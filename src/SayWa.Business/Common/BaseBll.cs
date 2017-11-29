using Microsoft.Extensions.Options;
using SayWa.Entities;
using SayWa.Entities.Common;
using SayWa.Service;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Business
{
    /// <summary>
    /// 基础BLL， 包括增删改查
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseBll<T> where T :BaseModel
    {
        private string _clsName;
        private IDatabase _cache;
        private BaseService<T> _service;
        private bool _cacheOpen = false;
        private IOptions<SysConfig> _config;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="clsName">分类名</param>
        /// <param name="cache">启用的缓存，仅支持ID为key的情况，其他情形请传空值</param>
        public BaseBll(BaseService<T> service, string clsName, IDatabase cache=null, IOptions<SysConfig> config=null)
        {
            _clsName = clsName;
            _cache = cache;
            _service = service;
            _cacheOpen = cache != null;
            _config = config;
        }

        /// <summary>
        /// 系统参数
        /// </summary>
        public virtual SysConfig SysConfig
        {
            get {
                if (_config == null) return new SysConfig();
                return _config.Value;
            }
        }

        /// <summary>
        /// 分类名
        /// </summary>
        protected virtual string ClsName
        {
            get { return _clsName; }
            //set { _clsName = value; }
        }

        /// <summary>
        /// 缓存
        /// </summary>
        public IDatabase Cache
        {
            get { return _cache; }
        }

        /// <summary>
        /// 缓存Key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual string GetKey(string id)
        {
            if (!_cacheOpen) return "";
            return RedisConfig.GetKey(ClsName, "item", id);
        }

        /// <summary>
        /// 读
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetModel(long id)
        {
            var key = GetKey(id.ToString());
            if (_cacheOpen)
            {               
                var m = _cache.Get<T>(key);
                if (m != null) return m;
            }
            var model = _service.GetModel(id);
            if(model!=null && _cacheOpen)
            {
                _cache.SetObj(key, model);
            }
            return model;
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="m"></param>
        /// <param name="id"></param>
        public virtual void SetCache<T>(T m,string id)
        {
            var key = GetKey(id.ToString());
            _cache.SetObj(key, m);
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual Result<long> Add(T model)
        {
            try
            {
                var chk = Check(model);
                if (!chk.IsSuccess()) return chk;
                var id = _service.Add(model, "");
                return Result<long>.SuccessBack(id);
            }
            catch (Exception ex)
            {
                return Result<long>.FailBack(ex.Message);
            }     
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual Result<long> Update(T model)
        {
            try
            {
                var chk = Check(model,false);
                if (!chk.IsSuccess()) return chk;
                var key = GetKey(model.Id.ToString());
                _cache.KeyDelete(key);
                var cnt = _service.Update(model, "");
                return Result<long>.SuccessBack(cnt);
            }
            catch (Exception ex)
            {
                return Result<long>.FailBack(ex.Message);
            }            
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Result<bool> Delete(long id)
        {
            try
            {
                if(_cacheOpen)
                {
                    var key = GetKey(id.ToString());
                    _cache.KeyDelete(key);
                }
                _service.Delete(id);
                return Result<bool>.SuccessBack(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.FailBack(ex.Message,null,false); 
            }
        }


        /// <summary>
        /// 检查
        /// </summary>
        /// <param name="model">model</param>
        /// <param name="bAdd">是否新增</param>
        /// <returns></returns>
        public virtual Result<long> Check(T model, bool bAdd = true)
        {
            var err = Result<long>.FailBack("数据检查不通过");
            if (model.Id <= 0 && !bAdd)
            {
                err.AddErrorMsg("ID", "不能为空");
            }
            if (err.ContainErrors()) return err;
            return Result<long>.SuccessBack(0);
        }
    }
}

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
    /// 基础BLL扩展，扩展了逻辑删除
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseBllExtend<T>:BaseBll<T> where T : BaseModel
    {  
        private IDatabase _cache;
        private BaseService<T> _service;
        private bool _cacheOpen = false;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="clsName"></param>
        /// <param name="cache"></param>
        public BaseBllExtend(BaseService<T> service, string clsName, IDatabase cache = null, IOptions<SysConfig> config=null) :base(service,clsName,cache,config)
        {
            _cache = cache;
            _service = service;
            _cacheOpen = cache != null;
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Result<bool> DeleteLogic(long id)
        {
            try
            {
                if (_cacheOpen)
                {
                    _cache.KeyDelete(base.GetKey(id.ToString()));
                }
                _service.DeleteLogic(id);
                return Result<bool>.SuccessBack(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.FailBack(ex.Message, null, false);
            }           
        }

    }
}

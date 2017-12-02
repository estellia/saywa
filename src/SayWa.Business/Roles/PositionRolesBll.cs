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
    public class PositionRolesBll : BaseBll<PositionRoles>
    {
        private PositionRoleService _service;
        private IDatabase _cache;
        private string _clsName;
        public PositionRolesBll(PositionRoleService service, IDatabase cache):base(service,"positionRoles",null)
        {
            _service = service;
            _cache = cache;
            _clsName = "positionRoles";
        }

        /// <summary>
        /// 查询职位角色列表
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public List<PositionRoles> GetList(long positionId)
        {
            if (positionId <= 0) return new List<PositionRoles>();
            var lst = _service.GetList(positionId);
            if (lst.Count > 0)
            {
                var key = GetKey(positionId.ToString());
                _cache.SetObj(key, lst);
            }
            return lst;
        }

        /// <summary>
        /// 重写获取key-以positionId为key
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public override string GetKey(string positionId)
        {
            return RedisConfig.GetKey(_clsName, "item", positionId);
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="positionId"></param>
        private void KeyDelete(long positionId)
        {
            var key = GetKey(positionId.ToString());
            _cache.KeyDelete(key);
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Result<long> Add(PositionRoles model)
        {
            var result = base.Add(model);
            if (result.IsSuccess()) KeyDelete(model.PositionId);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Result<long> Update(PositionRoles model)
        {
            var result = base.Update(model);
            if (result.IsSuccess()) KeyDelete(model.PositionId);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Result<bool> Delete(long id)
        {
            var m = GetModel(id);
            if (m == null) return Result<bool>.SuccessBack(true);
            var result = base.Delete(id);
            if (result.IsSuccess()) KeyDelete(m.PositionId);
            return result;
        }


        /// <summary>
        /// 检查
        /// </summary>
        /// <param name="model">model</param>
        /// <param name="bAdd">是否新增</param>
        /// <returns></returns>
        public override Result<long> Check(PositionRoles model, bool bAdd = true)
        {
            var err = Result<long>.FailBack("数据检查不通过");
            if (model.Id <= 0 && !bAdd)
            {
                err.AddErrorMsg("ID", "不能为空");
            }
            if (model.RoleId <= 0)
            {
                err.AddErrorMsg("RoleId", "不能为空");
            }
            if (model.PositionId <= 0)
            {
                err.AddErrorMsg("PositionId", "不能为空");
            }
            if (err.ContainErrors()) return err;
            var lst = GetList(model.PositionId);
            if (lst.FirstOrDefault(x => x.RoleId == model.RoleId && x.Id != model.Id) != null)
            {
                err.AddErrorMsg("RoleId,PositionId", "已存在的记录");
                return err;
            }
            return Result<long>.SuccessBack(0);
        }
    }
}

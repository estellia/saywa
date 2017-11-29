using Role.Entities;
using Role.Entities.Common;
using Role.Service;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role.Business
{
    public class DepartmentPositionBll : BaseBll<DepartmentPosition>
    {
        private DepartmentPositionService _service;
        private IDatabase _cache;
        private string _clsName;

        public DepartmentPositionBll(DepartmentPositionService service, IDatabase cache):base(service,"departmentPosition",null)
        {
            _service = service;
            _cache = cache;
            _clsName = "departmentPosition";
        }


        /// <summary>
        /// 检查
        /// </summary>
        /// <param name="model">model</param>
        /// <param name="bAdd">是否新增</param>
        /// <returns></returns>
        public override Result<long> Check(DepartmentPosition model, bool bAdd = true)
        {
            var err = Result<long>.FailBack("数据检查不通过");
            if (model.Id <= 0 && !bAdd)
            {
                err.AddErrorMsg("ID", "不能为空");
            }
            if (model.DepartmentId <= 0)
            {
                err.AddErrorMsg("DepartmentId", "不能为空");
            }
            if (model.PositionId <= 0)
            {
                err.AddErrorMsg("PositionId", "不能为空");
            }
            if (err.ContainErrors()) return err;
            var lst = GetList(model.DepartmentId);
            if (lst.FirstOrDefault(x => x.PositionId == model.PositionId && x.Id != model.Id) != null)
            {
                err.AddErrorMsg("DepartmentId,PositionId", "已存在的记录");
                return err;
            }
            return Result<long>.SuccessBack(0);
        }

        /// <summary>
        /// 查询部门职位列表
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public List<DepartmentPosition> GetList(long departmentId)
        {
            if (departmentId <= 0) return new List<DepartmentPosition>();
            var lst = _service.GetList(departmentId);
            if (lst.Count > 0)
            {
                var key = GetKey(departmentId.ToString());
                _cache.SetObj(key, lst);
            }
            return lst;
        }

        /// <summary>
        /// 重写获取key-以Department为key
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public override string GetKey(string departmentId)
        {
            return RedisConfig.GetKey(_clsName, "item", departmentId);
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="roleId"></param>
        private void KeyDelete(long departmentId)
        {
            var key = GetKey(departmentId.ToString());
            _cache.KeyDelete(key);
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Result<long> Add(DepartmentPosition model)
        {
            var result = base.Add(model);
            if (result.IsSuccess()) KeyDelete(model.DepartmentId);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Result<long> Update(DepartmentPosition model)
        {
            var result = base.Update(model);
            if (result.IsSuccess()) KeyDelete(model.DepartmentId);
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
            if (result.IsSuccess()) KeyDelete(m.DepartmentId);
            return result;
        }
    }
}

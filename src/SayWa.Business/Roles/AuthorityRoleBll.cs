using Microsoft.Extensions.Options;
using SayWa.Business;
using SayWa.Entities;
using SayWa.Entities.Common;
using SayWa.Service;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role.Business
{
    public class AuthorityRoleBll : BaseBll<AuthorityRole>
    {
        private AuthorityRoleService _service;
        private RoleBll _roleBll;
        private AuthorityBll _authBll;
        private IDatabase _cache;
        private string _clsName;       
        public AuthorityRoleBll(AuthorityRoleService service, IDatabase cache,
                                RoleBll roleBll, AuthorityBll authBll, IOptions<SysConfig> config) :base(service,"authorityRole",null,config)
        {
            _service = service;
            _cache = cache;
            _clsName = "authorityRole";
            _roleBll = roleBll;
            _authBll = authBll;
        }

        /// <summary>
        /// 重写获取key-以Role为key
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public override string GetKey(string roleId)
        {
            return RedisConfig.GetKey(_clsName, "item", roleId);
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="roleId"></param>
        private void KeyDelete(long roleId)
        {
            var key = GetKey(roleId.ToString());
            _cache.KeyDelete(key);
        }

        /// <summary>
        /// 查询角色拥有的权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<AuthorityRole> GetList(long roleId)
        {
            if (roleId <= 0) return new List<AuthorityRole>();
            var role = _roleBll.GetModel(roleId);
            if (role == null || role.IsDelete > 0) return new List<AuthorityRole>();
            if(role.IsAdmin>0) //管理员
            {
                roleId = base.SysConfig.AdminId;
            }
            var lst= _service.GetList(roleId);
            if (lst.Count > 0)
            {
                var key = GetKey(roleId.ToString());
                _cache.SetObj(key,lst);
            }
            return lst;
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Result<long> Add(AuthorityRole model)
        {
            var result= base.Add(model);
            if (result.IsSuccess()) KeyDelete(model.RoleId);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Result<long> Update(AuthorityRole model)
        {
            var result = base.Update(model);
            if (result.IsSuccess()) KeyDelete(model.RoleId);
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
            if (result.IsSuccess()) KeyDelete(m.RoleId);           
            return result;
        }

        /// <summary>
        /// 检查
        /// </summary>
        /// <param name="model">model</param>
        /// <param name="bAdd">是否新增</param>
        /// <returns></returns>
        public override Result<long> Check(AuthorityRole model,bool bAdd=true)
        {
            var err = Result<long>.FailBack("数据检查不通过");
            if (model.Id <= 0 && !bAdd)
            {
                err.AddErrorMsg("ID", "不能为空");
            }
            if (model.AuthorityId <= 0)
            {
                err.AddErrorMsg("AuthorityId", "不能为空");
            }
            if (model.RoleId <= 0)
            {
                err.AddErrorMsg("RoleId", "不能为空");
            }
            if (err.ContainErrors()) return err;
            var lst = GetList(model.RoleId);
            if(lst.FirstOrDefault(x => x.AuthorityId == model.AuthorityId && x.Id != model.Id) != null)
            {
                err.AddErrorMsg("AuthorityId,RoleId", "已存在的记录");
                return err;
            }
            return Result<long>.SuccessBack(0);
        }
        
    }
}

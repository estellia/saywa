using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Role.Business;
using System.Web.Http;
using SayWa.Entities;
using SayWa.Entities.Query;
using Microsoft.Extensions.Options;
using SayWa.Entities.Common;
using SayWa.Business;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SayWa.Controllers
{   
    [Route("v1")]
    public class AuthorityController : BaseController<Authority>
    {
        private AuthorityBll _bll;
        private AuthorityRoleBll _authRoleBll;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="bll"></param>
        public AuthorityController(AuthorityBll bll,AuthorityRoleBll authRoleBll,
            IOptions<SysConfig> config):base(bll,config)
        {
            _bll = bll;
            _authRoleBll = authRoleBll;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("authority/{id}")]
        public override JsonResult Get(long id)
        {
            return base.Get(id);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("authoritys")]
        public virtual JsonResult Query()
        {
            var m = _bll.Query(new AuthorityQuery());
            return JsonsResult(m);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("authority")]
        public override JsonResult Add([FromBody]Authority m)
        {
            var res = _bll.Add(m);
            if (!res.IsSuccess()) return Json(res);
            var roleId = base.SysConfig.AdminId;
            _authRoleBll.Add(new AuthorityRole()
            {
                RoleId = roleId,
                AuthorityId = res.returnValue
            });
            return Json(res);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("authority/{id}")]
        public override JsonResult Update([FromBody]Authority m,long id)
        {
            return base.Update(m, id);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("authority/{id}")]
        public override JsonResult Delete(long id)
        {
            var res = _bll.DeleteLogic(id);
            return Json(res);
        }
    }
}

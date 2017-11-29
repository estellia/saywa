using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Role.Business;
using Role.Entities;
using Microsoft.Extensions.Options;
using Role.Entities.Common;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Role.Roles.Controllers
{
    [Route("v1")]
    public class RolesController : BaseController<RolesTb>
    {
        private RoleBll _bll;      

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="bll"></param>
        public RolesController(RoleBll bll,AuthorityRoleBll authRoleBll):base(bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("roles/{id}")]
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
        [Route("roles")]
        public virtual JsonResult Query()
        {
            var m = _bll.Query(new Entities.Query.RolesQuery());
            return JsonsResult(m);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("roles")]
        public override JsonResult Add([FromBody]RolesTb m)
        {
            return base.Add(m);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("roles/{id}")]
        public override JsonResult Update([FromBody]RolesTb m, long id)
        {
            return base.Update(m,id);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("roles/{id}")]
        public override JsonResult Delete(long id)
        {
            var res = _bll.DeleteLogic(id);
            return Json(res);
        }
    }
}

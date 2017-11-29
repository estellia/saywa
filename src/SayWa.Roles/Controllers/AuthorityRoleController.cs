using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Role.Business;
using SayWa.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SayWa.Controllers
{
    [Route("v1")]
    public class AuthorityRoleController : BaseController<AuthorityRole>
    {
        private AuthorityRoleBll _bll;
        public AuthorityRoleController(AuthorityRoleBll bll):base(bll)
        {
            _bll = bll;
        }

        #region override
        /// <summary>
        /// get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("authority-role/{id}")]
        public override JsonResult Get(long id)
        {
            return base.Get(id);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("authority-role")]
        public override JsonResult Add([FromBody] AuthorityRole m)
        {
            return base.Add(m);
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("authority-role/{id}")]
        public override JsonResult Update([FromBody] AuthorityRole m, long id)
        {
            return base.Update(m, id);
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("authority-role/{id}")]
        public override JsonResult Delete(long id)
        {
            return base.Delete(id);
        }
        #endregion override
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Role.Entities;
using Role.Business;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Role.Roles.Controllers
{
    [Route("v1")]
    public class DepartmentController :BaseController<Department>
    {
        private DepartmentBll _bll;
        public DepartmentController(DepartmentBll bll):base(bll)
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
        [Route("department/{id}")]
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
        [Route("department")]
        public override JsonResult Add([FromBody] Department m)
        {
            return base.Add(m);
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("department/{id}")]
        public override JsonResult Update([FromBody] Department m, long id)
        {
            return base.Update(m, id);
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("department/{id}")]
        public override JsonResult Delete(long id)
        {
            return Json(_bll.DeleteLogic(id));
        }
        #endregion override

    }
}

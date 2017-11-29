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
    public class DepartmentPositionController : BaseController<DepartmentPosition>
    {
        private DepartmentPositionBll _bll;
        public DepartmentPositionController(DepartmentPositionBll bll):base(bll)
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
        [Route("department-position/{id}")]
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
        [Route("department-position")]
        public override JsonResult Add([FromBody] DepartmentPosition m)
        {
            return base.Add(m);
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("department-position/{id}")]
        public override JsonResult Update([FromBody] DepartmentPosition m, long id)
        {
            return base.Update(m, id);
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("department-position/{id}")]
        public override JsonResult Delete(long id)
        {
            return base.Delete(id);
        }
        #endregion override
    }
}

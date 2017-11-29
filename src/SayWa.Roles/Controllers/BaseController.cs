using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using SayWa.Entities;
using Microsoft.Extensions.Options;
using SayWa.Entities.Common;
using SayWa.Business;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SayWa.Controllers
{
    public class BaseController<TClass> : ApiController where TClass :BaseModel
    {
        private SysConfig _sysConfig=new SysConfig();
        private BaseBll<TClass> _bll;
        public BaseController(BaseBll<TClass> bll,IOptions<SysConfig> config = null)
        {
            if (config != null) _sysConfig = config.Value;
            _bll = bll;
        }

        protected virtual SysConfig SysConfig
        {
            get
            {
                return _sysConfig;
            }
        }


        public override JsonResult Json<T>(T content)
        {
            return base.Json<T>(content);
        }

        /// <summary>
        /// 为model包括一个Result后返回
        /// </summary>
        /// <param name="content"></param>
        /// <param name="isSuccess"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public JsonResult JsonsResult(object content ,bool isSuccess = true, string message = "")
        {
            if (!isSuccess || content == null)
            {
                return Json(Result<object>.FailBack("没有找到信息"));
            }
            return Json(Result<object>.SuccessBack(content));
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public virtual JsonResult Get(long id)
        {
            var m = _bll.GetModel(id);
            return JsonsResult(m);
        }
        
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual JsonResult Add([FromBody]TClass m)
        {
            var res = _bll.Add(m);
            return Json(res);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual JsonResult Update([FromBody]TClass m, long id)
        {
            m.Id = id;
            var res = _bll.Update(m);
            return Json(res);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual JsonResult Delete(long id)
        {
            var res = _bll.Delete(id);
            return Json(res);
        }
    }
}

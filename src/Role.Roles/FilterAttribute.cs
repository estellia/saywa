using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Role.Entities;
using System;
using System.Linq;

namespace Role.Roles
{
    /// <summary>
    /// 授权过滤器，用于检查token
    /// </summary>
    public class TokenAuthorizationFilter : IAuthorizationFilter//, IAsyncAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var m = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            var attr = m.MethodInfo.CustomAttributes;
            if (!attr.Select(x => x.AttributeType).Contains(typeof(LoginFucAttribute))) {
                if(!CheckToken())
                {
                    context.Result = FilterResult.ToLoginResult();
                    return;
                }
            }
        }

        private bool CheckToken()
        {
            return true;
        }
    }

    /// <summary>
    /// action过滤器，用于action检查
    /// </summary>
    public class MyActionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }

    /// <summary>
    /// 注册方法标志
    /// -用于不需进行token校验的方法
    /// </summary>
    public class LoginFucAttribute : Attribute
    {
        public LoginFucAttribute()
        {

        }
    }

    /// <summary>
    /// filter校验不通过返回结果
    /// </summary>
    public class FilterResult
    {
        public static JsonResult ToLoginResult()
        {
            var obj = Result<bool>.FailBack("用户未登录");
            return new JsonResult(obj);
        }
    }
}

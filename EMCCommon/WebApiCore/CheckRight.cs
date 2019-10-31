using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace EMCControls.WebApiCore
{
    /// <summary>
    /// 权限检查
    /// </summary>
    public class CheckRight : AuthorizeAttribute
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string fldUserID;
        /// <summary>
        /// 重写基类的验证方式，加入我们自定义的Ticket验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //url获取token
            var content = actionContext.Request.Properties["MS_HttpContext"] as HttpContextBase;
            var sRightKey = string.Empty;
            if (content.Request.Headers["sRightKey"] != null && content.Request.Headers["sRightKey"] != "")
            {
                sRightKey = content.Request.Headers["sRightKey"].ToString();
            }
            if (!string.IsNullOrEmpty(sRightKey))
            {
                ////解密用户ticket,并校验用户名密码是否匹配
                //if (ValidateAuth(sRightKey))
                //{
                //    base.IsAuthorized(actionContext);
                //}
                //else
                //{
                //    HandleUnauthorizedRequest(actionContext);
                //}
            }
            //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
        }
    }
}
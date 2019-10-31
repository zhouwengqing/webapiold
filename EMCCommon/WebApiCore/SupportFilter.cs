using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Newtonsoft.Json.Linq;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;

namespace EMCCommon.EMCCommon.AccountController.WebApiCore
{
    /// <summary>
    /// 过滤类：SupportFilter并继承AuthorizeAttribute权限筛选器OnAuthorization基类方法
    /// </summary>
    public class SupportFilter : AuthorizeAttribute
    {
        /// <summary>
        /// 重写基类的验证方式，加入我们自定义的Ticket验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //url获取token
            var content = actionContext.Request.Properties["MS_HttpContext"] as HttpContextBase;
            var token = string.Empty;
            if (content.Request.Headers["Token"] != null && content.Request.Headers["Token"] != "")
            {
                token = content.Request.Headers["Token"].ToString();
            }
            if (!string.IsNullOrEmpty(token))
            {
                //解密用户ticket,并校验用户名密码是否匹配
                if (ValidateTicket(token))
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
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

        //校验用户名密码（对Session匹配，或数据库数据匹配）
        private bool ValidateTicket(string encryptToken)
        {

            try
            {
                //解密Ticket
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                string json = "[" + decoder.Decode(encryptToken, "YYplay", verify: true).ToString() + "]";//token为之前生成的字符串

                if (json == null)
                {
                    return false;
                }


                return true;
            }
            catch (Exception x)
            {
                return false;
            }

        }
    }
}
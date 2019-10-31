using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace EMCCommon.Common
{
    /// <summary>
    /// 功能描述：商户系统登录
    /// 创建  人：周文卿
    /// 创建时间：2018-12-13
    /// </summary>
    public class MerchantLoginController : ApiController
    {
        /// <summary>
        /// 功能描述：商户系统登录认证
        /// 创建  人：周文卿
        /// 创建时间：2018-12-13
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public HttpResponseMessage LoginMerchant(string username, string password)
        {
            string result = string.Empty;
            RuleCommon rule = new RuleCommon();
            try
            {
                string massge = "";
                //到数据库进行校验
                if (CheckUser(username, password, ref massge) == false)
                {
                    result = rule.JsonStr("error", massge, "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };

                }
                DateTime dtime = DateTime.Parse(DateTime.Now.ToShortDateString());
                IDateTimeProvider provider = new UtcDateTimeProvider();
                var now = provider.GetNow();
                var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // or use JwtValidator.UnixEpoch
                var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds);
                var payload = new Dictionary<string, object>
                {
                    {"exp",secondsSinceEpoch+10000 },
                    {"name",username }
                };
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                var token = encoder.Encode(payload, "YYplayMerchant");

                ////返回登录结果、用户信息、用户验证票据信息
                //var Token = FormsAuthentication.Encrypt(token);
                ////将身份信息保存在session中，验证当前请求是否是有效请求
                //if (HttpContext.Current.Session[username] == null)
                //    HttpContext.Current.Session[username] = Token;
                LoginInfo lginfo = new LoginInfo();

                lginfo.token = token;

                result = rule.JsonStr("ok", "", lginfo);
                //插入登录日志
                CheckIP checkIP = new CheckIP();
                string ip = checkIP.GetIP();

                using (Model1 db = new Model1())
                {
                    tblMerchantLog tblMerchantLog = new tblMerchantLog();
                    tblMerchantLog.fldAutoID = 0;
                    tblMerchantLog.fldLoginCity = "";
                    tblMerchantLog.fldLoginIP = ip;
                    tblMerchantLog.fldLoginTime = DateTime.Now;
                    tblMerchantLog.fldMerchant = username;
                    db.tblMerchantLog.Add(tblMerchantLog);
                    db.SaveChanges();
                }

                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
   
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage UserInfo(string token)
        {
            string result = string.Empty;
            RuleCommon rule = new RuleCommon();
            try
            {
                string message = "";

                //var strTicket = FormsAuthentication.Decrypt(token).UserData;

                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                string json = "[" + decoder.Decode(token, "YYplayMerchant", verify: true).ToString() + "]";//token为之前生成的字符串
                string userName = "";
                JArray jsonObj = JArray.Parse(json);
                string password = "";
                for (int i = 0; i < jsonObj.Count; i++)
                {
                    userName = jsonObj[i]["name"].ToString();

                }

               



                LoginInfo lginfo = new LoginInfo();

                lginfo.userid = "1";
                lginfo.roleid = "1";
                lginfo.token = "";
                lginfo.cityid = "1";
                lginfo.username = userName;
                lginfo.roles = "super_admin";
                lginfo.introduction = "super_admin";
                lginfo.avatar = "super_admin";

                result = rule.JsonStr("ok", "", lginfo);
                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
            }


        }

        /// <summary>
        /// 到数据库进行校验登录信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="massge">提示信息</param>
        /// <returns></returns>
        private bool CheckUser(string username, string password, ref string massge)
        {
            bool bOk = true;

            RuletblFW_User ruleUser = new RuletblFW_User();

            using (YYPlayContext db = new YYPlayContext())
            {
                tbleMerchant tbleMerchant = (from x in db.tbleMerchant
                                             where x.fldMerchID == username &&
                                             x.fldMaPass == password
                                             select x).SingleOrDefault();

                if (tbleMerchant == null)
                {
                    bOk = false;
                }



                return bOk;
            }



        }


        /// <summary>
        /// /
        /// </summary>

        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage logout()
        {
            string result = string.Empty;
            RuleCommon rule = new RuleCommon();
            try
            {
                HttpContext.Current.Session.Abandon();
                result = rule.JsonStr("ok", "", "");
                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
            }


        }
    }
}

using DDYZ.Ensis.Rule.DataRule;
using DDYZ.Ensis.Presistence.DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System.Web.Http;
using System.Web.Security;
using DDYZ.Ensis.Library.Lib.account;
using EMCCommon.EMCCommon.AccountController.WebApiCore;
using Newtonsoft.Json.Linq;

namespace EMCCommon.Common
{
    /// <summary>
    /// 账号controller
    /// </summary>
    public class AccountController : ApiController
    {

        /// <summary>
        /// 功能描述    ：  登录认证
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2018-10-22
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>

        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Login(string username, string password)
        {
            string result = string.Empty;
            RuleCommon rule = new RuleCommon();
            try
            {
                tblFW_User objUser = new tblFW_User();
                //到数据库进行校验
                if (CheckUser(username, password, "", ref objUser) == false)
                {
                    result = rule.JsonStr("error", "用户名或密码错误", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };

                }
                DateTime dtime = DateTime.Parse(DateTime.Now.ToShortDateString());
                IDateTimeProvider provider = new UtcDateTimeProvider();
                var now = provider.GetNow();
                var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // or use JwtValidator.UnixEpoch
                var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds);
                var payload = new Dictionary<string, object>
                {
                    { "pass", password },
                    {"exp",secondsSinceEpoch+10000 },
                    {"name",username }
                };
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                var token = encoder.Encode(payload, "YYplay");

                ////返回登录结果、用户信息、用户验证票据信息
                //var Token = FormsAuthentication.Encrypt(token);
                ////将身份信息保存在session中，验证当前请求是否是有效请求
                //if (HttpContext.Current.Session[username] == null)
                //    HttpContext.Current.Session[username] = Token;
                LoginInfo lginfo = new LoginInfo();

                lginfo.token = token;

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
        /// <param name="cityid">城市ID</param>
        /// <param name="User">当前登录用户信息</param>
        /// <returns></returns>
        private bool CheckUser(string username, string password, string cityid, ref tblFW_User User)
        {
            bool bOk = true;

            RuletblFW_User ruleUser = new RuletblFW_User();

            DDYZ.Ensis.Rule.BusinessRule.UserManage.Common comm = new DDYZ.Ensis.Rule.BusinessRule.UserManage.Common();

            tblFW_User objUser = ruleUser.ByUserName(username, cityid);
            User = objUser;
            if (objUser == null || objUser.IsEmpty)
            {
                bOk = false;
            }
            if (objUser.fldActive == false)
            {
                bOk = false;
            }
            if (objUser.fldPassword != password)
            {
                bOk = false;
            }

            return bOk;
        }

        /// <summary>
        /// /
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
                tblFW_User objUser = new tblFW_User();

                //var strTicket = FormsAuthentication.Decrypt(token).UserData;

                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                string json = "[" + decoder.Decode(token, "YYplay", verify: true).ToString() + "]";//token为之前生成的字符串
                string userName = "";
                JArray jsonObj = JArray.Parse(json);
                string password = "";
                for (int i = 0; i < jsonObj.Count; i++)
                {
                    userName = jsonObj[i]["name"].ToString();
                    password= jsonObj[i]["pass"].ToString();
                }

                

                RuletblFW_User users = new RuletblFW_User();
                if (CheckUser(userName, password, "", ref objUser) == false)
                {
                    result = rule.JsonStr("error", "请重新登录，获取Token！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };

                }




                LoginInfo lginfo = new LoginInfo();
                lginfo.userid = objUser.fldAutoID.ToString();
                lginfo.roleid = objUser.fldRoleID;
                lginfo.token = "";
                lginfo.cityid = objUser.fldCityID.ToString();
                lginfo.username = objUser.fldUserName;
                lginfo.roles = objUser.fldroles;
                lginfo.introduction = objUser.fldintroduction;
                lginfo.avatar = objUser.fldavatar;
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

    /// <summary>
    /// 登录用户信息
    /// </summary>
    public class LoginInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string userid { get; set; }

        /// <summary>
        /// 用户角色ID
        /// </summary>
        public string roleid { get; set; }

        /// <summary>
        /// 用户身份验证密钥
        /// </summary>
        public string token { get; set; }

        /// <summary>
        /// 登录用户城市ID
        /// </summary>
        public string cityid { get; set; }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string roles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string introduction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string avatar { get; set; }
    }

}

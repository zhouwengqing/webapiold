using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCCommon.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemUrlController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  获取系统链接地址
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-12-04
        /// 修改者      ：  
        /// 修改日期    ：  
        /// 修改原因    ：  
        /// </summary>
        /// <returns>返回系统链接地址</returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage GetSysUrlAll()
        {
            string result = string.Empty;
            try
            {
                DataTable dt = rule.GetSysUrl();
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}

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
    /// 功能描述：获得用户表
    /// 创建  人：周文卿
    /// 创建时间：2018/03/29
    /// </summary>
    public class GetUserListController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获得用户列表
        /// 创建  人：周文卿
        /// 创建时间：2018/03/29
        /// 修改时间：
        /// 修改  人：
        /// 修改原因：
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]

        public HttpResponseMessage GetUserList()
        {
            string result = string.Empty;
            try
            {
                string sql = "select [fldAutoID],[fldUserName] from LAPtblFW_User";
                DataTable dt=rule.getdt(sql);
                if (dt.Rows.Count > 0)
                {
                    result = rule.JsonStr("ok", "", dt);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

    }
}

using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_DemoMiddle.Common
{
    /// <summary>
    /// 获得城市列表
    /// </summary>
    public class GetCityListController : ApiController
    {
        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获得城市列表
        /// 创建时间：2017/09/29
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="stcode"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCityLIST(string stcode)
        {
            string result = "";
            string where = "1=1";
            try
            {
                if (rule.Judge(stcode))
                {
                    where += " and fldSTCode='" + stcode + "'";
                }
                string sql = "select * from tblFW_RegCity where " + where + " and fldParentID='2'";
                DataTable dt = rule.GetMiddleData(sql);

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

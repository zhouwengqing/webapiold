using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_n
{
    public class SectionRelevantController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  获取断面信息
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-03-26
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="year">年</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetSection(string year)
        {
            string result = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt=rule.getdt("select * from tblEQIW_N_Section where fldyear="+ year);
                result = rule.JsonStr("ok", "", dt);
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

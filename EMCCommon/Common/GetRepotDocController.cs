using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DDYZ.Ensis.Rule.DataRule;

using System.Data;

namespace EMCCommon.Common
{
    /// <summary>
    /// 功能描述：针对tblReport_Doc表的操作
    /// 创建  人：周文卿
    /// 创建时间：2017/10/24
    /// </summary>
    public class GetRepotDocController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获得每张表的模板内容
        /// 创建时间：2017/10/24
        /// 创建  人：周文卿
        /// 修改  人：
        /// 修改时间：
        /// 修改原因：
        /// </summary>
        /// <param name="concent"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage GetReportDocList(dynamic concent)
        {
            string result = "";
            try
            {
                string sql = "select * from tblReport_Doc where fldReportName='" + concent.fldReportName + "' and fldType='" + concent.fldType + "'";
                DataTable dt = rule.SqlQueryForDataTatable("EntityContext", sql);
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：更新或者插入文档
        /// 创建时间：2017/10/24
        /// 创建  人：周文卿
        /// 修改  人：
        /// 修改时间：
        /// 修改原因：
        /// </summary>
        /// <param name="concent"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage InsertorUpdateDoct(dynamic concent)
        {
            string result = "";
            try
            {
                RuletblReport_Doc doc = new RuletblReport_Doc();
                int i = doc.InsertorUpdateDoc(concent.Type.ToString(), concent.name.ToString(), concent.userid.ToString(), concent.concent.ToString());
                if (i > 0)
                {
                    result = rule.JsonStr("ok", "", "成功");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}

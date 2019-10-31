using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_DemoMiddle.Eqiw.eqiw_r
{
    public class GetSectionController : ApiController
    {
        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获得河流断面基本信息
        /// 创建时间：2017/09/24
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="GP">查询的参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetSectionBasic(GisParameter GP)
        {
            string result = "";
            string where = "1=1";
            try
            {
                if (rule.Judge(GP.fldSTCode))
                {
                    where += " and fldSTCode='" + GP.fldSTCode + "'";
                }
                if (rule.Judge(GP.fldRCode))
                {
                    where += " and fldRCode='" + GP.fldRCode + "'";
                }
                if (rule.Judge(GP.fldRSCode))
                {
                    where += " and fldRSCode='" + GP.fldRSCode + "'";
                }
                if (rule.Judge(GP.year))
                {
                    where += " and fldYear='" + GP.year + "'";
                }
                string sql = "select * from vwtblEQIW_R_Section where " + where;
                DataTable dt = rule.GetMiddleData(sql);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 断面相关的参数
        /// </summary>
        public class GisParameter
        {
            /// <summary>
            /// 年份
            /// </summary>
            public string year { get; set; }

            /// <summary>
            /// 城市代码
            /// </summary>
            public string fldSTCode { get; set; }



            /// <summary>
            /// 河流代码
            /// </summary>
            public string fldRCode { get; set; }



            /// <summary>
            /// 断面代码
            /// </summary>
            public string fldRSCode { get; set; }



            /// <summary>
            /// 控制级别
            /// </summary>
            public string fldPLevel { get; set; }
        }
    }
}

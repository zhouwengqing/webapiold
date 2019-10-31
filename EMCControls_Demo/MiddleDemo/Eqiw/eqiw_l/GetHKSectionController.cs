using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_DemoMiddle.Eqiw.eqiw_l
{
    /// <summary>
    /// 获得湖库基本信息
    /// </summary>
    public class GetHKSectionController : ApiController
    {
        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获得湖库基本信息
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
                if (rule.Judge(GP.stcode))
                {
                    where += " and fldSTCode='" + GP.stcode + "'";
                }
                if (rule.Judge(GP.lcode))
                {
                    where += " and fldLCode='" + GP.lcode + "'";
                }
                if (rule.Judge(GP.lscode))
                {
                    where += " and fldLSCode='" + GP.lscode + "'";
                }
                if (rule.Judge(GP.year))
                {
                    where += " and fldYear='" + GP.year + "'";
                }
                string sql = "select * from vwtblEQIW_L_Section where " + where;
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
        ///湖库相关的参数
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
            public string stcode { get; set; }



            /// <summary>
            /// 河流代码
            /// </summary>
            public string lcode { get; set; }



            /// <summary>
            /// 断面代码
            /// </summary>
            public string lscode { get; set; }



           
        }

    }
}

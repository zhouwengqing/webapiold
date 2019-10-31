using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_DemoMiddle.Eqia.Eqia_r
{

    /// <summary>
    /// 获得城市AQI
    /// </summary>
    public class GetCityAQIController : ApiController
    {
        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获得城市AQI
        /// 创建时间：2017/09/29
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="GP">查询的参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetCityAqi(GisParameter GP)
        {
            string result = "";
            string where = "1=1";
            try
            {
                if (rule.Judge(GP.stcode))
                {
                    where += " and fldSTCode='" + GP.stcode + "'";
                }
                if (rule.Judge(GP.pcode))
                {
                    where += " and fldPCode='" + GP.pcode + "'";
                }

                if (rule.istime(GP.BeginDate))
                {
                    where += " and CONVERT(datetime,CAST(fldYear  as varchar(50))+'-'+CAST(fldMonth as varchar(50))+'-'+CAST(fldDay as varchar(50)),110)='" + GP.BeginDate + "'";
                }
                else
                {
                    result = rule.JsonStr("error", "时间格式不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }
                string sql = "select * from vwtblEQIA_R_CityData where " + where;
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
        ///城市AQI相关的参数
        /// </summary>
        public class GisParameter
        {
            /// <summary>
            /// 年份
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 城市代码
            /// </summary>
            public string stcode { get; set; }



            /// <summary>
            /// 测点代码
            /// </summary>
            public string pcode { get; set; }






        }
    }
}

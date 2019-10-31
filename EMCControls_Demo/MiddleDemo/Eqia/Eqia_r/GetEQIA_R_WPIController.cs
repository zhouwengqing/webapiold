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
    /// 空气WPI
    /// </summary>
    public class GetEQIA_R_WPIController : ApiController
    {
        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获得城市wpi
        /// 创建时间：2017/10/04
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="GP">查询的参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetCityWPI(GisParameter GP)
        {
            string result = "";
            string where = "1=1";
            string where2 = "1=1";
            try
            {
                if (rule.Judge(GP.stcode))
                {
                    where += " and fldSTCode='" + GP.stcode + "'";
                }
                if (rule.Judge(GP.stname))
                {
                    where += " and fldSTName='" + GP.stname + "'";
                }

                if (rule.istime(GP.BeginDate))
                {
                    DateTime dtime = DateTime.Parse(GP.BeginDate);
                    where += " and fldDate='" + dtime.Year + "年" + dtime.Month + "月'";
                    where2 += " and fldDate='" + dtime.Year + "年" + dtime.Month + "月'";
                }
                else
                {
                    result = rule.JsonStr("error", "时间格式不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }
                string sql = "select * from tblEQIA_R_WPI where " + where;
                DataTable dt = rule.GetMiddleData(sql);
               
                retudt tt = new retudt();
                tt.DQ = dt;
               
                result = rule.JsonStr("ok", "", tt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        ///相关的参数
        /// </summary>
        public class GisParameter
        {
            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }


            /// <summary>
            /// 开始时间
            /// </summary>
            public string EenDate { get; set; }

            /// <summary>
            /// 城市代码
            /// </summary>
            public string stcode { get; set; }



            /// <summary>
            /// 城市名称
            /// </summary>
            public string stname { get; set; }






        }


        public class retudt
        {
            /// <summary>
            /// 当期
            /// </summary>
            public DataTable DQ { get; set; }

           


        }
    }
}

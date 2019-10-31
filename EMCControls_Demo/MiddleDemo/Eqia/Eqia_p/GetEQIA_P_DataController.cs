using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_DemoMiddle.Eqia.Eqia_p
{
    /// <summary>
    /// 获得降水的数据
    /// </summary>
    public class GetEQIA_P_DataController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：获得降水数据
        /// 创建  人：周文卿
        /// 创建时间：2017/10/03
        /// </summary>
        /// <param name="DP"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage GetEQIA_P_data(DataParameter DP)
        {
            string result = "";
            string defwhere = "1=1";
            try
            {
                if (rule.Judge(DP.pcode))
                {
                    defwhere += " and fldCode='" + DP.pcode + "'";
                }

                if (rule.Judge(DP.stcode))
                {
                    defwhere += " and fldSTCode='" + DP.stcode + "'";
                }
                if (rule.JudgeLevel(DP.type))
                {
                    if (DP.type == "0")
                    {
                        defwhere += " and fldPName='全市'";
                    }
                    if (DP.type == "1")
                    {
                        defwhere += " and fldPName !='全市'";
                    }
                }
                if (rule.istime(DP.BeginDate) && rule.istime(DP.EndDate))
                {

                    DateTime dtime = DateTime.Parse(DP.BeginDate);
                    if (dtime.Month < 10)
                    {
                        string ti = dtime.Year + "年0" + dtime.Month + "月";
                        defwhere += " and fldDate='" + ti + "'";
                    }
                    else
                    {
                        string ti = dtime.Year + "年" + dtime.Month + "月";
                        defwhere += " and fldDate='" + ti + "'";
                    }
                }
                else
                {
                    result = rule.JsonStr("error", "时间格式不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }
                //当期
                string sql = "select * from vwtblEQIA_P_Data where " + defwhere;
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
        /// 湖库数据相关的参数
        /// </summary>
        public class DataParameter
        {


            /// <summary>
            /// 城市代码
            /// </summary>
            public string stcode { get; set; }

            /// <summary>
            /// 是否有全省的点位
            /// </summary>
            public string type { get; set; }


            /// <summary>
            /// 点位代码
            /// </summary>
            public string pcode { get; set; }

            /// <summary>


            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 结束时间时间
            /// </summary>
            public string EndDate { get; set; }
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

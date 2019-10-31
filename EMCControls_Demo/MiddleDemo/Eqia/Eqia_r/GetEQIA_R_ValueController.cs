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
    /// 空气城市点位污染物浓度值
    /// </summary>
    public class GetEQIA_R_ValueController : ApiController
    {
        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获得城市污染物
        /// 创建时间：2017/09/29
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="GP">查询的参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetEQIA_R_Value(GisParameter GP)
        {
            string result = "";
            string where = "1=1";
            string where2 = "1=1";
            string where3 = "";
            string where4 = "";
            try
            {
                if (rule.Judge(GP.type))
                {
                    if (GP.type == "城市")
                    {
                        where += " and fldPName='全市'";
                    }
                    if (GP.type == "测点")
                    {
                        where += " and fldPName !='全市'";
                    }
                }
                else
                {
                    result = rule.JsonStr("error", "测点类型不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }
                if (rule.Judge(GP.itemcode))
                {

                    where += " and fldItemCode='" + GP.itemcode + "'";
                    where2 += " and fldItemCode='" + GP.itemcode + "'";
                }
                else
                {
                    result = rule.JsonStr("error", "因子代码不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }
                if (rule.Judge(GP.stcode))
                {
                    where += " and fldSTCode='" + GP.stcode + "'";
                }
                if (rule.Judge(GP.pcode))
                {
                    where += " and fldPCode='" + GP.pcode + "'";
                }
                where3 += where2;
                where4 += where2;
                if (rule.istime(GP.BeginDate))
                {
                    DateTime dtime = DateTime.Parse(GP.BeginDate);
                    if (GP.type == "城市")
                    {
                        where += " and  fldDate='" + dtime.Year + "年" + dtime.Month + "月'";
                        where2 += " and  fldDate='" + dtime.Year + "年" + dtime.Month + "月'";

                        where3 += " and fldDate='" + (dtime.Year - 1) + "年" + dtime.Month + "月'";
                        if (dtime.Month == 1)
                        {
                            where4 += " and fldDate='" + (dtime.Year - 1) + "年12月'";
                        }
                        else
                        {
                            where4 += " and fldDate='" + (dtime.Year) + "年" + (dtime.Month - 1) + "月'";
                        }
                    }
                    else
                    {
                        if (dtime.Month < 10)
                        {
                            where += " and  fldDate='" + dtime.Year + "年" + dtime.Month + "月'";
                            where2 += " and  fldDate='" + dtime.Year + "年0" + dtime.Month + "月'";
                        }
                        else
                        {
                            where += " and  fldDate='" + dtime.Year + "年" + dtime.Month + "月'";
                            where2 += " and  fldDate='" + dtime.Year + "年" + dtime.Month + "月'";
                        }
                    }

                }
                else
                {
                    result = rule.JsonStr("error", "时间格式不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }
                string sql = "select * from vwtblEQIA_R_Value where " + where;
                DataTable dt = rule.GetMiddleData(sql);


                string sql1 = "select * from tblEQIA_R_CityWRW where " + where2;
                DataTable dt1 = rule.GetMiddleData(sql1);

                string sql3 = "select * from tblEQIA_R_CityWRW where " + where3;
                DataTable dt3 = rule.GetMiddleData(sql3);

                string sql4 = "select * from tblEQIA_R_CityWRW where " + where4;
                DataTable dt4 = rule.GetMiddleData(sql4);

                retudt tt = new retudt();
                tt.DQ = dt;
                tt.ALL = dt1;
                tt.ALLTQ = dt3;
                tt.ALLQQ = dt4;
                result = rule.JsonStr("ok", "", tt);
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

            /// <summary>
            /// 因子代码
            /// </summary>
            public string itemcode { get; set; }


            /// <summary>
            /// 点位类型
            /// </summary>
            public string type { get; set; }

        }
        public class retudt
        {
            /// <summary>
            /// 当期
            /// </summary>
            public DataTable DQ { get; set; }

            /// <summary>
            /// 全部
            /// </summary>
            public DataTable ALL { get; set; }

            /// <summary>
            /// 全部同期
            /// </summary>
            public DataTable ALLTQ { get; set; }

            /// <summary>
            /// 全部前期
            /// </summary>
            public DataTable ALLQQ { get; set; }

        }
    }
}

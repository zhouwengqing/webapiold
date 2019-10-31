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
    /// 获得城市优良天数
    /// </summary>
    public class GetCityYL_DataController : ApiController
    {
        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获得城市优良天数
        /// 创建时间：2017/10/04
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="GP">查询的参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetCityYL(GisParameter GP)
        {
            string result = "";
            string defwhere = "1=1";
            string where = "";
            string where2 = "";
            string where3 = "";
            string where4 = "";
            try
            {
                if (rule.Judge(GP.stcode))
                {
                    defwhere += " and fldSTCode='" + GP.stcode + "'";
                }
                if (rule.Judge(GP.stname))
                {
                    defwhere += " and fldSTName='" + GP.stname + "'";
                }

                if (rule.istime(GP.BeginDate))
                {
                    DateTime dtime = DateTime.Parse(GP.BeginDate);
                    where += " and fldDate='" + dtime.Year + "年" + dtime.Month + "月'";
                    where2 += " and fldDate='" + dtime.Year + "年" + dtime.Month + "月'";
                    where3 += " and fldDate='" + (dtime.Year - 1) + "年" + dtime.Month + "月'";
                    if (dtime.Month - 1 < 0)
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
                    result = rule.JsonStr("error", "时间格式不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }
                string sql = "select * from vwtblEQIA_R_YLData where " + defwhere + where;
                DataTable dt = rule.GetMiddleData(sql);
                string sql1 = "select * from tblEQIA_R_Province where  1=1 "  + where2;
                DataTable dt1 = rule.GetMiddleData(sql1);

                string sql2 = "select * from vwtblEQIA_R_YLData where " + defwhere + where3;
                DataTable dt2 = rule.GetMiddleData(sql2);
                string sql13 = "select * from tblEQIA_R_Province where " + defwhere + where4;
                DataTable dt3 = rule.GetMiddleData(sql13);

                retudt tt = new retudt();
                tt.DQ = dt;
                tt.Province = dt1;
                tt.TQ = dt2;
                tt.QQ = dt3;
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

            /// <summary>
            /// 全省
            /// </summary>
            public DataTable Province { get; set; }

            /// <summary>
            /// 同期
            /// </summary>
            public DataTable TQ { get; set; }

            /// <summary>
            /// 前期
            /// </summary>
            public DataTable QQ { get; set; }

        }
    }
}

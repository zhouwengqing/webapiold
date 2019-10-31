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
    /// <summary>
    /// 获得地表水表格呈现的数据
    /// </summary>
    public class GetIndexDataController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获得河流数据
        /// 创建  人：周文卿
        /// 创建时间：2017/09/26
        /// </summary>
        /// <param name="DP"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage GetRiverTabledata(DataParameter DP)
        {
            string result = "";
            string defwhere = "1=1";
            string defwhere2 = "1=1";
            string where1 = "";
            string where2 = "";
            string where3 = "";

            try
            {
                if (rule.JudgeLevel(DP.level))
                {
                    defwhere += " and fldLevel='" + DP.level + "'";
                    defwhere2 += " and fldLevel='" + DP.level + "'";
                }
                if (rule.Judge(DP.TimeType))
                {
                    defwhere += " and fldDType='" + DP.TimeType + "'";
                    defwhere2 += " and fldDType='" + DP.TimeType + "'";
                }
                else
                {
                    result = rule.JsonStr("error", "时间类型不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }
                if (rule.istime(DP.BeginDate) && rule.istime(DP.EndDate))
                {
                    if (DP.TimeType == "month")
                    {
                        DateTime dtime = DateTime.Parse(DP.BeginDate);
                        if (dtime.Month < 10)
                        {
                            string ti = dtime.Year + "年0" + dtime.Month + "月";
                            where1 += " and fldDate='" + ti + "'";
                            if (dtime.Month == 1)
                            {
                                where2 += " and fldDate='" + (dtime.Year - 1) + "年12月'";
                            }
                            else
                            {
                                where2 += " and fldDate='" + dtime.Year + "年0" + (dtime.Month - 1) + "月'";
                            }



                        }
                        else
                        {
                            string ti = dtime.Year + "年" + dtime.Month + "月";
                            where1 += " and fldDate='" + ti + "'";

                            where2 += " and fldDate='" + dtime.Year + "年" + (dtime.Month - 1) + "月'";


                        }
                    }
                    if (DP.TimeType == "sea")
                    {
                        DateTime dtime = DateTime.Parse(DP.EndDate);
                        string ti3 = dtime.Year + "年" + dtime.Month + "月";
                        string ti = "";
                        string ti2 = "";
                        if (dtime.Month == 3)
                        {
                            ti = dtime.Year + "年1季度";
                            ti2 = (dtime.Year - 1) + "年4季度";
                        }
                        if (dtime.Month == 6)
                        {
                            ti = dtime.Year + "年2季度";
                            ti2 = (dtime.Year) + "年1季度";
                        }
                        if (dtime.Month == 9)
                        {
                            ti = dtime.Year + "年3季度";
                            ti2 = (dtime.Year) + "年2季度";
                        }
                        if (dtime.Month == 12)
                        {
                            ti = dtime.Year + "年4季度";
                            ti2 = (dtime.Year) + "年3季度";
                        }
                        where1 += " and fldDate='" + ti + "'";
                        where2 += " and fldDate='" + ti2 + "'";

                    }
                    if (DP.TimeType == "year")
                    {
                        DateTime dtime = DateTime.Parse(DP.EndDate);
                        string ti3 = dtime.Year + "年";
                        string ti = "";
                        string ti2 = (dtime.Year - 1) + "年";
                        where1 += " and fldDate='" + ti3 + "'";
                        where2 += " and fldDate='" + ti2 + "'";
                    }
                }
                else
                {
                    result = rule.JsonStr("error", "时间格式不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }
                //当期
                string sql = "select * from tblEQIW_R_Province_Data where " + defwhere + where1;
                //累计
                string sql2 = "select * from tblEQIW_R_Province_Data where " + defwhere2 + where2;
                //同期
                string sql3 = "select * from tblEQIW_R_Province_Data where " + defwhere + where3;

                //城市
                string sql4 = "select * from tblEQIW_R_CityData where " + defwhere + where1 + " order by fldSTCode";

                //上期城市
                string sql5 = "select * from tblEQIW_R_CityData where " + defwhere2 + where2 + " order by fldSTCode";

                DataTable dt4 = rule.GetMiddleData(sql4);
                DataTable dt5 = rule.GetMiddleData(sql5);
                DataTable dt6 = dt4.Copy();

                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    if (dt4.Rows[i]["fldSTCode"].ToString() == dt5.Rows[i]["fldSTCode"].ToString())
                    {
                        if (rule.ismtch(dt5.Rows[i]["fldApprise"].ToString()))
                        {
                            dt6.Rows[i]["fldApprise"] = (decimal.Parse(dt4.Rows[i]["fldApprise"].ToString()) - decimal.Parse(dt5.Rows[i]["fldApprise"].ToString())) / decimal.Parse(dt5.Rows[i]["fldApprise"].ToString()) * 100;
                        }
                        else
                        {
                            dt6.Rows[i]["fldApprise"] = "0";
                        }
                    }
                }

                DataTable dt = rule.GetMiddleData(sql);
                DataTable dt2 = rule.GetMiddleData(sql2);
                DataTable dt3 = rule.GetMiddleData(sql3);

                retudt tt = new retudt();
                tt.DQ = dt;
                tt.LJ = dt2;
                tt.TQ = dt3;
                tt.city = dt4;
                tt.BHcity = dt6;
                result = rule.JsonStr("ok", "", tt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 河流数据相关的参数
        /// </summary>
        public class DataParameter
        {


            /// <summary>
            /// 评价方式
            /// </summary>
            public string StatType { get; set; }

            /// <summary>
            /// 时间类型
            /// </summary>
            public string TimeType { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndDate { get; set; }

            /// <summary>
            /// 同期时间
            /// </summary>
            public string TQBeginDate { get; set; }



            /// <summary>
            /// 控制级别
            /// </summary>
            public string level { get; set; }
        }


        public class retudt
        {
            /// <summary>
            /// 当期
            /// </summary>
            public DataTable DQ { get; set; }

            /// <summary>
            /// 前期
            /// </summary>
            public DataTable TQ { get; set; }

            /// <summary>
            /// 累计
            /// </summary>
            public DataTable LJ { get; set; }

            /// <summary>
            /// 城市cwqi
            /// </summary>
            public DataTable city { get; set; }

            /// <summary>
            /// 城市变化
            /// </summary>
            public DataTable BHcity { get; set; }
        }
    }
}

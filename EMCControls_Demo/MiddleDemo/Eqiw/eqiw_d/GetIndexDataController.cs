using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_DemoMiddle.Eqiw.eqiw_d
{
    /// <summary>
    /// 饮用水数据
    /// </summary>
    public class GetEQIW_D_IndexDataController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：获得饮用水数据
        /// 创建  人：周文卿
        /// 创建时间：2017/10/02
        /// </summary>
        /// <param name="DP"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage Geteqiw_d_Indexdata(DataParameter DP)
        {
            string result = "";
            string defwhere = "1=1";
            string defwhere2 = "1=1";
            string where1 = "";
            string level = "";
            string where2 = "";
            string where3 = "";
            try
            {
                if (rule.JudgeLevel(DP.level))
                {
                    if (DP.level == "1")
                        DP.level = "市级";
                    if (DP.level == "2")
                        DP.level = "县级";
                    defwhere += " and fldSLevel='" + DP.level + "'";
                    defwhere2 += " and fldSLevel='" + DP.level + "'";
                }

                if (rule.Judge(DP.stcode))
                {
                    defwhere += " and fldSTCode like '%" + DP.stcode.Substring(0, 4) + "%'";
                    defwhere2 += " and fldSTCode like '%" + DP.stcode.Substring(0, 4) + "%'";
                }
                if (rule.Judge(DP.stname))
                {
                    defwhere += " and fldSTName='" + DP.stname + "'";
                    defwhere2 += " and fldSTName='" + DP.stname + "'";
                }

                if (rule.Judge(DP.rscode))
                {
                    defwhere += " and fldRSCode='" + DP.rscode + "'";
                    defwhere2 += " and fldRSCode='" + DP.rscode + "'";
                }

                if (rule.Judge(DP.TimeType))
                {
                    defwhere += " and fldDType='" + DP.TimeType + "'";
                    defwhere2 += " and fldDType='累计'";
                }
                else
                {
                    result = rule.JsonStr("error", "时间类型不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }
                #region
                if (rule.istime(DP.BeginDate) && rule.istime(DP.EndDate))
                {
                    if (DP.TimeType == "month")
                    {
                        DateTime dtime = DateTime.Parse(DP.BeginDate);
                        if (dtime.Month < 10)
                        {
                            string ti = dtime.Year + "年0" + dtime.Month + "月";
                            where1 += " and fldDate='" + ti + "'";
                            where2 += rule.strtime(ti, "累计");
                            where3 += " and fldDate='" + (dtime.Year - 1) + "年0" + dtime.Month + "月" + "'";
                        }
                        else
                        {
                            string ti = dtime.Year + "年" + dtime.Month + "月";
                            where1 += " and fldDate='" + ti + "'";
                            where2 += rule.strtime(ti, "累计");
                            where3 += " and fldDate='" + (dtime.Year - 1) + "年" + dtime.Month + "月" + "'";
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
                            ti2 = (dtime.Year - 1) + "年1季度";
                        }
                        if (dtime.Month == 6)
                        {
                            ti = dtime.Year + "年2季度";
                            ti2 = (dtime.Year - 1) + "年2季度";
                        }
                        if (dtime.Month == 9)
                        {
                            ti = dtime.Year + "年3季度";
                            ti2 = (dtime.Year - 1) + "年3季度";
                        }
                        if (dtime.Month == 12)
                        {
                            ti = dtime.Year + "年4季度";
                            ti2 = (dtime.Year - 1) + "年4季度";
                        }
                        where1 += " and fldDate='" + ti + "'";
                        where2 += rule.strtime(ti3, "累计");
                        where3 += " and fldDate='" + ti2 + "'";
                    }
                    if (DP.TimeType == "year")
                    {
                        DateTime dtime = DateTime.Parse(DP.EndDate);
                        string ti3 = dtime.Year + "年";
                        string ti = "";
                        string ti2 = (dtime.Year - 1) + "年";
                        where1 += " and fldDate='" + ti3 + "'";
                        where2 += rule.strtime(ti3, "累计");
                        where3 += " and fldDate='" + ti2 + "'";
                    }
                }
                else
                {
                    result = rule.JsonStr("error", "时间格式不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }
                #endregion
                //达标率
                string sql = "select * from talEQIW_D_CityData where " + defwhere + where1;
                //水质
                string sql2 = "select * from tblEQIW_D_CityStage where " + defwhere + where1;
                string sql3 = "";
                string sql4 = "";
                if (DP.stcode == "-1")
                {
                    sql3 = "select * from talEQIW_D_CityData where " + defwhere + where1;//当前
                    sql4 = "select * from talEQIW_D_CityData where " + defwhere2 + where2;//累计
                }
                else
                {
                    sql3 = "select * from tblEQIW_D_SectionData_New where " + defwhere + where1;//当前
                    sql4 = "select * from tblEQIW_D_SectionData_New where " + defwhere2 + where2;//累计
                }



                DataTable dt = rule.GetMiddleData(sql);
                DataTable dt2 = rule.GetMiddleData(sql2);
                DataTable dt3 = rule.GetMiddleData(sql3);
                DataTable dt4 = rule.GetMiddleData(sql4);

                retudt tt = new retudt();
                tt.Scale = dt;
                tt.Stage = dt2;
                tt.city = dt3;
                tt.cityLJ = dt4;
                result = rule.JsonStr("ok", "", tt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        public class retudt
        {
            /// <summary>
            /// 当期
            /// </summary>
            public DataTable Scale { get; set; }

            /// <summary>
            /// 前期
            /// </summary>
            public DataTable Stage { get; set; }

            /// <summary>
            /// 累计
            /// </summary>
            public DataTable city { get; set; }

            /// <summary>
            /// 累计
            /// </summary>
            public DataTable cityLJ { get; set; }
        }
    }
}

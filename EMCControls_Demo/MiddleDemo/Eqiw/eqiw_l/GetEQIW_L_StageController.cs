﻿using DDYZ.Ensis.Rule.DataRule;
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
    /// 湖库水质类别
    /// </summary>
    public class GetEQIW_L_StageController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：获得湖库数据
        /// 创建  人：周文卿
        /// 创建时间：2017/09/26
        /// </summary>
        /// <param name="DP"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage GetEQIW_L_stage(DataParameter DP)
        {
            string result = "";
            string defwhere = "1=1";
            string defwhere2 = "1=1";
            string where1 = "";
            string where2 = "";
            string where3 = "";
            try
            {

                if (rule.Judge(DP.lname))
                {
                    defwhere += " and fldLName='" + DP.lname + "'";
                    defwhere2 += " and fldLName='" + DP.lname + "'";
                }
                if (rule.Judge(DP.lcode))
                {
                    defwhere += " and fldLCode='" + DP.lcode + "'";
                    defwhere2 += " and fldLCode='" + DP.lcode + "'";
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
                            where1 += " and fldDate<='" + ti + "' and fldDate>='" + dtime.Year + "年01月'";
                            where2 += rule.strtime(ti, "累计");
                            where3 += " and fldDate<='" + (dtime.Year - 1) + "年0" + dtime.Month + "月" + "' and fldDate>='" + (dtime.Year - 1) + "年01月'";
                        }
                        else
                        {
                            string ti = dtime.Year + "年" + dtime.Month + "月";
                            where1 += " and fldDate<='" + ti + "' and fldDate>='" + dtime.Year + "年01'";
                            where2 += rule.strtime(ti, "累计");
                            where3 += " and fldDate<='" + (dtime.Year - 1) + "年" + dtime.Month + "月" + "' and fldDate>='" + (dtime.Year - 1) + "年01月'";
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
                        where1 += " and fldDate<='" + ti + "' and fldDate>='" + dtime.Year + "年1季度'";
                        where2 += rule.strtime(ti3, "累计");
                        where3 += " and fldDate<='" + ti2 + "' and fldDate>='" + (dtime.Year - 1) + "年1季度'";
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
                string sql = "";
                string sql2 = "";
                string sql3 = "";

                sql = "select * from vwtblEQIW_L_Stage where " + defwhere + where1;
                sql2 = "select * from vwtblEQIW_L_Stage where " + defwhere2 + where2;
                sql3 = "select * from vwtblEQIW_L_Stage where " + defwhere + where3;


                DataTable dt = rule.GetMiddleData(sql);
                DataTable dt2 = rule.GetMiddleData(sql2);
                DataTable dt3 = rule.GetMiddleData(sql3);

                retudt tt = new retudt();
                tt.DQ = dt;
                tt.LJ = dt2;
                tt.TQ = dt3;
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
            /// 湖库代码
            /// </summary>
            public string lcode { get; set; }


            /// <summary>
            /// 湖库名称
            /// </summary>
            public string lname { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string TimeType { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 结束时间时间
            /// </summary>
            public string EndDate { get; set; }


            /// <summary>
            /// 结束时间时间
            /// </summary>
            public string stattype { get; set; }





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
        }
    }
}

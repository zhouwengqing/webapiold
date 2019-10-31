using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_r
{
    public class GetEQIW_R_ExecuteProcedureController : ApiController
    {


        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-19
        /// </summary>
        /// <param name="obj">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_eqiW_R_KH_StageSub(usp_eqiW_R_KH_StageSub_Parameter obj)
        {
            string result = null;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@BeginDate",obj.BeginDate),
                    new SqlParameter("@EndDate",obj.EndDate),
                    new SqlParameter("@ItemCode",obj.ItemCode),
                    new SqlParameter("@RSCode",obj.RSCode),
                    new SqlParameter("@PointAttr",obj.PointAttr)
                };

                ds = rule.RunProcedure_DS("usp_eqiW_R_KH_StageSub", paras.ToList(), "result", "EntityContext");

                result = rule.JsonStr("ok", "", ds);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// usp_eqiW_R_KH_StageSub - 参数实体
        /// </summary>
        public class usp_eqiW_R_KH_StageSub_Parameter
        {
            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndDate { get; set; }

            /// <summary>
            /// 项目代码
            /// </summary>
            public string ItemCode { get; set; }


            /// <summary>
            /// 断面代码
            /// </summary>
            public string RSCode { get; set; }


            /// <summary>
            /// 点位属性
            /// </summary>
            public string PointAttr { get; set; }


        }




        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-19
        /// </summary>
        /// <param name="obj">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_eqiW_R_KH_StandardResult(usp_eqiW_R_KH_StandardResult_Parameter obj)
        {
            string result = null;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@BeginDate",obj.BeginDate),
                    new SqlParameter("@EndDate",obj.EndDate),
                    new SqlParameter("@ItemCode",obj.ItemCode),
                    new SqlParameter("@RSCode",obj.RSCode),
                    new SqlParameter("@PointAttr",obj.PointAttr)
                };

                ds = rule.RunProcedure_DS("usp_eqiW_R_KH_StandardResult", paras.ToList(), "result", "EntityContext");

                result = rule.JsonStr("ok", "", ds);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// usp_eqiW_R_KH_StandardResult - 参数实体
        /// </summary>
        public class usp_eqiW_R_KH_StandardResult_Parameter
        {

            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndDate { get; set; }

            /// <summary>
            /// 项目代码
            /// </summary>
            public string ItemCode { get; set; }


            /// <summary>
            /// 断面代码
            /// </summary>
            public string RSCode { get; set; }


            /// <summary>
            /// 点位属性
            /// </summary>
            public string PointAttr { get; set; }

        }






















        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-19
        /// </summary>
        /// <param name="obj">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_WHPointQuery(WHPointQuery_Parameter obj)
        {
            string result = null;
            DataSet ds = new DataSet();
            try
            {
                //SqlParameter[] paras = new SqlParameter[]
                //{
                //    new SqlParameter("@BeginDate",obj.BeginDate),
                //    new SqlParameter("@EndDate",obj.EndDate),
                //    new SqlParameter("@ItemCode",obj.ItemCode),
                //    new SqlParameter("@RSCode",obj.RSCode),
                //    new SqlParameter("@PointAttr",obj.PointAttr)
                //};

                List<DataTable> dt_list = new List<DataTable>();

                DataTable dt = new DataTable();


                string[] list = obj.QueryList.Split(',');

                foreach (var item in list)
                {
                    if (item == "自动点位")
                    {
                        dt = rule.getdt("SELECT * FROM[dbEMCMIS_WUHAN].[dbo].[tblEQIW_R_Section] where fldyear = year(getdate()) and fldremark = '自动' order by fldstcode, fldrcode, fldRSCode");
                        dt_list.Add(dt);
                    }


                    if (item == "河流例行点位")
                    {
                        dt = rule.getdt("SELECT * FROM[dbEMCMIS_WUHAN].[dbo].[tblEQIW_R_Section] where fldyear = year(getdate()) and fldremark <> '自动' order by fldstcode, fldrcode, fldRSCode");
                        dt_list.Add(dt);
                    }


                    if (item == "排污口点位")
                    {
                        dt = rule.getdt("SELECT * FROM[dbEMCMIS_WUHAN].[dbo].[tblEQIW_N_Section] where fldYear = YEAR(GETDATE()) order by fldSTCode, fldLCode, fldLSCode");
                        dt_list.Add(dt);
                    }
                    if (item == "河长制")
                    {
                        dt = rule.getdt("SELECT * FROM[dbEMCMIS_WUHAN].[dbo].[tblEQIW_R_Section] where fldyear = year(getdate()) and fldremark like '河长制%' order by fldstcode, fldrcode, fldRSCode");
                        dt_list.Add(dt);
                    }
                }




                //ds = rule.RunProcedure_DS("WHPointQuery", paras.ToList(), "result", "EntityContext");

                result = rule.JsonStr("ok", "", dt_list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// WHPointQuery - 参数实体
        /// </summary>
        public class WHPointQuery_Parameter
        {

            /// <summary>
            /// 查询列表：
            /// “自动点位”
            /// “河流例行点位”
            /// “排污口点位”
            /// </summary>
            public string QueryList { get; set; }

        }




























        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-21
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_getEQIW_R_Value_ByAllForGis()
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {

                dt = rule.ExecProcessPrd("usp_getEQIW_R_Value_ByAllForGis", null, null);



                dt.Columns.Add("fldStaLod", typeof(string));
                dt.Columns.Add("fldStaLad", typeof(string));

                DataTable dt2 = rule.getdt("select * from tblEQIW_R_Section");

                dt2.Columns.Add("fldStaLod", typeof(string));
                dt2.Columns.Add("fldStaLad", typeof(string));

                foreach (DataRow item in dt2.Rows)
                {
                    item["fldStaLod"] = (double.Parse(item["fldLOD"].ToString()) + double.Parse(item["fldLOM"].ToString()) / 60 + double.Parse(item["fldLOS"].ToString()) / 3600).ToString();
                    item["fldStaLad"] = (double.Parse(item["fldLAD"].ToString()) + double.Parse(item["fldLAM"].ToString()) / 60 + double.Parse(item["fldLAS"].ToString()) / 3600).ToString();
                }

                foreach (DataRow item in dt.Rows)
                {
                    foreach (DataRow item2 in dt2.Rows)
                    {
                        if
                        (
                            item["fldSTCode"].ToString() == item2["fldSTCode"].ToString() &&
                            item["fldRCode"].ToString() == item2["fldRCode"].ToString() &&
                            item["fldRSCode"].ToString() == item2["fldRSCode"].ToString() &&
                            item["fldYear"].ToString() == item2["fldYear"].ToString()
                        )
                        {
                            item["fldStaLod"] = item2["fldStaLod"];
                            item["fldStaLad"] = item2["fldStaLad"];
                        }
                    }
                }






                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

















        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-22
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_R_Report_TenStat(usp_tblEQIW_R_Report_TenStat_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldSource",info.fldSource),
                    new SqlParameter("@fldJudge",info.fldJudge),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldRStandardName",info.fldRStandardName),
                    new SqlParameter("@fldRLevel",info.fldRLevel),
                    new SqlParameter("@fldLStandardName",info.fldLStandardName),
                    new SqlParameter("@fldLLevel",info.fldLLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@fldFromHour",info.fldFromHour),
                    new SqlParameter("@STatName",info.STatName),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@YjLineValue",info.YjLineValue)
                };

                dt = rule.ExecProcessPrd("usp_tblEQIW_R_Report_TenStat", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// usp_tblEQIW_R_Report_TenStat - 参数实体
        /// </summary>
        public class usp_tblEQIW_R_Report_TenStat_Info
        {
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
            /// 水期代码
            /// </summary>
            public string fldRSC { get; set; }


            /// <summary>
            /// 手动 0，自动 1，全部 2
            /// </summary>
            public int fldSource { get; set; }


            /// <summary>
            /// 数据冲突(0 先手 1 先自,2全部)
            /// </summary>
            public int fldJudge { get; set; }


            /// <summary>
            /// 测点代码
            /// </summary>
            public string fldRSCode { get; set; }


            /// <summary>
            /// 河流标准级别名称
            /// </summary>
            public string fldRStandardName { get; set; }



            /// <summary>
            /// 河流级别
            /// </summary>
            public int fldRLevel { get; set; }


            /// <summary>
            /// 湖库标准级别名称
            /// </summary>
            public string fldLStandardName { get; set; }


            /// <summary>
            /// 湖库级别
            /// </summary>
            public int fldLLevel { get; set; }


            /// <summary>
            /// 项目id
            /// </summary>
            public string fldItemCode { get; set; }


            /// <summary>
            /// 平均值取值方法
            /// </summary>
            public string DecCarry { get; set; }


            /// <summary>
            /// 开始小时
            /// </summary>
            public int fldFromHour { get; set; }


            /// <summary>
            /// 区域分组名称
            /// </summary>
            public string STatName { get; set; }


            /// <summary>
            /// 1河流1；0湖库
            /// </summary>
            public int STatType { get; set; }



            /// <summary>
            /// 常量0.9
            /// </summary>
            public double YjLineValue { get; set; }










        }





        ///// <summary>
        ///// 功能描述：由存储过程来获取数据（全省县界断面水质评价）
        ///// 创建者  ：熊瑞竹
        ///// 创建时间：2018-07-05
        ///// </summary>
        ///// <param name="info">参数列表</param>
        ///// <returns></returns>
        //[HttpPost]
        //public HttpResponseMessage Execute_usp_tblEQIW_R_Report_TransBoundary(usp_tblEQIW_R_Report_TransBoundary_info info)
        //{
        //    string result = null;
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        SqlParameter[] paras = new SqlParameter[]
        //        {
        //            new SqlParameter("@TimeType",info.TimeType),
        //            new SqlParameter("@BeginDate",info.BeginDate),
        //            new SqlParameter("@EndDate",info.EndDate),
        //            new SqlParameter("@fldRSC",info.fldRSC),
        //            new SqlParameter("@fldSource",info.fldSource),
        //            new SqlParameter("@fldJudge",info.fldJudge),
        //            new SqlParameter("@fldRSCode",info.fldRSCode),
        //            new SqlParameter("@fldRStandardName",info.fldRStandardName),
        //            new SqlParameter("@fldRLevel",info.fldRLevel),
        //            new SqlParameter("@fldLStandardName",info.fldLStandardName),
        //            new SqlParameter("@fldLLevel",info.fldLLevel),
        //            new SqlParameter("@fldItemCode",info.fldItemCode),
        //            new SqlParameter("@DecCarry",info.DecCarry),
        //            new SqlParameter("@fldFromHour",info.fldFromHour),
        //            new SqlParameter("@STatName",info.STatName),
        //            new SqlParameter("@STatType",info.STatType)
        //        };

        //        dt = rule.ExecProcessPrd("usp_tblEQIW_R_Report_TransBoundary", paras.ToList(), null);

        //        result = rule.JsonStr("ok", "", dt);
        //    }
        //    catch (Exception e)
        //    {
        //        result = rule.JsonStr("error", e.Message, "");
        //    }

        //    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        //}

        ///// <summary>
        ///// usp_tblEQIW_R_Report_TransBoundary - 参数实体 
        ///// </summary>
        //public class usp_tblEQIW_R_Report_TransBoundary_info
        //{
        //    /// <summary>
        //    /// 时间类型
        //    /// </summary>
        //    public string TimeType { get; set; }

        //    /// <summary>
        //    /// 开始时间
        //    /// </summary>
        //    public string BeginDate { get; set; }

        //    /// <summary>
        //    /// 结束时间
        //    /// </summary>
        //    public string EndDate { get; set; }

        //    /// <summary>
        //    /// 水期代码
        //    /// </summary>
        //    public string fldRSC { get; set; }

        //    /// <summary>
        //    /// 手动 0，自动 1，全部 2
        //    /// </summary>
        //    public int fldSource { get; set; }

        //    /// <summary>
        //    /// 数据冲突(0 先手 1 先自,2全部)
        //    /// </summary>
        //    public int fldJudge { get; set; }

        //    /// <summary>
        //    /// 测点代码
        //    /// </summary>
        //    public string fldRSCode { get; set; }

        //    /// <summary>
        //    /// 河流标准级别名称
        //    /// </summary>
        //    public string fldRStandardName { get; set; }

        //    /// <summary>
        //    /// 河流级别
        //    /// </summary>
        //    public int fldRLevel { get; set; }

        //    /// <summary>
        //    /// 湖库标准级别名称
        //    /// </summary>
        //    public string fldLStandardName { get; set; }

        //    /// <summary>
        //    /// 湖库级别
        //    /// </summary>
        //    public int fldLLevel { get; set; }

        //    /// <summary>
        //    /// 项目id
        //    /// </summary>
        //    public string fldItemCode { get; set; }

        //    /// <summary>
        //    /// 平均值取值方法
        //    /// </summary>
        //    public string DecCarry { get; set; }

        //    /// <summary>
        //    /// 开始小时
        //    /// </summary>
        //    public int fldFromHour { get; set; }

        //    /// <summary>
        //    /// 区域分组名称
        //    /// </summary>
        //    public string STatName { get; set; }

        //    /// <summary>
        //    /// 1河流1；0湖库
        //    /// </summary>
        //    public int STatType { get; set; }

        //}













        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-22
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_R_Report_SectionStage_CWQI(usp_tblEQIW_R_Report_SectionStage_CWQI_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldSource",info.fldSource),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldRStandardName",info.fldRStandardName),
                    new SqlParameter("@fldRLevel",info.fldRLevel),
                    new SqlParameter("@fldLStandardName",info.fldLStandardName),
                    new SqlParameter("@fldLLevel",info.fldLLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@CalculateID",info.CalculateID),
                    new SqlParameter("@CalculateID1",info.CalculateID1)
                };

                dt = rule.RunProcedure_V2("usp_tblEQIW_R_Report_SectionStage_CWQI", paras.ToList(), null, "EntityContext");

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// usp_tblEQIW_R_Report_SectionStage_CWQI - 参数实体
        /// </summary>
        public class usp_tblEQIW_R_Report_SectionStage_CWQI_Info
        {
            public string TimeType { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string fldRSC { get; set; }

            public int fldSource { get; set; }

            public string fldRSCode { get; set; }

            public string fldRStandardName { get; set; }

            public int fldRLevel { get; set; }

            public string fldLStandardName { get; set; }

            public int fldLLevel { get; set; }

            public string fldItemCode { get; set; }

            public string DecCarry { get; set; }

            public int STatType { get; set; }

            public int CalculateID { get; set; }

            public int CalculateID1 { get; set; }

        }















        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-22
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_R_Report_KHApprise(usp_tblEQIW_R_Report_KHApprise_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldSource",info.fldSource),
                    new SqlParameter("@fldJudge",info.fldJudge),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldRStandardName",info.fldRStandardName),
                    new SqlParameter("@fldRLevel",info.fldRLevel),
                    new SqlParameter("@fldLStandardName",info.fldLStandardName),
                    new SqlParameter("@fldLLevel",info.fldLLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@fldFromHour",info.fldFromHour),
                    new SqlParameter("@STatName",info.STatName),
                    new SqlParameter("@STatType",info.STatType)
                };

                dt = rule.ExecProcessPrd("usp_tblEQIW_R_Report_KHApprise", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// usp_tblEQIW_R_Report_KHApprise - 参数实体
        /// </summary>
        public class usp_tblEQIW_R_Report_KHApprise_Info
        {

            public string TimeType { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string fldRSC { get; set; }

            public int fldSource { get; set; }

            public int fldJudge { get; set; }

            public string fldRSCode { get; set; }

            public string fldRStandardName { get; set; }

            public int fldRLevel { get; set; }

            public string fldLStandardName { get; set; }

            public int fldLLevel { get; set; }

            public string fldItemCode { get; set; }

            public string DecCarry { get; set; }

            public int fldFromHour { get; set; }

            public string STatName { get; set; }

            public int STatType { get; set; }


        }



















        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-26
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_R_Report_SectionStage_CWQI_CQ(usp_tblEQIW_R_Report_SectionStage_CWQI_CQ_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                List<SqlParameter> paras = new List<SqlParameter>();
                paras.Add(new SqlParameter("@TimeType", info.TimeType));
                paras.Add(new SqlParameter("@BeginDate", info.BeginDate));
                paras.Add(new SqlParameter("@EndDate", info.EndDate));
                paras.Add(new SqlParameter("@BeginDate2", info.BeginDate2));
                paras.Add(new SqlParameter("@EndDate2", info.EndDate2));
                paras.Add(new SqlParameter("@fldRSC", info.fldRSC));
                paras.Add(new SqlParameter("@fldSource", info.fldSource));
                paras.Add(new SqlParameter("@fldRSCode", info.fldRSCode));
                paras.Add(new SqlParameter("@fldRStandardName", info.fldRStandardName));
                paras.Add(new SqlParameter("@fldRLevel", info.fldRLevel));
                paras.Add(new SqlParameter("@fldLStandardName", info.fldLStandardName));
                paras.Add(new SqlParameter("@fldLLevel", info.fldLLevel));
                paras.Add(new SqlParameter("@fldItemCode", info.fldItemCode));
                paras.Add(new SqlParameter("@DecCarry", info.DecCarry));
                paras.Add(new SqlParameter("@STatType", info.STatType));
                paras.Add(new SqlParameter("@STCodeType", info.STCodeType));

                if (info.CalculateID1 != null)
                {
                    paras.Add(new SqlParameter("@CalculateID1", info.CalculateID1));
                }

                if (info.fldSourceReset != null)
                {
                    paras.Add(new SqlParameter("@fldSourceReset", info.fldSourceReset));
                }

                if (info.Source != null)
                {
                    paras.Add(new SqlParameter("@Source", info.Source));
                }

                dt = rule.ExecProcessPrd("usp_tblEQIW_R_Report_SectionStage_CWQI_CQ", paras, null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// usp_tblEQIW_R_Report_SectionStage_CWQI_CQ - 参数实体
        /// </summary>
        public class usp_tblEQIW_R_Report_SectionStage_CWQI_CQ_Info
        {
            public string TimeType { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string BeginDate2 { get; set; }

            public string EndDate2 { get; set; }

            public string fldRSC { get; set; }

            public int fldSource { get; set; }

            public string fldRSCode { get; set; }

            public string fldRStandardName { get; set; }

            public int fldRLevel { get; set; }

            public string fldLStandardName { get; set; }

            public int fldLLevel { get; set; }

            public string fldItemCode { get; set; }

            public string DecCarry { get; set; }

            public int STatType { get; set; }

            public int STCodeType { get; set; }


            public int? CalculateID1 { get; set; }

            public int? fldSourceReset { get; set; }

            public int? Source { get; set; }
        }




















        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-26
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_GetSubmitDataInfo(usp_GetSubmitDataInfo_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@strSTCode",info.strSTCode),
                    new SqlParameter("@strYWType",info.strYWType),
                    new SqlParameter("@strJCType",info.strJCType),
                    new SqlParameter("@intLevel",info.intLevel),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldFlag",info.fldFlag),
                    new SqlParameter("@fldAttr",info.fldAttr)
                };

                dt = rule.ExecProcessPrd("usp_GetSubmitDataInfo", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// usp_GetSubmitDataInfo - 参数实体
        /// </summary>
        public class usp_GetSubmitDataInfo_Info
        {
            public string strSTCode { get; set; }

            public string strYWType { get; set; }

            public string strJCType { get; set; }

            public int intLevel { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public int fldFlag { get; set; }

            public string fldAttr { get; set; }


        }














        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-26
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_GetSubmitDataInfo_SH(usp_GetSubmitDataInfo_SH_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@strSTCode",info.strSTCode),
                    new SqlParameter("@strYWType",info.strYWType),
                    new SqlParameter("@strJCType",info.strJCType),
                    new SqlParameter("@intLevel",info.intLevel),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldFlag",info.fldFlag),
                    new SqlParameter("@fldAttr",info.fldAttr)
                };

                dt = rule.ExecProcessPrd("usp_GetSubmitDataInfo_SH", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// usp_GetSubmitDataInfo_SH - 参数实体
        /// </summary>
        public class usp_GetSubmitDataInfo_SH_Info
        {
            public string strSTCode { get; set; }

            public string strYWType { get; set; }

            public string strJCType { get; set; }

            public int intLevel { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public int fldFlag { get; set; }

            public string fldAttr { get; set; }
        }





























        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-26
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_R_Report_RiverStage_CWQI_CQRiver(usp_tblEQIW_R_Report_RiverStage_CWQI_CQRiver_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@BeginDate2",info.BeginDate2),
                    new SqlParameter("@EndDate2",info.EndDate2),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldSource",info.fldSource),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldRStandardName",info.fldRStandardName),
                    new SqlParameter("@fldRLevel",info.fldRLevel),
                    new SqlParameter("@fldLStandardName",info.fldLStandardName),
                    new SqlParameter("@fldLLevel",info.fldLLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@STCodeType",info.STCodeType)
                };

                dt = rule.ExecProcessPrd("usp_tblEQIW_R_Report_RiverStage_CWQI_CQRiver", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// usp_tblEQIW_R_Report_RiverStage_CWQI_CQRiver - 参数实体
        /// </summary>
        public class usp_tblEQIW_R_Report_RiverStage_CWQI_CQRiver_Info
        {
            public string TimeType { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string BeginDate2 { get; set; }

            public string EndDate2 { get; set; }

            public string fldRSC { get; set; }

            public int fldSource { get; set; }

            public string fldRSCode { get; set; }

            public string fldRStandardName { get; set; }

            public int fldRLevel { get; set; }

            public string fldLStandardName { get; set; }

            public int fldLLevel { get; set; }

            public string fldItemCode { get; set; }

            public string DecCarry { get; set; }

            public int STatType { get; set; }

            public int STCodeType { get; set; }
        }





















        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-4-9
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_R_Report_DataStat_Gis(usp_tblEQIW_R_Report_DataStat_Gis_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldSTCode",info.fldSTCode),
                    new SqlParameter("@fldSRName",info.fldSRName),
                    new SqlParameter("@fldRCode",info.fldRCode),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldRStandardName",info.fldRStandardName),
                    new SqlParameter("@fldRLevel",info.fldRLevel),
                    new SqlParameter("@fldLStandardName",info.fldLStandardName),
                    new SqlParameter("@fldLLevel",info.fldLLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry)
                };

                dt = rule.ExecProcessPrd("usp_tblEQIW_R_Report_DataStat_Gis", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// usp_tblEQIW_R_Report_DataStat_Gis - 参数实体
        /// </summary>
        public class usp_tblEQIW_R_Report_DataStat_Gis_Info
        {
            public string TimeType { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string fldSTCode { get; set; }

            public string fldSRName { get; set; }

            public string fldRCode { get; set; }

            public string fldRSCode { get; set; }

            public string fldRStandardName { get; set; }

            public int fldRLevel { get; set; }

            public string fldLStandardName { get; set; }

            public int fldLLevel { get; set; }

            public string fldItemCode { get; set; }

            public string DecCarry { get; set; }
        }




























        /// <summary>
        /// 功能描述：由存储过程来获取饮用水源地分布数据
        /// 创建者  ：熊瑞竹
        /// 创建时间：2018-04-27
        /// </summary>
        /// <returns>饮用水源地信息</returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_D_Section_ForGis()
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {

                dt = rule.ExecProcessPrd("usp_tblEQIW_D_Section_ForGis", null, null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }























        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-4-9
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_RL_Report_AppriseStat_HEIBEI(usp_tblEQIW_RL_Report_AppriseStat_HEIBEI_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@Source",info.Source),
                    new SqlParameter("@fldSTCodeReset",info.fldSTCodeReset),
                    new SqlParameter("@fldSourceReset",info.fldSourceReset)
                };

                dt = rule.ExecProcessPrd("usp_tblEQIW_RL_Report_AppriseStat_HEIBEI", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// usp_tblEQIW_RL_Report_AppriseStat_HEIBEI - 参数实体
        /// </summary>
        public class usp_tblEQIW_RL_Report_AppriseStat_HEIBEI_Info
        {
            public string TimeType { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string fldRSC { get; set; }

            public string fldRSCode { get; set; }

            public string fldStandardName { get; set; }

            public int fldLevel { get; set; }

            public string fldItemCode { get; set; }

            public string DecCarry { get; set; }

            public int STatType { get; set; }

            public int Source { get; set; }

            public int fldSTCodeReset { get; set; }

            public int fldSourceReset { get; set; }
        }

























        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-4-9
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_GetSubmitDataInfo_CQ(usp_GetSubmitDataInfo_CQ_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@strSTCode",info.strSTCode),
                    new SqlParameter("@strYWType",info.strYWType),
                    new SqlParameter("@strJCType",info.strJCType),
                    new SqlParameter("@intLevel",info.intLevel),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@TpyeNums",info.TpyeNums),
                    new SqlParameter("@Source",info.Source)
                };

                dt = rule.ExecProcessPrd("usp_GetSubmitDataInfo_CQ", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// usp_GetSubmitDataInfo_CQ - 参数实体
        /// </summary>
        public class usp_GetSubmitDataInfo_CQ_Info
        {
            public string strSTCode { get; set; }

            public string strYWType { get; set; }

            public string strJCType { get; set; }

            public int intLevel { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public int TpyeNums { get; set; }

            public int Source { get; set; }
        }









        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-4-9
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_R_Report_Auto_SectionStageApprise(usp_tblEQIW_R_Report_Auto_SectionStageApprise_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@fldTableName",info.fldTableName),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate)
                };

                dt = rule.RunProcedure_V2("usp_tblEQIW_R_Report_Auto_SectionStageApprise", paras.ToList(), null, "EntityContext");



                if (info.StaLodAndStaLad == "1")
                {
                    dt.Columns.Add("fldStaLod", typeof(string));
                    dt.Columns.Add("fldStaLad", typeof(string));


                    DataTable dt2 = new DataTable();


                    dt2 = rule.SqlQueryForDataTatable("EntityContext", "select * from tblEQIW_R_Section");


                    dt2.Columns.Add("fldStaLod", typeof(string));
                    dt2.Columns.Add("fldStaLad", typeof(string));


                    foreach (DataRow item in dt2.Rows)
                    {
                        item["fldStaLod"] = (double.Parse(item["fldLOD"].ToString()) + double.Parse(item["fldLOM"].ToString()) / 60 + double.Parse(item["fldLOS"].ToString()) / 3600).ToString();
                        item["fldStaLad"] = (double.Parse(item["fldLAD"].ToString()) + double.Parse(item["fldLAM"].ToString()) / 60 + double.Parse(item["fldLAS"].ToString()) / 3600).ToString();
                    }


                    foreach (DataRow item in dt.Rows)
                    {
                        foreach (DataRow item2 in dt2.Rows)
                        {
                            if
                            (
                                item["fldSTCode"].ToString() == item2["fldSTCode"].ToString() &&
                                item["fldRCode"].ToString() == item2["fldRCode"].ToString() &&
                                item["fldRSCode"].ToString() == item2["fldRSCode"].ToString() &&
                                item["fldDate"].ToString().Substring(0, 4) == item2["fldYear"].ToString()
                            )
                            {
                                item["fldStaLod"] = item2["fldStaLod"];
                                item["fldStaLad"] = item2["fldStaLad"];
                            }
                        }
                    }
                }




                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// usp_tblEQIW_R_Report_Auto_SectionStageApprise - 参数实体
        /// </summary>
        public class usp_tblEQIW_R_Report_Auto_SectionStageApprise_Info
        {
            public string fldTableName { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string StaLodAndStaLad { get; set; }
        }






















        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-4-9
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_R_Report_TenStat_ReWrite(usp_tblEQIW_R_Report_TenStat_ReWrite_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldSource",info.fldSource),
                    new SqlParameter("@fldJudge",info.fldJudge),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldRStandardName",info.fldRStandardName),
                    new SqlParameter("@fldRLevel",info.fldRLevel),
                    new SqlParameter("@fldLStandardName",info.fldLStandardName),
                    new SqlParameter("@fldLLevel",info.fldLLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@fldFromHour",info.fldFromHour),
                    new SqlParameter("@STatName",info.STatName),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@YjLineValue",info.YjLineValue)
                };

                dt = rule.RunProcedure_V2("usp_tblEQIW_R_Report_TenStat_ReWrite", paras.ToList(), null, "EntityContext");

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// usp_tblEQIW_R_Report_TenStat_ReWrite - 参数实体
        /// </summary>
        public class usp_tblEQIW_R_Report_TenStat_ReWrite_Info
        {
            public string TimeType { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string fldRSC { get; set; }

            public int fldSource { get; set; }

            public int fldJudge { get; set; }

            public string fldRSCode { get; set; }

            public string fldRStandardName { get; set; }

            public int fldRLevel { get; set; }

            public string fldLStandardName { get; set; }

            public int fldLLevel { get; set; }

            public string fldItemCode { get; set; }

            public string DecCarry { get; set; }

            public int fldFromHour { get; set; }

            public string STatName { get; set; }

            public int STatType { get; set; }

            public double YjLineValue { get; set; }



        }


























        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-4-9
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_eqiw_sts_dataStage090(usp_eqiw_sts_dataStage090_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@bdate",info.bdate),
                    new SqlParameter("@edate",info.edate),
                    new SqlParameter("@rscode",info.rscode),
                    new SqlParameter("@itemcode",info.itemcode),
                    new SqlParameter("@fldstandardname",info.fldstandardname),
                    new SqlParameter("@fldLevel",info.fldLevel)
                };

                dt = rule.RunProcedure_V2("usp_eqiw_sts_dataStage090", paras.ToList(), null, "EntityContext");

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// usp_eqiw_sts_dataStage090 - 参数实体
        /// </summary>
        public class usp_eqiw_sts_dataStage090_Info
        {
            public DateTime bdate { get; set; }

            public DateTime edate { get; set; }

            public string rscode { get; set; }

            public string itemcode { get; set; }

            public string fldstandardname { get; set; }

            public int fldLevel { get; set; }
        }








































        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-4-9
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_R_Report_TransBoundary(usp_tblEQIW_R_Report_TransBoundary_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldSource",info.fldSource),
                    new SqlParameter("@fldJudge",info.fldJudge),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldRStandardName",info.fldRStandardName),
                    new SqlParameter("@fldRLevel",info.fldRLevel),
                    new SqlParameter("@fldLStandardName",info.fldLStandardName),
                    new SqlParameter("@fldLLevel",info.fldLLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@fldFromHour",info.fldFromHour),
                    new SqlParameter("@STatName",info.STatName),
                    new SqlParameter("@STatType",info.STatType)
                };

                dt = rule.RunProcedure_V2("usp_tblEQIW_R_Report_TransBoundary", paras.ToList(), null, "EntityContext");

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// usp_tblEQIW_R_Report_TransBoundary - 参数实体
        /// </summary>
        public class usp_tblEQIW_R_Report_TransBoundary_Info
        {
            public string TimeType { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string fldRSC { get; set; }

            public int fldSource { get; set; }

            public int fldJudge { get; set; }

            public string fldRSCode { get; set; }

            public string fldRStandardName { get; set; }

            public int fldRLevel { get; set; }

            public string fldLStandardName { get; set; }

            public int fldLLevel { get; set; }

            public string fldItemCode { get; set; }

            public string DecCarry { get; set; }

            public int fldFromHour { get; set; }

            public string STatName { get; set; }

            public int STatType { get; set; }



        }























    }
}

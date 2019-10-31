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
    public class GetEQIW_R_Auto_ExecuteProcedureController : ApiController
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

                dt = rule.ExecProcessPrd("usp_tblEQIW_R_Report_SectionStage_CWQI", paras.ToList(), null);

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
        /// 创建时间：2017-12-22
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_R_Report_Auto_SectionStageApprise_byHand(usp_tblEQIW_R_Report_Auto_SectionStageApprise_byHand_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                };

                dt = rule.ExecProcessPrd("usp_tblEQIW_R_Report_Auto_SectionStageApprise_byHand", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// usp_tblEQIW_R_Report_Auto_SectionStageApprise_byHand - 参数实体
        /// </summary>
        public class usp_tblEQIW_R_Report_Auto_SectionStageApprise_byHand_Info
        {
            public string BeginDate { get; set; }

            public string EndDate { get; set; }
        }























        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-7-20
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_getSectionLatestDataStage(getSectionLatestData_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                dt = rule.ExecProcessPrd("getSectionLatestDataStage",null,null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// getSectionLatestDataStage - 参数实体
        /// </summary>
        public class getSectionLatestDataStage_Info
        {
        }



































        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-7-20
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_getSectionLatestData(getSectionLatestData_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@fldBDate",info.fldBDate),
                    new SqlParameter("@fldEDate",info.fldEDate),
                };

                dt = rule.RunProcedure_V2("getSectionLatestData", paras.ToList(), null, "EntityContext");

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// getSectionLatestData - 参数实体
        /// </summary>
        public class getSectionLatestData_Info
        {
            public string fldRSCode { get; set; }

            public string fldItemCode { get; set; }

            public DateTime fldBDate { get; set; }

            public DateTime fldEDate { get; set; }
        }















    }
}

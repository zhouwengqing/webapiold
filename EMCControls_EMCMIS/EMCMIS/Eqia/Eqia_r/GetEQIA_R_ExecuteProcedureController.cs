using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqia.Eqia_r
{
    public class GetEQIA_R_ExecuteProcedureController : ApiController
    {


        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-21
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_getEQIA_R_Value_ByAllForGis()
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {

                dt = rule.ExecProcessPrd("usp_getEQIA_R_Value_ByAllForGis", null, null);




                dt.Columns.Add("fldStaLod", typeof(string));
                dt.Columns.Add("fldStaLad", typeof(string));

                DataTable dt2 = rule.getdt("select * from tblEQIA_R_Point");

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
                            item["fldPCode"].ToString() == item2["fldPCode"].ToString() &&
                            item["fldEtime"].ToString().Substring(0, 4) == item2["fldYear"].ToString()
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
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIA_R_Report_AirQualityDay_Gis(usp_tblEQIA_R_Report_AirQualityDay_Gis_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {

                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@fldSource",info.fldSource),
                    new SqlParameter("@fldJudge",info.fldJudge),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldSTCode",info.fldSTCode),
                    new SqlParameter("@fldPCode",info.fldPCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@fldFromHour",info.fldFromHour)
                };

                dt = rule.ExecProcessPrd("usp_tblEQIA_R_Report_AirQualityDay_Gis", paras.ToList(), null);

                if (info.StaLodAndStaLad == "1")
                {
                    dt.Columns.Add("fldStaLod", typeof(string));
                    dt.Columns.Add("fldStaLad", typeof(string));

                    DataTable dt2 = rule.getdt("select * from tblEQIA_R_Point");

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
                                item["fldPCode"].ToString() == item2["fldPCode"].ToString() &&
                                item["fldLCode"].ToString() == item2["fldLCode"].ToString() &&
                                item["fldYear"].ToString() == item2["fldYear"].ToString()
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
        /// usp_tblEQIA_R_Report_AirQualityDay_Gis - 存储过程参数
        /// </summary>
        public class usp_tblEQIA_R_Report_AirQualityDay_Gis_Info
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
            public string fldItemCode { get; set; }


            /// <summary>
            /// 手动 0，自动 1，全部 2
            /// </summary>
            public string fldSource { get; set; }


            /// <summary>
            /// 数据冲突(0 先手 1 先自)
            /// </summary>
            public string fldJudge { get; set; }


            /// <summary>
            /// 标准级别名称
            /// </summary>
            public string fldStandardName { get; set; }


            /// <summary>
            /// 级别
            /// </summary>
            public string fldLevel { get; set; }


            /// <summary>
            /// 城市代码
            /// </summary>
            public string fldSTCode { get; set; }


            /// <summary>
            /// 测点代码
            /// </summary>
            public string fldPCode { get; set; }


            /// <summary>
            /// 平均值取值方法
            /// </summary>
            public string DecCarry { get; set; }


            /// <summary>
            /// 开始小时
            /// </summary>
            public string fldFromHour { get; set; }



            /// <summary>
            /// 是否增加经度纬度
            /// 1：增加经度纬度列fldStaLod和fldStaLad
            /// </summary>
            public string StaLodAndStaLad { get; set; }


        }




















        





        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-9
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIA_R_Report_MetalReport(usp_tblEQIA_R_Report_MetalReport_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {

                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldPCode",info.fldPCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry)
                };

                dt = rule.ExecProcessPrd("usp_tblEQIA_R_Report_MetalReport", paras.ToList(), null);


                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        /// usp_tblEQIA_R_Report_MetalReport - 存储过程参数
        /// </summary>
        public class usp_tblEQIA_R_Report_MetalReport_Info
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
            /// 测点代码
            /// </summary>
            public string fldPCode { get; set; }


            /// <summary>
            /// 标准级别名称
            /// </summary>
            public string fldStandardName { get; set; }


            /// <summary>
            /// 项目id
            /// </summary>
            public string fldItemCode { get; set; }


            /// <summary>
            /// 平均值取值方法
            /// </summary>
            public string DecCarry { get; set; }



        }




        
    }
}

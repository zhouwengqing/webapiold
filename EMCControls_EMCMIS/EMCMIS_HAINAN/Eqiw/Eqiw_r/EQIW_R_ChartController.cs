using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EMCControls_EMCMIS.EMCMIS_HAINAN.Model;

namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Eqiw.Eqiw_r
{
    public class EQIW_R_ChartController : ApiController
    {

        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-19
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tbl_IF_EQIW_R_StatData(Get_tbl_IF_EQIW_R_StatData_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            List<tbl_IF_EQIW_R_StatData> list = new List<tbl_IF_EQIW_R_StatData>();
            try
            {

                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tbl_IF_EQIW_R_StatData
                            where info.PointList.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                            info.fldDate.Contains(x.fldDate)
                            select x).ToList();
                }

                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Get_tbl_IF_EQIW_R_StatData_Info
        {
            /// <summary>
            /// 时间
            /// </summary>
            public List<string> fldDate { get; set; }

            public List<string> PointList { get; set; }
        }














        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-22
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Exe_usp_tblEQIW_R_Report_RiverSystemApprise(Exe_usp_tblEQIW_R_Report_RiverSystemApprise_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                string fldRSCode = null;

                DateTime date = DateTime.Parse(info.BeginDate);


                using (EntityContext db = new EntityContext())
                {
                    var query = (from x in db.tblEQIW_R_Section
                                 where x.fldControlCG == "是" &&
                                 x.fldYear == date.Year
                                 select x).ToList();
                    foreach (var item in query)
                    {
                        fldRSCode += "'" + item.fldSTCode + "." + item.fldRCode + "." + item.fldRSCode + "',";
                    }

                    fldRSCode = fldRSCode.TrimEnd(',');
                }


                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldSource",info.fldSource),
                    new SqlParameter("@fldJudge",info.fldJudge),
                    new SqlParameter("@fldRSCode",fldRSCode),
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

                dt = rule.RunProcedure_V2("usp_tblEQIW_R_Report_RiverSystemApprise", paras.ToList(), null, "EntityContext");


                DataRow[] dr = dt.Select("fldRName ='合计'");
                foreach (DataRow item in dr)
                {
                    dt.Rows.Remove(item);
                }


                dt.Columns.Remove("fldStage");





                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Exe_usp_tblEQIW_R_Report_RiverSystemApprise_Info
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
        /// 功能描述：获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-19
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQIW_R_Section(Get_tblEQIW_R_Section_Info info)
        {
            string result = null;
            try
            {
                Get_tblEQIW_R_Section_Return result_return = new Get_tblEQIW_R_Section_Return();

                List<tblEQIW_R_Section> list = new List<tblEQIW_R_Section>();


                using (EntityContext db = new EntityContext())
                {
                    if (info.Control == "国控")
                    {
                        list = (from x in db.tblEQIW_R_Section
                                where x.fldIsControl == "是" &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }
                    else if (info.Control == "常规省控")
                    {
                        list = (from x in db.tblEQIW_R_Section
                                where x.fldControlCG == "是" &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }
                    else if (info.Control == "交界断面")
                    {
                        list = (from x in db.tblEQIW_R_Section
                                where x.fldRSBoundary == "是" &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }


                    //断面数量
                    result_return.SectionCount = list.Count();



                    //断面代码
                    var query3 = (from x in list
                                  select x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode).ToList();

                    result_return.data_Return_Point_list = query3;





                    //显示格式
                    var query2 = (from x in db.tbl_IF_EQIW_R_StatData
                                  where query3.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                  info.fldDate.Contains(x.fldDate)
                                  orderby x.fldSTCode, x.fldRCode, x.fldRSCode
                                  select new Get_tblEQIW_R_Section_Data_Return
                                  {
                                      fldSTName = x.fldSTName,
                                      fldRName = x.fldRName,
                                      fldRSName = x.fldRSName,
                                      fldDate = x.fldDate,
                                      fldStage = x.fldStage
                                  }).ToList();

                    result_return.data_Return_list = query2;

                }





                result = rule.JsonStr("ok", "", result_return);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Get_tblEQIW_R_Section_Info
        {
            /// <summary>
            /// “国控”、“常规省控”、“交界断面”
            /// </summary>
            public string Control { get; set; }

            /// <summary>
            /// 年份：2017
            /// </summary>
            public int fldYear { get; set; }

            public List<string> fldDate { get; set; }

        }


        public class Get_tblEQIW_R_Section_Return
        {
            public int SectionCount { get; set; }

            public List<Get_tblEQIW_R_Section_Data_Return> data_Return_list { get; set; }

            public List<string> data_Return_Point_list { get; set; }
        }


        public class Get_tblEQIW_R_Section_Data_Return
        {
            public string fldSTName { get; set; }

            public string fldRName { get; set; }

            public string fldRSName { get; set; }

            public string fldDate { get; set; }

            public string fldStage { get; set; }
        }













































        /// <summary>
        /// 功能描述：海南(CWQI)
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-4-2
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_R_Report_SectionStage_CWQI_HB2(usp_tblEQIW_R_Report_SectionStage_CWQI_HB2_Info info)
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
                    new SqlParameter("@fldLSCode",info.fldLSCode),
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

                dt = rule.RunProcedure_V2("usp_tblEQIW_R_Report_SectionStage_CWQI_HB2", paras.ToList(), null, "EntityContext");


                dt.Columns.Add("fldSTName", typeof(string));

                int Year = DateTime.Parse(info.BeginDate).Year;


                List<tblEQIW_R_Section> list = new List<tblEQIW_R_Section>();

                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tblEQIW_R_Section
                            where x.fldYear == Year
                            select x).ToList();
                }

                foreach (DataRow item in dt.Rows)
                {
                    var query2 = (from x in list
                                  where x.fldSTCode == item["fldSTCode"].ToString()
                                  select x.fldSTName).FirstOrDefault();

                    if (query2 != null)
                    {
                        item["fldSTName"] = query2;
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
        /// usp_tblEQIW_R_Report_SectionStage_CWQI_HB2 - 参数实体
        /// </summary>
        public class usp_tblEQIW_R_Report_SectionStage_CWQI_HB2_Info
        {
            public string TimeType { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string fldRSC { get; set; }

            public int fldSource { get; set; }

            public string fldRSCode { get; set; }

            public string fldLSCode { get; set; }

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
        /// 功能描述：获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-19
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQIW_R_Section_V2(Get_tblEQIW_R_Section_V2_Info info)
        {
            string result = null;
            try
            {

                List<tblEQIW_R_Section> list = new List<tblEQIW_R_Section>();

                List<string> list_section = new List<string>();


                using (EntityContext db = new EntityContext())
                {
                    if (info.Control == "国控断面")
                    {
                        list = (from x in db.tblEQIW_R_Section
                                where x.fldIsControl == "是" &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }
                    else if (info.Control == "省控断面")
                    {
                        list = (from x in db.tblEQIW_R_Section
                                where x.fldControlCG == "是" &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tblEQIW_R_Section
                                where x.fldYear == info.fldYear
                                select x).ToList();
                    }


                    //断面代码
                    list_section = (from x in list
                                    select x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode).ToList();



                }





                result = rule.JsonStr("ok", "", list_section);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Get_tblEQIW_R_Section_V2_Info
        {
            /// <summary>
            /// “全部断面”、“国控断面”、“省控断面”
            /// </summary>
            public string Control { get; set; }

            /// <summary>
            /// 年份：2017
            /// </summary>
            public int fldYear { get; set; }
        }
















    }
}

using DDYZ.Ensis.Rule.DataRule;
using EMCControls_EMCMIS.EMCMIS_HAINAN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Eqia.Eqia_r
{
    public class EQIA_R_ChartController : ApiController
    {

        RuleCommon rule = new RuleCommon();





        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-22
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Exe_usp_tblEQIA_R_Report_AQIStat(Exe_usp_tblEQIA_R_Report_AQIStat_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                string fldRSCode = null;

                DateTime date = DateTime.Parse(info.BeginDate);

                using (EntityContext db = new EntityContext())
                {
                    var query = (from x in db.tblEQIA_R_Point
                                 where x.fldAttribute == "1" &&
                                 x.fldYear == date.Year
                                 select x).ToList();

                    foreach (var item in query)
                    {
                        fldRSCode += "'" + item.fldSTCode + "." + item.fldPCode + "',";
                    }

                    fldRSCode = fldRSCode.TrimEnd(',');
                }


                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldSource",info.fldSource),
                    new SqlParameter("@fldJudge",info.fldJudge),
                    new SqlParameter("@fldPCode",fldRSCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@fldFromHour",info.fldFromHour),
                    new SqlParameter("@ReportFlag",info.ReportFlag),
                    new SqlParameter("@intSTLevel",info.intSTLevel)
                };

                dt = rule.RunProcedure_V2("usp_tblEQIA_R_Report_AQIStat", paras.ToList(), null, "EntityContext");



                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Exe_usp_tblEQIA_R_Report_AQIStat_Info
        {
            public string TimeType { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public int fldSource { get; set; }

            public int fldJudge { get; set; }

            public string fldPCode { get; set; }

            public string fldStandardName { get; set; }

            public int fldLevel { get; set; }

            public string fldItemCode { get; set; }

            public string DecCarry { get; set; }

            public int fldFromHour { get; set; }

            public int ReportFlag { get; set; }

            public int intSTLevel { get; set; }
        }
































        /// <summary>
        /// 功能描述：获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-19
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQIA_R_Point(Get_tblEQIA_R_Point_Info info)
        {
            string result = null;
            try
            {
                Get_tblEQIA_R_Point_Return result_return = new Get_tblEQIA_R_Point_Return();

                List<tblEQIA_R_Point> list = new List<tblEQIA_R_Point>();


                using (EntityContext db = new EntityContext())
                {


                    if (info.Control == "测点级别")
                    {
                        list = (from x in db.tblEQIA_R_Point
                                where x.fldPLevel == info.Control_Value &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }

                    if (info.Control == "测点属性")
                    {
                        list = (from x in db.tblEQIA_R_Point
                                where x.fldAttribute == info.Control_Value.ToString() &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }

                    result_return.SectionCount = list.Count();

                    var query2 = from x in list
                                 orderby x.fldSTCode, x.fldPCode
                                 select new Get_tblEQIA_R_Point_Data_Return
                                 {
                                     fldSTName = x.fldSTName,
                                     fldPName = x.fldPName
                                 };

                    result_return.data_Return_list = query2.ToList();

                }





                result = rule.JsonStr("ok", "", result_return);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Get_tblEQIA_R_Point_Info
        {
            /// <summary>
            /// “测点级别”、“测点属性”
            /// </summary>
            public string Control { get; set; }

            /// <summary>
            /// 测点级别 = 1：国控、2：省控、3：市控、4：县控、5：其他、-1：其他
            /// 测点属性 = 1：趋势点、3：农村点、4：背景点、5：对照点、6：工业园区点、7：旅游景区点、8：负离子监测点、9：控制、-1：其他
            /// </summary>
            public int Control_Value { get; set; }

            public int fldYear { get; set; }

        }


        public class Get_tblEQIA_R_Point_Return
        {
            public int SectionCount { get; set; }

            public List<Get_tblEQIA_R_Point_Data_Return> data_Return_list { get; set; }
        }

        public class Get_tblEQIA_R_Point_Data_Return
        {
            public string fldSTName { get; set; }

            public string fldPName { get; set; }
        }















    }
}

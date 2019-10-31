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

namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Eqiw.Eqiw_l
{
    public class EQIW_L_ChartController : ApiController
    {



        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-22
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tbl_IF_EQIW_L_StatData(Get_tbl_IF_EQIW_L_StatData_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            List<tbl_IF_EQIW_L_StatData> list = new List<tbl_IF_EQIW_L_StatData>();
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tbl_IF_EQIW_L_StatData
                            where info.PointList.Contains(x.fldSTCode + "." + x.fldLCode + "." + x.fldLSCode) &&
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


        public class Get_tbl_IF_EQIW_L_StatData_Info
        {
            /// <summary>
            /// 时间
            /// </summary>
            public List<string> fldDate { get; set; }


            public List<string> PointList { get; set; }
        }











        /// <summary>
        /// 功能描述：获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-22
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
                            where info.fldDate.Contains(x.fldDate)
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
        }

















        /// <summary>
        /// 功能描述：获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-22
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQIW_L_Section(Get_tblEQIW_L_Section_Info info)
        {
            string result = null;
            try
            {
                Get_tblEQIW_L_Section_Return result_return = new Get_tblEQIW_L_Section_Return();

                List<tblEQIW_L_Section> list = new List<tblEQIW_L_Section>();


                using (EntityContext db = new EntityContext())
                {

                    if (info.Control == "国控")
                    {
                        list = (from x in db.tblEQIW_L_Section
                                where x.fldIsControl == "是" &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }
                    else if (info.Control == "常规省控")
                    {
                        list = (from x in db.tblEQIW_L_Section
                                where x.fldControlCG == "是" &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }
                    else if (info.Control == "交界断面")
                    {
                        list = (from x in db.tblEQIW_L_Section
                                where x.fldRSBoundary == "是" &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }



                    result_return.SectionCount = list.Count();




                    var query3 = (from x in list
                                  select x.fldSTCode + "." + x.fldLCode + "." + x.fldLSCode).ToList();

                    result_return.data_Return_Point_list = query3;





                    var query2 = (from x in db.tbl_IF_EQIW_L_StatData
                                  where query3.Contains(x.fldSTCode + "." + x.fldLCode + "." + x.fldLSCode) &&
                                  info.fldDate.Contains(x.fldDate)
                                  orderby x.fldSTCode, x.fldLCode, x.fldLSCode
                                  select new Get_tblEQIW_L_Section_Data_Return
                                  {
                                      fldSTName = x.fldSTName,
                                      fldLName = x.fldLName,
                                      fldLSName = x.fldLSName,
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


        public class Get_tblEQIW_L_Section_Info
        {
            /// <summary>
            /// “国控”、“省控”、“交界断面”
            /// </summary>
            public string Control { get; set; }

            public int fldYear { get; set; }

            public List<string> fldDate { get; set; }


        }


        public class Get_tblEQIW_L_Section_Return
        {
            public int SectionCount { get; set; }

            public List<Get_tblEQIW_L_Section_Data_Return> data_Return_list { get; set; }

            public List<string> data_Return_Point_list { get; set; }
        }


        public class Get_tblEQIW_L_Section_Data_Return
        {
            public string fldSTName { get; set; }

            public string fldLName { get; set; }

            public string fldLSName { get; set; }

            public string fldDate { get; set; }

            public string fldStage { get; set; }
        }

















    }
}

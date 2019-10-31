using DDYZ.Ensis.Rule.DataRule;
using EMCControls_EMCMIS.EMCMIS_HAINAN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Eqiw.Eqiw_ir
{
    public class EQIW_IR_ChartController : ApiController
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
        public HttpResponseMessage Get_tbl_IF_EQIW_IR_StatData(Get_tbl_IF_EQIW_IR_StatData_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            List<tbl_IF_EQIW_IR_StatData> list = new List<tbl_IF_EQIW_IR_StatData>();
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    if (info.fldStand == null || info.fldStand == "")
                    {
                        list = (from x in db.tbl_IF_EQIW_IR_StatData
                                where info.fldDate.Contains(x.fldDate) &&
                                info.PointList.Contains(x.fldSTCode + "." + x.fldRSCode) &&
                                info.fldType.Contains(x.fldType)
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tbl_IF_EQIW_IR_StatData
                                where info.fldDate.Contains(x.fldDate) &&
                                info.PointList.Contains(x.fldSTCode + "." + x.fldRSCode) &&
                                info.fldType.Contains(x.fldType) &&
                                info.fldStand == x.fldStand
                                select x).ToList();
                    }
                }

                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Get_tbl_IF_EQIW_IR_StatData_Info
        {
            public List<string> fldDate { get; set; }


            /// <summary>
            /// “河流”、“湖库”、“海水”
            /// 内河对应 河流，内湖对应 湖库，内河海水对应 海水
            /// </summary>
            public List<string> fldType { get; set; }

            public List<string> PointList { get; set; }

            /// <summary>
            /// “达标”
            /// </summary>
            public string fldStand { get; set; }

        }





        /// <summary>
        /// 功能描述：获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-22
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQIW_IR_Section(Get_tblEQIW_IR_Section_Info info)
        {
            string result = null;
            try
            {
                Get_tblEQIW_IR_Section_Return result_return = new Get_tblEQIW_IR_Section_Return();

                using (EntityContext db = new EntityContext())
                {
                    if (info.Control == "城镇内河")
                    {

                        var query = (from x in db.tblEQIW_IR_Section
                                     where x.fldYear == info.fldYear
                                     select x).ToList();


                        var query2 = (from x in query
                                      orderby x.fldSTCode, x.fldRSCode
                                      group x by new
                                      {
                                          x.fldSTCode,
                                          x.fldRSCode
                                      } into g
                                      select g.First()).ToList();




                        result_return.SectionCount = query2.Count();


                        var query4 = from x in query2
                                     select x.fldSTCode + "." + x.fldRSCode;

                        result_return.data_Return_Point_list = query4.ToList();






                        var query3 = (from x in db.tbl_IF_EQIW_IR_StatData
                                      where query4.Contains(x.fldSTCode + "." + x.fldRSCode) &&
                                      info.fldDate.Contains(x.fldDate)
                                      orderby x.fldSTCode, x.fldRSCode
                                      select new Get_tblEQIW_IR_Section_Data_Return
                                      {
                                          fldSTName = x.fldSTName,
                                          fldRName = x.fldRName,
                                          fldRSName = x.fldRSName,
                                          fldType = x.fldType,
                                          fldDate = x.fldDate,
                                          fldStage = x.fldStage
                                      }).ToList();


                        result_return.data_Return_list = query3;



                    }





                    if (info.Control == "城镇内河治理水体")
                    {

                        var query = (from x in db.tblEQIW_IR_Section
                                     where x.fldYear == info.fldYear &&
                                     x.fldIsZheng == "是"
                                     select x).ToList();


                        var query2 = (from x in query
                                      orderby x.fldSTCode, x.fldRSCode
                                      group x by new
                                      {
                                          x.fldSTCode,
                                          x.fldRSCode
                                      } into g
                                      select g.First()).ToList();


                        result_return.SectionCount = query2.Count();


                        var query4 = from x in query2
                                     select x.fldSTCode + "." + x.fldRSCode;

                        result_return.data_Return_Point_list = query4.ToList();


                        var query3 = (from x in db.tbl_IF_EQIW_IR_StatData
                                      where query4.Contains(x.fldSTCode + "." + x.fldRSCode) &&
                                      info.fldDate.Contains(x.fldDate)
                                      orderby x.fldSTCode, x.fldRSCode
                                      select new Get_tblEQIW_IR_Section_Data_Return
                                      {
                                          fldSTName = x.fldSTName,
                                          fldRName = x.fldRName,
                                          fldRSName = x.fldRSName,
                                          fldType = x.fldType,
                                          fldDate = x.fldDate,
                                          fldStage = x.fldStage,
                                          fldStand = x.fldStand
                                      }).ToList();

                        result_return.data_Return_list = query3;
                    }
                }





                result = rule.JsonStr("ok", "", result_return);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Get_tblEQIW_IR_Section_Info
        {
            /// <summary>
            /// “城镇内河”、“城镇内河治理水体”
            /// </summary>
            public string Control { get; set; }

            public int fldYear { get; set; }

            public List<string> fldDate { get; set; }

        }


        public class Get_tblEQIW_IR_Section_Return
        {
            public int SectionCount { get; set; }

            public List<Get_tblEQIW_IR_Section_Data_Return> data_Return_list { get; set; }

            public List<string> data_Return_Point_list { get; set; }

        }


        public class Get_tblEQIW_IR_Section_Data_Return
        {
            public string fldSTName { get; set; }

            public string fldRName { get; set; }

            public string fldRSName { get; set; }

            public string fldType { get; set; }

            public string fldDate { get; set; }

            public string fldStage { get; set; }

            public string fldStand { get; set; }
        }
    }
}

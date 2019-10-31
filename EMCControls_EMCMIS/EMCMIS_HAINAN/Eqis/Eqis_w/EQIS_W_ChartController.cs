using DDYZ.Ensis.Rule.DataRule;
using EMCControls_EMCMIS.EMCMIS_HAINAN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Eqis.Eqis_w
{
    public class EQIS_W_ChartController : ApiController
    {



        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-23
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tbl_IF_EQIS_W_StatData(Get_tbl_IF_EQIS_W_StatData_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            List<tbl_IF_EQIS_W_StatData> list = new List<tbl_IF_EQIS_W_StatData>();
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tbl_IF_EQIS_W_StatData
                            where info.PointList.Contains(x.fldSTCode + "." + x.fldPCode) &&
                            info.fldDate.Contains(x.fldDate)
                            select x).ToList();

                    foreach (var item in info.PointNameList)
                    {
                        foreach (var item2 in list)
                        {
                            if
                            (
                                item.fldSTName == item2.fldSTName &&
                                item.fldPName == item2.fldPName &&
                                item.fldDate == item2.fldDate &&
                                item.fldStage == item2.fldStage
                            )
                            {
                                item2.fldPLDC = item.fldPLDC;
                            }
                        }
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


        public class Get_tbl_IF_EQIS_W_StatData_Info
        {
            /// <summary>
            /// 时间
            /// </summary>
            public List<string> fldDate { get; set; }


            public List<string> PointList { get; set; }

            public List<Get_tblEQIS_W_Point_Data_Return> PointNameList { get; set; }

        }








        /// <summary>
        /// 功能描述：获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-22
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQIS_W_Point(Get_tblEQIS_W_Point_Info info)
        {
            string result = null;
            try
            {
                Get_tblEQIS_W_Point_Return result_return = new Get_tblEQIS_W_Point_Return();

                List<tblEQIS_W_Point> list = new List<tblEQIS_W_Point>();


                using (EntityContext db = new EntityContext())
                {

                    if (info.Control == "例行省控监测")
                    {
                        list = (from x in db.tblEQIS_W_Point
                                where x.fldDiscID == 1 &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }
                    else if (info.Control == "滨海旅游区监测")
                    {
                        list = (from x in db.tblEQIS_W_Point
                                where x.fldDiscID == 2 &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }
                    else if (info.Control == "功能区监测")
                    {
                        list = (from x in db.tblEQIS_W_Point
                                where x.fldPAttr2 == "是" &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }
                    else if (info.Control == "国控")
                    {
                        list = (from x in db.tblEQIS_W_Point
                                where x.fldPLevel == 1 &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }




                    result_return.SectionCount = list.Count();





                    var query3 = from x in list
                                 select x.fldSTCode + "." + x.fldPCode;

                    result_return.data_Return_Point_list = query3.ToList();






                    if (info.Control == "功能区监测")
                    {
                        var query2 = from x in db.tbl_IF_EQIS_W_StatData
                                     join y in db.tblEQIS_W_Point
                                     on new { x.fldSTCode, x.fldPCode } equals new { y.fldSTCode, y.fldPCode }
                                     where info.fldDate.Contains(x.fldDate) &&
                                     y.fldYear == info.fldYear &&
                                     y.fldPAttr2 == "是"
                                     orderby x.fldSTCode, x.fldPCode
                                     select new Get_tblEQIS_W_Point_Data_Return
                                     {
                                         fldSTName = x.fldSTName,
                                         fldPName = x.fldPName,
                                         fldDate = x.fldDate,
                                         fldStage = x.fldStage,
                                         fldPLDC = y.fldPLDC
                                     };

                        result_return.data_Return_list = query2.ToList();

                    }
                    else
                    {
                        var query2 = (from y in list
                                      join x in db.tbl_IF_EQIS_W_StatData
                                      on new { y.fldSTCode, y.fldPCode } equals new { x.fldSTCode, x.fldPCode }
                                      where info.fldDate.Contains(x.fldDate)
                                      orderby x.fldSTCode, x.fldPCode
                                      select new Get_tblEQIS_W_Point_Data_Return
                                      {
                                          fldSTName = x.fldSTName,
                                          fldPName = x.fldPName,
                                          fldDate = x.fldDate,
                                          fldStage = x.fldStage
                                      }).ToList();


                        foreach (var item in list)
                        {
                            var query = (from x in query2
                                         where x.fldSTName == item.fldSTName &&
                                         x.fldPName == item.fldPName
                                         select x).ToList();

                            if (query.Count == 0)
                            {
                                Get_tblEQIS_W_Point_Data_Return list2 = new Get_tblEQIS_W_Point_Data_Return();
                                list2.fldSTName = item.fldSTName;
                                list2.fldPName = item.fldPName;
                                list2.fldDate = info.fldDate[0];
                                list2.fldStage = "";

                                query2.Add(list2);
                            }


                        }

                        result_return.data_Return_list = query2.ToList();
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


        public class Get_tblEQIS_W_Point_Info
        {
            /// <summary>
            /// “例行省控监测”、“滨海旅游区监测”、“功能区监测”、“国控”
            /// </summary>
            public string Control { get; set; }

            public int fldYear { get; set; }

            public List<string> fldDate { get; set; }
        }


        public class Get_tblEQIS_W_Point_Return
        {
            public int SectionCount { get; set; }

            public List<Get_tblEQIS_W_Point_Data_Return> data_Return_list { get; set; }

            public List<string> data_Return_Point_list { get; set; }
        }


        public class Get_tblEQIS_W_Point_Data_Return
        {
            public string fldSTName { get; set; }

            public string fldPName { get; set; }

            public string fldDate { get; set; }

            public string fldStage { get; set; }

            public string fldPLDC { get; set; }
        }




    }
}

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

namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Eqia.Eqia_p
{
    public class EQIA_P_ChartController : ApiController
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
        public HttpResponseMessage Get_tbl_IF_EQIA_P_StatData(Get_tbl_IF_EQIA_P_StatData_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            List<tbl_IF_EQIA_P_StatData> list = new List<tbl_IF_EQIA_P_StatData>();
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tbl_IF_EQIA_P_StatData
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


        public class Get_tbl_IF_EQIA_P_StatData_Info
        {
            /// <summary>
            /// 时间
            /// </summary>
            public List<string> fldDate { get; set; }
        }


















        /// <summary>
        /// 功能描述：获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-23
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQIA_P_Point(Get_tblEQIA_P_Point_Info info)
        {
            string result = null;
            try
            {
                Get_tblEQIA_P_Point_Return result_return = new Get_tblEQIA_P_Point_Return();

                List<tblEQIA_P_Point> list = new List<tblEQIA_P_Point>();


                using (EntityContext db = new EntityContext())
                {


                    if (info.Control == "测点级别")
                    {
                        list = (from x in db.tblEQIA_P_Point
                                where x.fldPLevel == info.Control_Value &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }

                    result_return.SectionCount = list.Count();

                    var query2 = from x in list
                                 orderby x.fldSTCode, x.fldPCode
                                 select new Get_tblEQIA_P_Point_Data_Return
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


        public class Get_tblEQIA_P_Point_Info
        {
            /// <summary>
            /// “测点级别”
            /// </summary>
            public string Control { get; set; }

            /// <summary>
            /// 测点级别 = 1：国控、2：省控、3：市控、4：县控、5：其他、-1：其他
            /// </summary>
            public int Control_Value { get; set; }


            public int fldYear { get; set; }

        }


        public class Get_tblEQIA_P_Point_Return
        {
            public int SectionCount { get; set; }

            public List<Get_tblEQIA_P_Point_Data_Return> data_Return_list { get; set; }
        }


        public class Get_tblEQIA_P_Point_Data_Return
        {
            public string fldSTName { get; set; }

            public string fldPName { get; set; }
        }









    }
}

using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqia.Eqia_r
{
    public class Eqia_R_ReportController : ApiController
    {
        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 创建者  ：刘勇军 
        /// 创建日期：2018-05-03
        /// 功能描述：实时值查询
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetRealTimeQuery(GetRealTimeQuery_Info info)
        {
            string result = string.Empty;

            try
            {
                List<string> ItemCode = new List<string>();

                if (info.fldItemCode != "All")
                {
                    ItemCode = info.fldItemCode.Split(',').ToList();
                }

                List<Model.tblEQIA_RPI_Basedata> list = new List<Model.tblEQIA_RPI_Basedata>();

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in db.tblEQIA_RPI_Basedata
                            select x).ToList();

                    if (info.fldSTCode != "-1")
                    {
                        //根据断面代码查询
                        list = (from x in list
                                where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode)
                                select x).ToList();
                    }
                    if (info.fldItemCode != "All")
                    {
                        //根据因子代码查询
                        list = (from x in list
                                where ItemCode.Contains(x.fldItemCode)
                                select x).ToList();
                    }

                    List<Model.tblEQIA_RPI_Basedata> list_2 = new List<Model.tblEQIA_RPI_Basedata>();


                    foreach (var item in list)
                    {
                        if (DateTime.TryParse(item.fldEYear + "-" + item.fldEMonth + "-" + item.fldEDay + " " + item.fldEHour + ":" + item.fldEMinute + ":00", out DateTime ret))
                        {

                        }
                        else
                        {
                            list_2.Add(item);
                        }
                    }




                    //根据时间查询
                    list = (from x in list
                            where DateTime.Parse(x.fldSYear + "-" + x.fldSMonth + "-" + x.fldSDay + " " + x.fldSHour + ":" + x.fldSMinute + ":00") >= BeginDate &&
                            DateTime.Parse(x.fldSYear + "-" + x.fldSMonth + "-" + x.fldSDay + " " + x.fldSHour + ":" + x.fldSMinute + ":00") <= EndDate
                            select x).ToList();
                }

                if (list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 参数实体
        /// </summary>
        public class GetRealTimeQuery_Info
        {

            /// <summary>
            /// 断面代码
            /// </summary>
            public string fldSTCode { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string fldBeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string fldEndDate { get; set; }

            /// <summary>
            /// 因子代码集合
            /// </summary>
            public string fldItemCode { get; set; }
        }


        







    }
}

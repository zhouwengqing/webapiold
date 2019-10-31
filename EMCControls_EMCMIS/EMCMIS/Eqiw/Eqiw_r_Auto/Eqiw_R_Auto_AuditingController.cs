using DDYZ.Ensis.Rule.DataRule;
using EMCControls_EMCMIS.EMCMIS.Model;
using System.Data.Entity.Migrations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_r_Auto
{
    public class Eqiw_R_Auto_AuditingController : ApiController
    {

        RuleCommon rule = new RuleCommon();


        RuleEQICommon_Auditing rule_auditing = new RuleEQICommon_Auditing();






        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-16
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Query_tblEQIW_R_Auto_Remark(Query_tblEQIW_R_Auto_Remark_Info info)
        {
            string result = string.Empty;
            try
            {
                List<tblEQIW_R_Auto_Remark> list = new List<tblEQIW_R_Auto_Remark>();

                using (EntityContext db = new EntityContext())
                {
                    if (info.fldBeginDate != "" || info.fldBeginDate != "")
                    {
                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);

                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        list = (from x in db.tblEQIW_R_Auto_Remark
                            where x.fldDate >= BeginDate && x.fldDate <= EndDate
                            select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tblEQIW_R_Auto_Remark select x).ToList();
                    }

                    if (info.fldSTCode != "-1")
                    {
                        list = (from x in list
                                where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                select x).ToList();
                    }

                    if (info.fldItemCode != "")
                    {
                        list = (from x in list
                                where info.fldItemCode.Contains(x.fldItemCode)
                                select x).ToList();

                    }

                    if (info.fldAction != "")
                    {
                        list = (from x in list
                                where info.fldAction.Contains(x.fldAction)
                                select x).ToList();
                    }



                    if (info.fldAuditor != "")
                    {
                        list = (from x in list
                                where info.fldAuditor.Contains(x.fldAuditor)
                                select x).ToList();
                    }







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
        public class Query_tblEQIW_R_Auto_Remark_Info
        {
            /// <summary>
            /// 值-1查在时间范围内的全部数据
            /// </summary>
            public string fldSTCode { get; set; }

            public string fldBeginDate { get; set; }

            public string fldEndDate { get; set; }

            /// <summary>
            /// 值不为null的情况下，会筛选因子
            /// </summary>
            public string fldItemCode { get; set; }


            /// <summary>
            /// 操作类型，不为null的情况下，会按照此参数筛选
            /// </summary>
            public string fldAction { get; set; }


            /// <summary>
            /// 审核人，不为null进行筛选
            /// </summary>
            public string fldAuditor { get; set; }

        }





























        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-16
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Write_tblEQIW_R_Auto_Remark(Write_tblEQIW_R_Auto_Remark_Info info)
        {
            string result = string.Empty;
            int count = 0;
            try
            {
                List<tblEQIW_R_Auto_Remark> list = new List<tblEQIW_R_Auto_Remark>();

                tblEQIW_R_Auto_Remark remark = new tblEQIW_R_Auto_Remark();

                remark.fldSTCode = info.fldSTCode;
                remark.fldRCode = info.fldRCode;
                remark.fldRSCode = info.fldRSCode;
                remark.fldRSName = info.fldRSName;
                remark.fldDate = info.fldDate;
                remark.fldItemCode = info.fldItemCode;
                remark.fldItemName = info.fldItemName;
                remark.fldItemValue =info.fldItemValue;
                remark.fldAction = info.fldAction;
                remark.fldAuditingDate = info.fldAuditingDate;
                remark.fldAuditor = info.fldAuditor;
                remark.fldRemark = info.fldRemark;

                list.Add(remark);

                using (EntityContext db = new EntityContext())
                {
                    var query = (from x in db.tblEQIW_R_Auto_Remark
                                 where x.fldSTCode == info.fldSTCode &&
                                 x.fldRCode == info.fldRCode &&
                                 x.fldRSCode == info.fldRSCode &&
                                 x.fldItemCode == info.fldItemCode &&
                                 x.fldDate==info.fldDate
                                 select x).FirstOrDefault();

                    if (query != null)
                    {
                        remark.fldAutoID = query.fldAutoID;
                        db.tblEQIW_R_Auto_Remark.AddOrUpdate(remark);
                    }
                    else
                    {
                        db.tblEQIW_R_Auto_Remark.Add(remark);
                    }
                    count = db.SaveChanges();
                }


                if (count > 0)
                {
                    result = rule.JsonStr("ok", "", count);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有保存数据！", "");
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
        public class Write_tblEQIW_R_Auto_Remark_Info
        {
            public string fldSTCode { get; set; }

            public string fldRCode { get; set; }

            public string fldRSCode { get; set; }

            public string fldRSName { get; set; }

            /// <summary>
            /// 断面监测日期
            /// </summary>
            public DateTime? fldDate { get; set; }

            public string fldItemCode { get; set; }

            public string fldItemName { get; set; }

            public decimal fldItemValue { get; set; }

            /// <summary>
            /// 动作类型
            /// </summary>
            public string fldAction { get; set; }

            /// <summary>
            /// 审核日期
            /// </summary>
            public DateTime? fldAuditingDate { get; set; }

            /// <summary>
            /// 审核人
            /// </summary>
            public string fldAuditor { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            public string fldRemark { get; set; }
        }







        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-16
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Delete_tblEQIW_R_Auto_Remark(Delete_tblEQIW_R_Auto_Remark_Info info)
        {
            string result = string.Empty;
            int count = 0;
            try
            {
                List<tblEQIW_R_Auto_Remark> list = new List<tblEQIW_R_Auto_Remark>();

                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tblEQIW_R_Auto_Remark
                            where info.fldAutoIDList.Contains(x.fldAutoID)
                            select x).ToList();

                    db.tblEQIW_R_Auto_Remark.RemoveRange(list);
                    count = db.SaveChanges();
                }


                if (count > 0)
                {
                    result = rule.JsonStr("ok", "", count);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有可操作的数据！", "");
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
        public class Delete_tblEQIW_R_Auto_Remark_Info
        {
            /// <summary>
            /// ID
            /// </summary>
            public List<int> fldAutoIDList { get; set; }
        }


















































        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-16
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Query_tblEQIW_R_BaseData_Pre_Auto(Query_tblEQIW_R_BaseData_Pre_Auto_Info info)
        {
            string result = string.Empty;
            try
            {
                if (info.wherequery == "" || info.wherequery == null)
                {
                    info.wherequery = " fldFlag=1 and fldSource=0";
                }


                Query_tblEQIW_R_BaseData_Pre_Auto_Return returndata = new Query_tblEQIW_R_BaseData_Pre_Auto_Return();



                DataTable dt = new DataTable();

                dt = rule_auditing.GetAuditingDatabyBusinessType("eqiw_r_auto", "vwEQIW_R_Basedata_Pre_NewAll_Auto", info.wherequery, 0);

                //dt.Rows.RemoveAt(0);






                List<tblEQIW_R_Auto_Remark> list_remark = new List<tblEQIW_R_Auto_Remark>();

                using (EntityContext db = new EntityContext())
                {
                    list_remark = (from x in db.tblEQIW_R_Auto_Remark
                                   select x).ToList();
                }




                DataTable dtItem = rule.SqlQueryForDataTatable("EntityContext", "select * from tblEQIW_R_Auto_Itemstarget");










                foreach (DataRow item in dt.Rows)
                {
                    foreach (DataColumn item2 in dt.Columns)
                    {
                        string name = item2.ColumnName.TrimStart('f', 'l', 'd');

                        int num = 0;
                        if (int.TryParse(name, out num))
                        {

                            double value = 0;

                            if (double.TryParse(item[item2.ColumnName].ToString(), out value))
                            {



                                if (value == 0)
                                {
                                    item[item2.ColumnName] += "_1";
                                }
                                else
                                {
                                    var query5 = (from x in dt.AsEnumerable()
                                                  where x["fldSTCode"].ToString() == item["fldSTCode"].ToString() &&
                                                  x["fldRCode"].ToString() == item["fldRCode"].ToString() &&
                                                  x["fldRSCode"].ToString() == item["fldRSCode"].ToString() &&
                                                  x[item2.ColumnName].ToString() == item[item2.ColumnName].ToString()
                                                  select x).Count();

                                    if (query5 >= 3)
                                    {
                                        item[item2.ColumnName] += "_1";
                                    }






                                    var query3 = (from x in dtItem.AsEnumerable()
                                                  where x["fldItemCode"].ToString() == name &&
                                                  x["fldRSCode"].ToString() == item["fldRSCode"].ToString()
                                                  select x).FirstOrDefault();

                                    if (query3 != null)
                                    {
                                        if (value < double.Parse(query3["fldItemTarget"].ToString()))
                                        {
                                            item[item2.ColumnName] += "_1";
                                        }
                                    }
                                }


                                var query4 = (from x in list_remark
                                              where x.fldSTCode == item["fldSTCode"].ToString() &&
                                              x.fldRCode == item["fldRCode"].ToString() &&
                                              x.fldRSCode == item["fldRSCode"].ToString() &&
                                              x.fldDate == DateTime.Parse(item["fldDate"].ToString())
                                              select x).ToList();

                                if (query4.Count > 0)
                                {
                                    foreach (var item4 in query4)
                                    {
                                        if (dt.Columns.Contains("fld" + item4.fldItemCode))
                                        {
                                            // _0 代表 是用户手工自己填的备注信息
                                            item[item2.ColumnName] += "_0";
                                        }
                                    }
                                }


                            }


                        }
                    }
                }


                returndata.dt = dt;


                result = rule.JsonStr("ok", "", returndata);
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
        public class Query_tblEQIW_R_BaseData_Pre_Auto_Info
        {
            /// <summary>
            /// 存储过程条件参数
            /// </summary>
            public string wherequery { get; set; }
        }




        /// <summary>
        /// 参数实体
        /// </summary>
        public class Query_tblEQIW_R_BaseData_Pre_Auto_Return
        {
            public List<tblEQIW_R_Basedata_Pre_Auto> PreData { get; set; }

            public List<tblEQIW_R_Auto_Remark> RemarkData { get; set; }

            public DataTable dt { get; set; }
        }














































        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-16
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Submit_tblEQIW_R_Auto_PreToBaseData(Submit_tblEQIW_R_Auto_PreToBaseData_Info info)
        {
            string result = string.Empty;
            int count = 0;
            try
            {
                List<tblEQIW_R_Basedata_Pre_Auto> list_auto_pre = new List<tblEQIW_R_Basedata_Pre_Auto>();

                List<tblEQIW_R_Basedata_Auto> list_auto_basedata = new List<tblEQIW_R_Basedata_Auto>();

                List<tblEQIW_R_Auto_Remark> list_remark = new List<tblEQIW_R_Auto_Remark>();


                List<tblEQIW_R_Section_Auto> list_section = new List<tblEQIW_R_Section_Auto>();


                List<tblEQIW_R_Item> list_item = new List<tblEQIW_R_Item>();


                using (EntityContext db = new EntityContext())
                {

                    list_auto_pre = (from x in db.tblEQIW_R_Basedata_Pre_Auto
                                     where x.fldFlag == 1 &&
                                     x.fldSource == 0
                                     select x).ToList();

                    list_remark = (from x in db.tblEQIW_R_Auto_Remark
                                   select x).ToList();

                    list_section = (from x in db.tblEQIW_R_Section_Auto
                                    select x).ToList();

                    list_item = (from x in db.tblEQIW_R_Item
                                 select x).ToList();
                }


                //var temp = (from x in list_auto_pre
                //            join y in list_remark
                //            on x.fldAutoID equals y.fldFKID
                //            select x).ToList();

                //foreach (var item in temp)
                //{
                //    list_auto_pre.Remove(item);
                //}


                var query = (from x in list_auto_pre
                             group x by new
                             {
                                 x.fldSTCode,
                                 x.fldRCode,
                                 x.fldRSCode,
                                 x.fldYear,
                                 x.fldMonth,
                                 x.fldDay,
                                 x.fldItemCode
                             } into g
                             select new
                             {
                                 g.Key,
                                 AvgValue = g.Average(x => x.fldItemValue)
                             }
                             ).ToList();



                foreach (var item in query)
                {
                    tblEQIW_R_Basedata_Auto list_auto_basedata_new = new tblEQIW_R_Basedata_Auto();

                    list_auto_basedata_new.fldSTCode = item.Key.fldSTCode;

                    var STName = (from x in list_section
                                  where x.fldYear == item.Key.fldYear &&
                                  x.fldSTCode == item.Key.fldSTCode
                                  select x.fldSTName).FirstOrDefault();


                    list_auto_basedata_new.fldSTName = STName;



                    list_auto_basedata_new.fldRCode = item.Key.fldRCode;

                    var RName = (from x in list_section
                                 where x.fldYear == item.Key.fldYear &&
                                 x.fldRCode == item.Key.fldRCode
                                 select x.fldRName).FirstOrDefault();


                    list_auto_basedata_new.fldRName = RName;




                    list_auto_basedata_new.fldRSCode = item.Key.fldRSCode;

                    var RSName = (from x in list_section
                                  where x.fldYear == item.Key.fldYear &&
                                  x.fldRSCode == item.Key.fldRSCode
                                  select x.fldRSName).FirstOrDefault();

                    list_auto_basedata_new.fldRSName = RSName;





                    var query2 = (from x in list_auto_pre
                                  where x.fldSTCode == item.Key.fldSTCode &&
                                  x.fldRCode == item.Key.fldRCode &&
                                  x.fldRSCode == item.Key.fldRSCode &&
                                  x.fldYear == item.Key.fldYear &&
                                  x.fldMonth == item.Key.fldMonth &&
                                  x.fldDay == item.Key.fldDay &&
                                  x.fldItemCode == item.Key.fldItemCode
                                  select x).FirstOrDefault();



                    list_auto_basedata_new.fldSAMPH = query2.fldSAMPH;

                    list_auto_basedata_new.fldSAMPR = query2.fldSAMPR;

                    list_auto_basedata_new.fldSAMPR = query2.fldSAMPR;

                    list_auto_basedata_new.fldRSC = query2.fldRSC;



                    list_auto_basedata_new.fldYear = item.Key.fldYear;

                    list_auto_basedata_new.fldMonth = item.Key.fldMonth;

                    list_auto_basedata_new.fldDay = item.Key.fldDay;


                    //list_auto_basedata_new.fldHour = query2.fldHour;
                    list_auto_basedata_new.fldHour = 0;


                    //list_auto_basedata_new.fldMinute = query2.fldMinute;

                    list_auto_basedata_new.fldMinute = 0;

                    list_auto_basedata_new.fldItemCode = item.Key.fldItemCode;


                    var ItemName = (from x in list_item
                                    where x.fldItemCode == item.Key.fldItemCode
                                    select x.fldItemName).FirstOrDefault();

                    list_auto_basedata_new.fldItemName = ItemName;


                    list_auto_basedata_new.fldItemValue = item.AvgValue;



                    list_auto_basedata_new.fldSource = query2.fldSource;
                    list_auto_basedata_new.fldUserID = query2.fldUserID;
                    list_auto_basedata_new.fldFlag = query2.fldFlag;




                    list_auto_basedata.Add(list_auto_basedata_new);

                }




                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_R_Basedata_Auto.AddRange(list_auto_basedata);


                    count = db.SaveChanges();


                    //if (count > 0)
                    //{
                    //    db.tblEQIW_R_Basedata_Pre_Auto.RemoveRange(list_auto_pre);
                    //    count = db.SaveChanges();
                    //}

                }



                if (count > 0)
                {
                    result = rule.JsonStr("ok", "", count);
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
        public class Submit_tblEQIW_R_Auto_PreToBaseData_Info
        {

        }

















    }
}

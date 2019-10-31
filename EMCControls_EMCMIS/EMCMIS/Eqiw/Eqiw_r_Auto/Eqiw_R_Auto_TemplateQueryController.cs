using DDYZ.Ensis.Rule.DataRule;
using EMCControls_EMCMIS.EMCMIS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_r_Auto
{
    public class Eqiw_R_Auto_TemplateQueryController : ApiController
    {


        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-14
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Query_tblEQIW_R_Basedata_Auto(Query_tblEQIW_R_Basedata_Auto_Info info)
        {
            string result = string.Empty;
            try
            {
                List<tblEQIW_R_Basedata_Auto> list = new List<tblEQIW_R_Basedata_Auto>();


                using (EntityContext db = new EntityContext())
                {

                    list = (from x in db.tblEQIW_R_Basedata_Auto
                            where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                            info.fldItemCode.Contains(x.fldItemCode)
                            select x).ToList();

                    foreach (var item in list)
                    {
                        item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDate);
                    }


                    DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                    DateTime EndDate = DateTime.Parse(info.fldEndDate);


                    list = (from x in list
                            where x.fldDate >= BeginDate &&
                            x.fldDate <= EndDate
                            select x).ToList();
                }



                var query = (from x in list
                             group x by x.fldItemCode
                             into g
                             select new
                             {
                                 Key = g.Key,
                                 Data = g
                             }).ToList();


                if (query.Count > 0)
                {
                    result = rule.JsonStr("ok", "", query);
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
        public class Query_tblEQIW_R_Basedata_Auto_Info
        {
            public string fldSTCode { get; set; }

            public string fldBeginDate { get; set; }

            public string fldEndDate { get; set; }

            public List<string> fldItemCode { get; set; }
        }

























        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-14
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Query_WithDate(Query_WithDate_Info info)
        {
            string result = string.Empty;
            try
            {

                Query_WithDate_Return returndata = new Query_WithDate_Return();

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);

                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                List<Model.Lap.tblFW_Dictionary> list_dic = new List<Model.Lap.tblFW_Dictionary>();

                List<tblEQIW_R_Item> list_item = new List<tblEQIW_R_Item>();

                List<tblEQIW_R_Auto_Remark> list_remark = new List<tblEQIW_R_Auto_Remark>();

                using (Model.Lap.LAPContext db = new Model.Lap.LAPContext())
                {
                    list_dic = (from x in db.tblFW_Dictionary
                                where x.fldTableName == "vwEQIW_R_Basedata_Auto"
                                select x).ToList();
                }

                using (EntityContext db = new EntityContext())
                {
                    list_remark = (from x in db.tblEQIW_R_Auto_Remark
                                   select x).ToList();


                    list_item = (from x in db.tblEQIW_R_Item
                                 select x).ToList();

                }

                returndata.list_dic = list_dic;

                returndata.list_remark = list_remark;


                returndata.list_item = list_item;






                DataTable dt = new DataTable();







                if (info.type == "hour")
                {

                    List<tblEQIW_R_HourData_Auto> list = new List<tblEQIW_R_HourData_Auto>();

                    tblEQIW_R_HourData_Auto hour_auto = new tblEQIW_R_HourData_Auto();

                    Dictionary<object, object> dictionary = GetProperties(hour_auto);

                    foreach (var item in dictionary)
                    {
                        dt.Columns.Add(item.Key.ToString(), typeof(string));
                    }

                    foreach (var item in info.fldItemCode.Split(','))
                    {
                        dt.Columns.Add(item + "_Value", typeof(string));
                    }

                    dt.Columns.Add("备注", typeof(string));


                    DataTable dtTemp = rule.SqlQueryForDataTatable("EntityContext", "select * from tblEQIW_R_HourData_Auto");

                    DataTable dtItem = rule.SqlQueryForDataTatable("EntityContext", "select * from tblEQIW_R_Auto_Itemstarget");


                    using (EntityContext db = new EntityContext())
                    {
                        if (info.fldSTCode == "-1")
                        {
                            list = (from x in db.tblEQIW_R_HourData_Auto
                                    select x).ToList();
                        }
                        else
                        {
                            list = (from x in db.tblEQIW_R_HourData_Auto
                                    where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                    select x).ToList();

                        }
                    }




                    foreach (var item in list)
                    {
                        item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay + " " + item.fldHour + ":" + item.fldMinute + ":00");
                    }

                    list = (from x in list
                            where x.fldDate >= BeginDate &&
                            x.fldDate <= EndDate
                            select x).ToList();



                    var query = (from x in list
                                 group x by new
                                 {
                                     x.fldSTCode,
                                     x.fldRCode,
                                     x.fldRSCode,
                                     x.fldYear,
                                     x.fldMonth,
                                     x.fldDay,
                                     x.fldHour
                                 }
                                 into g
                                 select new
                                 {
                                     g.Key,
                                     Data = g
                                 }).ToList();



                    foreach (var item in query)
                    {
                        DataRow dr = dt.NewRow();
                        var query2 = (from x in dtTemp.AsEnumerable()
                                      where x["fldSTCode"].ToString() == item.Key.fldSTCode &&
                                      x["fldRCode"].ToString() == item.Key.fldRCode &&
                                      x["fldRSCode"].ToString() == item.Key.fldRSCode &&
                                      x["fldYear"].ToString() == item.Key.fldYear.ToString() &&
                                      x["fldMonth"].ToString() == item.Key.fldMonth.ToString() &&
                                      x["fldDay"].ToString() == item.Key.fldDay.ToString() &&
                                      x["fldHour"].ToString() == item.Key.fldHour.ToString()
                                      select x).CopyToDataTable();

                        foreach (DataColumn item3 in query2.Columns)
                        {
                            dr[item3.ColumnName] = query2.Rows[0][item3.ColumnName].ToString();
                        }


                        foreach (DataRow item3 in query2.Rows)
                        {
                            if (dr.Table.Columns.Contains(item3["fldItemCode"].ToString() + "_Value"))
                            {
                                if (item3["fldItemValue"].ToString() != "")
                                {
                                    double value = double.Parse(item3["fldItemValue"].ToString());

                                    if (value == 0)
                                    {
                                        dr[item3["fldItemCode"].ToString() + "_Value"] = item3["fldItemValue"].ToString() + "_XTJCCW";
                                    }
                                    else
                                    {
                                        var query3 = (from x in dtItem.AsEnumerable()
                                                      where x["fldItemCode"].ToString() == item3["fldItemCode"].ToString() &&
                                                      x["fldRSCode"].ToString() == item.Key.fldRCode
                                                      select x).FirstOrDefault();

                                        if (query3 != null)
                                        {
                                            if (value < double.Parse(query3["fldItemTarget"].ToString()))
                                            {
                                                dr[item3["fldItemCode"].ToString() + "_Value"] = item3["fldItemValue"].ToString() + "_XTJCCW";
                                            }
                                        }


                                    }
                                }




                            }
                        }

                        var query4 = (from x in list_remark
                                      where x.fldSTCode == item.Key.fldSTCode &&
                                      x.fldRCode == item.Key.fldRCode &&
                                      x.fldRSCode == item.Key.fldRSCode &&
                                      x.fldDate == DateTime.Parse(item.Key.fldYear + "-" + item.Key.fldMonth + "-" + item.Key.fldDay + " " + item.Key.fldHour + ":00:00")
                                      select x).ToList();

                        if (query4.Count > 0)
                        {
                            foreach (var item4 in query4)
                            {
                                if (dr.Table.Columns.Contains(item4.fldItemCode + "_Value"))
                                {
                                    // _0 代表 是用户手工自己填的备注信息
                                    dr[item4.fldItemCode + "_Value"] += "_YHQRCW";
                                    dr["备注"] += item4.fldItemName + "[" + item4.fldItemCode + "]" + "：" + item4.fldRemark + "；";
                                }
                            }
                        }








                        dt.Rows.Add(dr);
                    }















                    returndata.dt = dt;

                }



                if (info.type == "day")
                {
                    List<tblEQIW_R_Basedata_Auto> list_data = new List<tblEQIW_R_Basedata_Auto>();

                    using (EntityContext db = new EntityContext())
                    {

                        list_data = (from x in db.tblEQIW_R_Basedata_Auto
                                     where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                     select x).ToList();

                    }

                    foreach (var item in list_data)
                    {
                        item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay + " " + item.fldHour + ":" + item.fldMinute + ":00");
                    }

                    list_data = (from x in list_data
                                 where x.fldDate >= BeginDate &&
                                 x.fldDate <= EndDate
                                 select x).ToList();


                    var query = (from x in list_data
                                 group x by new
                                 {
                                     x.fldSTCode,
                                     x.fldRCode,
                                     x.fldRSCode,
                                     x.fldYear,
                                     x.fldMonth,
                                     x.fldDay,
                                     x.fldHour,
                                     x.fldMinute,
                                     x.fldSAMPH,
                                     x.fldSAMPR
                                 }
                                 into g
                                 select new
                                 {
                                     g.Key,
                                     Data = g
                                 }).ToList();



                    returndata.obj_list_data = query;

                }



                if (info.type == "week" || info.type == "month" || info.type == "year")
                {
                    List<tblEQIW_R_Basedata_Auto> list_data = new List<tblEQIW_R_Basedata_Auto>();

                    using (EntityContext db = new EntityContext())
                    {
                        list_data = (from x in db.tblEQIW_R_Basedata_Auto
                                     where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                     select x).ToList();
                    }


                    foreach (var item in list_data)
                    {
                        item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay + " " + item.fldHour + ":" + item.fldMinute + ":00");
                    }


                    list_data = (from x in list_data
                                 where x.fldDate >= BeginDate &&
                                 x.fldDate <= EndDate
                                 select x).ToList();


                    var query = from x in list_data
                                group x by new
                                {
                                    x.fldSTCode,
                                    x.fldSTName,
                                    x.fldRCode,
                                    x.fldRName,
                                    x.fldRSCode,
                                    x.fldRSName,
                                    x.fldItemCode,
                                    x.fldItemName
                                } into g
                                select new
                                {
                                    g.Key,
                                    Data = g,
                                    AvgValue = g.Average(z => z.fldItemValue)
                                };

                    returndata.obj_list_data = query;
                }




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
        public class Query_WithDate_Info
        {
            /// <summary>
            /// “小时值”
            /// </summary>
            public string type { get; set; }

            public string fldSTCode { get; set; }

            public string fldItemCode { get; set; }

            public string fldBeginDate { get; set; }

            public string fldEndDate { get; set; }

        }


        /// <summary>
        /// 功能描述：获取水质自动周，月，年均值和小时值
        /// 创建  人：周文卿
        /// 创建时间：2018/05/30
        /// 修改  人：
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage GetAutoAvge(Query_WithDate_Info info)
        {
            string result = string.Empty;
            try
            {
                RuletblEQIW_R_HourData_Auto auto = new RuletblEQIW_R_HourData_Auto();
                DataTable dt = null;
                //获得点位对应的因子
                DataTable dt1 = new DataTable();
                //string sql = "select * from tblRSNameCorItemName";
                //dt1 = rule.getdt(sql);
                string sql1 = "select *  from tblEQIW_R_Item_Auto";
                DataTable tableitem = rule.getdt(sql1);
                //获得不同的数据源
                if (info.type == "hour")
                {
                    dt = auto.GetHourData(info.fldBeginDate, info.fldEndDate, info.fldSTCode, info.fldItemCode);
                    dt.Columns.Remove("fldYear");
                    dt.Columns.Remove("fldMonth");
                    dt.Columns.Remove("fldDay");
                    dt.Columns.Remove("fldHour");
                    DataRow dr = dt.NewRow();
                    dr["fldSTName"] = "城市名称";
                    dr["fldSTCode"] = "城市代码";
                    dr["fldRName"] = "河流名称";
                    dr["fldRCode"] = "河流代码";
                    dr["fldRSName"] = "断面名称";
                    dr["fldRSCode"] = "断面代码";
                    dr["fldDate"] = "监测日期";
                    dr["fldTime"] = "监测时间";

                    for (int i = 8; i < dt.Columns.Count; i++)
                    {
                        DataRow[] dataRows = tableitem.Select("fldItemName='" + dt.Columns[i].ToString() + "'");
                        if (dataRows.Length > 0)
                        {
                            dr[dt.Columns[i].ToString()] = dataRows[0]["fldUnit"].ToString();
                        }
                    }
                    dt.Rows.InsertAt(dr, 0);
                }
                else
                {
                    //获得均值
                    dt = auto.GetAutoAvg(info.type, info.fldBeginDate, info.fldEndDate, info.fldSTCode, info.fldItemCode);
                    dt.Columns.Remove("fldYear");
                    dt.Columns.Remove("fldMonth");
                    dt.Columns.Remove("fldDay");
                    dt.Columns.Remove("fldCount");
                    DataRow dr = dt.NewRow();
                    dr["fldSTName"] = "城市名称";
                    dr["fldSTCode"] = "城市代码";
                    dr["fldRName"] = "河流名称";
                    dr["fldRCode"] = "河流代码";
                    dr["fldRSName"] = "断面名称";
                    dr["fldRSCode"] = "断面代码";
                    dr["fldDate"] = "监测日期";

                    for (int i = 7; i < dt.Columns.Count; i++)
                    {
                        DataRow[] dataRows = tableitem.Select("fldItemName='" + dt.Columns[i].ToString() + "'");
                        if (dataRows.Length > 0)
                        {
                            dr[dt.Columns[i].ToString()] = dataRows[0]["fldUnit"].ToString();
                        }
                    }
                    dt.Rows.InsertAt(dr, 0);
                }





                //替换空值和没有仪器的值                 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ////先判断断面代码
                        //if (dt.Rows[i]["fldRSName"].ToString() == dt1.Rows[j]["fldRSCName"].ToString())
                        //{
                        //    string coritem = dt1.Rows[j]["fldItemName"].ToString();
                        //    //再判断因子
                        //    for (int h = 8; h < dt.Columns.Count; h++)
                        //    {
                        //        //不包含这个因子 且数据为空时为无仪器的数据
                        //        if (!coritem.Contains(dt.Columns[h].ColumnName.ToString()) && dt.Rows[i][h].ToString() == "")
                        //        {
                        //            dt.Rows[i][h] = "无仪器";
                        //        }
                        //        //包含这个因子 但是没有数据用/表示
                        //        if (coritem.Contains(dt.Columns[h].ColumnName.ToString()) && dt.Rows[i][h].ToString() == "")
                        //        {
                        //            dt.Rows[i][h] = "/";
                        //        }
                        //    }
                        //}
                        if (dt.Rows[i][j].ToString() == "")
                        {
                            dt.Rows[i][j] = "-";
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
        /// 参数实体
        /// </summary>
        public class Query_WithDate_Return
        {
            public object obj_list_data { get; set; }

            public DataTable dt { get; set; }

            public List<tblEQIW_R_Basedata_Auto> list_data { get; set; }

            public List<Model.Lap.tblFW_Dictionary> list_dic { get; set; }

            public List<tblEQIW_R_Item> list_item { get; set; }

            public List<tblEQIW_R_Auto_Remark> list_remark { get; set; }
        }








































        /// <summary>
        /// 反射得到实体类的字段名称和值
        /// var dict = GetProperties(model);
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t">实例化</param>
        /// <returns></returns>
        public static Dictionary<object, object> GetProperties<T>(T t)
        {
            var ret = new Dictionary<object, object>();
            if (t == null) { return null; }
            PropertyInfo[] properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (properties.Length <= 0) { return null; }
            foreach (PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    ret.Add(name, value);
                }
            }
            return ret;
        }
















    }
}

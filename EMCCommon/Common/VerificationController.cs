using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace EMCCommon.Common
{
    /// <summary>
    /// 功能描述：用于检查“超标项目”、“突变值检查”
    /// 创建者  ：吕荣誉
    /// 创建日期：2017-6-21
    /// 修改者  ：
    /// 修改日期：
    /// 修改原因：
    /// </summary>
    public class VerificationController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        string strLocalpath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/TypeBaseData.json");//配置的json文件地址

        /// <summary>
        /// 功能描述：超标检查中，加载“判断项目超标依据”下拉列表
        ///           根据传入的“业务类型”的不同，返回的数据不同
        ///           同时返回级别
        /// 创建者  ：吕荣誉
        /// 创建日期：2017-6-21
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <returns>返回StandardList集合与LevelList集合转换成的Json字符串</returns>
        //[SupportFilter]
        [HttpGet]
        public HttpResponseMessage QueryStandardAndLevel(string type)
        {
            string result = string.Empty;
            try
            {
                RuletblDictionary dic = new RuletblDictionary();

                string list = dic.ByParentIDAndValue("执行标准", type);

                RuletblEQIW_R_DAQLTSTD ruleStdR = new RuletblEQIW_R_DAQLTSTD();

                DataTable tblData = ruleStdR.GetEdition(list);

                // 处理标准数据
                DataTable dt1 = tblData.Copy();

                // 处理级别数据
                DataTable dt2 = tblData.Copy();

                string col = null;

                // 这里是不移除的列
                string colName = "fldStandardNum^fldEdition";

                for (int i = 0; i < dt1.Columns.Count; i++)
                {
                    if (!(colName.Contains(dt1.Columns[i].ColumnName)))
                    {
                        dt1.Columns.Remove(dt1.Columns[i]);
                        i--;
                    }
                    else
                    {
                        col += dt1.Columns[i].ColumnName;
                    }
                }

                // 这里是移除的列
                string colName2 = "fldAutoID^fldStandardName^fldItemCode^fldStandardNum^fldEdition";

                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    if ((colName2.Contains(dt2.Columns[i].ColumnName)))
                    {
                        dt2.Columns.Remove(dt2.Columns[i]);
                        i--;
                    }
                }

                List<KeyValue> standardList = new List<KeyValue>();

                List<KeyValue> levelList = new List<KeyValue>();


                var query = (from x in dt1.AsEnumerable()
                             select x[col].ToString()).Distinct();

                foreach (var item1 in query)
                {
                    KeyValue standard = new KeyValue()
                    {
                        Key = col,
                        Value = item1
                    };
                    standardList.Add(standard);
                }

                foreach (DataColumn item in dt2.Columns)
                {

                    if (type == "eqiw_r" || type == "eqiw_r_auto" || type == "eqiw_d" || type == "eqiw_dt" || type == "eqiw_dx" || type == "eqiw_g" || type == "eqiw_sts")
                    {
                        foreach (LevelEnum_eqiw_r item2 in Enum.GetValues(typeof(LevelEnum_eqiw_r)))
                        {
                            if (item.ColumnName == item2.ToString())
                            {
                                colName += item2.ToString() + "^";

                                KeyValue level = new KeyValue()
                                {
                                    Key = item2.ToString(),
                                    Value = GetEnumDescription(item2)
                                };
                                levelList.Add(level);
                            }
                        }
                    }
                    else
                    {
                        foreach (LevelEnum item2 in Enum.GetValues(typeof(LevelEnum)))
                        {
                            if (item.ColumnName == item2.ToString())
                            {
                                colName += item2.ToString() + "^";

                                KeyValue level = new KeyValue()
                                {
                                    Key = item2.ToString(),
                                    Value = GetEnumDescription(item2)
                                };
                                levelList.Add(level);
                            }
                        }
                    }






                }

                JsonEntity JsonEntityList = new JsonEntity()
                {
                    StandardList = standardList,
                    LevelList = levelList
                };
                if (JsonEntityList != null)
                {
                    result = rule.JsonStr("ok", "", JsonEntityList);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据", JsonEntityList);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：根据传入的参数，返回标准表中各项目的值
        /// 创建者  ：吕荣誉
        /// 创建日期：2017-6-21
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <param name="checktype">检查方式：“超标检查”，“突变值检查”，“因子逻辑关系检查”</param>
        /// <param name="basis">判断超标依据</param>
        /// <param name="level">级别</param>
        /// <param name="datetime">日期范围，格式：2017-06-01～2017-07-06</param>
        /// <param name="percent">百分比</param>
        /// <param name="cityid">城市ID</param>
        /// <param name="where">查询条件</param>
        /// <param name="flag">数据状态标识，0是待提交，1是待审核</param>
        /// <returns>返回fldItemCode列与级别列的DataTable转换的Json字符串</returns>
        [HttpGet]
        //[SupportFilter]
        public HttpResponseMessage ReturnStandardValue(string type, string checktype, string basis, string level, string datetime, string percent, string cityid, string where, string flag, string Number3Auditing = "N")
        {
            string result = string.Empty;
            try
            {
                DataTable tblData = new DataTable();

                RuleEQICommon_Auditing com = new RuleEQICommon_Auditing();

                RuletblDictionary rd = new RuletblDictionary();

                string[] viewName = rd.ByParentIDAndValue("数据审核视图", type).Split(',');

                string defaultwhere = null;

                string fldSource = "0";

                if (type.Contains("hm"))
                {
                    fldSource = "1";
                }




                if (Number3Auditing == "N")
                {
                    if (flag == "0")
                    {
                        defaultwhere = "fldCityID_Operate=" + cityid + " and fldSource=" + fldSource + " and fldFlag=" + flag + " and fldImport=1" + where;
                    }
                    else
                    {
                        if (cityid == "2")
                        {
                            if (type == "eqiw_r_auto")
                            {
                                defaultwhere = " fldFlag=0 " + where;
                            }
                            else
                            {
                                defaultwhere = "fldSource=" + fldSource + " and fldFlag=" + flag + " " + where;
                            }
                        }
                        else
                        {
                            if (type == "eqiw_r_auto")
                            {
                                defaultwhere = "fldCityID_Operate=" + cityid + " and fldFlag=0 " + where;
                            }
                            else
                            {
                                defaultwhere = "fldCityID_Operate=" + cityid + " and fldSource=" + fldSource + " and fldFlag=" + flag + " " + where;
                            }
                        }
                    }

                }
                else
                {
                    defaultwhere = "fldCityID_Operate=" + cityid + " and fldSource=" + fldSource + " and fldFlag=" + flag + " and fldImport=1" + where;
                }













                // 页面条件返回的数据
                tblData = com.GetAuditingDatabyBusinessType(type, viewName[0], defaultwhere, 0);


                foreach (DataRow item in tblData.Rows)
                {
                    foreach (DataColumn item2 in tblData.Columns)
                    {
                        string name = item2.ColumnName.TrimStart('f', 'l', 'd');
                        int itemcode = 0;

                        if (int.TryParse(name, out itemcode))
                        {
                            item[item2.ColumnName] = item[item2.ColumnName].ToString().Split('_')[0];
                        }
                    }
                }








                RuleEQIV_WaitTable_Auditing rulAud = new RuleEQIV_WaitTable_Auditing();

                if (type.Contains("_v") || type.Contains("eqie"))
                {
                    tblData = rulAud.GetEqiv_AuditingData(viewName[0], defaultwhere, type);
                }

                DataTable data = tblData.Copy();


                if
                (!(
                    type.Contains("_v") ||
                    type.Contains("eqib") ||
                    type.Contains("eqie") ||
                    type.Contains("eqin") ||
                    type == "eqid_d"
                ))
                {
                    if (tblData.Rows.Count > 0)
                    {

                        tblData.Rows.RemoveAt(0);
                    }
                }

                DataTable dt = new DataTable();

                foreach (DataColumn item in tblData.Columns)
                {
                    dt.Columns.Add(item.ColumnName, typeof(string));
                }

                foreach (DataRow item in tblData.Rows)
                {
                    dt.ImportRow(item);
                }

                tblData = dt;


                Dictionary<string, string> dictionary = new Dictionary<string, string>();

                List<string> col_zh_cn = TitleName(type, viewName[1], tblData, out dictionary);

                DataTable dataTable = new DataTable();




                if (tblData == null || tblData.Rows.Count == 0)
                {

                    ReturnJson returnjson2 = new ReturnJson()
                    {
                        Data = tblData,
                        Head = col_zh_cn,
                    };

                    result = rule.JsonStr("nodata", "无数据", returnjson2);

                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }

                string getjson = rule.GetJson(strLocalpath);

                JArray jsonObj = JArray.Parse(getjson);

                var tablename = (from x in jsonObj
                                 where x["type"].ToString() == type
                                 select x["tablename"].ToString()).FirstOrDefault();



                List<KeyValue> kvlist2 = new List<KeyValue>();



                if (checktype == "超标检查")
                {
                    RuletblDictionary dic = new RuletblDictionary();

                    string list = dic.ByParentIDAndValue("执行标准", type);

                    RuletblEQIW_R_DAQLTSTD ruleStdR = new RuletblEQIW_R_DAQLTSTD();

                    DataTable dtSTD = ruleStdR.GetEdition(list);

                    tblData = CalculateOut(dtSTD, tblData, basis, level);
                }



                // 用于存储范围值的
                List<KeyValue> SectionData = new List<KeyValue>();



                if (checktype == "突变值检查")
                {
                    string[] datetimeList = datetime.Split('～');

                    DateTime BeginDate = DateTime.Parse(datetimeList[0]);

                    DateTime EndDate = DateTime.Parse(datetimeList[1]);

                    string year = null;
                    string month = null;
                    string day = null;
                    if
                    (
                        type == "eqia_r" ||
                        type == "eqia_rd" ||
                        type == "eqia_p"
                    )
                    {
                        year = "fldSYear";
                        month = "fldSMonth";
                        day = "fldSDay";
                    }
                    else
                    {
                        year = "fldYear";
                        month = "fldMonth";
                        day = "fldDay";
                    }

                    // 正式表中的数据
                    DataTable dtBaseData = rule.getdt("select * from " + tablename + " where " + year + " in (" + BeginDate.Year.ToString() + "," + EndDate.Year.ToString() + ")");


                    if (dtBaseData == null || dtBaseData.Rows.Count == 0)
                    {
                        if
                        (!(
                            type.Contains("_v") ||
                            type.Contains("eqib") ||
                            type.Contains("eqie") ||
                            type.Contains("eqin") ||
                            type == "eqid_d"
                         ))
                        {
                            DataRow dataRow = tblData.NewRow();

                            foreach (DataColumn item in data.Columns)
                            {
                                dataRow[item.ColumnName] = data.Rows[0][item];
                            }

                            if (dataRow != null)
                            {
                                tblData.Rows.InsertAt(dataRow, 0);
                            }
                        }


                        ReturnJson returnjson2 = new ReturnJson()
                        {
                            Data = tblData,
                            Head = col_zh_cn,
                        };

                        result = rule.JsonStr("nodata", "正式表中无数据！", returnjson2);

                        return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                    }



                    EnumerableRowCollection<DataRow> query = null;
                    if (type.Contains("eqie"))
                    {
                        dtBaseData.Columns.Add("fldDate", typeof(int));


                        foreach (DataRow item in dtBaseData.Rows)
                        {
                            item["fldDate"] = int.Parse(item[year].ToString());
                        }

                        query = from x in dtBaseData.AsEnumerable()
                                where int.Parse(x["fldDate"].ToString()) >= BeginDate.Year && int.Parse(x["fldDate"].ToString()) <= EndDate.Year
                                select x;
                    }
                    else
                    {

                        dtBaseData.Columns.Add("fldDate", typeof(DateTime));

                        foreach (DataRow item in dtBaseData.Rows)
                        {
                            item["fldDate"] = DateTime.Parse(item[year].ToString() + "-" + item[month].ToString() + "-" + item[day].ToString());
                        }

                        query = from x in dtBaseData.AsEnumerable()
                                where DateTime.Parse(x["fldDate"].ToString()) >= BeginDate && DateTime.Parse(x["fldDate"].ToString()) <= EndDate
                                select x;
                    }


                    if (query == null || query.Count() == 0)
                    {

                        if
                        (!(
                            type.Contains("_v") ||
                            type.Contains("eqib") ||
                            type.Contains("eqie") ||
                            type.Contains("eqin") ||
                            type == "eqid_d"
                         ))
                        {
                            DataRow dataRow = tblData.NewRow();

                            foreach (DataColumn item in data.Columns)
                            {
                                dataRow[item.ColumnName] = data.Rows[0][item];
                            }

                            if (dataRow != null)
                            {
                                tblData.Rows.InsertAt(dataRow, 0);
                            }
                        }

                        ReturnJson returnjson2 = new ReturnJson()
                        {
                            Data = tblData,
                            Head = col_zh_cn,
                        };

                        result = rule.JsonStr("nodata", "正式表无数据", returnjson2);

                        return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                    }

                    List<string> colList = new List<string>();

                    List<string> colNumber = new List<string>();

                    List<string> sectionName = new List<string>();

                    foreach (DataColumn item in tblData.Columns)
                    {
                        colList.Add(item.ColumnName);
                    }
                    foreach (var item in colList)
                    {
                        int temp = 0;
                        if (int.TryParse(item.Substring(3, item.Length - 3), out temp))
                        {
                            colNumber.Add(temp.ToString());
                        }
                    }

                    foreach (DataRow item in tblData.Rows)
                    {
                        if (!(sectionName.Contains(item["fldRSName"].ToString())))
                        {
                            sectionName.Add(item["fldRSName"].ToString());
                        }
                    }

                    List<KeyValue> kvlist = new List<KeyValue>();



                    if (type == "eqie")
                    {
                        foreach (var item in colNumber)
                        {
                            var KV = from x in query.AsEnumerable()
                                     select new KeyValue
                                     {
                                         Key = item,
                                         Value = x["fld" + item].ToString()
                                     };



                            if (KV.Count() == 0)
                            {
                                KeyValue kv = new KeyValue()
                                {
                                    Key = item,
                                    Value = "空"
                                };

                                kvlist.Add(kv);
                            }
                            else
                            {
                                double value = 0;

                                foreach (var item1 in KV)
                                {
                                    value += Convert.ToDouble(item1.Value);
                                }

                                value = value / KV.Count();

                                KeyValue kvTemp = new KeyValue
                                {
                                    Key = item,
                                    Value = value.ToString()
                                };

                                if (!(KV == null))
                                {
                                    kvlist.Add(kvTemp);
                                }
                            }
                        }
                    }
                    else
                    {




                        foreach (var item in sectionName)
                        {


                            foreach (var item2 in colNumber)
                            {
                                var KV = from x in query.AsEnumerable()
                                         where x["fldItemCode"].ToString() == item2 && x["fldRSName"].ToString() == item
                                         select new KeyValue
                                         {
                                             Key = x["fldItemCode"].ToString(),
                                             Value = x["fldItemValue"].ToString(),
                                             SectionName = x["fldRSName"].ToString()
                                         };

                                if (KV.Count() == 0)
                                {
                                    KeyValue kv = new KeyValue()
                                    {
                                        Key = item2,
                                        Value = "空",
                                        SectionName = item
                                    };

                                    kvlist.Add(kv);
                                }
                                else
                                {
                                    double value = 0;

                                    foreach (var item1 in KV)
                                    {
                                        value += Convert.ToDouble(item1.Value);
                                    }

                                    value = value / KV.Count();

                                    KeyValue kvTemp = new KeyValue
                                    {
                                        Key = item2,
                                        Value = value.ToString(),
                                        SectionName = item
                                    };

                                    if (!(KV == null))
                                    {
                                        kvlist.Add(kvTemp);
                                    }
                                }
                            }



                        }






                    }






                    foreach (var item1 in kvlist)
                    {
                        foreach (DataRow item2 in tblData.Rows)
                        {

                            if (item1.SectionName == item2["fldRSName"].ToString())
                            {









                                if (!(item2["fld" + item1.Key] == null) && item2["fld" + item1.Key].ToString() != "")
                                {

                                    if (item1.Value == "空")
                                    {
                                        item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_1";
                                    }
                                    else
                                    {
                                        double percentValue = double.Parse(percent) / 100;

                                        double value = double.Parse(item1.Value) * percentValue;

                                        double result1 = 0;

                                        if (item2["fld" + item1.Key].ToString().Contains("L"))
                                        {
                                            result1 = double.Parse(item2["fld" + item1.Key].ToString().TrimEnd('L')) / 2;
                                        }
                                        else
                                        {
                                            result1 = double.Parse(item2["fld" + item1.Key].ToString());
                                        }

                                        double result4 = double.Parse(item1.Value);

                                        // 减去运算百分比后的值
                                        double result2 = result4 - value;

                                        // 加上运算百分比后的值
                                        double result3 = result4 + value;


                                        string result2Value = null;

                                        string result3Value = null;

                                        if (result2 < 0)
                                        {
                                            result2Value = Math.Abs(result2).ToString("0.0000") + "L";
                                        }
                                        else
                                        {
                                            result2Value = Math.Abs(result2).ToString("0.0000");
                                        }


                                        if (result3 < 0)
                                        {
                                            result3Value = Math.Abs(result3).ToString("0.0000") + "L";
                                        }
                                        else
                                        {
                                            result3Value = Math.Abs(result3).ToString("0.0000");
                                        }






                                        KeyValue kv = new KeyValue
                                        {
                                            Key = item1.Key,
                                            Value = result2Value + "～" + result3Value,
                                            SectionName = item1.SectionName
                                        };

                                        SectionData.Add(kv);






                                        if (result1 < result2 || result1 > result3)
                                        {
                                            item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_0";
                                        }
                                        else
                                        {
                                            item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_1";
                                        }
                                    }
                                }






                            }





                        }
                    }





                }














                if (checktype == "因子逻辑关系检查")
                {

                    List<string> colList = new List<string>();

                    List<string> colNumber = new List<string>();

                    foreach (DataColumn item in tblData.Columns)
                    {
                        colList.Add(item.ColumnName);
                    }
                    foreach (var item in colList)
                    {
                        int temp = 0;
                        if (int.TryParse(item.Substring(3, item.Length - 3), out temp))
                        {
                            colNumber.Add(item);
                        }
                    }





                    foreach (DataRow item in tblData.Rows)
                    {
                        foreach (var item2 in colNumber)
                        {
                            //检出限数据，_2用绿色显示
                            if (item[item2].ToString().Contains("L"))
                            {
                                item[item2] = item[item2].ToString() + "_2";
                            }

                            if (true)
                            {

                            }
                        }







                        if
                        (
                            tblData.Columns.Contains("fld316") && //化学需氧量（CODcr）
                            tblData.Columns.Contains("fld317")    //生化需氧量（BOD5）
                        )
                        {
                            if (double.Parse(item["fld316"].ToString()) < double.Parse(item["fld317"].ToString()))
                            {
                                item["fld316"] = item["fld316"].ToString() + "_0";
                                item["fld317"] = item["fld317"].ToString() + "_0";
                            }
                        }


                        if
                        (
                            tblData.Columns.Contains("fld316") && //化学需氧量（CODcr）
                            tblData.Columns.Contains("fld314")    //高锰酸盐指数
                        )
                        {
                            if (double.Parse(item["fld316"].ToString()) < double.Parse(item["fld314"].ToString()))
                            {
                                item["fld316"] = item["fld316"].ToString() + "_0";
                                item["fld314"] = item["fld314"].ToString() + "_0";
                            }
                        }


                        if
                        (
                            tblData.Columns.Contains("fld466") //总氮
                        )
                        {
                            double fld466 = double.Parse(item["fld466"].ToString());
                            double fld311 = 0;
                            double fld310 = 0;

                            //氨氮
                            if (tblData.Columns.Contains("fld311"))
                            {
                                fld311 = double.Parse(item["fld311"].ToString());
                            }

                            //亚硝酸盐（以N计）
                            if (tblData.Columns.Contains("fld310"))
                            {
                                fld310 = double.Parse(item["fld310"].ToString());
                            }

                            if (fld466 < fld311 + fld310)
                            {
                                item["fld466"] = item["fld466"].ToString() + "_0";

                                if (fld311 != 0)
                                {
                                    item["fld311"] = item["fld311"].ToString() + "_0";
                                }

                                if (fld310 != 0)
                                {
                                    item["fld310"] = item["fld310"].ToString() + "_0";
                                }
                            }
                        }
                    }
                }



                if
                (
                    type == "eqiw_r" ||
                     type == "eqiw_r_auto" ||
                    type == "eqiw_d" ||
                    type == "eqiw_sts" ||
                    type == "eqiw_dt" ||
                    type == "eqiw_dx"
                )
                {
                    dataTable.Columns.Add("fldSTName", typeof(string));
                    dataTable.Columns.Add("fldRName", typeof(string));

                    dataTable.Columns.Add("fldRSName", typeof(string));

                    dataTable.Columns.Add("fldDate", typeof(string));
                    dataTable.Columns.Add("fldItemName", typeof(string));
                    dataTable.Columns.Add("fldItemValue", typeof(double));

                    dataTable.Columns.Add("fldRange2", typeof(string));

                    dataTable.Columns.Add("fldRange", typeof(string));

                    DataTable table = rule.getdt("select * from " + viewName[0]);

                    foreach (DataRow item in tblData.Rows)
                    {
                        foreach (var item2 in dictionary)
                        {
                            if (item[item2.Key].ToString().Contains("_0"))
                            {
                                DataRow dr = dataTable.NewRow();
                                dr["fldSTName"] = item["fldSTName"];
                                dr["fldRName"] = item["fldRName"];
                                dr["fldRSName"] = item["fldRSName"];


                                dr["fldDate"] = item["fldDate"].ToString();

                                dr["fldItemName"] = item2.Value;

                                string fldItemValue = null;

                                if (item[item2.Key].ToString().TrimEnd('0', '_').Contains("L"))
                                {
                                    fldItemValue = "-" + item[item2.Key].ToString().TrimEnd('0', '_', 'L');
                                }
                                else
                                {
                                    fldItemValue = item[item2.Key].ToString().TrimEnd('0', '_');
                                }

                                if (fldItemValue == "" || fldItemValue == null)
                                {
                                    dr["fldItemValue"] = -1;
                                }
                                else
                                {
                                    dr["fldItemValue"] = ChangeDataToD(fldItemValue);

                                }







                                if (checktype == "突变值检查")
                                {

                                    var query2 = (from x in SectionData
                                                  where "fld" + x.Key == item2.Key && x.SectionName == item["fldRSName"].ToString()
                                                  select x).FirstOrDefault();

                                    dr["fldRange2"] = query2.Value;

                                }



                                var query = from x in table.AsEnumerable()
                                            where x["fldItemCode"].ToString() == item2.Key.TrimStart('f', 'l', 'd')
                                            select double.Parse(x["fldItemValue"].ToString());


                                string Min = null;

                                string Max = null;


                                if (query.Min() < 0)
                                {
                                    Min = ChangeDataToD(Math.Abs(query.Min()).ToString()) + "L";
                                }
                                else
                                {
                                    Min = ChangeDataToD(query.Min().ToString()) + "";
                                }



                                if (query.Max() < 0)
                                {
                                    Max = ChangeDataToD(Math.Abs(query.Max()).ToString()) + "L";
                                }
                                else
                                {
                                    Max = ChangeDataToD(query.Max().ToString()) + "";
                                }



                                dr["fldRange"] = Min + "～" + Max;
                                dataTable.Rows.Add(dr);

                            }
                        }
                    }




                }
                else if
                (
                    type == "eqiw_g"
                )
                {
                    dataTable.Columns.Add("fldSTName", typeof(string));
                    dataTable.Columns.Add("fldPName", typeof(string));


                    dataTable.Columns.Add("fldDate", typeof(string));
                    dataTable.Columns.Add("fldItemName", typeof(string));
                    dataTable.Columns.Add("fldItemValue", typeof(double));
                    dataTable.Columns.Add("fldRange", typeof(string));


                    DataTable table = rule.getdt("select * from " + viewName[0]);


                    foreach (DataRow item in tblData.Rows)
                    {
                        foreach (var item2 in dictionary)
                        {
                            if (item[item2.Key].ToString().Contains("_0"))
                            {
                                DataRow dr = dataTable.NewRow();
                                dr["fldSTName"] = item["fldSTName"];
                                dr["fldPName"] = item["fldPName"];


                                dr["fldDate"] = item["fldDate"].ToString();

                                dr["fldItemName"] = item2.Value;


                                string fldItemValue = null;

                                if (item[item2.Key].ToString().TrimEnd('0', '_').Contains("L"))
                                {
                                    fldItemValue = "-" + item[item2.Key].ToString().TrimEnd('0', '_', 'L');
                                }
                                else
                                {
                                    fldItemValue = item[item2.Key].ToString().TrimEnd('0', '_');
                                }



                                dr["fldItemValue"] = fldItemValue;
                                var query = from x in table.AsEnumerable()
                                            where x["fldItemCode"].ToString() == item2.Key.TrimStart('f', 'l', 'd')
                                            select double.Parse(x["fldItemValue"].ToString());
                                dr["fldRange"] = query.Min() + "～" + query.Max();
                                dataTable.Rows.Add(dr);
                            }
                        }
                    }
                }




                if
                (!(
                    type.Contains("_v") ||
                    type.Contains("eqib") ||
                    type.Contains("eqie") ||
                    type.Contains("eqin") ||
                    type == "eqid_d"
                 ))
                {
                    DataRow dataRow = tblData.NewRow();

                    foreach (DataColumn item in data.Columns)
                    {
                        dataRow[item.ColumnName] = data.Rows[0][item];
                    }

                    if (dataRow != null)
                    {
                        tblData.Rows.InsertAt(dataRow, 0);
                    }
                }



                DataTable dtTemp = new DataTable();

                foreach (DataColumn item in dataTable.Columns)
                {
                    dtTemp.Columns.Add(item.ColumnName, typeof(string));
                }


                foreach (DataRow item in dataTable.Rows)
                {
                    dtTemp.ImportRow(item);
                }

                dataTable = dtTemp;



                foreach (DataRow item in dataTable.Rows)
                {
                    foreach (DataColumn item2 in dataTable.Columns)
                    {
                        double num = 0;
                        if (double.TryParse(item[item2.ColumnName].ToString(), out num))
                        {
                            if (num < 0)
                            {
                                item[item2.ColumnName] = ChangeDataToD(Math.Abs(num).ToString()) + "L";
                            }
                        }
                    }
                }














                if (checktype == "Itemlogic")
                {
                    #region 表达式处理


                    //DataTable Temp = new DataTable();
                    //Temp = tblData.Copy();

                    int i = 0;
                    foreach (var item in col_zh_cn)
                    {
                        tblData.Columns[i].ColumnName = item;
                        i++;
                    }


                    tblData.Columns.Add("颜色信息", typeof(string));


                    //Temp.Columns.Add("其他因子逻辑对应关系", typeof(string)).SetOrdinal(5);
                    //Temp.Columns.Add("颜色信息", typeof(string));



                    List<Mode.tblCorrespond_Btype_ItemCode> list = new List<Mode.tblCorrespond_Btype_ItemCode>();

                    using (Mode.EntityContext db = new Mode.EntityContext())
                    {
                        list = (from x in db.tblCorrespond_Btype_ItemCode
                                where x.fldExpression != null && x.fldExpression != ""
                                select x).ToList();
                    }

                    bool IsFirst = true;
                    foreach (DataRow item in tblData.Rows)
                    {
                        if (IsFirst)
                        {
                            IsFirst = false;
                            continue;
                        }
                        string IDList = "";

                        string colorList = "";

                        foreach (var exp2 in list)
                        {
                            bool bol = true;

                            List<string> explist = exp2.fldExpression.Split(' ').ToList();

                            List<string> explist_temp = new List<string>();

                            foreach (var item2 in explist)
                            {
                                explist_temp.Add(item2);
                            }



                            explist.Remove("+");
                            explist.Remove("-");
                            explist.Remove("*");
                            explist.Remove("/");
                            explist.Remove(">");
                            explist.Remove("<");
                            explist.Remove("=");
                            explist.Remove("");


                            foreach (var item2 in explist)
                            {
                                if (!(tblData.Columns.Contains(item2)))
                                {
                                    bol = false;
                                    break;
                                }
                            }


                            if (bol)
                            {
                                foreach (DataColumn item2 in tblData.Columns)
                                {

                                    if (explist.Contains(item2.ColumnName))
                                    {
                                        if (item[item2].ToString() == "")
                                        {
                                            bol = false;
                                            break;
                                        }
                                        else
                                        {
                                            if (item[item2.ColumnName].ToString().Contains("L"))
                                            {
                                                string temp = "-" + item[item2.ColumnName].ToString().TrimEnd('L');

                                                for (int k = 0; k < explist_temp.Count; k++)
                                                {
                                                    if (explist_temp[k] == item2.ColumnName)
                                                    {
                                                        explist_temp[k] = temp;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                for (int j = 0; j < explist_temp.Count; j++)
                                                {
                                                    if (explist_temp[j] == item2.ColumnName)
                                                    {
                                                        explist_temp[j] = item[item2.ColumnName].ToString().TrimEnd('(', ')', '（', '）', '/', 'Ⅰ', 'Ⅱ', 'Ⅲ', 'Ⅳ', 'Ⅴ', '劣');
                                                    }
                                                }
                                            }
                                        }
                                    }




                                }

                            }


                            if (bol)
                            {
                                string exp = null;

                                foreach (var item2 in explist_temp)
                                {
                                    exp += item2;
                                }

                                exp = exp.Trim();

                                bool result1 = bool.Parse(item.Table.Compute(exp, "").ToString());

                                if (!result1)
                                {
                                    IDList += exp2.fldIndex + ",";

                                    foreach (var item2 in explist)
                                    {
                                        colorList += item2 + ",";
                                    }
                                }
                            }
                        }

                        //item["其他因子逻辑对应关系"] = IDList.TrimEnd(',');

                        item["颜色信息"] = colorList.TrimEnd(',');

                    }



                    //int count = 0;
                    //foreach (DataRow item2 in tblData.Rows)
                    //{
                    //    tblData.Rows[count]["颜色信息"] = item2["颜色信息"].ToString();
                    //    tblData.Rows[count]["其他因子逻辑对应关系"] = item2["其他因子逻辑对应关系"].ToString();
                    //    count++;
                    //}


                    #endregion
                }















                ReturnJson returnjson = new ReturnJson()
                {
                    Data = tblData,
                    Head = col_zh_cn,
                    dataTable = dataTable
                };





                if (!(returnjson == null))
                {
                    result = rule.JsonStr("ok", "", returnjson);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据", returnjson);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }
















        /// <summary>
        /// 功能描述：根据传入的参数，返回标准表中各项目的值
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-6-23
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <returns>返回fldItemCode列与级别列的DataTable转换的Json字符串</returns>
        [HttpPost]
        public HttpResponseMessage ReturnStandardValue_V2(ReturnStandardValue_V2_Info info)
        {
            string result = string.Empty;
            try
            {
                DataTable tblData = new DataTable();

                RuleEQICommon_Auditing com = new RuleEQICommon_Auditing();

                RuletblDictionary rd = new RuletblDictionary();

                string[] viewName = rd.ByParentIDAndValue("数据审核视图", info.type).Split(',');

                string defaultwhere = null;

                string fldSource = "0";

                if (info.type.Contains("hm"))
                {
                    fldSource = "1";
                }





                if (info.Number3Auditing == null || info.Number3Auditing == "")
                {
                    if (info.flag == "0")
                    {
                        defaultwhere = "fldCityID_Operate=" + info.cityid + " and fldSource=" + fldSource + " and fldFlag=" + info.flag + " and fldImport=1" + info.where;
                    }
                    else
                    {
                        if (info.cityid == "2")
                        {
                            if (info.type == "eqiw_r_auto")
                            {
                                defaultwhere = " fldFlag=0 " + info.where;
                            }
                            else
                            {
                                defaultwhere = "fldSource=" + fldSource + " and fldFlag=" + info.flag + " " + info.where;
                            }


                            if (info.where.Contains("fldSource"))
                            {
                                defaultwhere = " fldFlag=" + info.flag + " " + info.where;
                            }
                        }
                        else
                        {
                            if (info.type == "eqiw_r_auto")
                            {
                                defaultwhere = "fldCityID_Operate=" + info.cityid + " and fldFlag=0 " + info.where;
                            }
                            else
                            {
                                defaultwhere = "fldCityID_Operate=" + info.cityid + " and fldSource=" + fldSource + " and fldFlag=" + info.flag + " " + info.where;
                            }
                        }
                    }

                }
                else
                {
                    defaultwhere = "fldCityID_Operate=" + info.cityid + " and fldSource=" + fldSource + " and fldFlag=" + info.flag + " and fldImport=1" + info.where;
                }













                // 页面条件返回的数据
                tblData = com.GetAuditingDatabyBusinessType(info.type, viewName[0], defaultwhere, 0);


                foreach (DataRow item in tblData.Rows)
                {
                    foreach (DataColumn item2 in tblData.Columns)
                    {
                        string name = item2.ColumnName.TrimStart('f', 'l', 'd');
                        int itemcode = 0;

                        if (int.TryParse(name, out itemcode))
                        {
                            item[item2.ColumnName] = item[item2.ColumnName].ToString().Split('_')[0];
                        }
                    }
                }








                RuleEQIV_WaitTable_Auditing rulAud = new RuleEQIV_WaitTable_Auditing();

                if (info.type.Contains("_v") || info.type.Contains("eqie"))
                {
                    tblData = rulAud.GetEqiv_AuditingData(viewName[0], defaultwhere, info.type);
                }

                DataTable data = tblData.Copy();


                if
                (!(
                    info.type.Contains("_v") ||
                    info.type.Contains("eqib") ||
                    info.type.Contains("eqie") ||
                    info.type.Contains("eqin") ||
                    info.type == "eqid_d"
                ))
                {
                    if (tblData.Rows.Count > 0)
                    {

                        tblData.Rows.RemoveAt(0);
                    }
                }

                DataTable dt = new DataTable();

                foreach (DataColumn item in tblData.Columns)
                {
                    dt.Columns.Add(item.ColumnName, typeof(string));
                }

                foreach (DataRow item in tblData.Rows)
                {
                    dt.ImportRow(item);
                }

                tblData = dt;


                Dictionary<string, string> dictionary = new Dictionary<string, string>();

                List<string> col_zh_cn = TitleName(info.type, viewName[1], tblData, out dictionary);

                DataTable dataTable = new DataTable();




                if (tblData == null || tblData.Rows.Count == 0)
                {

                    ReturnJson returnjson2 = new ReturnJson()
                    {
                        Data = tblData,
                        Head = col_zh_cn,
                    };

                    result = rule.JsonStr("nodata", "无数据", returnjson2);

                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }

                string getjson = rule.GetJson(strLocalpath);

                JArray jsonObj = JArray.Parse(getjson);

                var tablename = (from x in jsonObj
                                 where x["type"].ToString() == info.type
                                 select x["tablename"].ToString()).FirstOrDefault();



                List<KeyValue> kvlist2 = new List<KeyValue>();



                if (info.checktype == "超标检查")
                {
                    RuletblDictionary dic = new RuletblDictionary();

                    string list = dic.ByParentIDAndValue("执行标准", info.type);

                    RuletblEQIW_R_DAQLTSTD ruleStdR = new RuletblEQIW_R_DAQLTSTD();

                    DataTable dtSTD = ruleStdR.GetEdition(list);

                    tblData = CalculateOut(dtSTD, tblData, info.basis, info.level);
                }



                // 用于存储范围值的
                List<KeyValue> SectionData = new List<KeyValue>();



                if (info.checktype == "突变值检查")
                {
                    string[] datetimeList = info.datetime.Split('～');

                    DateTime BeginDate = DateTime.Parse(datetimeList[0]);

                    DateTime EndDate = DateTime.Parse(datetimeList[1]);

                    string year = null;
                    string month = null;
                    string day = null;
                    if
                    (
                        info.type == "eqia_r" ||
                        info.type == "eqia_rd" ||
                        info.type == "eqia_p"
                    )
                    {
                        year = "fldSYear";
                        month = "fldSMonth";
                        day = "fldSDay";
                    }
                    else
                    {
                        year = "fldYear";
                        month = "fldMonth";
                        day = "fldDay";
                    }

                    // 正式表中的数据
                    DataTable dtBaseData = rule.getdt("select * from " + tablename + " where " + year + " in (" + BeginDate.Year.ToString() + "," + EndDate.Year.ToString() + ")");


                    if (dtBaseData == null || dtBaseData.Rows.Count == 0)
                    {
                        if
                        (!(
                            info.type.Contains("_v") ||
                            info.type.Contains("eqib") ||
                            info.type.Contains("eqie") ||
                            info.type.Contains("eqin") ||
                            info.type == "eqid_d"
                         ))
                        {
                            DataRow dataRow = tblData.NewRow();

                            foreach (DataColumn item in data.Columns)
                            {
                                dataRow[item.ColumnName] = data.Rows[0][item];
                            }

                            if (dataRow != null)
                            {
                                tblData.Rows.InsertAt(dataRow, 0);
                            }
                        }


                        ReturnJson returnjson2 = new ReturnJson()
                        {
                            Data = tblData,
                            Head = col_zh_cn,
                        };

                        result = rule.JsonStr("nodata", "正式表中无数据！", returnjson2);

                        return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                    }



                    EnumerableRowCollection<DataRow> query = null;
                    if (info.type.Contains("eqie"))
                    {
                        dtBaseData.Columns.Add("fldDate", typeof(int));


                        foreach (DataRow item in dtBaseData.Rows)
                        {
                            item["fldDate"] = int.Parse(item[year].ToString());
                        }

                        query = from x in dtBaseData.AsEnumerable()
                                where int.Parse(x["fldDate"].ToString()) >= BeginDate.Year && int.Parse(x["fldDate"].ToString()) <= EndDate.Year
                                select x;
                    }
                    else
                    {

                        dtBaseData.Columns.Add("fldDate", typeof(DateTime));

                        foreach (DataRow item in dtBaseData.Rows)
                        {
                            item["fldDate"] = DateTime.Parse(item[year].ToString() + "-" + item[month].ToString() + "-" + item[day].ToString());
                        }

                        query = from x in dtBaseData.AsEnumerable()
                                where DateTime.Parse(x["fldDate"].ToString()) >= BeginDate && DateTime.Parse(x["fldDate"].ToString()) <= EndDate
                                select x;
                    }


                    if (query == null || query.Count() == 0)
                    {

                        if
                        (!(
                            info.type.Contains("_v") ||
                            info.type.Contains("eqib") ||
                            info.type.Contains("eqie") ||
                            info.type.Contains("eqin") ||
                            info.type == "eqid_d"
                         ))
                        {
                            DataRow dataRow = tblData.NewRow();

                            foreach (DataColumn item in data.Columns)
                            {
                                dataRow[item.ColumnName] = data.Rows[0][item];
                            }

                            if (dataRow != null)
                            {
                                tblData.Rows.InsertAt(dataRow, 0);
                            }
                        }

                        ReturnJson returnjson2 = new ReturnJson()
                        {
                            Data = tblData,
                            Head = col_zh_cn,
                        };

                        result = rule.JsonStr("nodata", "正式表无数据", returnjson2);

                        return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                    }

                    List<string> colList = new List<string>();

                    List<string> colNumber = new List<string>();

                    List<string> sectionName = new List<string>();

                    foreach (DataColumn item in tblData.Columns)
                    {
                        colList.Add(item.ColumnName);
                    }
                    foreach (var item in colList)
                    {
                        int temp = 0;
                        if (int.TryParse(item.Substring(3, item.Length - 3), out temp))
                        {
                            colNumber.Add(temp.ToString());
                        }
                    }

                    foreach (DataRow item in tblData.Rows)
                    {
                        if (!(sectionName.Contains(item["fldRSName"].ToString())))
                        {
                            sectionName.Add(item["fldRSName"].ToString());
                        }
                    }

                    List<KeyValue> kvlist = new List<KeyValue>();



                    if (info.type == "eqie")
                    {
                        foreach (var item in colNumber)
                        {
                            var KV = from x in query.AsEnumerable()
                                     select new KeyValue
                                     {
                                         Key = item,
                                         Value = x["fld" + item].ToString()
                                     };



                            if (KV.Count() == 0)
                            {
                                KeyValue kv = new KeyValue()
                                {
                                    Key = item,
                                    Value = "空"
                                };

                                kvlist.Add(kv);
                            }
                            else
                            {
                                double value = 0;

                                foreach (var item1 in KV)
                                {
                                    value += Convert.ToDouble(item1.Value);
                                }

                                value = value / KV.Count();

                                KeyValue kvTemp = new KeyValue
                                {
                                    Key = item,
                                    Value = value.ToString()
                                };

                                if (!(KV == null))
                                {
                                    kvlist.Add(kvTemp);
                                }
                            }
                        }
                    }
                    else
                    {




                        foreach (var item in sectionName)
                        {


                            foreach (var item2 in colNumber)
                            {
                                var KV = from x in query.AsEnumerable()
                                         where x["fldItemCode"].ToString() == item2 && x["fldRSName"].ToString() == item
                                         select new KeyValue
                                         {
                                             Key = x["fldItemCode"].ToString(),
                                             Value = x["fldItemValue"].ToString(),
                                             SectionName = x["fldRSName"].ToString()
                                         };

                                if (KV.Count() == 0)
                                {
                                    KeyValue kv = new KeyValue()
                                    {
                                        Key = item2,
                                        Value = "空",
                                        SectionName = item
                                    };

                                    kvlist.Add(kv);
                                }
                                else
                                {
                                    double value = 0;

                                    foreach (var item1 in KV)
                                    {
                                        value += Convert.ToDouble(item1.Value);
                                    }

                                    value = value / KV.Count();

                                    KeyValue kvTemp = new KeyValue
                                    {
                                        Key = item2,
                                        Value = value.ToString(),
                                        SectionName = item
                                    };

                                    if (!(KV == null))
                                    {
                                        kvlist.Add(kvTemp);
                                    }
                                }
                            }



                        }






                    }






                    foreach (var item1 in kvlist)
                    {
                        foreach (DataRow item2 in tblData.Rows)
                        {

                            if (item1.SectionName == item2["fldRSName"].ToString())
                            {









                                if (!(item2["fld" + item1.Key] == null) && item2["fld" + item1.Key].ToString() != "")
                                {

                                    if (item1.Value == "空")
                                    {
                                        item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_1";
                                    }
                                    else
                                    {
                                        double percentValue = double.Parse(info.percent) / 100;

                                        double value = double.Parse(item1.Value) * percentValue;

                                        double result1 = 0;

                                        if (item2["fld" + item1.Key].ToString().Contains("L"))
                                        {
                                            result1 = double.Parse(item2["fld" + item1.Key].ToString().TrimEnd('L')) / 2;
                                        }
                                        else
                                        {
                                            result1 = double.Parse(item2["fld" + item1.Key].ToString());
                                        }

                                        double result4 = double.Parse(item1.Value);

                                        // 减去运算百分比后的值
                                        double result2 = result4 - value;

                                        // 加上运算百分比后的值
                                        double result3 = result4 + value;


                                        string result2Value = null;

                                        string result3Value = null;

                                        if (result2 < 0)
                                        {
                                            result2Value = Math.Abs(result2).ToString("0.0000") + "L";
                                        }
                                        else
                                        {
                                            result2Value = Math.Abs(result2).ToString("0.0000");
                                        }


                                        if (result3 < 0)
                                        {
                                            result3Value = Math.Abs(result3).ToString("0.0000") + "L";
                                        }
                                        else
                                        {
                                            result3Value = Math.Abs(result3).ToString("0.0000");
                                        }






                                        KeyValue kv = new KeyValue
                                        {
                                            Key = item1.Key,
                                            Value = result2Value + "～" + result3Value,
                                            SectionName = item1.SectionName
                                        };

                                        SectionData.Add(kv);






                                        if (result1 < result2 || result1 > result3)
                                        {
                                            item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_0";
                                        }
                                        else
                                        {
                                            item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_1";
                                        }
                                    }
                                }






                            }





                        }
                    }





                }














                if (info.checktype == "因子逻辑关系检查")
                {

                    List<string> colList = new List<string>();

                    List<string> colNumber = new List<string>();

                    foreach (DataColumn item in tblData.Columns)
                    {
                        colList.Add(item.ColumnName);
                    }
                    foreach (var item in colList)
                    {
                        int temp = 0;
                        if (int.TryParse(item.Substring(3, item.Length - 3), out temp))
                        {
                            colNumber.Add(item);
                        }
                    }





                    foreach (DataRow item in tblData.Rows)
                    {
                        foreach (var item2 in colNumber)
                        {
                            //检出限数据，_2用绿色显示
                            if (item[item2].ToString().Contains("L"))
                            {
                                item[item2] = item[item2].ToString() + "_2";
                            }

                            if (true)
                            {

                            }
                        }







                        if
                        (
                            tblData.Columns.Contains("fld316") && //化学需氧量（CODcr）
                            tblData.Columns.Contains("fld317")    //生化需氧量（BOD5）
                        )
                        {
                            if (double.Parse(item["fld316"].ToString()) < double.Parse(item["fld317"].ToString()))
                            {
                                item["fld316"] = item["fld316"].ToString() + "_0";
                                item["fld317"] = item["fld317"].ToString() + "_0";
                            }
                        }


                        if
                        (
                            tblData.Columns.Contains("fld316") && //化学需氧量（CODcr）
                            tblData.Columns.Contains("fld314")    //高锰酸盐指数
                        )
                        {
                            if (double.Parse(item["fld316"].ToString()) < double.Parse(item["fld314"].ToString()))
                            {
                                item["fld316"] = item["fld316"].ToString() + "_0";
                                item["fld314"] = item["fld314"].ToString() + "_0";
                            }
                        }


                        if
                        (
                            tblData.Columns.Contains("fld466") //总氮
                        )
                        {
                            double fld466 = double.Parse(item["fld466"].ToString());
                            double fld311 = 0;
                            double fld310 = 0;

                            //氨氮
                            if (tblData.Columns.Contains("fld311"))
                            {
                                fld311 = double.Parse(item["fld311"].ToString());
                            }

                            //亚硝酸盐（以N计）
                            if (tblData.Columns.Contains("fld310"))
                            {
                                fld310 = double.Parse(item["fld310"].ToString());
                            }

                            if (fld466 < fld311 + fld310)
                            {
                                item["fld466"] = item["fld466"].ToString() + "_0";

                                if (fld311 != 0)
                                {
                                    item["fld311"] = item["fld311"].ToString() + "_0";
                                }

                                if (fld310 != 0)
                                {
                                    item["fld310"] = item["fld310"].ToString() + "_0";
                                }
                            }
                        }
                    }
                }



                if
                (
                    info.type == "eqiw_r" ||
                     info.type == "eqiw_r_auto" ||
                    info.type == "eqiw_d" ||
                    info.type == "eqiw_sts" ||
                    info.type == "eqiw_dt" ||
                    info.type == "eqiw_dx"
                )
                {
                    dataTable.Columns.Add("fldSTName", typeof(string));
                    dataTable.Columns.Add("fldRName", typeof(string));

                    dataTable.Columns.Add("fldRSName", typeof(string));

                    dataTable.Columns.Add("fldDate", typeof(string));
                    dataTable.Columns.Add("fldItemName", typeof(string));
                    dataTable.Columns.Add("fldItemValue", typeof(double));

                    dataTable.Columns.Add("fldRange2", typeof(string));

                    dataTable.Columns.Add("fldRange", typeof(string));

                    DataTable table = rule.getdt("select * from " + viewName[0]);

                    foreach (DataRow item in tblData.Rows)
                    {
                        foreach (var item2 in dictionary)
                        {
                            if (item[item2.Key].ToString().Contains("_0"))
                            {
                                DataRow dr = dataTable.NewRow();
                                dr["fldSTName"] = item["fldSTName"];
                                dr["fldRName"] = item["fldRName"];
                                dr["fldRSName"] = item["fldRSName"];


                                dr["fldDate"] = item["fldDate"].ToString();

                                dr["fldItemName"] = item2.Value;

                                string fldItemValue = null;

                                if (item[item2.Key].ToString().TrimEnd('0', '_').Contains("L"))
                                {
                                    fldItemValue = "-" + item[item2.Key].ToString().TrimEnd('0', '_', 'L');
                                }
                                else
                                {
                                    fldItemValue = item[item2.Key].ToString().TrimEnd('0', '_');
                                }

                                if (fldItemValue == "" || fldItemValue == null)
                                {
                                    dr["fldItemValue"] = -1;
                                }
                                else
                                {
                                    dr["fldItemValue"] = ChangeDataToD(fldItemValue);

                                }







                                if (info.checktype == "突变值检查")
                                {

                                    var query2 = (from x in SectionData
                                                  where "fld" + x.Key == item2.Key && x.SectionName == item["fldRSName"].ToString()
                                                  select x).FirstOrDefault();

                                    dr["fldRange2"] = query2.Value;

                                }



                                var query = from x in table.AsEnumerable()
                                            where x["fldItemCode"].ToString() == item2.Key.TrimStart('f', 'l', 'd')
                                            select double.Parse(x["fldItemValue"].ToString());


                                string Min = null;

                                string Max = null;


                                if (query.Min() < 0)
                                {
                                    Min = ChangeDataToD(Math.Abs(query.Min()).ToString()) + "L";
                                }
                                else
                                {
                                    Min = ChangeDataToD(query.Min().ToString()) + "";
                                }



                                if (query.Max() < 0)
                                {
                                    Max = ChangeDataToD(Math.Abs(query.Max()).ToString()) + "L";
                                }
                                else
                                {
                                    Max = ChangeDataToD(query.Max().ToString()) + "";
                                }



                                dr["fldRange"] = Min + "～" + Max;
                                dataTable.Rows.Add(dr);

                            }
                        }
                    }




                }
                else if
                (
                    info.type == "eqiw_g"
                )
                {
                    dataTable.Columns.Add("fldSTName", typeof(string));
                    dataTable.Columns.Add("fldPName", typeof(string));


                    dataTable.Columns.Add("fldDate", typeof(string));
                    dataTable.Columns.Add("fldItemName", typeof(string));
                    dataTable.Columns.Add("fldItemValue", typeof(double));
                    dataTable.Columns.Add("fldRange", typeof(string));


                    DataTable table = rule.getdt("select * from " + viewName[0]);


                    foreach (DataRow item in tblData.Rows)
                    {
                        foreach (var item2 in dictionary)
                        {
                            if (item[item2.Key].ToString().Contains("_0"))
                            {
                                DataRow dr = dataTable.NewRow();
                                dr["fldSTName"] = item["fldSTName"];
                                dr["fldPName"] = item["fldPName"];


                                dr["fldDate"] = item["fldDate"].ToString();

                                dr["fldItemName"] = item2.Value;


                                string fldItemValue = null;

                                if (item[item2.Key].ToString().TrimEnd('0', '_').Contains("L"))
                                {
                                    fldItemValue = "-" + item[item2.Key].ToString().TrimEnd('0', '_', 'L');
                                }
                                else
                                {
                                    fldItemValue = item[item2.Key].ToString().TrimEnd('0', '_');
                                }



                                dr["fldItemValue"] = fldItemValue;
                                var query = from x in table.AsEnumerable()
                                            where x["fldItemCode"].ToString() == item2.Key.TrimStart('f', 'l', 'd')
                                            select double.Parse(x["fldItemValue"].ToString());
                                dr["fldRange"] = query.Min() + "～" + query.Max();
                                dataTable.Rows.Add(dr);
                            }
                        }
                    }
                }




                if
                (!(
                    info.type.Contains("_v") ||
                    info.type.Contains("eqib") ||
                    info.type.Contains("eqie") ||
                    info.type.Contains("eqin") ||
                    info.type == "eqid_d"
                 ))
                {
                    DataRow dataRow = tblData.NewRow();

                    foreach (DataColumn item in data.Columns)
                    {
                        dataRow[item.ColumnName] = data.Rows[0][item];
                    }

                    if (dataRow != null)
                    {
                        tblData.Rows.InsertAt(dataRow, 0);
                    }
                }



                DataTable dtTemp = new DataTable();

                foreach (DataColumn item in dataTable.Columns)
                {
                    dtTemp.Columns.Add(item.ColumnName, typeof(string));
                }


                foreach (DataRow item in dataTable.Rows)
                {
                    dtTemp.ImportRow(item);
                }

                dataTable = dtTemp;



                foreach (DataRow item in dataTable.Rows)
                {
                    foreach (DataColumn item2 in dataTable.Columns)
                    {
                        double num = 0;
                        if (double.TryParse(item[item2.ColumnName].ToString(), out num))
                        {
                            if (num < 0)
                            {
                                item[item2.ColumnName] = ChangeDataToD(Math.Abs(num).ToString()) + "L";
                            }
                        }
                    }
                }














                if (info.checktype == "Itemlogic")
                {
                    #region 表达式处理


                    //DataTable Temp = new DataTable();
                    //Temp = tblData.Copy();

                    int i = 0;
                    foreach (var item in col_zh_cn)
                    {
                        tblData.Columns[i].ColumnName = item;
                        i++;
                    }


                    tblData.Columns.Add("颜色信息", typeof(string));


                    //Temp.Columns.Add("其他因子逻辑对应关系", typeof(string)).SetOrdinal(5);
                    //Temp.Columns.Add("颜色信息", typeof(string));



                    List<Mode.tblCorrespond_Btype_ItemCode> list = new List<Mode.tblCorrespond_Btype_ItemCode>();

                    using (Mode.EntityContext db = new Mode.EntityContext())
                    {
                        list = (from x in db.tblCorrespond_Btype_ItemCode
                                where x.fldExpression != null && x.fldExpression != ""
                                select x).ToList();
                    }

                    bool IsFirst = true;
                    foreach (DataRow item in tblData.Rows)
                    {
                        if (IsFirst)
                        {
                            IsFirst = false;
                            continue;
                        }
                        string IDList = "";

                        string colorList = "";

                        foreach (var exp2 in list)
                        {
                            bool bol = true;

                            List<string> explist = exp2.fldExpression.Split(' ').ToList();

                            List<string> explist_temp = new List<string>();

                            foreach (var item2 in explist)
                            {
                                explist_temp.Add(item2);
                            }



                            explist.Remove("+");
                            explist.Remove("-");
                            explist.Remove("*");
                            explist.Remove("/");
                            explist.Remove(">");
                            explist.Remove("<");
                            explist.Remove("=");
                            explist.Remove("");


                            foreach (var item2 in explist)
                            {
                                if (!(tblData.Columns.Contains(item2)))
                                {
                                    bol = false;
                                    break;
                                }
                            }


                            if (bol)
                            {
                                foreach (DataColumn item2 in tblData.Columns)
                                {

                                    if (explist.Contains(item2.ColumnName))
                                    {
                                        if (item[item2].ToString() == "")
                                        {
                                            bol = false;
                                            break;
                                        }
                                        else
                                        {
                                            if (item[item2.ColumnName].ToString().Contains("L"))
                                            {
                                                string temp = "-" + item[item2.ColumnName].ToString().TrimEnd('L');

                                                for (int k = 0; k < explist_temp.Count; k++)
                                                {
                                                    if (explist_temp[k] == item2.ColumnName)
                                                    {
                                                        explist_temp[k] = temp;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                for (int j = 0; j < explist_temp.Count; j++)
                                                {
                                                    if (explist_temp[j] == item2.ColumnName)
                                                    {
                                                        explist_temp[j] = item[item2.ColumnName].ToString().TrimEnd('(', ')', '（', '）', '/', 'Ⅰ', 'Ⅱ', 'Ⅲ', 'Ⅳ', 'Ⅴ', '劣');
                                                    }
                                                }
                                            }
                                        }
                                    }




                                }

                            }


                            if (bol)
                            {
                                string exp = null;

                                foreach (var item2 in explist_temp)
                                {
                                    exp += item2;
                                }

                                exp = exp.Trim();

                                bool result1 = bool.Parse(item.Table.Compute(exp, "").ToString());

                                if (!result1)
                                {
                                    IDList += exp2.fldIndex + ",";

                                    foreach (var item2 in explist)
                                    {
                                        colorList += item2 + ",";
                                    }
                                }
                            }
                        }

                        //item["其他因子逻辑对应关系"] = IDList.TrimEnd(',');

                        item["颜色信息"] = colorList.TrimEnd(',');

                    }



                    //int count = 0;
                    //foreach (DataRow item2 in tblData.Rows)
                    //{
                    //    tblData.Rows[count]["颜色信息"] = item2["颜色信息"].ToString();
                    //    tblData.Rows[count]["其他因子逻辑对应关系"] = item2["其他因子逻辑对应关系"].ToString();
                    //    count++;
                    //}


                    #endregion
                }















                ReturnJson returnjson = new ReturnJson()
                {
                    Data = tblData,
                    Head = col_zh_cn,
                    dataTable = dataTable
                };





                if (!(returnjson == null))
                {
                    result = rule.JsonStr("ok", "", returnjson);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据", returnjson);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }






        public class ReturnStandardValue_V2_Info
        {
            /// <summary>
            /// 业务类型
            /// </summary>
            public string type { get; set; }


            /// <summary>
            /// 检查方式：“超标检查”，“突变值检查”，“因子逻辑关系检查”
            /// </summary>
            public string checktype { get; set; }


            /// <summary>
            /// 判断超标依据
            /// </summary>
            public string basis { get; set; }


            /// <summary>
            /// 级别
            /// </summary>
            public string level { get; set; }


            /// <summary>
            /// 日期范围，格式：2017-06-01～2017-07-06
            /// </summary>
            public string datetime { get; set; }


            /// <summary>
            /// 百分比
            /// </summary>
            public string percent { get; set; }


            /// <summary>
            /// 城市ID
            /// </summary>
            public string cityid { get; set; }


            /// <summary>
            /// 查询条件
            /// </summary>
            public string where { get; set; }


            /// <summary>
            /// 数据状态标识，0是待提交，1是待审核
            /// </summary>
            public string flag { get; set; }


            /// <summary>
            /// 三级审核
            /// 不传为null，就是默认的审核
            /// 其他任意值属于三级审核
            /// </summary>
            public string Number3Auditing { get; set; }




        }






























        private List<string> TitleName(string type, string viewName, DataTable tblData, out Dictionary<string, string> dictionary)
        {
            string colNameList = null;

            foreach (DataColumn item in tblData.Columns)
            {
                colNameList += "'" + item.ColumnName + "',";
            }

            colNameList = colNameList.TrimEnd(',');

            DataTable TempColList = rule.ChinesizeTitleNamebyViewName(viewName, colNameList);

            List<string> col_zh_cn = new List<string>();

            dictionary = new Dictionary<string, string>();

            foreach (DataColumn item in tblData.Columns)
            {
                var querycol = (from x in TempColList.AsEnumerable()
                                where x["fldFieldName"].ToString() == item.ColumnName
                                select x["fldFieldDesc"].ToString()).FirstOrDefault();

                if (querycol == null)
                {
                    RuletblEQIA_R_Item itemnames = new RuletblEQIA_R_Item();

                    tblEQIA_R_Item name = itemnames.ByItemCodes(item.ColumnName.Substring(3, item.ColumnName.Length - 3), type, "");

                    col_zh_cn.Add(name.fldItemName);

                    dictionary.Add(item.ColumnName, name.fldItemName);
                }
                else
                {
                    col_zh_cn.Add(querycol);
                }
            }

            return col_zh_cn;
        }


        /// <summary>
        /// 超标检查具体的处理方法
        /// </summary>
        /// <param name="dt">需要处理的DataTable表</param>
        /// <param name="dt2">页面返回的数据</param>
        /// <param name="basis">超标依据</param>
        /// <param name="level">级别</param>
        /// <returns></returns>
        private static DataTable CalculateOut(DataTable dt, DataTable dt2, string basis, string level)
        {

            if (level == "All")
            {
                string colItem = null;

                if (dt.Columns.Contains("fldEdition"))
                {
                    colItem = "fldEdition";
                }
                if (dt.Columns.Contains("fldStandardNum"))
                {
                    colItem = "fldStandardNum";
                }
                var query = (from x in dt.AsEnumerable()
                             where x[colItem].ToString() == basis
                             select x).CopyToDataTable();



                List<string> colList = new List<string>();

                List<string> colNumber = new List<string>();

                foreach (DataColumn item in dt2.Columns)
                {
                    colList.Add(item.ColumnName);
                }
                foreach (var item in colList)
                {
                    int temp = 0;
                    if (int.TryParse(item.Substring(3, item.Length - 3), out temp))
                    {
                        colNumber.Add(temp.ToString());
                    }
                }

                List<StdValue> svlist = new List<StdValue>();

                foreach (var item in colNumber)
                {
                    var KV = (from x in query.AsEnumerable()
                              where x["fldItemCode"].ToString() == item
                              select new StdValue
                              {
                                  ItemName = x["fldItemCode"].ToString(),
                                  fldST10 = x["fldST10"].ToString(),
                                  fldST30 = x["fldST30"].ToString(),
                                  fldST40 = x["fldST40"].ToString(),
                                  fldST50 = x["fldST50"].ToString(),
                              }).FirstOrDefault();
                    if (!(KV == null))
                    {
                        svlist.Add(KV);
                    }
                    else
                    {
                        StdValue kv = new StdValue()
                        {
                            ItemName = item,
                            fldST10 = "空",
                            fldST30 = "空",
                            fldST40 = "空",
                            fldST50 = "空"
                        };
                        svlist.Add(kv);
                    }
                }





                foreach (var item1 in svlist)
                {
                    foreach (DataRow item2 in dt2.Rows)
                    {
                        if (!(item2["fld" + item1.ItemName] == null) && item2["fld" + item1.ItemName].ToString() != "")
                        {
                            double value1;
                            if (item2["fld" + item1.ItemName].ToString().Contains("L"))
                            {
                                value1 = double.Parse(item2["fld" + item1.ItemName].ToString().TrimEnd('L')) / 2;
                            }
                            else
                            {
                                value1 = double.Parse(item2["fld" + item1.ItemName].ToString());
                            }




                            if (item1.fldST30 == "空" || item1.fldST40 == "空" || item1.fldST50 == "空")
                            {
                                item2["fld" + item1.ItemName] = item2["fld" + item1.ItemName].ToString() + "_1";
                            }
                            else
                            {
                                double stdValue_1 = Convert.ToDouble(item1.fldST10);
                                double stdValue_3 = Convert.ToDouble(item1.fldST30);
                                double stdValue_4 = Convert.ToDouble(item1.fldST40);
                                double stdValue_5 = Convert.ToDouble(item1.fldST50);

                                if (item1.ItemName == "315")
                                {
                                    if (value1 < stdValue_3)
                                    {
                                        item2["fld" + item1.ItemName] = item2["fld" + item1.ItemName].ToString() + "_0";
                                    }
                                    else
                                    {
                                        item2["fld" + item1.ItemName] = item2["fld" + item1.ItemName].ToString() + "_1";
                                    }
                                }
                                else
                                {
                                    if (item1.ItemName == "302")
                                    {
                                        if (value1 < stdValue_1 || value1 > stdValue_4)
                                        {
                                            item2["fld" + item1.ItemName] = item2["fld" + item1.ItemName].ToString() + "_0";
                                        }
                                    }
                                    else
                                    {
                                        if (value1 <= stdValue_3)
                                        {
                                            item2["fld" + item1.ItemName] = item2["fld" + item1.ItemName].ToString() + "_1";
                                        }
                                        else if (value1 > stdValue_3 && value1 <= stdValue_4)
                                        {
                                            item2["fld" + item1.ItemName] = item2["fld" + item1.ItemName].ToString() + "_4";
                                        }
                                        else if (value1 > stdValue_4 && value1 <= stdValue_5)
                                        {
                                            item2["fld" + item1.ItemName] = item2["fld" + item1.ItemName].ToString() + "_5";
                                        }
                                        else if (value1 > stdValue_5)
                                        {
                                            item2["fld" + item1.ItemName] = item2["fld" + item1.ItemName].ToString() + "_6";
                                        }
                                        else
                                        {
                                            item2["fld" + item1.ItemName] = item2["fld" + item1.ItemName].ToString() + "_0";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }




                return dt2;

            }
            else
            {
                string colItem = null;

                if (dt.Columns.Contains("fldEdition"))
                {
                    colItem = "fldEdition";
                }
                if (dt.Columns.Contains("fldStandardNum"))
                {
                    colItem = "fldStandardNum";
                }
                var query = (from x in dt.AsEnumerable()
                             where x[colItem].ToString() == basis
                             select x).CopyToDataTable();

                // 这里是不移除的列
                string colName = "fldItemCode^";

                colName += level;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (!(colName.Contains(dt.Columns[i].ColumnName)))
                    {
                        dt.Columns.Remove(dt.Columns[i]);
                        i--;
                    }
                }

                List<string> colList = new List<string>();

                List<string> colNumber = new List<string>();

                foreach (DataColumn item in dt2.Columns)
                {
                    colList.Add(item.ColumnName);
                }
                foreach (var item in colList)
                {
                    int temp = 0;
                    if (int.TryParse(item.Substring(3, item.Length - 3), out temp))
                    {
                        colNumber.Add(temp.ToString());
                    }
                }

                List<KeyValue> kvlist = new List<KeyValue>();

                foreach (var item in colNumber)
                {
                    var KV = (from x in dt.AsEnumerable()
                              where x["fldItemCode"].ToString() == item
                              select new KeyValue
                              {
                                  Key = x["fldItemCode"].ToString(),
                                  Value = x[level].ToString()
                              }).FirstOrDefault();
                    if (!(KV == null))
                    {
                        kvlist.Add(KV);
                    }
                    else
                    {
                        KeyValue kv = new KeyValue()
                        {
                            Key = item,
                            Value = "空"
                        };
                        kvlist.Add(kv);
                    }
                }

                foreach (var item1 in kvlist)
                {
                    //不做检查的因子
                    //301 - 水温
                    if (item1.Key == "301")
                    {
                        continue;
                    }

                    foreach (DataRow item2 in dt2.Rows)
                    {
                        if (!(item2["fld" + item1.Key] == null) && item2["fld" + item1.Key].ToString() != "")
                        {
                            double value1 = 0;
                            if (item2["fld" + item1.Key].ToString().Contains("L"))
                            {
                                double val1 = double.Parse(item2["fld" + item1.Key].ToString().TrimEnd('L'));
                                val1 = Math.Abs(val1) / 2;
                                value1 = val1;
                            }
                            else
                            {
                                value1 = double.Parse(item2["fld" + item1.Key].ToString());
                            }

                            if (item1.Value == "空")
                            {
                                item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_1";
                            }
                            else
                            {
                                double stdValue = Convert.ToDouble(item1.Value);

                                //315 - 溶解氧
                                //302 - pH
                                if (item1.Key == "302")
                                {
                                    if (value1 > stdValue || value1 < 6)
                                    {
                                        item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_0";
                                    }
                                    else
                                    {
                                        item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_1";
                                    }
                                }
                                else if (item1.Key == "315")
                                {
                                    if (value1 < stdValue)
                                    {
                                        item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_0";
                                    }
                                    else
                                    {
                                        item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_1";
                                    }
                                }
                                else
                                {
                                    if (value1 > stdValue)
                                    {
                                        item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_0";
                                    }
                                    else
                                    {
                                        item2["fld" + item1.Key] = item2["fld" + item1.Key].ToString() + "_1";
                                    }
                                }
                            }
                        }
                    }
                }
                return dt2;
            }
        }


        /// <summary>
        /// 超标依据级别枚举
        /// </summary>
        [Flags]
        private enum LevelEnum
        {
            [Description("一级")]
            fldST10 = 1,

            [Description("二级")]
            fldST20 = 2,

            [Description("三级")]
            fldST30 = 3,

            [Description("四级")]
            fldST40 = 4,

            [Description("五级")]
            fldST50 = 5,

            [Description("小时一级")]
            fldHourSTG1 = 6,

            [Description("小时二级")]
            fldHourSTG2 = 7,

            [Description("小时三级")]
            fldHourSTG3 = 8,

            [Description("日一级")]
            fldDaySTG1 = 9,

            [Description("日二级")]
            fldDaySTG2 = 10,

            [Description("日三级")]
            fldDaySTG3 = 11,

            [Description("年一级")]
            fldYearSTG1 = 12,

            [Description("年二级")]
            fldYearSTG2 = 13,

            [Description("年三级")]
            fldYearSTG3 = 14,

            [Description("二一级")]
            fldST21 = 15,

            [Description("二二级")]
            fldST22 = 16,

            [Description("二三级")]
            fldST23 = 17,

            [Description("一级")]
            fldST = 18,
        }



        /// <summary>
        /// 超标依据级别枚举
        /// </summary>
        [Flags]
        private enum LevelEnum_eqiw_r
        {
            [Description("Ⅰ类")]
            fldST10 = 1,

            [Description("Ⅱ类")]
            fldST20 = 2,

            [Description("Ⅲ类")]
            fldST30 = 3,

            [Description("Ⅳ类")]
            fldST40 = 4,

            [Description("劣Ⅴ类")]
            fldST50 = 5,

            [Description("Ⅰ类")]
            fldST = 6,
        }


        /// <summary>
        /// 获取一个枚举值的中文描述
        /// </summary>
        /// <param name="obj">枚举值</param>
        /// <returns></returns>
        private static string GetEnumDescription(Enum obj)
        {
            FieldInfo fi = obj.GetType().GetField(obj.ToString());
            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return arrDesc[0].Description;
        }


        /// <summary>
        /// 要转换成Json字符串的实体
        /// 备注：此实体在类中，不在命名空间中，用于VerificationController控制器访问
        /// </summary>
        private class JsonEntity
        {
            /// <summary>
            /// 标准值集合
            /// </summary>
            public List<KeyValue> StandardList { get; set; }

            /// <summary>
            /// 级别集合
            /// </summary>
            public List<KeyValue> LevelList { get; set; }
        }


        /// <summary>
        /// 要转换特定的Json字符串
        /// </summary>
        private class ReturnJson
        {
            /// <summary>
            /// 主体数据
            /// </summary>
            public DataTable Data { get; set; }

            /// <summary>
            /// 列中文名称列表
            /// </summary>
            public List<string> Head { get; set; }


            public DataTable dataTable { get; set; }
        }


        /// <summary>
        /// 健-值实体
        /// 备注：此实体在类中，不在命名空间中，用于VerificationController控制器访问
        /// </summary>
        private class KeyValue
        {
            /// <summary>
            /// 健 - 标准表中标准的字段名称
            /// </summary>
            public string Key { get; set; }

            /// <summary>
            /// 值 - 标准表中标准的字段的值
            /// </summary>
            public string Value { get; set; }

            /// <summary>
            /// 断面名称
            /// </summary>
            public string SectionName { get; set; }

        }



        public class StdValue
        {
            public string ItemName { get; set; }

            public string fldST10 { get; set; }

            public string fldST30 { get; set; }

            public string fldST40 { get; set; }

            public string fldST50 { get; set; }
        }





        private Decimal ChangeDataToD(string strData)
        {
            Decimal dData = 0.0M;
            if (strData.Contains("E"))
            {
                dData = Convert.ToDecimal(Decimal.Parse(strData.ToString(), System.Globalization.NumberStyles.Float));
            }
            else
            {
                dData = Convert.ToDecimal(Decimal.Parse(strData.ToString(), System.Globalization.NumberStyles.Float));
            }
            return dData;
        }



    }
}

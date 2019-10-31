using System;
using System.Net.Http;
using System.Web.Http;
using DDYZ.Ensis.Rule.DataRule;
using System.Data;

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace EMCCommon.Common
{
    /// <summary>
    /// 查询测点或者点位
    /// 周文卿
    /// </summary>
    public class PointAllController : ApiController
    {
        string strLocalpath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/PiontField.json");//配置的json文件地址

        string GetPointMetaDataPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/GetPointMetaData.json");

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获得点位或者断面
        /// 创建  人：周文卿
        /// 创建时间：2017/06/06
        /// 修改时间：
        /// 修改原因：
        /// 修改  人：
        /// </summary>
        /// <param name="model">业务类别</param>
        /// <param name="userid">用户ID（为空时查找useID=-1）</param>
        /// <param name="cityID">城市ID</param>
        /// <param name="year">年份</param>
        /// <param name="where">筛选条件</param>
        /// <param name="screenflied">筛选字段</param>
        /// <param name="DName">字典名称</param>
        /// <returns></returns>
        //[SupportFilter]
        [HttpGet]
        public HttpResponseMessage GetPiont(string model, string userid, string cityID, string year, string where, string screenflied, string DName)
        {
            string returntxt = "";
            try
            {
                string getjson = rule.GetJson(strLocalpath);
                JArray jsonObj = JArray.Parse(getjson);
                userid = userid == "" ? "" : userid;
                string citysql = "";
                JArray js = new JArray();
                js.Add("[{stcode:0, label: '全部',children:[]}]");
                DataTable dt1 = rule.getdt("select fldAutoID,fldObject,fldName,fldUserID,fldPointContent from tblEQI_Point_Group where fldObject='" + model + "' and fldUserID=" + userid);
                string resposne = JsonHelper.SerializeObject(dt1);
                string json = "[{stcode:0, label: '全部',children:[";
                for (int i = 0; i < jsonObj.Count; i++)
                {
                    string typemodel = jsonObj[i]["type"].ToString();
                    if (typemodel == model)
                    {
                        if (cityID == "2")
                        {
                            citysql = "select distinct fldSTCode,fldSTName from " + jsonObj[i]["table"] + " where fldYear=" + year;
                        }
                        else
                        {
                            RuletblFW_RegCity city = new RuletblFW_RegCity();
                            string citycode = city.ByPK(int.Parse(cityID)).fldSTCode.ToString().Substring(0, 4);
                            citysql = "select distinct fldSTCode,fldSTName from " + jsonObj[i]["table"] + " where fldYear=" + year + " and fldSTCode like '%" + citycode + "%'";
                        }
                        DataTable dt = rule.getdt(citysql);
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (j == dt.Rows.Count - 1)
                            {
                                json += "{stcode:'" + dt.Rows[j]["fldSTCode"].ToString() + "'" + ",label:'" + dt.Rows[j]["fldSTName"].ToString() +
                                         "',children:" + GetTwoLevel(dt.Rows[j]["fldSTCode"].ToString(), jsonObj[i]["table"].ToString(),
                                              jsonObj[i]["twofield"].ToString(), jsonObj[i]["level"].ToString(),
                                              year, jsonObj[i]["threefield"].ToString(), jsonObj[i]["istranslate"].ToString(),
                                              jsonObj[i]["rerurnpiont"].ToString(), where, screenflied, DName, jsonObj[i]["pionttype"].ToString()) + "}]}]";
                            }
                            else
                            {
                                json += "{stcode:'" + dt.Rows[j]["fldSTCode"].ToString() + "'" + ",label:'" + dt.Rows[j]["fldSTName"].ToString() +
                                          "',children:" + GetTwoLevel(dt.Rows[j]["fldSTCode"].ToString(), jsonObj[i]["table"].ToString(),
                                              jsonObj[i]["twofield"].ToString(), jsonObj[i]["level"].ToString(),
                                              year, jsonObj[i]["threefield"].ToString(), jsonObj[i]["istranslate"].ToString(),
                                              jsonObj[i]["rerurnpiont"].ToString(), where, screenflied, DName, jsonObj[i]["pionttype"].ToString()) + "},";
                            }
                        }
                    }
                }
                returntxt = rule.JsonStr("ok", "", json + "|" + resposne);
            }
            catch (Exception e)
            {
                returntxt = rule.JsonStr("ok", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：获得二级节点
        /// 创建  人：周文卿
        /// 创建时间：2017/06/06
        /// 修改时间：
        /// 修改  人：
        /// 修改原因：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="table">表名称</param>
        /// <param name="field">二级字段名称</param>
        /// <param name="level">几级节点</param>
        /// <param name="year">年份</param>
        /// <param name="threefield">三级节点</param>
        /// <param name="istranslate">是否需要翻译</param>
        /// <param name="returnpoint">最后得到的点位是几级（2=fldSTCode.fldPCode,3=fldSTCode.fldRCode.fldRSCode）</param>
        /// <param name="where">筛选条件</param>
        /// <param name="screenflied">筛选字段</param>
        /// <param name="DName">字典名称</param> 
        /// <param name="pionttype">返回的点位类型（第一级为（0是城市代码，1是区县代码））</param> 
        /// <returns></returns>
        private string GetTwoLevel(string stcode, string table, string field, string level, string year, string threefield, string istranslate, string returnpoint, string where, string screenflied, string DName, string pionttype)
        {
            try
            {
                string sqlyear = year == null ? DateTime.Now.Year.ToString() : year;
                string dname = DName == null ? "测点级别" : DName;
                field = screenflied == null ? field : screenflied;
                DataTable dt = rule.getdt("select distinct " + field + " from " + table + " where fldSTCode =" + stcode + "  and  fldYear=" + sqlyear + where);
                string label = "";
                string json = "[";
                RuletblDictionary dic = new RuletblDictionary();
                if (int.Parse(level) > 2)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (istranslate == "0")
                            {
                                label = dic.ByParentIDAndValue(dname, dt.Rows[i][field.Split(',')[0].ToString()].ToString());
                            }
                            else
                            {
                                label = dt.Rows[i][field.Split(',')[1].ToString()].ToString();
                            }

                            if (i == dt.Rows.Count - 1)
                            {
                                json += "{stcode:'" + stcode + "." + dt.Rows[i][field.Split(',')[0].ToString()].ToString() + "',label:'" + label +
                                    "',children:" + GetThreeLevel(stcode, table, threefield, sqlyear,
                                                    field, dt.Rows[i][field.Split(',')[0].ToString()].ToString(), returnpoint, pionttype,
                                                    dt.Rows[i][field.Split(',')[2].ToString()].ToString()) + "}]";
                            }
                            else
                            {
                                json += "{stcode:'" + stcode + "." + dt.Rows[i][field.Split(',')[0].ToString()].ToString() + "',label:'" + label +
                                    "',children:" + GetThreeLevel(stcode, table, threefield, sqlyear,
                                                    field, dt.Rows[i][field.Split(',')[0].ToString()].ToString(), returnpoint, pionttype,
                                                    dt.Rows[i][field.Split(',')[2].ToString()].ToString()) + "},";
                            }
                        }
                    }
                    else
                    {
                        json += "{stcode:'8',label:'无数据'}]";
                    }
                }
                #region 只有两级节点
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (istranslate == "0")
                            {
                                label = dic.ByParentIDAndValue("测点级别", dt.Rows[i][field.Split(',')[0].ToString()].ToString());
                            }
                            else
                            {
                                label = dt.Rows[i][field.Split(',')[1].ToString()].ToString();
                            }
                            if (i == dt.Rows.Count - 1)
                            {
                                json += "{stcode:'" + stcode + "." + dt.Rows[i][field.Split(',')[0].ToString()].ToString() + "',label:'" + label + "'}]";
                            }
                            else
                            {
                                json += "{stcode:'" + stcode + "." + dt.Rows[i][field.Split(',')[0].ToString()].ToString() + "',label:'" + label + "'},";
                            }
                        }
                    }
                    else
                    {
                        json += "{stcode:'8',label:'其他'}]";
                    }
                }
                #endregion
                return json;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// 功能描述：获得三级节点
        /// 创建  人：周文卿
        /// 创建时间：2017/06/06
        /// 修改时间：
        /// 修改  人：
        /// 修改原因：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="table">表格</param>
        /// <param name="threefield">三级字段</param>
        /// <param name="year">年份</param>
        /// <param name="twofield">二级字段</param>
        /// <param name="twovalue">二级字段的值</param>
        /// <param name="pionttype">返回测点的类型（0是城市点位--1是区县点位）</param>
        /// <param name="returnpoint">最后得到的点位是几级（2=fldSTCode.fldPCode,3=fldSTCode.fldRCode.fldRSCode）</param>
        /// <param name="countycode">区县代码</param>
        /// <returns></returns>
        private string GetThreeLevel(string stcode, string table, string threefield, string year, string twofield, string twovalue, string returnpoint, string pionttype, string countycode)
        {
            try
            {
                string json = "[";
                DataTable dt = rule.getdt("select distinct " + threefield + " from " + table + " where fldSTCode =" + stcode + " and fldYear=" + year + " and " + twofield.Split(',')[0] + "='" + twovalue + "'");
                if (returnpoint == "2")//返回的为两级点位
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (i == dt.Rows.Count - 1)
                            {
                                if (pionttype == "1")
                                {
                                    json += "{point:'" + twovalue + "." + dt.Rows[i][threefield.Split(',')[0]].ToString() + "',label:'" + dt.Rows[i][threefield.Split(',')[1]].ToString() + "'}]";
                                }
                                else
                                {
                                    json += "{point:'" + stcode + "." + dt.Rows[i][threefield.Split(',')[0]].ToString() + "',label:'" + dt.Rows[i][threefield.Split(',')[1]].ToString() + "'}]";
                                }
                            }
                            else
                            {
                                if (pionttype == "1")
                                {
                                    json += "{point:'" + twovalue + "." + dt.Rows[i][threefield.Split(',')[0]].ToString() + "',label:'" + dt.Rows[i][threefield.Split(',')[1]].ToString() + "'},";
                                }
                                else
                                {
                                    json += "{point:'" + stcode + "." + dt.Rows[i][threefield.Split(',')[0]].ToString() + "',label:'" + dt.Rows[i][threefield.Split(',')[1]].ToString() + "'},";
                                }
                            }
                        }
                    }
                    else
                    {
                        json += "{}]";
                    }
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (pionttype == "1")//返回区县+
                            {
                                if (i == dt.Rows.Count - 1)
                                {
                                    json += "{point:'" + countycode + "." + twovalue + "." + dt.Rows[i][threefield.Split(',')[0]].ToString() + "',label:'" + dt.Rows[i][threefield.Split(',')[1]].ToString() + "'}]";
                                }
                                else
                                {
                                    json += "{point:'" + countycode + "." + twovalue + "." + dt.Rows[i][threefield.Split(',')[0]].ToString() + "',label:'" + dt.Rows[i][threefield.Split(',')[1]].ToString() + "'},";
                                }
                            }
                            else
                            {
                                if (i == dt.Rows.Count - 1)
                                {
                                    json += "{point:'" + stcode + "." + twovalue + "." + dt.Rows[i][threefield.Split(',')[0]].ToString() + "',label:'" + dt.Rows[i][threefield.Split(',')[1]].ToString() + "'}]";
                                }
                                else
                                {
                                    json += "{point:'" + stcode + "." + twovalue + "." + dt.Rows[i][threefield.Split(',')[0]].ToString() + "',label:'" + dt.Rows[i][threefield.Split(',')[1]].ToString() + "'},";
                                }
                            }
                        }
                    }
                    else
                    {
                        json += "{}]";
                    }
                }
                return json;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }



















        /// <summary>
        /// 功能描述：获得点位或者断面 V2版本
        /// 创建  人：吕荣誉
        /// 创建时间：2017-8-31
        /// 修改时间：
        /// 修改原因：
        /// 修改  人：
        /// </summary>
        /// <returns></returns>
        //[SupportFilter]
        [HttpPost]
        public HttpResponseMessage GetPiont_V2(Info info)
        {
            string returntxt = "";
            try
            {
                string getjson = rule.GetJson(GetPointMetaDataPath);

                List<JsonEntity> jsonObj = JsonConvert.DeserializeObject<List<JsonEntity>>(getjson);

                var query = (from x in jsonObj
                             where x.type == info.type
                             select x).FirstOrDefault();

                if (info.Levels != null)
                {
                    foreach (var item in info.Levels)
                    {


                        var query2 = (from x in query.Levels
                                      where x.ID == item.ID
                                      select x).FirstOrDefault();
                        if (query2 != null)
                        {


                            if (item.where.Contains("-1"))
                            {
                                var query4 = (from x in query.Levels
                                              where x.ID == item.ID
                                              select x).FirstOrDefault();

                                Level temp = new Level();
                                temp = query4;

                                query.Levels.Remove(query4);

                                temp.Source = item.Source;
                                temp.value = item.value;
                                temp.pointformat = item.pointformat;


                                query.Levels.Add(temp);

                            }
                            else
                            {
                                query.Levels.Remove(query2);


                                query.Levels.Add(item);

                            }





                            int id = int.Parse(item.ID) + 1;
                            var query3 = (from x in query.Levels
                                          where x.ID == id.ToString()
                                          select x).FirstOrDefault();
                            if (query3 != null)
                            {

                                query3.where = item.Source.Split(',')[0];
                                Level temp = new Level();
                                temp = query3;

                                query.Levels.Remove(query3);

                                query.Levels.Add(temp);

                            }




                        }



                    }
                }



                string citysql = null;
                if (info.cityID == "2")
                {
                    if (info.type == "eqiw_sts_cq")
                        citysql = "select * from " + query.PointTableName + " where YEAR(fldDate)  in (" + info.year + ") order by fldTaskName";
                    else
                        citysql = "select * from " + query.PointTableName + " where fldYear in (" + info.year + ") order by fldSTCode";
                }
                else
                {
                    if (info.type == "eqiw_sts_cq")
                    {
                        RuletblFW_RegCity city = new RuletblFW_RegCity();
                        string fldSTName = city.ByPK(int.Parse(info.cityID)).fldSTName;
                        citysql = "select * from " + query.PointTableName + " where YEAR(fldDate)  in (" + info.year + ") and fldSTName like '%" + fldSTName + "%'" + " order by fldTaskName";
                    }
                    else
                    {
                        RuletblFW_RegCity city = new RuletblFW_RegCity();
                        string citycode = city.ByPK(int.Parse(info.cityID)).fldSTCode.ToString().Substring(0, 4);
                        citysql = "select * from " + query.PointTableName + " where fldYear in (" + info.year + ") and fldSTCode like '%" + citycode + "%'" + " order by fldSTCode";
                    }

                }


                DataTable dtSource = rule.SqlQueryForDataTatable("EntityContext", citysql);


                List<Return> result = new List<Return>();


                Return result1 = new Return();
                result1.stcode = "-1";
                result1.label = "全部";
                result1.point = "-1";

                List<Return> result2 = new List<Return>();
                DataTable dt1 = null;
                // 查询一级条件
                var Level1 = (from x in query.Levels
                              where x.ID == "1"
                              select x).FirstOrDefault();
                // 获取一级数据，并赋值
                List<Return> tempList = GetList(dtSource, Level1, null, out dt1);
                result1.children = tempList;


                if (result1.children != null)
                {

                    foreach (var item1 in result1.children)
                    {

                        DataTable dt2 = null;
                        Level Level2 = null;
                        // 查询二级条件
                        Level2 = (from x in query.Levels
                                  where x.ID == "2"
                                  select x).FirstOrDefault();


                        if (Level2 != null)
                        {

                            tempList = GetList(dt1, Level2, item1, out dt2);
                            item1.children = tempList;


                            if (item1.children != null)
                            {

                                foreach (var item2 in item1.children)
                                {

                                    DataTable dt3 = null;
                                    Level Level3 = null;
                                    // 查询三级条件
                                    Level3 = (from x in query.Levels
                                              where x.ID == "3"
                                              select x).FirstOrDefault();

                                    if (Level3 != null)
                                    {
                                        tempList = GetList(dt2, Level3, item2, out dt3);
                                        item2.children = tempList;

                                        if (item2.children != null)
                                        {
                                            foreach (var item3 in item2.children)
                                            {
                                                DataTable dt4 = null;
                                                Level Level4 = null;
                                                // 查询四级条件
                                                Level4 = (from x in query.Levels
                                                          where x.ID == "4"
                                                          select x).FirstOrDefault();

                                                if (Level4 != null)
                                                {
                                                    tempList = GetList(dt3, Level4, item3, out dt4);
                                                    item3.children = tempList;
                                                }
                                            }


                                        }

                                    }
                                }


                            }

                        }
                    }

                }


                DataTable dt = rule.getdt("select fldAutoID,fldObject,fldName,fldUserID,fldPointContent from tblEQI_Point_Group where fldObject='" + info.type + "' and fldUserID=" + info.userID);

                result.Add(result1);



                List<object> output = new List<object>();
                output.Add(result);
                output.Add(dt);

                returntxt = rule.JsonStr("ok", "", output);

            }
            catch (Exception e)
            {
                returntxt = rule.JsonStr("no", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
        }





        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dtSource">数据源，输出的dt也可以作为数据源</param>
        /// <param name="item">节点对象</param>
        /// <param name="result">接收输出实体</param>
        /// <param name="dt">输出dt作为下一节点的数据源</param>
        /// <returns>返回输出实体的集合</returns>
        private List<Return> GetList(DataTable dtSource, Level item, Return result, out DataTable dt)
        {
            List<Return> tempList = new List<Return>();


            if (result != null)
            {
                string[] where = item.where.Split(',');

                if (where.Length == 2)
                {
                    DataRow[] dr = dtSource.Select(where[0] + "='" + result.id + "' and " + where[1].Split('=')[0] + "='" + where[1].Split('=')[1] + "'");
                    if (dr.Count() > 0)
                    {
                        dtSource = dr.CopyToDataTable();
                    }
                    else
                    {
                        dt = null;
                        return null;
                    }
                }
                else
                {
                    dtSource = dtSource.Select(item.where + "='" + result.id + "'").CopyToDataTable();
                }

            }

            dt = dtSource;

            DataView dv = new DataView(dtSource);

            DataTable dtTemp = dv.ToTable(true, item.Source.Split(','));

            foreach (DataRow item1 in dtTemp.Rows)
            {
                Return temp = new Return();

                temp.id = item1[item.Source.Split(',')[0]].ToString();

                if (item.pointformat != null)
                {
                    string stcode = null;

                    string[] pointformat = item.pointformat.Split('.');

                    foreach (var item2 in pointformat)
                    {
                        var query = (from x in dtSource.AsEnumerable()
                                     where x[item.Source.Split(',')[0]].ToString() == temp.id
                                     select x[item2].ToString()).FirstOrDefault();
                        stcode += query + ".";
                    }

                    temp.stcode = stcode.TrimEnd('.');
                }
                else
                {
                    temp.stcode = item1[item.Source.Split(',')[0]].ToString();
                }


                if (item.value != null)
                {
                    string[] convert = item.value.Split(',');

                    foreach (var item2 in convert)
                    {
                        if (item1[item.Source.Split(',')[0]].ToString() == item2.Split('=')[0])
                        {
                            temp.label = item2.Split('=')[1];
                        }
                    }
                }
                else
                {
                    if (item.Source.Contains(','))
                    {
                        temp.label = item1[item.Source.Split(',')[1]].ToString();
                    }
                    else
                    {
                        temp.label = item1[item.Source.Split(',')[0]].ToString();
                    }
                }

                temp.point = "";

                if (item.endPoint == true)
                {
                    temp.point = temp.stcode;
                }

                tempList.Add(temp);
            }
            return tempList;
        }




        /// <summary>
        /// 接收参数的实体
        /// </summary>
        public class Info
        {
            /// <summary>
            /// 业务类型
            /// </summary>
            public string type { get; set; }


            /// <summary>
            /// 用户ID
            /// </summary>
            public string userID { get; set; }


            /// <summary>
            /// 城市ID
            /// </summary>
            public string cityID { get; set; }


            /// <summary>
            /// 年份
            /// </summary>
            public string year { get; set; }

            /// <summary>
            /// 条件
            /// </summary>
            public string where { get; set; }

            /// <summary>
            /// 筛选字段
            /// </summary>
            public string screenflied { get; set; }


            /// <summary>
            /// 字典名称
            /// </summary>
            public string DName { get; set; }


            /// <summary>
            /// 根据传入的级别来替换配置
            /// </summary>
            public List<Level> Levels { get; set; }

        }



        /// <summary>
        /// 读取json配置文件，转换为实体
        /// </summary>
        public class JsonEntity
        {
            public string type { get; set; }

            public string PointTableName { get; set; }

            public List<Level> Levels { get; set; }
        }

        public class Level
        {
            /// <summary>
            /// 节点层次ID，值为1-4
            /// </summary>
            public string ID { get; set; }

            public string Source { get; set; }

            public string where { get; set; }

            public string value { get; set; }

            /// <summary>
            /// 输出点位格式，例子：fldSTCode.fldPCode
            /// </summary>
            public string pointformat { get; set; }

            /// <summary>
            /// 是否是最后一层节点
            /// </summary>
            public bool endPoint { get; set; }
        }





        /// <summary>
        /// 输出实体
        /// </summary>
        public class Return
        {
            /// <summary>
            /// 在节点层级中作为下一层级的条件ID
            /// </summary>
            public string id { get; set; }

            /// <summary>
            /// 作为节点级别的输出格式
            /// </summary>
            public string stcode { get; set; }

            /// <summary>
            /// 如果节点中最后一级endPoint配置为true
            /// 那么将point代替label
            /// </summary>
            public string point { get; set; }

            /// <summary>
            /// 非最后一级节点的名称输出参数
            /// </summary>
            public string label { get; set; }

            /// <summary>
            /// 子节点集合
            /// </summary>
            public List<Return> children { get; set; }
        }




    }
}

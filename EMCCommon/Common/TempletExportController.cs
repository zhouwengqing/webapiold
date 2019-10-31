using DDYZ.Ensis.Rule.DataRule;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace EMCCommon.Common
{
    /// <summary>
    /// 功能描述：数据模板导出统一API
    /// 创建者  ：吕荣誉
    /// 创建日期：2017-7-17
    /// 修改者  ：
    /// 修改日期：
    /// 修改原因：
    /// API说明 ：
    /// </summary>
    public class TempletExportController : ApiController
    {
        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获取数据模板导出列表
        /// 创建者  ：吕荣誉
        /// 创建日期：2017-7-17
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// API说明 ：
        /// 大气监测-fldPoint_Type = "1"
        /// 降尘监测-fldPoint_Type = "2"
        /// 降水监测-fldPoint_Type = "3"
        /// 地表水监测-fldPoint_Type="4","5"
        /// 湖库监测-fldPoint_Type = "7"
        /// 地表饮用水监测-fldPoint_Type = "6"
        /// 区域噪声监测-fldPoint_Type = "8"
        /// 功能区噪声监测-fldPoint_Type = "9"
        /// 道路交通噪声监测-fldPoint_Type = "10"
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <param name="path">json路径</param>
        /// <returns></returns>
        [HttpGet]
        //[SupportFilter]
        public HttpResponseMessage GetTempletExportList(string type, string path, string cityid = "2")
        {
            string result = string.Empty;
            try
            {
                path = HttpUtility.UrlDecode(path);

                string getjson = rule.GetJson(path);

                JArray jsonObj = JArray.Parse(getjson);

                var tablename = (from x in jsonObj
                                 where x["type"].ToString() == type
                                 select x).FirstOrDefault();

                JArray jsonObj2 = JArray.Parse(tablename["TempletInfo"].ToString());

                var TempletInfo = (from x in jsonObj2
                                   select x).DefaultIfEmpty().ToList();





                //if (cityid != "2")
                //{
                //    TempletInfo = (from x in TempletInfo
                //                   where x["fldTableDesc"].ToString() == "重庆市区县控断面上报表" ||
                //                   x["fldTableDesc"].ToString() == "水质自动站建设进度上报模板" ||
                //                   x["fldTableDesc"].ToString() == "重庆市国控、市控、水华综合表"
                //                   select x).ToList();
                //}





                if (TempletInfo != null)
                {
                    result = rule.JsonStr("ok", "", TempletInfo);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：获取数据模板导出信息
        /// 创建者  ：吕荣誉
        /// 创建日期：2017-7-17
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="tbl">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage GetTempletExportInfo(List<tbcode> tbl)
        {
            string result = string.Empty;
            try
            {
                //string TempletExportSetting = HostingEnvironment.MapPath(@"~/App_Data/Config/TempletExportSetting/" + tbl[0].type + ".json");

                string path = HttpUtility.UrlDecode(tbl[0].path);


                string getjson2 = rule.GetJson(path);

                JArray jsonObj2 = JArray.Parse(getjson2);

                var ItemSetting = (from x in jsonObj2
                                   where x["type"].ToString() == tbl[0].type
                                   select x).FirstOrDefault();

                JArray TempletInfo = JArray.Parse(ItemSetting["TempletInfo"].ToString());

                var TempletInfoQueryResult = (from x in TempletInfo
                                              where x["fldAutoID"].ToString() == tbl[0].fldAutoID
                                              select x).FirstOrDefault();

                string pcodeList = null;

                string[] PointFormat = ItemSetting["PointFormat"].ToString().Split('^');

                foreach (var item in tbl)
                {
                    pcodeList += "'" + DateTime.Now.Year.ToString();
                    foreach (var item1 in PointFormat)
                    {
                        if (item1 == "fldSTCode")
                        {
                            pcodeList += "-" + item.fldSTCode;
                        }
                        else if (item1 == "fldRCode")
                        {
                            pcodeList += "-" + item.fldRCode;
                        }
                        else if (item1 == "fldRSCode")
                        {
                            pcodeList += "-" + item.fldRSCode;
                        }
                        else if (item1 == "fldPCode")
                        {
                            pcodeList += "-" + item.fldPCode;
                        }
                        else if (item1 == "fldGDCODE")
                        {
                            pcodeList += "-" + item.fldGDCODE;
                        }
                        else if (item1 == "fldRDCode")
                        {
                            pcodeList += "-" + item.fldGDCODE;
                        }
                    }
                    pcodeList += "',";
                }

                pcodeList = pcodeList.TrimEnd(',');

                string sql = null;

                DataTable dt = new DataTable();

                string meg = "";

                if (TempletInfoQueryResult["ItemList"].ToString() == "")
                {

                    sql = "select distinct " + TempletInfoQueryResult["Sqlselect"].ToString();

                    meg = TempletInfoQueryResult["merge"].ToString();

                    sql += " from " + ItemSetting["PointTableName"].ToString();

                    sql += " where " + ItemSetting["Sqlwhere"].ToString().Replace("@pcode", pcodeList);

                    dt = rule.SqlQueryForDataTatable("EntityContext", sql);

                    if (tbl[0].itemcodeList != "" && tbl[0].itemcodeList != null)
                    {
                        string[] ItemList = tbl[0].itemcodeList.Split('^');

                        foreach (var item in ItemList)
                        {
                            dt.Columns.Add(item, typeof(string));
                        }
                    }
                }
                else
                {
                    meg = TempletInfoQueryResult["merge"].ToString();

                    JArray itemList = JArray.Parse(TempletInfoQueryResult["ItemList"].ToString());

                    sql = "select distinct " + TempletInfoQueryResult["Sqlselect"].ToString();

                    sql += " from " + ItemSetting["PointTableName"].ToString();

                    sql += " where " + ItemSetting["Sqlwhere"].ToString().Replace("@pcode", pcodeList);

                    dt = rule.SqlQueryForDataTatable("EntityContext", sql);

                    foreach (string item in itemList)
                    {
                        dt.Columns.Add(item, typeof(string));
                    }
                }




                string head = "[";

                foreach (DataColumn item in dt.Columns)
                {
                    head += "'" + item.ColumnName + "',";
                }

                head = head.TrimEnd(',');

                head += "]";

                string json = "[{data:" + JsonHelper.SerializeObject(dt) + ",head:" + head + ",merg:" + meg + "}]";

                if (dt.Rows.Count > 0)
                {
                    result = rule.JsonStr("ok", "", json);
                }
                else
                {
                    if (tbl[0].IsNeedNullData == "Y")
                    {
                        result = rule.JsonStr("ok", "", json);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "无数据", "");
                    }
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 点位的实体类
        /// </summary>
        public class tbcode
        {
            /// <summary>
            /// 业务类别
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// id
            /// </summary>
            public string fldAutoID { get; set; }

            /// <summary>
            /// 因子列表
            /// </summary>
            public string itemcodeList { get; set; }

            /// <summary>
            /// 城市代码
            /// </summary>
            public string fldSTCode { get; set; }

            /// <summary>
            /// 测点代码
            /// </summary>
            public string fldPCode { get; set; }

            /// <summary>
            /// 河流代码
            /// </summary>
            public string fldRCode { get; set; }

            /// <summary>
            /// 断面代码
            /// </summary>
            public string fldRSCode { get; set; }


            /// <summary>
            /// 
            /// </summary>
            public string fldGDCODE { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldRDCode { get; set; }


            public string path { get; set; }


            /// <summary>
            /// 是否需要空数据
            /// “Y”
            /// </summary>
            public string IsNeedNullData { get; set; }

        }
    }
}

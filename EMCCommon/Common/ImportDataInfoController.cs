using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.EMCCommon.AccountController.WebApiCore;
using EMCCommon.Mode;
using EMCCommon.Mode.重金属;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace EMCCommon.Common
{
    /// <summary>
    /// 功能描述：固定格式导入统一API
    /// 创建者  ：吕荣誉
    /// 创建日期：2017-7-24
    /// 修改者  ：
    /// 修改日期：
    /// 修改原因：
    /// API说明 ：
    /// </summary>
    public class ImportDataInfoController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        LAPContext LapContext = new LAPContext();

        string TypeBaseDataPath = HostingEnvironment.MapPath(@"~/App_Data/Config/TypeBaseData.json");

        /// <summary>
        /// 获取上报设置列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SupportFilter]
        public HttpResponseMessage GetSetupList()
        {
            string result = string.Empty;
            try
            {
                List<To_Setup> list = new List<To_Setup>();

                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.To_Setup
                            select x).ToList();
                }

                if (list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据！", list);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        /// 功能描述：获取导入日志
        /// 创建者  ：徐雍文
        /// 创建日期：2018-6-4
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="modeltype"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GeteqiDatalog(string modeltype)
        {
            string result = string.Empty;
            try
            {
                DataTable dt = rule.getdt("select * from vwDT_Dn_ImportDataLog where fldModeltype='" + modeltype + "' order by fldDn_date desc");
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 新增或者更新上报设置数据
        /// </summary>
        /// <param name="tos">To_Setup实体列表</param>
        /// <returns></returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage AddOrUpdateSetup(AddOrUpdateSetup_Info info)
        {
            string result = string.Empty;
            int num = 0;
            try
            {
                using (EntityContext db_E = new EntityContext())
                {
                    db_E.To_Setup.AddOrUpdate(info.tos.ToArray());

                    if (info.fldUserID != 0)
                    {
                        using (Lap.Model.LAPContext db = new Lap.Model.LAPContext())
                        {
                            Lap.Model.tblFW_Log log = new Lap.Model.tblFW_Log();

                            log.fldModalName = "新增或更新上报设置";

                            log.fldUserID = info.fldUserID;
                            log.fldCityID = info.fldCityID;

                            string fldContent = "";


                            foreach (var item in info.tos)
                            {
                                if (item.fldAutoID == 0)
                                {
                                    fldContent += "增加了表：" + item.fldTableName;
                                }
                                else
                                {
                                    var temp = db_E.To_Setup.Find(item.fldAutoID);

                                    fldContent += "ID为" + temp.fldAutoID + "的断面数据由用户" + info.fldUserID + "变更为：";

                                    if (temp.fldTableName != item.fldTableName)
                                    {
                                        fldContent += "【表名称：" + temp.fldTableName + "→" + item.fldTableName + "】；";
                                    }
                                    if (temp.fldStartDate != item.fldStartDate)
                                    {
                                        fldContent += "【开始时间：" + temp.fldStartDate + "→" + item.fldStartDate + "】；";
                                    }
                                    if (temp.fldEndDate != item.fldEndDate)
                                    {
                                        fldContent += "【结束时间：" + temp.fldEndDate + "→" + item.fldEndDate + "】；";
                                    }


                                }
                            }







                            log.fldContent = fldContent;






                            log.fldDate_operate = DateTime.Now;

                            if (info.fldIPAddress == null || info.fldIPAddress == "")
                            {
                                log.fldIPAddress = GetIP();
                            }
                            else
                            {
                                log.fldIPAddress = info.fldIPAddress;
                            }

                            db.tblFW_Log.Add(log);
                            db.SaveChanges();
                        }
                    }






                    num = db_E.SaveChanges();
                }



                if (num > 0)
                {
                    result = rule.JsonStr("ok", "新增或者更新成功！", num);
                }
                else
                {
                    result = rule.JsonStr("no", "失败！", num);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }





        public class AddOrUpdateSetup_Info
        {
            public int fldUserID { get; set; }

            public int fldCityID { get; set; }

            public string fldIPAddress { get; set; }


            public List<To_Setup> tos { get; set; }
        }


        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(result))
            {
                return "0.0.0.0";
            }
            return result;
        }









        /// <summary>
        /// 功能描述：获取固定格式导入列表
        /// 创建者  ：吕荣誉
        /// 创建日期：2017-7-24
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// API说明 ：
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <param name="path"></param>
        /// <param name="cityid"></param>
        /// <returns>返回表集合的Json数据</returns>
        [HttpGet]
        //[SupportFilter]
        public HttpResponseMessage GetImportDataList(string type, string path, string cityid)
        {
            string result = string.Empty;
            try
            {
                //string ImportDataInfoSetting = HostingEnvironment.MapPath(@"~/App_Data/Config/ImportDataInfoSetting/" + type + ".json");
                path = HttpUtility.UrlDecode(path);
                string getjson = rule.GetJson(path);

                JArray jsonObj = JArray.Parse(getjson);

                var tablename = (from x in jsonObj
                                 where x["type"].ToString() == type
                                 select x).FirstOrDefault();

                JArray jsonObj2 = JArray.Parse(tablename["TableDataInfo"].ToString());



                List<JToken> TableDataInfo = new List<JToken>();



                if (type.Contains("_hm"))
                {

                    var cityData = LapContext.tblFW_RegCity.Find(int.Parse(cityid));

                    if (cityData.fldAutoID == 2)
                    {
                        TableDataInfo = (from x in jsonObj2
                                         select x).DefaultIfEmpty().ToList();

                    }
                    else
                    {


                        To_Setup to = new To_Setup();

                        using (Mode.重金属.HMEntityContext db = new Mode.重金属.HMEntityContext())
                        {
                            to = (from x in db.To_Setup
                                  where x.fldType == type
                                  select x).FirstOrDefault();
                        }

                        TableDataInfo = (from x in jsonObj2
                                         where to.fldStartDate <= DateTime.Now && to.fldEndDate >= DateTime.Now
                                         select x).DefaultIfEmpty().ToList();


                    }

                }
                else if (type.Contains("_v"))
                {

                    var cityData = LapContext.tblFW_RegCity.Find(int.Parse(cityid));

                    if (cityData.fldAutoID == 2)
                    {
                        TableDataInfo = (from x in jsonObj2
                                         select x).DefaultIfEmpty().ToList();
                    }
                    else
                    {
                        To_Setup to = new To_Setup();

                        using (VEntityContext db = new VEntityContext())
                        {
                            to = (from x in db.To_Setup
                                  where x.fldType == type
                                  select x).FirstOrDefault();
                        }

                        TableDataInfo = (from x in jsonObj2
                                         where to.fldStartDate <= DateTime.Now && to.fldEndDate >= DateTime.Now
                                         select x).DefaultIfEmpty().ToList();

                    }

                }
                else
                {

                    var cityData = LapContext.tblFW_RegCity.Find(int.Parse(cityid));

                    if (cityData.fldAutoID == 2)
                    {
                        TableDataInfo = (from x in jsonObj2
                                         select x).DefaultIfEmpty().ToList();
                    }
                    else
                    {
                        List<To_Setup> to = new List<To_Setup>();

                        using (EntityContext db = new EntityContext())
                        {
                            to = (from x in db.To_Setup
                                  where x.fldType == type
                                  select x).ToList();
                        }

                        foreach (var item in to)
                        {
                            //var query2 = (from x in jsonObj2
                            //              where item.fldStartDate <= DateTime.Now && item.fldEndDate >= DateTime.Parse(DateTime.Now.ToShortDateString()) &&
                            //              item.fldTableName == x["fldTableDesc"].ToString()
                            //              select x).ToList();
                            var query2 = (from x in jsonObj2
                                          where item.fldStartDate.Day <= DateTime.Now.Day && item.fldEndDate.Day >= DateTime.Parse(DateTime.Now.ToShortDateString()).Day &&
                                          item.fldTableName == x["fldTableDesc"].ToString()
                                          select x).ToList();



                            TableDataInfo.AddRange(query2);

                        }




                    }

                }





                TableDataInfo = (from x in TableDataInfo
                                 where (bool)x["Display"] == true
                                 select x).DefaultIfEmpty().ToList();






                if (TableDataInfo != null)
                {
                    result = rule.JsonStr("ok", "", TableDataInfo);
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
        /// 功能描述：数据检查
        /// 创建者  ：吕荣誉
        /// 创建日期：2017-7-24
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// API说明 ：
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[SupportFilter]
        public HttpResponseMessage CheckData(string type, string fldAutoID, string path, string cityid, string jsonpath, string TableID = null, string deletehistory = "")
        {
            string result = string.Empty;
            try
            {
                //string ImportDataInfoSetting = HostingEnvironment.MapPath(@"~/App_Data/Config/ImportDataInfoSetting/" + type + ".json");

                path = HttpUtility.UrlDecode(path);

                jsonpath = HttpUtility.UrlDecode(jsonpath);

                string getjson = rule.GetJson(jsonpath);

                JArray jsonObj = JArray.Parse(getjson);

                var tablename = (from x in jsonObj
                                 where x["type"].ToString() == type
                                 select x).FirstOrDefault();

                JArray jsonObj2 = JArray.Parse(tablename["TableDataInfo"].ToString());

                var TableDataInfo = (from x in jsonObj2
                                     where x["fldAutoID"].ToString() == fldAutoID
                                     select x).FirstOrDefault();

                JArray Check = JArray.Parse(TableDataInfo["Check"].ToString());

                JArray Column = JArray.Parse(TableDataInfo["Column"].ToString());




                DataTable dt = ExcelConvertDataTable(TableDataInfo["TitleRow"].ToString(), TableDataInfo["DeleteRows"].ToString(), path);


                dt.Columns.Add("错误信息", typeof(string));

                dt.Columns.Add("颜色信息", typeof(string));

                dt.Columns.Add("因子逻辑关系_颜色信息", typeof(string));



                #region 特殊处理的表


                if (type == "eqiw_r" && TableID == "1")
                {
                    foreach (DataColumn item in dt.Columns)
                    {
                        switch (item.ColumnName)
                        {
                            case "落实经费":
                                item.ColumnName = "新建水站_落实经费_计划开始时间";
                                break;
                            case "落实经费1":
                                item.ColumnName = "新建水站_落实经费_计划完成时间";
                                break;
                            case "落实经费2":
                                item.ColumnName = "新建水站_落实经费_是否完成";
                                break;
                            case "落实经费3":
                                item.ColumnName = "新建水站_落实经费_未完成原因";
                                break;
                            case "征租地":
                                item.ColumnName = "新建水站_征租地_计划开始时间";
                                break;
                            case "征租地1":
                                item.ColumnName = "新建水站_征租地_计划完成时间";
                                break;
                            case "征租地2":
                                item.ColumnName = "新建水站_征租地_是否完成";
                                break;
                            case "征租地3":
                                item.ColumnName = "新建水站_征租地_未完成原因";
                                break;
                            case "设计图纸":
                                item.ColumnName = "新建水站_设计图纸_计划开始时间";
                                break;
                            case "设计图纸1":
                                item.ColumnName = "新建水站_设计图纸_计划完成时间";
                                break;
                            case "设计图纸2":
                                item.ColumnName = "新建水站_设计图纸_是否完成";
                                break;
                            case "设计图纸3":
                                item.ColumnName = "新建水站_设计图纸_未完成原因";
                                break;
                            case "招投标":
                                item.ColumnName = "新建水站_招投标_计划开始时间";
                                break;
                            case "招投标1":
                                item.ColumnName = "新建水站_招投标_计划完成时间";
                                break;
                            case "招投标2":
                                item.ColumnName = "新建水站_招投标_是否完成";
                                break;
                            case "招投标3":
                                item.ColumnName = "新建水站_招投标_未完成原因";
                                break;
                            case "四通一平":
                                item.ColumnName = "新建水站_四通一平_计划开始时间";
                                break;
                            case "四通一平1":
                                item.ColumnName = "新建水站_四通一平_计划完成时间";
                                break;
                            case "四通一平2":
                                item.ColumnName = "新建水站_四通一平_是否完成";
                                break;
                            case "四通一平3":
                                item.ColumnName = "新建水站_四通一平_未完成原因";
                                break;
                            case "主体建设":
                                item.ColumnName = "新建水站_主体建设_计划开始时间";
                                break;
                            case "主体建设1":
                                item.ColumnName = "新建水站_主体建设_计划完成时间";
                                break;
                            case "主体建设2":
                                item.ColumnName = "新建水站_主体建设_是否完成";
                                break;
                            case "主体建设3":
                                item.ColumnName = "新建水站_主体建设_未完成原因";
                                break;
                            case "室内装修":
                                item.ColumnName = "新建水站_室内装修_计划开始时间";
                                break;
                            case "室内装修1":
                                item.ColumnName = "新建水站_室内装修_计划完成时间";
                                break;
                            case "室内装修2":
                                item.ColumnName = "新建水站_室内装修_是否完成";
                                break;
                            case "室内装修3":
                                item.ColumnName = "新建水站_室内装修_未完成原因";
                                break;
                            case "采水系统建设":
                                item.ColumnName = "新建水站_采水系统建设_计划开始时间";
                                break;
                            case "采水系统建设1":
                                item.ColumnName = "新建水站_采水系统建设_计划完成时间";
                                break;
                            case "采水系统建设2":
                                item.ColumnName = "新建水站_采水系统建设_是否完成";
                                break;
                            case "采水系统建设3":
                                item.ColumnName = "新建水站_采水系统建设_未完成原因";
                                break;
                            case "联网运行":
                                item.ColumnName = "新建水站_联网运行_计划开始时间";
                                break;
                            case "联网运行1":
                                item.ColumnName = "新建水站_联网运行_计划完成时间";
                                break;
                            case "联网运行2":
                                item.ColumnName = "新建水站_联网运行_是否完成";
                                break;
                            case "联网运行3":
                                item.ColumnName = "新建水站_联网运行_未完成原因";
                                break;

                            case "落实经费（已建）":
                                item.ColumnName = "已建水站_落实经费_计划开始时间";
                                break;
                            case "落实经费（已建）1":
                                item.ColumnName = "已建水站_落实经费_计划完成时间";
                                break;
                            case "落实经费（已建）2":
                                item.ColumnName = "已建水站_落实经费_是否完成";
                                break;
                            case "落实经费（已建）3":
                                item.ColumnName = "已建水站_落实经费_未完成原因";
                                break;
                            case "仪器设备补齐情况":
                                item.ColumnName = "已建水站_仪器设备补齐情况_计划开始时间";
                                break;
                            case "仪器设备补齐情况1":
                                item.ColumnName = "已建水站_仪器设备补齐情况_计划完成时间";
                                break;
                            case "仪器设备补齐情况2":
                                item.ColumnName = "已建水站_仪器设备补齐情况_是否完成";
                                break;
                            case "仪器设备补齐情况3":
                                item.ColumnName = "已建水站_仪器设备补齐情况_未完成原因";
                                break;
                            case "系统更新情况":
                                item.ColumnName = "已建水站_系统更新情况_计划开始时间";
                                break;
                            case "系统更新情况1":
                                item.ColumnName = "已建水站_系统更新情况_计划完成时间";
                                break;
                            case "系统更新情况2":
                                item.ColumnName = "已建水站_系统更新情况_是否完成";
                                break;
                            case "系统更新情况3":
                                item.ColumnName = "已建水站_系统更新情况_未完成原因";
                                break;
                            case "联网运行（已建）":
                                item.ColumnName = "已建水站_联网运行_计划开始时间";
                                break;
                            case "联网运行（已建）1":
                                item.ColumnName = "已建水站_联网运行_计划完成时间";
                                break;
                            case "联网运行（已建）2":
                                item.ColumnName = "已建水站_联网运行_是否完成";
                                break;
                            case "联网运行（已建）3":
                                item.ColumnName = "已建水站_联网运行_未完成原因";
                                break;
                            default:
                                break;
                        }
                    }
                }


                #endregion



                #region 设置上报

                To_Setup to = new To_Setup();

                if (type.Contains("_hm"))
                {
                    using (Mode.重金属.HMEntityContext db = new Mode.重金属.HMEntityContext())
                    {
                        List<To_Setup> toList = new List<To_Setup>();

                        toList = (from x in db.To_Setup
                                  select x).ToList();

                        to = (from x in toList
                              where x.fldType == type &&
                              x.fldTableName == TableDataInfo["fldTableDesc"].ToString()
                              select x).FirstOrDefault();
                    }
                }
                else if (type.Contains("_v"))
                {
                    using (VEntityContext db = new VEntityContext())
                    {

                        List<To_Setup> toList = new List<To_Setup>();

                        toList = (from x in db.To_Setup
                                  select x).ToList();

                        to = (from x in toList
                              where x.fldType == type &&
                              x.fldTableName == TableDataInfo["fldTableDesc"].ToString()
                              select x).FirstOrDefault();
                    }
                }
                else
                {
                    using (EntityContext db = new EntityContext())
                    {

                        List<To_Setup> toList = new List<To_Setup>();

                        toList = (from x in db.To_Setup
                                  select x).ToList();

                        to = (from x in toList
                              where x.fldType == type &&
                              x.fldTableName == TableDataInfo["fldTableDesc"].ToString()
                              select x).FirstOrDefault();
                    }
                }

                if (to != null)
                {
                    if (to.DateType == "每月")
                    {
                        if (to.fldFlag == 0)
                        {
                            var query = (from x in Column
                                         where x["DateTimeFormat"].ToString() != ""
                                         select x).FirstOrDefault();

                            foreach (DataRow item in dt.Rows)
                            {
                                DateTime dateTime = DateTime.Parse(item[query["SourceName"].ToString()].ToString());

                                if (DateTime.Now.Month != dateTime.Month)
                                {
                                    item["错误信息"] = "并非上报日期！";

                                    result = rule.JsonStr("no", "此业务上报历史数据已经关闭！", dt);
                                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                                }
                            }
                        }





                        if (DateTime.Now.Day < to.fldStartDate.Day || DateTime.Now.Day > to.fldEndDate.Day)
                        {

                            foreach (DataRow item in dt.Rows)
                            {
                                item["错误信息"] = "并非上报日期！";
                            }

                            result = rule.JsonStr("nopower", "无操作权限", dt);
                            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                        }
                    }
                    else if (to.DateType == "每年")
                    {
                        if (to.fldFlag == 0)
                        {
                            var query = (from x in Column
                                         where x["DateTimeFormat"].ToString() != ""
                                         select x).FirstOrDefault();

                            foreach (DataRow item in dt.Rows)
                            {
                                DateTime dateTime = DateTime.Parse(item[query["SourceName"].ToString()].ToString());

                                if (DateTime.Now.Year != dateTime.Year)
                                {
                                    item["错误信息"] = "并非上报日期！";

                                    result = rule.JsonStr("no", "此业务上报历史数据已经关闭！", dt);
                                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                                }
                            }
                        }



                        int num = DateTime.Now.Year - to.fldStartDate.Year;
                        to.fldStartDate.AddYears(num);
                        to.fldEndDate.AddYears(num);
                        if (DateTime.Now < to.fldStartDate || DateTime.Now > to.fldEndDate)
                        {
                            foreach (DataRow item in dt.Rows)
                            {
                                item["错误信息"] = "并非上报日期！";
                            }

                            result = rule.JsonStr("nopower", "无操作权限", dt);
                            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                        }
                    }
                    else if (to.DateType == "每半年")
                    {
                        if (to.fldFlag == 0)
                        {
                            var query = (from x in Column
                                         where x["DateTimeFormat"].ToString() != ""
                                         select x).FirstOrDefault();

                            foreach (DataRow item in dt.Rows)
                            {
                                DateTime dateTime = DateTime.Parse(item[query["SourceName"].ToString()].ToString());
                                bool rel = false;

                                if (DateTime.Now.Month < 7)
                                {
                                    rel = dateTime < new DateTime(DateTime.Now.Year, 1, 1);
                                }

                                if (DateTime.Now.Month >= 7)
                                {
                                    rel = dateTime < new DateTime(DateTime.Now.Year, 6, 30);
                                }


                                if (rel)
                                {
                                    item["错误信息"] = "并非上报日期！";

                                    result = rule.JsonStr("no", "此业务上报历史数据已经关闭！", dt);
                                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                                }
                            }
                        }


                        if (DateTime.Now < to.fldStartDate || DateTime.Now > to.fldEndDate)
                        {
                            foreach (DataRow item in dt.Rows)
                            {
                                item["错误信息"] = "并非上报日期！";
                            }

                            result = rule.JsonStr("nopower", "无操作权限", dt);
                            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                        }
                    }
                    else if (to.DateType == "每季度")
                    {
                        if (to.fldFlag == 0)
                        {
                            var query = (from x in Column
                                         where x["DateTimeFormat"].ToString() != ""
                                         select x).FirstOrDefault();

                            DateTime startQuarter = DateTime.Now.AddMonths(0 - (DateTime.Now.Month - 1) % 3).AddDays(1 - DateTime.Now.Day);

                            DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);

                            foreach (DataRow item in dt.Rows)
                            {
                                DateTime dateTime = DateTime.Parse(item[query["SourceName"].ToString()].ToString());

                                if (dateTime < startQuarter || dateTime > endQuarter)
                                {
                                    item["错误信息"] = "并非上报日期！";

                                    result = rule.JsonStr("no", "此业务上报历史数据已经关闭！", dt);
                                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                                }
                            }
                        }

                        int num = DateTime.Now.Year - to.fldStartDate.Year;
                        to.fldStartDate.AddYears(num).AddMonths(3);
                        to.fldEndDate.AddYears(num).AddMonths(3);
                        if (DateTime.Now < to.fldStartDate || DateTime.Now > to.fldEndDate)
                        {
                            foreach (DataRow item in dt.Rows)
                            {
                                item["错误信息"] = "并非上报日期！";
                            }

                            result = rule.JsonStr("nopower", "无操作权限", dt);
                            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                        }
                    }
                }




                #endregion









                var cityData = LapContext.tblFW_RegCity.Find(int.Parse(cityid));
                if (!(cityData.fldAutoID == 2))
                {
                    var query = from x in dt.AsEnumerable()
                                where x[TableDataInfo["VerCity"].ToString()].ToString().Substring(0, 4) != cityData.fldSTCode.Substring(0, 4)
                                select x;

                    if (query.Count() > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            if (item[TableDataInfo["VerCity"].ToString()].ToString().Substring(0, 4) != cityData.fldSTCode.Substring(0, 4))
                            {
                                item["错误信息"] = "无操作权限";
                            }
                        }
                        result = rule.JsonStr("nopower", "无操作权限", dt);
                        return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                    }
                }







                foreach (var item in Check)
                {
                    if (item["FilterCityID"].ToString() != "")
                    {
                        List<string> list = item["FilterCityID"].ToString().Split(',').ToList();

                        if (list.Contains(cityid))
                        {
                            continue;
                        }
                    }


                    if (item["CheckType"].ToString() == "CheckData" || item["CheckType"].ToString() == "Check24Hour")
                    {
                        List<object> list = new List<object>();
                        list.Add(type);
                        list.Add(dt);
                        list.Add(item["CheckCol"].ToString());
                        object[] obj = list.ToArray();
                        dt = (DataTable)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                    }
                    else if (item["CheckType"].ToString() == "Check_withtype_eqiw_r_and_TableID_1")
                    {
                        foreach (DataRow item2 in dt.Rows)
                        {
                            List<object> list = new List<object>();
                            list.Add(type);
                            list.Add(item2);

                            object[] obj = list.ToArray();
                            item2["错误信息"] += (string)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                        }
                    }
                    else if (item["CheckType"].ToString() == "CheckItemName")
                    {
                        DataRow dr = dt.Rows[0];

                        DataTable dtItem = GetItemTable(type);

                        List<object> list = new List<object>();
                        list.Add(dr);
                        list.Add(dtItem);
                        list.Add(item["CheckCol"].ToString());

                        object[] obj = list.ToArray();

                        dt.Rows[0]["错误信息"] += (string)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                    }
                    else if (item["CheckType"].ToString() == "CheckExcel_PointIntegrity")
                    {
                        var query = (from x in Column
                                     where x["DateTimeFormat"].ToString() != ""
                                     select x).FirstOrDefault();


                        List<object> list = new List<object>();
                        list.Add(type);
                        list.Add(query);
                        list.Add(dt);
                        list.Add(item["CheckCol"].ToString());
                        list.Add(cityid);

                        object[] obj = list.ToArray();
                        dt = (DataTable)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                    }
                    else if (item["CheckType"].ToString() == "Check_Item_Validity")
                    {
                        var query = (from x in Column
                                     where x["ItemCode"].ToString() != ""
                                     select x).ToList();

                        foreach (DataRow item2 in dt.Rows)
                        {
                            List<object> list = new List<object>();
                            list.Add(type);
                            list.Add(query);
                            list.Add(item2);
                            object[] obj = list.ToArray();
                            item2["错误信息"] += (string)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                        }
                    }
                    else if (item["CheckType"].ToString() == "Check_Item_Dec")
                    {
                        DataTable dtItem = GetItemTable(type);

                        foreach (DataRow dr in dt.Rows)
                        {
                            List<object> list = new List<object>();
                            list.Add(dtItem);
                            list.Add(dr);
                            list.Add(item["CheckCol"].ToString());

                            object[] obj = list.ToArray();

                            dr["错误信息"] += (string)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                        }
                    }
                    else if (item["CheckType"].ToString() == "Check_Item_Remarks")
                    {
                        DataTable dtItem = GetItemTable(type);

                        foreach (DataRow dr in dt.Rows)
                        {
                            List<object> list = new List<object>();
                            list.Add(dtItem);
                            list.Add(dr);
                            list.Add(item["CheckCol"].ToString());

                            object[] obj = list.ToArray();

                            VerificationRunTime.Object_Return data = new VerificationRunTime.Object_Return();

                            data = (VerificationRunTime.Object_Return)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);

                            dr["错误信息"] += data.ErrorInfo;
                            dr["颜色信息"] += data.ColorInfo;
                        }
                    }
                    else if (item["CheckType"].ToString() == "Check_Item_Remarks_ForAllNull")
                    {
                        DataTable dtItem = GetItemTable(type);

                        foreach (DataRow dr in dt.Rows)
                        {
                            List<object> list = new List<object>();
                            list.Add(dtItem);
                            list.Add(dr);
                            list.Add(item["CheckCol"].ToString());

                            object[] obj = list.ToArray();

                            VerificationRunTime.Object_Return data = new VerificationRunTime.Object_Return();

                            data = (VerificationRunTime.Object_Return)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);

                            dr["错误信息"] += data.ErrorInfo;
                            dr["颜色信息"] += data.ColorInfo;
                        }
                    }
                    else if (item["CheckType"].ToString() == "Check_Col_IsEmpty")
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            List<object> list = new List<object>();
                            list.Add(dr);
                            list.Add(item["CheckCol"].ToString());
                            object[] obj = list.ToArray();

                            dr["错误信息"] += (string)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                        }
                    }
                    else if (item["CheckType"].ToString() == "Check_Col_IsEmpty_ForItem")
                    {
                        DataTable dtItem = GetItemTable(type);

                        foreach (DataRow dr in dt.Rows)
                        {

                            List<object> list = new List<object>();
                            list.Add(dr);
                            list.Add(dtItem);
                            object[] obj = list.ToArray();

                            dr["错误信息"] += (string)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                        }
                    }
                    else if (item["CheckType"].ToString() == "Check_Item_IsNot")
                    {
                        DataTable dtItem = GetItemTable(type);

                        foreach (DataRow dr in dt.Rows)
                        {
                            List<object> list = new List<object>();
                            list.Add(dr);
                            list.Add(dtItem);
                            list.Add(item["CheckCol"].ToString());
                            object[] obj = list.ToArray();

                            dr["错误信息"] += (string)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                        }
                    }
                    else if (item["CheckType"].ToString() == "CheckIsDouble")
                    {
                        foreach (DataRow item2 in dt.Rows)
                        {
                            List<object> list = new List<object>();
                            list.Add(type);
                            list.Add(item2);
                            list.Add(item["CheckCol"].ToString());

                            object[] obj = list.ToArray();

                            VerificationRunTime.Object_Return data = new VerificationRunTime.Object_Return();

                            data = (VerificationRunTime.Object_Return)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);

                            item2["错误信息"] += data.ErrorInfo;
                            item2["颜色信息"] += data.ColorInfo;
                        }
                    }
                    else if (item["CheckType"].ToString() == "CheckIsDouble_V2")
                    {
                        foreach (DataRow item2 in dt.Rows)
                        {
                            List<object> list = new List<object>();
                            list.Add(type);
                            list.Add(item2);
                            list.Add(item["CheckCol"].ToString());

                            object[] obj = list.ToArray();

                            VerificationRunTime.Object_Return data = new VerificationRunTime.Object_Return();

                            data = (VerificationRunTime.Object_Return)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);

                            item2["错误信息"] += data.ErrorInfo;
                            item2["颜色信息"] += data.ColorInfo;
                        }
                    }
                    else if (item["CheckType"].ToString() == "CheckIsDate")
                    {
                        foreach (DataRow item2 in dt.Rows)
                        {
                            List<object> list = new List<object>();
                            list.Add(type);
                            list.Add(item2);
                            list.Add(item["CheckCol"].ToString());
                            list.Add(TableID);

                            object[] obj = list.ToArray();
                            item2["错误信息"] += (string)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                        }
                    }
                    else if (item["CheckType"].ToString() == "Check_ItemLogic")
                    {
                        List<object> list = new List<object>();
                        list.Add(dt);

                        object[] obj = list.ToArray();

                        dt = (DataTable)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                    }
                    else if (item["CheckType"].ToString() == "Check_IsDateNow_Month")
                    {
                        List<object> list = new List<object>();
                        list.Add(dt);

                        object[] obj = list.ToArray();

                        dt = (DataTable)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                    }
                    else if (item["CheckType"].ToString() == "Check_BaseData")
                    {










                        if
                        (
                            (type == "eqiw_r" && fldAutoID == "13") ||
                            (type == "eqiw_d" && fldAutoID == "3")
                        )
                        {
                            #region 处理断面

                            dt.Columns.Add("fldSTCode", typeof(string));
                            dt.Columns.Add("fldRCode", typeof(string));
                            dt.Columns.Add("fldRSCode", typeof(string));

                            string sql = "";
                            if (type == "eqiw_r")
                            {
                                sql = "select * from tblEQIW_R_Section where fldYear = " + DateTime.Now.Year;
                            }

                            if (type == "eqiw_d")
                            {
                                sql = "select * from tblEQIW_D_Section where fldYear = " + DateTime.Now.Year;
                            }

                            DataTable dt_Section = rule.SqlQueryForDataTatable("EntityContext", sql);

                            foreach (DataRow item2 in dt.Rows)
                            {
                                var query2 = (from x in dt_Section.AsEnumerable()
                                              where x["fldRName"].ToString() == item2["河流（湖、库）名称"].ToString() &&
                                              x["fldRSName"].ToString() == item2["断面名称"].ToString()
                                              select x).FirstOrDefault();
                                if (query2 != null)
                                {
                                    item2["fldSTCode"] = query2["fldSTCode"];
                                    item2["fldRCode"] = query2["fldRCode"];
                                    item2["fldRSCode"] = query2["fldRSCode"];
                                }
                            }

                            #endregion

                            #region 日期处理

                            dt.Columns.Add("fldYear", typeof(string));
                            dt.Columns.Add("fldMonth", typeof(string));
                            dt.Columns.Add("fldDay", typeof(string));
                            dt.Columns.Add("fldHour", typeof(string));
                            dt.Columns.Add("fldMinute", typeof(string));

                            var query = (from x in Column
                                         where x["DateTimeFormat"].ToString() != ""
                                         select x).FirstOrDefault();

                            foreach (DataRow dr in dt.Rows)
                            {
                                DateTime date = DateTime.Parse(DateTime.Now.Year + "." + dr[query["SourceName"].ToString()].ToString());

                                dr[query["SourceName"].ToString()] = date;



                                dr["fldYear"] = date.Year.ToString();
                                dr["fldMonth"] = date.Month.ToString();
                                dr["fldDay"] = date.Day.ToString();
                                dr["fldHour"] = date.Hour.ToString();
                                dr["fldMinute"] = date.Minute.ToString();
                            }

                            #endregion

                            #region 处理水平向垂直向

                            dt.Columns.Add("fldSAMPH", typeof(string));
                            dt.Columns.Add("fldSAMPR", typeof(string));

                            foreach (DataRow item2 in dt.Rows)
                            {
                                if (item2["采样点"].ToString().Contains("左"))
                                {
                                    item2["fldSAMPH"] = "1";
                                }
                                else if (item2["采样点"].ToString().Contains("中"))
                                {
                                    item2["fldSAMPH"] = "2";
                                }
                                else
                                {
                                    item2["fldSAMPH"] = "3";
                                }
                                item2["fldSAMPR"] = "1";
                            }

                            #endregion

                            #region 处理水期代码

                            dt.Columns.Add("水期代码", typeof(string));

                            var fldRSC_var = (from x in Column
                                              where x["DestName"].ToString() == "fldRSC"
                                              select x).FirstOrDefault();

                            if (fldRSC_var != null)
                            {

                                var fldRSC_datetime2 = (from x in Column
                                                        where x["DateTimeFormat"].ToString() != ""
                                                        select x).FirstOrDefault();

                                List<string> fldRSC_List = fldRSC_var["fldRSCInput"].ToString().Split('|').ToList();


                                Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();

                                foreach (var item1 in fldRSC_List)
                                {
                                    string FPK = item1.Split('=')[0];
                                    List<string> Months_Temp = item1.Split('=')[1].Split(',').ToList();

                                    List<int> Months = new List<int>();

                                    foreach (var item2 in Months_Temp)
                                    {
                                        Months.Add(int.Parse(item2));
                                    }

                                    dic.Add(FPK, Months);
                                }


                                foreach (DataRow item1 in dt.Rows)
                                {
                                    DateTime date = DateTime.Parse(item1[fldRSC_datetime2["SourceName"].ToString()].ToString());


                                    foreach (var item2 in dic)
                                    {
                                        if (item2.Value.Contains(date.Month))
                                        {
                                            item1[fldRSC_var["SourceName"].ToString()] = item2.Key;
                                        }
                                    }
                                }
                            }

                            #endregion
                        }



















                        //if
                        //(
                        //    (type == "eqiw_r" && fldAutoID == "9") ||
                        //    (type == "eqiw_dt" && fldAutoID == "2")
                        //)
                        //{
                        //    #region 日期处理

                        //    dt.Columns.Add("fldYear", typeof(string));
                        //    dt.Columns.Add("fldMonth", typeof(string));
                        //    dt.Columns.Add("fldDay", typeof(string));
                        //    dt.Columns.Add("fldHour", typeof(string));
                        //    dt.Columns.Add("fldMinute", typeof(string));

                        //    var query = (from x in Column
                        //                 where x["DateTimeFormat"].ToString() != ""
                        //                 select x).FirstOrDefault();

                        //    foreach (DataRow dr in dt.Rows)
                        //    {
                        //        DateTime date = DateTime.Parse(DateTime.Now.Year + "." + dr[query["SourceName"].ToString()].ToString());

                        //        dr["fldYear"] = date.Year.ToString();
                        //        dr["fldMonth"] = date.Month.ToString();
                        //        dr["fldDay"] = date.Day.ToString();
                        //        dr["fldHour"] = date.Hour.ToString();
                        //        dr["fldMinute"] = date.Minute.ToString();
                        //    }

                        //    #endregion

                        //    #region 处理水期代码

                        //    var fldRSC_var = (from x in Column
                        //                      where x["DestName"].ToString() == "fldRSC"
                        //                      select x).FirstOrDefault();

                        //    if (fldRSC_var != null)
                        //    {

                        //        var fldRSC_datetime2 = (from x in Column
                        //                                where x["DateTimeFormat"].ToString() != ""
                        //                                select x).FirstOrDefault();

                        //        List<string> fldRSC_List = fldRSC_var["fldRSCInput"].ToString().Split('|').ToList();


                        //        Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();

                        //        foreach (var item1 in fldRSC_List)
                        //        {
                        //            string FPK = item1.Split('=')[0];
                        //            List<string> Months_Temp = item1.Split('=')[1].Split(',').ToList();

                        //            List<int> Months = new List<int>();

                        //            foreach (var item2 in Months_Temp)
                        //            {
                        //                Months.Add(int.Parse(item2));
                        //            }

                        //            dic.Add(FPK, Months);
                        //        }


                        //        foreach (DataRow item1 in dt.Rows)
                        //        {
                        //            DateTime date = DateTime.Parse(item1[fldRSC_datetime2["SourceName"].ToString()].ToString());


                        //            foreach (var item2 in dic)
                        //            {
                        //                if (item2.Value.Contains(date.Month))
                        //                {
                        //                    item1[fldRSC_var["SourceName"].ToString()] = item2.Key;
                        //                }
                        //            }
                        //        }
                        //    }

                        //    #endregion
                        //}





                        if
                        (
                            (type == "eqiw_d" && fldAutoID == "2") ||
                            (type == "eqiw_d" && fldAutoID == "1") ||
                            (type == "eqiw_r" && fldAutoID == "11") ||
                            (type == "eqiw_dt" && fldAutoID == "3") ||
                            (type == "eqiw_r" && fldAutoID == "9") ||
                            (type == "eqiw_dt" && fldAutoID == "2") ||
                            (type == "eqiw_dt" && fldAutoID == "1") ||
                            (type == "eqiw_r" && fldAutoID == "4")
                        )
                        {
                            #region 日期处理

                            dt.Columns.Add("fldYear", typeof(string));
                            dt.Columns.Add("fldMonth", typeof(string));
                            dt.Columns.Add("fldDay", typeof(string));
                            dt.Columns.Add("fldHour", typeof(string));
                            dt.Columns.Add("fldMinute", typeof(string));

                            var query = (from x in Column
                                         where x["DateTimeFormat"].ToString() != ""
                                         select x).FirstOrDefault();

                            foreach (DataRow dr in dt.Rows)
                            {
                                DateTime date = DateTime.Parse(dr[query["SourceName"].ToString()].ToString());

                                dr["fldYear"] = date.Year.ToString();
                                dr["fldMonth"] = date.Month.ToString();
                                dr["fldDay"] = date.Day.ToString();
                                dr["fldHour"] = date.Hour.ToString();
                                dr["fldMinute"] = date.Minute.ToString();
                            }

                            #endregion

                            #region 处理水期代码

                            var fldRSC_var = (from x in Column
                                              where x["DestName"].ToString() == "fldRSC"
                                              select x).FirstOrDefault();

                            if (fldRSC_var != null)
                            {

                                var fldRSC_datetime2 = (from x in Column
                                                        where x["DateTimeFormat"].ToString() != ""
                                                        select x).FirstOrDefault();

                                List<string> fldRSC_List = fldRSC_var["fldRSCInput"].ToString().Split('|').ToList();


                                Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();

                                foreach (var item1 in fldRSC_List)
                                {
                                    string FPK = item1.Split('=')[0];
                                    List<string> Months_Temp = item1.Split('=')[1].Split(',').ToList();

                                    List<int> Months = new List<int>();

                                    foreach (var item2 in Months_Temp)
                                    {
                                        Months.Add(int.Parse(item2));
                                    }

                                    dic.Add(FPK, Months);
                                }


                                foreach (DataRow item1 in dt.Rows)
                                {
                                    DateTime date = DateTime.Parse(item1[fldRSC_datetime2["SourceName"].ToString()].ToString());


                                    foreach (var item2 in dic)
                                    {
                                        if (item2.Value.Contains(date.Month))
                                        {
                                            item1[fldRSC_var["SourceName"].ToString()] = item2.Key;
                                        }
                                    }
                                }
                            }

                            #endregion
                        }



























                        if
                        (
                            (type == "eqiw_r" && fldAutoID == "12")
                        )
                        {
                            #region 处理断面

                            dt.Columns.Add("fldSTCode", typeof(string));
                            dt.Columns.Add("fldRCode", typeof(string));
                            dt.Columns.Add("fldRSCode", typeof(string));

                            string sql = "";
                            if (type == "eqiw_r")
                            {
                                sql = "select * from tblEQIW_R_Section where fldYear = " + DateTime.Now.Year;
                            }

                            if (type == "eqiw_d")
                            {
                                sql = "select * from tblEQIW_D_Section where fldYear = " + DateTime.Now.Year;
                            }

                            DataTable dt_Section = rule.SqlQueryForDataTatable("EntityContext", sql);

                            foreach (DataRow item2 in dt.Rows)
                            {
                                var query2 = (from x in dt_Section.AsEnumerable()
                                              where x["fldRSCode"].ToString() == item2["断面编码"].ToString()
                                              select x).FirstOrDefault();
                                if (query2 != null)
                                {
                                    item2["fldSTCode"] = query2["fldSTCode"];
                                    item2["fldRCode"] = query2["fldRCode"];
                                    item2["fldRSCode"] = query2["fldRSCode"];
                                }
                            }

                            #endregion

                            #region 日期处理

                            dt.Columns.Add("fldYear", typeof(string));
                            dt.Columns.Add("fldMonth", typeof(string));
                            dt.Columns.Add("fldDay", typeof(string));
                            dt.Columns.Add("fldHour", typeof(string));
                            dt.Columns.Add("fldMinute", typeof(string));

                            var query = (from x in Column
                                         where x["DateTimeFormat"].ToString() != ""
                                         select x).FirstOrDefault();

                            foreach (DataRow dr in dt.Rows)
                            {
                                DateTime date = DateTime.Parse(dr[query["SourceName"].ToString()].ToString());

                                dr[query["SourceName"].ToString()] = date;



                                dr["fldYear"] = date.Year.ToString();
                                dr["fldMonth"] = date.Month.ToString();
                                dr["fldDay"] = date.Day.ToString();
                                dr["fldHour"] = date.Hour.ToString();
                                dr["fldMinute"] = date.Minute.ToString();
                            }

                            #endregion

                            #region 处理水平向垂直向

                            dt.Columns.Add("fldSAMPH", typeof(string));
                            dt.Columns.Add("fldSAMPR", typeof(string));

                            foreach (DataRow item2 in dt.Rows)
                            {
                                item2["fldSAMPH"] = "2";
                                item2["fldSAMPR"] = "1";
                            }

                            #endregion

                            #region 处理水期代码

                            dt.Columns.Add("水期代码", typeof(string));

                            var fldRSC_var = (from x in Column
                                              where x["DestName"].ToString() == "fldRSC"
                                              select x).FirstOrDefault();

                            if (fldRSC_var != null)
                            {

                                var fldRSC_datetime2 = (from x in Column
                                                        where x["DateTimeFormat"].ToString() != ""
                                                        select x).FirstOrDefault();

                                List<string> fldRSC_List = fldRSC_var["fldRSCInput"].ToString().Split('|').ToList();


                                Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();

                                foreach (var item1 in fldRSC_List)
                                {
                                    string FPK = item1.Split('=')[0];
                                    List<string> Months_Temp = item1.Split('=')[1].Split(',').ToList();

                                    List<int> Months = new List<int>();

                                    foreach (var item2 in Months_Temp)
                                    {
                                        Months.Add(int.Parse(item2));
                                    }

                                    dic.Add(FPK, Months);
                                }


                                foreach (DataRow item1 in dt.Rows)
                                {
                                    DateTime date = DateTime.Parse(item1[fldRSC_datetime2["SourceName"].ToString()].ToString());


                                    foreach (var item2 in dic)
                                    {
                                        if (item2.Value.Contains(date.Month))
                                        {
                                            item1[fldRSC_var["SourceName"].ToString()] = item2.Key;
                                        }
                                    }
                                }
                            }

                            #endregion
                        }

















































                        #region 处理fldSource

                        dt.Columns.Add("fldSource", typeof(string));

                        string fldSource = "0";

                        if (TableDataInfo["fldSource"].ToString() != "")
                        {
                            fldSource = TableDataInfo["fldSource"].ToString();
                        }

                        foreach (DataRow item1 in dt.Rows)
                        {
                            item1["fldSource"] = fldSource;
                        }

                        #endregion


















                        #region 核心处理

                        foreach (DataRow item2 in dt.Rows)
                        {
                            List<object> list = new List<object>();
                            list.Add(type);
                            list.Add(item2);
                            list.Add(item["CheckCol"].ToString());

                            object[] obj = list.ToArray();
                            item2["错误信息"] += (string)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                        }

                        #endregion


                        #region 删除多余字段
                        if (dt.Columns.Contains("fldSTCode"))
                        {
                            dt.Columns.Remove("fldSTCode");
                        }
                        if (dt.Columns.Contains("fldRCode"))
                        {
                            dt.Columns.Remove("fldRCode");
                        }
                        if (dt.Columns.Contains("fldRSCode"))
                        {
                            dt.Columns.Remove("fldRSCode");
                        }

                        if (dt.Columns.Contains("fldYear"))
                        {
                            dt.Columns.Remove("fldYear");
                        }
                        if (dt.Columns.Contains("fldMonth"))
                        {
                            dt.Columns.Remove("fldMonth");
                        }
                        if (dt.Columns.Contains("fldDay"))
                        {
                            dt.Columns.Remove("fldDay");
                        }
                        if (dt.Columns.Contains("fldHour"))
                        {
                            dt.Columns.Remove("fldHour");
                        }
                        if (dt.Columns.Contains("fldMinute"))
                        {
                            dt.Columns.Remove("fldMinute");
                        }

                        if (dt.Columns.Contains("fldSAMPH"))
                        {
                            dt.Columns.Remove("fldSAMPH");
                        }
                        if (dt.Columns.Contains("fldSAMPR"))
                        {
                            dt.Columns.Remove("fldSAMPR");
                        }

                        if (dt.Columns.Contains("fldSource"))
                        {
                            dt.Columns.Remove("fldSource");
                        }


                        #endregion
                    }
                    else if (item["CheckType"].ToString() == "Check_BaseData_Pre")
                    {
                        if (deletehistory == "是")
                        {
                            continue;
                        }

                        if
                        (
                            (type == "eqiw_r" && fldAutoID == "13") ||
                            (type == "eqiw_d" && fldAutoID == "3")
                        )
                        {
                            #region 处理断面

                            dt.Columns.Add("fldSTCode", typeof(string));
                            dt.Columns.Add("fldRCode", typeof(string));
                            dt.Columns.Add("fldRSCode", typeof(string));

                            string sql = "";
                            if (type == "eqiw_r")
                            {
                                sql = "select * from tblEQIW_R_Section where fldYear = " + DateTime.Now.Year;
                            }

                            if (type == "eqiw_d")
                            {
                                sql = "select * from tblEQIW_D_Section where fldYear = " + DateTime.Now.Year;
                            }

                            DataTable dt_Section = rule.SqlQueryForDataTatable("EntityContext", sql);

                            foreach (DataRow item2 in dt.Rows)
                            {
                                var query2 = (from x in dt_Section.AsEnumerable()
                                              where x["fldRName"].ToString() == item2["河流（湖、库）名称"].ToString() &&
                                              x["fldRSName"].ToString() == item2["断面名称"].ToString()
                                              select x).FirstOrDefault();
                                if (query2 != null)
                                {
                                    item2["fldSTCode"] = query2["fldSTCode"];
                                    item2["fldRCode"] = query2["fldRCode"];
                                    item2["fldRSCode"] = query2["fldRSCode"];
                                }
                            }

                            #endregion

                            #region 日期处理

                            dt.Columns.Add("fldYear", typeof(string));
                            dt.Columns.Add("fldMonth", typeof(string));
                            dt.Columns.Add("fldDay", typeof(string));
                            dt.Columns.Add("fldHour", typeof(string));
                            dt.Columns.Add("fldMinute", typeof(string));

                            var query = (from x in Column
                                         where x["DateTimeFormat"].ToString() != ""
                                         select x).FirstOrDefault();

                            foreach (DataRow dr in dt.Rows)
                            {
                                DateTime date = DateTime.Parse(dr[query["SourceName"].ToString()].ToString());

                                //dr[query["SourceName"].ToString()] = date;



                                dr["fldYear"] = date.Year.ToString();
                                dr["fldMonth"] = date.Month.ToString();
                                dr["fldDay"] = date.Day.ToString();
                                dr["fldHour"] = date.Hour.ToString();
                                dr["fldMinute"] = date.Minute.ToString();
                            }

                            #endregion

                            #region 处理水平向垂直向

                            dt.Columns.Add("fldSAMPH", typeof(string));
                            dt.Columns.Add("fldSAMPR", typeof(string));

                            foreach (DataRow item2 in dt.Rows)
                            {
                                if (item2["采样点"].ToString().Contains("左"))
                                {
                                    item2["fldSAMPH"] = "1";
                                }
                                else if (item2["采样点"].ToString().Contains("中"))
                                {
                                    item2["fldSAMPH"] = "2";
                                }
                                else
                                {
                                    item2["fldSAMPH"] = "3";
                                }
                                item2["fldSAMPR"] = "1";
                            }

                            #endregion

                            #region 处理水期代码

                            //dt.Columns.Add("水期代码", typeof(string));

                            //var fldRSC_var = (from x in Column
                            //                  where x["DestName"].ToString() == "fldRSC"
                            //                  select x).FirstOrDefault();

                            //if (fldRSC_var != null)
                            //{

                            //    var fldRSC_datetime2 = (from x in Column
                            //                            where x["DateTimeFormat"].ToString() != ""
                            //                            select x).FirstOrDefault();

                            //    List<string> fldRSC_List = fldRSC_var["fldRSCInput"].ToString().Split('|').ToList();


                            //    Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();

                            //    foreach (var item1 in fldRSC_List)
                            //    {
                            //        string FPK = item1.Split('=')[0];
                            //        List<string> Months_Temp = item1.Split('=')[1].Split(',').ToList();

                            //        List<int> Months = new List<int>();

                            //        foreach (var item2 in Months_Temp)
                            //        {
                            //            Months.Add(int.Parse(item2));
                            //        }

                            //        dic.Add(FPK, Months);
                            //    }


                            //    foreach (DataRow item1 in dt.Rows)
                            //    {
                            //        DateTime date = DateTime.Parse(item1[fldRSC_datetime2["SourceName"].ToString()].ToString());


                            //        foreach (var item2 in dic)
                            //        {
                            //            if (item2.Value.Contains(date.Month))
                            //            {
                            //                item1[fldRSC_var["SourceName"].ToString()] = item2.Key;
                            //            }
                            //        }
                            //    }
                            //}

                            #endregion
                        }



















                        if
                        (
                            (type == "eqiw_r" && fldAutoID == "9") ||
                            (type == "eqiw_r" && fldAutoID == "11") ||
                            (type == "eqiw_d" && fldAutoID == "2") ||
                            (type == "eqiw_d" && fldAutoID == "1") ||
                            (type == "eqiw_dt" && fldAutoID == "1") ||
                            (type == "eqiw_dt" && fldAutoID == "2") ||
                            (type == "eqiw_dt" && fldAutoID == "3") ||
                            (type == "eqiw_r" && fldAutoID == "4")

                        )
                        {
                            #region 日期处理

                            dt.Columns.Add("fldYear", typeof(string));
                            dt.Columns.Add("fldMonth", typeof(string));
                            dt.Columns.Add("fldDay", typeof(string));
                            dt.Columns.Add("fldHour", typeof(string));
                            dt.Columns.Add("fldMinute", typeof(string));

                            var query = (from x in Column
                                         where x["DateTimeFormat"].ToString() != ""
                                         select x).FirstOrDefault();

                            foreach (DataRow dr in dt.Rows)
                            {
                                DateTime date = DateTime.Parse(dr[query["SourceName"].ToString()].ToString());

                                dr["fldYear"] = date.Year.ToString();
                                dr["fldMonth"] = date.Month.ToString();
                                dr["fldDay"] = date.Day.ToString();
                                dr["fldHour"] = date.Hour.ToString();
                                dr["fldMinute"] = date.Minute.ToString();
                            }

                            #endregion

                            #region 处理水期代码

                            var fldRSC_var = (from x in Column
                                              where x["DestName"].ToString() == "fldRSC"
                                              select x).FirstOrDefault();

                            if (fldRSC_var != null)
                            {

                                var fldRSC_datetime2 = (from x in Column
                                                        where x["DateTimeFormat"].ToString() != ""
                                                        select x).FirstOrDefault();

                                List<string> fldRSC_List = fldRSC_var["fldRSCInput"].ToString().Split('|').ToList();


                                Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();

                                foreach (var item1 in fldRSC_List)
                                {
                                    string FPK = item1.Split('=')[0];
                                    List<string> Months_Temp = item1.Split('=')[1].Split(',').ToList();

                                    List<int> Months = new List<int>();

                                    foreach (var item2 in Months_Temp)
                                    {
                                        Months.Add(int.Parse(item2));
                                    }

                                    dic.Add(FPK, Months);
                                }


                                foreach (DataRow item1 in dt.Rows)
                                {
                                    DateTime date = DateTime.Parse(item1[fldRSC_datetime2["SourceName"].ToString()].ToString());


                                    foreach (var item2 in dic)
                                    {
                                        if (item2.Value.Contains(date.Month))
                                        {
                                            item1[fldRSC_var["SourceName"].ToString()] = item2.Key;
                                        }
                                    }
                                }
                            }

                            #endregion
                        }



























                        if
                        (
                            (type == "eqiw_r" && fldAutoID == "12")
                        )
                        {
                            #region 处理断面

                            dt.Columns.Add("fldSTCode", typeof(string));
                            dt.Columns.Add("fldRCode", typeof(string));
                            dt.Columns.Add("fldRSCode", typeof(string));

                            string sql = "";
                            if (type == "eqiw_r")
                            {
                                sql = "select * from tblEQIW_R_Section where fldYear = " + DateTime.Now.Year;
                            }

                            if (type == "eqiw_d")
                            {
                                sql = "select * from tblEQIW_D_Section where fldYear = " + DateTime.Now.Year;
                            }

                            DataTable dt_Section = rule.SqlQueryForDataTatable("EntityContext", sql);

                            foreach (DataRow item2 in dt.Rows)
                            {
                                var query2 = (from x in dt_Section.AsEnumerable()
                                              where x["fldRSCode"].ToString() == item2["断面编码"].ToString()
                                              select x).FirstOrDefault();
                                if (query2 != null)
                                {
                                    item2["fldSTCode"] = query2["fldSTCode"];
                                    item2["fldRCode"] = query2["fldRCode"];
                                    item2["fldRSCode"] = query2["fldRSCode"];
                                }
                            }

                            #endregion

                            #region 日期处理

                            dt.Columns.Add("fldYear", typeof(string));
                            dt.Columns.Add("fldMonth", typeof(string));
                            dt.Columns.Add("fldDay", typeof(string));
                            dt.Columns.Add("fldHour", typeof(string));
                            dt.Columns.Add("fldMinute", typeof(string));

                            var query = (from x in Column
                                         where x["DateTimeFormat"].ToString() != ""
                                         select x).FirstOrDefault();

                            foreach (DataRow dr in dt.Rows)
                            {
                                DateTime date = DateTime.Parse(dr[query["SourceName"].ToString()].ToString());

                                dr[query["SourceName"].ToString()] = date;



                                dr["fldYear"] = date.Year.ToString();
                                dr["fldMonth"] = date.Month.ToString();
                                dr["fldDay"] = date.Day.ToString();
                                dr["fldHour"] = date.Hour.ToString();
                                dr["fldMinute"] = date.Minute.ToString();
                            }

                            #endregion

                            #region 处理水平向垂直向

                            dt.Columns.Add("fldSAMPH", typeof(string));
                            dt.Columns.Add("fldSAMPR", typeof(string));

                            foreach (DataRow item2 in dt.Rows)
                            {
                                item2["fldSAMPH"] = "2";
                                item2["fldSAMPR"] = "1";
                            }

                            #endregion

                            #region 处理水期代码

                            //dt.Columns.Add("水期代码", typeof(string));

                            //var fldRSC_var = (from x in Column
                            //                  where x["DestName"].ToString() == "fldRSC"
                            //                  select x).FirstOrDefault();

                            //if (fldRSC_var != null)
                            //{

                            //    var fldRSC_datetime2 = (from x in Column
                            //                            where x["DateTimeFormat"].ToString() != ""
                            //                            select x).FirstOrDefault();

                            //    List<string> fldRSC_List = fldRSC_var["fldRSCInput"].ToString().Split('|').ToList();


                            //    Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();

                            //    foreach (var item1 in fldRSC_List)
                            //    {
                            //        string FPK = item1.Split('=')[0];
                            //        List<string> Months_Temp = item1.Split('=')[1].Split(',').ToList();

                            //        List<int> Months = new List<int>();

                            //        foreach (var item2 in Months_Temp)
                            //        {
                            //            Months.Add(int.Parse(item2));
                            //        }

                            //        dic.Add(FPK, Months);
                            //    }


                            //    foreach (DataRow item1 in dt.Rows)
                            //    {
                            //        DateTime date = DateTime.Parse(item1[fldRSC_datetime2["SourceName"].ToString()].ToString());


                            //        foreach (var item2 in dic)
                            //        {
                            //            if (item2.Value.Contains(date.Month))
                            //            {
                            //                item1[fldRSC_var["SourceName"].ToString()] = item2.Key;
                            //            }
                            //        }
                            //    }
                            //}

                            #endregion
                        }




                        #region 处理fldSource

                        dt.Columns.Add("fldSource", typeof(string));

                        string fldSource = "0";

                        if (TableDataInfo["fldSource"].ToString() != "")
                        {
                            fldSource = TableDataInfo["fldSource"].ToString();
                        }

                        foreach (DataRow item1 in dt.Rows)
                        {
                            item1["fldSource"] = fldSource;
                        }

                        #endregion




                        #region 核心处理

                        foreach (DataRow item2 in dt.Rows)
                        {
                            List<object> list = new List<object>();
                            list.Add(type);
                            list.Add(item2);
                            list.Add(item["CheckCol"].ToString());

                            object[] obj = list.ToArray();
                            item2["错误信息"] += (string)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                        }

                        #endregion


                        #region 删除多余字段
                        if (dt.Columns.Contains("fldSTCode"))
                        {
                            dt.Columns.Remove("fldSTCode");
                        }
                        if (dt.Columns.Contains("fldRCode"))
                        {
                            dt.Columns.Remove("fldRCode");
                        }
                        if (dt.Columns.Contains("fldRSCode"))
                        {
                            dt.Columns.Remove("fldRSCode");
                        }

                        if (dt.Columns.Contains("fldYear"))
                        {
                            dt.Columns.Remove("fldYear");
                        }
                        if (dt.Columns.Contains("fldMonth"))
                        {
                            dt.Columns.Remove("fldMonth");
                        }
                        if (dt.Columns.Contains("fldDay"))
                        {
                            dt.Columns.Remove("fldDay");
                        }
                        if (dt.Columns.Contains("fldHour"))
                        {
                            dt.Columns.Remove("fldHour");
                        }
                        if (dt.Columns.Contains("fldMinute"))
                        {
                            dt.Columns.Remove("fldMinute");
                        }

                        if (dt.Columns.Contains("fldSAMPH"))
                        {
                            dt.Columns.Remove("fldSAMPH");
                        }
                        if (dt.Columns.Contains("fldSAMPR"))
                        {
                            dt.Columns.Remove("fldSAMPR");
                        }

                        if (dt.Columns.Contains("fldSource"))
                        {
                            dt.Columns.Remove("fldSource");
                        }

                        #endregion

                    }
                    else
                    {
                        foreach (DataRow item2 in dt.Rows)
                        {
                            List<object> list = new List<object>();
                            list.Add(type);
                            list.Add(item2);
                            list.Add(item["CheckCol"].ToString());

                            object[] obj = list.ToArray();
                            item2["错误信息"] += (string)InvokeMethod<VerificationRunTime>(item["CheckType"].ToString(), obj);
                        }
                    }
                }













                var ResultInfo = from x in dt.AsEnumerable()
                                 where x["错误信息"].ToString() != ""
                                 select x;

                if (ResultInfo.Count() == 0)
                {
                    result = rule.JsonStr("ok", "数据正确", dt);
                }
                else
                {
                    result = rule.JsonStr("no", "数据错误", dt);
                }
            }
            catch (Exception e)
            {
                string one_InnerException = "";
                string two_InnerException = "";
                if (e.InnerException != null)
                {
                    one_InnerException = e.InnerException.Message;

                    if (e.InnerException.InnerException != null)
                    {
                        two_InnerException = e.InnerException.InnerException.Message;
                    }
                }


                result = rule.JsonStr("error", "常规异常信息：【" + e.Message + "】，一级内部异常信息：【" + one_InnerException + "】，二级内部异常信息：【" + two_InnerException + "】，堆栈跟踪信息【" + e.StackTrace + "】", "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：数据导入
        /// 创建者  ：吕荣誉
        /// 创建日期：2017-7-26
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// API说明 ：
        /// </summary>
        /// <param name="info">传入的Info参数</param>
        /// <returns></returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage ImportData(Info info)
        {
            string result = string.Empty;
            int index = 0;
            try
            {
                //string ImportDataInfoSetting = HostingEnvironment.MapPath(@"~/App_Data/Config/ImportDataInfoSetting/" + info.type + ".json");

                string getjson = rule.GetJson(HttpUtility.UrlDecode(info.jsonpath));

                JArray jsonObj = JArray.Parse(getjson);

                var tablename = (from x in jsonObj
                                 where x["type"].ToString() == info.type.ToString()
                                 select x).FirstOrDefault();

                JArray jsonObj2 = JArray.Parse(tablename["TableDataInfo"].ToString());

                var TableDataInfo = (from x in jsonObj2
                                     where x["fldAutoID"].ToString() == info.fldAutoID.ToString()
                                     select x).FirstOrDefault();





                DataTable dt = ExcelConvertDataTable(TableDataInfo["TitleRow"].ToString(), TableDataInfo["DeleteRows"].ToString(), info.path.ToString());




                #region 特殊处理的表

                if (info.type == "eqiw_r" && info.TableID == "1")
                {
                    foreach (DataColumn item in dt.Columns)
                    {
                        switch (item.ColumnName)
                        {
                            case "落实经费":
                                item.ColumnName = "新建水站_落实经费_计划开始时间";
                                break;
                            case "落实经费1":
                                item.ColumnName = "新建水站_落实经费_计划完成时间";
                                break;
                            case "落实经费2":
                                item.ColumnName = "新建水站_落实经费_是否完成";
                                break;
                            case "落实经费3":
                                item.ColumnName = "新建水站_落实经费_未完成原因";
                                break;
                            case "征租地":
                                item.ColumnName = "新建水站_征租地_计划开始时间";
                                break;
                            case "征租地1":
                                item.ColumnName = "新建水站_征租地_计划完成时间";
                                break;
                            case "征租地2":
                                item.ColumnName = "新建水站_征租地_是否完成";
                                break;
                            case "征租地3":
                                item.ColumnName = "新建水站_征租地_未完成原因";
                                break;
                            case "设计图纸":
                                item.ColumnName = "新建水站_设计图纸_计划开始时间";
                                break;
                            case "设计图纸1":
                                item.ColumnName = "新建水站_设计图纸_计划完成时间";
                                break;
                            case "设计图纸2":
                                item.ColumnName = "新建水站_设计图纸_是否完成";
                                break;
                            case "设计图纸3":
                                item.ColumnName = "新建水站_设计图纸_未完成原因";
                                break;
                            case "招投标":
                                item.ColumnName = "新建水站_招投标_计划开始时间";
                                break;
                            case "招投标1":
                                item.ColumnName = "新建水站_招投标_计划完成时间";
                                break;
                            case "招投标2":
                                item.ColumnName = "新建水站_招投标_是否完成";
                                break;
                            case "招投标3":
                                item.ColumnName = "新建水站_招投标_未完成原因";
                                break;
                            case "四通一平":
                                item.ColumnName = "新建水站_四通一平_计划开始时间";
                                break;
                            case "四通一平1":
                                item.ColumnName = "新建水站_四通一平_计划完成时间";
                                break;
                            case "四通一平2":
                                item.ColumnName = "新建水站_四通一平_是否完成";
                                break;
                            case "四通一平3":
                                item.ColumnName = "新建水站_四通一平_未完成原因";
                                break;
                            case "主体建设":
                                item.ColumnName = "新建水站_主体建设_计划开始时间";
                                break;
                            case "主体建设1":
                                item.ColumnName = "新建水站_主体建设_计划完成时间";
                                break;
                            case "主体建设2":
                                item.ColumnName = "新建水站_主体建设_是否完成";
                                break;
                            case "主体建设3":
                                item.ColumnName = "新建水站_主体建设_未完成原因";
                                break;
                            case "室内装修":
                                item.ColumnName = "新建水站_室内装修_计划开始时间";
                                break;
                            case "室内装修1":
                                item.ColumnName = "新建水站_室内装修_计划完成时间";
                                break;
                            case "室内装修2":
                                item.ColumnName = "新建水站_室内装修_是否完成";
                                break;
                            case "室内装修3":
                                item.ColumnName = "新建水站_室内装修_未完成原因";
                                break;
                            case "采水系统建设":
                                item.ColumnName = "新建水站_采水系统建设_计划开始时间";
                                break;
                            case "采水系统建设1":
                                item.ColumnName = "新建水站_采水系统建设_计划完成时间";
                                break;
                            case "采水系统建设2":
                                item.ColumnName = "新建水站_采水系统建设_是否完成";
                                break;
                            case "采水系统建设3":
                                item.ColumnName = "新建水站_采水系统建设_未完成原因";
                                break;
                            case "联网运行":
                                item.ColumnName = "新建水站_联网运行_计划开始时间";
                                break;
                            case "联网运行1":
                                item.ColumnName = "新建水站_联网运行_计划完成时间";
                                break;
                            case "联网运行2":
                                item.ColumnName = "新建水站_联网运行_是否完成";
                                break;
                            case "联网运行3":
                                item.ColumnName = "新建水站_联网运行_未完成原因";
                                break;

                            case "落实经费（已建）":
                                item.ColumnName = "已建水站_落实经费_计划开始时间";
                                break;
                            case "落实经费（已建）1":
                                item.ColumnName = "已建水站_落实经费_计划完成时间";
                                break;
                            case "落实经费（已建）2":
                                item.ColumnName = "已建水站_落实经费_是否完成";
                                break;
                            case "落实经费（已建）3":
                                item.ColumnName = "已建水站_落实经费_未完成原因";
                                break;
                            case "仪器设备补齐情况":
                                item.ColumnName = "已建水站_仪器设备补齐情况_计划开始时间";
                                break;
                            case "仪器设备补齐情况1":
                                item.ColumnName = "已建水站_仪器设备补齐情况_计划完成时间";
                                break;
                            case "仪器设备补齐情况2":
                                item.ColumnName = "已建水站_仪器设备补齐情况_是否完成";
                                break;
                            case "仪器设备补齐情况3":
                                item.ColumnName = "已建水站_仪器设备补齐情况_未完成原因";
                                break;
                            case "系统更新情况":
                                item.ColumnName = "已建水站_系统更新情况_计划开始时间";
                                break;
                            case "系统更新情况1":
                                item.ColumnName = "已建水站_系统更新情况_计划完成时间";
                                break;
                            case "系统更新情况2":
                                item.ColumnName = "已建水站_系统更新情况_是否完成";
                                break;
                            case "系统更新情况3":
                                item.ColumnName = "已建水站_系统更新情况_未完成原因";
                                break;
                            case "联网运行（已建）":
                                item.ColumnName = "已建水站_联网运行_计划开始时间";
                                break;
                            case "联网运行（已建）1":
                                item.ColumnName = "已建水站_联网运行_计划完成时间";
                                break;
                            case "联网运行（已建）2":
                                item.ColumnName = "已建水站_联网运行_是否完成";
                                break;
                            case "联网运行（已建）3":
                                item.ColumnName = "已建水站_联网运行_未完成原因";
                                break;
                            default:
                                break;
                        }
                    }
                }






                if (info.type == "eqiw_r" && info.fldAutoID == "13")
                {

                    #region 处理断面


                    dt.Columns.Add("fldSTCode", typeof(string));
                    dt.Columns.Add("fldRCode", typeof(string));
                    dt.Columns.Add("fldRSCode", typeof(string));

                    DataTable dt_Section = rule.SqlQueryForDataTatable("EntityContext", "select * from tblEQIW_R_Section where fldYear = " + DateTime.Now.Year);

                    foreach (DataRow item in dt.Rows)
                    {
                        var query2 = (from x in dt_Section.AsEnumerable()
                                      where x["fldRName"].ToString() == item["河流（湖、库）名称"].ToString() &&
                                      x["fldRSName"].ToString() == item["断面名称"].ToString()
                                      select x).FirstOrDefault();
                        if (query2 != null)
                        {
                            item["fldSTCode"] = query2["fldSTCode"];
                            item["fldRCode"] = query2["fldRCode"];
                            item["fldRSCode"] = query2["fldRSCode"];
                        }
                    }

                    #endregion


                    #region 处理水平向垂直向

                    dt.Columns.Add("fldSAMPH", typeof(string));
                    dt.Columns.Add("fldSAMPR", typeof(string));

                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["采样点"].ToString().Contains("左"))
                        {
                            item["fldSAMPH"] = "1";
                        }
                        else if (item["采样点"].ToString().Contains("中"))
                        {
                            item["fldSAMPH"] = "2";
                        }
                        else
                        {
                            item["fldSAMPH"] = "3";
                        }
                        item["fldSAMPR"] = "1";
                    }

                    #endregion


                    #region 处理日期

                    foreach (DataRow item in dt.Rows)
                    {
                        item["采样日"] = DateTime.Parse(DateTime.Now.Year + "." + item["采样日"].ToString());
                    }

                    #endregion


                    #region 处理水期代码

                    dt.Columns.Add("水期代码", typeof(string));

                    #endregion
















                    string filepath = HostingEnvironment.MapPath(@"~/App_Data/国家采测分离映射文件/ItemName_Map2.json");

                    List<ItemName_Map> ItemName_Map = new List<ItemName_Map>();


                    ItemName_Map = GetFileJson<List<ItemName_Map>>(filepath);

                    foreach (var item in ItemName_Map)
                    {
                        foreach (DataColumn item2 in dt.Columns)
                        {
                            if (item.ItemName_Country == item2.ColumnName)
                            {
                                item2.ColumnName = item.ItemName_System;
                            }
                        }
                    }








                    #region 处理数学科学计数法
                    foreach (DataRow item in dt.Rows)
                    {
                        foreach (DataColumn item2 in dt.Columns)
                        {
                            if (item[item2].ToString().Contains("×"))
                            {
                                string value = item[item2].ToString().Split('×')[1].Replace("10", "").Replace("L", "");

                                string value2 = "1";

                                for (int i = 0; i < Math.Abs(int.Parse(value)); i++)
                                {
                                    value2 += "0";
                                }

                                double value3 = double.Parse(item[item2].ToString().Split('×')[0]);

                                double result_val = 0;
                                if (double.Parse(value) > 0)
                                {
                                    result_val = value3 * double.Parse(value2);
                                }
                                else
                                {
                                    result_val = value3 / double.Parse(value2);
                                }

                                if (item[item2].ToString().Contains("L"))
                                {
                                    item[item2] = result_val.ToString() + "L";
                                }
                                else
                                {
                                    item[item2] = result_val.ToString();
                                }
                            }
                        }
                    }





                    #endregion



                    filepath = HostingEnvironment.MapPath(@"~/App_Data/国家采测分离映射文件/UnitConverter_Data2.json");


                    List<UnitConverter_Data> UnitConverter_Data = new List<UnitConverter_Data>();


                    UnitConverter_Data = GetFileJson<List<UnitConverter_Data>>(filepath);

                    foreach (var item in UnitConverter_Data)
                    {
                        foreach (DataRow item2 in dt.Rows)
                        {
                            if (item2[item.ItemName].ToString() == "-1" || item2[item.ItemName].ToString() == "" || item2[item.ItemName].ToString() == "/")
                            {
                                continue;
                            }


                            double value = 0;

                            if (item2[item.ItemName].ToString().Contains("L"))
                            {
                                value = -double.Parse(item2[item.ItemName].ToString().TrimEnd('L'));
                            }
                            else
                            {
                                value = double.Parse(item2[item.ItemName].ToString());
                            }



                            if (item.UnitConverter[0] == "*")
                            {
                                item2[item.ItemName] = value * double.Parse(item.UnitConverter[1]);
                            }

                            if (item.UnitConverter[0] == "/")
                            {
                                item2[item.ItemName] = value / double.Parse(item.UnitConverter[1]);
                            }
                            if (item.UnitConverter[0] == "+")
                            {
                                item2[item.ItemName] = value + double.Parse(item.UnitConverter[1]);
                            }
                            if (item.UnitConverter[0] == "-")
                            {
                                item2[item.ItemName] = value - double.Parse(item.UnitConverter[1]);
                            }
                        }
                    }















                    #region 生成水华数据

                    DataTable dt_2 = dt.Copy();

                    foreach (DataRow item in dt_Section.Rows)
                    {
                        foreach (DataRow item2 in dt_2.Rows)
                        {
                            if (item["fldSyncDataSectionInfo"].ToString() == item2["fldSTCode"].ToString() + "." + item2["fldRCode"].ToString() + "." + item2["fldRSCode"].ToString())
                            {
                                DataRow dr = dt_2.NewRow();
                                dr = item2;

                                dr["fldSTCode"] = item["fldSTCode"].ToString();
                                dr["fldRCode"] = item["fldRCode"].ToString();
                                dr["fldRSCode"] = item["fldRSCode"].ToString();

                                dt.ImportRow(dr);
                            }
                        }
                    }










                    #endregion












                }






                if (info.type == "eqiw_d" && info.fldAutoID == "3")
                {

                    #region 处理断面


                    dt.Columns.Add("fldSTCode", typeof(string));
                    dt.Columns.Add("fldRCode", typeof(string));
                    dt.Columns.Add("fldRSCode", typeof(string));

                    DataTable dt_Section = rule.SqlQueryForDataTatable("EntityContext", "select * from tblEQIW_D_Section where fldYear = " + DateTime.Now.Year);

                    foreach (DataRow item in dt.Rows)
                    {
                        var query2 = (from x in dt_Section.AsEnumerable()
                                      where x["fldRName"].ToString() == item["河流（湖、库）名称"].ToString() &&
                                      x["fldRSName"].ToString() == item["断面名称"].ToString()
                                      select x).FirstOrDefault();
                        if (query2 != null)
                        {
                            item["fldSTCode"] = query2["fldSTCode"];
                            item["fldRCode"] = query2["fldRCode"];
                            item["fldRSCode"] = query2["fldRSCode"];
                        }
                    }

                    #endregion


                    #region 处理水平向垂直向

                    dt.Columns.Add("fldSAMPH", typeof(string));
                    dt.Columns.Add("fldSAMPR", typeof(string));

                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["采样点"].ToString().Contains("左"))
                        {
                            item["fldSAMPH"] = "1";
                        }
                        else if (item["采样点"].ToString().Contains("中"))
                        {
                            item["fldSAMPH"] = "2";
                        }
                        else
                        {
                            item["fldSAMPH"] = "3";
                        }
                        item["fldSAMPR"] = "1";
                    }

                    #endregion


                    #region 处理日期

                    foreach (DataRow item in dt.Rows)
                    {
                        item["采样日"] = DateTime.Parse(DateTime.Now.Year + "." + item["采样日"].ToString());
                    }

                    #endregion


                    #region 处理水期代码

                    dt.Columns.Add("水期代码", typeof(string));

                    #endregion
















                    string filepath = HostingEnvironment.MapPath(@"~/App_Data/国家采测分离映射文件/ItemName_Map3.json");

                    List<ItemName_Map> ItemName_Map = new List<ItemName_Map>();


                    ItemName_Map = GetFileJson<List<ItemName_Map>>(filepath);

                    foreach (var item in ItemName_Map)
                    {
                        foreach (DataColumn item2 in dt.Columns)
                        {
                            if (item.ItemName_Country == item2.ColumnName)
                            {
                                item2.ColumnName = item.ItemName_System;
                            }
                        }
                    }








                    #region 处理数学科学计数法
                    foreach (DataRow item in dt.Rows)
                    {
                        foreach (DataColumn item2 in dt.Columns)
                        {
                            if (item[item2].ToString().Contains("×"))
                            {
                                string value = item[item2].ToString().Split('×')[1].Replace("10", "").Replace("L", "");

                                string value2 = "1";

                                for (int i = 0; i < Math.Abs(int.Parse(value)); i++)
                                {
                                    value2 += "0";
                                }

                                double value3 = double.Parse(item[item2].ToString().Split('×')[0]);

                                double result_val = 0;
                                if (double.Parse(value) > 0)
                                {
                                    result_val = value3 * double.Parse(value2);
                                }
                                else
                                {
                                    result_val = value3 / double.Parse(value2);
                                }

                                if (item[item2].ToString().Contains("L"))
                                {
                                    item[item2] = result_val.ToString() + "L";
                                }
                                else
                                {
                                    item[item2] = result_val.ToString();
                                }
                            }
                        }
                    }





                    #endregion







                }





                if (info.type == "eqiw_r" && info.fldAutoID == "12")
                {
                    dt.Columns.Add("水期代码", typeof(string));
                    dt.Columns.Add("fldSTCode", typeof(string));
                    dt.Columns.Add("fldRCode", typeof(string));

                    foreach (DataColumn item in dt.Columns)
                    {
                        if (item.ColumnName == "断面编码")
                        {
                            item.ColumnName = "fldRSCode";
                        }
                    }

                    DataTable dt_Section = rule.SqlQueryForDataTatable("EntityContext", "select * from tblEQIW_R_Section where fldYear = " + DateTime.Now.Year);


                    foreach (DataRow item in dt.Rows)
                    {
                        var query2 = (from x in dt_Section.AsEnumerable()
                                      where x["fldrcodeback"].ToString() == item["fldRSCode"].ToString()
                                      select x).FirstOrDefault();
                        if (query2 != null)
                        {
                            item["fldSTCode"] = query2["fldSTCode"];
                            item["fldRCode"] = query2["fldRCode"];
                            item["fldRSCode"] = query2["fldRSCode"];
                        }
                    }


                    dt.Columns.Add("fldSAMPH", typeof(string));
                    dt.Columns.Add("fldSAMPR", typeof(string));

                    foreach (DataRow item in dt.Rows)
                    {
                        item["fldSAMPH"] = "2";
                        item["fldSAMPR"] = "1";
                    }






                    string filepath = HostingEnvironment.MapPath(@"~/App_Data/国家采测分离映射文件/ItemName_Map.json");

                    List<ItemName_Map> ItemName_Map = new List<ItemName_Map>();


                    ItemName_Map = GetFileJson<List<ItemName_Map>>(filepath);

                    foreach (var item in ItemName_Map)
                    {
                        foreach (DataColumn item2 in dt.Columns)
                        {
                            if (item.ItemName_Country == item2.ColumnName)
                            {
                                item2.ColumnName = item.ItemName_System;
                            }
                        }
                    }








                    filepath = HostingEnvironment.MapPath(@"~/App_Data/国家采测分离映射文件/UnitConverter_Data.json");


                    List<UnitConverter_Data> UnitConverter_Data = new List<UnitConverter_Data>();


                    UnitConverter_Data = GetFileJson<List<UnitConverter_Data>>(filepath);

                    foreach (var item in UnitConverter_Data)
                    {
                        foreach (DataRow item2 in dt.Rows)
                        {
                            if (item2[item.ItemName].ToString() == "-1" || item2[item.ItemName].ToString() == "")
                            {
                                continue;
                            }

                            if (item.UnitConverter[0] == "*")
                            {
                                item2[item.ItemName] = double.Parse(item2[item.ItemName].ToString()) * double.Parse(item.UnitConverter[1]);
                            }

                            if (item.UnitConverter[0] == "/")
                            {
                                item2[item.ItemName] = double.Parse(item2[item.ItemName].ToString()) / double.Parse(item.UnitConverter[1]);
                            }
                            if (item.UnitConverter[0] == "+")
                            {
                                item2[item.ItemName] = double.Parse(item2[item.ItemName].ToString()) + double.Parse(item.UnitConverter[1]);
                            }
                            if (item.UnitConverter[0] == "-")
                            {
                                item2[item.ItemName] = double.Parse(item2[item.ItemName].ToString()) - double.Parse(item.UnitConverter[1]);
                            }
                        }
                    }
                }





                #endregion







                dt.Columns.Add("fldItemCode", typeof(string));
                dt.Columns.Add("fldItemValue", typeof(string));

                JArray ColArray = JArray.Parse(TableDataInfo["Column"].ToString());

                var datetime = from x in ColArray
                               where x["DateTimeFormat"].ToString() != ""
                               select x;

                if (!(datetime.Count() == 0))
                {
                    foreach (var item in datetime)
                    {
                        string[] temp = item["DateTimeFormat"].ToString().Split('-');
                        foreach (var item1 in temp)
                        {
                            dt.Columns.Add(item1, typeof(string));
                        }

                        foreach (DataRow item2 in dt.Rows)
                        {
                            DateTime date = DateTime.Parse(item2[item["SourceName"].ToString()].ToString());
                            foreach (var item3 in temp)
                            {
                                if (item3 == "fldSYear" || item3 == "fldEYear" || item3 == "fldYear")
                                {
                                    item2[item3] = date.Year.ToString();
                                }
                                else if (item3 == "fldSMonth" || item3 == "fldEMonth" || item3 == "fldMonth" || item3 == "fldMon")
                                {
                                    item2[item3] = date.Month.ToString();
                                }
                                else if (item3 == "fldSDay" || item3 == "fldEDay" || item3 == "fldDay")
                                {
                                    item2[item3] = date.Day.ToString();
                                }
                                else if (item3 == "fldSHour" || item3 == "fldEHour" || item3 == "fldHour")
                                {
                                    item2[item3] = date.Hour.ToString();
                                }
                                else if (item3 == "fldSMinute" || item3 == "fldEMinute" || item3 == "fldMinute")
                                {
                                    item2[item3] = date.Minute.ToString();
                                }
                            }
                        }
                    }
                }



                #region 处理水期代码(fldRSC)

                var fldRSC_var = (from x in ColArray
                                  where x["DestName"].ToString() == "fldRSC"
                                  select x).FirstOrDefault();

                if (fldRSC_var != null)
                {

                    var fldRSC_datetime2 = (from x in ColArray
                                            where x["DateTimeFormat"].ToString() != ""
                                            select x).FirstOrDefault();

                    List<string> fldRSC_List = fldRSC_var["fldRSCInput"].ToString().Split('|').ToList();


                    Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();

                    foreach (var item in fldRSC_List)
                    {
                        string FPK = item.Split('=')[0];
                        List<string> Months_Temp = item.Split('=')[1].Split(',').ToList();

                        List<int> Months = new List<int>();

                        foreach (var item2 in Months_Temp)
                        {
                            Months.Add(int.Parse(item2));
                        }

                        dic.Add(FPK, Months);
                    }


                    foreach (DataRow item in dt.Rows)
                    {
                        DateTime date = DateTime.Parse(item[fldRSC_datetime2["SourceName"].ToString()].ToString());


                        foreach (var item2 in dic)
                        {
                            if (item2.Value.Contains(date.Month))
                            {
                                item[fldRSC_var["SourceName"].ToString()] = item2.Key;
                            }
                        }
                    }
                }


                #endregion






                dt.Columns.Add("fldCityID_Submit", typeof(string));
                dt.Columns.Add("fldCityID_Operate", typeof(string));
                dt.Columns.Add("fldBatch", typeof(string));
                dt.Columns.Add("fldUserID", typeof(string));
                dt.Columns.Add("fldDate_Operate", typeof(string));
                dt.Columns.Add("fldSource", typeof(string));
                dt.Columns.Add("fldImport", typeof(string));
                dt.Columns.Add("fldFlag", typeof(string));



                int fldSource = 0;


                if (TableDataInfo["fldSource"].ToString() != "")
                {
                    fldSource = Convert.ToInt32(TableDataInfo["fldSource"]);
                }


                int fldFlag = 0;

                //if (info.Number3Auditing == "Y")
                //{
                //    if (info.fldCityID_Submit == "2")
                //    {
                //        fldFlag = 4;
                //    }
                //}


                foreach (DataRow item in dt.Rows)
                {
                    item["fldCityID_Submit"] = info.fldCityID_Submit.ToString();
                    item["fldCityID_Operate"] = info.fldCityID_Operate.ToString();
                    item["fldBatch"] = "0";
                    item["fldUserID"] = info.fldUserID.ToString();
                    item["fldDate_Operate"] = DateTime.Now;
                    item["fldSource"] = fldSource;
                    item["fldImport"] = 1;
                    item["fldFlag"] = fldFlag;
                }












































                if (TableDataInfo["Item"].ToString() != "")
                {
                    JArray ItemArray = JArray.Parse(TableDataInfo["Item"].ToString());

                    foreach (var item in ItemArray)
                    {
                        if (dt.Columns.Contains(item["ItemName"].ToString()))
                        {
                            foreach (DataRow item2 in dt.Rows)
                            {
                                if (item2[item["ItemName"].ToString()].ToString() == "-1" || item2[item["ItemName"].ToString()].ToString() == "" || item2[item["ItemName"].ToString()].ToString() == "/")
                                {
                                    continue;
                                }

                                if (item2[item["ItemName"].ToString()].ToString().Contains("L"))
                                {
                                    double value = double.Parse(item2[item["ItemName"].ToString()].ToString().Replace("L", ""));

                                    item2[item["ItemName"].ToString()] = "-" + ChangeDataToD(value.ToString()).ToString();
                                }

                                JArray UnitConverter = JArray.Parse(item["UnitConverter"].ToString());

                                if (UnitConverter[0].ToString() == "*")
                                {
                                    item2[item["ItemName"].ToString()] = double.Parse(item2[item["ItemName"].ToString()].ToString()) * double.Parse(UnitConverter[1].ToString());
                                }
                                if (UnitConverter[0].ToString() == "/")
                                {
                                    item2[item["ItemName"].ToString()] = double.Parse(item2[item["ItemName"].ToString()].ToString()) / double.Parse(UnitConverter[1].ToString());
                                }
                                if (UnitConverter[0].ToString() == "+")
                                {
                                    item2[item["ItemName"].ToString()] = double.Parse(item2[item["ItemName"].ToString()].ToString()) + double.Parse(UnitConverter[1].ToString());
                                }
                                if (UnitConverter[0].ToString() == "-")
                                {
                                    item2[item["ItemName"].ToString()] = double.Parse(item2[item["ItemName"].ToString()].ToString()) - double.Parse(UnitConverter[1].ToString());
                                }
                            }
                        }
                    }
                }


























                DataTable dtTemp = dt.Clone();

                DataTable dtItem = GetItemTable(info.type);


                foreach (DataRow item in dt.Rows)
                {
                    if (dtItem == null)
                    {
                        dtTemp.ImportRow(item);
                    }
                    else
                    {
                        foreach (DataRow item1 in dtItem.Rows)
                        {
                            if (item.Table.Columns.Contains(item1["fldItemName"].ToString()))
                            {
                                item["fldItemCode"] = item1["fldItemCode"];

                                if (item[item1["fldItemName"].ToString()].ToString().Contains("L"))
                                {
                                    double value = double.Parse(item[item1["fldItemName"].ToString()].ToString().Replace("L", ""));

                                    item["fldItemValue"] = "-" + ChangeDataToD(value.ToString()).ToString();
                                }
                                else if (item[item1["fldItemName"].ToString()].ToString() == "-1" || item[item1["fldItemName"].ToString()].ToString() == "" || item[item1["fldItemName"].ToString()].ToString() == "/")
                                {
                                    continue;
                                }
                                else
                                {
                                    item["fldItemValue"] = ChangeDataToD(item[item1["fldItemName"].ToString()].ToString());
                                }
















                                dtTemp.ImportRow(item);
                            }
                        }
                    }
                }

















                var OM = from x in ColArray
                         where x["DestName"].ToString() != ""
                         select x;

                foreach (DataColumn item in dtTemp.Columns)
                {
                    foreach (var item1 in OM)
                    {
                        if (item1["SourceName"].ToString() == item.ColumnName)
                        {
                            item.ColumnName = item1["DestName"].ToString();
                        }
                    }
                }






                int number = ExecuteEntityContext(info.type, info.TableID, info.deletehistory, dtTemp, dt, info.fldCityID_Operate, out index);







                if (number > 0)
                {







                    using (EntityContext db = new EntityContext())
                    {
                        tblDT_Dn_DataLog log = new tblDT_Dn_DataLog()
                        {
                            fldTableName = TableDataInfo["fldTableDesc"].ToString(),
                            fldSTName = "空",
                            fldsource = 0,
                            fldTtype = info.type,
                            fldDate_Begin = DateTime.Now,
                            fldDate_End = DateTime.Now,
                            fldDn_date = DateTime.Now,
                            fldLevel = "1,2,3,4,5",
                            fldPointNum = dt.Rows.Count,
                            fldRecordNum = index,
                            fldType = 1,
                            fldDn_user = int.Parse(info.fldUserID),
                        };
                        db.tblDT_Dn_DataLog.Add(log);
                        db.SaveChanges();
                    }




                    using (EntityContext db = new EntityContext())
                    {


                        var remarkresult = (from x in OM
                                            where x["SourceName"].ToString() == "备注"
                                            select x).FirstOrDefault();

                        if (remarkresult != null)
                        {
                            List<tblEQI_DataImport_Remark> remarklist = new List<tblEQI_DataImport_Remark>();

                            foreach (DataRow item in dt.Rows)
                            {
                                string remarkinfo = null;
                                if (item["备注"].ToString() != "")
                                {
                                    tblEQI_DataImport_Remark remark = new tblEQI_DataImport_Remark();
                                    remark.fldObject = info.type;

                                    foreach (var item1 in remarkresult["DestName"].ToString().Split('.'))
                                    {
                                        remarkinfo += item[item1].ToString() + ".";
                                    }

                                    remark.fldRSInfo = remarkinfo.TrimEnd('.');

                                    var datetime2 = (from x in ColArray
                                                     where x["DateTimeFormat"].ToString() != ""
                                                     select x).FirstOrDefault();

                                    remark.fldDate = item[datetime2["SourceName"].ToString()].ToString();

                                    remark.fldRemark = item["备注"].ToString();

                                    if (TableDataInfo["fldSource"].ToString() != "")
                                    {
                                        remark.fldsource = Convert.ToInt32(TableDataInfo["fldSource"]);
                                    }
                                    else
                                    {
                                        remark.fldsource = 0;
                                    }

                                    remarklist.Add(remark);
                                }
                            }



                            var query = (from x in db.tblEQI_DataImport_Remark
                                         select x).ToList();


                            foreach (var item in remarklist)
                            {
                                var query2 = (from x in query
                                              where x.fldObject == item.fldObject &&
                                              x.fldRSInfo == item.fldRSInfo &&
                                              x.fldDate == item.fldDate &&
                                              x.fldsource == item.fldsource
                                              select x).ToList();

                                db.tblEQI_DataImport_Remark.RemoveRange(query2);
                                db.SaveChanges();
                            }







                            db.tblEQI_DataImport_Remark.AddRange(remarklist);
                            db.SaveChanges();

                        }
                    }








                    result = rule.JsonStr("ok", "插入数据成功！", number);
                }
                else
                {
                    result = rule.JsonStr("no", "没有数据入库！", "");
                }




            }
            catch (Exception e)
            {
                //result = rule.JsonStr("error", e.Message, "");

                //int yi = e.InnerException.InnerException.Message.IndexOf('(');

                //int er = e.InnerException.InnerException.Message.IndexOf(')');

                //int num = er - yi;

                //string info2 = e.InnerException.InnerException.Message.Substring(yi + 1, num - 1);

                //string[] info3 = info2.Split(',');

                //string info4 = "与系统中的数据重复，城市代码:" + info3[0] + "、断面代码:" + info3[1] + "、年:" + info3[2] + "、月:" + info3[3] + "、日:" + info3[4] + "，若需要替换系统中数据，请在导入的时候勾选删除历史数据选项！";

                //string info4 = "与系统中的数据重复，若需要替换系统中数据，请在导入的时候勾选是否删除原有数据选项！";





                //string one_InnerException = "";
                //string two_InnerException = "";
                //if (e.InnerException != null)
                //{
                //    one_InnerException = e.InnerException.Message;

                //    if (e.InnerException.InnerException != null)
                //    {
                //        two_InnerException = e.InnerException.InnerException.Message;
                //    }
                //}

                //result = rule.JsonStr("error", "常规异常信息：【" + e.Message + "】，一级内部异常信息：【" + one_InnerException + "】，二级内部异常信息：【" + two_InnerException + "】，堆栈跟踪信息【" + e.StackTrace + "】", "");



                result = rule.JsonStr("error", "出现错误", "");


            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <param name="deletehistory">是否删除原有数据“是”“否”</param>
        /// <param name="dtTemp">传入的dt</param>
        /// <param name="index">作为总记录数使用</param>
        /// <returns></returns>
        private static int ExecuteEntityContext(string type, string TableID, string deletehistory, DataTable dtTemp, DataTable dt, string fldCityID_Operate, out int index)
        {
            int result = 0;
            index = 0;



            using (EntityContext db = new EntityContext())
            {
                if (type == "eqia_r")
                {
                    List<Mode.tblEQIA_RPI_Basedata_Pre> list = BuildEntity<Mode.tblEQIA_RPI_Basedata_Pre>(dtTemp);

                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIA_RPI_Basedata_Pre
                                    select x;


                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldPCode == item2.fldPCode &&
                                    item.fldSYear == item2.fldSYear &&
                                    item.fldSMonth == item2.fldSMonth &&
                                    item.fldSDay == item2.fldSDay &&
                                    item.fldItemCode == item2.fldItemCode
                                )
                                {
                                    db.tblEQIA_RPI_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();

                    }

                    index = list.Count();
                    db.tblEQIA_RPI_Basedata_Pre.AddRange(list);

                }
                else if (type == "eqia_s")
                {
                    List<tblEQIA_STS_Basedata_Pre> list = BuildEntity<tblEQIA_STS_Basedata_Pre>(dtTemp);

                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIA_STS_Basedata_Pre
                                    select x;


                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldPCode == item2.fldPCode &&
                                    item.fldSYear == item2.fldSYear &&
                                    item.fldSMonth == item2.fldSMonth &&
                                    item.fldSDay == item2.fldSDay &&
                                    item.fldItemCode == item2.fldItemCode
                                )
                                {
                                    db.tblEQIA_STS_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();

                    }

                    index = list.Count();
                    db.tblEQIA_STS_Basedata_Pre.AddRange(list);

                }
                else if (type == "eqin_a")
                {
                    List<tblEQIN_A_BaseData_Pre> list = BuildEntity<tblEQIN_A_BaseData_Pre>(dtTemp);

                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIN_A_BaseData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldGDCODE == item2.fldGDCODE &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour
                                )
                                {
                                    db.tblEQIN_A_BaseData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIN_A_BaseData_Pre.AddRange(list);

                }
                else if (type == "eqin_f")
                {
                    List<tblEQIN_F_BaseData_Pre> list = BuildEntity<tblEQIN_F_BaseData_Pre>(dtTemp);

                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIN_F_BaseData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldPCode == item2.fldPCode &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour
                                )
                                {
                                    db.tblEQIN_F_BaseData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIN_F_BaseData_Pre.AddRange(list);


                }
                else if (type == "eqin_t")
                {
                    List<tblEQIN_T_BaseData_Pre> list = BuildEntity<tblEQIN_T_BaseData_Pre>(dtTemp);

                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIN_T_BaseData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldRDCode == item2.fldRDCode &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour
                                )
                                {
                                    db.tblEQIN_T_BaseData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIN_T_BaseData_Pre.AddRange(list);
                }
                else if (type == "eqin_m")
                {
                    List<tblEQIN_M_BaseData_Pre> list = BuildEntity<tblEQIN_M_BaseData_Pre>(dtTemp);

                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIN_M_BaseData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldPCode == item2.fldPCode &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour
                                )
                                {
                                    db.tblEQIN_M_BaseData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIN_M_BaseData_Pre.AddRange(list);
                }
                else if (type == "eqia_p")
                {
                    List<tblEQIA_PPI_BaseData_Pre> list = BuildEntity<tblEQIA_PPI_BaseData_Pre>(dtTemp);

                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIA_PPI_BaseData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldPCode == item2.fldPCode &&
                                    item.fldSYear == item2.fldSYear &&
                                    item.fldSMonth == item2.fldSMonth &&
                                    item.fldSDay == item2.fldSDay &&
                                    item.fldSHour == item2.fldSHour
                                )
                                {
                                    db.tblEQIA_PPI_BaseData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIA_PPI_BaseData_Pre.AddRange(list);
                }
                else if (type == "eqia_rd")
                {
                    List<tblEQIA_RDPI_Basedata_Pre> list = BuildEntity<tblEQIA_RDPI_Basedata_Pre>(dtTemp);

                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIA_RDPI_Basedata_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldPCode == item2.fldPCode &&
                                    item.fldSYear == item2.fldSYear &&
                                    item.fldSMonth == item2.fldSMonth &&
                                    item.fldSDay == item2.fldSDay &&
                                    item.fldSHour == item2.fldSHour
                                )
                                {
                                    db.tblEQIA_RDPI_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIA_RDPI_Basedata_Pre.AddRange(list);
                }
                else if (type == "eqiw_r")
                {
                    if (TableID == "1")
                    {
                        List<Mode.tblEQIW_R_DevelopmentPace> list = BuildEntity<Mode.tblEQIW_R_DevelopmentPace>(dtTemp);
                        if (deletehistory == "是")
                        {
                            var query = from x in db.tblEQIW_R_DevelopmentPace
                                        select x;


                            foreach (var item in query)
                            {
                                foreach (var item2 in list)
                                {
                                    if
                                    (
                                        item.fldSTName == item2.fldSTName &&
                                        item.fldRName == item2.fldRName &&
                                        item.fldRSName == item2.fldRSName &&
                                        item.上报时间 == item2.上报时间
                                    )
                                    {
                                        db.tblEQIW_R_DevelopmentPace.Remove(item);
                                    }
                                }
                            }
                            db.SaveChanges();
                        }

                        index = list.Count();
                        db.tblEQIW_R_DevelopmentPace.AddRange(list);
                    }
                    else
                    {
                        List<Mode.tblEQIW_R_Basedata_Pre> list = BuildEntity<Mode.tblEQIW_R_Basedata_Pre>(dtTemp);

                        if (deletehistory == "是")
                        {
                            var query = from x in db.tblEQIW_R_Basedata_Pre
                                        select x;

                            foreach (var item in query)
                            {
                                foreach (var item2 in list)
                                {
                                    if
                                    (
                                        item.fldSTCode == item2.fldSTCode &&
                                        item.fldRCode == item2.fldRCode &&
                                        item.fldRSCode == item2.fldRSCode &&
                                        item.fldYear == item2.fldYear &&
                                        item.fldMonth == item2.fldMonth &&
                                        item.fldDay == item2.fldDay &&
                                        item.fldHour == item2.fldHour &&
                                        item.fldMinute == item2.fldMinute &&
                                        item.fldItemCode == item2.fldItemCode &&
                                        item.fldSAMPH == item2.fldSAMPH &&
                                        item.fldSAMPR == item2.fldSAMPR
                                    )
                                    {
                                        db.tblEQIW_R_Basedata_Pre.Remove(item);
                                    }
                                }
                            }

                            db.SaveChanges();
                        }
                        else if (deletehistory == "水华专用")
                        {
                            List<Mode.Model_CQHB.MIS.tblEQIW_R_Section> list_section = new List<Mode.Model_CQHB.MIS.tblEQIW_R_Section>();

                            List<Mode.tblEQIW_R_Basedata_Pre> list_pre_sh = new List<Mode.tblEQIW_R_Basedata_Pre>();

                            List<Mode.tblEQIW_R_Basedata_Pre> list_pre = new List<Mode.tblEQIW_R_Basedata_Pre>();

                            List<Mode.tblEQIW_R_Basedata_Pre> list_pre_2 = new List<Mode.tblEQIW_R_Basedata_Pre>();

                            using (Mode.Model_CQHB.MIS.EntityContext db_CQHB = new Mode.Model_CQHB.MIS.EntityContext())
                            {
                                if (fldCityID_Operate == "2")
                                {
                                    list_section = (from x in db_CQHB.tblEQIW_R_Section
                                                    where x.fldSyncDataSectionInfo != ""
                                                    select x).ToList();
                                }
                                else
                                {
                                    RuleCommon rule = new RuleCommon();

                                    DataTable dtfldSTCode = rule.SqlQueryForDataTatable("LAPContext", "select * from tblFW_RegCity where fldAutoID=" + fldCityID_Operate);
                                    string StrfldSTCode = dtfldSTCode.Rows[0]["fldSTCode"].ToString();

                                    list_section = (from x in db_CQHB.tblEQIW_R_Section
                                                    where x.fldSyncDataSectionInfo != "" &&
                                                    x.fldSTCode == StrfldSTCode
                                                    select x).ToList();
                                }
                            }

                            var query = (from x in db.tblEQIW_R_Basedata_Pre
                                         select x).ToList();


                            List<string> itemlist = new List<string>();
                            itemlist.Add("301");
                            itemlist.Add("463");
                            itemlist.Add("302");
                            itemlist.Add("315");
                            itemlist.Add("501");
                            itemlist.Add("464");
                            itemlist.Add("313");
                            itemlist.Add("466");
                            itemlist.Add("309");
                            itemlist.Add("310");
                            itemlist.Add("314");
                            itemlist.Add("316");
                            itemlist.Add("311");
                            itemlist.Add("327");
                            itemlist.Add("317");
                            itemlist.Add("438");
                            itemlist.Add("437");
                            itemlist.Add("323");
                            itemlist.Add("326");
                            itemlist.Add("330");
                            itemlist.Add("461");
                            itemlist.Add("902");
                            itemlist.Add("362");
                            itemlist.Add("434");
                            itemlist.Add("435");
                            itemlist.Add("318");
                            itemlist.Add("319");
                            itemlist.Add("320");
                            itemlist.Add("436");
                            itemlist.Add("325");
                            itemlist.Add("328");
                            itemlist.Add("467");
                            //itemlist.Add("492");
                            //itemlist.Add("903");



                            foreach (var item in list)
                            {
                                foreach (var item2 in list_section)
                                {
                                    if
                                    (
                                        item.fldSTCode + "." + item.fldRCode + "." + item.fldRSCode == item2.fldSyncDataSectionInfo &&
                                        itemlist.Contains(item.fldItemCode) &&
                                        item.fldYear == item2.fldYear
                                    )
                                    {

                                        Mode.tblEQIW_R_Basedata_Pre temp = new Mode.tblEQIW_R_Basedata_Pre();

                                        temp.fldSTCode = item2.fldSTCode;
                                        temp.fldRCode = item2.fldRCode;
                                        temp.fldRSCode = item2.fldRSCode;

                                        temp.fldSAMPH = item.fldSAMPH;
                                        temp.fldSAMPR = item.fldSAMPR;
                                        temp.fldRSC = item.fldRSC;
                                        temp.fldYear = item.fldYear;
                                        temp.fldMonth = item.fldMonth;
                                        temp.fldDay = item.fldDay;
                                        temp.fldHour = item.fldHour;
                                        temp.fldMinute = item.fldMinute;
                                        temp.fldItemCode = item.fldItemCode;
                                        temp.fldItemValue = item.fldItemValue;
                                        temp.fldFlag = item.fldFlag;
                                        temp.fldImport = item.fldImport;
                                        temp.fldCityID_Operate = item.fldCityID_Operate;
                                        temp.fldCityID_Submit = item.fldCityID_Submit;
                                        temp.fldDate_Operate = item.fldDate_Operate;
                                        temp.fldUserID = item.fldUserID;
                                        temp.fldSource = item.fldSource;
                                        temp.fldBatch = item.fldBatch;
                                        temp.fldDeleteState = item.fldDeleteState;

                                        list_pre_sh.Add(temp);
                                    }
                                }
                            }





                            //foreach (var item in query)
                            //{
                            //    foreach (var item2 in list)
                            //    {
                            //        if
                            //        (
                            //            item.fldSTCode == item2.fldSTCode &&
                            //            item.fldRCode == item2.fldRCode &&
                            //            item.fldRSCode == item2.fldRSCode &&
                            //            item.fldYear == item2.fldYear &&
                            //            item.fldMonth == item2.fldMonth &&
                            //            item.fldDay == item2.fldDay &&
                            //            item.fldHour == item2.fldHour &&
                            //            item.fldMinute == item2.fldMinute &&
                            //            item.fldItemCode == item2.fldItemCode &&
                            //            item.fldSAMPH == item2.fldSAMPH &&
                            //            item.fldSAMPR == item2.fldSAMPR
                            //        )
                            //        {
                            //            db.tblEQIW_R_Basedata_Pre.Remove(item);
                            //        }
                            //    }
                            //}

                            //db.SaveChanges();

                            //db.tblEQIW_R_Basedata_Pre.AddRange(list);

                            //db.SaveChanges();








                            foreach (var item in query)
                            {
                                foreach (var item2 in list_section)
                                {
                                    if
                                    (
                                        item.fldSTCode + "." + item.fldRCode + "." + item.fldRSCode == item2.fldSyncDataSectionInfo
                                    )
                                    {
                                        item.fldSyncDataSectionInfo = item2.fldSyncDataSectionInfo;
                                        list_pre.Add(item);
                                    }




                                    if
                                    (
                                        item.fldSTCode == item2.fldSTCode &&
                                        item.fldRCode == item2.fldRCode &&
                                        item.fldRSCode == item2.fldRSCode
                                    )
                                    {
                                        item.fldSyncDataSectionInfo = item2.fldSyncDataSectionInfo;
                                        list_pre_2.Add(item);
                                    }
                                }
                            }












                            //水华取用国控
                            if (list_pre.Count > 0)
                            {
                                foreach (var item in list_pre)
                                {
                                    foreach (var item2 in list)
                                    {
                                        if
                                        (
                                            item.fldSyncDataSectionInfo == item2.fldSTCode + "." + item2.fldRCode + "." + item2.fldRSCode &&
                                            item.fldSAMPH == item2.fldSAMPH &&
                                            item.fldSAMPR == item2.fldSAMPR &&
                                            item.fldYear == item2.fldYear &&
                                            item.fldMonth == item2.fldMonth &&
                                            item.fldDay == item2.fldDay &&
                                            item.fldHour == item2.fldHour &&
                                            item.fldMinute == item2.fldMinute &&
                                            item.fldItemCode == item2.fldItemCode
                                        )
                                        {
                                            item2.fldItemValue = item.fldItemValue;
                                            db.tblEQIW_R_Basedata_Pre.AddOrUpdate(item);
                                        }
                                    }
                                }






                            }


                            //国控替换水华
                            if (list_pre_2.Count > 0)
                            {
                                foreach (var item in list_pre_2)
                                {
                                    foreach (var item2 in list)
                                    {
                                        if
                                        (
                                            item.fldSyncDataSectionInfo == item2.fldSTCode + "." + item2.fldRCode + "." + item2.fldRSCode &&
                                            item.fldSAMPH == item2.fldSAMPH &&
                                            item.fldSAMPR == item2.fldSAMPR &&
                                            item.fldYear == item2.fldYear &&
                                            item.fldMonth == item2.fldMonth &&
                                            item.fldDay == item2.fldDay &&
                                            item.fldHour == item2.fldHour &&
                                            item.fldMinute == item2.fldMinute &&
                                            item.fldItemCode == item2.fldItemCode
                                        )
                                        {
                                            item.fldItemValue = item2.fldItemValue;
                                        }
                                    }
                                }






                                foreach (var item in query)
                                {
                                    foreach (var item2 in list_pre_2)
                                    {
                                        if
                                        (
                                            item.fldSTCode == item2.fldSTCode &&
                                            item.fldRCode == item2.fldRCode &&
                                            item.fldRSCode == item2.fldRSCode &&
                                            item.fldYear == item2.fldYear &&
                                            item.fldMonth == item2.fldMonth &&
                                            item.fldDay == item2.fldDay &&
                                            item.fldHour == item2.fldHour &&
                                            item.fldMinute == item2.fldMinute &&
                                            item.fldItemCode == item2.fldItemCode &&
                                            item.fldSAMPH == item2.fldSAMPH &&
                                            item.fldSAMPR == item2.fldSAMPR
                                        )
                                        {
                                            db.tblEQIW_R_Basedata_Pre.Remove(item);
                                        }
                                    }
                                }



                                db.SaveChanges();

                                db.tblEQIW_R_Basedata_Pre.AddRange(list_pre_2);

                                db.SaveChanges();

                            }






                            foreach (var item in query)
                            {
                                foreach (var item2 in list)
                                {
                                    if
                                    (
                                        item.fldSTCode == item2.fldSTCode &&
                                        item.fldRCode == item2.fldRCode &&
                                        item.fldRSCode == item2.fldRSCode &&
                                        item.fldYear == item2.fldYear &&
                                        item.fldMonth == item2.fldMonth &&
                                        item.fldDay == item2.fldDay &&
                                        item.fldHour == item2.fldHour &&
                                        item.fldMinute == item2.fldMinute &&
                                        item.fldItemCode == item2.fldItemCode &&
                                        item.fldSAMPH == item2.fldSAMPH &&
                                        item.fldSAMPR == item2.fldSAMPR
                                    )
                                    {
                                        db.tblEQIW_R_Basedata_Pre.Remove(item);
                                    }
                                }
                            }

                            db.SaveChanges();



                            list_pre_sh = (from x in list_pre_sh
                                           select x).DistinctBy(y => new
                                           {
                                               y.fldSTCode,
                                               y.fldRCode,
                                               y.fldRSCode,
                                               y.fldSAMPH,
                                               y.fldSAMPR,
                                               y.fldRSC,
                                               y.fldYear,
                                               y.fldMonth,
                                               y.fldDay,
                                               y.fldHour,
                                               y.fldMinute,
                                               y.fldItemCode
                                           }
                                           ).ToList();





                            foreach (var item in query)
                            {
                                foreach (var item2 in list_pre_sh)
                                {
                                    if
                                    (
                                        item.fldSTCode == item2.fldSTCode &&
                                        item.fldRCode == item2.fldRCode &&
                                        item.fldRSCode == item2.fldRSCode &&
                                        item.fldYear == item2.fldYear &&
                                        item.fldMonth == item2.fldMonth &&
                                        item.fldDay == item2.fldDay &&
                                        item.fldHour == item2.fldHour &&
                                        item.fldMinute == item2.fldMinute &&
                                        item.fldItemCode == item2.fldItemCode &&
                                        item.fldSAMPH == item2.fldSAMPH &&
                                        item.fldSAMPR == item2.fldSAMPR
                                    )
                                    {
                                        db.tblEQIW_R_Basedata_Pre.Remove(item);
                                    }
                                }
                            }

                            db.SaveChanges();






                            list.AddRange(list_pre_sh);





                        }
                        //else
                        //{
                        //    var query = from x in db.tblEQIW_R_Basedata_Pre
                        //                select x;

                        //    List<Mode.tblEQIW_R_Basedata_Pre> dellist = new List<Mode.tblEQIW_R_Basedata_Pre>();

                        //    foreach (var item in query)
                        //    {
                        //        foreach (var item2 in list)
                        //        {
                        //            if
                        //            (
                        //                item.fldSTCode == item2.fldSTCode &&
                        //                item.fldRCode == item2.fldRCode &&
                        //                item.fldRSCode == item2.fldRSCode &&
                        //                item.fldYear == item2.fldYear &&
                        //                item.fldMonth == item2.fldMonth &&
                        //                item.fldDay == item2.fldDay &&
                        //                item.fldHour == item2.fldHour &&
                        //                item.fldMinute == item2.fldMinute &&
                        //                item.fldItemCode == item2.fldItemCode &&
                        //                item.fldSAMPH == item2.fldSAMPH &&
                        //                item.fldSAMPR == item2.fldSAMPR
                        //            )
                        //            {
                        //                dellist.Add(item2);
                        //            }
                        //        }
                        //    }

                        //    foreach (var item in dellist)
                        //    {
                        //        list.Remove(item);
                        //    }



                        //}





                        index = list.Count();
                        db.tblEQIW_R_Basedata_Pre.AddRange(list);





                    }
                }
                else if (type == "eqise")
                {
                    List<Mode.tblEQIW_R_Basedata_Pre> list = BuildEntity<Mode.tblEQIW_R_Basedata_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIW_R_Basedata_Pre
                                    select x;


                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldRCode == item2.fldRCode &&
                                    item.fldRSCode == item2.fldRSCode &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour &&
                                    item.fldMinute == item2.fldMinute &&
                                    item.fldItemCode == item2.fldItemCode &&
                                    item.fldSAMPH == item2.fldSAMPH &&
                                    item.fldSAMPR == item2.fldSAMPR
                                )
                                {
                                    db.tblEQIW_R_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIW_R_Basedata_Pre.AddRange(list);
                }
                else if (type == "eqiw_g")
                {
                    List<tblEQIW_G_Basedata_Pre> list = BuildEntity<tblEQIW_G_Basedata_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIW_G_Basedata_Pre
                                    select x;


                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldPCode == item2.fldPCode &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour &&
                                    item.fldMinute == item2.fldMinute &&
                                    item.fldItemCode == item2.fldItemCode
                                )
                                {
                                    db.tblEQIW_G_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIW_G_Basedata_Pre.AddRange(list);
                }
                else if (type == "eqiw_sts")
                {
                    if (TableID == "1")
                    {
                        List<tblEQIW_STS_Data> list = new List<tblEQIW_STS_Data>();

                        List<tblEQIW_R_Item> item_list = new List<tblEQIW_R_Item>();
                        item_list = (from x in db.tblEQIW_R_Item
                                     select x).ToList();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQIW_STS_Data data = new tblEQIW_STS_Data();

                            data.fldNumber = int.Parse(item["序号"].ToString());
                            data.fldTaskName = item["课题名称"].ToString();
                            data.fldSTName = item["所属区县名称"].ToString();
                            data.fldRName = item["所在河流名称"].ToString();
                            data.fldRSName = item["点位名称"].ToString();
                            data.fldDate = DateTime.Parse(item["时间"].ToString());
                            data.fldSAMPH = item["水平向代码"].ToString();
                            data.fldSAMPR = item["垂直向代码"].ToString();

                            list.Add(data);
                            db.tblEQIW_STS_Data.Add(data);
                            db.SaveChanges();

                            // 因子表相关操作
                            List<tblEQIW_STS_Data_Item> data_item_list = new List<tblEQIW_STS_Data_Item>();

                            foreach (var item2 in item_list)
                            {
                                if (item.Table.Columns.Contains(item2.fldItemName))
                                {
                                    if (item[item2.fldItemName].ToString() == "-1")
                                    {
                                        continue;
                                    }

                                    if (item[item2.fldItemName].ToString().Contains("L"))
                                    {
                                        item[item2.fldItemName] = "-" + item[item2.fldItemName].ToString().TrimEnd('L');
                                    }


                                    tblEQIW_STS_Data_Item data_item = new tblEQIW_STS_Data_Item();

                                    data_item.fldFKID = data.fldAutoID;

                                    data_item.fldItemCode = item2.fldItemCode;
                                    data_item.fldItemName = item2.fldItemName;
                                    data_item.Value = decimal.Parse(item[item2.fldItemName].ToString());

                                    data_item_list.Add(data_item);
                                }
                            }

                            db.tblEQIW_STS_Data_Item.AddRange(data_item_list);
                        }
                    }
                    else
                    {
                        List<tblEQIW_STS_Basedata_Pre> list = BuildEntity<tblEQIW_STS_Basedata_Pre>(dtTemp);
                        if (deletehistory == "是")
                        {
                            var query = from x in db.tblEQIW_STS_Basedata_Pre
                                        select x;


                            foreach (var item in query)
                            {
                                foreach (var item2 in list)
                                {
                                    if
                                    (
                                        item.fldSTCode == item2.fldSTCode &&
                                        item.fldRCode == item2.fldRCode &&
                                        item.fldYear == item2.fldYear &&
                                        item.fldMonth == item2.fldMonth &&
                                        item.fldDay == item2.fldDay &&
                                        item.fldHour == item2.fldHour &&
                                        item.fldMinute == item2.fldMinute &&
                                        item.fldItemCode == item2.fldItemCode
                                    )
                                    {
                                        db.tblEQIW_STS_Basedata_Pre.Remove(item);
                                    }
                                }
                            }
                            db.SaveChanges();
                        }

                        index = list.Count();
                        db.tblEQIW_STS_Basedata_Pre.AddRange(list);

                    }
                }
                else if (type == "eqiw_d")
                {
                    List<Mode.tblEQIW_D_Basedata_Pre> list = BuildEntity<Mode.tblEQIW_D_Basedata_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIW_D_Basedata_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldRCode == item2.fldRCode &&
                                    item.fldRSCode == item2.fldRSCode &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour &&
                                    item.fldMinute == item2.fldMinute &&
                                    item.fldItemCode == item2.fldItemCode
                                )
                                {
                                    db.tblEQIW_D_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIW_D_Basedata_Pre.AddRange(list);
                }
                else if (type == "eqiw_dt")
                {
                    List<tblEQIW_DT_Basedata_Pre> list = BuildEntity<tblEQIW_DT_Basedata_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIW_DT_Basedata_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldRCode == item2.fldRCode &&
                                    item.fldRSCode == item2.fldRSCode &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour &&
                                    item.fldMinute == item2.fldMinute &&
                                    item.fldItemCode == item2.fldItemCode
                                )
                                {
                                    db.tblEQIW_DT_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIW_DT_Basedata_Pre.AddRange(list);
                }
                else if (type == "eqiw_dx")
                {
                    List<tbleqiw_dx_Basedata_Pre> list = BuildEntity<tbleqiw_dx_Basedata_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tbleqiw_dx_Basedata_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldRCode == item2.fldRCode &&
                                    item.fldRSCode == item2.fldRSCode &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour &&
                                    item.fldMinute == item2.fldMinute &&
                                    item.fldItemCode == item2.fldItemCode
                                )
                                {
                                    db.tbleqiw_dx_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tbleqiw_dx_Basedata_Pre.AddRange(list);

                }
                else if (type == "eqiso")
                {
                    List<Mode.tblEQISO_Basedata_Pre> list = BuildEntity<Mode.tblEQISO_Basedata_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQISO_Basedata_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldPCode == item2.fldPCode &&
                                    item.fldSampleType == item2.fldSampleType &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour &&
                                    item.fldMinute == item2.fldMinute &&
                                    item.fldItemCode == item2.fldItemCode
                                )
                                {
                                    db.tblEQISO_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQISO_Basedata_Pre.AddRange(list);
                }
                else if (type == "eqie")
                {
                    List<tblEQIE_BaseData_Pre> list = BuildEntity<tblEQIE_BaseData_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIE_BaseData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    db.tblEQIE_BaseData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIE_BaseData_Pre.AddRange(list);
                }
                else if (type == "eqie_f")
                {
                    List<tblEQIE_FunData_Pre> list = BuildEntity<tblEQIE_FunData_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIE_FunData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    db.tblEQIE_FunData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIE_FunData_Pre.AddRange(list);
                }
                else if (type == "eqie_c")
                {
                    List<tblEQIE_CityData_Pre> list = BuildEntity<tblEQIE_CityData_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIE_CityData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    db.tblEQIE_CityData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIE_CityData_Pre.AddRange(list);
                }
                else if (type == "eqib_czp")
                {
                    List<tblEQIBCZPBaseData_Pre> list = BuildEntity<tblEQIBCZPBaseData_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIBCZPBaseData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    db.tblEQIBCZPBaseData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIBCZPBaseData_Pre.AddRange(list);
                }
                else if (type == "eqib_czc")
                {
                    List<tblEQIBCZCBaseData_Pre> list = BuildEntity<tblEQIBCZCBaseData_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIBCZCBaseData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    db.tblEQIBCZCBaseData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIBCZCBaseData_Pre.AddRange(list);
                }
                else if (type == "eqib_cd")
                {
                    List<tblEQIBCDBaseData_Pre> list = BuildEntity<tblEQIBCDBaseData_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIBCDBaseData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    db.tblEQIBCDBaseData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIBCDBaseData_Pre.AddRange(list);
                }
                else if (type == "eqib_cwc")
                {
                    List<tblEQIBCWCBaseData_Pre> list = BuildEntity<tblEQIBCWCBaseData_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIBCWCBaseData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    db.tblEQIBCWCBaseData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIBCWCBaseData_Pre.AddRange(list);
                }
                else if (type == "eqib_cwp")
                {
                    List<tblEQIBCWPBaseData_Pre> list = BuildEntity<tblEQIBCWPBaseData_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQIBCWPBaseData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    db.tblEQIBCWPBaseData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQIBCWPBaseData_Pre.AddRange(list);
                }
                else if (type == "eqid_d")
                {
                    List<tblEQID_D_BaseData_Pre> list = BuildEntity<tblEQID_D_BaseData_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in db.tblEQID_D_BaseData_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    db.tblEQID_D_BaseData_Pre.Remove(item);
                                }
                            }
                        }
                        db.SaveChanges();
                    }

                    index = list.Count();
                    db.tblEQID_D_BaseData_Pre.AddRange(list);
                }

                result = db.SaveChanges();
            }


            if (type == "eqia_r_v")
            {
                using (VEntityContext Vdb = new VEntityContext())
                {
                    List<tblEQIA_RPI_Basedata_V_Pre> list = BuildEntity<tblEQIA_RPI_Basedata_V_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in Vdb.tblEQIA_RPI_Basedata_V_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    Vdb.tblEQIA_RPI_Basedata_V_Pre.Remove(item);
                                }
                            }
                        }
                        Vdb.SaveChanges();
                    }

                    index = list.Count();
                    Vdb.tblEQIA_RPI_Basedata_V_Pre.AddRange(list);
                    result = Vdb.SaveChanges();
                }
            }
            else if (type == "eqiw_r_v")
            {
                using (VEntityContext Vdb = new VEntityContext())
                {
                    List<tblEQIW_R_Basedata_V_Pre> list = BuildEntity<tblEQIW_R_Basedata_V_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in Vdb.tblEQIW_R_Basedata_V_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    Vdb.tblEQIW_R_Basedata_V_Pre.Remove(item);
                                }
                            }
                        }
                        Vdb.SaveChanges();
                    }

                    index = list.Count();
                    Vdb.tblEQIW_R_Basedata_V_Pre.AddRange(list);
                    result = Vdb.SaveChanges();
                }

            }
            else if (type == "eqiw_d_v")
            {
                using (VEntityContext Vdb = new VEntityContext())
                {
                    List<tblEQIW_D_Basedata_V_Pre> list = BuildEntity<tblEQIW_D_Basedata_V_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in Vdb.tblEQIW_D_Basedata_V_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    Vdb.tblEQIW_D_Basedata_V_Pre.Remove(item);
                                }
                            }
                        }
                        Vdb.SaveChanges();
                    }

                    index = list.Count();
                    Vdb.tblEQIW_D_Basedata_V_Pre.AddRange(list);
                    result = Vdb.SaveChanges();
                }
            }
            else if (type == "eqiso_v")
            {
                using (VEntityContext Vdb = new VEntityContext())
                {
                    List<tblEQISO_Basedata_V_Pre> list = BuildEntity<tblEQISO_Basedata_V_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in Vdb.tblEQISO_Basedata_V_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    Vdb.tblEQISO_Basedata_V_Pre.Remove(item);
                                }
                            }
                        }
                        Vdb.SaveChanges();
                    }
                    index = list.Count();
                    Vdb.tblEQISO_Basedata_V_Pre.AddRange(list);
                    result = Vdb.SaveChanges();
                }
            }
            else if (type == "eqib_v")
            {
                using (VEntityContext Vdb = new VEntityContext())
                {
                    List<tbl_EQIB_BaseData_V_Pre> list = BuildEntity<tbl_EQIB_BaseData_V_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in Vdb.tbl_EQIB_BaseData_V_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    Vdb.tbl_EQIB_BaseData_V_Pre.Remove(item);
                                }
                            }
                        }
                        Vdb.SaveChanges();
                    }
                    index = list.Count();
                    Vdb.tbl_EQIB_BaseData_V_Pre.AddRange(list);
                    result = Vdb.SaveChanges();
                }
            }
            else if (type == "eqiw_ws_v")
            {
                using (VEntityContext Vdb = new VEntityContext())
                {
                    List<tblEQIW_WS_Basedata_V_Pre> list = BuildEntity<tblEQIW_WS_Basedata_V_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in Vdb.tblEQIW_WS_Basedata_V_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldYear == item2.fldYear
                                )
                                {
                                    Vdb.tblEQIW_WS_Basedata_V_Pre.Remove(item);
                                }
                            }
                        }
                        Vdb.SaveChanges();
                    }
                    index = list.Count();
                    Vdb.tblEQIW_WS_Basedata_V_Pre.AddRange(list);
                    result = Vdb.SaveChanges();
                }
            }


            if (type == "eqia_r_hm")
            {
                using (HMEntityContext HMdb = new HMEntityContext())
                {
                    List<Mode.重金属.tblEQIA_RPI_Basedata_Pre> list = BuildEntity<Mode.重金属.tblEQIA_RPI_Basedata_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in HMdb.tblEQIA_RPI_Basedata_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldPCode == item2.fldPCode &&
                                    item.fldSYear == item2.fldSYear &&
                                    item.fldSMonth == item2.fldSMonth &&
                                    item.fldSDay == item2.fldSDay &&
                                    item.fldItemCode == item2.fldItemCode
                                )
                                {
                                    HMdb.tblEQIA_RPI_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        HMdb.SaveChanges();
                    }

                    index = list.Count();
                    HMdb.tblEQIA_RPI_Basedata_Pre.AddRange(list);
                    result = HMdb.SaveChanges();
                }
            }
            else if (type == "eqiw_r_hm")
            {
                using (HMEntityContext HMdb = new HMEntityContext())
                {
                    List<Mode.重金属.tblEQIW_R_Basedata_Pre> list = BuildEntity<Mode.重金属.tblEQIW_R_Basedata_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in HMdb.tblEQIW_R_Basedata_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldRCode == item2.fldRCode &&
                                    item.fldRSCode == item2.fldRSCode &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour &&
                                    item.fldMinute == item2.fldMinute &&
                                    item.fldItemCode == item2.fldItemCode
                                )
                                {
                                    HMdb.tblEQIW_R_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        HMdb.SaveChanges();
                    }

                    index = list.Count();
                    HMdb.tblEQIW_R_Basedata_Pre.AddRange(list);
                    result = HMdb.SaveChanges();
                }
            }
            else if (type == "eqiw_d_hm")
            {
                using (HMEntityContext HMdb = new HMEntityContext())
                {
                    List<Mode.重金属.tblEQIW_D_Basedata_Pre> list = BuildEntity<Mode.重金属.tblEQIW_D_Basedata_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in HMdb.tblEQIW_D_Basedata_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldRCode == item2.fldRCode &&
                                    item.fldRSCode == item2.fldRSCode &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour &&
                                    item.fldMinute == item2.fldMinute &&
                                    item.fldItemCode == item2.fldItemCode
                                )
                                {
                                    HMdb.tblEQIW_D_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        HMdb.SaveChanges();
                    }

                    index = list.Count();
                    HMdb.tblEQIW_D_Basedata_Pre.AddRange(list);
                    result = HMdb.SaveChanges();
                }
            }
            else if (type == "eqiso_hm")
            {
                using (HMEntityContext HMdb = new HMEntityContext())
                {
                    List<Mode.重金属.tblEQISO_Basedata_Pre> list = BuildEntity<Mode.重金属.tblEQISO_Basedata_Pre>(dtTemp);
                    if (deletehistory == "是")
                    {
                        var query = from x in HMdb.tblEQISO_Basedata_Pre
                                    select x;

                        foreach (var item in query)
                        {
                            foreach (var item2 in list)
                            {
                                if
                                (
                                    item.fldSTCode == item2.fldSTCode &&
                                    item.fldPCode == item2.fldPCode &&
                                    item.fldSampleType == item2.fldSampleType &&
                                    item.fldYear == item2.fldYear &&
                                    item.fldMonth == item2.fldMonth &&
                                    item.fldDay == item2.fldDay &&
                                    item.fldHour == item2.fldHour &&
                                    item.fldMinute == item2.fldMinute &&
                                    item.fldItemCode == item2.fldItemCode
                                )
                                {
                                    HMdb.tblEQISO_Basedata_Pre.Remove(item);
                                }
                            }
                        }
                        HMdb.SaveChanges();
                    }

                    index = list.Count();
                    HMdb.tblEQISO_Basedata_Pre.AddRange(list);
                    result = HMdb.SaveChanges();
                }
            }


            return result;
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
            /// 表的ID
            /// </summary>
            public string fldAutoID { get; set; }

            /// <summary>
            /// 表的完整路径
            /// </summary>
            public string path { get; set; }

            /// <summary>
            /// 提交城市的ID
            /// </summary>
            public string fldCityID_Submit { get; set; }

            /// <summary>
            /// 当前操作城市的ID
            /// </summary>
            public string fldCityID_Operate { get; set; }

            /// <summary>
            /// 用户ID
            /// </summary>
            public string fldUserID { get; set; }


            /// <summary>
            /// “是”：删除原有数据，输入新数据
            /// “水华专用”：兼容 [国控-水华] [水华-国控] 方向性智能转换，最终以国控为准
            /// 其他任意值：不替换已经上报的数据
            /// </summary>
            public string deletehistory { get; set; }

            /// <summary>
            /// json配置的地址
            /// </summary>
            public string jsonpath { get; set; }



            /// <summary>
            /// type = "eqiw_r"与此参数为"1"的情况下，导入 水质自动站建设进度上报模板 表，数据库表名称为 tblEQIW_R_DevelopmentPace
            /// type = "eqiw_sts"和此参数为"1"的情况下，为地表水专项，主表为tblEQIW_STS_Data，因子数据表为tblEQIW_STS_Data_Item
            /// </summary>
            public string TableID { get; set; }

        }


        /// <summary>
        /// NPOI将Excel对象转为DataTabel
        /// </summary>
        /// <param name="TitleRow">需要作为标题的行，默认是第0行</param>
        /// <param name="DeleteRows">删除行的列表</param>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        private static DataTable ExcelConvertDataTable(string TitleRow, string DeleteRows, string path)
        {
            IWorkbook workbook = null;
            ISheet sheet = null;

            DataTable dt = new DataTable();

            // 2007以上
            if (path.IndexOf(".xlsx") > 0)
            {
                workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
                sheet = workbook.GetSheetAt(0);
            }
            else if (path.IndexOf(".xls") > 0)
            {
                workbook = new HSSFWorkbook(File.Open(path, FileMode.Open));
                sheet = workbook.GetSheetAt(0);
            }

            int title = int.Parse(TitleRow);

            IRow headRow = sheet.GetRow(title);

            for (int i = headRow.FirstCellNum, len = headRow.LastCellNum; i < len; i++)
            {
                dt.Columns.Add(headRow.Cells[i].StringCellValue.Trim());
            }






            //int rowsCount = sheet.PhysicalNumberOfRows;

            //int colsCount = sheet.GetRow(0).PhysicalNumberOfCells;


            //for (int i = 0; i < colsCount; i++)
            //{
            //    dt.Columns.Add(sheet.GetRow(title).GetCell(i).ToString().Trim());
            //}












            ////遍历数据行
            //for (int i = (sheet.FirstRowNum + 1), len = sheet.LastRowNum + 1; i < len; i++)
            //{
            //    IRow tempRow = sheet.GetRow(i);
            //    DataRow dataRow = dt.NewRow();

            //    //遍历一行的每一个单元格
            //    for (int r = 0, j = tempRow.FirstCellNum, len2 = tempRow.LastCellNum; j < len2; j++, r++)
            //    {

            //        ICell cell = tempRow.GetCell(j);

            //        if (cell != null)
            //        {
            //            switch (cell.CellType)
            //            {
            //                case CellType.STRING:
            //                    dataRow[r] = cell.StringCellValue;
            //                    break;
            //                case CellType.NUMERIC:
            //                    dataRow[r] = cell.NumericCellValue;
            //                    break;
            //                case CellType.BOOLEAN:
            //                    dataRow[r] = cell.BooleanCellValue;
            //                    break;
            //                default:
            //                    dataRow[r] = "ERROR";
            //                    break;
            //            }
            //        }
            //    }
            //    dt.Rows.Add(dataRow);
            //}








            for (int i = title + 1; i < sheet.LastRowNum + 1; i++)
            {
                IRow tempRow = sheet.GetRow(i);
                DataRow dr = dt.NewRow();




                for (int r = 0, j = tempRow.FirstCellNum, len2 = tempRow.LastCellNum; j < len2; j++, r++)
                {
                    ICell cell = tempRow.GetCell(j);

                    if (cell == null)
                    {
                        dr[r] = "";
                    }
                    else if (cell.CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(cell))
                    {
                        dr[r] = cell.DateCellValue.ToString().Trim();
                    }
                    else
                    {
                        dr[r] = cell.ToString().Trim();
                    }
                }





                dt.Rows.Add(dr);
            }






            sheet = null;
            workbook = null;


            //根据配置表中DeleteRows字段删除行，标题行下面是第0行
            if (DeleteRows != "")
            {
                int delCount = 0;
                foreach (var item in DeleteRows.Split(','))
                {
                    int num = int.Parse(item) - delCount;
                    dt.Rows.RemoveAt(num);
                    delCount++;
                }
            }






            List<DataRow> removelist = new List<DataRow>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsNull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {
                        IsNull = false;
                    }
                }
                if (IsNull)
                {
                    removelist.Add(dt.Rows[i]);
                }
            }

            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }





            return dt;
        }


        /// <summary>
        /// 反射方法
        /// </summary>
        /// <typeparam name="T">检查类库</typeparam>
        /// <param name="methodName">方法名称</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        private static object InvokeMethod<T>(string methodName, params object[] parameters)
        {
            Type type = typeof(T);
            object obj = Activator.CreateInstance(type);
            MethodInfo mi = type.GetMethod(methodName);
            return mi.Invoke(obj, parameters);
        }


        /// <summary>
        /// 构建实体集合
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="dtTemp">传入的DataTable</param>
        /// <returns></returns>
        private static List<T> BuildEntity<T>(DataTable dtTemp)
        {
            List<T> list = new List<T>();

            Type classtype = typeof(T);

            foreach (DataRow item in dtTemp.Rows)
            {
                object obj = Activator.CreateInstance(classtype);

                foreach (PropertyInfo item1 in classtype.GetProperties())
                {
                    Type PI = item1.PropertyType;

                    if (PI.IsGenericType && PI.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        PI = PI.GetGenericArguments()[0];
                    }

                    if (dtTemp.Columns.Contains(item1.Name))
                    {
                        item1.SetValue(obj, Convert.ChangeType(item[item1.Name], PI), null);
                    }
                    else
                    {
                        if (PI == typeof(DateTime))
                        {
                            item1.SetValue(obj, Convert.ChangeType(DateTime.Now, PI), null);
                        }
                        else if (PI == typeof(bool))
                        {
                            item1.SetValue(obj, Convert.ChangeType(false, PI), null);
                        }
                        else
                        {
                            item1.SetValue(obj, Convert.ChangeType("0", PI), null);
                        }
                    }
                }
                list.Add((T)obj);
            }
            return list;
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






        private DataTable GetItemTable(string type)
        {
            string ItemTableName = null;

            DataTable dtItem = null;

            if
            (
                type == "eqiw_r" ||
                type == "eqiw_l" ||
                type == "eqiw_d" ||
                type == "eqiw_dt" ||
                type == "eqiw_dx" ||
                type == "eqiw_sts" ||
                type == "eqise" ||
                type == "eqiw_g"
            )
            {
                ItemTableName = "tblEQIW_R_Item";
            }
            else if (type == "eqia_p")
            {
                ItemTableName = "tblEQIA_P_Item";
            }



            if (ItemTableName != null)
            {
                dtItem = rule.SqlQueryForDataTatable("EntityContext", "select * from " + ItemTableName);
            }

            return dtItem;
        }












        private static T GetFileJson<T>(string filepath)
        {
            string json = string.Empty;

            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    json = sr.ReadToEnd();
                }
            }
            return JsonConvert.DeserializeObject<T>(json);
        }






        public class fldRSCode_Map
        {
            /// <summary>
            /// 国家的代码
            /// </summary>
            public string fldRSCode_Country { get; set; }

            /// <summary>
            /// 系统的代码
            /// </summary>
            public string fldRSCode_System { get; set; }
        }


        public class ItemName_Map
        {
            /// <summary>
            /// 国家的
            /// </summary>
            public string ItemName_Country { get; set; }

            /// <summary>
            /// 系统的
            /// </summary>
            public string ItemName_System { get; set; }
        }





        public class UnitConverter_Data
        {
            public string ItemName { get; set; }

            public List<string> UnitConverter { get; set; }
        }


















    }
}










/// <summary>
/// Linq扩展方法
/// </summary>
public static class Distinct
{
    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        HashSet<TKey> seenKeys = new HashSet<TKey>();
        foreach (TSource element in source)
        {
            if (seenKeys.Add(keySelector(element)))
            {
                yield return element;
            }
        }
    }
}









/// <summary>
/// 检查类库
/// </summary>
public class VerificationRunTime
{

    RuleCommon rule = new RuleCommon();


    /// <summary>
    /// 检查时间是否是有效的日期
    /// </summary>
    /// <param name="type"></param>
    /// <param name="dr"></param>
    /// <param name="ColName"></param>
    /// <returns></returns>
    public string CheckIsDate(string type, DataRow dr, string ColName, string TableID)
    {
        DateTime result = new DateTime();
        string info = null;
        string[] temp = ColName.Split('-');
        foreach (var item in temp)
        {
            if (!(DateTime.TryParse(dr[item].ToString(), out result)))
            {
                if (type == "eqiw_r" && TableID == "1")
                {
                    if (dr["建设情况"].ToString() == "已建")
                    {
                        if (item.Contains("已建水站"))
                        {
                            info += "[" + item + "：" + dr[item].ToString() + "]不是有效的时间。";
                        }
                    }

                    if (dr["建设情况"].ToString() == "新建")
                    {
                        if (item.Contains("新建水站"))
                        {
                            info += "[" + item + "：" + dr[item].ToString() + "]不是有效的时间。";
                        }
                    }
                }
                else
                {
                    info += "[" + item + "：" + dr[item].ToString() + "]不是有效的时间。";
                }
            }
        }
        return info;
    }
















    /// <summary>
    /// 检查是否是数字。
    /// 如果值中有带L的数据，那么就跳过
    /// </summary>
    /// <param name="type"></param>
    /// <param name="dr"></param>
    /// <param name="ColName"></param>
    /// <returns></returns>
    public Object_Return CheckIsDouble(string type, DataRow dr, string ColName)
    {
        Object_Return data = new Object_Return();

        string ErrorInfo = null;
        string ColorInfo = null;
        double result = new double();
        string[] temp = ColName.Split('|');

        foreach (var item in temp)
        {
            if (dr.Table.Columns.Contains(item))
            {
                if (!(dr[item].ToString().Contains("L")) && !(dr[item].ToString() == ""))
                {
                    if (!(double.TryParse(dr[item].ToString(), out result)))
                    {
                        ErrorInfo += "[" + item + "：" + dr[item].ToString() + "]不是有效的数字。";
                        ColorInfo += item + ",";
                    }
                }
            }
        }

        data.ErrorInfo = ErrorInfo;
        if (ColorInfo != null)
        {
            data.ColorInfo = ColorInfo.TrimEnd(',');
        }

        return data;
    }







    /// <summary>
    /// 检查是否是数字。
    /// 如果值中有带L的数据，那么就跳过
    /// </summary>
    /// <param name="type"></param>
    /// <param name="dr"></param>
    /// <param name="ColName"></param>
    /// <returns></returns>
    public Object_Return CheckIsDouble_V2(string type, DataRow dr, string ColName)
    {
        Object_Return data = new Object_Return();

        string ErrorInfo = null;
        string ColorInfo = null;
        double result = new double();
        string[] temp = ColName.Split('|');

        foreach (var item in temp)
        {
            if (dr.Table.Columns.Contains(item))
            {
                if (!(dr[item].ToString().Contains("L")))
                {
                    if (dr[item].ToString() == "-1" || dr[item].ToString() == "")
                    {
                        if (!(item == "水位" || item == "电导率" || item == "透明度" || item == "叶绿素a" || item == "化学需氧量"))
                        {
                            ErrorInfo += "[" + item + "：" + dr[item].ToString() + "]空值和-1都是不允许的。";
                            ColorInfo += item + ",";
                        }
                    }
                    else
                    {
                        if (!(double.TryParse(dr[item].ToString(), out result)))
                        {
                            ErrorInfo += "[" + item + "：" + dr[item].ToString() + "]不是有效的数字。";
                            ColorInfo += item + ",";
                        }
                    }
                }
            }
        }

        data.ErrorInfo = ErrorInfo;
        if (ColorInfo != null)
        {
            data.ColorInfo = ColorInfo.TrimEnd(',');
        }

        return data;
    }







    public class Object_Return
    {
        public string ErrorInfo { get; set; }

        public string ColorInfo { get; set; }
    }










    /// <summary>
    /// 【点位一致性检查】
    /// </summary>
    /// <param name="type">业务类型</param>
    /// <param name="dr">需要检查的行</param>
    /// <param name="ColName">需要检查的列</param>
    /// <returns></returns>
    public string CheckCityAndPoint(string type, DataRow dr, string ColName)
    {
        string[] col = ColName.Split('-');
        string info = null;

        using (EntityContext db = new EntityContext())
        {
            if (type == "eqia_r")
            {
                DateTime date = new DateTime();
                if (DateTime.TryParse(dr[col[2]].ToString(), out date))
                {
                }
                var query = db.tblEQIA_R_Point.Where
                (
                    x =>
                    x.fldSTCode == dr[col[0]].ToString() &&
                    x.fldPCode == dr[col[1]].ToString() &&
                    x.fldYear == date.Year
                );
                if (query.Count() == 0)
                {
                    info = "[" + col[0] + "：" + dr[col[0]].ToString() + "]";
                    info += "[" + col[1] + "：" + dr[col[1]].ToString() + "]";
                    info += "[" + col[2] + "：" + dr[col[2]].ToString() + "]";
                    info += "未能查询到此点位！";
                }

            }
            else if (type == "eqia_p")
            {
                DateTime date = new DateTime();
                if (DateTime.TryParse(dr[col[2]].ToString(), out date))
                {
                }
                var query2 = db.tblEQIA_P_Point.Where
                (
                    x =>
                    x.fldSTCode == dr[col[0]].ToString() &&
                    x.fldPCode == dr[col[1]].ToString() &&
                    x.fldYear == date.Year
                );
                if (query2.Count() == 0)
                {
                    info = "[" + col[0] + "：" + dr[col[0]].ToString() + "]";
                    info += "[" + col[1] + "：" + dr[col[1]].ToString() + "]";
                    info += "[" + col[2] + "：" + dr[col[2]].ToString() + "]";
                    info += "未能查询到此点位！";
                }

            }
            else if (type == "eqiw_r" || type == "eqiw_l")
            {
                DateTime date = new DateTime();
                int Year = 0;
                if (DateTime.TryParse(dr[col[3]].ToString(), out date))
                {
                    Year = date.Year;
                }

                string fldSTCode = dr[col[0]].ToString();
                string fldRCode = dr[col[1]].ToString();
                string fldRSCode = dr[col[2]].ToString();

                DataTable dt = rule.SqlQueryForDataTatable("EntityContext", "select * from tblEQIW_R_Section");



                var query = (from x in dt.AsEnumerable()
                             where x["fldSTCode"].ToString() == fldSTCode &&
                             x["fldRCode"].ToString() == fldRCode &&
                             x["fldRSCode"].ToString() == fldRSCode &&
                             x["fldYear"].ToString() == Year.ToString()
                             select x).ToList();

                if (query.Count() == 0)
                {
                    info = "[" + col[0] + "：" + dr[col[0]].ToString() + "]";
                    info += "[" + col[1] + "：" + dr[col[1]].ToString() + "]";
                    info += "[" + col[2] + "：" + dr[col[2]].ToString() + "]";
                    info += "[" + col[3] + "：" + dr[col[3]].ToString() + "]";
                    info += "未能查询到此点位！";
                }

            }
            else if (type == "eqiw_d")
            {
                DateTime date = new DateTime();
                int Year = 0;
                if (DateTime.TryParse(dr[col[3]].ToString(), out date))
                {
                    Year = date.Year;
                }

                string fldSTCode = dr[col[0]].ToString();
                string fldRCode = dr[col[1]].ToString();
                string fldRSCode = dr[col[2]].ToString();

                DataTable dt = rule.SqlQueryForDataTatable("EntityContext", "select * from tblEQIW_D_Section");



                var query = (from x in dt.AsEnumerable()
                             where x["fldSTCode"].ToString() == fldSTCode &&
                             x["fldRCode"].ToString() == fldRCode &&
                             x["fldRSCode"].ToString() == fldRSCode &&
                             x["fldYear"].ToString() == Year.ToString()
                             select x).ToList();

                if (query.Count() == 0)
                {
                    info = "[" + col[0] + "：" + dr[col[0]].ToString() + "]";
                    info += "[" + col[1] + "：" + dr[col[1]].ToString() + "]";
                    info += "[" + col[2] + "：" + dr[col[2]].ToString() + "]";
                    info += "[" + col[3] + "：" + dr[col[3]].ToString() + "]";
                    info += "未能查询到此点位！";
                }
            }
            else if (type == "eqin_f")
            {
                DateTime date = new DateTime();
                if (DateTime.TryParse(dr[col[3]].ToString(), out date))
                {
                }


                string fldSTCode = dr[col[0]].ToString();
                string fldPCode = dr[col[1]].ToString();
                string fldNDISC = dr[col[2]].ToString();


                var query = from x in db.tblEQIN_F_Point
                            where x.fldSTCode == fldSTCode &&
                            x.fldPCode == fldPCode &&
                            x.fldNDISC == fldNDISC &&
                            x.fldYear == date.Year
                            select x;


                if (query.Count() == 0)
                {
                    info = "[" + col[0] + "：" + dr[col[0]].ToString() + "]";
                    info += "[" + col[1] + "：" + dr[col[1]].ToString() + "]";
                    info += "[" + col[2] + "：" + dr[col[2]].ToString() + "]";
                    info += "[" + col[3] + "：" + dr[col[3]].ToString() + "]";
                    info += "未能查询到此点位！";
                }
            }



        }
        return info;
    }






    /// <summary>
    /// 检查24小时数据
    /// </summary>
    /// <param name="type"></param>
    /// <param name="dt"></param>
    /// <param name="ColName"></param>
    /// <returns></returns>
    public DataTable Check24Hour(string type, DataTable dt, string ColName)
    {
        string[] temp = ColName.Split('-');

        string query = null;

        foreach (DataRow item in dt.Rows)
        {
            foreach (var item2 in temp)
            {
                query += item2 + "='" + item[item2].ToString() + "' and ";
            }
            query = query.TrimEnd(' ', 'd', 'n', 'a');

            DataRow[] dr = dt.Select(query);

            if (dr.Count() != 24)
            {
                item["错误信息"] += "并非24小时数据！";
            }
        }
        return dt;
    }













    /// <summary>
    /// 检查Excel中数据是否重复
    /// </summary>
    /// <param name="type"></param>
    /// <param name="dr"></param>
    /// <param name="ColName"></param>
    /// <returns></returns>
    public DataTable CheckData(string type, DataTable dt, string ColName)
    {
        string[] temp = ColName.Split('-');

        string query = null;

        foreach (DataRow item in dt.Rows)
        {
            foreach (var item2 in temp)
            {
                query += item2 + "='" + item[item2].ToString() + "' and ";
            }
            query = query.TrimEnd(' ', 'd', 'n', 'a');

            DataRow[] dr = dt.Select(query);

            if (dr.Count() > 1)
            {
                item["错误信息"] += "数据重复！";
            }

            query = null;
        }
        return dt;
    }













    /// <summary>
    /// 检查Excel中项目名称是否存在于数据库中Item表
    /// </summary>
    /// <param name="dr"></param>
    /// <param name="dtItem"></param>
    /// <param name="ColName"></param>
    /// <returns></returns>
    public string CheckItemName(DataRow dr, DataTable dtItem, string ColName)
    {
        string info = null;

        List<string> list = ColName.Split('-').ToList();

        foreach (DataColumn item in dr.Table.Columns)
        {
            if (!(list.Contains(item.ColumnName)))
            {
                var query1 = (from x in dtItem.AsEnumerable()
                              where x["fldItemName"].ToString() == item.ColumnName
                              select x).ToList();

                if (query1.Count == 0 || query1 == null)
                {
                    info += "[" + item.ColumnName + "：为未知的项目名称！]";
                }
            }
        }
        return info;
    }










    /// <summary>
    /// 【点位完整性检查】
    /// </summary>
    /// <param name="type">业务类型</param>
    /// <param name="query">日期字段</param>
    /// <param name="dt">Excel中的数据</param>
    /// <param name="ColName">需要处理的列名称</param>
    /// <param name="cityid"></param>
    /// <returns></returns>
    public DataTable CheckExcel_PointIntegrity(string type, JToken query, DataTable dt, string ColName, string cityid)
    {
        var query2 = (from x in dt.AsEnumerable()
                      select x[query["SourceName"].ToString()].ToString().Substring(0, 4)).Distinct().ToList();

        List<decimal> yearlist = new List<decimal>();
        foreach (var item2 in query2)
        {
            yearlist.Add(decimal.Parse(item2));
        }

        if (type == "eqiw_r" || type == "eqise")
        {
            List<string> col = ColName.Split('-').ToList();
            string fldSTCode = col[0];
            string fldRCode = col[1];
            string fldRSCode = col[2];


            string var1 = null;

            List<short> var1_value_list = new List<short>();

            List<string> var1_value_list_2 = new List<string>();






            if (col[3].Contains("fldMBWAF"))
            {
                var1 = col[3].Trim('{').Trim('}');
            }



            if (col[3].Contains("fldAttribute"))
            {
                var1 = col[3].Trim('{').Trim('}');
            }






            if (var1 != "" && var1 != null)
            {
                List<string> var1_list = var1.Split('=').ToList();

                string var1_key = var1_list[0];

                var var1_value_list_1 = var1_list[1].Split(',').ToList();

                foreach (var item in var1_value_list_1)
                {
                    if (col[3].Contains("fldMBWAF"))
                    {
                        var1_value_list.Add(short.Parse(item));
                    }


                    if (col[3].Contains("fldAttribute"))
                    {
                        var1_value_list_2.Add(item);
                    }


                }
            }

            List<tblEQIW_R_Section> list = new List<tblEQIW_R_Section>();
            using (EntityContext db = new EntityContext())
            {
                foreach (var item in yearlist)
                {

                    var query3 = (from x in dt.AsEnumerable()
                                  select x[col[0]].ToString()).FirstOrDefault();

                    if (var1 == "" || var1 == null)
                    {
                        list = (from x in db.tblEQIW_R_Section
                                where x.fldYear == item &&
                                x.fldSTCode == query3
                                select x).ToList();
                    }
                    else
                    {

                        if (col[3].Contains("fldMBWAF"))
                        {
                            list = (from x in db.tblEQIW_R_Section
                                    where x.fldYear == item &&
                                    x.fldSTCode == query3 &&
                                    var1_value_list.Contains(x.fldMBWAF)
                                    select x).ToList();
                        }



                        if (col[3].Contains("fldAttribute"))
                        {
                            list = (from x in db.tblEQIW_R_Section
                                    where x.fldYear == item &&
                                    x.fldSTCode == query3 &&
                                    var1_value_list_2.Contains(x.fldAttribute)
                                    select x).ToList();
                        }




















                        //if (var1_value_list.Contains("水华专用"))
                        //{
                        //    List<EMCCommon.Mode.Model_CQHB.MIS.tblEQIW_R_Section> list_section = new List<EMCCommon.Mode.Model_CQHB.MIS.tblEQIW_R_Section>();

                        //    using (EMCCommon.Mode.Model_CQHB.MIS.EntityContext db_CQHB = new EMCCommon.Mode.Model_CQHB.MIS.EntityContext())
                        //    {
                        //        list_section = (from x in db_CQHB.tblEQIW_R_Section
                        //                        where x.fldSyncDataSectionInfo != ""
                        //                        select x).ToList();

                        //        foreach (var item_section in list_section)
                        //        {
                        //            var section = (from x in list
                        //                           where x.fldAutoID == item_section.fldAutoID
                        //                           select x).FirstOrDefault();
                        //            if (section != null)
                        //            {
                        //                list.Remove(section);
                        //            }

                        //        }

                        //    }

                        //}
                    }

                    foreach (var item2 in list)
                    {
                        string year = item.ToString();

                        int datacount = 0;

                        if (var1 == "" || var1 == null)
                        {
                            datacount = (from x in dt.AsEnumerable()
                                         where x[query["SourceName"].ToString()].ToString().Substring(0, 4) == year &&
                                         x[col[0]].ToString() == item2.fldSTCode &&
                                         x[col[1]].ToString() == item2.fldRCode &&
                                         x[col[2]].ToString() == item2.fldRSCode
                                         select x).Count();
                        }
                        else
                        {
                            if (col[3].Contains("fldMBWAF"))
                            {
                                datacount = (from x in dt.AsEnumerable()
                                             where x[query["SourceName"].ToString()].ToString().Substring(0, 4) == year &&
                                             x[col[0]].ToString() == item2.fldSTCode &&
                                             x[col[1]].ToString() == item2.fldRCode &&
                                             x[col[2]].ToString() == item2.fldRSCode &&
                                             var1_value_list.Contains(item2.fldMBWAF)
                                             select x).Count();
                            }






                            if (col[3].Contains("fldAttribute"))
                            {
                                datacount = (from x in dt.AsEnumerable()
                                             where x[query["SourceName"].ToString()].ToString().Substring(0, 4) == year &&
                                             x[col[0]].ToString() == item2.fldSTCode &&
                                             x[col[1]].ToString() == item2.fldRCode &&
                                             x[col[2]].ToString() == item2.fldRSCode &&
                                             var1_value_list_2.Contains(item2.fldAttribute)
                                             select x).Count();
                            }





                        }

                        if (datacount == 0)
                        {
                            if (col[3].Contains("fldMBWAF"))
                            {
                                if (item2.fldMBWAF != 0)
                                {
                                    dt.Rows[0]["错误信息"] += "[年份：" + year + "," + col[0] + "：" + item2.fldSTCode + "," + col[1] + "：" + item2.fldRCode + "," + col[2] + "：" + item2.fldRSCode + ",点位缺少！]";
                                }
                            }



                            if (col[3].Contains("fldAttribute"))
                            {
                                dt.Rows[0]["错误信息"] += "[年份：" + year + "," + col[0] + "：" + item2.fldSTCode + "," + col[1] + "：" + item2.fldRCode + "," + col[2] + "：" + item2.fldRSCode + ",点位缺少！]";
                            }


                        }
                    }
                }
            }




        }






        if (type == "eqiw_d")
        {
            List<string> col = ColName.Split('-').ToList();
            string fldSTCode = col[0];
            string fldRCode = col[1];
            string fldRSCode = col[2];


            string var1 = null;

            List<string> var1_value = new List<string>();
            List<short?> var1_value_list = new List<short?>();


            if (col.Contains("fldSCategory"))
            {
                var1 = col[3].Trim('{').Trim('}');
            }

            if (var1 != "" && var1 != null)
            {
                List<string> var1_list = var1.Split('=').ToList();

                string var1_key = var1_list[0];
                var1_value = var1_list[1].Split(',').ToList();
                foreach (var item in var1_value)
                {
                    var1_value_list.Add(short.Parse(item));
                }

            }

            List<tblEQIW_D_Section> list = new List<tblEQIW_D_Section>();
            using (EntityContext db = new EntityContext())
            {
                foreach (var item in yearlist)
                {
                    //list = (from x in db.tblEQIW_D_Section
                    //        where x.fldYear == item
                    //        select x).ToList();


                    if (cityid != "2")
                    {
                        DataTable dtfldSTCode = rule.SqlQueryForDataTatable("LAPContext", "select * from tblFW_RegCity where fldAutoID=" + cityid);
                        string StrfldSTCode = dtfldSTCode.Rows[0]["fldSTCode"].ToString();

                        list = (from x in db.tblEQIW_D_Section
                                where x.fldYear == item &&
                                x.fldSTCode == StrfldSTCode
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tblEQIW_D_Section
                                where x.fldYear == item
                                select x).ToList();
                    }





                    foreach (var item2 in list)
                    {
                        string year = item.ToString();

                        int datacount = 0;

                        if (var1 == "" || var1 == null)
                        {
                            datacount = (from x in dt.AsEnumerable()
                                         where x[query["SourceName"].ToString()].ToString().Substring(0, 4) == year &&
                                         x[col[0]].ToString() == item2.fldSTCode &&
                                         x[col[1]].ToString() == item2.fldRCode &&
                                         x[col[2]].ToString() == item2.fldRSCode
                                         select x).Count();
                        }
                        else
                        {
                            datacount = (from x in dt.AsEnumerable()
                                         where x[query["SourceName"].ToString()].ToString().Substring(0, 4) == year &&
                                         x[col[0]].ToString() == item2.fldSTCode &&
                                         x[col[1]].ToString() == item2.fldRCode &&
                                         x[col[2]].ToString() == item2.fldRSCode &&
                                         var1_value_list.Contains(item2.fldSCategory)
                                         select x).Count();
                        }

                        if (datacount == 0)
                        {
                            dt.Rows[0]["错误信息"] += "[年份：" + year + "," + col[0] + "：" + item2.fldSTCode + "," + col[1] + "：" + item2.fldRCode + "," + col[2] + "：" + item2.fldRSCode + ",点位缺少！]";
                        }
                    }
                }
            }
        }








        if (type == "eqiw_dt")
        {
            List<string> col = ColName.Split('-').ToList();
            string fldSTCode = col[0];
            string fldRCode = col[1];
            string fldRSCode = col[2];


            string var1 = null;

            List<string> var1_value = new List<string>();
            List<short?> var1_value_list = new List<short?>();


            if (col.Contains("fldSCategory"))
            {
                var1 = col[3].Trim('{').Trim('}');
            }

            if (var1 != "" && var1 != null)
            {
                List<string> var1_list = var1.Split('=').ToList();

                string var1_key = var1_list[0];
                var1_value = var1_list[1].Split(',').ToList();
                foreach (var item in var1_value)
                {
                    var1_value_list.Add(short.Parse(item));
                }

            }

            List<tblEQIW_DT_Section> list = new List<tblEQIW_DT_Section>();
            using (EntityContext db = new EntityContext())
            {
                foreach (var item in yearlist)
                {
                    if (cityid != "2")
                    {
                        DataTable dtfldSTCode = rule.SqlQueryForDataTatable("LAPContext", "select * from tblFW_RegCity where fldAutoID=" + cityid);
                        string StrfldSTCode = dtfldSTCode.Rows[0]["fldSTCode"].ToString();

                        list = (from x in db.tblEQIW_DT_Section
                                where x.fldYear == item &&
                                x.fldSTCode == StrfldSTCode
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tblEQIW_DT_Section
                                where x.fldYear == item
                                select x).ToList();
                    }




                    foreach (var item2 in list)
                    {
                        string year = item.ToString();

                        int datacount = 0;

                        if (var1 == "" || var1 == null)
                        {
                            datacount = (from x in dt.AsEnumerable()
                                         where x[query["SourceName"].ToString()].ToString().Substring(0, 4) == year &&
                                         x[col[0]].ToString() == item2.fldSTCode &&
                                         x[col[1]].ToString() == item2.fldRCode &&
                                         x[col[2]].ToString() == item2.fldRSCode
                                         select x).Count();
                        }
                        else
                        {
                            datacount = (from x in dt.AsEnumerable()
                                         where x[query["SourceName"].ToString()].ToString().Substring(0, 4) == year &&
                                         x[col[0]].ToString() == item2.fldSTCode &&
                                         x[col[1]].ToString() == item2.fldRCode &&
                                         x[col[2]].ToString() == item2.fldRSCode &&
                                         var1_value_list.Contains(item2.fldSCategory)
                                         select x).Count();
                        }

                        if (datacount == 0)
                        {
                            dt.Rows[0]["错误信息"] += "[年份：" + year + "," + col[0] + "：" + item2.fldSTCode + "," + col[1] + "：" + item2.fldRCode + "," + col[2] + "：" + item2.fldRSCode + ",点位缺少！]";
                        }
                    }
                }
            }

        }







        if (type == "eqiw_dx")
        {
            List<string> col = ColName.Split('-').ToList();
            string fldSTCode = col[0];
            string fldRCode = col[1];
            string fldRSCode = col[2];


            string var1 = null;

            List<string> var1_value = new List<string>();
            List<short?> var1_value_list = new List<short?>();


            if (col.Contains("fldSCategory"))
            {
                var1 = col[3].Trim('{').Trim('}');
            }

            if (var1 != "" && var1 != null)
            {
                List<string> var1_list = var1.Split('=').ToList();

                string var1_key = var1_list[0];
                var1_value = var1_list[1].Split(',').ToList();
                foreach (var item in var1_value)
                {
                    var1_value_list.Add(short.Parse(item));
                }

            }

            List<tbleqiw_dx_Section> list = new List<tbleqiw_dx_Section>();
            using (EntityContext db = new EntityContext())
            {
                foreach (var item in yearlist)
                {
                    //list = (from x in db.tbleqiw_dx_Section
                    //        where x.fldYear == item
                    //        select x).ToList();

                    if (cityid != "2")
                    {
                        DataTable dtfldSTCode = rule.SqlQueryForDataTatable("LAPContext", "select * from tblFW_RegCity where fldAutoID=" + cityid);
                        string StrfldSTCode = dtfldSTCode.Rows[0]["fldSTCode"].ToString();

                        list = (from x in db.tbleqiw_dx_Section
                                where x.fldYear == item &&
                                x.fldSTCode == StrfldSTCode
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tbleqiw_dx_Section
                                where x.fldYear == item
                                select x).ToList();
                    }






                    foreach (var item2 in list)
                    {
                        string year = item.ToString();

                        int datacount = 0;

                        if (var1 == "" || var1 == null)
                        {
                            datacount = (from x in dt.AsEnumerable()
                                         where x[query["SourceName"].ToString()].ToString().Substring(0, 4) == year &&
                                         x[col[0]].ToString() == item2.fldSTCode &&
                                         x[col[1]].ToString() == item2.fldRCode &&
                                         x[col[2]].ToString() == item2.fldRSCode
                                         select x).Count();
                        }
                        else
                        {
                            datacount = (from x in dt.AsEnumerable()
                                         where x[query["SourceName"].ToString()].ToString().Substring(0, 4) == year &&
                                         x[col[0]].ToString() == item2.fldSTCode &&
                                         x[col[1]].ToString() == item2.fldRCode &&
                                         x[col[2]].ToString() == item2.fldRSCode &&
                                         var1_value_list.Contains(item2.fldSCategory)
                                         select x).Count();
                        }

                        if (datacount == 0)
                        {
                            dt.Rows[0]["错误信息"] += "[年份：" + year + "," + col[0] + "：" + item2.fldSTCode + "," + col[1] + "：" + item2.fldRCode + "," + col[2] + "：" + item2.fldRSCode + ",点位缺少！]";
                        }
                    }
                }
            }

        }






        return dt;
    }





    /// <summary>
    /// 检查Excel中因子数据 - 验证因子有效性
    /// </summary>
    /// <param name="type">业务类型</param>
    /// <param name="query">配置Json中因子数据</param>
    /// <param name="dr">Excel中的一行数据</param>
    /// <returns></returns>
    public string Check_Item_Validity(string type, List<JToken> query, DataRow dr)
    {
        string info = null;

        if (type == "eqiw_r" || type == "eqiw_d")
        {
            List<tblEQIW_R_Item> list = new List<tblEQIW_R_Item>();

            using (EntityContext db = new EntityContext())
            {
                list = (from x in db.tblEQIW_R_Item
                        select x).ToList();

                foreach (var item in query)
                {
                    var query2 = (from x in list
                                  where x.fldItemCode == item["ItemCode"].ToString()
                                  select x).FirstOrDefault();


                    #region 检查因子的值是否超出范围

                    double ItemValue = 0;

                    if (dr[item["SourceName"].ToString()].ToString().Contains("L"))
                    {
                        ItemValue = Convert.ToDouble("-" + dr[item["SourceName"].ToString()].ToString().TrimEnd('L'));
                    }
                    else
                    {
                        ItemValue = Convert.ToDouble(dr[item["SourceName"].ToString()]);
                    }

                    double fldMinValue = Convert.ToDouble(query2.fldMinValue);
                    double fldMaxValue = Convert.ToDouble(query2.fldMaxValue);

                    if (ItemValue < fldMinValue || ItemValue > fldMaxValue)
                    {
                        info += "[" + item["SourceName"].ToString() + "：值超出范围！]";
                    }

                    #endregion



                }
            }
        }




        #region 检查因子是否是数字，带L的值跳过

        double result = new double();

        foreach (var item in query)
        {
            if (dr.Table.Columns.Contains(item["SourceName"].ToString()))
            {
                if (!(dr[item["SourceName"].ToString()].ToString().Contains("L")))
                {
                    if (!(double.TryParse(dr[item["SourceName"].ToString()].ToString(), out result)))
                    {
                        info += "[" + item["SourceName"].ToString() + "：" + dr[item["SourceName"].ToString()].ToString() + "]不是有效的数字。";
                    }
                }
            }
        }

        #endregion


        return info;
    }

















    /// <summary>
    /// 检查因子的小数位数是否有效
    /// </summary>
    /// <param name="dtItem">因子数据</param>
    /// <param name="dr">Excel中的一行数据</param>
    /// <param name="ColName">需要检查的列名称，用|符号分割</param>
    /// <returns></returns>
    public string Check_Item_Dec(DataTable dtItem, DataRow dr, string ColName)
    {
        string info = null;

        DataTable itemlist_new = null;

        List<string> colNameList = ColName.Split('|').ToList();

        itemlist_new = (from x in dtItem.AsEnumerable()
                        where colNameList.Contains(x["fldItemName"].ToString())
                        select x).CopyToDataTable();

        foreach (DataRow item in itemlist_new.Rows)
        {
            if (dr.Table.Columns.Contains(item["fldItemName"].ToString()))
            {

                if (!(dr[item["fldItemName"].ToString()].ToString() == "-1" || dr[item["fldItemName"].ToString()].ToString() == ""))
                {
                    int result = 0;

                    if (dr[item["fldItemName"].ToString()].ToString().Contains("."))
                    {
                        string value = dr[item["fldItemName"].ToString()].ToString();

                        result = value.Length - value.IndexOf('.') - 1;

                        if (value.Contains("L"))
                        {
                            result--;
                        }
                    }

                    if (result != int.Parse(item["fldDec"].ToString()))
                    {
                        info += "[" + item["fldItemName"].ToString() + "：小数位数不符合规范！]";
                    }
                }
            }
        }

        return info;
    }












    /// <summary>
    /// 检查Excel中因子数据 - 若因子的值为-1或者""，那么[备注]列需要填写相关信息
    /// </summary>
    /// <param name="dtItem">因子数据表</param>
    /// <param name="dr">Excel中的一行数据</param>
    /// <param name="ColName">此参数在这里的意义在于：当因子都为-1或者""的情况下，备注中出现其中的关键字，即视为有效备注</param>
    /// <returns></returns>
    public Object_Return Check_Item_Remarks(DataTable dtItem, DataRow dr, string ColName)
    {
        Object_Return data = new Object_Return();

        string ErrorInfo = null;

        string ColorInfo = null;

        int itemcount = 0;

        int itemcount_null = 0;

        foreach (DataRow item in dtItem.Rows)
        {
            if (dr.Table.Columns.Contains(item["fldItemName"].ToString()))
            {
                itemcount++;

                if (dr[item["fldItemName"].ToString()].ToString() == "-1" || dr[item["fldItemName"].ToString()].ToString() == "")
                {
                    itemcount_null++;

                    if (!(dr["备注"].ToString().Contains(item["fldItemName"].ToString())))
                    {
                        ErrorInfo += "[" + item["fldItemName"].ToString() + "：未在备注列填写说明！]";
                        ColorInfo += item["fldItemName"].ToString() + ",";
                    }
                }
            }
        }


        if (!(dr["备注"].ToString().Contains("原因是")))
        {
            if (dr["备注"].ToString() != "")
            {
                ErrorInfo += "[备注句式中要包含“原因是”]";
            }
        }



        if (!(itemcount == 0 && itemcount_null == 0))
        {
            if (itemcount == itemcount_null)
            {
                if (ColName != "")
                {
                    List<string> KeyNameList = ColName.Split('|').ToList();

                    Dictionary<string, string> dic = new Dictionary<string, string>();

                    foreach (var item in KeyNameList)
                    {
                        List<string> list = item.Split('=').ToList();

                        dic.Add(list[0], list[1]);
                    }


                    foreach (var item in dic)
                    {



                        if (!(dr["备注"].ToString().Contains(item.Key)))
                        {
                            ErrorInfo += "[备注列需要填写【" + item.Key + "】相关说明！(" + item.Value + ")]";
                        }
                        else
                        {
                            ErrorInfo = "";
                            break;
                        }
                    }

                }
                else
                {
                    if (dr["备注"].ToString() == "")
                    {
                        ErrorInfo = "[若因子全部未监测，则备注列需要填写说明！]";
                    }
                    else
                    {
                        ErrorInfo = "";
                    }
                }
            }
        }







        data.ErrorInfo = ErrorInfo;

        if (ColorInfo != null)
        {
            data.ColorInfo = ColorInfo.TrimEnd(',');
        }

        return data;
    }
















    /// <summary>
    /// 检查Excel中因子数据 - 若因子的值为-1或者""，那么[备注]列需要填写相关信息
    /// </summary>
    /// <param name="dtItem">因子数据表</param>
    /// <param name="dr">Excel中的一行数据</param>
    /// <param name="ColName">此参数在这里的意义在于：当因子都为-1或者""的情况下，备注中出现其中的关键字，即视为有效备注</param>
    /// <returns></returns>
    public Object_Return Check_Item_Remarks_ForAllNull(DataTable dtItem, DataRow dr, string ColName)
    {
        Object_Return data = new Object_Return();

        string ErrorInfo = null;

        string ColorInfo = null;

        int itemcount = 0;

        int itemcount_null = 0;

        foreach (DataRow item in dtItem.Rows)
        {
            if (dr.Table.Columns.Contains(item["fldItemName"].ToString()))
            {
                itemcount++;

                if (dr[item["fldItemName"].ToString()].ToString() == "-1" || dr[item["fldItemName"].ToString()].ToString() == "")
                {
                    itemcount_null++;

                    //if (!(dr["备注"].ToString().Contains(item["fldItemName"].ToString())))
                    //{
                    //    ErrorInfo += "[" + item["fldItemName"].ToString() + "：未在备注列填写说明！]";
                    //    ColorInfo += item["fldItemName"].ToString() + ",";
                    //}
                }
            }
        }

        if (!(itemcount == 0 && itemcount_null == 0))
        {
            if (itemcount == itemcount_null)
            {
                if (ColName != "")
                {
                    List<string> KeyNameList = ColName.Split('|').ToList();

                    Dictionary<string, string> dic = new Dictionary<string, string>();

                    foreach (var item in KeyNameList)
                    {
                        List<string> list = item.Split('=').ToList();

                        dic.Add(list[0], list[1]);
                    }


                    foreach (var item in dic)
                    {
                        if (!(dr["备注"].ToString().Contains(item.Key)))
                        {
                            ErrorInfo += "[备注列需要填写【" + item.Key + "】相关说明！(" + item.Value + ")]";
                        }
                        else
                        {
                            ErrorInfo = "";
                            break;
                        }
                    }
                }
                else
                {
                    if (dr["备注"].ToString() == "")
                    {
                        ErrorInfo = "[若因子全部未监测，则备注列需要填写说明！]";
                    }
                    else
                    {
                        ErrorInfo = "";
                    }
                }
            }
        }

        data.ErrorInfo = ErrorInfo;

        if (ColorInfo != null)
        {
            data.ColorInfo = ColorInfo.TrimEnd(',');
        }

        return data;
    }

















    /// <summary>
    /// 检查Excel中的列是否为空
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="ColName"></param>
    /// <returns></returns>
    public string Check_Col_IsEmpty(DataRow dr, string ColName)
    {
        string info = null;

        if (ColName != "")
        {
            List<string> colNameList = ColName.Split('|').ToList();

            foreach (var item in colNameList)
            {
                if (dr.Table.Columns.Contains(item))
                {
                    if (dr[item].ToString() == "")
                    {
                        info += "[" + item + "：存在空值！]";
                    }
                }
            }
        }

        return info;
    }








    /// <summary>
    /// 检查Excel中的因子是否为空
    /// </summary>
    /// <param name="dr"></param>
    /// <param name="dtItem"></param>
    /// <returns></returns>
    public string Check_Col_IsEmpty_ForItem(DataRow dr, DataTable dtItem)
    {
        string info = null;

        foreach (DataRow item in dtItem.Rows)
        {
            if (dr.Table.Columns.Contains(item["fldItemName"].ToString()))
            {
                if (dr[item["fldItemName"].ToString()].ToString() == "")
                {
                    info += "[" + item + "：存在空值！]";
                }
            }
        }

        return info;
    }











    /// <summary>
    /// 检查因子不能为某值
    /// </summary>
    /// <param name="dr"></param>
    /// <param name="dtItem"></param>
    /// <param name="ColName"></param>
    /// <returns></returns>
    public string Check_Item_IsNot(DataRow dr, DataTable dtItem, string ColName)
    {
        string info = null;


        Dictionary<string, string> dic = new Dictionary<string, string>();

        List<string> temp = ColName.Split(',').ToList();

        foreach (var item in temp)
        {
            string key = item.Split('!')[0];

            string value = item.Split('!')[1];

            dic.Add(key, value);
        }


        foreach (var item in dic)
        {
            var fldItemName = (from x in dtItem.AsEnumerable()
                               where x["fldItemCode"].ToString() == item.Key
                               select x["fldItemName"].ToString()).FirstOrDefault();

            if (dr.Table.Columns.Contains(fldItemName))
            {
                if (dr[fldItemName].ToString() == item.Value)
                {
                    info += "[" + fldItemName + "：的值不能为" + item.Value + "]";
                }
            }
        }

        return info;
    }























    /// <summary>
    /// 特殊表检查数据
    /// </summary>
    /// <param name="type"></param>
    /// <param name="dr"></param>
    /// <returns></returns>
    public string Check_withtype_eqiw_r_and_TableID_1(string type, DataRow dr)
    {
        string info = null;

        if (dr["新建水站_落实经费_是否完成"].ToString() == "否")
        {
            if (dr["新建水站_落实经费_是否完成"].ToString() == "")
            {
                info += "[新建水站_落实经费_未完成原因]需填写原因；";
            }
        }




        if (dr["新建水站_征租地_是否完成"].ToString() == "否")
        {
            if (dr["新建水站_征租地_未完成原因"].ToString() == "")
            {
                info += "[新建水站_征租地_未完成原因]需填写原因；";
            }
        }






        if (dr["新建水站_设计图纸_是否完成"].ToString() == "否")
        {
            if (dr["新建水站_设计图纸_未完成原因"].ToString() == "")
            {
                info += "[新建水站_设计图纸_未完成原因]需填写原因；";
            }
        }





        if (dr["新建水站_招投标_是否完成"].ToString() == "否")
        {
            if (dr["新建水站_招投标_未完成原因"].ToString() == "")
            {
                info += "[新建水站_招投标_未完成原因]需填写原因；";
            }
        }







        if (dr["新建水站_四通一平_是否完成"].ToString() == "否")
        {
            if (dr["新建水站_四通一平_未完成原因"].ToString() == "")
            {
                info += "[新建水站_四通一平_未完成原因]需填写原因；";
            }
        }







        if (dr["新建水站_主体建设_是否完成"].ToString() == "否")
        {
            if (dr["新建水站_主体建设_未完成原因"].ToString() == "")
            {
                info += "[新建水站_主体建设_未完成原因]需填写原因；";
            }
        }








        if (dr["新建水站_室内装修_是否完成"].ToString() == "否")
        {
            if (dr["新建水站_室内装修_未完成原因"].ToString() == "")
            {
                info += "[新建水站_室内装修_未完成原因]需填写原因；";
            }
        }













        if (dr["新建水站_采水系统建设_是否完成"].ToString() == "否")
        {
            if (dr["新建水站_采水系统建设_未完成原因"].ToString() == "")
            {
                info += "[新建水站_采水系统建设_未完成原因]需填写原因；";
            }
        }








        if (dr["新建水站_联网运行_是否完成"].ToString() == "否")
        {
            if (dr["新建水站_联网运行_未完成原因"].ToString() == "")
            {
                info += "[新建水站_联网运行_未完成原因]需填写原因；";
            }
        }










        if (dr["已建水站_落实经费_是否完成"].ToString() == "否")
        {
            if (dr["已建水站_落实经费_未完成原因"].ToString() == "")
            {
                info += "[已建水站_落实经费_未完成原因]需填写原因；";
            }
        }

        if (dr["已建水站_仪器设备补齐情况_是否完成"].ToString() == "否")
        {
            if (dr["已建水站_仪器设备补齐情况_未完成原因"].ToString() == "")
            {
                info += "[已建水站_仪器设备补齐情况_未完成原因]需填写原因；";
            }
        }





        if (dr["已建水站_系统更新情况_是否完成"].ToString() == "否")
        {
            if (dr["已建水站_系统更新情况_未完成原因"].ToString() == "")
            {
                info += "[已建水站_系统更新情况_未完成原因]需填写原因；";
            }
        }




        if (dr["已建水站_联网运行_是否完成"].ToString() == "否")
        {
            if (dr["已建水站_联网运行_未完成原因"].ToString() == "")
            {
                info += "[已建水站_联网运行_未完成原因]需填写原因；";
            }
        }





        if (dr["建设情况"].ToString() == "已建")
        {
            foreach (DataColumn item in dr.Table.Columns)
            {
                if (item.ColumnName.Contains("新建水站"))
                {
                    if (dr[item.ColumnName].ToString() != "/" && dr[item.ColumnName].ToString() != "")
                    {
                        info += "已建水站，只能在新建水站数据中填写“/”或者空；";
                    }

                }
            }
        }



        if (dr["建设情况"].ToString() == "新建")
        {
            foreach (DataColumn item in dr.Table.Columns)
            {
                if (item.ColumnName.Contains("已建水站"))
                {
                    if (dr[item.ColumnName].ToString() != "/" && dr[item.ColumnName].ToString() != "")
                    {
                        info += "新建水站，只能在已建水站数据中填写“/”或者空；";
                    }

                }
            }
        }


        return info;
    }











    /// <summary>
    /// 因子逻辑关系检查
    /// </summary>
    /// <returns></returns>
    public DataTable Check_ItemLogic(DataTable tblData)
    {


        List<tblCorrespond_Btype_ItemCode> list = new List<tblCorrespond_Btype_ItemCode>();

        using (EntityContext db = new EntityContext())
        {
            list = (from x in db.tblCorrespond_Btype_ItemCode
                    where x.fldExpression != null && x.fldExpression != ""
                    select x).ToList();
        }

        //bool IsFirst = true;

        foreach (DataRow item in tblData.Rows)
        {
            //if (IsFirst)
            //{
            //    IsFirst = false;
            //    continue;
            //}



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


            item["因子逻辑关系_颜色信息"] = colorList.TrimEnd(',');

        }


        return tblData;
    }














    /// <summary>
    /// 检查数据是否是本月的数据
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public DataTable Check_IsDateNow_Month(DataTable dt)
    {
        int month = DateTime.Now.Month;

        foreach (DataRow item in dt.Rows)
        {
            DateTime dttemp = DateTime.Parse(item["采样时间"].ToString());
            if (dttemp.Month != month)
            {
                item["错误信息"] += "存在非本月数据！";
            }
        }

        return dt;
    }

















    /// <summary>
    /// 与正式表中检查是否存在相同数据
    /// </summary>
    /// <param name="type"></param>
    /// <param name="dr"></param>
    /// <param name="ColName"></param>
    /// <returns></returns>
    public string Check_BaseData(string type, DataRow dr, string ColName)
    {
        string result = null;
        string sql = "";

        if (type == "eqiw_r" || type == "eqise")
        {
            sql += "select * from tblEQIW_R_Basedata";
        }

        if (type == "eqiw_d")
        {
            sql += "select * from tblEQIW_D_Basedata";
        }

        if (type == "eqiw_dt")
        {
            sql += "select * from tblEQIW_DT_Basedata";
        }

        if (type == "eqiw_dx")
        {
            sql += "select * from tbleqiw_dx_Basedata";
        }



        List<string> maplist = ColName.Split('|').ToList();

        sql += " where 1=1 ";

        foreach (var item in maplist)
        {
            string dtname = item.Split('-')[0];
            string tablename = item.Split('-')[1];

            sql += " and " + tablename + " = '" + dr[dtname].ToString() + "' ";
        }


        DataTable dt_Basedata = rule.SqlQueryForDataTatable("EntityContext", sql);


        if (dt_Basedata.Rows.Count > 0)
        {
            result = "【此数据在[正式表]中已经存在，请核对数据。】";
        }

        return result;
    }















    /// <summary>
    /// 与临时表中检查是否存在相同数据
    /// </summary>
    /// <param name="type"></param>
    /// <param name="dr"></param>
    /// <param name="ColName"></param>
    /// <returns></returns>
    public string Check_BaseData_Pre(string type, DataRow dr, string ColName)
    {
        string result = null;
        string sql = "";

        if (type == "eqiw_r" || type == "eqise")
        {
            sql += "select * from tblEQIW_R_Basedata_Pre";
        }

        if (type == "eqiw_d")
        {
            sql += "select * from tblEQIW_D_Basedata_Pre";
        }

        if (type == "eqiw_dt")
        {
            sql += "select * from tblEQIW_DT_Basedata_Pre";
        }

        if (type == "eqiw_dx")
        {
            sql += "select * from tbleqiw_dx_Basedata_Pre";
        }



        List<string> maplist = ColName.Split('|').ToList();

        sql += " where 1=1 ";

        foreach (var item in maplist)
        {
            string dtname = item.Split('-')[0];
            string tablename = item.Split('-')[1];

            sql += " and " + tablename + " = '" + dr[dtname].ToString() + "' ";
        }


        DataTable dt_Basedata = rule.SqlQueryForDataTatable("EntityContext", sql);


        if (dt_Basedata.Rows.Count > 0)
        {
            string flagname = "";

            if (dt_Basedata.Rows[0]["fldFlag"].ToString() == "0")
            {
                flagname = "区县一级审核环节";
            }
            if (dt_Basedata.Rows[0]["fldFlag"].ToString() == "2")
            {
                flagname = "区县二级审核环节";
            }
            if (dt_Basedata.Rows[0]["fldFlag"].ToString() == "3")
            {
                flagname = "区县三级审核环节";
            }
            if (dt_Basedata.Rows[0]["fldFlag"].ToString() == "3")
            {
                flagname = "区县三级审核环节";
            }
            if (dt_Basedata.Rows[0]["fldFlag"].ToString() == "1")
            {
                flagname = "市站一级审核环节";
            }





            result = "【此数据在[" + flagname + "]中已经存在，请核对数据，若要覆盖此数据，请勾选删除历史数据。】";
        }

        return result;
    }














}








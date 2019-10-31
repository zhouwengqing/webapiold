
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using EMCCommon.Mode;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data.Entity.Migrations;

namespace EMCCommon.Common
{
    /// <summary>
    /// 功能描述：关于审核确认的统一API
    /// 创建者  ：吕荣誉
    /// 创建日期：2017-7-1
    /// 修改者  ：
    /// 修改日期：
    /// 修改原因：
    /// </summary>
    public class AuditingController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        RuleEQICommon_Auditing ruleAuditing = new RuleEQICommon_Auditing();

        string strLocalpath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/TypeBaseData.json");//配置的json文件地址

        string zhCNpath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/zh_CN.json");//配置的json文件地址


        /// <summary>
        /// 功能描述：确认全部数据
        /// 创建者  ：吕荣誉
        /// 创建日期：2017-7-3
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <param name="actionType">操作类型：“待提交审核”1，“监测数据审核”0</param>
        /// <param name="where">条件</param>
        /// <param name="AuditingType">
        /// ""或者null，代表原来的默认审核
        /// 比如："二级审核"，代表第二个步骤，fldFlag=1
        /// </param>
        /// <returns></returns>
        [HttpPost, HttpGet]
        //[SupportFilter]
        public HttpResponseMessage AuditingActionAll(string type, string actionType, string where, string AuditingType = "", string OldFlag = "", string NewFlag = "")
        {
            string result = string.Empty;
            try
            {
                int result2 = 0;

                string getjson = rule.GetJson(strLocalpath);

                JArray jsonObj = JArray.Parse(getjson);

                var tablename = (from x in jsonObj
                                 where x["type"].ToString() == type
                                 select x).FirstOrDefault();


                if (AuditingType == "" || AuditingType == null)
                {
                    string where2 = null;
                    if (where == "undefined" || where == "" || where == null)
                    {
                        if (type.Contains("hm"))
                        {
                            where = " and fldSource=1 ";
                        }
                        else
                        {
                            where = " and fldSource=0 ";
                        }
                    }

                    if (actionType == "1")
                    {
                        where2 = " fldFlag=0 and fldImport=1 ";
                    }
                    if (actionType == "0")
                    {
                        where2 = " fldFlag=1 ";
                    }

                    where = where2 + HttpUtility.UrlDecode(where);


                    if (actionType == "1")
                    {
                        result2 = ruleAuditing.ExecuteAuditingAll("待提交审核", "", "", tablename["tablenamepre"].ToString(), "", "", where, "", "", "");
                    }
                    else if (actionType == "0")
                    {
                        result2 = ruleAuditing.ExecuteAuditingAll("监测数据审核", tablename["tablename"].ToString(), tablename["basedatacol"].ToString(), tablename["tablenamepre"].ToString(), tablename["View"].ToString(), tablename["ViewCol"].ToString(), where, "", "", "");
                    }

                }
                else
                {

                    //where = HttpUtility.UrlDecode(where);


                    if (where == "" || where == null || where == "undefined")
                    {
                        where = " fldFlag=" + OldFlag;
                    }


                    if (OldFlag == "" || NewFlag == "" || NewFlag == "99")
                    {
                        result2 = ruleAuditing.ExecuteAuditingAll("市站_入库_确认全部", tablename["tablename"].ToString(), tablename["basedatacol"].ToString(), tablename["tablenamepre"].ToString(), tablename["View"].ToString(), tablename["ViewCol"].ToString(), where, "", type, "");
                    }
                    else
                    {
                        result2 = ruleAuditing.ExecuteAuditingAll("区县_审核_确认全部", "", "", tablename["tablenamepre"].ToString(), "", "", where, "", type, NewFlag);
                    }

                }








                // 审核日志
                List<tblFW_AuditingLog> lstAuditingLog = new List<tblFW_AuditingLog>();

                tblFW_AuditingLog autitingLog = new tblFW_AuditingLog()
                {
                    fldUserID = -1,

                    fldCityID = -1,

                    fldModal = tablename["TypeDisplayName"].ToString(),

                    fldDate_operate = DateTime.Now,

                    fldContent = "确认全部数据",

                    fldImport = true,

                    fldOperId = -1,

                    fldType = type,

                    fldAuditingSate = 1
                };
                lstAuditingLog.Add(autitingLog);

                int result3 = ruleAuditing.ExecuteAuditingLog(lstAuditingLog);



                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", result2.ToString());
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

















        [HttpPost]
        public HttpResponseMessage AuditingActionAll_Post(AuditingActionAll_Post_Info info)
        {
            string result = string.Empty;
            try
            {
                int result2 = 0;

                string getjson = rule.GetJson(strLocalpath);

                JArray jsonObj = JArray.Parse(getjson);

                var tablename = (from x in jsonObj
                                 where x["type"].ToString() == info.type
                                 select x).FirstOrDefault();


                if (info.AuditingType == "" || info.AuditingType == null)
                {
                    string where2 = null;
                    if (info.where == "undefined" || info.where == "" || info.where == null)
                    {
                        if (info.type.Contains("hm"))
                        {
                            info.where = " and fldSource=1 ";
                        }
                        else
                        {
                            info.where = " and fldSource=0 ";
                        }
                    }

                    if (info.actionType == "1")
                    {
                        where2 = " fldFlag=0 and fldImport=1 ";
                    }
                    if (info.actionType == "0")
                    {
                        where2 = " fldFlag=1 ";
                    }

                    info.where = where2 + HttpUtility.UrlDecode(info.where);


                    if (info.actionType == "1")
                    {
                        result2 = ruleAuditing.ExecuteAuditingAll("待提交审核", "", "", tablename["tablenamepre"].ToString(), "", "", info.where, "", "", "");
                    }
                    else if (info.actionType == "0")
                    {
                        result2 = ruleAuditing.ExecuteAuditingAll("监测数据审核", tablename["tablename"].ToString(), tablename["basedatacol"].ToString(), tablename["tablenamepre"].ToString(), tablename["View"].ToString(), tablename["ViewCol"].ToString(), info.where, "", "", "");
                    }

                }
                else
                {

                    //where = HttpUtility.UrlDecode(where);


                    if (info.where == "" || info.where == null || info.where == "undefined")
                    {
                        info.where = " fldFlag=" + info.OldFlag;
                    }


                    if (info.OldFlag == "" || info.NewFlag == "" || info.NewFlag == "99")
                    {
                        result2 = ruleAuditing.ExecuteAuditingAll("市站_入库_确认全部", tablename["tablename"].ToString(), tablename["basedatacol"].ToString(), tablename["tablenamepre"].ToString(), tablename["View"].ToString(), tablename["ViewCol"].ToString(), info.where, "", info.type, "");
                    }
                    else
                    {
                        result2 = ruleAuditing.ExecuteAuditingAll("区县_审核_确认全部", "", "", tablename["tablenamepre"].ToString(), "", "", info.where, "", info.type, info.NewFlag);
                    }

                }








                // 审核日志
                List<tblFW_AuditingLog> lstAuditingLog = new List<tblFW_AuditingLog>();

                tblFW_AuditingLog autitingLog = new tblFW_AuditingLog()
                {
                    fldUserID = -1,

                    fldCityID = -1,

                    fldModal = tablename["TypeDisplayName"].ToString(),

                    fldDate_operate = DateTime.Now,

                    fldContent = "确认全部数据",

                    fldImport = true,

                    fldOperId = -1,

                    fldType = info.type,

                    fldAuditingSate = 1
                };
                lstAuditingLog.Add(autitingLog);

                int result3 = ruleAuditing.ExecuteAuditingLog(lstAuditingLog);



                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", result2.ToString());
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





        public class AuditingActionAll_Post_Info
        {
            public string type { get; set; }

            public string actionType { get; set; }

            public string where { get; set; }

            public string AuditingType { get; set; }

            public string OldFlag { get; set; }

            public string NewFlag { get; set; }
        }
































        /// <summary>
        /// 功能描述：审核确认
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-7-6
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="obj">动态参数：type-业务类型；IDList：ID列表</param>
        /// <returns></returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage AuditingActionEQIA_R(AuditingActionEQIA_R_Info info)
        {
            string result = string.Empty;
            try
            {
                string getjson = rule.GetJson(strLocalpath);

                JArray jsonObj = JArray.Parse(getjson);

                var tablename = (from x in jsonObj
                                 where x["type"].ToString() == info.type
                                 select x).FirstOrDefault();

                DataTable dt = rule.SqlQueryForDataTatable("EntityContext", "select * from " + tablename["View"] + " where fldAutoID in (" + info.IDList.TrimEnd(',') + ")");

                // 市站审核通过ID列表
                string okList = null;

                // 市站审核未通过ID列表
                string noList = null;


                // 市站审核未通过ID列表
                string noListqx = null;

                //三级退回到一级
                string noListtoone = null;


                var okquery = from x in dt.AsEnumerable()
                              where x["fldAudType"].ToString() == "yes"
                              select x["fldAutoID"].ToString();
                okList = string.Join(",", okquery.ToList());

                var noquery = from x in dt.AsEnumerable()
                              where x["fldAudType"].ToString() == "no"
                              && x["fldCityID_Operate"].ToString() == "2"
                              select x["fldAutoID"].ToString();

                var noqueryqx = from x in dt.AsEnumerable()
                                where x["fldAudType"].ToString() == "no"
                                && x["fldCityID_Operate"].ToString() != "2"
                                 && x["fldFlag"].ToString() == "1"
                                select x["fldAutoID"].ToString();

                var noquerytoone = from x in dt.AsEnumerable()
                                   where x["fldAudType"].ToString() == "no"
                                   && x["fldCityID_Operate"].ToString() != "2"
                                    && x["fldFlag"].ToString() != "1"
                                   select x["fldAutoID"].ToString();

                noList = string.Join(",", noquery.ToList());

                noListqx = string.Join(",", noqueryqx.ToList());

                noListtoone = string.Join(",", noquerytoone.ToList());

                int result1 = 0;

                int result2 = 0;





                if (info.AuditingType == null)
                {
                    if (okList != "")
                    {
                        string sql = "insert into " + tablename["tablename"].ToString() + " (" + tablename["basedatacol"].ToString() + ") select " + tablename["ViewCol"].ToString() + " from " + tablename["View"].ToString() + " where fldAutoID in (" + okList + ")";

                        result1 = ruleAuditing.ExecuteAuditingAll("通过", tablename["tablename"].ToString(), tablename["basedatacol"].ToString(), tablename["tablenamepre"].ToString(), tablename["View"].ToString(), tablename["ViewCol"].ToString(), "", okList, "", info.NewFlag);
                    }

                    if (noList != "")
                    {
                        result2 = ruleAuditing.ExecuteAuditingAll("未通过", "", "", tablename["tablenamepre"].ToString(), "", "", "", noList, "", info.NewFlag);
                    }

                }
                else
                {
                    if (info.NewFlag == "" || info.NewFlag == "99")
                    {
                        if (okList != "")
                        {
                            result1 = ruleAuditing.ExecuteAuditingAll("市站_入库_审核确认", tablename["tablename"].ToString(), tablename["basedatacol"].ToString(), tablename["tablenamepre"].ToString(), tablename["View"].ToString(), tablename["ViewCol"].ToString(), "", okList, "", info.NewFlag);
                        }
                        if (noListqx != "")
                        {
                            result1 = ruleAuditing.ExecuteAuditingAll("区县_审核_审核确认", "", "", tablename["tablenamepre"].ToString(), "", "", "", noListqx, "", "3");
                        }
                        if (noList != "")
                        {
                            result1 = ruleAuditing.ExecuteAuditingAll("区县_审核_审核确认", "", "", tablename["tablenamepre"].ToString(), "", "", "", noList, "", "-1");
                        }
                    }
                    else
                    {
                        if (okList != "")
                        {
                            result1 = ruleAuditing.ExecuteAuditingAll("区县_审核_审核确认", "", "", tablename["tablenamepre"].ToString(), "", "", "", okList, "", info.NewFlag);
                        }

                        //if (noList != "")
                        //{
                        //    result2 = ruleAuditing.ExecuteAuditingAll("区县_审核_审核确认", "", "", tablename["tablenamepre"].ToString(), "", "", "", noList, "", info.NewFlag.ToString());
                        //}
                        if (noListtoone != "")
                        {
                            result2 = ruleAuditing.ExecuteAuditingAll("区县_审核_审核确认", "", "", tablename["tablenamepre"].ToString(), "", "", "", noListtoone, "", "-1");
                        }
                    }
                }














                // 审核日志
                List<tblFW_AuditingLog> lstAuditingLog = new List<tblFW_AuditingLog>();

                foreach (DataRow item in dt.Rows)
                {
                    string content = "";
                    if (tablename["AuditingLog"].ToString() != "")
                    {
                        JArray Log = JArray.Parse(tablename["AuditingLog"].ToString());

                        foreach (var item2 in Log)
                        {
                            content += item2["Display"].ToString() + item[item2["Field"].ToString()].ToString();
                        }
                        content += "项目因子：";
                        foreach (DataRow item2 in dt.Rows)
                        {
                            if (dt.Columns.Contains("fldItemName"))
                            {
                                content += "[" + item2["fldItemName"].ToString() + "]";
                            }
                        }
                    }

                    int fldAuditingSate = 0;
                    if (item["fldAudType"].ToString() == "yes")
                    {
                        fldAuditingSate = 1;
                    }
                    tblFW_AuditingLog autitingLog = new tblFW_AuditingLog()
                    {
                        //fldUserID = int.Parse(item["fldUserID"].ToString()),

                        fldUserID = info.fldUserID,

                        fldCityID = int.Parse(item["fldCityID_Operate"].ToString()),

                        fldModal = tablename["TypeDisplayName"].ToString(),

                        fldDate_operate = DateTime.Now,

                        fldContent = content,

                        fldImport = (item["fldImport"].ToString() == "0" ? false : true),

                        fldOperId = -1,

                        fldType = info.type,

                        fldAuditingSate = fldAuditingSate
                    };
                    lstAuditingLog.Add(autitingLog);



                    break;
                }




                int result3 = ruleAuditing.ExecuteAuditingLog(lstAuditingLog);


                if (result1 > 0)
                {
                    result = "审核通过的数据执行成功!|";
                }

                if (result2 > 0)
                {
                    result += "审核未通过的数据执行成功!|";
                }

                if (result3 > 0)
                {
                    result += "审核日志记录执行成功!";
                }





                if (info.fldUserID != 0)
                {
                    using (Lap.Model.LAPContext db = new Lap.Model.LAPContext())
                    {
                        Lap.Model.tblFW_Log log = new Lap.Model.tblFW_Log();

                        log.fldModalName = info.fldModalName;

                        log.fldUserID = info.fldUserID;
                        log.fldCityID = info.fldCityID;
                        log.fldContent = info.fldContent;
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




                if (result != null)
                {
                    result = rule.JsonStr("ok", "执行成功！", result);
                }
                else
                {
                    result = rule.JsonStr("no", "执行失败！", "失败");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }






        public class AuditingActionEQIA_R_Info
        {
            public string type { get; set; }

            public string IDList { get; set; }

            public string AuditingType { get; set; }

            public string NewFlag { get; set; }



            public string fldModalName { get; set; }

            public int fldUserID { get; set; }

            public int fldCityID { get; set; }

            public string fldContent { get; set; }

            public string fldIPAddress { get; set; }
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
        /// 功能描述：数据状态修改
        /// 创建者  ：吕荣誉
        /// 创建日期：2017-7-5
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="obj">type：业务类型，audType：数据状态，“no”，“yes”，typeID：ID列表，comment：内容信息，datatime：日期，pname：pname</param>
        /// <returns>状态修改成功！，状态提交失败！</returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage AuditingActionState(dynamic obj)
        {
            string result = null;

            try
            {

                RuletblEQI_publi rtea = new RuletblEQI_publi();

                List<tbleqi_ThreeVerify> lstttv = new List<tbleqi_ThreeVerify>();

                // ID列表
                //string[] fldautoid = obj.typeID.ToString().Split(',');
                JArray fldautoid = JArray.Parse(obj.typeID.ToString());

                for (int i = 0; i < fldautoid.Count; i++)
                {
                    string[] pk = fldautoid[i].ToString().Split('_');

                    for (int j = 0; j < pk.Length; j++)
                    {
                        tbleqi_ThreeVerify ttv = new tbleqi_ThreeVerify();

                        ttv.fldType = obj.type.ToString();

                        ttv.fldTypeID = Convert.ToInt64(pk[j]);

                        ttv.fldComment = obj.comment.ToString();

                        ttv.fldAudType = obj.audType.ToString();

                        ttv.fldDataTime = DateTime.Now.ToString();

                        ttv.fldPName = obj.pname.ToString();

                        lstttv.Add(ttv);
                    }
                }

                if (rtea.ThreeVerifyIfUpdateOrInsert(lstttv))
                {
                    result = "状态修改成功！";
                }
                else
                {
                    result = "状态提交失败！";
                }

                if (result != null)
                {
                    result = rule.JsonStr("ok", "", result.ToString());
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
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AuditingData(Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@fldSTCode",info.fldSTCode),
                    new SqlParameter("@fldFlag",info.fldFlag),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@Source",info.Source),
                    new SqlParameter("@StatType",info.StatType),
                    new SqlParameter("@fldUserID",info.fldUserID)
                };

                string ProcName = null;

                if (info.type == "eqiw_r")
                {
                    ProcName = "usp_tblEQIW_R_Report_SectionAudit";
                }
                else if (info.type == "eqiw_l")
                {
                    ProcName = "usp_tblEQIW_L_Report_SectionAudit";
                }
                else if (info.type == "eqiw_d")
                {
                    ProcName = "usp_tblEQIW_D_Report_SectionAudit";
                }
                else if (info.type == "eqiw_r_auto")
                {
                    ProcName = "usp_tblEQIW_R_Auto_Report_SectionAudit";
                }
                else
                {
                    ProcName = "usp_tblEQIW_R_Report_SectionAudit";
                }


                dt = rule.RunProcedure_V2(ProcName, paras.ToList(), null, "EntityContext");


                if (dt.Columns.Contains("fldSort"))
                {
                    dt.Columns.Remove("fldSort");
                }

                if (dt.Columns.Contains("fldSectionType"))
                {
                    dt.Columns.Remove("fldSectionType");
                }

                DataTable dtItem = rule.getdt("select * from tblEQIW_R_Item");


                foreach (DataRow item in dtItem.Rows)
                {
                    foreach (DataColumn item2 in dt.Columns)
                    {
                        if (item2.ColumnName.Contains(item["fldItemCode"].ToString()))
                        {
                            int result1 = 0;
                            if (int.TryParse(item2.ColumnName.Substring(0, 3), out result1))
                            {
                                item2.ColumnName = item2.ColumnName.Replace(item["fldItemCode"].ToString(), item["fldChineseCode"].ToString()).Replace("_Value", "").Replace("Stage", "水质类别");
                            }
                        }
                    }
                }

                //功能描述：显示断面水质类别时，要增加括号显示具体是根据哪个因子判断的水质类别，有多个的话都列出来
                //创建者：熊瑞竹
                //创建日期：2018/02/05
                //修改者：
                //修改日期：
                #region
                if (info.type == "eqiw_r")
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string fldStage = dt.Rows[j]["fldStage"].ToString();
                        string item = "";
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (dt.Rows[j][dt.Columns[i].ColumnName].ToString().Contains(fldStage))
                            {
                                if (Array.IndexOf("fldFun、fldStage、fldMStage、fldYStage、fldItems、fldFitems".Split('、'), dt.Columns[i].ColumnName) == -1)
                                    item += dt.Columns[i - 1].ColumnName.ToString() + "、";
                            }
                        }
                        item = item.TrimEnd('、');
                        dt.Rows[j]["fldStage"] += "（" + item + "）";
                    }
                }
                #endregion

                string getjson = rule.GetJson(zhCNpath);


                List<zhCN> zhCN = JsonConvert.DeserializeObject<List<zhCN>>(getjson);


                var query = (from x in zhCN
                             where x.type == info.type
                             select x).FirstOrDefault();


                foreach (DataColumn item in dt.Columns)
                {
                    var query2 = (from x in query.Translators
                                  where x.Field == item.ColumnName
                                  select x).FirstOrDefault();
                    if (query2 != null)
                    {
                        item.ColumnName = query2.zh_CN;
                    }
                }






                #region 表达式处理


                dt.Columns.Add("其他因子逻辑对应关系", typeof(string)).SetOrdinal(5);

                dt.Columns.Add("颜色信息", typeof(string));

                List<tblCorrespond_Btype_ItemCode> list = new List<tblCorrespond_Btype_ItemCode>();

                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tblCorrespond_Btype_ItemCode
                            where x.fldExpression != null && x.fldExpression != ""
                            select x).ToList();
                }



                foreach (DataRow item in dt.Rows)
                {
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
                            if (!(dt.Columns.Contains(item2)))
                            {
                                bol = false;
                                break;
                            }
                        }


                        if (bol)
                        {
                            foreach (DataColumn item2 in dt.Columns)
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

                                            for (int i = 0; i < explist_temp.Count; i++)
                                            {
                                                if (explist_temp[i] == item2.ColumnName)
                                                {
                                                    explist_temp[i] = temp;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            for (int i = 0; i < explist_temp.Count; i++)
                                            {
                                                if (explist_temp[i] == item2.ColumnName)
                                                {
                                                    explist_temp[i] = item[item2.ColumnName].ToString().TrimEnd('(', ')', '（', '）', '/', 'Ⅰ', 'Ⅱ', 'Ⅲ', 'Ⅳ', 'Ⅴ', '劣');
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

                    item["其他因子逻辑对应关系"] = IDList.TrimEnd(',');

                    item["颜色信息"] = colorList.TrimEnd(',');

                }



                #endregion











                if (dt != null && dt.Rows.Count > 0)
                {
                    result = rule.JsonStr("ok", "", dt);
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




        public class Info
        {
            public string type { get; set; }

            public string fldSTCode { get; set; }

            public string fldFlag { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public int Source { get; set; }

            public int StatType { get; set; }

            public int fldUserID { get; set; }
        }







        public class zhCN
        {
            public string type { get; set; }

            public List<Translator> Translators { get; set; }
        }



        public class Translator
        {
            public string Field { get; set; }

            public string zh_CN { get; set; }
        }













        /// <summary>
        /// 功能描述：查询tblCorrespond_Btype_ItemCode表数据（公式）
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-8
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <returns>返回tblCorrespond_Btype_ItemCode实体集合</returns>
        [HttpPost]
        public HttpResponseMessage Query_tblCorrespond_Btype_ItemCode()
        {
            string result = string.Empty;
            int result2 = 0;
            try
            {
                List<tblCorrespond_Btype_ItemCode> list = new List<tblCorrespond_Btype_ItemCode>();
                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tblCorrespond_Btype_ItemCode
                            where x.fldExpression != null && x.fldExpression != ""
                            select x).ToList();
                }

                if (list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
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
        /// 功能描述：新增或者更新tblCorrespond_Btype_ItemCode表数据（公式）
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-8
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns>返回tblCorrespond_Btype_ItemCode实体</returns>
        [HttpPost]
        public HttpResponseMessage AddOrUpdate_tblCorrespond_Btype_ItemCode(AddOrUpdate_tblCorrespond_Btype_ItemCode_Info info)
        {
            string result = string.Empty;
            int result2 = 0;
            try
            {
                if (info.fldExpression == "" || info.fldExpression == null)
                {
                    result = rule.JsonStr("nodata", "表达式不能为空！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }

                if (info.fldIndex == "" || info.fldIndex == null)
                {
                    result = rule.JsonStr("nodata", "序号不能为空！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };

                }
                else
                {
                    using (EntityContext db = new EntityContext())
                    {
                        var query = (from x in db.tblCorrespond_Btype_ItemCode
                                     where x.fldIndex == info.fldIndex
                                     select x).Count();

                        if (query > 0)
                        {
                            result = rule.JsonStr("nodata", "序号已经存在！", "");
                            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                        }
                    }
                }


                using (EntityContext db = new EntityContext())
                {
                    tblCorrespond_Btype_ItemCode name = new tblCorrespond_Btype_ItemCode();
                    name.fldAutoid = info.fldAutoid;
                    name.fldBName = info.fldBName;
                    name.fldItemCode = info.fldItemCode;
                    name.fldItemName = info.fldItemName;
                    name.fldRelation = info.fldRelation;
                    name.fldCItemCode = info.fldCItemCode;
                    name.fldCItemName = info.fldCItemName;
                    name.fldIndex = info.fldIndex;
                    name.fldExpression = info.fldExpression;


                    db.tblCorrespond_Btype_ItemCode.AddOrUpdate(name);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", result2.ToString());
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
        /// 参数实体
        /// </summary>
        public class AddOrUpdate_tblCorrespond_Btype_ItemCode_Info
        {
            public int fldAutoid { get; set; }

            public string fldBName { get; set; }

            public string fldItemCode { get; set; }

            public string fldItemName { get; set; }

            public string fldRelation { get; set; }

            public string fldCItemCode { get; set; }

            public string fldCItemName { get; set; }

            public string fldIndex { get; set; }

            public string fldExpression { get; set; }
        }














        /// <summary>
        /// 功能描述：删除tblCorrespond_Btype_ItemCode表数据（公式）
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-8
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns>返回删除数量</returns>
        [HttpPost]
        public HttpResponseMessage Delete_tblCorrespond_Btype_ItemCode(Delete_tblCorrespond_Btype_ItemCode_Info info)
        {
            string result = string.Empty;
            int result2 = 0;
            try
            {
                List<tblCorrespond_Btype_ItemCode> list = new List<tblCorrespond_Btype_ItemCode>();
                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tblCorrespond_Btype_ItemCode
                            where info.fldAutoid_List.Contains(x.fldAutoid)
                            select x).ToList();

                    db.tblCorrespond_Btype_ItemCode.RemoveRange(list);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", result2);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有可以删除的数据！", "");
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
        public class Delete_tblCorrespond_Btype_ItemCode_Info
        {
            public List<int> fldAutoid_List { get; set; }

        }


































        /// <summary>
        /// 功能描述：提醒功能
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-8
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns>返回Remind_Return实体</returns>
        [HttpPost]
        public HttpResponseMessage Remind(Remind_Info info)
        {
            string result = string.Empty;
            try
            {
                List<Remind_Return> list2 = new List<Remind_Return>();
















                using (EntityContext db = new EntityContext())
                {
                    foreach (var item in info.typeList)
                    {
                        Remind_Return rr = new Remind_Return();

                        rr.type = item;




                        DataTable dt = rule.SqlQueryForDataTatable("LAPContext", "select * from tblFW_User where fldAutoID = " + info.fldUserID);

                        string UserLevel = dt.Rows[0]["fldUserName"].ToString().Substring(dt.Rows[0]["fldUserName"].ToString().Length - 1, 1);

                        List<int> fldFlag_List = new List<int>();

                        if (UserLevel == "1")
                        {
                            fldFlag_List.Add(0);
                        }

                        if (UserLevel == "2")
                        {
                            fldFlag_List.Add(2);
                        }

                        if (UserLevel == "3")
                        {
                            fldFlag_List.Add(3);
                        }

                        string One_UserName = dt.Rows[0]["fldUserName"].ToString().Replace("2", "1").Replace("3", "1");

                        DataTable dt2 = rule.SqlQueryForDataTatable("LAPContext", "select * from tblFW_User where fldUserName = '" + One_UserName + "'");

                        int One_UserID = int.Parse(dt2.Rows[0]["fldAutoID"].ToString());






                        //地表水
                        if (item == "eqiw_r")
                        {
                            List<string> value = new List<string>();
                            value.Add("综合整治湖库");
                            value.Add("大中型水库");
                            value.Add("水华");

                            var sectionlist = (from x in db.tblEQIW_R_Section
                                               where !value.Contains(x.fldAttribute)
                                               select x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode).ToList();


                            List<Mode.tblEQIW_R_Basedata_Pre> list = new List<Mode.tblEQIW_R_Basedata_Pre>();


                            if (info.fldUserID == 578)
                            {
                                list = (from x in db.tblEQIW_R_Basedata_Pre
                                        where sectionlist.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                        select x).ToList();
                                fldFlag_List.Add(0);
                                fldFlag_List.Add(2);
                                fldFlag_List.Add(3);
                            }
                            else
                            {
                                list = (from x in db.tblEQIW_R_Basedata_Pre
                                        where sectionlist.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                        x.fldUserID == One_UserID
                                        select x).ToList();
                            }









                            var PreCount = (from x in list
                                            where x.fldFlag == 0
                                            group x by new
                                            {
                                                x.fldSTCode,
                                                x.fldRCode,
                                                x.fldRSCode,
                                                x.fldSAMPH,
                                                x.fldSAMPR,
                                                x.fldYear,
                                                x.fldMonth,
                                                x.fldDay,
                                                x.fldHour,
                                                x.fldMinute
                                            } into g
                                            select g).ToList().Count;

                            rr.PreCount = PreCount;





                            var PreCount2 = (from x in list
                                             where x.fldFlag == 1
                                             group x by new
                                             {
                                                 x.fldSTCode,
                                                 x.fldRCode,
                                                 x.fldRSCode,
                                                 x.fldSAMPH,
                                                 x.fldSAMPR,
                                                 x.fldYear,
                                                 x.fldMonth,
                                                 x.fldDay,
                                                 x.fldHour,
                                                 x.fldMinute
                                             } into g
                                             select g).ToList().Count;

                            rr.PreCount2 = PreCount2;






                            var GoBackCount = (from x in list
                                               where x.fldFlag == -1
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldRCode,
                                                   x.fldRSCode,
                                                   x.fldSAMPH,
                                                   x.fldSAMPR,
                                                   x.fldYear,
                                                   x.fldMonth,
                                                   x.fldDay,
                                                   x.fldHour,
                                                   x.fldMinute
                                               } into g
                                               select g).ToList().Count;

                            rr.GoBackCount = GoBackCount;







                            var ThreeLevel = (from x in list
                                              where fldFlag_List.Contains(x.fldFlag)
                                              group x by new
                                              {
                                                  x.fldSTCode,
                                                  x.fldRCode,
                                                  x.fldRSCode,
                                                  x.fldSAMPH,
                                                  x.fldSAMPR,
                                                  x.fldYear,
                                                  x.fldMonth,
                                                  x.fldDay,
                                                  x.fldHour,
                                                  x.fldMinute
                                              } into g
                                              select g).ToList().Count;

                            rr.ThreeLevel = ThreeLevel;







                        }







                        //水华
                        else if (item == "eqise")
                        {

                            List<string> value = new List<string>();
                            value.Add("综合整治湖库");
                            value.Add("大中型水库");
                            value.Add("水华");

                            var sectionlist = (from x in db.tblEQIW_R_Section
                                               where value.Contains(x.fldAttribute)
                                               select x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode).ToList();



                            List<Mode.tblEQIW_R_Basedata_Pre> list = new List<Mode.tblEQIW_R_Basedata_Pre>();


                            if (info.fldUserID == 578)
                            {
                                list = (from x in db.tblEQIW_R_Basedata_Pre
                                        where sectionlist.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                        select x).ToList();
                                fldFlag_List.Add(0);
                                fldFlag_List.Add(2);
                                fldFlag_List.Add(3);
                            }
                            else
                            {
                                list = (from x in db.tblEQIW_R_Basedata_Pre
                                        where sectionlist.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                        x.fldUserID == One_UserID
                                        select x).ToList();
                            }













                            var PreCount = (from x in list
                                            where x.fldFlag == 0
                                            group x by new
                                            {
                                                x.fldSTCode,
                                                x.fldRCode,
                                                x.fldRSCode,
                                                x.fldSAMPH,
                                                x.fldSAMPR,
                                                x.fldYear,
                                                x.fldMonth,
                                                x.fldDay,
                                                x.fldHour,
                                                x.fldMinute
                                            } into g
                                            select g).ToList().Count;

                            rr.PreCount = PreCount;





                            var PreCount2 = (from x in list
                                             where x.fldFlag == 1
                                             group x by new
                                             {
                                                 x.fldSTCode,
                                                 x.fldRCode,
                                                 x.fldRSCode,
                                                 x.fldSAMPH,
                                                 x.fldSAMPR,
                                                 x.fldYear,
                                                 x.fldMonth,
                                                 x.fldDay,
                                                 x.fldHour,
                                                 x.fldMinute
                                             } into g
                                             select g).ToList().Count;

                            rr.PreCount2 = PreCount2;






                            var GoBackCount = (from x in list
                                               where x.fldFlag == -1
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldRCode,
                                                   x.fldRSCode,
                                                   x.fldSAMPH,
                                                   x.fldSAMPR,
                                                   x.fldYear,
                                                   x.fldMonth,
                                                   x.fldDay,
                                                   x.fldHour,
                                                   x.fldMinute
                                               } into g
                                               select g).ToList().Count;

                            rr.GoBackCount = GoBackCount;









                            var ThreeLevel = (from x in list
                                              where fldFlag_List.Contains(x.fldFlag)
                                              group x by new
                                              {
                                                  x.fldSTCode,
                                                  x.fldRCode,
                                                  x.fldRSCode,
                                                  x.fldSAMPH,
                                                  x.fldSAMPR,
                                                  x.fldYear,
                                                  x.fldMonth,
                                                  x.fldDay,
                                                  x.fldHour,
                                                  x.fldMinute
                                              } into g
                                              select g).ToList().Count;

                            rr.ThreeLevel = ThreeLevel;







                        }






                        //地市饮用水
                        else if (item == "eqiw_d")
                        {




                            List<Mode.tblEQIW_D_Basedata_Pre> list = new List<Mode.tblEQIW_D_Basedata_Pre>();


                            if (info.fldUserID == 578)
                            {
                                list = (from x in db.tblEQIW_D_Basedata_Pre
                                        select x).ToList();
                                fldFlag_List.Add(0);
                                fldFlag_List.Add(2);
                                fldFlag_List.Add(3);
                            }
                            else
                            {
                                list = (from x in db.tblEQIW_D_Basedata_Pre
                                        where x.fldUserID == One_UserID
                                        select x).ToList();
                            }








                            var PreCount = (from x in list
                                            where x.fldFlag == 0
                                            group x by new
                                            {
                                                x.fldSTCode,
                                                x.fldRCode,
                                                x.fldRSCode,
                                                x.fldSAMPH,
                                                x.fldSAMPR,
                                                x.fldYear,
                                                x.fldMonth,
                                                x.fldDay,
                                                x.fldHour,
                                                x.fldMinute
                                            } into g
                                            select g).Count();

                            rr.PreCount = PreCount;










                            var PreCount2 = (from x in list
                                             where x.fldFlag == 1
                                             group x by new
                                             {
                                                 x.fldSTCode,
                                                 x.fldRCode,
                                                 x.fldRSCode,
                                                 x.fldSAMPH,
                                                 x.fldSAMPR,
                                                 x.fldYear,
                                                 x.fldMonth,
                                                 x.fldDay,
                                                 x.fldHour,
                                                 x.fldMinute
                                             } into g
                                             select g).Count();

                            rr.PreCount2 = PreCount2;








                            var GoBackCount = (from x in list
                                               where x.fldFlag == -1
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldRCode,
                                                   x.fldRSCode,
                                                   x.fldSAMPH,
                                                   x.fldSAMPR,
                                                   x.fldYear,
                                                   x.fldMonth,
                                                   x.fldDay,
                                                   x.fldHour,
                                                   x.fldMinute
                                               } into g
                                               select g).Count();

                            rr.GoBackCount = GoBackCount;






                            var ThreeLevel = (from x in list
                                              where fldFlag_List.Contains(x.fldFlag)
                                              group x by new
                                              {
                                                  x.fldSTCode,
                                                  x.fldRCode,
                                                  x.fldRSCode,
                                                  x.fldSAMPH,
                                                  x.fldSAMPR,
                                                  x.fldYear,
                                                  x.fldMonth,
                                                  x.fldDay,
                                                  x.fldHour,
                                                  x.fldMinute
                                              } into g
                                              select g).ToList().Count;

                            rr.ThreeLevel = ThreeLevel;

                        }





                        //区县饮用水
                        else if (item == "eqiw_dt")
                        {

                            List<Mode.tblEQIW_DT_Basedata_Pre> list = new List<Mode.tblEQIW_DT_Basedata_Pre>();


                            if (info.fldUserID == 578)
                            {
                                list = (from x in db.tblEQIW_DT_Basedata_Pre
                                        select x).ToList();
                                fldFlag_List.Add(0);
                                fldFlag_List.Add(2);
                                fldFlag_List.Add(3);
                            }
                            else
                            {
                                list = (from x in db.tblEQIW_DT_Basedata_Pre
                                        where x.fldUserID == One_UserID
                                        select x).ToList();
                            }




                            var PreCount = (from x in list
                                            where x.fldFlag == 0
                                            group x by new
                                            {
                                                x.fldSTCode,
                                                x.fldRCode,
                                                x.fldRSCode,
                                                x.fldSAMPH,
                                                x.fldSAMPR,
                                                x.fldYear,
                                                x.fldMonth,
                                                x.fldDay,
                                                x.fldHour,
                                                x.fldMinute
                                            } into g
                                            select g).Count();

                            rr.PreCount = PreCount;





                            var PreCount2 = (from x in db.tblEQIW_DT_Basedata_Pre
                                             where x.fldFlag == 1
                                             group x by new
                                             {
                                                 x.fldSTCode,
                                                 x.fldRCode,
                                                 x.fldRSCode,
                                                 x.fldSAMPH,
                                                 x.fldSAMPR,
                                                 x.fldYear,
                                                 x.fldMonth,
                                                 x.fldDay,
                                                 x.fldHour,
                                                 x.fldMinute
                                             } into g
                                             select g).Count();

                            rr.PreCount2 = PreCount2;










                            var GoBackCount = (from x in db.tblEQIW_DT_Basedata_Pre
                                               where x.fldFlag == -1
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldRCode,
                                                   x.fldRSCode,
                                                   x.fldSAMPH,
                                                   x.fldSAMPR,
                                                   x.fldYear,
                                                   x.fldMonth,
                                                   x.fldDay,
                                                   x.fldHour,
                                                   x.fldMinute
                                               } into g
                                               select g).Count();

                            rr.GoBackCount = GoBackCount;




                            var ThreeLevel = (from x in list
                                              where fldFlag_List.Contains(x.fldFlag)
                                              group x by new
                                              {
                                                  x.fldSTCode,
                                                  x.fldRCode,
                                                  x.fldRSCode,
                                                  x.fldSAMPH,
                                                  x.fldSAMPR,
                                                  x.fldYear,
                                                  x.fldMonth,
                                                  x.fldDay,
                                                  x.fldHour,
                                                  x.fldMinute
                                              } into g
                                              select g).ToList().Count;

                            rr.ThreeLevel = ThreeLevel;


                        }





                        //乡镇饮用水
                        else if (item == "eqiw_dx")
                        {


                            List<Mode.tbleqiw_dx_Basedata_Pre> list = new List<Mode.tbleqiw_dx_Basedata_Pre>();


                            if (info.fldUserID == 578)
                            {
                                list = (from x in db.tbleqiw_dx_Basedata_Pre
                                        select x).ToList();
                                fldFlag_List.Add(0);
                                fldFlag_List.Add(2);
                                fldFlag_List.Add(3);
                            }
                            else
                            {
                                list = (from x in db.tbleqiw_dx_Basedata_Pre
                                        where x.fldUserID == One_UserID
                                        select x).ToList();
                            }


                            var PreCount = (from x in list
                                            where x.fldFlag == 0
                                            group x by new
                                            {
                                                x.fldSTCode,
                                                x.fldRCode,
                                                x.fldRSCode,
                                                x.fldSAMPH,
                                                x.fldSAMPR,
                                                x.fldYear,
                                                x.fldMonth,
                                                x.fldDay,
                                                x.fldHour,
                                                x.fldMinute
                                            } into g
                                            select g).Count();

                            rr.PreCount = PreCount;




                            var PreCount2 = (from x in list
                                             where x.fldFlag == 1
                                             group x by new
                                             {
                                                 x.fldSTCode,
                                                 x.fldRCode,
                                                 x.fldRSCode,
                                                 x.fldSAMPH,
                                                 x.fldSAMPR,
                                                 x.fldYear,
                                                 x.fldMonth,
                                                 x.fldDay,
                                                 x.fldHour,
                                                 x.fldMinute
                                             } into g
                                             select g).Count();

                            rr.PreCount2 = PreCount2;















                            var GoBackCount = (from x in list
                                               where x.fldFlag == -1
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldRCode,
                                                   x.fldRSCode,
                                                   x.fldSAMPH,
                                                   x.fldSAMPR,
                                                   x.fldYear,
                                                   x.fldMonth,
                                                   x.fldDay,
                                                   x.fldHour,
                                                   x.fldMinute
                                               } into g
                                               select g).Count();

                            rr.GoBackCount = GoBackCount;







                            var ThreeLevel = (from x in list
                                              where fldFlag_List.Contains(x.fldFlag)
                                              group x by new
                                              {
                                                  x.fldSTCode,
                                                  x.fldRCode,
                                                  x.fldRSCode,
                                                  x.fldSAMPH,
                                                  x.fldSAMPR,
                                                  x.fldYear,
                                                  x.fldMonth,
                                                  x.fldDay,
                                                  x.fldHour,
                                                  x.fldMinute
                                              } into g
                                              select g).ToList().Count;

                            rr.ThreeLevel = ThreeLevel;


                        }





                        list2.Add(rr);

                    }
                }

                result = rule.JsonStr("ok", "", list2);
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
        public class Remind_Info
        {
            /// <summary>
            /// eqise：水华
            /// eqiw_r：地表水
            /// eqiw_d：地市饮用水
            /// eqiw_dt：区县饮用水
            /// eqiw_dx：乡镇饮用水
            /// </summary>
            public List<string> typeList { get; set; }


            public int fldUserID { get; set; }
        }







        /// <summary>
        /// 返回实体
        /// </summary>
        public class Remind_Return
        {
            /// <summary>
            /// 业务类型
            /// </summary>
            public string type { get; set; }


            /// <summary>
            /// 待审核条数，fldFlag = 0
            /// </summary>
            public int PreCount { get; set; }


            /// <summary>
            /// 监测数据审核，fldFlag = 1
            /// </summary>
            public int PreCount2 { get; set; }


            /// <summary>
            /// 审核退回的数据，fldFlag = -1
            /// </summary>
            public int GoBackCount { get; set; }


            /// <summary>
            /// 当前用户，三级审核条数
            /// </summary>
            public int ThreeLevel { get; set; }


        }




























        /// <summary>
        /// 功能描述：市站上报统计优化
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-8
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns>返回Remind_Return实体</returns>
        [HttpPost]
        public HttpResponseMessage STCodeApprise(STCodeApprise_Info info)
        {
            string result = string.Empty;

            try
            {
                List<STCodeApprise_Return> retrun_data = new List<STCodeApprise_Return>();



                if (HttpUtility.UrlDecode(info.DataType) == "入库前")
                {
                    using (EntityContext db = new EntityContext())
                    {
                        foreach (var item_Raw in info.RawDatas)
                        {
                            string SectionType = HttpUtility.UrlDecode(item_Raw.SectionType);
                            if (item_Raw.type == "eqiw_r")
                            {



                                #region 断面以及数据处理

                                var query_section = (from x in db.tblEQIW_R_Section
                                                     where SectionType.Contains(x.fldAttribute) &&
                                                     x.fldYear == DateTime.Now.Year
                                                     select x).ToList();

                                var query_data = (from x in query_section
                                                  join y in db.tblEQIW_R_Basedata_Pre
                                                  on new
                                                  {
                                                      x.fldSTCode,
                                                      x.fldRCode,
                                                      x.fldRSCode
                                                  }
                                                  equals new
                                                  {
                                                      y.fldSTCode,
                                                      y.fldRCode,
                                                      y.fldRSCode
                                                  }
                                                  select y).ToList();

                                foreach (var item in query_data)
                                {
                                    item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay + " " + item.fldHour + ":" + item.fldMinute + ":00");
                                }



                                #endregion






                                #region 日期处理


                                DateTime fldBeginDate = DateTime.Now;
                                DateTime fldEndDate = DateTime.Now;

                                DateTime Now = DateTime.Now;

                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每月")
                                {
                                    fldBeginDate = new DateTime(Now.Year, Now.Month, 1);

                                    fldEndDate = fldBeginDate.AddMonths(1).AddSeconds(-1);
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每季度")
                                {
                                    fldBeginDate = Now.AddMonths(0 - (Now.Month - 1) % 3).AddDays(1 - Now.Day);//本季度初

                                    fldEndDate = fldBeginDate.AddMonths(3).AddDays(-1);  //本季度末
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每半年")
                                {
                                    if (Now.Year < 7)
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 1, 1);

                                        fldEndDate = new DateTime(Now.Year, 6, 30);
                                    }
                                    else
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 7, 1);

                                        fldEndDate = new DateTime(Now.Year, 12, 31);
                                    }
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每年")
                                {
                                    fldBeginDate = new DateTime(Now.Year, 1, 1);

                                    fldEndDate = new DateTime(Now.Year, 12, 31);
                                }



                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "5月、8月、11月")
                                {
                                    DateTime T1B = new DateTime(Now.Year, 5, 1);
                                    DateTime T1E = new DateTime(Now.Year, 5, 31);

                                    DateTime T2B = new DateTime(Now.Year, 8, 1);
                                    DateTime T2E = new DateTime(Now.Year, 8, 31);

                                    DateTime T3B = new DateTime(Now.Year, 11, 1);
                                    DateTime T3E = new DateTime(Now.Year, 11, 30);


                                    var query_data1 = (from x in query_data
                                                       where x.fldDate >= T1B && x.fldDate <= T1E
                                                       select x).ToList();
                                    query_data.AddRange(query_data1);


                                    var query_data2 = (from x in query_data
                                                       where x.fldDate >= T2B && x.fldDate <= T2E
                                                       select x).ToList();
                                    query_data.AddRange(query_data2);



                                    var query_data3 = (from x in query_data
                                                       where x.fldDate >= T3B && x.fldDate <= T3E
                                                       select x).ToList();
                                    query_data.AddRange(query_data3);
                                }
                                else
                                {
                                    query_data = (from x in query_data
                                                  where x.fldDate >= fldBeginDate && x.fldDate <= fldEndDate
                                                  select x).ToList();
                                }

                                #endregion






                                #region 备注处理以及源数据处理


                                query_data = (from x in query_data
                                              where item_Raw.ItemCode.Contains(x.fldItemCode)
                                              select x).ToList();


                                var query_remark = (from x in db.tblEQI_DataImport_Remark
                                                    where x.fldObject == item_Raw.type
                                                    select x).ToList();

                                foreach (var item in query_remark)
                                {
                                    item.fldDate_2 = DateTime.Parse(item.fldDate.Trim());
                                }

                                query_remark = (from x in query_remark
                                                where x.fldDate_2 >= fldBeginDate && x.fldDate_2 <= fldEndDate
                                                select x).ToList();






                                var query_item = (from x in db.tblEQIW_R_Item
                                                  select x).ToList();


                                #endregion






                                #region 主体处理



                                retrun_data = (from x in query_section
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldSTName,
                                                   x.fldRCode,
                                                   x.fldRName,
                                                   x.fldRSCode,
                                                   x.fldRSName,
                                                   x.fldAttribute
                                               } into g
                                               select new STCodeApprise_Return
                                               {
                                                   fldSTName = g.Key.fldSTName,

                                                   SectionType = g.Key.fldAttribute,

                                                   PointName = g.Key.fldRSName,

                                                   ItemCode = Calc_ItemCode_R_Pre(query_data, item_Raw.ItemCode, query_item),

                                                   Remark = Calc_Remark_R_Pre(query_data, query_remark, g.Key.fldSTCode, g.Key.fldRCode, g.Key.fldRSCode)

                                               }).ToList();
                                #endregion




                            }


                            if (item_Raw.type == "eqiw_d")
                            {



                                #region 断面以及数据处理

                                List<int?> sectiontype = new List<int?>();

                                List<string> temp = SectionType.Split(',').ToList();


                                foreach (var item in temp)
                                {
                                    sectiontype.Add(int.Parse(item));
                                }


                                var query_section = (from x in db.tblEQIW_D_Section
                                                     where sectiontype.Contains(x.fldSCategory) &&
                                                     x.fldYear == DateTime.Now.Year
                                                     select x).ToList();

                                var query_data = (from x in query_section
                                                  join y in db.tblEQIW_D_Basedata_Pre
                                                  on new
                                                  {
                                                      x.fldSTCode,
                                                      x.fldRCode,
                                                      x.fldRSCode
                                                  }
                                                  equals new
                                                  {
                                                      y.fldSTCode,
                                                      y.fldRCode,
                                                      y.fldRSCode
                                                  }
                                                  select y).ToList();

                                foreach (var item in query_data)
                                {
                                    item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay + " " + item.fldHour + ":" + item.fldMinute + ":00");
                                }



                                #endregion






                                #region 日期处理


                                DateTime fldBeginDate = DateTime.Now;
                                DateTime fldEndDate = DateTime.Now;

                                DateTime Now = DateTime.Now;

                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每月")
                                {
                                    fldBeginDate = new DateTime(Now.Year, Now.Month, 1);

                                    fldEndDate = fldBeginDate.AddMonths(1).AddSeconds(-1);
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每季度")
                                {
                                    fldBeginDate = Now.AddMonths(0 - (Now.Month - 1) % 3).AddDays(1 - Now.Day);//本季度初

                                    fldEndDate = fldBeginDate.AddMonths(3).AddDays(-1);  //本季度末
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每半年")
                                {
                                    if (Now.Year < 7)
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 1, 1);

                                        fldEndDate = new DateTime(Now.Year, 6, 30);
                                    }
                                    else
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 7, 1);

                                        fldEndDate = new DateTime(Now.Year, 12, 31);
                                    }
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每年")
                                {
                                    fldBeginDate = new DateTime(Now.Year, 1, 1);

                                    fldEndDate = new DateTime(Now.Year, 12, 31);
                                }



                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "5月、8月、11月")
                                {
                                    DateTime T1B = new DateTime(Now.Year, 5, 1);
                                    DateTime T1E = new DateTime(Now.Year, 5, 31);

                                    DateTime T2B = new DateTime(Now.Year, 8, 1);
                                    DateTime T2E = new DateTime(Now.Year, 8, 31);

                                    DateTime T3B = new DateTime(Now.Year, 11, 1);
                                    DateTime T3E = new DateTime(Now.Year, 11, 30);


                                    var query_data1 = (from x in query_data
                                                       where x.fldDate >= T1B && x.fldDate <= T1E
                                                       select x).ToList();
                                    query_data.AddRange(query_data1);


                                    var query_data2 = (from x in query_data
                                                       where x.fldDate >= T2B && x.fldDate <= T2E
                                                       select x).ToList();
                                    query_data.AddRange(query_data2);



                                    var query_data3 = (from x in query_data
                                                       where x.fldDate >= T3B && x.fldDate <= T3E
                                                       select x).ToList();
                                    query_data.AddRange(query_data3);
                                }
                                else
                                {
                                    query_data = (from x in query_data
                                                  where x.fldDate >= fldBeginDate && x.fldDate <= fldEndDate
                                                  select x).ToList();
                                }

                                #endregion






                                #region 备注处理以及源数据处理


                                query_data = (from x in query_data
                                              where item_Raw.ItemCode.Contains(x.fldItemCode)
                                              select x).ToList();


                                var query_remark = (from x in db.tblEQI_DataImport_Remark
                                                    where x.fldObject == item_Raw.type
                                                    select x).ToList();

                                foreach (var item in query_remark)
                                {
                                    item.fldDate_2 = DateTime.Parse(item.fldDate.Trim());
                                }

                                query_remark = (from x in query_remark
                                                where x.fldDate_2 >= fldBeginDate && x.fldDate_2 <= fldEndDate
                                                select x).ToList();






                                var query_item = (from x in db.tblEQIW_R_Item
                                                  select x).ToList();


                                #endregion






                                #region 主体处理



                                retrun_data = (from x in query_section
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldSTName,
                                                   x.fldRCode,
                                                   x.fldRName,
                                                   x.fldRSCode,
                                                   x.fldRSName,
                                                   x.fldSCategory
                                               } into g
                                               select new STCodeApprise_Return
                                               {
                                                   fldSTName = g.Key.fldSTName,

                                                   SectionType = Convert.ToString(g.Key.fldSCategory),

                                                   PointName = g.Key.fldRSName,

                                                   ItemCode = Calc_ItemCode_D_Pre(query_data, item_Raw.ItemCode, query_item),

                                                   Remark = Calc_Remark_D_Pre(query_data, query_remark, g.Key.fldSTCode, g.Key.fldRCode, g.Key.fldRSCode)

                                               }).ToList();
                                #endregion




                            }


                            if (item_Raw.type == "eqiw_dt")
                            {



                                #region 断面以及数据处理

                                List<int?> sectiontype = new List<int?>();

                                List<string> temp = SectionType.Split(',').ToList();


                                foreach (var item in temp)
                                {
                                    sectiontype.Add(int.Parse(item));
                                }


                                var query_section = (from x in db.tblEQIW_DT_Section
                                                     where sectiontype.Contains(x.fldSCategory) &&
                                                     x.fldYear == DateTime.Now.Year
                                                     select x).ToList();

                                var query_data = (from x in query_section
                                                  join y in db.tblEQIW_DT_Basedata_Pre
                                                  on new
                                                  {
                                                      x.fldSTCode,
                                                      x.fldRCode,
                                                      x.fldRSCode
                                                  }
                                                  equals new
                                                  {
                                                      y.fldSTCode,
                                                      y.fldRCode,
                                                      y.fldRSCode
                                                  }
                                                  select y).ToList();

                                foreach (var item in query_data)
                                {
                                    item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay + " " + item.fldHour + ":" + item.fldMinute + ":00");
                                }



                                #endregion






                                #region 日期处理


                                DateTime fldBeginDate = DateTime.Now;
                                DateTime fldEndDate = DateTime.Now;

                                DateTime Now = DateTime.Now;

                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每月")
                                {
                                    fldBeginDate = new DateTime(Now.Year, Now.Month, 1);

                                    fldEndDate = fldBeginDate.AddMonths(1).AddSeconds(-1);
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每季度")
                                {
                                    fldBeginDate = Now.AddMonths(0 - (Now.Month - 1) % 3).AddDays(1 - Now.Day);//本季度初

                                    fldEndDate = fldBeginDate.AddMonths(3).AddDays(-1);  //本季度末
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每半年")
                                {
                                    if (Now.Year < 7)
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 1, 1);

                                        fldEndDate = new DateTime(Now.Year, 6, 30);
                                    }
                                    else
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 7, 1);

                                        fldEndDate = new DateTime(Now.Year, 12, 31);
                                    }
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每年")
                                {
                                    fldBeginDate = new DateTime(Now.Year, 1, 1);

                                    fldEndDate = new DateTime(Now.Year, 12, 31);
                                }



                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "5月、8月、11月")
                                {
                                    DateTime T1B = new DateTime(Now.Year, 5, 1);
                                    DateTime T1E = new DateTime(Now.Year, 5, 31);

                                    DateTime T2B = new DateTime(Now.Year, 8, 1);
                                    DateTime T2E = new DateTime(Now.Year, 8, 31);

                                    DateTime T3B = new DateTime(Now.Year, 11, 1);
                                    DateTime T3E = new DateTime(Now.Year, 11, 30);


                                    var query_data1 = (from x in query_data
                                                       where x.fldDate >= T1B && x.fldDate <= T1E
                                                       select x).ToList();
                                    query_data.AddRange(query_data1);


                                    var query_data2 = (from x in query_data
                                                       where x.fldDate >= T2B && x.fldDate <= T2E
                                                       select x).ToList();
                                    query_data.AddRange(query_data2);



                                    var query_data3 = (from x in query_data
                                                       where x.fldDate >= T3B && x.fldDate <= T3E
                                                       select x).ToList();
                                    query_data.AddRange(query_data3);
                                }
                                else
                                {
                                    query_data = (from x in query_data
                                                  where x.fldDate >= fldBeginDate && x.fldDate <= fldEndDate
                                                  select x).ToList();
                                }

                                #endregion






                                #region 备注处理以及源数据处理


                                query_data = (from x in query_data
                                              where item_Raw.ItemCode.Contains(x.fldItemCode)
                                              select x).ToList();


                                var query_remark = (from x in db.tblEQI_DataImport_Remark
                                                    where x.fldObject == item_Raw.type
                                                    select x).ToList();

                                foreach (var item in query_remark)
                                {
                                    item.fldDate_2 = DateTime.Parse(item.fldDate.Trim());
                                }

                                query_remark = (from x in query_remark
                                                where x.fldDate_2 >= fldBeginDate && x.fldDate_2 <= fldEndDate
                                                select x).ToList();






                                var query_item = (from x in db.tblEQIW_R_Item
                                                  select x).ToList();


                                #endregion






                                #region 主体处理



                                retrun_data = (from x in query_section
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldSTName,
                                                   x.fldRCode,
                                                   x.fldRName,
                                                   x.fldRSCode,
                                                   x.fldRSName,
                                                   x.fldSCategory
                                               } into g
                                               select new STCodeApprise_Return
                                               {
                                                   fldSTName = g.Key.fldSTName,

                                                   SectionType = Convert.ToString(g.Key.fldSCategory),

                                                   PointName = g.Key.fldRSName,

                                                   ItemCode = Calc_ItemCode_DT_Pre(query_data, item_Raw.ItemCode, query_item),

                                                   Remark = Calc_Remark_DT_Pre(query_data, query_remark, g.Key.fldSTCode, g.Key.fldRCode, g.Key.fldRSCode)

                                               }).ToList();
                                #endregion




                            }


                            if (item_Raw.type == "eqiw_dx")
                            {



                                #region 断面以及数据处理

                                List<int?> sectiontype = new List<int?>();

                                List<string> temp = SectionType.Split(',').ToList();


                                foreach (var item in temp)
                                {
                                    sectiontype.Add(int.Parse(item));
                                }


                                var query_section = (from x in db.tbleqiw_dx_Section
                                                     where sectiontype.Contains(x.fldSCategory) &&
                                                     x.fldYear == DateTime.Now.Year
                                                     select x).ToList();

                                var query_data = (from x in query_section
                                                  join y in db.tbleqiw_dx_Basedata_Pre
                                                  on new
                                                  {
                                                      x.fldSTCode,
                                                      x.fldRCode,
                                                      x.fldRSCode
                                                  }
                                                  equals new
                                                  {
                                                      y.fldSTCode,
                                                      y.fldRCode,
                                                      y.fldRSCode
                                                  }
                                                  select y).ToList();

                                foreach (var item in query_data)
                                {
                                    item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay + " " + item.fldHour + ":" + item.fldMinute + ":00");
                                }



                                #endregion






                                #region 日期处理


                                DateTime fldBeginDate = DateTime.Now;
                                DateTime fldEndDate = DateTime.Now;

                                DateTime Now = DateTime.Now;

                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每月")
                                {
                                    fldBeginDate = new DateTime(Now.Year, Now.Month, 1);

                                    fldEndDate = fldBeginDate.AddMonths(1).AddSeconds(-1);
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每季度")
                                {
                                    fldBeginDate = Now.AddMonths(0 - (Now.Month - 1) % 3).AddDays(1 - Now.Day);//本季度初

                                    fldEndDate = fldBeginDate.AddMonths(3).AddDays(-1);  //本季度末
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每半年")
                                {
                                    if (Now.Year < 7)
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 1, 1);

                                        fldEndDate = new DateTime(Now.Year, 6, 30);
                                    }
                                    else
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 7, 1);

                                        fldEndDate = new DateTime(Now.Year, 12, 31);
                                    }
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每年")
                                {
                                    fldBeginDate = new DateTime(Now.Year, 1, 1);

                                    fldEndDate = new DateTime(Now.Year, 12, 31);
                                }



                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "5月、8月、11月")
                                {
                                    DateTime T1B = new DateTime(Now.Year, 5, 1);
                                    DateTime T1E = new DateTime(Now.Year, 5, 31);

                                    DateTime T2B = new DateTime(Now.Year, 8, 1);
                                    DateTime T2E = new DateTime(Now.Year, 8, 31);

                                    DateTime T3B = new DateTime(Now.Year, 11, 1);
                                    DateTime T3E = new DateTime(Now.Year, 11, 30);


                                    var query_data1 = (from x in query_data
                                                       where x.fldDate >= T1B && x.fldDate <= T1E
                                                       select x).ToList();
                                    query_data.AddRange(query_data1);


                                    var query_data2 = (from x in query_data
                                                       where x.fldDate >= T2B && x.fldDate <= T2E
                                                       select x).ToList();
                                    query_data.AddRange(query_data2);



                                    var query_data3 = (from x in query_data
                                                       where x.fldDate >= T3B && x.fldDate <= T3E
                                                       select x).ToList();
                                    query_data.AddRange(query_data3);
                                }
                                else
                                {
                                    query_data = (from x in query_data
                                                  where x.fldDate >= fldBeginDate && x.fldDate <= fldEndDate
                                                  select x).ToList();
                                }

                                #endregion






                                #region 备注处理以及源数据处理


                                query_data = (from x in query_data
                                              where item_Raw.ItemCode.Contains(x.fldItemCode)
                                              select x).ToList();


                                var query_remark = (from x in db.tblEQI_DataImport_Remark
                                                    where x.fldObject == item_Raw.type
                                                    select x).ToList();

                                foreach (var item in query_remark)
                                {
                                    item.fldDate_2 = DateTime.Parse(item.fldDate.Trim());
                                }

                                query_remark = (from x in query_remark
                                                where x.fldDate_2 >= fldBeginDate && x.fldDate_2 <= fldEndDate
                                                select x).ToList();






                                var query_item = (from x in db.tblEQIW_R_Item
                                                  select x).ToList();


                                #endregion






                                #region 主体处理



                                retrun_data = (from x in query_section
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldSTName,
                                                   x.fldRCode,
                                                   x.fldRName,
                                                   x.fldRSCode,
                                                   x.fldRSName,
                                                   x.fldSCategory
                                               } into g
                                               select new STCodeApprise_Return
                                               {
                                                   fldSTName = g.Key.fldSTName,

                                                   SectionType = Convert.ToString(g.Key.fldSCategory),

                                                   PointName = g.Key.fldRSName,

                                                   ItemCode = Calc_ItemCode_DX_Pre(query_data, item_Raw.ItemCode, query_item),

                                                   Remark = Calc_Remark_DX_Pre(query_data, query_remark, g.Key.fldSTCode, g.Key.fldRCode, g.Key.fldRSCode)

                                               }).ToList();
                                #endregion




                            }
                        }
                    }
                }









                if (HttpUtility.UrlDecode(info.DataType) == "入库后")
                {
                    using (EntityContext db = new EntityContext())
                    {
                        foreach (var item_Raw in info.RawDatas)
                        {
                            string SectionType = HttpUtility.UrlDecode(item_Raw.SectionType);
                            if (item_Raw.type == "eqiw_r")
                            {



                                #region 断面以及数据处理

                                var query_section = (from x in db.tblEQIW_R_Section
                                                     where SectionType.Contains(x.fldAttribute) &&
                                                     x.fldYear == DateTime.Now.Year
                                                     select x).ToList();

                                var query_data = (from x in query_section
                                                  join y in db.tblEQIW_R_Basedata
                                                  on new
                                                  {
                                                      x.fldSTCode,
                                                      x.fldRCode,
                                                      x.fldRSCode
                                                  }
                                                  equals new
                                                  {
                                                      y.fldSTCode,
                                                      y.fldRCode,
                                                      y.fldRSCode
                                                  }
                                                  select y).ToList();

                                foreach (var item in query_data)
                                {
                                    item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay + " " + item.fldHour + ":" + item.fldMinute + ":00");
                                }



                                #endregion






                                #region 日期处理


                                DateTime fldBeginDate = DateTime.Now;
                                DateTime fldEndDate = DateTime.Now;

                                DateTime Now = DateTime.Now;

                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每月")
                                {
                                    fldBeginDate = new DateTime(Now.Year, Now.Month, 1);

                                    fldEndDate = fldBeginDate.AddMonths(1).AddSeconds(-1);
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每季度")
                                {
                                    fldBeginDate = Now.AddMonths(0 - (Now.Month - 1) % 3).AddDays(1 - Now.Day);//本季度初

                                    fldEndDate = fldBeginDate.AddMonths(3).AddDays(-1);  //本季度末
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每半年")
                                {
                                    if (Now.Year < 7)
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 1, 1);

                                        fldEndDate = new DateTime(Now.Year, 6, 30);
                                    }
                                    else
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 7, 1);

                                        fldEndDate = new DateTime(Now.Year, 12, 31);
                                    }
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每年")
                                {
                                    fldBeginDate = new DateTime(Now.Year, 1, 1);

                                    fldEndDate = new DateTime(Now.Year, 12, 31);
                                }



                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "5月、8月、11月")
                                {
                                    DateTime T1B = new DateTime(Now.Year, 5, 1);
                                    DateTime T1E = new DateTime(Now.Year, 5, 31);

                                    DateTime T2B = new DateTime(Now.Year, 8, 1);
                                    DateTime T2E = new DateTime(Now.Year, 8, 31);

                                    DateTime T3B = new DateTime(Now.Year, 11, 1);
                                    DateTime T3E = new DateTime(Now.Year, 11, 30);


                                    var query_data1 = (from x in query_data
                                                       where x.fldDate >= T1B && x.fldDate <= T1E
                                                       select x).ToList();
                                    query_data.AddRange(query_data1);


                                    var query_data2 = (from x in query_data
                                                       where x.fldDate >= T2B && x.fldDate <= T2E
                                                       select x).ToList();
                                    query_data.AddRange(query_data2);



                                    var query_data3 = (from x in query_data
                                                       where x.fldDate >= T3B && x.fldDate <= T3E
                                                       select x).ToList();
                                    query_data.AddRange(query_data3);
                                }
                                else
                                {
                                    query_data = (from x in query_data
                                                  where x.fldDate >= fldBeginDate && x.fldDate <= fldEndDate
                                                  select x).ToList();
                                }

                                #endregion






                                #region 备注处理以及源数据处理


                                query_data = (from x in query_data
                                              where item_Raw.ItemCode.Contains(x.fldItemCode)
                                              select x).ToList();


                                var query_remark = (from x in db.tblEQI_DataImport_Remark
                                                    where x.fldObject == item_Raw.type
                                                    select x).ToList();

                                foreach (var item in query_remark)
                                {
                                    item.fldDate_2 = DateTime.Parse(item.fldDate.Trim());
                                }

                                query_remark = (from x in query_remark
                                                where x.fldDate_2 >= fldBeginDate && x.fldDate_2 <= fldEndDate
                                                select x).ToList();






                                var query_item = (from x in db.tblEQIW_R_Item
                                                  select x).ToList();


                                #endregion






                                #region 主体处理



                                retrun_data = (from x in query_section
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldSTName,
                                                   x.fldRCode,
                                                   x.fldRName,
                                                   x.fldRSCode,
                                                   x.fldRSName,
                                                   x.fldAttribute
                                               } into g
                                               select new STCodeApprise_Return
                                               {
                                                   fldSTName = g.Key.fldSTName,

                                                   SectionType = g.Key.fldAttribute,

                                                   PointName = g.Key.fldRSName,

                                                   ItemCode = Calc_ItemCode_R_BaseData(query_data, item_Raw.ItemCode, query_item),

                                                   Remark = Calc_Remark_R_BaseData(query_data, query_remark, g.Key.fldSTCode, g.Key.fldRCode, g.Key.fldRSCode)

                                               }).ToList();
                                #endregion




                            }


                            if (item_Raw.type == "eqiw_d")
                            {



                                #region 断面以及数据处理

                                List<int?> sectiontype = new List<int?>();

                                List<string> temp = SectionType.Split(',').ToList();


                                foreach (var item in temp)
                                {
                                    sectiontype.Add(int.Parse(item));
                                }


                                var query_section = (from x in db.tblEQIW_D_Section
                                                     where sectiontype.Contains(x.fldSCategory) &&
                                                     x.fldYear == DateTime.Now.Year
                                                     select x).ToList();

                                var query_data = (from x in query_section
                                                  join y in db.tblEQIW_D_Basedata
                                                  on new
                                                  {
                                                      x.fldSTCode,
                                                      x.fldRCode,
                                                      x.fldRSCode
                                                  }
                                                  equals new
                                                  {
                                                      y.fldSTCode,
                                                      y.fldRCode,
                                                      y.fldRSCode
                                                  }
                                                  select y).ToList();

                                foreach (var item in query_data)
                                {
                                    item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay + " " + item.fldHour + ":" + item.fldMinute + ":00");
                                }



                                #endregion






                                #region 日期处理


                                DateTime fldBeginDate = DateTime.Now;
                                DateTime fldEndDate = DateTime.Now;

                                DateTime Now = DateTime.Now;

                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每月")
                                {
                                    fldBeginDate = new DateTime(Now.Year, Now.Month, 1);

                                    fldEndDate = fldBeginDate.AddMonths(1).AddSeconds(-1);
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每季度")
                                {
                                    fldBeginDate = Now.AddMonths(0 - (Now.Month - 1) % 3).AddDays(1 - Now.Day);//本季度初

                                    fldEndDate = fldBeginDate.AddMonths(3).AddDays(-1);  //本季度末
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每半年")
                                {
                                    if (Now.Year < 7)
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 1, 1);

                                        fldEndDate = new DateTime(Now.Year, 6, 30);
                                    }
                                    else
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 7, 1);

                                        fldEndDate = new DateTime(Now.Year, 12, 31);
                                    }
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每年")
                                {
                                    fldBeginDate = new DateTime(Now.Year, 1, 1);

                                    fldEndDate = new DateTime(Now.Year, 12, 31);
                                }



                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "5月、8月、11月")
                                {
                                    DateTime T1B = new DateTime(Now.Year, 5, 1);
                                    DateTime T1E = new DateTime(Now.Year, 5, 31);

                                    DateTime T2B = new DateTime(Now.Year, 8, 1);
                                    DateTime T2E = new DateTime(Now.Year, 8, 31);

                                    DateTime T3B = new DateTime(Now.Year, 11, 1);
                                    DateTime T3E = new DateTime(Now.Year, 11, 30);


                                    var query_data1 = (from x in query_data
                                                       where x.fldDate >= T1B && x.fldDate <= T1E
                                                       select x).ToList();
                                    query_data.AddRange(query_data1);


                                    var query_data2 = (from x in query_data
                                                       where x.fldDate >= T2B && x.fldDate <= T2E
                                                       select x).ToList();
                                    query_data.AddRange(query_data2);



                                    var query_data3 = (from x in query_data
                                                       where x.fldDate >= T3B && x.fldDate <= T3E
                                                       select x).ToList();
                                    query_data.AddRange(query_data3);
                                }
                                else
                                {
                                    query_data = (from x in query_data
                                                  where x.fldDate >= fldBeginDate && x.fldDate <= fldEndDate
                                                  select x).ToList();
                                }

                                #endregion






                                #region 备注处理以及源数据处理


                                query_data = (from x in query_data
                                              where item_Raw.ItemCode.Contains(x.fldItemCode)
                                              select x).ToList();


                                var query_remark = (from x in db.tblEQI_DataImport_Remark
                                                    where x.fldObject == item_Raw.type
                                                    select x).ToList();

                                foreach (var item in query_remark)
                                {
                                    item.fldDate_2 = DateTime.Parse(item.fldDate.Trim());
                                }

                                query_remark = (from x in query_remark
                                                where x.fldDate_2 >= fldBeginDate && x.fldDate_2 <= fldEndDate
                                                select x).ToList();






                                var query_item = (from x in db.tblEQIW_R_Item
                                                  select x).ToList();


                                #endregion






                                #region 主体处理



                                retrun_data = (from x in query_section
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldSTName,
                                                   x.fldRCode,
                                                   x.fldRName,
                                                   x.fldRSCode,
                                                   x.fldRSName,
                                                   x.fldSCategory
                                               } into g
                                               select new STCodeApprise_Return
                                               {
                                                   fldSTName = g.Key.fldSTName,

                                                   SectionType = Convert.ToString(g.Key.fldSCategory),

                                                   PointName = g.Key.fldRSName,

                                                   ItemCode = Calc_ItemCode_D_BaseData(query_data, item_Raw.ItemCode, query_item),

                                                   Remark = Calc_Remark_D_BaseData(query_data, query_remark, g.Key.fldSTCode, g.Key.fldRCode, g.Key.fldRSCode)

                                               }).ToList();

                                #endregion




                            }


                            if (item_Raw.type == "eqiw_dt")
                            {



                                #region 断面以及数据处理

                                List<int?> sectiontype = new List<int?>();

                                List<string> temp = SectionType.Split(',').ToList();


                                foreach (var item in temp)
                                {
                                    sectiontype.Add(int.Parse(item));
                                }


                                var query_section = (from x in db.tblEQIW_DT_Section
                                                     where sectiontype.Contains(x.fldSCategory) &&
                                                     x.fldYear == DateTime.Now.Year
                                                     select x).ToList();

                                var query_data = (from x in query_section
                                                  join y in db.tblEQIW_DT_Basedata
                                                  on new
                                                  {
                                                      x.fldSTCode,
                                                      x.fldRCode,
                                                      x.fldRSCode
                                                  }
                                                  equals new
                                                  {
                                                      y.fldSTCode,
                                                      y.fldRCode,
                                                      y.fldRSCode
                                                  }
                                                  select y).ToList();

                                foreach (var item in query_data)
                                {
                                    item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay + " " + item.fldHour + ":" + item.fldMinute + ":00");
                                }



                                #endregion






                                #region 日期处理


                                DateTime fldBeginDate = DateTime.Now;
                                DateTime fldEndDate = DateTime.Now;

                                DateTime Now = DateTime.Now;

                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每月")
                                {
                                    fldBeginDate = new DateTime(Now.Year, Now.Month, 1);

                                    fldEndDate = fldBeginDate.AddMonths(1).AddSeconds(-1);
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每季度")
                                {
                                    fldBeginDate = Now.AddMonths(0 - (Now.Month - 1) % 3).AddDays(1 - Now.Day);//本季度初

                                    fldEndDate = fldBeginDate.AddMonths(3).AddDays(-1);  //本季度末
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每半年")
                                {
                                    if (Now.Year < 7)
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 1, 1);

                                        fldEndDate = new DateTime(Now.Year, 6, 30);
                                    }
                                    else
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 7, 1);

                                        fldEndDate = new DateTime(Now.Year, 12, 31);
                                    }
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每年")
                                {
                                    fldBeginDate = new DateTime(Now.Year, 1, 1);

                                    fldEndDate = new DateTime(Now.Year, 12, 31);
                                }



                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "5月、8月、11月")
                                {
                                    DateTime T1B = new DateTime(Now.Year, 5, 1);
                                    DateTime T1E = new DateTime(Now.Year, 5, 31);

                                    DateTime T2B = new DateTime(Now.Year, 8, 1);
                                    DateTime T2E = new DateTime(Now.Year, 8, 31);

                                    DateTime T3B = new DateTime(Now.Year, 11, 1);
                                    DateTime T3E = new DateTime(Now.Year, 11, 30);


                                    var query_data1 = (from x in query_data
                                                       where x.fldDate >= T1B && x.fldDate <= T1E
                                                       select x).ToList();
                                    query_data.AddRange(query_data1);


                                    var query_data2 = (from x in query_data
                                                       where x.fldDate >= T2B && x.fldDate <= T2E
                                                       select x).ToList();
                                    query_data.AddRange(query_data2);



                                    var query_data3 = (from x in query_data
                                                       where x.fldDate >= T3B && x.fldDate <= T3E
                                                       select x).ToList();
                                    query_data.AddRange(query_data3);
                                }
                                else
                                {
                                    query_data = (from x in query_data
                                                  where x.fldDate >= fldBeginDate && x.fldDate <= fldEndDate
                                                  select x).ToList();
                                }

                                #endregion






                                #region 备注处理以及源数据处理


                                query_data = (from x in query_data
                                              where item_Raw.ItemCode.Contains(x.fldItemCode)
                                              select x).ToList();


                                var query_remark = (from x in db.tblEQI_DataImport_Remark
                                                    where x.fldObject == item_Raw.type
                                                    select x).ToList();

                                foreach (var item in query_remark)
                                {
                                    item.fldDate_2 = DateTime.Parse(item.fldDate.Trim());
                                }

                                query_remark = (from x in query_remark
                                                where x.fldDate_2 >= fldBeginDate && x.fldDate_2 <= fldEndDate
                                                select x).ToList();






                                var query_item = (from x in db.tblEQIW_R_Item
                                                  select x).ToList();


                                #endregion






                                #region 主体处理



                                retrun_data = (from x in query_section
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldSTName,
                                                   x.fldRCode,
                                                   x.fldRName,
                                                   x.fldRSCode,
                                                   x.fldRSName,
                                                   x.fldSCategory
                                               } into g
                                               select new STCodeApprise_Return
                                               {
                                                   fldSTName = g.Key.fldSTName,

                                                   SectionType = Convert.ToString(g.Key.fldSCategory),

                                                   PointName = g.Key.fldRSName,

                                                   ItemCode = Calc_ItemCode_DT_BaseData(query_data, item_Raw.ItemCode, query_item),

                                                   Remark = Calc_Remark_DT_BaseData(query_data, query_remark, g.Key.fldSTCode, g.Key.fldRCode, g.Key.fldRSCode)

                                               }).ToList();
                                #endregion




                            }


                            if (item_Raw.type == "eqiw_dx")
                            {



                                #region 断面以及数据处理

                                List<int?> sectiontype = new List<int?>();

                                List<string> temp = SectionType.Split(',').ToList();


                                foreach (var item in temp)
                                {
                                    sectiontype.Add(int.Parse(item));
                                }


                                var query_section = (from x in db.tbleqiw_dx_Section
                                                     where sectiontype.Contains(x.fldSCategory) &&
                                                     x.fldYear == DateTime.Now.Year
                                                     select x).ToList();

                                var query_data = (from x in query_section
                                                  join y in db.tbleqiw_dx_Basedata
                                                  on new
                                                  {
                                                      x.fldSTCode,
                                                      x.fldRCode,
                                                      x.fldRSCode
                                                  }
                                                  equals new
                                                  {
                                                      y.fldSTCode,
                                                      y.fldRCode,
                                                      y.fldRSCode
                                                  }
                                                  select y).ToList();

                                foreach (var item in query_data)
                                {
                                    item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay + " " + item.fldHour + ":" + item.fldMinute + ":00");
                                }



                                #endregion






                                #region 日期处理


                                DateTime fldBeginDate = DateTime.Now;
                                DateTime fldEndDate = DateTime.Now;

                                DateTime Now = DateTime.Now;

                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每月")
                                {
                                    fldBeginDate = new DateTime(Now.Year, Now.Month, 1);

                                    fldEndDate = fldBeginDate.AddMonths(1).AddSeconds(-1);
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每季度")
                                {
                                    fldBeginDate = Now.AddMonths(0 - (Now.Month - 1) % 3).AddDays(1 - Now.Day);//本季度初

                                    fldEndDate = fldBeginDate.AddMonths(3).AddDays(-1);  //本季度末
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每半年")
                                {
                                    if (Now.Year < 7)
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 1, 1);

                                        fldEndDate = new DateTime(Now.Year, 6, 30);
                                    }
                                    else
                                    {
                                        fldBeginDate = new DateTime(Now.Year, 7, 1);

                                        fldEndDate = new DateTime(Now.Year, 12, 31);
                                    }
                                }
                                else if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "每年")
                                {
                                    fldBeginDate = new DateTime(Now.Year, 1, 1);

                                    fldEndDate = new DateTime(Now.Year, 12, 31);
                                }



                                if (HttpUtility.UrlDecode(item_Raw.Cyctyp) == "5月、8月、11月")
                                {
                                    DateTime T1B = new DateTime(Now.Year, 5, 1);
                                    DateTime T1E = new DateTime(Now.Year, 5, 31);

                                    DateTime T2B = new DateTime(Now.Year, 8, 1);
                                    DateTime T2E = new DateTime(Now.Year, 8, 31);

                                    DateTime T3B = new DateTime(Now.Year, 11, 1);
                                    DateTime T3E = new DateTime(Now.Year, 11, 30);


                                    var query_data1 = (from x in query_data
                                                       where x.fldDate >= T1B && x.fldDate <= T1E
                                                       select x).ToList();
                                    query_data.AddRange(query_data1);


                                    var query_data2 = (from x in query_data
                                                       where x.fldDate >= T2B && x.fldDate <= T2E
                                                       select x).ToList();
                                    query_data.AddRange(query_data2);



                                    var query_data3 = (from x in query_data
                                                       where x.fldDate >= T3B && x.fldDate <= T3E
                                                       select x).ToList();
                                    query_data.AddRange(query_data3);
                                }
                                else
                                {
                                    query_data = (from x in query_data
                                                  where x.fldDate >= fldBeginDate && x.fldDate <= fldEndDate
                                                  select x).ToList();
                                }

                                #endregion






                                #region 备注处理以及源数据处理


                                query_data = (from x in query_data
                                              where item_Raw.ItemCode.Contains(x.fldItemCode)
                                              select x).ToList();


                                var query_remark = (from x in db.tblEQI_DataImport_Remark
                                                    where x.fldObject == item_Raw.type
                                                    select x).ToList();

                                foreach (var item in query_remark)
                                {
                                    item.fldDate_2 = DateTime.Parse(item.fldDate.Trim());
                                }

                                query_remark = (from x in query_remark
                                                where x.fldDate_2 >= fldBeginDate && x.fldDate_2 <= fldEndDate
                                                select x).ToList();






                                var query_item = (from x in db.tblEQIW_R_Item
                                                  select x).ToList();


                                #endregion






                                #region 主体处理



                                retrun_data = (from x in query_section
                                               group x by new
                                               {
                                                   x.fldSTCode,
                                                   x.fldSTName,
                                                   x.fldRCode,
                                                   x.fldRName,
                                                   x.fldRSCode,
                                                   x.fldRSName,
                                                   x.fldSCategory
                                               } into g
                                               select new STCodeApprise_Return
                                               {
                                                   fldSTName = g.Key.fldSTName,

                                                   SectionType = Convert.ToString(g.Key.fldSCategory),

                                                   PointName = g.Key.fldRSName,

                                                   ItemCode = Calc_ItemCode_DX_BaseData(query_data, item_Raw.ItemCode, query_item),

                                                   Remark = Calc_Remark_DX_BaseData(query_data, query_remark, g.Key.fldSTCode, g.Key.fldRCode, g.Key.fldRSCode)

                                               }).ToList();
                                #endregion




                            }
                        }
                    }
                }


















                result = rule.JsonStr("ok", "", retrun_data);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }







        /// <summary>
        /// 计算缺报因子
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public static string Calc_ItemCode_R_Pre(List<Mode.tblEQIW_R_Basedata_Pre> list, string ItemList, List<Mode.tblEQIW_R_Item> ItemTable)
        {
            string result = "";
            List<string> itemList = ItemList.Split(',').ToList();

            foreach (var item in itemList)
            {
                var count = (from x in list
                             where x.fldItemCode == item
                             select x).Count();
                if (count == 0)
                {
                    var query = (from x in ItemTable
                                 where x.fldItemCode == item
                                 select x).FirstOrDefault();

                    if (query != null)
                    {
                        result += query.fldItemName + "(" + item + ")、";
                    }
                }
            }

            result = result.TrimEnd('、');


            return result;
        }




        /// <summary>
        /// 统计备注（包括水平向、垂直向）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Calc_Remark_R_Pre(List<Mode.tblEQIW_R_Basedata_Pre> list, List<Mode.tblEQI_DataImport_Remark> RemarkList, string fldSTCode, string fldRCode, string fldRSCode)
        {
            string result = "";

            var query = (from x in list
                         where x.fldSTCode == fldSTCode &&
                         x.fldRCode == fldRCode &&
                         x.fldRSCode == fldRSCode
                         select x).ToList();

            foreach (var item in query)
            {
                var query2 = (from x in RemarkList
                              where x.fldRSInfo == item.fldSTCode + "." + item.fldRCode + "." + item.fldRSCode + item.fldSAMPH + "." + item.fldSAMPR
                              select x).FirstOrDefault();

                if (query2 != null)
                {
                    result += "【" + query2.fldRemark + "】、";
                }
            }

            result.TrimEnd('、');


            return result;
        }








        /// <summary>
        /// 计算缺报因子
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public static string Calc_ItemCode_R_BaseData(List<Mode.tblEQIW_R_Basedata> list, string ItemList, List<Mode.tblEQIW_R_Item> ItemTable)
        {
            string result = "";
            List<string> itemList = ItemList.Split(',').ToList();

            foreach (var item in itemList)
            {
                var count = (from x in list
                             where x.fldItemCode == item
                             select x).Count();
                if (count == 0)
                {
                    var query = (from x in ItemTable
                                 where x.fldItemCode == item
                                 select x).FirstOrDefault();

                    if (query != null)
                    {
                        result += query.fldItemName + "(" + item + ")、";
                    }
                }
            }

            result = result.TrimEnd('、');


            return result;
        }




        /// <summary>
        /// 统计备注（包括水平向、垂直向）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Calc_Remark_R_BaseData(List<Mode.tblEQIW_R_Basedata> list, List<Mode.tblEQI_DataImport_Remark> RemarkList, string fldSTCode, string fldRCode, string fldRSCode)
        {
            string result = "";

            var query = (from x in list
                         where x.fldSTCode == fldSTCode &&
                         x.fldRCode == fldRCode &&
                         x.fldRSCode == fldRSCode
                         select x).ToList();

            foreach (var item in query)
            {
                var query2 = (from x in RemarkList
                              where x.fldRSInfo == item.fldSTCode + "." + item.fldRCode + "." + item.fldRSCode + item.fldSAMPH + "." + item.fldSAMPR
                              select x).FirstOrDefault();

                if (query2 != null)
                {
                    result += "【" + query2.fldRemark + "】、";
                }
            }

            result.TrimEnd('、');


            return result;
        }























        /// <summary>
        /// 计算缺报因子
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public static string Calc_ItemCode_D_Pre(List<Mode.tblEQIW_D_Basedata_Pre> list, string ItemList, List<Mode.tblEQIW_R_Item> ItemTable)
        {
            string result = "";
            List<string> itemList = ItemList.Split(',').ToList();

            foreach (var item in itemList)
            {
                var count = (from x in list
                             where x.fldItemCode == item
                             select x).Count();
                if (count == 0)
                {
                    var query = (from x in ItemTable
                                 where x.fldItemCode == item
                                 select x).FirstOrDefault();

                    if (query != null)
                    {
                        result += query.fldItemName + "(" + item + ")、";
                    }
                }
            }

            result = result.TrimEnd('、');


            return result;
        }




        /// <summary>
        /// 统计备注（包括水平向、垂直向）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Calc_Remark_D_Pre(List<Mode.tblEQIW_D_Basedata_Pre> list, List<Mode.tblEQI_DataImport_Remark> RemarkList, string fldSTCode, string fldRCode, string fldRSCode)
        {
            string result = "";

            var query = (from x in list
                         where x.fldSTCode == fldSTCode &&
                         x.fldRCode == fldRCode &&
                         x.fldRSCode == fldRSCode
                         select x).ToList();

            foreach (var item in query)
            {
                var query2 = (from x in RemarkList
                              where x.fldRSInfo == item.fldSTCode + "." + item.fldRCode + "." + item.fldRSCode + item.fldSAMPH + "." + item.fldSAMPR
                              select x).FirstOrDefault();

                if (query2 != null)
                {
                    result += "【" + query2.fldRemark + "】、";
                }
            }

            result.TrimEnd('、');


            return result;
        }






        /// <summary>
        /// 计算缺报因子
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public static string Calc_ItemCode_D_BaseData(List<Mode.tblEQIW_D_Basedata> list, string ItemList, List<Mode.tblEQIW_R_Item> ItemTable)
        {
            string result = "";
            List<string> itemList = ItemList.Split(',').ToList();

            foreach (var item in itemList)
            {
                var count = (from x in list
                             where x.fldItemCode == item
                             select x).Count();
                if (count == 0)
                {
                    var query = (from x in ItemTable
                                 where x.fldItemCode == item
                                 select x).FirstOrDefault();

                    if (query != null)
                    {
                        result += query.fldItemName + "(" + item + ")、";
                    }
                }
            }

            result = result.TrimEnd('、');


            return result;
        }




        /// <summary>
        /// 统计备注（包括水平向、垂直向）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Calc_Remark_D_BaseData(List<Mode.tblEQIW_D_Basedata> list, List<Mode.tblEQI_DataImport_Remark> RemarkList, string fldSTCode, string fldRCode, string fldRSCode)
        {
            string result = "";

            var query = (from x in list
                         where x.fldSTCode == fldSTCode &&
                         x.fldRCode == fldRCode &&
                         x.fldRSCode == fldRSCode
                         select x).ToList();

            foreach (var item in query)
            {
                var query2 = (from x in RemarkList
                              where x.fldRSInfo == item.fldSTCode + "." + item.fldRCode + "." + item.fldRSCode + item.fldSAMPH + "." + item.fldSAMPR
                              select x).FirstOrDefault();

                if (query2 != null)
                {
                    result += "【" + query2.fldRemark + "】、";
                }
            }

            result.TrimEnd('、');


            return result;
        }












































        /// <summary>
        /// 计算缺报因子
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public static string Calc_ItemCode_DT_Pre(List<Mode.tblEQIW_DT_Basedata_Pre> list, string ItemList, List<Mode.tblEQIW_R_Item> ItemTable)
        {
            string result = "";
            List<string> itemList = ItemList.Split(',').ToList();

            foreach (var item in itemList)
            {
                var count = (from x in list
                             where x.fldItemCode == item
                             select x).Count();
                if (count == 0)
                {
                    var query = (from x in ItemTable
                                 where x.fldItemCode == item
                                 select x).FirstOrDefault();

                    if (query != null)
                    {
                        result += query.fldItemName + "(" + item + ")、";
                    }
                }
            }

            result = result.TrimEnd('、');


            return result;
        }




        /// <summary>
        /// 统计备注（包括水平向、垂直向）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Calc_Remark_DT_Pre(List<Mode.tblEQIW_DT_Basedata_Pre> list, List<Mode.tblEQI_DataImport_Remark> RemarkList, string fldSTCode, string fldRCode, string fldRSCode)
        {
            string result = "";

            var query = (from x in list
                         where x.fldSTCode == fldSTCode &&
                         x.fldRCode == fldRCode &&
                         x.fldRSCode == fldRSCode
                         select x).ToList();

            foreach (var item in query)
            {
                var query2 = (from x in RemarkList
                              where x.fldRSInfo == item.fldSTCode + "." + item.fldRCode + "." + item.fldRSCode + item.fldSAMPH + "." + item.fldSAMPR
                              select x).FirstOrDefault();

                if (query2 != null)
                {
                    result += "【" + query2.fldRemark + "】、";
                }
            }

            result.TrimEnd('、');


            return result;
        }














        /// <summary>
        /// 计算缺报因子
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public static string Calc_ItemCode_DT_BaseData(List<Mode.tblEQIW_DT_Basedata> list, string ItemList, List<Mode.tblEQIW_R_Item> ItemTable)
        {
            string result = "";
            List<string> itemList = ItemList.Split(',').ToList();

            foreach (var item in itemList)
            {
                var count = (from x in list
                             where x.fldItemCode == item
                             select x).Count();
                if (count == 0)
                {
                    var query = (from x in ItemTable
                                 where x.fldItemCode == item
                                 select x).FirstOrDefault();

                    if (query != null)
                    {
                        result += query.fldItemName + "(" + item + ")、";
                    }
                }
            }

            result = result.TrimEnd('、');


            return result;
        }




        /// <summary>
        /// 统计备注（包括水平向、垂直向）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Calc_Remark_DT_BaseData(List<Mode.tblEQIW_DT_Basedata> list, List<Mode.tblEQI_DataImport_Remark> RemarkList, string fldSTCode, string fldRCode, string fldRSCode)
        {
            string result = "";

            var query = (from x in list
                         where x.fldSTCode == fldSTCode &&
                         x.fldRCode == fldRCode &&
                         x.fldRSCode == fldRSCode
                         select x).ToList();

            foreach (var item in query)
            {
                var query2 = (from x in RemarkList
                              where x.fldRSInfo == item.fldSTCode + "." + item.fldRCode + "." + item.fldRSCode + item.fldSAMPH + "." + item.fldSAMPR
                              select x).FirstOrDefault();

                if (query2 != null)
                {
                    result += "【" + query2.fldRemark + "】、";
                }
            }

            result.TrimEnd('、');


            return result;
        }



































        /// <summary>
        /// 计算缺报因子
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public static string Calc_ItemCode_DX_Pre(List<Mode.tbleqiw_dx_Basedata_Pre> list, string ItemList, List<Mode.tblEQIW_R_Item> ItemTable)
        {
            string result = "";
            List<string> itemList = ItemList.Split(',').ToList();

            foreach (var item in itemList)
            {
                var count = (from x in list
                             where x.fldItemCode == item
                             select x).Count();
                if (count == 0)
                {
                    var query = (from x in ItemTable
                                 where x.fldItemCode == item
                                 select x).FirstOrDefault();

                    if (query != null)
                    {
                        result += query.fldItemName + "(" + item + ")、";
                    }
                }
            }

            result = result.TrimEnd('、');


            return result;
        }




        /// <summary>
        /// 统计备注（包括水平向、垂直向）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Calc_Remark_DX_Pre(List<Mode.tbleqiw_dx_Basedata_Pre> list, List<Mode.tblEQI_DataImport_Remark> RemarkList, string fldSTCode, string fldRCode, string fldRSCode)
        {
            string result = "";

            var query = (from x in list
                         where x.fldSTCode == fldSTCode &&
                         x.fldRCode == fldRCode &&
                         x.fldRSCode == fldRSCode
                         select x).ToList();

            foreach (var item in query)
            {
                var query2 = (from x in RemarkList
                              where x.fldRSInfo == item.fldSTCode + "." + item.fldRCode + "." + item.fldRSCode + item.fldSAMPH + "." + item.fldSAMPR
                              select x).FirstOrDefault();

                if (query2 != null)
                {
                    result += "【" + query2.fldRemark + "】、";
                }
            }

            result.TrimEnd('、');


            return result;
        }












        /// <summary>
        /// 计算缺报因子
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public static string Calc_ItemCode_DX_BaseData(List<Mode.tbleqiw_dx_Basedata> list, string ItemList, List<Mode.tblEQIW_R_Item> ItemTable)
        {
            string result = "";
            List<string> itemList = ItemList.Split(',').ToList();

            foreach (var item in itemList)
            {
                var count = (from x in list
                             where x.fldItemCode == item
                             select x).Count();
                if (count == 0)
                {
                    var query = (from x in ItemTable
                                 where x.fldItemCode == item
                                 select x).FirstOrDefault();

                    if (query != null)
                    {
                        result += query.fldItemName + "(" + item + ")、";
                    }
                }
            }

            result = result.TrimEnd('、');


            return result;
        }




        /// <summary>
        /// 统计备注（包括水平向、垂直向）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Calc_Remark_DX_BaseData(List<Mode.tbleqiw_dx_Basedata> list, List<Mode.tblEQI_DataImport_Remark> RemarkList, string fldSTCode, string fldRCode, string fldRSCode)
        {
            string result = "";

            var query = (from x in list
                         where x.fldSTCode == fldSTCode &&
                         x.fldRCode == fldRCode &&
                         x.fldRSCode == fldRSCode
                         select x).ToList();

            foreach (var item in query)
            {
                var query2 = (from x in RemarkList
                              where x.fldRSInfo == item.fldSTCode + "." + item.fldRCode + "." + item.fldRSCode + item.fldSAMPH + "." + item.fldSAMPR
                              select x).FirstOrDefault();

                if (query2 != null)
                {
                    result += "【" + query2.fldRemark + "】、";
                }
            }

            result.TrimEnd('、');


            return result;
        }





























        /// <summary>
        /// 参数实体
        /// </summary>
        public class STCodeApprise_Info
        {
            /// <summary>
            /// 源数据类型：“入库前”、“入库后”
            /// </summary>
            public string DataType { get; set; }

            public List<RawData> RawDatas { get; set; }
        }



        public class RawData
        {
            /// <summary>
            /// 业务类型
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// 断面类型
            /// </summary>
            public string SectionType { get; set; }

            /// <summary>
            /// 因子代码
            /// </summary>
            public string ItemCode { get; set; }


            /// <summary>
            /// 周期类型
            /// </summary>
            public string Cyctyp { get; set; }

        }





        /// <summary>
        /// 返回实体
        /// </summary>
        public class STCodeApprise_Return
        {

            /// <summary>
            /// 城市名称
            /// </summary>
            public string fldSTName { get; set; }

            /// <summary>
            /// 断面类型
            /// </summary>
            public string SectionType { get; set; }

            /// <summary>
            /// 缺报点位名称
            /// </summary>
            public string PointName { get; set; }

            /// <summary>
            /// 缺报项目因子
            /// </summary>
            public string ItemCode { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            public string Remark { get; set; }
        }





































    }
}

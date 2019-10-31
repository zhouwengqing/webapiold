
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml;

namespace EMCCommon.Eqin.Eqin_t
{
    /// <summary>
    /// 功能描述：噪声审核功能
    /// 创建者：熊瑞竹
    /// 创建日期：2017-06-20
    /// 修改者：
    /// 修改日期：
    /// </summary>
    public class NoiseAuditingController : ApiController
    {
        RuleCommon rule = new RuleCommon();





        /// <summary>
        /// 功能描述：获得审核的数据
        /// 创建者：熊瑞竹
        /// 创建日期：2017-06-06
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <returns>json字符串</returns>
        [HttpGet]
        // [SupportFilter]
        public HttpResponseMessage Geteqicom_data(string type, string wherequery, string pageshow, string cityid)
        {
            string returnjson = "[{data: ";
            try
            {
                string sbtype = type;
                #region 拼接原始条件
                string defaultwhere = "";//原始条件
                if (wherequery == "undefined" || wherequery == "")
                {
                    wherequery = " and fldSource=0";
                }
                if (pageshow == "1")
                {
                    defaultwhere = "fldCityID_Operate=" + cityid + " and fldFlag=0 and fldImport=1 ";
                }
                if (pageshow == "0")
                {
                    defaultwhere = " fldFlag=1 ";
                }

                #endregion

                #region 基本数据获取
                RuletblDictionary dic = new RuletblDictionary();
                RuleEQICommon_Auditing rulAud = new RuleEQICommon_Auditing();
                string list = dic.ByParentIDAndValue("数据审核视图", sbtype);
                RuletblEQI_publi exec = new RuletblEQI_publi();
                string ViewName = list.Split(',')[0].ToString();
                string ChinesizeViewName = list.Split(',')[1].ToString();
                wherequery = defaultwhere + HttpUtility.UrlDecode(wherequery);
                DataTable dt = rulAud.GetAuditingDatabyBusinessType(sbtype, ViewName, wherequery, 0);//需要的数据数据

                #endregion
                #region 数据源转化为Json格式
                string json = JsonHelper.SerializeObject(dt);
                returnjson += json;
                #endregion

                #region 拼数据对应列名
                returnjson += ",head: [";//标题
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string engname = "'" + dt.Columns[i].ColumnName + "'";
                    DataTable dtDesc = rule.ChinesizeTitleNamebyViewName(ChinesizeViewName, engname);//根据视图名称在字典表中查出对应字段的中文名称

                    if (dtDesc.Rows.Count > 0)
                    {
                        if (i == dt.Columns.Count - 1)
                        {
                            returnjson += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "']}]";
                        }
                        else
                        {
                            returnjson += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "',";

                        }
                    }
                }
                #endregion

                #region 对应列填数据

                #endregion

                #region 最后返回数据给前台
                if (dt.Rows.Count > 0)
                {
                    returnjson = rule.JsonStr("ok", "", returnjson.ToString());
                }
                else
                {
                    returnjson = rule.JsonStr("nodata", "没有数据", returnjson.ToString());
                }
            }
            catch (Exception e)
            {
                returnjson = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(returnjson, System.Text.Encoding.UTF8, "application/json") };
            #endregion
        }







        /// <summary>
        /// 功能描述：获得审核的数据
        /// 创建者：熊瑞竹
        /// 创建日期：2017-06-06
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <returns>json字符串</returns>
        [HttpPost]
        public HttpResponseMessage Geteqicom_data(Geteqicom_data_Info info)
        {
            string returnjson = "[{data: ";
            try
            {
                string sbtype = info.type;
                #region 拼接原始条件
                string defaultwhere = "";//原始条件
                if (info.wherequery == "undefined" || info.wherequery == "")
                {
                    info.wherequery = " and fldSource=0";
                }
                if (info.pageshow == "1")
                {
                    defaultwhere = "fldCityID_Operate=" + info.cityid + " and fldFlag=0 and fldImport=1 ";
                }
                if (info.pageshow == "0")
                {
                    defaultwhere = " fldFlag=1 ";
                }

                #endregion

                #region 基本数据获取
                RuletblDictionary dic = new RuletblDictionary();
                RuleEQICommon_Auditing rulAud = new RuleEQICommon_Auditing();
                string list = dic.ByParentIDAndValue("数据审核视图", sbtype);
                RuletblEQI_publi exec = new RuletblEQI_publi();
                string ViewName = list.Split(',')[0].ToString();
                string ChinesizeViewName = list.Split(',')[1].ToString();
                info.wherequery = defaultwhere + HttpUtility.UrlDecode(info.wherequery);
                DataTable dt = rulAud.GetAuditingDatabyBusinessType(sbtype, ViewName, info.wherequery, 0);//需要的数据数据

                #endregion
                #region 数据源转化为Json格式
                string json = JsonHelper.SerializeObject(dt);
                returnjson += json;
                #endregion

                #region 拼数据对应列名
                returnjson += ",head: [";//标题
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string engname = "'" + dt.Columns[i].ColumnName + "'";
                    DataTable dtDesc = rule.ChinesizeTitleNamebyViewName(ChinesizeViewName, engname);//根据视图名称在字典表中查出对应字段的中文名称

                    if (dtDesc.Rows.Count > 0)
                    {
                        if (i == dt.Columns.Count - 1)
                        {
                            returnjson += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "']}]";
                        }
                        else
                        {
                            returnjson += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "',";

                        }
                    }
                }
                #endregion

                #region 对应列填数据

                #endregion

                #region 最后返回数据给前台
                if (dt.Rows.Count > 0)
                {
                    returnjson = rule.JsonStr("ok", "", returnjson.ToString());
                }
                else
                {
                    returnjson = rule.JsonStr("nodata", "没有数据", returnjson.ToString());
                }
            }
            catch (Exception e)
            {
                returnjson = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(returnjson, System.Text.Encoding.UTF8, "application/json") };
            #endregion
        }


        public class Geteqicom_data_Info
        {
            public string type { get; set; }

            public string wherequery { get; set; }

            public string pageshow { get; set; }

            public string cityid { get; set; }
        }










        /// <summary>
        /// 功能描述：加载只有基本信息的表格
        /// 创建者：周文卿
        /// 修改日期：
        /// 修改者：熊瑞竹
        /// 修改日期：2017-06-07
        /// </summary>
        /// <param name="obj">动态参数</param>
        /// <returns>json字符串</returns>
        [HttpGet]
        //[SupportFilter]
        public HttpResponseMessage Geteqicom_basic(string type, string wherequery, string pageshow, string cityid)
        {
            string returnjson = "[{data: ";
            try
            {
                #region  拼查询条件
                string sbtype = type;
                string defaultwhere = "";//原始条件

                if (wherequery == "undefined" || wherequery == "")
                {
                    wherequery = " and fldSource=0";
                }
                if (pageshow == "2")
                {
                    defaultwhere = " and fldFlag=-1 and fldImport=1 ";
                }
                if (pageshow == "3")
                {
                    defaultwhere = " and fldFlag=0 and fldImport=0 ";
                }
                if (pageshow == "4")
                {
                    defaultwhere = " and fldFlag=-1 and fldImport=0 ";
                }
                if (pageshow == "5")
                {
                    defaultwhere = " and fldFlag=1 and fldImport=0 ";
                }
                if (pageshow == "6")
                {
                    defaultwhere = " and fldFlag=1 ";
                }
                #endregion
                #region 查询数据
                RuletblDictionary dic = new RuletblDictionary();
                RuleEQICommon_Auditing rulAud = new RuleEQICommon_Auditing();
                string list = dic.ByParentIDAndValue("数据审核视图", sbtype);
                RuletblEQI_publi exec = new RuletblEQI_publi();
                string ViewName = list.Split(',')[0].ToString();
                string ChinesizeViewName = list.Split(',')[1].ToString();
                wherequery = "fldCityID_Operate=" + cityid + defaultwhere + HttpUtility.UrlDecode(wherequery);
                DataTable dt = rulAud.GetAuditingDatabyBusinessType(sbtype, ViewName, wherequery, 1);//需要的基本信息数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["fldAutoID"] = dt.Rows[i]["fldAutoID"].ToString().Replace(',', '_');
                }
                #endregion
                #region 数据源转化为Json格式
                string json = JsonHelper.SerializeObject(dt);
                returnjson += json;
                #endregion

                #region 拼数据对应列名
                returnjson += ",head: [";//标题
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string engname = "'" + dt.Columns[i].ColumnName + "'";
                    DataTable dtDesc = rule.ChinesizeTitleNamebyViewName(ChinesizeViewName, engname);//根据视图名称在字典表中查出对应字段的中文名称

                    if (dtDesc.Rows.Count > 0)
                    {
                        if (i == dt.Columns.Count - 1)
                        {
                            returnjson += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "']}]";
                        }
                        else
                        {
                            returnjson += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "',";

                        }
                    }
                }
                #endregion

                #region 返回数据给前台
                if (dt.Rows.Count > 0)
                {
                    returnjson = rule.JsonStr("ok", "", returnjson.ToString());
                }
                else
                {
                    returnjson = rule.JsonStr("nodata", "没有数据", returnjson.ToString());
                }
            }
            catch (Exception e)
            {
                returnjson = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(returnjson, System.Text.Encoding.UTF8, "application/json") };
            #endregion
        }




        /// <summary>
        /// 功能描述：子表格加载
        /// 创建者：熊瑞竹
        /// 创建日期：2017-06-09
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <param name="fldAutoId">默认ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Subtable(string type, string fldAutoId)
        {
            string fldAutoID = fldAutoId.ToString();
            string listtype = type.ToString();
            fldAutoID = fldAutoID.Replace('_', ',');
            RuletblDictionary dic = new RuletblDictionary();
            string list = dic.ByParentIDAndValue("数据审核视图", listtype);
            string table = list.Split(',')[1];
            string execsql = "select fldItemName,fldItemCode,fldItemValue,fldComment from " + table + " where fldAutoID in (" + fldAutoID + ")";
            RuletblEQI_publi pub = new RuletblEQI_publi();
            DataTable dtItemInfo = pub.getdt(execsql);
            string json = JsonHelper.SerializeObject(dtItemInfo);

            #region 返回数据给前台
            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/xm") };

            #endregion
        }

    }
}

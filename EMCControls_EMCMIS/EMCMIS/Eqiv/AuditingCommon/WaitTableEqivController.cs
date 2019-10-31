using DDYZ.Ensis.Presistence.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using DDYZ.Ensis.Rule.DataRule;
using DDYZ.Ensis.Library.Lib.str;

using System.Xml;
using System.Web;
using System.Text;

namespace EMCControls_EMCMIS.Eqiv.AuditingCommon
{
    /// <summary>
    /// 审核数据表
    /// </summary>
    public class WaitTableEqivController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：获得生态、生物审核的数据
        /// 创建者：熊瑞竹
        /// 创建日期：2017-08-22
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <param name="wherequery">查询条件</param>
        /// <param name="pageshow">数据类型</param>
        /// <param name="cityid">城市Id</param>
        /// <returns>返回基本信息数据的Json字符串</returns>
        [HttpGet]
        //
        public HttpResponseMessage Geteqicom_data(string type, string wherequery, string pageshow, string cityid)
        {
            string returnjson = "[{data: ";
            try
            {
                string sbtype = type;
                #region 拼接原始条件
                string defaultwhere = "";//原始条件
                if (wherequery == "undefined" || wherequery == "" || wherequery == null)
                {
                    wherequery = " and fldSource=0";
                }
                if (pageshow == "1")
                {
                    defaultwhere = "  fldImport=1 and fldFlag=0 and fldCityID_Operate=" + cityid;
                }
                if (pageshow == "0")
                {
                    defaultwhere = " fldFlag=1 ";
                }
                #endregion

                #region 基本数据获取
                RuletblDictionary dic = new RuletblDictionary();
                string list = dic.ByParentIDAndValue("数据审核视图", sbtype);//获取需要的视图名称
                RuleEQIV_WaitTable_Auditing rulAud = new RuleEQIV_WaitTable_Auditing();
                string ViewName = list.Split(',')[0].ToString();
                string ChinesizeViewName = list.Split(',')[1].ToString();//汉化表头需要的视图名称
                wherequery = defaultwhere + HttpUtility.UrlDecode(wherequery);
                DataTable dt = rulAud.GetEqiv_AuditingData(ViewName, wherequery,sbtype);//需要的数据数据
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
                returnjson += ",head: [";
                //拼标题并汉化
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string engname = "'" + dt.Columns[i].ColumnName + "'";
                    DataTable dtDesc = rule.ChinesizeTitleNamebyViewName(ChinesizeViewName, engname);//根据视图名称在字典表中查出对应字段的中文名称

                    if (dtDesc.Rows.Count > 0)
                    {
                        if (i == dt.Columns.Count - 1)
                        {
                            returnjson += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "'";
                        }
                        else
                        {
                            returnjson += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "',";

                        }
                    }
                }
                #endregion

                returnjson += "]}]";
                #region 最后返回数据给前台
                if (dt.Rows.Count > 0)
                {
                    returnjson = rule.JsonStr("ok", "", returnjson.ToString());//有数据
                }
                else
                {
                    
                    returnjson = rule.JsonStr("nodata", "没有数据", returnjson.ToString());//没数据
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
        /// 功能描述：获得生态、生物审核的数据
        /// 创建者：熊瑞竹
        /// 创建日期：2017-08-24
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <param name="wherequery">查询条件</param>
        /// <param name="pageshow">数据类型</param>
        /// <param name="cityid">城市Id</param>
        /// <returns>返回基本信息数据的Json字符串</returns>
        [HttpGet]
        //
        public HttpResponseMessage Geteqicom_basic(string type, string wherequery, string pageshow, string cityid)
        {
            string returnjson = "[{data: ";
            try
            {
                string sbtype = type;
                #region 拼接原始条件
                string defaultwhere = "";//原始条件
                if (wherequery == "undefined" || wherequery == "" || wherequery == null)
                {
                    wherequery = " and fldSource=0";
                }
                if (pageshow == "2")
                {
                    defaultwhere = "  fldFlag=-1 and fldImport=1 ";
                }
                if (pageshow == "3")
                {
                    defaultwhere = "  fldFlag=0 and fldImport=0 ";
                }
                if (pageshow == "4")
                {
                    defaultwhere = "  fldFlag=-1 and fldImport=0 ";
                }
                if (pageshow == "5")
                {
                    defaultwhere = "  fldFlag=1 and fldImport=0 ";
                }
                if (pageshow == "6")
                {
                    defaultwhere = " fldFlag=1 ";
                }
                #endregion

                #region 基本数据获取
                RuletblDictionary dic = new RuletblDictionary();
                string list = dic.ByParentIDAndValue("数据审核视图", sbtype);//获取需要的视图名称
                RuleEQIV_WaitTable_Auditing rulAud = new RuleEQIV_WaitTable_Auditing();
                string ViewName = list.Split(',')[0].ToString();
                string ChinesizeViewName = list.Split(',')[1].ToString();//汉化表头需要的视图名称
                wherequery =  defaultwhere + HttpUtility.UrlDecode(wherequery)+"and fldCityID_Operate=" + cityid ;
                DataTable dt = rulAud.GetEqiv_AuditingData(ViewName, wherequery, sbtype);//需要的数据数据
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
                returnjson += ",head: [";
                //拼标题并汉化
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string engname = "'" + dt.Columns[i].ColumnName + "'";
                    DataTable dtDesc = rule.ChinesizeTitleNamebyViewName(ChinesizeViewName, engname);//根据视图名称在字典表中查出对应字段的中文名称

                    if (dtDesc.Rows.Count > 0)
                    {
                        if (i == dt.Columns.Count - 1)
                        {
                            returnjson += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "'";
                        }
                        else
                        {
                            returnjson += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "',";

                        }
                    }
                }
                #endregion

                returnjson += "]}]";
                #region 最后返回数据给前台
                if (dt.Rows.Count > 0)
                {
                    returnjson = rule.JsonStr("ok", "", returnjson.ToString());//有数据
                }
                else
                {

                    returnjson = rule.JsonStr("nodata", "没有数据", returnjson.ToString());//没数据
                }
            }
            catch (Exception e)
            {
                returnjson = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(returnjson, System.Text.Encoding.UTF8, "application/json") };
                #endregion
        }
    }
}

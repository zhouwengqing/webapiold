using DDYZ.Ensis.Presistence.DataEntity;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using DDYZ.Ensis.Rule.DataRule;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCommon.Common
{
    /// <summary>
    /// 审核数据表
    /// </summary>
    public class WaitTableAllController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：获得审核的数据
        /// 创建者：熊瑞竹
        /// 创建日期：2017-06-06
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="info">所有的查询条件信息</param> 
        /// <returns>返回基本信息数据的Json字符串</returns>
        [HttpPost]
        

        public HttpResponseMessage Geteqicom_data(GetParams_Info info)
        {
            string returnjson = "[{data: ";
            try
            {
                string sbtype = info.type;


                #region 拼接原始条件
                string defaultwhere = "";//原始条件

                if (info.wherequery == "undefined" || info.wherequery == "" || info.wherequery == null)
                {
                    if (sbtype == "eqiw_r_auto")
                    {
                        //info.wherequery = " and ";
                    }
                    else
                    {
                        info.wherequery = " and fldSource=0";
                    }
                }
                if (info.defwhere == null)
                {
                    if (sbtype == "eqiw_r_auto")
                    {
                        if (info.pageshow == "0")
                        {
                            //defaultwhere = " fldFlag=1 ";
                        }
                        if (info.pageshow == "1")
                        {
                            defaultwhere = " fldFlag=0 ";
                        }
                    }
                    else
                    {
                        if (info.pageshow == "1")
                        {
                            defaultwhere = "fldCityID_Operate=" + info.cityid + " and fldFlag=0 and fldImport=1 ";
                        }
                        if (info.pageshow == "0")
                        {
                            defaultwhere = " fldFlag=1 ";
                        }
                    }

                }
                else
                {
                    defaultwhere = info.defwhere;
                }


                #endregion


                #region 基本数据获取
                RuletblDictionary dic = new RuletblDictionary();
                string list = dic.ByParentIDAndValue("数据审核视图", sbtype);
                RuleEQICommon_Auditing rulAud = new RuleEQICommon_Auditing();
                string ViewName = list.Split(',')[0].ToString();
                string ChinesizeViewName = list.Split(',')[1].ToString();
                info.wherequery = defaultwhere + HttpUtility.UrlDecode(info.wherequery, Encoding.UTF8);
                DataTable dt = rulAud.GetAuditingDatabyBusinessType(sbtype, ViewName, info.wherequery, 0);//需要的数据数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["fldAutoID"] = dt.Rows[i]["fldAutoID"].ToString().Replace(',', '_');
                }
                #endregion



                #region 增加颜色标识
                if (info.type == "eqiw_r_auto")
                {

                    #region 判断同一点，同一因子，连续三个相等

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow[] dr = dt.Select("fldRSName='" + dt.Rows[i]["fldRSName"] + "'");
                        //先判断这个断面是否有三个断面
                        if (dr.Length >= 3)
                        {
                            for (int j = 0; j < dr.Length; j++)
                            {
                                for (int h = 9; h < dt.Columns.Count; h++)
                                {
                                    string dist = dr[j][h].ToString();
                                    //为空的不判断
                                    if (dist != "")
                                    {
                                        //第一次的跟后两次比较
                                        if (j == 0)
                                        {

                                            if (dist == dr[j + 1][h].ToString() && dist == dr[j + 2][h].ToString())
                                            {
                                                dr[j][h] = dist + "_XTJCCW";
                                                dr[j + 1][h] = dr[j + 1][h].ToString() + "_XTJCCW";
                                                dr[j + 2][h] = dist + "_XTJCCW";
                                            }

                                        }//最后一次跟前两次比较
                                        else if (j == dr.Length - 1)
                                        {

                                            if (dist + "_XTJCCW" == dr[j - 1][h].ToString() && dist + "_XTJCCW" == dr[j - 2][h].ToString())
                                            {
                                                dr[j][h] = dist + "_XTJCCW";
                                            }

                                        }//其他的跟前面一次比较和后面一次比较
                                        else
                                        {

                                            if (dist + "_XTJCCW" == dr[j - 1][h].ToString() && dist == dr[j + 1][h].ToString())
                                            {
                                                dr[j][h] = dist + "_XTJCCW";
                                            }

                                        }
                                    }


                                }

                            }

                        }

                    }
                    #endregion

                    List<Mode.tblEQIW_R_Auto_Remark> list_remark = new List<Mode.tblEQIW_R_Auto_Remark>();

                    using (Mode.EntityContext db = new Mode.EntityContext())
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
                                        item[item2.ColumnName] += "_XTJCCW";
                                    }
                                    else
                                    {
                                        //var query5 = (from x in dt.AsEnumerable()
                                        //              where x["fldSTCode"].ToString() == item["fldSTCode"].ToString() &&
                                        //              x["fldRCode"].ToString() == item["fldRCode"].ToString() &&
                                        //              x["fldRSCode"].ToString() == item["fldRSCode"].ToString() &&
                                        //              x[item2.ColumnName].ToString() == item[item2.ColumnName].ToString()
                                        //              select x).Count();

                                        //if (query5 >= 3)
                                        //{
                                        //    item[item2.ColumnName] += "_XTJCCW";
                                        //}





                                        var query3 = (from x in dtItem.AsEnumerable()
                                                      where x["fldItemCode"].ToString() == name &&
                                                      x["fldRSCode"].ToString() == item["fldRSCode"].ToString()
                                                      select x).FirstOrDefault();

                                        if (query3 != null)
                                        {
                                            //溶解氧特殊判断
                                            if (name == "315")
                                            {
                                                if (value < double.Parse(query3["fldItemTarget"].ToString()))
                                                {
                                                    item[item2.ColumnName] += "_XTJCCW";
                                                }
                                            }
                                            //Ph特殊处理
                                            else if (name == "302")
                                            {
                                                if (value > 9 || value < 6)
                                                {
                                                    item[item2.ColumnName] += "_XTJCCW";
                                                }
                                            }
                                            else
                                            {
                                                if (value > double.Parse(query3["fldItemTarget"].ToString()))
                                                {
                                                    item[item2.ColumnName] += "_XTJCCW";
                                                }
                                            }


                                        }
                                    }


                                    var query4 = (from x in list_remark
                                                  where x.fldSTCode == item["fldSTCode"].ToString() &&
                                                  x.fldRCode == item["fldRCode"].ToString() &&
                                                  x.fldRSCode == item["fldRSCode"].ToString() &&
                                                  x.fldDate == DateTime.Parse(item["fldDate"].ToString() + " " + item["fldHour"].ToString() + ":00:00") &&
                                                  x.fldItemCode == name
                                                  select x).ToList();

                                    if (query4.Count > 0)
                                    {
                                        foreach (var item4 in query4)
                                        {
                                            if (dt.Columns.Contains("fld" + item4.fldItemCode) && item4.fldRemark != "正常")
                                            {
                                                // _0 代表 是用户手工自己填的备注信息
                                                item[item2.ColumnName] += "_YHQRCW";
                                            }
                                            if (dt.Columns.Contains("fld" + item4.fldItemCode) && item4.fldRemark == "正常")
                                            {
                                                // _0 代表 是用户手工自己填的备注信息
                                                item[item2.ColumnName] += "_ZHENGCHANG";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }


                }
                #endregion




                #region 数据源转化为Json格式
                string json = JsonHelper.SerializeObject(dt);
                returnjson += json;
                #endregion


                #region 拼数据对应列名
                returnjson += ",head: [";
                RuletblEQIA_R_Item itemnames = new RuletblEQIA_R_Item();
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
                    else
                    {
                        string itemcode = dt.Columns[i].ColumnName.Substring(3);
                        tblEQIA_R_Item name = itemnames.ByItemCodes(itemcode, sbtype, "");

                        if (i == dt.Columns.Count - 1)
                        {
                            //最后一列的时候添加“]”↓
                            returnjson += "'" + name.fldItemName + "']}]";

                        }
                        else
                        {

                            returnjson += "'" + name.fldItemName + "',";

                        }

                    }
                }
                #endregion


                #region 最后返回数据给前台
                if (dt.Rows.Count > 0)
                {
                    returnjson = rule.JsonStr("ok", "", returnjson.ToString());//有数据
                }
                else
                {
                    returnjson += "]}]";
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





        [HttpGet]
        public HttpResponseMessage Geteqicom_data(string type, string wherequery, string pageshow, string cityid, string defwhere = null)
        {
            string returnjson = "[{data: ";
            try
            {
                string sbtype = type;


                #region 拼接原始条件
                string defaultwhere = "";//原始条件

                if (wherequery == "undefined" || wherequery == "" || wherequery == null)
                {
                    if (sbtype == "eqiw_r_auto")
                    {
                        //wherequery = " and ";
                    }
                    else
                    {
                        wherequery = " and fldSource=0";
                    }
                }
                if (defwhere == null)
                {
                    if (sbtype == "eqiw_r_auto")
                    {
                        if (pageshow == "0")
                        {
                            //defaultwhere = " fldFlag=1 ";
                        }
                        if (pageshow == "1")
                        {
                            defaultwhere = " fldFlag=0 ";
                        }
                    }
                    else
                    {
                        if (pageshow == "1")
                        {
                            defaultwhere = "fldCityID_Operate=" + cityid + " and fldFlag=0 and fldImport=1 ";
                        }
                        if (pageshow == "0")
                        {
                            defaultwhere = " fldFlag=1 ";
                        }
                    }

                }
                else
                {
                    defaultwhere = defwhere;
                }


                #endregion


                #region 基本数据获取
                RuletblDictionary dic = new RuletblDictionary();
                string list = dic.ByParentIDAndValue("数据审核视图", sbtype);
                RuleEQICommon_Auditing rulAud = new RuleEQICommon_Auditing();
                string ViewName = list.Split(',')[0].ToString();
                string ChinesizeViewName = list.Split(',')[1].ToString();
                wherequery = defaultwhere + HttpUtility.UrlDecode(wherequery, Encoding.UTF8);
                DataTable dt = rulAud.GetAuditingDatabyBusinessType(sbtype, ViewName, wherequery, 0);//需要的数据数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["fldAutoID"] = dt.Rows[i]["fldAutoID"].ToString().Replace(',', '_');
                }
                #endregion



                #region 增加颜色标识






                if (type == "eqiw_r_auto")
                {

                    #region 判断同一点，同一因子，连续三个相等

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow[] dr = dt.Select("fldRSName='" + dt.Rows[i]["fldRSName"] + "'");
                        //先判断这个断面是否有三个断面
                        if (dr.Length >= 3)
                        {
                            for (int j = 0; j < dr.Length; j++)
                            {
                                for (int h = 9; h < dt.Columns.Count; h++)
                                {
                                    string dist = dr[j][h].ToString();
                                    //为空的不判断
                                    if (dist != "")
                                    {
                                        //第一次的跟后两次比较
                                        if (j == 0)
                                        {

                                            if (dist == dr[j + 1][h].ToString() && dist == dr[j + 2][h].ToString())
                                            {
                                                dr[j][h] = dist + "_XTJCCW";
                                                dr[j + 1][h] = dr[j + 1][h].ToString() + "_XTJCCW";
                                                dr[j + 2][h] = dist + "_XTJCCW";
                                            }

                                        }//最后一次跟前两次比较
                                        else if (j == dr.Length - 1)
                                        {

                                            if (dist + "_XTJCCW" == dr[j - 1][h].ToString() && dist + "_XTJCCW" == dr[j - 2][h].ToString())
                                            {
                                                dr[j][h] = dist + "_XTJCCW";
                                            }

                                        }//其他的跟前面一次比较和后面一次比较
                                        else
                                        {

                                            if (dist + "_XTJCCW" == dr[j - 1][h].ToString() && dist == dr[j + 1][h].ToString())
                                            {
                                                dr[j][h] = dist + "_XTJCCW";
                                            }

                                        }
                                    }


                                }

                            }

                        }

                    }
                    #endregion

                    List<Mode.tblEQIW_R_Auto_Remark> list_remark = new List<Mode.tblEQIW_R_Auto_Remark>();

                    using (Mode.EntityContext db = new Mode.EntityContext())
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
                                        item[item2.ColumnName] += "_XTJCCW";
                                    }
                                    else
                                    {
                                        //var query5 = (from x in dt.AsEnumerable()
                                        //              where x["fldSTCode"].ToString() == item["fldSTCode"].ToString() &&
                                        //              x["fldRCode"].ToString() == item["fldRCode"].ToString() &&
                                        //              x["fldRSCode"].ToString() == item["fldRSCode"].ToString() &&
                                        //              x[item2.ColumnName].ToString() == item[item2.ColumnName].ToString()
                                        //              select x).Count();

                                        //if (query5 >= 3)
                                        //{
                                        //    item[item2.ColumnName] += "_XTJCCW";
                                        //}





                                        var query3 = (from x in dtItem.AsEnumerable()
                                                      where x["fldItemCode"].ToString() == name &&
                                                      x["fldRSCode"].ToString() == item["fldRSCode"].ToString()
                                                      select x).FirstOrDefault();

                                        if (query3 != null)
                                        {
                                            //溶解氧特殊判断
                                            if (name == "315")
                                            {
                                                if (value < double.Parse(query3["fldItemTarget"].ToString()))
                                                {
                                                    item[item2.ColumnName] += "_XTJCCW";
                                                }
                                            }
                                            //Ph特殊处理
                                            else if (name == "302")
                                            {
                                                if (value > 9 || value < 6)
                                                {
                                                    item[item2.ColumnName] += "_XTJCCW";
                                                }
                                            }
                                            else
                                            {
                                                if (value > double.Parse(query3["fldItemTarget"].ToString()))
                                                {
                                                    item[item2.ColumnName] += "_XTJCCW";
                                                }
                                            }


                                        }
                                    }


                                    var query4 = (from x in list_remark
                                                  where x.fldSTCode == item["fldSTCode"].ToString() &&
                                                  x.fldRCode == item["fldRCode"].ToString() &&
                                                  x.fldRSCode == item["fldRSCode"].ToString() &&
                                                  x.fldDate == DateTime.Parse(item["fldDate"].ToString() + " " + item["fldHour"].ToString() + ":00:00") &&
                                                  x.fldItemCode == name
                                                  select x).ToList();

                                    if (query4.Count > 0)
                                    {
                                        foreach (var item4 in query4)
                                        {
                                            if (dt.Columns.Contains("fld" + item4.fldItemCode) && item4.fldRemark != "正常")
                                            {
                                                // _0 代表 是用户手工自己填的备注信息
                                                item[item2.ColumnName] += "_YHQRCW";
                                            }
                                            if (dt.Columns.Contains("fld" + item4.fldItemCode) && item4.fldRemark == "正常")
                                            {
                                                // _0 代表 是用户手工自己填的备注信息
                                                item[item2.ColumnName] += "_ZHENGCHANG";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }


                }

                #endregion




                #region 数据源转化为Json格式
                string json = JsonHelper.SerializeObject(dt);
                returnjson += json;
                #endregion


                #region 拼数据对应列名
                returnjson += ",head: [";
                RuletblEQIA_R_Item itemnames = new RuletblEQIA_R_Item();
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
                    else
                    {
                        string itemcode = dt.Columns[i].ColumnName.Substring(3);
                        tblEQIA_R_Item name = itemnames.ByItemCodes(itemcode, sbtype, "");

                        if (i == dt.Columns.Count - 1)
                        {
                            //最后一列的时候添加“]”↓
                            returnjson += "'" + name.fldItemName + "']}]";

                        }
                        else
                        {

                            returnjson += "'" + name.fldItemName + "',";

                        }

                    }
                }
                #endregion


                #region 最后返回数据给前台
                if (dt.Rows.Count > 0)
                {
                    returnjson = rule.JsonStr("ok", "", returnjson.ToString());//有数据
                }
                else
                {
                    returnjson += "]}]";
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
        /// 功能描述：加载只有基本信息的表格
        /// 创建者：周文卿
        /// 修改日期：
        /// 修改者：熊瑞竹
        /// 修改日期：2017-06-07
        /// </summary>
        /// <param name="info">原参数信息</param> 
        /// <returns>返回基本信息数据的Json字符串</returns>
        [HttpPost]
        public HttpResponseMessage Geteqicom_basic(GetParams_Info info)
        {
            string json = "[{data: ";
            try
            {

                #region  拼查询条件
                string sbtype = info.type;
                string defaultwhere = "";//原始条件

                if (info.wherequery == "undefined" || info.wherequery == "" || info.wherequery == null)
                {
                    if (info.type.Substring(info.type.Length - 3, 3) == "_hm")
                    {
                        info.wherequery = " and fldSource=1";
                    }
                    else
                    {
                        info.wherequery = " and fldSource=0";
                    }
                }
                if (info.pageshow == "2")
                {
                    defaultwhere = " and fldFlag=-1 and fldImport=1 ";
                }
                if (info.pageshow == "3")
                {
                    defaultwhere = " and fldFlag=0 and fldImport=0 ";
                }
                if (info.pageshow == "4")
                {
                    defaultwhere = " and fldFlag=-1 and fldImport=0 ";
                }
                if (info.pageshow == "5")
                {
                    defaultwhere = " and fldFlag=1 and fldImport=0 ";
                }
                if (info.pageshow == "6")
                {
                    defaultwhere = " and fldFlag=1 ";
                }
                #endregion
                #region 查询数据
                RuletblDictionary dic = new RuletblDictionary();
                RuleEQICommon_Auditing rulAud = new RuleEQICommon_Auditing();
                string list = dic.ByParentIDAndValue("数据审核视图", sbtype.ToString());
                string ViewName = list.Split(',')[0].ToString();
                string TitleViewName = list.Split(',')[1].ToString();
                info.wherequery = "fldCityID_Operate=" + info.cityid + defaultwhere + HttpUtility.UrlDecode(info.wherequery);
                DataTable dt = rulAud.GetAuditingDatabyBusinessType(sbtype, ViewName, info.wherequery, 1);//基本信息数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["fldAutoID"] = dt.Rows[i]["fldAutoID"].ToString().Replace(',', '_');
                }
                json += JsonHelper.SerializeObject(dt);
                #endregion
                json += ",head: [";//标题

                //   RuletblEQIA_R_Item itemnames = new RuletblEQIA_R_Item();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string engname = "'" + dt.Columns[i].ColumnName + "'";
                    DataTable dtDesc = rule.ChinesizeTitleNamebyViewName(TitleViewName, engname);//根据视图名称在字典表中查出对应字段的中文名称

                    if (dtDesc.Rows.Count > 0)
                    {
                        if (i == dt.Columns.Count - 1)
                        {
                            json += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "']}]";
                        }
                        else
                        {
                            json += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "',";

                        }
                    }
                }

                #region 返回数据给前台
                if (dt.Rows.Count > 0)
                {
                    json = rule.JsonStr("ok", "", json.ToString());
                }
                else
                {
                    json = rule.JsonStr("nodata", "没有数据", json.ToString());
                }
            }
            catch (Exception e)
            {
                json = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
            #endregion
        }





        /// <summary>
        /// 获得审核的数据原参数的实体类
        /// </summary>
        public class GetParams_Info
        {
            /// <summary>
            /// 业务类型
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// 查询条件
            /// </summary>
            public string wherequery { get; set; }

            /// <summary>
            /// 数据类型
            /// </summary>
            public string pageshow { get; set; }

            /// <summary>
            /// 城市Id
            /// </summary>
            public string cityid { get; set; }

            /// <summary>
            /// 是否是三级审核
            /// </summary>
            public string defwhere { get; set; }
        }















        /// <summary>
        /// 功能描述：加载只有基本信息的表格
        /// 创建者：周文卿
        /// 修改日期：
        /// 修改者：熊瑞竹
        /// 修改日期：2017-06-07
        /// </summary>
        /// <param name="info">原参数信息</param> 
        /// <returns>返回基本信息数据的Json字符串</returns>
        [HttpGet]
        public HttpResponseMessage Geteqicom_basic(string type, string wherequery, string pageshow, string cityid)
        {
            string json = "[{data: ";
            try
            {

                #region  拼查询条件
                string sbtype = type;
                string defaultwhere = "";//原始条件

                if (wherequery == "undefined" || wherequery == "" || wherequery == null)
                {
                    if (type.Substring(type.Length - 3, 3) == "_hm")
                    {
                        wherequery = " and fldSource=1";
                    }
                    else
                    {
                        wherequery = " and fldSource=0";
                    }
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
                string list = dic.ByParentIDAndValue("数据审核视图", sbtype.ToString());
                string ViewName = list.Split(',')[0].ToString();
                string TitleViewName = list.Split(',')[1].ToString();
                wherequery = "fldCityID_Operate=" + cityid + defaultwhere + HttpUtility.UrlDecode(wherequery);
                DataTable dt = rulAud.GetAuditingDatabyBusinessType(sbtype, ViewName, wherequery, 1);//基本信息数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["fldAutoID"] = dt.Rows[i]["fldAutoID"].ToString().Replace(',', '_');
                }
                json += JsonHelper.SerializeObject(dt);
                #endregion
                json += ",head: [";//标题

                //   RuletblEQIA_R_Item itemnames = new RuletblEQIA_R_Item();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string engname = "'" + dt.Columns[i].ColumnName + "'";
                    DataTable dtDesc = rule.ChinesizeTitleNamebyViewName(TitleViewName, engname);//根据视图名称在字典表中查出对应字段的中文名称

                    if (dtDesc.Rows.Count > 0)
                    {
                        if (i == dt.Columns.Count - 1)
                        {
                            json += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "']}]";
                        }
                        else
                        {
                            json += "'" + dtDesc.Rows[0]["fldFieldDesc"].ToString() + "',";

                        }
                    }
                }

                #region 返回数据给前台
                if (dt.Rows.Count > 0)
                {
                    json = rule.JsonStr("ok", "", json.ToString());
                }
                else
                {
                    json = rule.JsonStr("nodata", "没有数据", json.ToString());
                }
            }
            catch (Exception e)
            {
                json = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
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
        /// <param name="conds">查询的字段</param>
        /// <returns>返回Json格式的子表格数据字符串</returns>
        [HttpGet]
        public HttpResponseMessage Subtable(string type, string fldAutoId, string conds)
        {
            string json = String.Empty;
            try
            {
                string conditions = conds.ToString();
                string fldAutoID = fldAutoId.ToString();//默认ID
                string listtype = type.ToString();//业务类型 
                fldAutoID = fldAutoID.Replace('_', ',');//获取fldautoid
                RuletblDictionary dic = new RuletblDictionary();
                string list = dic.ByParentIDAndValue("数据审核视图", listtype);//根据业务类型获取对应视图
                string table = list.Split(',')[0];
                string execsql = "";
                if (conditions != "" && conditions != null && conditions != "undefined")
                {
                    execsql = "select " + conditions + " from " + table + " where fldAutoID in (" + fldAutoID + ")";
                }
                else
                {
                    execsql = "select fldItemName,fldItemCode,dbo.Absolutevalue(fldItemValue) as fldItemValue,fldComment from " + table + " where fldAutoID in (" + fldAutoID + ")";
                }
                RuletblEQI_publi pub = new RuletblEQI_publi();
                DataTable dtItemInfo = pub.getdt(execsql);//因子数据
                json = JsonHelper.SerializeObject(dtItemInfo);
            }
            catch (Exception e)
            {
                json = rule.JsonStr("error", e.Message, "");
            }
            #region 返回数据给前台

            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/xm") };

            #endregion
        }

        /// <summary>
        /// 功能描述：根据业务类别查询因子的修改记录
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public HttpResponseMessage itemRecording(string type)
        {
            string json = String.Empty;
            try
            {
                RuletblItem_Recording it = new RuletblItem_Recording();
                DataTable dt = it.getbytype(type);
                json = rule.JsonStr("ok", "查询成功", dt);
            }
            catch (Exception e)
            {
                json = rule.JsonStr("error", e.Message, "");
            }
            #region 返回数据给前台

            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/xm") };

            #endregion
        }


        /// <summary>
        /// 功能描述：更新因子值
        /// 创建者：熊瑞竹
        /// 创建日期：2018/02/28
        /// </summary>
        /// <param name="infos">跟新条件参数实体类</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateItemvalue(List<UpateInfos> infos)
        {
            string json = String.Empty;
            try
            {
                bool result2 = true;
                foreach (UpateInfos item in infos)
                {
                    bool result = rule.UpdateitemAndRemark(item.autoid, item.itemcode, item.itemvalue, item.tablename, item.source, item.rsinfos, item.dtime, item.remark, item.btyname);
                    if (!result)
                    {
                        result2 = false;
                        break;
                    }
                }
                //bool test = rule.Updateitem(infos.autoid,infos.itemcode,infos.itemvalue,infos.tablename);
                if (result2 == true)
                {
                    json = rule.JsonStr("ok", "更新成功", "");
                }
                else
                {
                    json = rule.JsonStr("ok", "更新失败", "");
                }
            }
            catch (Exception e)
            {
                json = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/xm") };
        }

        /// <summary>
        /// 更新因子值要用到的实体类
        /// </summary>
        public class UpateInfos
        {
            /// <summary>
            /// 行ID
            /// </summary>
            public string autoid { get; set; }
            /// <summary>
            /// 因子代码
            /// </summary>
            public string itemcode { get; set; }
            /// <summary>
            /// 修改因子的值
            /// </summary>
            public string itemvalue { get; set; }
            /// <summary>
            /// 临时表的名称
            /// </summary>
            public string tablename { get; set; }

            /// <summary>
            /// 数据来源
            /// </summary>
            public string source { get; set; }
            /// <summary>
            /// 断面信息
            /// </summary>
            public string rsinfos { get; set; }

            /// <summary>
            /// 日期
            /// </summary>
            public string dtime { get; set; }
            /// <summary>
            /// 备注
            /// </summary>
            public string remark { get; set; }
            /// <summary>
            /// 业务名称
            /// </summary>
            public string btyname { get; set; }

        }


        /// <summary>
        /// 功能描述：查询监测数据审核中断面的水质类别以及同比和环比
        /// 创建者：熊瑞竹
        /// 创建日期：2018/03/02
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <param name="editon">执行标准</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetSectionStage(string type, string editon)
        {
            string json = String.Empty;
            try
            {
                RuleEQIV_WaitTable_Auditing rules = new RuleEQIV_WaitTable_Auditing();
                DataTable secstage = rules.Getsectionstage(type, "GB 3838-2002");

                json = rule.JsonStr("ok", "", secstage);
            }
            catch (Exception e)
            {

            }

            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/xm") };

        }


 

      
        /// <summary>
        /// 获取判断超标颜色参数
        /// </summary>
        public class stdinfos
        {
            /// <summary>
            /// 附加条件
            /// </summary>
            public string cond { get; set; }
            /// <summary>
            /// 开始时间
            /// </summary>
            public string btime { get; set; }
            /// <summary>
            /// 结束时间
            /// </summary>
            public string etime { get; set; }
            /// <summary>
            /// 点位代码
            /// </summary>
            public string point { get; set; }
            /// <summary>
            /// 因子代码
            /// </summary>
            public string ItemCode { get; set; }

            /// <summary>
            /// 视图名称
            /// </summary>
            public string viewname { get; set; }


        }


        /// <summary>
        ///  功能描述：汉化因子
        ///  创建  人：周文卿
        ///  创建时间：2017/06/28
        ///  修改原因：全部转换成大写字母好比较
        ///  修改时间：2018/01/24
        ///  修改  人：熊瑞竹
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="vwname">表名称</param>
        /// <returns>DataTable</returns>
        private DataTable GetItemChineseDt(DataTable dt, string vwname)
        {
            vwname = vwname.ToUpper();
            DataTable Itemdt = new DataTable();
            if (vwname == "vwEQIW_R_Basedata".ToUpper() || vwname == "tblEQIW_R_Basedata".ToUpper() ||
                 vwname == "vwEQIW_R_Basedata_xia".ToUpper() || vwname == "vwEQIW_R_Basedata_xia_Pre".ToUpper() || vwname == "vwEQIW_STS_BasedataD".ToUpper() || vwname == "vwEQIW_R_Basedata_Auto".ToUpper())
            {
                RuletblEQIW_R_Item ruleW = new RuletblEQIW_R_Item();
                Itemdt = ruleW.GetAllData();
            }
            else if (vwname == "vwEQIS_W_BaseData".ToUpper())
            {
                RuletblEQIS_W_Item ruleW = new RuletblEQIS_W_Item();
                Itemdt = ruleW.GetAllData();
            }
            else if (vwname == "vwEQISO_Basedata".ToUpper())
            {
                RuletblEQISO_Item ruleW = new RuletblEQISO_Item();
                Itemdt = ruleW.GetAllData();
            }

            else if (vwname == "vwEQIS_W_Un_BaseData".ToUpper())
            {
                RuletblEQIS_W_Item ruleW = new RuletblEQIS_W_Item();
                Itemdt = ruleW.GetAllData();
            }
            else if (vwname == "vwEQISE_Basedata".ToUpper())
            {
                RuletblEQISE_Item ruleW = new RuletblEQISE_Item();
                Itemdt = ruleW.GetAllData();
            }
            else if (vwname == "vwEQIW_G_Basedata".ToUpper())
            {
                RuletblEQIW_R_Item ruleW = new RuletblEQIW_R_Item();
                Itemdt = ruleW.GetAllData();
            }
            //河流翻译表头
            else if (vwname == "vwEQIW_D_Basedata_xia".ToUpper() || vwname == "vwEQIW_D_Basedata".ToUpper() || vwname == "tblEQIW_D_Basedata".ToUpper() || vwname == "vwEQIW_R_BasedataD".ToUpper())
            {
                RuletblEQIW_R_Item ruleW = new RuletblEQIW_R_Item();
                Itemdt = ruleW.GetAllData();
            }
            else if (vwname.ToLower().IndexOf("eqiw_dt_basedata".ToUpper()) != -1 || vwname == "vwEQIW_DT_Basedata_xia".ToUpper() || vwname == "vwEQIW_DT_Basedata".ToUpper())
            {
                RuletblEQIW_R_Item ruleW = new RuletblEQIW_R_Item();
                Itemdt = ruleW.GetAllData();
            }

            //湖库翻译表头
            else if (vwname == "tblEQIW_D_Basedata".ToUpper() || vwname == "vwEQIW_L_Basedata".ToUpper())
            {
                RuletblEQIW_R_Item ruleW = new RuletblEQIW_R_Item();
                Itemdt = ruleW.GetAllData();
            }
            //降水翻译表头
            else if (vwname == "vwEQIA_PPI_Basedata".ToUpper() || vwname == "vwEQIA_PPI_Basedata_xia".ToUpper() || vwname == "tblEQIA_PPI_Basedata".ToUpper())
            {
                RuletblEQIA_P_Item ruleW = new RuletblEQIA_P_Item();
                Itemdt = ruleW.GetAllData();
            }
            //降尘翻译表头
            else if (vwname == "vwEQIA_RDPI_Basedata".ToUpper() || vwname == "vwEQIA_RDPI_Basedata_xia".ToUpper())
            {
                RuletblEQIA_RD_Item ruleW = new RuletblEQIA_RD_Item();
                Itemdt = ruleW.GetAllData();
            }
            else if (vwname == "vwEQIA_D_Basedata".ToUpper() || vwname == "vwEQIA_D_Basedata_xia".ToUpper() || vwname == "vwEQIA_D_BasedataAVG".ToUpper())
            {
                RuletblEQIA_D_Item ruleW = new RuletblEQIA_D_Item();
                Itemdt = ruleW.GetAllData();
            }
            //大气翻译表头
            else if (vwname == "vwEQIA_RPI_Basedata".ToUpper() || vwname == "vwEQIA_STS_Basedata_query".ToUpper() || vwname == "vwEQIA_RPI_Basedata_query_xia".ToUpper() || vwname == "vwEQIA_RPI_Basedata_Acquisition".ToUpper() || vwname == "vwEQIA_RPI_Basedata_query".ToUpper())
            {
                RuletblEQIA_R_Item ruleW = new RuletblEQIA_R_Item();
                Itemdt = ruleW.GetAllData();
            }
            if (vwname.IndexOf("EQIW") >= 0 || vwname.IndexOf("vwEQIA_D_BasedataAVG".ToUpper()) >= 0)
            {
                for (int i = 0; i < Itemdt.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["fldFieldName"] = "fld" + Itemdt.Rows[i]["fldItemCode"].ToString();
                    dr["fldFieldDesc"] = Itemdt.Rows[i]["fldItemName"].ToString();
                    dt.Rows.Add(dr);
                }
                DataRow dr1 = dt.NewRow();
                DataRow dr2 = dt.NewRow();
                DataRow dr3 = dt.NewRow();
                dr1["fldFieldName"] = "fldSea";
                dr1["fldFieldDesc"] = "季";
                dr2["fldFieldName"] = "fldhalfyear";
                dr2["fldFieldDesc"] = "半年";
                dr2["fldFieldName"] = "fldSrot";
                dr2["fldFieldDesc"] = "区域排序";
                dt.Rows.Add(dr1);
                dt.Rows.Add(dr2);
                dt.Rows.Add(dr3);
                return dt;

            }
            else
            {
                for (int i = 0; i < Itemdt.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["fldFieldName"] = "fld" + Itemdt.Rows[i]["fldItemCode"].ToString();
                    dr["fldFieldDesc"] = Itemdt.Rows[i]["fldItemName"].ToString();
                    dt.Rows.Add(dr);
                }
                return dt;
            }

        }

    }
}

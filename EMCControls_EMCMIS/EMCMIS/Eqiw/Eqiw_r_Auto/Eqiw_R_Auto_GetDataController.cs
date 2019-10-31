using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_r_Auto
{
    /// <summary>
    /// 地表水自动监测获取数据
    /// </summary>
    public class Eqiw_R_Auto_GetDataController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获取近一小时的数据
        /// 创建者：熊瑞竹
        /// 创建日期：2018-03-17
        /// </summary>
        /// <param name="vname">视图名称 例如 vwEQIW_R_HourData_Auto_RawD</param>
        /// <param name="btype">业务名称 例如 eqiw_r</param>
        /// <param name="strwhere">过滤查询条件 例如 fldmonth=3</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOneHour_data(string vname, string btype, string strwhere)
        {
            string json = "[{data: ";
            try
            {
                RuletblEQIW_R_HourData_Auto rules = new RuletblEQIW_R_HourData_Auto();
                if (strwhere == null || strwhere == "undefind")
                {
                    strwhere = ""
;
                }
                DataTable dt = rules.getOneHour_Data(vname, strwhere);
                string sql1 = "select *  from tblEQIW_R_Item_Auto";
                DataTable tableitem = rule.getdt(sql1);
                DataRow dr = dt.NewRow();
                dr["fldSTName"] = "城市名称";
                dr["fldRName"] = "河流名称";
                dr["fldRSName"] = "断面名称";
                dr["fldDate"] = "监测日期";
                dr["fldTime"] = "监测时间";
                for (int i = 6; i < dt.Columns.Count; i++)
                {
             
                    DataRow[] dataRows = tableitem.Select("fldItemCode='" + dt.Columns[i].ToString().Substring(3) + "'");
                    if (dataRows.Length > 0)
                    {
                        dr[dt.Columns[i].ToString()] = dataRows[0]["fldUnit"].ToString();
                    }
                }
                dt.Rows.InsertAt(dr, 0);
                string jsondt = JsonHelper.SerializeObject(dt);

                json += jsondt;
                #region 拼数据对应列名
                json += ",head: [";
                RuletblEQIA_R_Item itemnames = new RuletblEQIA_R_Item();
                //拼标题并汉化
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string engname = "'" + dt.Columns[i].ColumnName + "'";
                    DataTable dtDesc = rule.ChinesizeTitleNamebyViewName(vname, engname);//根据视图名称在字典表中查出对应字段的中文名称

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
                    else
                    {
                        string itemcode = dt.Columns[i].ColumnName.Substring(3);
                        tblEQIA_R_Item name = itemnames.ByItemCodes(itemcode, btype, "");
                        if (i == dt.Columns.Count - 1)
                        {
                            //最后一列的时候添加“]”↓
                            json += "'" + name.fldItemName + "']}]";

                        }
                        else
                        {

                            json += "'" + name.fldItemName + "',";

                        }
                    }
                }
                #endregion
                if (dt.Rows.Count > 0)
                {
                    json = rule.JsonStr("ok", "", json.ToString());//有数据
                }
                else
                {
                    json = rule.JsonStr("nodata", "没有数据", json.ToString());//没数据
                }
            }
            catch (Exception e)
            {
                json = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };


        }
    }
}

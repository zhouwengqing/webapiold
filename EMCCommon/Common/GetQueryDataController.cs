using System;
using System.Net.Http;
using System.Web.Http;
using DDYZ.Ensis.Rule.DataRule;
using System.Data;

using Newtonsoft.Json.Linq;

namespace EMCCommon.Common
{
    /// <summary>
    /// 数据查询结果
    /// 创建人：周文卿
    /// 创建时间：2017/06/16
    /// 
    /// </summary>
    public class GetQueryDataController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        string strLocalpath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/Query.json");//配置的json文件地址
      



        private decimal ConvertToDecimal(string value)
        {
            return Convert.ToDecimal(decimal.Parse(value, System.Globalization.NumberStyles.Float));
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

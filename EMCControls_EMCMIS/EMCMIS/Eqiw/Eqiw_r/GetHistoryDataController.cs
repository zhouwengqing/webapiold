using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_r
{
    /// <summary>
    /// 查询历史数据
    /// </summary>
    public class GetHistoryDataController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获得历史数据
        /// 创建  人：周文卿
        /// 创建时间：2018/08/13
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage GetEqiw_R_History(historypra obj)
        {
            string result = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                RuletblEQIW_R_Basedata ru = new RuletblEQIW_R_Basedata();

                string itemname = obj.fldItemName;
                string praname = "";
                if (itemname != null && itemname != "")
                {
                    string[] listname = itemname.Split('、');
                    for (int i = 0; i < listname.Length; i++)
                    {
                        praname += "[" + listname[i].Substring(0, listname[i].IndexOf("(")) + "],";
                    }
                }
                praname = praname.Substring(0, praname.Length - 1);

                string ti = DateTime.Now.AddYears(-2).ToShortDateString();
                dt = ru.GetHistory(obj.fldSTName, obj.fldRName, obj.fldRSName, ti, praname);
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }
    }


    /// <summary>
    /// 参数
    /// </summary>
    public class historypra
    {
        /// <summary>
        /// 城市名称
        /// </summary>
        public string fldSTName { get; set; }

        /// <summary>
        /// 测点名称
        /// </summary>
        public string fldRName { get; set; }

        /// <summary>
        /// 断面名称
        /// </summary>
        public string fldRSName { get; set; }

        /// <summary>
        /// 因子名称
        /// </summary>
        public string fldItemName { get; set; }
    }
}

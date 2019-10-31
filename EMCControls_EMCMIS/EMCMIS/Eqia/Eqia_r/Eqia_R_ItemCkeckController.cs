
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;


namespace EMCControls_EMCMIS.Eqia.Eqia_r
{
    /// <summary>
    /// 大气监测因子标准值
    /// </summary>
    public class Eqia_R_ItemCkeckController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述    ：  根据因子代码获取执行标准值
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-06-15
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="itemcontent">监测因子代码</param>
        /// <param name="standardnum">执行标准名称</param>
        /// <param name="std">执行标准级别</param>
        /// <param name="type">备用参数</param>
        /// <returns>返回因子执行标准值</returns>
        [HttpGet]
        //
        public HttpResponseMessage Geteqia_r_daySTG(string itemcontent, string standardnum,string std,string type)
        {
            string result = string.Empty;
            try
            {
                string itemCode1000 = System.Configuration.ConfigurationManager.AppSettings["itemCode1000"].ToString();//因子单位mg转ug *1000
                List<ItemSTD> itemstd = new List<ItemSTD>();
                RuletblEQIA_R_ItemSTD rule_itemstd = new RuletblEQIA_R_ItemSTD();
                IList<tblEQIA_R_ItemSTD> list = rule_itemstd.GetDaySTG(itemcontent.TrimEnd(new char[] { ',' }), standardnum);
                if (list != null && list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (itemCode1000.Contains(list[i].fldItemCode))
                        {
                            list[i].fldDaySTG1 = list[i].fldDaySTG1;
                            list[i].fldDaySTG2 = list[i].fldDaySTG2;
                            list[i].fldDaySTG3 = list[i].fldDaySTG3;
                            list[i].fldHourSTG1 = list[i].fldHourSTG1;
                            list[i].fldHourSTG2 = list[i].fldHourSTG2;
                            list[i].fldHourSTG3 = list[i].fldHourSTG3;
                        }
                        string stgstr = "";
                        switch (std)
                        {
                            case "1":
                                stgstr = type == "0" ? list[i].fldDaySTG1.ToString() : list[i].fldHourSTG1.ToString();
                                break;
                            case "2":
                                stgstr = type == "0" ? list[i].fldDaySTG2.ToString() : list[i].fldHourSTG2.ToString();
                                break;
                            case "3":
                                stgstr = type == "0" ? list[i].fldDaySTG3.ToString() : list[i].fldHourSTG3.ToString();
                                break;
                        }
                        ItemSTD str = new ItemSTD();
                        str.key = list[i].fldItemCode;
                        str.stg = stgstr;
                        itemstd.Add(str);
                    }
                    result = rule.JsonStr("ok", "", itemstd);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有因子对应的执行质量标准", itemstd);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }           
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}

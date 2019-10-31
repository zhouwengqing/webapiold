using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqia.Eqia_rd
{
    /// <summary>
    /// 降尘监测因子标准值
    /// </summary>
    public class Eqia_RD_ItemCkeckController : ApiController
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
        /// <returns>返回因子执行标准值</returns>
        [HttpGet]
        //
        public HttpResponseMessage Geteqia_rd_daySTG(string itemcontent, string standardnum, string std)
        {
            string result = string.Empty;
            try
            {
                List<ItemSTD> itemstd = new List<ItemSTD>();
                RuletblEQIA_RD_ItemSTD rule_itemstd = new RuletblEQIA_RD_ItemSTD();
                IList<tblEQIA_RD_ItemSTD> list = rule_itemstd.GetDaySTG(itemcontent, standardnum);
                if (list != null && list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        string stgstr = "";
                        switch (std)
                        {
                            case "1":
                                stgstr = list[i].fldDaySTG1.ToString();
                                break;
                            case "2":
                                stgstr = list[i].fldDaySTG2.ToString();
                                break;
                            case "3":
                                stgstr = list[i].fldDaySTG3.ToString();
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
            catch(Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}

using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using EMCControls_EMCMIS.EMCMIS.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqiw.Eqiw_r
{
    /// <summary>
    /// 地表水检查
    /// </summary>
    public class Eqiw_R_Auto_ItemCkeckController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述    ：  根据因子代码获取执行标准值
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-06-16
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="itemcontent">监测因子代码</param>
        /// <param name="standardnum">执行标准名称</param>
        /// <param name="std">执行标准级别</param>
        /// <param name="type">返回因子执行标准值</param>
        /// <returns>返回因子执行标准值</returns>
        [HttpGet]
        //
        public HttpResponseMessage Geteqiw_r_daySTG(string itemcontent, string standardnum, string std, string type)
        {
            string result = string.Empty;
            try
            {
                RuletblEQIW_R_DAQLTSTD rule_itemstd = new RuletblEQIW_R_DAQLTSTD();
                List<ItemSTD> itemstd = new List<ItemSTD>();
                IList<DDYZ.Ensis.Presistence.DataEntity.tblEQIW_R_DAQLTSTD> list = rule_itemstd.GetSTD(itemcontent, standardnum);
                if (list != null && list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        string stgstr = "";
                        switch (std)
                        {
                            case "1":
                                stgstr = list[i].fldST10.ToString();
                                break;
                            case "2":
                                stgstr = list[i].fldST20.ToString();
                                break;
                            case "3":
                                stgstr = list[i].fldST30.ToString();
                                break;
                            case "4":
                                stgstr = list[i].fldST40.ToString();
                                break;
                            case "5":
                                stgstr = list[i].fldST50.ToString();
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

        /// <summary>
        /// 功能描述：获得自动因子表
        /// 创建  人：周文卿
        /// 创建时间：2018/07/27
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public HttpResponseMessage Geteqiw_r_item()
        {
            string result = string.Empty;
            try
            {
                List<tblEQIW_R_Item_Auto> list = new List<tblEQIW_R_Item_Auto>();
                using (EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {

                    list = (from x in db.tblEQIW_R_Item_Auto
                            select x).ToList();
                    result = rule.JsonStr("ok", "", list);
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

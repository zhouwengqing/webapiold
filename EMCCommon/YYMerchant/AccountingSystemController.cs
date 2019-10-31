using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.EMCCommon.AccountController.WebApiCore;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCCommon.YYMerchant
{
    /// <summary>
    ///  功能描述：商户系统账户表
    ///  创建时间：2018-12-20
    ///  创建  人：周文卿
    /// </summary>
    /// 
    public class AccountingSystemController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：
        /// </summary>
        /// <param name="Merchant">商户ID</param>
        /// <returns></returns>
        /// 

        [HttpGet]
        [MerchantFiter]
        public HttpResponseMessage GetAccountingSystem(string Merchant)
        {
            string result = string.Empty;
            try
            {
                using (YYPlayContext db = new YYPlayContext())
                {

                    //查询所有的数据  用于前端筛选
                    List<vwtblAccountingSystem> AccountingSystem = (from x in db.vwtblAccountingSystem
                                                                    where x.fldMerchID== Merchant
                                                                    select x).ToList();

                    if (AccountingSystem.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", AccountingSystem);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "无数据！", AccountingSystem);
                    }
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

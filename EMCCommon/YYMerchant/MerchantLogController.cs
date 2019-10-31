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
    /// 功能描述：商户平台登录日志
    /// 创建时间：2018-12-21
    /// 创建  人：周文卿
    /// </summary>
    public class MerchantLogController : ApiController
    {
        RuleCommon rule = new RuleCommon();

      /// <summary>
      /// 
      /// </summary>
      /// <param name="mid"></param>
      /// <returns></returns>
        [HttpGet]
        [MerchantFiter]
        public HttpResponseMessage GetMerchantLog(string mid )
        {
            string result = string.Empty;
            try
            {

                using (Model1 db = new Model1())
                {
                    var merchant = (from x in db.tblMerchantLog
                                    where x.fldMerchant == mid
                                    orderby x.fldLoginTime  descending
                                    select x).Skip(1).Take(1);
                    result = rule.JsonStr("ok", "", merchant);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}

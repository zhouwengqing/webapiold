using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EMCCommon.Mode;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.EMCCommon.AccountController.WebApiCore;
using System.Data.Entity;
using System.Data;

namespace EMCCommon.YYplay
{
    /// <summary>
    /// 费率表相关的操作
    /// </summary>
    public class MerchantRateController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：根据商户ID查询费率
        /// 创建  人：周文卿
        /// 创建时间：20181106
        /// </summary>
        /// <param name="id">商户id</param>
        /// <returns></returns>
        [HttpGet]
        [SupportFilter]
        public HttpResponseMessage GetMerchantList(string id)
        {
            string result = string.Empty;
            try
            {

                using (YYPlayContext db = new YYPlayContext())
                {
                    List<tblMerchantRate> tbls = (from x in db.tblMerchantRate
                                                  where x.fldMerchID == id
                                                  select x
                                                ).ToList();
                    
                    if (tbls.Count > 0)
                    {
                        for (int i = 0; i < tbls.Count; i++)
                        {
                            if (tbls[i].fldENName != "pay")
                            {
                                tbls[i].fldRate = tbls[i].fldRate * 100;
                            }
                            
                        }
                        result = rule.JsonStr("ok", "", tbls);
                    }
                    else
                    {
                        result = rule.JsonStr("err", "", true);
                    }
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：新增或者修改
        /// 创建  人：周文卿
        /// 创建时间：20181106
        /// </summary>
        /// <param name="pram">商户id</param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage addorupdateMerchantList(addorupdat pram)
        {
            string result = string.Empty;
            try
            {

                using (YYPlayContext db = new YYPlayContext())
                {
                    //如果为空 就插入,否则修改
                    if (pram.isnull)
                    {
                        List<tblMerchantRate> tblMerchantRates = pram.tbl;
                        for (int i = 0; i < tblMerchantRates.Count; i++)
                        {
                            string fldENName = tblMerchantRates[i].fldENName;
                            tbleRate tbleRate = (from x in db.tbleRate
                                                 where x.fldENName == fldENName
                                                 select x).Single();
                            if (fldENName != "pay")
                            {
                                tblMerchantRates[i].fldRate = tblMerchantRates[i].fldRate / 100;
                            }
                            tblMerchantRates[i].fldRateCode = tbleRate.fldRateCode;
                        }
                        db.tblMerchantRate.AddRange(tblMerchantRates);
                        db.SaveChanges();
                        result = rule.JsonStr("ok", "更新成功", "");
                    }
                    else
                    {

                        List<tblMerchantRate> rates = pram.tbl;
                        for (int i = 0; i < rates.Count; i++)
                        {
                            string fldENName = rates[i].fldENName;
                            string fldMerchID = rates[i].fldMerchID;
                            tblMerchantRate tbls = (from x in db.tblMerchantRate
                                                    where x.fldENName == fldENName &&
                                                    x.fldMerchID == fldMerchID
                                                    select x).Single();
                            if (fldENName != "pay")
                            {
                                tbls.fldRate = rates[i].fldRate / 100;
                            }
                            else
                            {
                                tbls.fldRate = rates[i].fldRate;
                            }
                            db.SaveChanges();
                        }
                        result = rule.JsonStr("ok", "更新成功", "");
                    }
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 
        /// </summary>
        public class addorupdat
        {
            /// <summary>
            /// 
            /// </summary>
            public List<tblMerchantRate> tbl { get; set; }

            /// <summary>
            /// 是否有数据
            /// </summary>
            public bool isnull { get; set; }
        }
    }
}

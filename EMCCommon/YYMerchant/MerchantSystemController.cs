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
    /// 功能描述：商户系统的商户表
    /// 创建时间：2018-12-13
    /// 创建  人：周文卿
    /// </summary>
    public class MerchantSystemController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        ///  功能描述：功能商户ID 查询秘钥
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [MerchantFiter]
        public HttpResponseMessage GetMerchant(param param)
        {
            string result = string.Empty;
            try
            {

                using (YYPlayContext db = new YYPlayContext())
                {
                    var merchant = db.tbleMerchant.Select(x => new { x.fldSecretKey, x.fldMerchID, x.fldMerchName }).Where(x => x.fldMerchID == param.MerchantID).DefaultIfEmpty();
                    result = rule.JsonStr("ok", "", merchant);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        ///  功能描述：验证密码是否正确
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [MerchantFiter]
        public HttpResponseMessage Ispass(param param)
        {
            string result = string.Empty;
            try
            {

                using (YYPlayContext db = new YYPlayContext())
                {
                    List<tbleMerchant> merchant = (from x in db.tbleMerchant
                                                   where x.fldMaPass == param.pass && x.fldMerchID == param.MerchantID
                                                   select x).ToList();
                    if (merchant.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", true);
                    }
                    else
                    {
                        result = rule.JsonStr("error", "", false);
                    }
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        ///  功能描述：修改密码
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [MerchantFiter]
        public HttpResponseMessage Updatepass(param param)
        {
            string result = string.Empty;
            try
            {

                using (YYPlayContext db = new YYPlayContext())
                {
                    tbleMerchant merchant = (from x in db.tbleMerchant
                                             where x.fldMaPass == param.pass && x.fldMerchID == param.MerchantID
                                             select x).Single();
                    merchant.fldMaPass = param.newpass;
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        result = rule.JsonStr("ok", "", true);
                    }
                    else
                    {
                        result = rule.JsonStr("error", "", false);
                    }
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        ///  功能描述：修改支付密码
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [MerchantFiter]
        public HttpResponseMessage Updatepaypass(param param)
        {
            string result = string.Empty;
            try
            {

                using (YYPlayContext db = new YYPlayContext())
                {
                    tbleMerchant merchant = (from x in db.tbleMerchant
                                             where x.fldPayPass == param.pass && x.fldMerchID == param.MerchantID
                                             select x).Single();
                    merchant.fldPayPass = param.newpass;
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        result = rule.JsonStr("ok", "", true);
                    }
                    else
                    {
                        result = rule.JsonStr("error", "", false);
                    }
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 
        /// </summary>
        public class param
        {

            /// <summary>
            /// 
            /// </summary>
            public string MerchantID { get; set; }


            /// <summary>
            /// 
            /// </summary>
            public string pass { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string newpass { get; set; }
        }
    }
}

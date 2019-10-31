using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.EMCCommon.AccountController.WebApiCore;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace EMCCommon.YYplay
{
    /// <summary>
    /// 冻结 解冻金额
    /// </summary>
    public class FrozenAccountController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：验证支付密码是否正确
        /// 创建时间：2018-12-27
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="paypass"></param>
        /// <returns></returns>
        /// 

        [HttpGet]
        [SupportFilter]
        public HttpResponseMessage VerificationPayPass(string paypass)
        {
            string result = string.Empty;
            try
            {

                using (Model1 context = new Model1())
                {
                    List<tblFW_User> tblFW = (from x in context.tblFW_User
                                        where x.fldDuty == paypass
                                        select x).ToList();
                    if (tblFW.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", "");
                    }
                    else
                    {
                        result = rule.JsonStr("error", "", "");
                    }

                }


            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, " Accountflow", "VerificationPayPass", paypass);
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：冻结金额
        /// 创建时间：2018-12-27
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="prams"></param>
        /// <returns></returns>
        /// 

        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage FrozenAccountDate(pram prams)
        {
            string result = string.Empty;
            try
            {

                using (Model1 context = new Model1())
                {
                    List<tblFW_User> tblFW = (from x in context.tblFW_User
                                              where x.fldDuty == prams.paypass
                                              select x).ToList();
                    //验证支付密码是否正确
                    if (tblFW.Count > 0)
                    {
                        RuleFrozenAccount ruleFrozen = new RuleFrozenAccount();
                        int fldAutoID = 1;
                        DataTable table = ruleFrozen.FrozenAccount(prams.MerchID, prams.Accoun, out fldAutoID);
                        if (fldAutoID == 0)
                        {
                            result = rule.JsonStr("error", "余额不足", fldAutoID);
                        }
                        else
                        {
                            result = rule.JsonStr("ok", "", table);
                        }
                        
                    }
                    else
                    {
                        result = rule.JsonStr("error", "支付密码错误", "");
                    }

                }


            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, " Accountflow", "FrozenAccount", prams.ToString());
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：解冻金额
        /// 创建时间：2018-12-28
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="prams"></param>
        /// <returns></returns>
        /// 

        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage ThawAccountDate(pram prams)
        {
            string result = string.Empty;
            try
            {
                using (Model1 context = new Model1())
                {
                    List<tblFW_User> tblFW = (from x in context.tblFW_User
                                              where x.fldDuty == prams.paypass
                                              select x).ToList();
                    //验证支付密码是否正确
                    if (tblFW.Count > 0)
                    {
                        RuleFrozenAccount ruleFrozen = new RuleFrozenAccount();
                        int fldAutoID = 1;
                        DataTable table = ruleFrozen.ThawAccount(prams.MerchID, prams.Accoun, out fldAutoID);
                        if (fldAutoID == 0)
                        {
                            result = rule.JsonStr("error", "解冻金额大于冻结金额", fldAutoID);
                        }
                        else
                        {
                            result = rule.JsonStr("ok", "", table);
                        }
                    }
                    else
                    {
                        result = rule.JsonStr("error", "支付密码错误", "");
                    }

                }


            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, " Accountflow", "FrozenAccount", prams.ToString());
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 
        /// </summary>
        public class pram {

            /// <summary>
            /// 
            /// </summary>
            public string MerchID { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Accoun { get; set; }

            /// <summary>
            /// 支付密码
            /// </summary>
            public string paypass { get; set; }

         
        }
    }
}

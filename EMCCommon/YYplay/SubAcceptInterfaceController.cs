using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.DateRule;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace EMCCommon.YYplay
{
    /// <summary>
    /// 代付异步通知
    /// </summary>
    public class SubAcceptInterfaceController : ApiController
    {
        RulePayBehavior PayBehavior = new RulePayBehavior();

        RuletblPayfailMessageLog messageLog = new RuletblPayfailMessageLog();
        string Retunr = "";

        SysLogMsg sysLogMsg = new SysLogMsg();

        /// <summary>
        /// 功能描述：再创的代付异步通知
        /// 创建  人：周文卿
        /// 创建时间：2019-03-12
        /// </summary>
        /// <param name="zcpram"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Accept_ZCSub(zcpram zcpram)
        {
            string retext = "error";
            try
            {

                sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sysLogMsg.MerchantId = "";
                sysLogMsg.MethodName = "Accept_ZCSub";
                sysLogMsg.Parameter = JsonHelper.SerializeObject(zcpram);
                sysLogMsg.Content = "再创代付异步";
                Retunr = LogHelp.logMessage(sysLogMsg);
                LogHelp.fatal(Retunr);
                string aa = Request.Content.Headers.ToString();

                RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                //渠道信息

                string fldChannelnum = zcpram.order_no;

                DataSet alldt = ruletbl.selechannebycid(fldChannelnum);
                //渠道信息表
                DataTable dt = alldt.Tables[0];
                //订单表
                DataTable oerderdt = alldt.Tables[1];
                //商户表
                DataTable Merchant = alldt.Tables[2];

                string keystring = zcpram.mch_id + zcpram.order_no + zcpram.money + zcpram.status + dt.Rows[0]["fldUpstreamSecretKey"].ToString();


                //加密字符串
                string sign = PayBehavior.EncryptionMd5(keystring, "x2");

                if (dt.Rows.Count > 0)
                {
                    if (zcpram.sign == sign && oerderdt.Rows[0]["fldStaute"].ToString() != "支付成功")
                    {
                        RuleOldOrdertable ruleOldOrdertable = new RuleOldOrdertable();
                        bool IsSuccess = false;
                        DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "支付成功", out IsSuccess, decimal.Parse(zcpram.money) / 100);
                        if (!IsSuccess)
                        {
                            retext = "error";
                        }
                        else
                        {


                            //写入日志
                            sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sysLogMsg.MerchantId = oerderdt.Rows[0]["fldMerchID"].ToString();
                            sysLogMsg.MethodName = "Accept_ZCSub";
                            sysLogMsg.Parameter = JsonHelper.SerializeObject(zcpram);
                            sysLogMsg.Content = "再创代付异步通知地址";
                            Retunr = LogHelp.logMessage(sysLogMsg);
                            LogHelp.fatal(Retunr);
                            retext = "success";
                        }
                    }
                }


                HttpResponseMessage responseMessage = new HttpResponseMessage { Content = new StringContent(retext, Encoding.GetEncoding("UTF-8"), "text/plain") };
                return responseMessage;
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "SubAcceptInterfaceController", "Accept_ZCSub", "再创代付返回结果解析失败");
            }

        }



        /// <summary>
        /// 功能描述：海付的代付异步通知
        /// 创建  人：周文卿
        /// 创建时间：2019-05-06
        /// </summary>
        /// <param name="zcpram"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Accept_HFSub(zcpram zcpram)
        {
            string retext = "success";
            HttpResponseMessage responseMessage = new HttpResponseMessage { Content = new StringContent(retext, Encoding.GetEncoding("UTF-8"), "text/plain") };
            return responseMessage;

        }

        /// <summary>
        /// 
        /// </summary>
        public class zcpram
        {

            /// <summary>
            /// 
            /// </summary>
            public string mch_id { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string order_no { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string money { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string sign { get; set; }

        }
    }
}

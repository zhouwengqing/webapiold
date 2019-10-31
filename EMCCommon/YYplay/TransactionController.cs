using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using DDYZ.Ensis.Rule.DataRule;
using System.Security.Cryptography;
using EMCCommon.DateRule;
using DDYZ.Ensis.Library.Exception.DataRule;
using EMCCommon.Mode;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DDYZ.Ensis.Presistence.DataEntity;
using System.Threading;
using RestSharp;

namespace EMCCommon.YYplay
{
    /// <summary>
    /// 所有的交易接口
    /// </summary>
    public class TransactionController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        ///  功能描述：H5支付
        ///  创建  人：周文卿
        ///  创建时间：2018-11-20
        /// </summary>
        /// <param name="payparameter">参数</param>
        /// <returns></returns>

        public HttpResponseMessage X_PayH5(payparameter payparameter)
        {
            string result = string.Empty;
            try
            {
                //首先判断商户号是否存在
                RulePayMethod rulePay = new RulePayMethod();
                rerurnpram rerurnpram = rulePay.Islegitimate(payparameter);

                result = rule.JsonStr(rerurnpram.statecode, rerurnpram.message, rerurnpram.data);
                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };


            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, "Transaction", "LB_PayH5", payparameter.ToString());
            }

        }

        /// <summary>
        /// 功能描述：扫码支付接口
        /// 创建  人：周文卿
        /// 创建时间：2019-03-03
        /// </summary>
        /// <param name="payparameter"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage X_ScanCode(payparameter payparameter)
        {
            string result = string.Empty;

            try
            {

                RulePayMethod rulePay = new RulePayMethod();
                rerurnpram rerurnpram = rulePay.Islegitimate(payparameter);

                if (payparameter.PayType == "119" && payparameter.PayType == "104")
                {
                    result = rule.JsonStrCode(rerurnpram.statecode, rerurnpram.message, rerurnpram.data, rerurnpram.urlcode);
                }
                else
                {
                    result = rule.JsonStr(rerurnpram.statecode, rerurnpram.message, rerurnpram.data);
                }

                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };


            }

            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, "Transaction", "LB_ScanCode", payparameter.ToString());
            }
        }


        /// <summary>
        /// 功能描述：代付
        /// 创建  人：周文卿
        /// 创建时间：2018-11-20
        /// </summary>
        /// <param name="payparameter"></param>
        /// <returns></returns>
        public HttpResponseMessage X_PaySub(paysubparameter payparameter)
        {
            string result = string.Empty;
            try
            {
                //首先判断商户号是否存在
                RulePayMethod rulePay = new RulePayMethod();
                rerurnpram rerurnpram = rulePay.Islegitimate(payparameter);

                result = rule.JsonStr(rerurnpram.statecode, rerurnpram.message, rerurnpram.data);
                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };


            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, "Transaction", "LB_PaySub", payparameter.ToString());
            }

        }

        public string subtext()
        {
            string gg = "";
            Thread thread1 = new Thread(() => RuleAgentPayQuery.QueryAgentThend("734641", "X05061527172717AE6549E1E", "177d3003c78892faff27bbe68a88c121", "HF_011"));
                                                                                           
            thread1.Start();
            return gg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Amount"></param>
        /// <param name="PayType"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage testpay(string Amount, string PayType, string key,string MerchantId)
        {
            string result = string.Empty;

            RulePayMethod rulePay = new RulePayMethod();

            payparameter payparameter = new payparameter();

            RulePayBehavior behavior = new RulePayBehavior();



           



            Dictionary<string, string> keys = new Dictionary<string, string>();
            keys.Add("Amount", Amount);
            keys.Add("MerchantId", "100001");
            keys.Add("Notifyurl", "http://120.78.210.41:8066/actionapi/AcceptInterface/testreq");
            keys.Add("OrderID", "tx" + behavior.ram(1000000));
            keys.Add("OrderTime", DateTime.Now.ToString());
            keys.Add("PayType", PayType);
            keys.Add("ProductName", "小商品");
            string sign = behavior.AsciiDesc(keys);

            sign = sign + "key=" + key;

            sign = behavior.EncryptionMd5(sign);

            payparameter.Amount = Amount;
            payparameter.MerchantId = MerchantId;
            payparameter.Notifyurl = "http://120.78.210.41:8066/actionapi/AcceptInterface/testreq";
            payparameter.OrderID = keys["OrderID"];
            payparameter.OrderTime = keys["OrderTime"];
            payparameter.PayType = PayType;
            payparameter.ProductName = "小商品";
            payparameter.Sign = sign;
            rerurnpram rerurnpram = rulePay.Islegitimate(payparameter);

            result = rule.JsonStrCode(rerurnpram.statecode, rerurnpram.message, rerurnpram.data, rerurnpram.urlcode);
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

      
      



    }
}

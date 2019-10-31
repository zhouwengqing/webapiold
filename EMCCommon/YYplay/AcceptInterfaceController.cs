using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.DateRule;
using EMCCommon.Mode;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Threading;
using System.Data.SqlClient;
using System.Text;
using RASencryption;
using System.IO;

namespace EMCCommon.YYplay
{
    /// <summary>
    /// 功能描述：接受各个渠道返回信息
    /// 创建时间：2018-11-26
    /// 创建  人：周文卿
    /// </summary>
    /// 

    public class AcceptInterfaceController : ApiController
    {
        RulePayBehavior PayBehavior = new RulePayBehavior();

        RuletblPayfailMessageLog messageLog = new RuletblPayfailMessageLog();
        string Retunr = "";

        SysLogMsg sysLogMsg = new SysLogMsg();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage testreq()
        {
            string re = "ok";
            SqlParameter[] sqlParas = { new SqlParameter("@time", DateTime.Now), new SqlParameter("@fldindex", "1111"), new SqlParameter("@remark", "11") };
            RuleCommon rule = new RuleCommon();
            rule.RunProcedure_V2("ces", sqlParas.ToList(), "", "YYPlayContext");
            //RulePayRequest rulePayRequest = new RulePayRequest();
            //string rest = rulePayRequest.PostUrl("http://120.78.210.41:8066/actionapi/AcceptInterface/testreq", "{}");
            //if (rest == "ok")
            //    re = "er";
            HttpResponseMessage responseMessage = new HttpResponseMessage { Content = new StringContent(re, Encoding.GetEncoding("UTF-8"), "text/plain") };

            return responseMessage;
        }



        /// <summary>
        /// 功能描述：接收万通返回的支付信息
        /// 创建  人：周文卿
        /// 创建时间：2019-2-22
        /// </summary>
        /// <param name="pram"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public string Accept_QJ(QJPram pram)
        {
            string retext = "error";
            try
            {

                string transdata = HttpUtility.UrlDecode(pram.transdata);

                //得到的参数装换成Dictionary
                Dictionary<string, string> notify_Msg = JsonHelper.DeserializeStringToDictionary<string, string>(transdata);

                RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                //渠道信息

                string fldChannelnum = notify_Msg["order_no"].ToString();

                DataSet alldt = ruletbl.selechannebycid(fldChannelnum);
                //渠道信息表
                DataTable dt = alldt.Tables[0];
                //订单表
                DataTable oerderdt = alldt.Tables[1];
                //商户表
                DataTable Merchant = alldt.Tables[2];
                //&& oerderdt.Rows[0]["fldStaute"].ToString() != "支付成功"
                if (dt.Rows.Count > 0 && oerderdt.Rows[0]["fldStaute"].ToString() != "支付成功")
                {

                    string ascdict = PayBehavior.AsciiDesc(notify_Msg);
                    ascdict += "key=" + dt.Rows[0]["fldUpstreamSecretKey"].ToString();////判断签名是否正确
                    string sign = PayBehavior.EncryptionMd5(ascdict);
                    if (pram.sign == sign)
                    {
                        RuleOldOrdertable ruleOldOrdertable = new RuleOldOrdertable();
                        bool IsSuccess = false;
                        DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "支付成功", out IsSuccess, decimal.Parse(notify_Msg["order_amount"].ToString()));
                        if (!IsSuccess)
                        {
                            retext = "error";
                        }
                        else
                        {
                            //异步通知 下游
                            string prams = "";
                            AsynParameterPay asyn = new AsynParameterPay();
                            asyn.MerchantId = oerderdt.Rows[0]["fldMerchID"].ToString();
                            asyn.OrderID = oerderdt.Rows[0]["fldOrdernum"].ToString();
                            asyn.Amount = oerderdt.Rows[0]["fldOrderAmount"].ToString();
                            asyn.OrderTime = oerderdt.Rows[0]["fldCreatetime"].ToString();
                            asyn.Paytype = oerderdt.Rows[0]["fldRateName"].ToString();
                            asyn.ProductName = oerderdt.Rows[0]["fldOrederdetailed"].ToString();
                            asyn.Paystate = "支付成功";


                            string getpram = JsonHelper.SerializeObject(asyn);
                            //json 转换成Dictionary
                            Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
                            //排序
                            RulePayBehavior behavior = new RulePayBehavior();
                            string pxrams = behavior.AsciiDesc(valuePairs);
                            //添加key值
                            pxrams += "key=" + Merchant.Rows[0]["fldSecretKey"].ToString();
                            //md5加密
                            string signkey = behavior.EncryptionMd5(pxrams);

                            asyn.Sign = signkey;

                            //转换成json 格式
                            prams = JsonHelper.SerializeObject(asyn);

                            RulePayRequest rulePayRequest = new RulePayRequest();
                            string rest = rulePayRequest.PostUrl(oerderdt.Rows[0]["fldNotice"].ToString(), prams);
                            //没接收到通知 开启线程  循环通知 五次 
                            if (rest != "ok")
                            {
                                Thread thread1 = new Thread(() => Notifyurl.myThread(oerderdt.Rows[0]["fldMerchID"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), oerderdt.Rows[0]["fldOrderAmount"].ToString(), oerderdt.Rows[0]["fldCreatetime"].ToString(), oerderdt.Rows[0]["fldRateName"].ToString(), oerderdt.Rows[0]["fldOrederdetailed"].ToString(), oerderdt.Rows[0]["fldNotice"].ToString(), Merchant.Rows[0]["fldSecretKey"].ToString()));
                                thread1.Start();
                            }


                            retext = "ok";
                        }
                    }

                }
                return retext;
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "AcceptInterfaceController", "Accept_QJ", "万通返回结果解析失败");
            }

        }




        /// <summary>
        /// 功能描述：接受锐支付的返回通知
        /// 创建  人：周文卿
        /// 创建时间：2019-03-06
        /// </summary>
        /// <param name="ruipram"></param>

        /// <returns></returns>
        [HttpPost]
        public string Accept_RUI(ruipram ruipram)
        {
            string retext = "error";
            try
            {
                string publickeys = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDAwqs0V3INIADNtrYwl7qCKlmR7uMP64mklgLB6SOiFLDSzO0g9QSKPZrDmmnZ/BQy8rNSxedE9S1VwKKEgQLel3jFqFtR6vn3U3YcLuIpVkng1c0A1IKrEF+UivMojbEValYiPzEXnD5qFeDZzU+S6rsiZgBygZgkgM4QRl4omQIDAQAB";

                RulePayBehavior PayBehavior = new RulePayBehavior();

                Dictionary<string, string> dic = new Dictionary<string, string>();

                dic.Add("mno", ruipram.mno);
                dic.Add("s_orderno", ruipram.s_orderno);
                dic.Add("orderno", ruipram.orderno);
                dic.Add("status", ruipram.status);
                dic.Add("amount", ruipram.amount);
                dic.Add("paytime", ruipram.paytime);

                string strsign = PayBehavior.GetParamsStr(dic);

                string xmlpublicKey = RSAExtensions.RSAPublicKeyJava2DotNet(publickeys);
                string sign1 = RSAUtil.PublicKeyDecrypt(xmlpublicKey, ruipram.sign);


                RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                //渠道信息

                string fldChannelnum = ruipram.orderno;

                DataSet alldt = ruletbl.selechannebycid(fldChannelnum);
                //渠道信息表
                DataTable dt = alldt.Tables[0];
                //订单表
                DataTable oerderdt = alldt.Tables[1];
                //商户表
                DataTable Merchant = alldt.Tables[2];
                //重复通知查询
                if (dt.Rows.Count > 0 && oerderdt.Rows[0]["fldStaute"].ToString() != "支付成功")
                {

                    if (sign1 == strsign && ruipram.status == "1")
                    {
                        RuleOldOrdertable ruleOldOrdertable = new RuleOldOrdertable();
                        bool IsSuccess = false;
                        DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "支付成功", out IsSuccess, decimal.Parse(ruipram.amount) / 100);
                        if (!IsSuccess)
                        {
                            retext = "error";
                        }
                        else
                        {
                            //异步通知 下游
                            string prams = "";
                            AsynParameterPay asyn = new AsynParameterPay();
                            asyn.MerchantId = oerderdt.Rows[0]["fldMerchID"].ToString();
                            asyn.OrderID = oerderdt.Rows[0]["fldOrdernum"].ToString();
                            asyn.Amount = oerderdt.Rows[0]["fldOrderAmount"].ToString();
                            asyn.OrderTime = oerderdt.Rows[0]["fldchangstautetime"].ToString();
                            asyn.Paytype = oerderdt.Rows[0]["fldRateName"].ToString();
                            asyn.ProductName = oerderdt.Rows[0]["fldOrederdetailed"].ToString();
                            asyn.Paystate = "支付成功";


                            string getpram = JsonHelper.SerializeObject(asyn);
                            //json 转换成Dictionary
                            Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
                            //排序
                            RulePayBehavior behavior = new RulePayBehavior();
                            string pxrams = behavior.AsciiDesc(valuePairs);
                            //添加key值
                            pxrams += "key=" + Merchant.Rows[0]["fldSecretKey"].ToString();
                            //md5加密
                            string signkey = behavior.EncryptionMd5(pxrams);

                            asyn.Sign = signkey;

                            //转换成json 格式
                            prams = JsonHelper.SerializeObject(asyn);

                            RulePayRequest rulePayRequest = new RulePayRequest();
                            string rest = rulePayRequest.PostUrl(oerderdt.Rows[0]["fldNotice"].ToString(), prams);

                            //写入日志
                            sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sysLogMsg.MerchantId = asyn.MerchantId;
                            sysLogMsg.MethodName = "Accept_RUI";
                            sysLogMsg.Parameter = prams;
                            sysLogMsg.Content = "通知下游参数";
                            Retunr = LogHelp.logMessage(sysLogMsg);
                            LogHelp.Info(Retunr);

                            //没接收到通知 开启线程  循环通知 五次 
                            if (rest != "ok")
                            {
                                messageLog.inserttblPayfailMessageLog("瑞支付", "A190319160935882", prams, oerderdt.Rows[0]["fldNotice"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), DateTime.Now, prams);
                                Thread thread1 = new Thread(() => Notifyurl.myThread(oerderdt.Rows[0]["fldMerchID"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), oerderdt.Rows[0]["fldOrderAmount"].ToString(), oerderdt.Rows[0]["fldtransactiontime"].ToString(), oerderdt.Rows[0]["fldRateName"].ToString(), oerderdt.Rows[0]["fldOrederdetailed"].ToString(), oerderdt.Rows[0]["fldNotice"].ToString(), Merchant.Rows[0]["fldSecretKey"].ToString()));
                                thread1.Start();
                            }


                            retext = "success";
                        }
                    }

                }
                return retext;
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "AcceptInterfaceController", "Accept_RUI", "锐支付返回结果解析失败");
            }

        }





        /// <summary>
        /// 功能描述：汇通的异步通知
        /// 创建  人：周文卿
        /// 创建时间：2019-03-12
        /// </summary>
        /// <param name="htpram"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Accept_HT(htpram htpram)
        {
            string retext = "error";
            try
            {
                string aa = Request.Content.Headers.ToString();

                Dictionary<string, string> dic = new Dictionary<string, string>();


                dic.Add("MerNo", htpram.MerNo);
                dic.Add("TxSN", htpram.TxSN);
                dic.Add("PdtName", htpram.PdtName);
                dic.Add("Amount", htpram.Amount);
                dic.Add("Status", htpram.Status);
                dic.Add("PlatTxSN", htpram.PlatTxSN);
                dic.Add("PayFee", htpram.PayFee);
                dic.Add("PlatTxMsg", htpram.PlatTxMsg);
                dic.Add("BankTxSN", htpram.BankTxSN);
                //验证签名 
                string[] arrKeynew = dic.Keys.ToArray();
                String[] base64Keys = new String[] { "CodeUrl", "ImgUrl", "Token_Id", "PayInfo", "sPayUrl", "PayUrl", "NotifyUrl", "ReturnUrl" };
                for (int i = 0; i < arrKeynew.Length; i++)
                {
                    //对所有的值值 进行 UrlDecode
                    dic[arrKeynew[i].ToString()] = Utils.UrlDecode(dic[arrKeynew[i].ToString()].ToString());
                    //对特殊参数先进行把其中的”%2b”替换为“+”然后 Base64解码
                    for (int j = 0; j < base64Keys.Length; j++)
                    {
                        if (arrKeynew[i].ToString() == base64Keys[j].ToString())
                        {
                            string value = dic[arrKeynew[i].ToString()].ToString().Replace("%2b", "+");
                            byte[] bytes = Convert.FromBase64String(value);
                            string uec = Encoding.GetEncoding("utf-8").GetString(bytes);
                            dic[arrKeynew[i].ToString()] = uec;
                        }
                    }

                }

                RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                //渠道信息

                string fldChannelnum = htpram.TxSN;

                DataSet alldt = ruletbl.selechannebycid(fldChannelnum);
                //渠道信息表
                DataTable dt = alldt.Tables[0];
                //订单表
                DataTable oerderdt = alldt.Tables[1];
                //商户表
                DataTable Merchant = alldt.Tables[2];


                //排序
                string paixu = PayBehavior.AsciiDesc(dic).TrimEnd('&');
                //排序后的字符串加上key
                paixu = paixu + dt.Rows[0]["fldUpstreamSecretKey"].ToString(); ;
                //加密字符串
                string sign = PayBehavior.EncryptionMd5(paixu, "x2");

                if (htpram.Signature == sign && oerderdt.Rows[0]["fldStaute"].ToString() != "支付成功")
                {
                    RuleOldOrdertable ruleOldOrdertable = new RuleOldOrdertable();
                    bool IsSuccess = false;
                    DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "支付成功", out IsSuccess, decimal.Parse(htpram.Amount) / 100);
                    if (!IsSuccess)
                    {
                        retext = "error";
                    }
                    else
                    {
                        //异步通知 下游
                        string prams = "";
                        AsynParameterPay asyn = new AsynParameterPay();
                        asyn.MerchantId = oerderdt.Rows[0]["fldMerchID"].ToString();
                        asyn.OrderID = oerderdt.Rows[0]["fldOrdernum"].ToString();
                        asyn.Amount = oerderdt.Rows[0]["fldOrderAmount"].ToString();
                        asyn.OrderTime = oerderdt.Rows[0]["fldMerchID"].ToString();
                        asyn.Paytype = oerderdt.Rows[0]["fldRateName"].ToString();
                        asyn.ProductName = oerderdt.Rows[0]["fldOrederdetailed"].ToString();
                        asyn.Paystate = "支付成功";


                        string getpram = JsonHelper.SerializeObject(asyn);
                        //json 转换成Dictionary
                        Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
                        //排序
                        RulePayBehavior behavior = new RulePayBehavior();
                        string pxrams = behavior.AsciiDesc(valuePairs);
                        //添加key值
                        pxrams += "key=" + Merchant.Rows[0]["fldSecretKey"].ToString();
                        //md5加密
                        string signkey = behavior.EncryptionMd5(pxrams);

                        asyn.Sign = signkey;

                        //转换成json 格式
                        prams = JsonHelper.SerializeObject(asyn);

                        RulePayRequest rulePayRequest = new RulePayRequest();
                        string rest = rulePayRequest.PostUrl(oerderdt.Rows[0]["fldNotice"].ToString(), prams);

                        //写入日志
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = asyn.MerchantId;
                        sysLogMsg.MethodName = "Accept_HT";
                        sysLogMsg.Parameter = prams;
                        sysLogMsg.Content = "通知下游参数";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.Info(Retunr);

                        //没接收到通知 开启线程  循环通知 五次 
                        if (rest != "ok")
                        {
                            Thread thread1 = new Thread(() => Notifyurl.myThread(oerderdt.Rows[0]["fldMerchID"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), oerderdt.Rows[0]["fldOrderAmount"].ToString(), oerderdt.Rows[0]["fldtransactiontime"].ToString(), oerderdt.Rows[0]["fldRateName"].ToString(), oerderdt.Rows[0]["fldOrederdetailed"].ToString(), oerderdt.Rows[0]["fldNotice"].ToString(), Merchant.Rows[0]["fldSecretKey"].ToString()));
                            thread1.Start();
                        }


                        retext = "success";
                    }
                }

                HttpResponseMessage responseMessage = new HttpResponseMessage { Content = new StringContent(retext, Encoding.GetEncoding("UTF-8"), "text/plain") };
                return responseMessage;
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "AcceptInterfaceController", "Accept_RUI", "锐支付返回结果解析失败");
            }

        }


        /// <summary>
        /// 功能描述：再创的异步通知
        /// 创建  人：周文卿
        /// 创建时间：2019-03-12
        /// </summary>
        /// <param name="zcpram"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Accept_ZC(zcpram zcpram)
        {
            string retext = "error";
            try
            {
                string aa = Request.Content.Headers.ToString();

                RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                //渠道信息

                string fldChannelnum = zcpram.order_number;

                DataSet alldt = ruletbl.selechannebycid(fldChannelnum);
                //渠道信息表
                DataTable dt = alldt.Tables[0];
                //订单表
                DataTable oerderdt = alldt.Tables[1];
                //商户表
                DataTable Merchant = alldt.Tables[2];

                string keystring = zcpram.mch_id + zcpram.order_number + zcpram.pay_money + zcpram.pay_status + dt.Rows[0]["fldUpstreamSecretKey"].ToString();


                //加密字符串
                string sign = PayBehavior.EncryptionMd5(keystring, "x2");

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
                        //异步通知 下游
                        string prams = "";
                        AsynParameterPay asyn = new AsynParameterPay();
                        asyn.MerchantId = oerderdt.Rows[0]["fldMerchID"].ToString();
                        asyn.OrderID = oerderdt.Rows[0]["fldOrdernum"].ToString();
                        asyn.Amount = oerderdt.Rows[0]["fldOrderAmount"].ToString();
                        asyn.OrderTime = oerderdt.Rows[0]["fldchangstautetime"].ToString(); ;
                        asyn.Paytype = oerderdt.Rows[0]["fldRateName"].ToString();
                        asyn.ProductName = oerderdt.Rows[0]["fldOrederdetailed"].ToString();
                        asyn.Paystate = "支付成功";


                        string getpram = JsonHelper.SerializeObject(asyn);
                        //json 转换成Dictionary
                        Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
                        //排序
                        RulePayBehavior behavior = new RulePayBehavior();
                        string pxrams = behavior.AsciiDesc(valuePairs);
                        //添加key值
                        pxrams += "key=" + Merchant.Rows[0]["fldSecretKey"].ToString();
                        //md5加密
                        string signkey = behavior.EncryptionMd5(pxrams);

                        asyn.Sign = signkey;

                        //转换成json 格式
                        prams = JsonHelper.SerializeObject(asyn);

                        RulePayRequest rulePayRequest = new RulePayRequest();
                        string rest = rulePayRequest.PostUrl(oerderdt.Rows[0]["fldNotice"].ToString(), prams);

                        //写入日志
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = asyn.MerchantId;
                        sysLogMsg.MethodName = "Accept_ZC";
                        sysLogMsg.Parameter = prams;
                        sysLogMsg.Content = "通知下游参数";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.Info(Retunr);

                        //没接收到通知 开启线程  循环通知 五次 
                        if (rest != "ok")
                        {
                            messageLog.inserttblPayfailMessageLog("再创支付", "10783", prams, oerderdt.Rows[0]["fldNotice"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), DateTime.Now, prams);
                            Thread thread1 = new Thread(() => Notifyurl.myThread(oerderdt.Rows[0]["fldMerchID"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), oerderdt.Rows[0]["fldOrderAmount"].ToString(), oerderdt.Rows[0]["fldtransactiontime"].ToString(), oerderdt.Rows[0]["fldRateName"].ToString(), oerderdt.Rows[0]["fldOrederdetailed"].ToString(), oerderdt.Rows[0]["fldNotice"].ToString(), Merchant.Rows[0]["fldSecretKey"].ToString()));
                            thread1.Start();
                        }


                        retext = "successed";
                    }
                }

                HttpResponseMessage responseMessage = new HttpResponseMessage { Content = new StringContent(retext, Encoding.GetEncoding("UTF-8"), "text/plain") };
                return responseMessage;
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "AcceptInterfaceController", "Accept_RUI", "锐支付返回结果解析失败");
            }

        }

        /// <summary>
        /// 功能描述：无名的异步通知
        /// 创建  人：周文卿
        /// 创建时间：2019-04-23
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpPost]
        public HttpResponseMessage Accept_WM()
        {
            HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
            HttpRequestBase request = context.Request;//定义传统request对象
            string retext = "error";
            try
            {
                string aa = Request.Content.Headers.ToString();

                RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                //渠道信息

                string fldChannelnum = request["out_trade_no"].ToString();

                DataSet alldt = ruletbl.selechannebycid(fldChannelnum);
                //渠道信息表
                DataTable dt = alldt.Tables[0];
                //订单表
                DataTable oerderdt = alldt.Tables[1];
                //商户表
                DataTable Merchant = alldt.Tables[2];

                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("mno", request["mno"].ToString());
                pairs.Add("out_trade_no", request["out_trade_no"].ToString());
                pairs.Add("total_fee", request["total_fee"].ToString());
                pairs.Add("transaction_id", request["transaction_id"].ToString());
                pairs.Add("pay_type", request["pay_type"].ToString());
                pairs.Add("pay_time", request["pay_time"].ToString());
                string strsign = PayBehavior.AsciiDesc(pairs).TrimEnd('&');

                string keystring = strsign + dt.Rows[0]["fldUpstreamSecretKey"].ToString();

                //加密字符串
                string sign = PayBehavior.EncryptionMd5(keystring, "x2");

                if (request["sign"].ToString() == sign && oerderdt.Rows[0]["fldStaute"].ToString() != "支付成功")
                {
                    RuleOldOrdertable ruleOldOrdertable = new RuleOldOrdertable();
                    bool IsSuccess = false;
                    DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "支付成功", out IsSuccess, decimal.Parse(request["total_fee"].ToString()));
                    if (!IsSuccess)
                    {
                        retext = "error";
                    }
                    else
                    {
                        //异步通知 下游
                        string prams = "";
                        AsynParameterPay asyn = new AsynParameterPay();
                        asyn.MerchantId = oerderdt.Rows[0]["fldMerchID"].ToString();
                        asyn.OrderID = oerderdt.Rows[0]["fldOrdernum"].ToString();
                        asyn.Amount = oerderdt.Rows[0]["fldOrderAmount"].ToString();
                        asyn.OrderTime = oerderdt.Rows[0]["fldMerchID"].ToString();
                        asyn.Paytype = oerderdt.Rows[0]["fldRateName"].ToString();
                        asyn.ProductName = oerderdt.Rows[0]["fldOrederdetailed"].ToString();
                        asyn.Paystate = "支付成功";


                        string getpram = JsonHelper.SerializeObject(asyn);
                        //json 转换成Dictionary
                        Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
                        //排序
                        RulePayBehavior behavior = new RulePayBehavior();
                        string pxrams = behavior.AsciiDesc(valuePairs);
                        //添加key值
                        pxrams += "key=" + Merchant.Rows[0]["fldSecretKey"].ToString();
                        //md5加密
                        string signkey = behavior.EncryptionMd5(pxrams);

                        asyn.Sign = signkey;

                        //转换成json 格式
                        prams = JsonHelper.SerializeObject(asyn);

                        RulePayRequest rulePayRequest = new RulePayRequest();
                        string rest = rulePayRequest.PostUrl(oerderdt.Rows[0]["fldNotice"].ToString(), prams);

                        //写入日志
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = asyn.MerchantId;
                        sysLogMsg.MethodName = "Accept_WM";
                        sysLogMsg.Parameter = prams;
                        sysLogMsg.Content = "通知下游参数";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.Info(Retunr);

                        //没接收到通知 开启线程  循环通知 五次 
                        if (rest != "ok")
                        {
                            messageLog.inserttblPayfailMessageLog("无名", "114", prams, oerderdt.Rows[0]["fldNotice"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), DateTime.Now, prams);
                            Thread thread1 = new Thread(() => Notifyurl.myThread(oerderdt.Rows[0]["fldMerchID"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), oerderdt.Rows[0]["fldOrderAmount"].ToString(), oerderdt.Rows[0]["fldtransactiontime"].ToString(), oerderdt.Rows[0]["fldRateName"].ToString(), oerderdt.Rows[0]["fldOrederdetailed"].ToString(), oerderdt.Rows[0]["fldNotice"].ToString(), Merchant.Rows[0]["fldSecretKey"].ToString()));
                            thread1.Start();
                        }


                        retext = "success";
                    }
                }

                HttpResponseMessage responseMessage = new HttpResponseMessage { Content = new StringContent(retext, Encoding.GetEncoding("UTF-8"), "text/plain") };
                return responseMessage;
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "AcceptInterfaceController", "Accept_RUI", "锐支付返回结果解析失败");
            }

        }



        /// <summary>
        /// 功能描述：亿点的异步通知
        /// 创建  人：周文卿
        /// 创建时间：2019-04-28
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpPost]
        public HttpResponseMessage Accept_YD()
        {

            string retext = "error";
            try
            {
                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
                HttpRequestBase request = context.Request;//定义传统request对象




                RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                //渠道信息

                string fldChannelnum = request["orderNum"].ToString();

                DataSet alldt = ruletbl.selechannebycid(fldChannelnum);
                //渠道信息表
                DataTable dt = alldt.Tables[0];
                //订单表
                DataTable oerderdt = alldt.Tables[1];
                //商户表
                DataTable Merchant = alldt.Tables[2];

                string[] listkey = new string[] { "merchantNum", "orderNum", "amount", "nonce_str", "orderStatus" };



                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("merchantNum", request["merchantNum"].ToString());
                pairs.Add("orderNum", request["orderNum"].ToString());
                pairs.Add("amount", request["amount"].ToString());
                pairs.Add("nonce_str", request["nonce_str"].ToString());
                pairs.Add("orderStatus", request["orderStatus"].ToString());


                string ascdict = "";
                foreach (string item in listkey)
                {

                    ascdict += item + "=" + pairs[item] + "&";
                }

                string keystring = ascdict + "key=" + dt.Rows[0]["fldUpstreamSecretKey"].ToString();

                //加密字符串
                string sign = PayBehavior.EncryptionMd5(keystring);

                if (request["sign"].ToString() == sign && oerderdt.Rows[0]["fldStaute"].ToString() != "支付成功" && request["orderStatus"].ToString() == "SUCCESS")
                {
                    RuleOldOrdertable ruleOldOrdertable = new RuleOldOrdertable();
                    bool IsSuccess = false;
                    DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "支付成功", out IsSuccess, decimal.Parse(request["amount"].ToString()) / 100);
                    if (!IsSuccess)
                    {
                        retext = "error";
                    }
                    else
                    {
                        //异步通知 下游
                        string prams = "";
                        AsynParameterPay asyn = new AsynParameterPay();
                        asyn.MerchantId = oerderdt.Rows[0]["fldMerchID"].ToString();
                        asyn.OrderID = oerderdt.Rows[0]["fldOrdernum"].ToString();
                        asyn.Amount = oerderdt.Rows[0]["fldOrderAmount"].ToString();
                        asyn.OrderTime = oerderdt.Rows[0]["fldchangstautetime"].ToString(); ;
                        asyn.Paytype = oerderdt.Rows[0]["fldRateName"].ToString();
                        asyn.ProductName = oerderdt.Rows[0]["fldOrederdetailed"].ToString();
                        asyn.Paystate = "支付成功";


                        string getpram = JsonHelper.SerializeObject(asyn);
                        //json 转换成Dictionary
                        Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
                        //排序
                        RulePayBehavior behavior = new RulePayBehavior();
                        string pxrams = behavior.AsciiDesc(valuePairs);
                        //添加key值
                        pxrams += "key=" + Merchant.Rows[0]["fldSecretKey"].ToString();
                        //md5加密
                        string signkey = behavior.EncryptionMd5(pxrams);

                        asyn.Sign = signkey;

                        //转换成json 格式
                        prams = JsonHelper.SerializeObject(asyn);

                        //写入日志
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = asyn.MerchantId;
                        sysLogMsg.MethodName = "Accept_YD";
                        sysLogMsg.Parameter = prams;
                        sysLogMsg.Content = "通知下游参数";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.Info(Retunr);

                        RulePayRequest rulePayRequest = new RulePayRequest();
                        string rest = rulePayRequest.PostUrl(oerderdt.Rows[0]["fldNotice"].ToString(), prams);



                        //没接收到通知 开启线程  循环通知 五次 
                        if (rest != "ok")
                        {
                            messageLog.inserttblPayfailMessageLog("亿点", "888017", prams, oerderdt.Rows[0]["fldNotice"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), DateTime.Now, prams);
                            Thread thread1 = new Thread(() => Notifyurl.myThread(oerderdt.Rows[0]["fldMerchID"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), oerderdt.Rows[0]["fldOrderAmount"].ToString(), oerderdt.Rows[0]["fldtransactiontime"].ToString(), oerderdt.Rows[0]["fldRateName"].ToString(), oerderdt.Rows[0]["fldOrederdetailed"].ToString(), oerderdt.Rows[0]["fldNotice"].ToString(), Merchant.Rows[0]["fldSecretKey"].ToString()));
                            thread1.Start();
                        }


                        retext = "SUCCESS";
                    }
                }

                HttpResponseMessage responseMessage = new HttpResponseMessage { Content = new StringContent(retext, Encoding.GetEncoding("UTF-8"), "text/plain") };
                return responseMessage;
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "AcceptInterfaceController", "Accept_YD", "亿点支付返回结果解析失败");
            }

        }


        /// <summary>
        /// 功能描述：海付的异步通知
        /// 创建  人：周文卿
        /// 创建时间：2019-04-30
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpPost]
        public HttpResponseMessage Accept_HF(hfpram hfpram)
        {

            string retext = "error";
            try
            {

                RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                //渠道信息

                string fldChannelnum = hfpram.pay_number;

                DataSet alldt = ruletbl.selechannebycid(fldChannelnum);
                //渠道信息表
                DataTable dt = alldt.Tables[0];
                //订单表
                DataTable oerderdt = alldt.Tables[1];
                //商户表
                DataTable Merchant = alldt.Tables[2];

                if (dt.Rows.Count > 0)
                {
                    //需要参加签名的字段
                    string[] listkey = new string[] { "amount", "gallery_number", "orderId", "pay_number", "respCode", "respInfo", "status" };

                    string jsonstring = JsonHelper.SerializeObject(hfpram);



                    //json 转换成Dictionary
                    Dictionary<string, string> valuePairs2 = JsonHelper.DeserializeStringToDictionary<string, string>(jsonstring);

                    //定义一个需要签名的字典
                    Dictionary<string, string> newsign = new Dictionary<string, string>();

                    string ascdict = "";
                    foreach (string item in listkey)
                    {

                        newsign.Add(item, valuePairs2[item].ToString());
                    }

                    ascdict = PayBehavior.AsciiDesc(newsign);

                    string keystring = ascdict + "key=" + dt.Rows[0]["fldUpstreamSecretKey"].ToString();

                    //加密字符串
                    string sign = PayBehavior.EncryptionMd5(keystring, "x2");

                    if (hfpram.sign == sign && oerderdt.Rows[0]["fldStaute"].ToString() != "支付成功" && hfpram.status == "TRADE_SUCCESS")
                    {
                        RuleOldOrdertable ruleOldOrdertable = new RuleOldOrdertable();
                        bool IsSuccess = false;
                        DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "支付成功", out IsSuccess, decimal.Parse(hfpram.amount));
                        if (!IsSuccess)
                        {
                            retext = "error";
                        }
                        else
                        {
                            //异步通知 下游
                            string prams = "";
                            AsynParameterPay asyn = new AsynParameterPay();
                            asyn.MerchantId = oerderdt.Rows[0]["fldMerchID"].ToString();
                            asyn.OrderID = oerderdt.Rows[0]["fldOrdernum"].ToString();
                            asyn.Amount = oerderdt.Rows[0]["fldOrderAmount"].ToString();
                            asyn.OrderTime = oerderdt.Rows[0]["fldchangstautetime"].ToString(); ;
                            asyn.Paytype = oerderdt.Rows[0]["fldRateName"].ToString();
                            asyn.ProductName = oerderdt.Rows[0]["fldOrederdetailed"].ToString();
                            asyn.Paystate = "支付成功";


                            string getpram = JsonHelper.SerializeObject(asyn);
                            //json 转换成Dictionary
                            Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
                            //排序
                            RulePayBehavior behavior = new RulePayBehavior();
                            string pxrams = behavior.AsciiDesc(valuePairs);
                            //添加key值
                            pxrams += "key=" + Merchant.Rows[0]["fldSecretKey"].ToString();
                            //md5加密
                            string signkey = behavior.EncryptionMd5(pxrams);

                            asyn.Sign = signkey;

                            //转换成json 格式
                            prams = JsonHelper.SerializeObject(asyn);

                            //写入日志
                            sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sysLogMsg.MerchantId = asyn.MerchantId;
                            sysLogMsg.MethodName = "Accept_HF";
                            sysLogMsg.Parameter = prams;
                            sysLogMsg.Content = "通知下游参数";
                            Retunr = LogHelp.logMessage(sysLogMsg);
                            LogHelp.Info(Retunr);




                            RulePayRequest rulePayRequest = new RulePayRequest();
                            string rest = rulePayRequest.PostUrl(oerderdt.Rows[0]["fldNotice"].ToString(), prams);
                           

                            //没接收到通知 开启线程  循环通知 五次 
                            if (rest != "ok")
                            {
                                messageLog.inserttblPayfailMessageLog("海付", "734641", prams, oerderdt.Rows[0]["fldNotice"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), DateTime.Now, prams);
                                Thread thread1 = new Thread(() => Notifyurl.myThread(oerderdt.Rows[0]["fldMerchID"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), oerderdt.Rows[0]["fldOrderAmount"].ToString(), oerderdt.Rows[0]["fldtransactiontime"].ToString(), oerderdt.Rows[0]["fldRateName"].ToString(), oerderdt.Rows[0]["fldOrederdetailed"].ToString(), oerderdt.Rows[0]["fldNotice"].ToString(), Merchant.Rows[0]["fldSecretKey"].ToString()));
                                thread1.Start();
                            }


                            retext = "success";
                        }
                    }
                }

              




                HttpResponseMessage responseMessage = new HttpResponseMessage { Content = new StringContent(retext, Encoding.GetEncoding("UTF-8"), "text/plain") };
                return responseMessage;
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "AcceptInterfaceController", "Accept_HF", "海付支付返回结果解析失败");
            }

        }


        /// <summary>
        /// 海付参数
        /// </summary>
        public class hfpram
        {
            // <summary>
            /// 
            /// </summary>
            public string orderId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string amount { get; set; }

            // <summary>
            /// 
            /// </summary>
            public string pay_number { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string sign { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string respCode { get; set; }

            // <summary>
            /// 
            /// </summary>
            public string respInfo { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string gallery_number { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }
        }


        /// <summary>
        /// 
        /// </summary>
        public class ruipram
        {
            // <summary>
            /// 
            /// </summary>
            public string mno { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string s_orderno { get; set; }

            // <summary>
            /// 
            /// </summary>
            public string orderno { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string amount { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }

            // <summary>
            /// 
            /// </summary>
            public string paytime { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string sign { get; set; }
        }

        /// <summary>
        /// 汇通的参数
        /// </summary>
        public class htpram
        {

            /// <summary>
            /// 
            /// </summary>
            public string MerNo { get; set; }
            public string TxSN { get; set; }

            public string Amount { get; set; }
            public string PdtName { get; set; }
            public string Status { get; set; }
            public string PlatTxSN { get; set; }
            public string PlatTxMsg { get; set; }
            public string BankTxSN { get; set; }
            public string PayFee { get; set; }
            public string SignMethod { get; set; }
            public string Signature { get; set; }

        }

        /// <summary>
        /// 再创支付参数
        /// </summary>
        public class zcpram
        {

            /// <summary>
            /// 商户号
            /// </summary>
            public string mch_id { get; set; }

            /// <summary>
            /// 订单号
            /// </summary>
            public string order_number { get; set; }

            /// <summary>
            /// 订单金额
            /// </summary>
            public string money { get; set; }

            /// <summary>
            /// 实际支付金额
            /// </summary>
            public string pay_money { get; set; }

            /// <summary>
            /// 支付状态
            /// </summary>

            public string pay_status { get; set; }

            /// <summary>
            /// 签名
            /// </summary>
            public string sign { get; set; }
        }



        /// <summary>
        /// 功能描述：接收万通返回的代付信息
        /// 创建  人：周文卿
        /// 创建时间：2019-2-22
        /// </summary>
        /// <param name="pram"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public string Accept_QJSub(QJPram pram)
        {
            string retext = "error";
            try
            {

                string transdata = HttpUtility.UrlDecode(pram.transdata);

                //得到的参数装换成Dictionary
                Dictionary<string, string> notify_Msg = JsonHelper.DeserializeStringToDictionary<string, string>(transdata);

                RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                //渠道信息

                string fldChannelnum = notify_Msg["order_no"].ToString();

                DataSet alldt = ruletbl.selechannebycidsub(fldChannelnum);
                //渠道信息表
                DataTable dt = alldt.Tables[0];
                //订单表
                DataTable oerderdt = alldt.Tables[1];
                //商户表
                DataTable Merchant = alldt.Tables[2];

                string passstate = "";
                //&& oerderdt.Rows[0]["fldStaute"].ToString() != "支付成功"
                if (dt.Rows.Count > 0)
                {

                    string ascdict = PayBehavior.AsciiDesc(notify_Msg);
                    ascdict += "key=" + dt.Rows[0]["fldUpstreamSecretKey"].ToString();////判断签名是否正确
                    string sign = PayBehavior.EncryptionMd5(ascdict);

                    if (pram.sign == sign)
                    {
                        //判断是否代付成功
                        if (notify_Msg["resp_code"].ToString() == "S")
                        {
                            RuletblAgentPay ruleOldOrdertable = new RuletblAgentPay();
                            bool IsSuccess = false;
                            DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "代付成功", out IsSuccess, decimal.Parse(notify_Msg["order_amount"].ToString()));
                            if (!IsSuccess)
                            {
                                retext = "error";
                            }
                            else
                            {

                                retext = "ok";
                            }
                        }
                        else
                        {
                            RuleCommon rule = new RuleCommon();
                            rule.getdt("update tblAgentPay set fldPayState='异常' where fldChannelnum in ('" + fldChannelnum + "')");
                        }
                        switch (notify_Msg["resp_code"].ToString())
                        {
                            case "S":
                                passstate = "支付成功";
                                break;
                            case "F":
                                passstate = "代付失败";
                                break;
                            case "P":
                                passstate = "处理中";
                                break;
                        }

                        //异步通知 下游
                        AsynParameterSub asyn = new AsynParameterSub();
                        asyn.MerchantId = oerderdt.Rows[0]["fldMerchID"].ToString();
                        asyn.OrderID = oerderdt.Rows[0]["fldOrdernum"].ToString();
                        asyn.Amount = oerderdt.Rows[0]["fldPayAmount"].ToString();
                        asyn.OrderTime = oerderdt.Rows[0]["fldtransactiontime"].ToString();
                        asyn.Paystate = passstate;
                        string prams = "";

                        string getpram = JsonHelper.SerializeObject(asyn);
                        //json 转换成Dictionary
                        Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
                        //排序
                        RulePayBehavior behavior = new RulePayBehavior();
                        string pxrams = behavior.AsciiDesc(valuePairs);
                        //添加key值
                        pxrams += "key=" + Merchant.Rows[0]["fldSecretKey"].ToString();
                        //md5加密
                        string signkey = behavior.EncryptionMd5(pxrams);

                        asyn.Sign = signkey;

                        //转换成json 格式
                        prams = JsonHelper.SerializeObject(asyn);

                        RulePayRequest rulePayRequest = new RulePayRequest();
                        string rest = rulePayRequest.PostUrl(oerderdt.Rows[0]["fldNotice"].ToString(), prams);
                        if (rest != "ok")
                        {
                            Thread thread1 = new Thread(() => Notifyurl.myThread(oerderdt.Rows[0]["fldMerchID"].ToString(), oerderdt.Rows[0]["fldOrdernum"].ToString(), oerderdt.Rows[0]["fldOrderAmount"].ToString(), oerderdt.Rows[0]["fldtransactiontime"].ToString(), oerderdt.Rows[0]["fldNotice"].ToString(), passstate, Merchant.Rows[0]["fldSecretKey"].ToString()));
                            thread1.Start();
                        }

                    }

                }
                return retext;
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "AcceptInterfaceController", "Accept_QJSub", "万通返回结果解析失败");
            }

        }

        /// <summary>
        /// 万通参数
        /// </summary>
        public class QJPram
        {
            /// <summary>
            /// 
            /// </summary>
            public string transdata { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string sign { get; set; }
        }



        /// <summary>
        /// YF返回的是数据
        /// </summary>
        public class YFPram
        {
            /// <summary>
            /// 签名
            /// </summary>
            public string sign { get; set; }

            /// <summary>
            /// 返回信息
            /// </summary>
            public string notify_Msg { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class notify_msg
        {
            /// <summary>
            /// 商户订单号
            /// </summary>
            public string order_no { get; set; }

            /// <summary>
            /// 平台的交易流水
            /// </summary>
            public string trade_no { get; set; }

            /// <summary>
            /// 订单金额
            /// </summary>
            public string order_amount { get; set; }

            /// <summary>
            /// 商户ID
            /// </summary>
            public string merchant_id { get; set; }

            /// <summary>
            /// 交易目前所处的状态
            /// </summary>
            public string trade_status { get; set; }

            /// <summary>
            /// 会计日期
            /// </summary>
            public string account_date { get; set; }

            /// <summary>
            /// 手续费
            /// </summary>
            public string fee { get; set; }

        }
    }
}

using DDYZ.Ensis.Rule.DataRule;
using DDYZ.Ensis.Library.Exception.DataRule;

using EMCCommon.Mode;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using RASencryption;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using Newtonsoft.Json;

namespace EMCCommon.DateRule
{
    /// <summary>
    /// 处理各自渠道返回的结果
    /// </summary>
    public class ChannelReturnresult
    {
        RuletblPayfailMessageLog messageLog = new RuletblPayfailMessageLog();
        /// <summary>
        /// 功能描述：处理万通的返回结果
        /// 创建  人：周文卿
        /// 创建时间：2019-02-19
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="transactionnum">流水号</param>
        /// <param name="OrderID">订单号</param>
        /// <param name="ratecode">支付代码</param>
        /// <returns></returns>
        public rerurnpram ResultQJ(string result, string ratecode, string transactionnum, string OrderID)
        {
            JToken rejson = JToken.Parse(result);
            string aa = rejson["payment"].ToString();
            rerurnpram rerurnpram = new rerurnpram();
            int i = 0;
            if (aa == "True")
            {
                rerurnpram.message = "支付中";
                switch (ratecode)
                {
                    case "101":
                        RuleAlipay alipay = new RuleAlipay();
                        i = alipay.insertAlipay(OrderID, transactionnum, rejson["payUrl"].ToString(), DateTime.Now);
                        if (i == 0)
                        {
                            rerurnpram.message = "支付失败";
                        }
                        break;
                    case "103":
                        RuleWeixinpay weixinpay = new RuleWeixinpay();
                        i = weixinpay.insertweixinpay(OrderID, transactionnum, rejson["payUrl"].ToString(), DateTime.Now);
                        if (i == 0)
                        {
                            rerurnpram.message = "支付失败";
                        }
                        break;
                    case "119":
                        RuleJDpay ruleJDpay = new RuleJDpay();
                        rerurnpram.urlcode = rejson["payUrl"].ToString();
                        i = ruleJDpay.insertjdpay(OrderID, transactionnum, rejson["payUrl"].ToString(), DateTime.Now);
                        if (i == 0)
                        {
                            rerurnpram.message = "支付失败";
                        }
                        break;
                }
            }
            else
            {
                rerurnpram.message = rejson["message"].ToString();

                messageLog.inserttblPayfailMessageLog("万通", "1550473045", rerurnpram.message, transactionnum, OrderID, DateTime.Now, result);
            }
            return rerurnpram;
        }

        /// <summary>
        /// 功能描述：处理锐支付的返回结果
        /// 创建  人：周文卿
        /// 创建时间：2019-02-19
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="transactionnum">流水号</param>
        /// <param name="OrderID">订单号</param>
        /// <param name="ratecode">支付代码</param>
        /// <returns></returns>
        public string ResultRUI(string result, string ratecode, string transactionnum, string OrderID)
        {
            string Ownresult = "";
            JToken rejson = JToken.Parse(result);
            string code = rejson["code"].ToString();
            int i = 0;
            if (code == "success")
            {
                JToken data = JToken.Parse(rejson["data"].ToString());
                Ownresult = "支付中";
                switch (ratecode)
                {
                    case "102":
                        RuleAlipay alipay = new RuleAlipay();
                        string hh = Utils.UrlDecode(data["payurl"].ToString());
                        i = alipay.insertAlipay(OrderID, transactionnum, Utils.UrlDecode(data["payurl"].ToString()), DateTime.Now);
                        if (i == 0)
                        {
                            Ownresult = "支付失败";
                        }
                        break;
                    case "104":
                        RuleWeixinpay rule = new RuleWeixinpay();
                        //string hh = Utils.UrlDecode(data["payurl"].ToString());
                        i = rule.insertweixinpay(OrderID, transactionnum, Utils.UrlDecode(data["payurl"].ToString()), DateTime.Now);
                        if (i == 0)
                        {
                            Ownresult = "支付失败";
                        }
                        break;

                }
            }
            else
            {
                Ownresult = rejson["msg"].ToString();

                messageLog.inserttblPayfailMessageLog("锐支付", "A190305145337941", Ownresult, transactionnum, OrderID, DateTime.Now, result);
            }
            return Ownresult;
        }


        /// <summary>
        /// 功能描述：处理锐支付的返回结果
        /// 创建  人：周文卿
        /// 创建时间：2019-02-19
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="transactionnum">流水号</param>
        /// <param name="OrderID">订单号</param>
        /// <param name="ratecode">支付代码</param>
        /// <returns></returns>
        public string ResultY(string result, string ratecode, string transactionnum, string OrderID)
        {
            string Ownresult = "";
            JToken rejson = JToken.Parse(result);
            string code = rejson["retcode"].ToString();
            int i = 0;
            if (code == "1")
            {
                Ownresult = "支付中";
                if (ratecode == "102")
                {
                    RuleAlipay alipay = new RuleAlipay();
                    i = alipay.insertAlipay(OrderID, transactionnum, rejson["payUrl"].ToString(), DateTime.Now);
                    if (i == 0)
                    {
                        Ownresult = "支付失败";
                    }
                }
                if (ratecode == "101")
                {
                    RuleAlipay alipay = new RuleAlipay();
                    i = alipay.insertAlipay(OrderID, transactionnum, rejson["payUrl"].ToString(), DateTime.Now);
                    if (i == 0)
                    {
                        Ownresult = "支付失败";
                    }
                }


            }
            else
            {

                messageLog.inserttblPayfailMessageLog("易极速", "10783", result, transactionnum, OrderID, DateTime.Now, result);
            }
            return Ownresult;
        }




        /// <summary>
        /// 功能描述：处理再创支付的返回结果
        /// 创建  人：周文卿
        /// 创建时间：2019-03-19
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="transactionnum">流水号</param>
        /// <param name="OrderID">订单号</param>
        /// <param name="ratecode">支付代码</param>
        /// <returns></returns>
        public rerurnpram ResultZC(string result, string ratecode, string transactionnum, string OrderID)
        {
            rerurnpram Ownresult = new rerurnpram();
            JToken rejson = JToken.Parse(result);
            string code = rejson["status"].ToString();
            int i = 0;
            if (code == "0")
            {

                RuleWeixinpay weixinpay = new RuleWeixinpay();
                i = weixinpay.insertweixinpay(OrderID, transactionnum, rejson["qrcode"].ToString(), DateTime.Now);
                Ownresult.urlcode = rejson["qrcode_data"].ToString();
                if (i == 0)
                {
                    Ownresult.message = "支付失败";
                }
                Ownresult.message = "支付中";
            }
            else
            {
                Ownresult.message = "支付失败";
                messageLog.inserttblPayfailMessageLog("再创支付", "605", result, transactionnum, OrderID, DateTime.Now, result);
            }
            return Ownresult;
        }


        /// <summary>
        /// 功能描述：处理再创代付的返回结果
        /// 创建  人：周文卿
        /// 创建时间：2019-05-01
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="key">加密字段</param>
        /// <param name="orid"></param>
        /// <returns></returns>
        public string ResultZCSub(string result, string key, string orid)
        {
            string Ownresult = "";
            JToken rejson = JToken.Parse(result);
            string code = rejson["status"].ToString();
            if (code == "0")
            {
                ////开启线程 查询
                Thread thread1 = new Thread(() => RuleAgentPayQuery.QueryAgentThend("605", orid, key, "ZC_008"));
                thread1.Start();
                Ownresult = "ok";
            }
            else
            {
                Ownresult = "err";
                messageLog.inserttblPayfailMessageLog("再创支付", "605", result, "ZC_008", "", DateTime.Now, result);
            }
            return Ownresult;
        }

        /// <summary>
        /// 功能描述：处理万通代付返回的结果
        /// 创建  人：周文卿
        /// 创建时间：2019-02-19
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="key">key值</param>
        /// <param name="orid">订单号</param>
        /// <returns></returns>
        public string ResultQJSub(string result, string key, string orid)
        {
            string Ownresult = "";
            JToken rejson = JToken.Parse(result);
            string aa = rejson["status"].ToString();
            if (aa == "True")
            {
                Ownresult = "ok";
                ////开启线程 查询
                Thread thread1 = new Thread(() => RuleAgentPayQuery.QueryAgentThend("40939485", orid, key, "QJ_004"));
                thread1.Start();

            }
            else
            {

                Ownresult = rejson["message"].ToString();
                messageLog.inserttblPayfailMessageLog("万通", "1550473045", Ownresult, "代付", "", DateTime.Now, result);
            }
            return Ownresult;
        }

        /// <summary>
        /// 功能描述：处理汇通代付返回的结果
        /// 创建  人：周文卿
        /// 创建时间：2019-02-19
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ResultHTSub(string result, string key)
        {
            string Ownresult = Utils.UrlDecode(result);

            Dictionary<string, string> valuePairs = new Dictionary<string, string>();

            //先按& 转换成数组
            string[] jsontext = result.Split('&');

            for (int i = 0; i < jsontext.Length; i++)
            {
                //在进行=的截取 获得key值很Value值
                string[] keyvalue = jsontext[i].Split('=');
                valuePairs.Add(keyvalue[0], keyvalue[1]);
            }
            //判断是否成功
            if (valuePairs["RspCod"].ToString() == "00000")
            {
                String[] base64Keys = new String[] { "CodeUrl", "ImgUrl", "Token_Id", "PayInfo", "sPayUrl", "PayUrl", "NotifyUrl", "ReturnUrl" };
                string[] arrKeynew = valuePairs.Keys.ToArray();
                for (int i = 0; i < arrKeynew.Length; i++)
                {
                    //对所有的值值 进行 UrlDecode
                    valuePairs[arrKeynew[i].ToString()] = Utils.UrlDecode(valuePairs[arrKeynew[i].ToString()].ToString());
                    //对特殊参数先进行把其中的”%2b”替换为“+”然后 Base64解码
                    for (int j = 0; j < base64Keys.Length; j++)
                    {
                        if (arrKeynew[i].ToString() == base64Keys[j].ToString())
                        {
                            string value = valuePairs[arrKeynew[i].ToString()].ToString().Replace("%2b", "+");
                            byte[] bytes = Convert.FromBase64String(value);
                            string uec = Encoding.GetEncoding("utf-8").GetString(bytes);
                            valuePairs[arrKeynew[i].ToString()] = uec;
                        }
                    }

                }
                //开启线程 查询
                Thread thread1 = new Thread(() => RuleAgentPayQuery.QueryAgentThend("40939485", valuePairs["TxSN"].ToString(), key, "HT_006"));
                thread1.Start();

                Ownresult = "ok";
            }
            else
            {
                Ownresult = Utils.UrlDecode(result);
                messageLog.inserttblPayfailMessageLog("汇通", "40939485", Ownresult, "代付", "", DateTime.Now, Ownresult);
            }
            return Ownresult;
        }


        /// <summary>
        /// 功能描述：处理汇通代付返回的结果
        /// 创建  人：周文卿
        /// 创建时间：2019-02-19
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ResultYSub(string result, string key)
        {
            string Ownresult = Utils.UrlDecode(result);


            Ownresult = Utils.UrlDecode(result);
            messageLog.inserttblPayfailMessageLog("易极速", "10783", Ownresult, "代付", "", DateTime.Now, Ownresult);

            return Ownresult;
        }


        /// <summary>
        /// 功能描述：处理亿点代付返回的结果
        /// 创建  人：周文卿
        /// 创建时间：2019-04-29
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="key"></param>
        ///  <param name="orid"></param>
        /// <returns></returns>
        public string ResultYDSub(string result, string key)
        {
            string Ownresult = "";

            JToken jToken = JsonConvert.DeserializeObject(result) as JObject;

            if (jToken["transferStatus"] != null)
            {
                if (jToken["transferStatus"].ToString() == "C")
                {
                    Ownresult = "ok";
                    ////开启线程 查询
                    Thread thread1 = new Thread(() => RuleAgentPayQuery.QueryAgentThend("888017", jToken["transferId"].ToString(), key, "YD_010"));
                    thread1.Start();
                }
                else
                {
                    Ownresult = "err";
                }

            }
            else
            {
                Ownresult = "err";
                messageLog.inserttblPayfailMessageLog("亿点", "888017", result, "支付", "", DateTime.Now, result);
            }
            return Ownresult;
        }

        /// <summary>
        /// 功能描述：处理海付代付返回的结果
        /// 创建  人：周文卿
        /// 创建时间：2019-04-29
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="key"></param>
        ///  <param name="orid"></param>
        /// <returns></returns>
        public string ResultHFSub(string result, string key)
        {
            string Ownresult = "";

            JToken jToken = JsonConvert.DeserializeObject(result) as JObject;

            if (jToken["respCode"].ToString() == "0000")
            {
                
                    Ownresult = "ok";
                    ////开启线程 查询
                    Thread thread1 = new Thread(() => RuleAgentPayQuery.QueryAgentThend("734641", jToken["pay_number"].ToString(), key, "HF_011"));
                    thread1.Start();
               

            }
            else
            {
                Ownresult = "err";
                messageLog.inserttblPayfailMessageLog("海付", "734641", result, "代付", "", DateTime.Now, result);
            }
            return Ownresult;
        }

        /// <summary>
        /// 功能描述：处理汇通的返回结果
        /// 创建  人：周文卿
        /// 创建时间：2019-03-09
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="transactionnum">流水号</param>
        /// <param name="OrderID">订单号</param>
        /// <param name="ratecode">支付代码</param>
        /// <returns></returns>
        public string ResultHT(string result, string ratecode, string transactionnum, string OrderID)
        {
            string Ownresult = "";

            Dictionary<string, string> valuePairs = new Dictionary<string, string>();

            //先按& 转换成数组
            string[] jsontext = result.Split('&');

            for (int i = 0; i < jsontext.Length; i++)
            {
                //在进行=的截取 获得key值很Value值
                string[] keyvalue = jsontext[i].Split('=');
                valuePairs.Add(keyvalue[0], keyvalue[1]);
            }
            //判断是否成功
            if (valuePairs["RspCod"].ToString() == "00000")
            {
                String[] base64Keys = new String[] { "CodeUrl", "ImgUrl", "Token_Id", "PayInfo", "sPayUrl", "PayUrl", "NotifyUrl", "ReturnUrl" };
                string[] arrKeynew = valuePairs.Keys.ToArray();
                for (int i = 0; i < arrKeynew.Length; i++)
                {
                    //对所有的值值 进行 UrlDecode
                    valuePairs[arrKeynew[i].ToString()] = Utils.UrlDecode(valuePairs[arrKeynew[i].ToString()].ToString());
                    //对特殊参数先进行把其中的”%2b”替换为“+”然后 Base64解码
                    for (int j = 0; j < base64Keys.Length; j++)
                    {
                        if (arrKeynew[i].ToString() == base64Keys[j].ToString())
                        {
                            string value = valuePairs[arrKeynew[i].ToString()].ToString().Replace("%2b", "+");
                            byte[] bytes = Convert.FromBase64String(value);
                            string uec = Encoding.GetEncoding("utf-8").GetString(bytes);
                            valuePairs[arrKeynew[i].ToString()] = uec;
                        }
                    }

                }

                RuleWeixinpay weixinpay = new RuleWeixinpay();
                int h = weixinpay.insertweixinpay(OrderID, transactionnum, valuePairs["ImgUrl"].ToString(), DateTime.Now);
                if (h == 0)
                {
                    Ownresult = "支付失败";
                }
                Ownresult = "支付中";
            }
            else
            {
                Ownresult = Utils.UrlDecode(result);
                messageLog.inserttblPayfailMessageLog("汇通", "40939485", Ownresult, "支付", "", DateTime.Now, Ownresult);
            }
            return Ownresult;
        }

        /// <summary>
        /// 功能描述：处理无名的返回结果
        /// 创建  人：周文卿
        /// 创建时间：2019-04-23
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="transactionnum">流水号</param>
        /// <param name="OrderID">订单号</param>
        /// <param name="ratecode">支付代码</param>
        /// <returns></returns>
        public string ResultWM(string result, string ratecode, string transactionnum, string OrderID)
        {
            string Ownresult = "";

            JToken jToken = JsonConvert.DeserializeObject(result) as JObject;

            if (jToken["rsc"].ToString() == "1001")
            {
                JToken data = JsonConvert.DeserializeObject(jToken["data"].ToString()) as JObject;
                RuleWeixinpay weixinpay = new RuleWeixinpay();
                int i = weixinpay.insertweixinpay(OrderID, transactionnum, data["payUrl"].ToString(), DateTime.Now);
                if (i == 0)
                {
                    Ownresult = "支付失败";
                }
                Ownresult = "支付中";
            }
            else
            {
                Ownresult = Utils.UrlDecode(result);
                messageLog.inserttblPayfailMessageLog("无名", "114", Ownresult, "支付", "", DateTime.Now, Ownresult);
            }
            return Ownresult;
        }


        /// <summary>
        /// 功能描述：处理亿动的返回结果
        /// 创建  人：周文卿
        /// 创建时间：2019-04-28
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="transactionnum">流水号</param>
        /// <param name="OrderID">订单号</param>
        /// <param name="ratecode">支付代码</param>
        /// <returns></returns>
        public string ResultYD(string result, string ratecode, string transactionnum, string OrderID)
        {
            string Ownresult = "";

            JToken jToken = JsonConvert.DeserializeObject(result) as JObject;

            if (jToken["orderStatus"] != null)
            {
                if (jToken["orderStatus"].ToString() == "SUCCESS")
                {
                    RuleWeixinpay weixinpay = new RuleWeixinpay();
                    int i = weixinpay.insertweixinpay(OrderID, transactionnum, jToken["qrCode"].ToString(), DateTime.Now);
                    if (i == 0)
                    {
                        Ownresult = "支付失败";
                    }
                    Ownresult = "支付中";
                }
                else
                {
                    Ownresult = "支付失败";
                    messageLog.inserttblPayfailMessageLog("亿动", "888017", result, "支付", "", DateTime.Now, result);
                }

            }
            else
            {

                messageLog.inserttblPayfailMessageLog("亿动", "888017", result, "支付", "", DateTime.Now, result);
            }
            return Ownresult;
        }

        /// <summary>
        /// 功能描述：处理海付的返回结果
        /// 创建  人：周文卿
        /// 创建时间：2019-04-30
        /// </summary>
        /// <param name="result">请求结果</param>
        /// <param name="transactionnum">流水号</param>
        /// <param name="OrderID">订单号</param>
        /// <param name="ratecode">支付代码</param>
        /// <returns></returns>
        public string ResultHF(string result, string ratecode, string transactionnum, string OrderID)
        {
            string Ownresult = "";

            JToken jToken = JsonConvert.DeserializeObject(result) as JObject;


            if (jToken["respCode"].ToString() == "0000")
            {
                if (ratecode == "104")
                {
                    RuleWeixinpay weixinpay = new RuleWeixinpay();
                    int i = weixinpay.insertweixinpay(OrderID, transactionnum, jToken["payUrl"].ToString(), DateTime.Now);
                    if (i == 0)
                    {
                        Ownresult = "支付失败";
                    }
                    Ownresult = "支付中";
                }
                if (ratecode == "102")
                {

                    RuleAlipay alipay = new RuleAlipay();
                    int i = alipay.insertAlipay(OrderID, transactionnum, jToken["payUrl"].ToString(), DateTime.Now);
                    if (i == 0)
                    {
                        Ownresult = "支付失败";
                    }
                    Ownresult = "支付中";
                }
            }
            else
            {
                Ownresult = "支付失败";
                messageLog.inserttblPayfailMessageLog("亿动", "888017", result, "支付", "", DateTime.Now, result);
            }


            return Ownresult;
        }
    }
}
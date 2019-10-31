using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using Newtonsoft.Json.Linq;
using RASencryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace EMCCommon.DateRule
{
    /// <summary>
    /// 处理各个通道的参数
    /// </summary>
    public class Processingparameter
    {
        /// <summary>
        /// 公共的
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string Processing(Dictionary<string, string> parameter)
        {
            string jsonpar = JsonHelper.SerializeObject(parameter);
            return jsonpar;
        }

        /// <summary>
        /// 功能描述：QJ的参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="encstring">加密字段</param>
        /// <param name="outamunt">内扣金额</param>
        /// <returns></returns>
        public string ProcessingQJ(Dictionary<string, string> parameter, string encstring, decimal outamunt)
        {
            RulePayBehavior PayBehavior = new RulePayBehavior();
            parameter["order_amount"] = (decimal.Parse(parameter["order_amount"].ToString()) + outamunt).ToString();
            string returnjson = "{transdata:'',sign:'',signtype:''}";
            string newdict = PayBehavior.AsciiDesc(parameter);
            newdict += "key=" + encstring;
            string md5string = PayBehavior.EncryptionMd5(newdict);


            string jsonpar = JsonHelper.SerializeObject(parameter);

            //转换成JSON
            //JArray array = JArray.Parse("[" + jsonpar + "]");

            JToken jToken = JToken.Parse(returnjson);



            jToken["sign"] = HttpUtility.UrlEncode(md5string, Encoding.GetEncoding("utf-8"));
            jToken["transdata"] = HttpUtility.UrlEncode(jsonpar, Encoding.GetEncoding("utf-8"));
            jToken["signtype"] = "MD5";
            return jToken.ToString();
        }

        /// <summary>
        /// 功能描述：Y的参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="key">加密字段</param>
        /// <returns></returns>
        public string ProcessingY(Dictionary<string, string> parameter, string key)
        {
            RulePayBehavior PayBehavior = new RulePayBehavior();
            string ascdict = PayBehavior.AsciiDesc(parameter);
            ascdict = ascdict + "md5key=" + key;
            string jsonpar = PayBehavior.EncryptionMd5(ascdict, "x2");

            parameter.Add("sign", jsonpar);
            string retuntext = PayBehavior.AsciiDesc(parameter).TrimEnd('&');
            return retuntext;
        }

        /// <summary>
        /// 功能描述：RUI的参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="key">加密字段</param>
        /// <returns></returns>
        public string ProcessingRUI(Dictionary<string, string> parameter, string key)
        {
            RulePayBehavior PayBehavior = new RulePayBehavior();

            //得到异步通知地址
            string async_url = parameter["async_notify_url"].ToString();
            parameter["amount"] = (decimal.Parse(parameter["amount"]) * 100).ToString("F0");

            //删除异步地址和同步地址 进行签名
            parameter.Remove("async_notify_url");
            parameter.Remove("notify_url");
            //得到一个字符串
            string ascdict = PayBehavior.GetParamsStr(parameter);

            //java 私钥转.net xml
            string xmlprivateKey = RSAExtensions.ConvertToXmlPrivateKey(key);

            //私钥加密
            string sign = RSAUtil.PrivateKeyEncrypt(xmlprivateKey, ascdict);

            //添加 同步地址 异步地址 签名

            parameter.Add("notify_url", async_url);
            parameter.Add("async_notify_url", async_url);

            parameter.Add("sign", Utils.UrlEncode(sign));
            string jsontext = PayBehavior.GetParamsStr(parameter);
            //string jsontext = JsonHelper.SerializeObject(parameter);

            return jsontext;
        }


        /// <summary>
        /// 功能描述：汇通参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="key">加密字段</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public string ProcessingHT(Dictionary<string, string> parameter, string key, string type)
        {
            RulePayBehavior PayBehavior = new RulePayBehavior();

            //得到加密方式
            string SignMethod = parameter["SignMethod"].ToString();
            string Amount = "";

            if (type == "0")
            {
                Amount = "Amount";
            }
            else
            {
                Amount = "Payment_amt";
            }
            //金额乘以100
            if (parameter.ContainsKey(Amount))
            {
                parameter[Amount] = (decimal.Parse(parameter[Amount]) * 100).ToString("F0");
            }


            //删除异步地址和同步地址 进行签名
            parameter.Remove("SignMethod");



            //排序
            string paixu = PayBehavior.AsciiDesc(parameter).TrimEnd('&');
            //排序后的字符串加上key
            paixu = paixu + key;
            //加密字符串
            string sign = PayBehavior.EncryptionMd5(paixu, "x2");

            //添加 加密方式和sign 


            parameter.Add("SignMethod", SignMethod);

            parameter.Add("Signature", sign);


            //对特殊参数先进行Base64编码然后把其中的”+”替换为“%2b”
            String[] base64Keys = new String[] { "CodeUrl", "ImgUrl", "Token_Id", "PayInfo", "sPayUrl", "PayUrl", "NotifyUrl", "ReturnUrl" };

            Dictionary<string, string> keyValuePairs = PayBehavior.stringtobase64(parameter, base64Keys);

            ////对所有的值进行encode
            string[] arrKeynew = keyValuePairs.Keys.ToArray();
            for (int i = 0; i < arrKeynew.Length; i++)
            {
                keyValuePairs[arrKeynew[i].ToString()] = HttpUtility.UrlEncode(keyValuePairs[arrKeynew[i].ToString()], System.Text.Encoding.UTF8);
            }

            //string jsontext = PayBehavior.GetParamsStr(keyValuePairs);
            string jsontext = PayBehavior.GetParamsStr(keyValuePairs);
            //string jsontext = JsonHelper.SerializeObject(parameter);

            return jsontext;
        }


        /// <summary>
        /// 功能描述：再创参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="encstring">加密字段</param>
        /// <returns></returns>
        public string ProcessingZC(Dictionary<string, string> parameter, string encstring)
        {
            RulePayBehavior PayBehavior = new RulePayBehavior();


            parameter["money"] = (decimal.Parse(parameter["money"]) * 100).ToString("F0");


            //得到所有的值
            string keys = "";
            foreach (string item in parameter.Keys)
            {
                if (item != "notify_url")
                {
                    keys += parameter[item];
                }

            }
            keys += encstring;




            string pram = PayBehavior.EncryptionMd5(keys, "x2");

            parameter.Add("sign", pram);


            string reust = PayBehavior.AsciiDescnotnull(parameter).TrimEnd('&');

            return reust;
        }


        /// <summary>
        /// 功能描述：再创参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="encstring">加密字段</param>
        /// <returns></returns>
        public string ProcessingZCselect(Dictionary<string, string> parameter, string encstring)
        {
            RulePayBehavior PayBehavior = new RulePayBehavior();


          


            //得到所有的值
            string keys = "";
            foreach (string item in parameter.Keys)
            {
                if (item != "notify_url")
                {
                    keys += parameter[item];
                }

            }
            keys += encstring;




            string pram = PayBehavior.EncryptionMd5(keys, "x2");

            parameter.Add("sign", pram);


            string reust = PayBehavior.AsciiDesc(parameter).TrimEnd('&');

            return reust;
        }

        /// <summary>
        /// 功能描述：无名参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="encstring">加密字段</param>
        /// <returns></returns>
        public string ProcessingWM(Dictionary<string, string> parameter, string encstring)
        {
            string reust = "";
            RulePayBehavior PayBehavior = new RulePayBehavior();

            string ascdict = PayBehavior.AsciiDesc(parameter).TrimEnd('&');

            ascdict += encstring;

            reust = PayBehavior.EncryptionMd5(ascdict, "x2");

            parameter.Add("sign", reust);


            reust = PayBehavior.AsciiDesc(parameter).TrimEnd('&');

            return reust;
        }




        /// <summary>
        /// 功能描述：亿动的参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="key">加密字段</param>
        /// <returns></returns>
        public string ProcessingYD(Dictionary<string, string> parameter, string key)
        {
            RulePayBehavior PayBehavior = new RulePayBehavior();
            //得到一个字符串


            parameter["amount"] = (decimal.Parse(parameter["amount"]) * 100).ToString("F0");

            string[] listkey = new string[] { "version", "merchantNum", "nonce_str", "merMark", "client_ip", "payType", "orderNum", "amount", "body" };

            string ascdict = "";
            foreach (string item in listkey)
            {

                ascdict += item + "=" + parameter[item] + "&";
            }





            //添加key
            ascdict = ascdict + "key=" + key;

            //md5加密

            string sign = PayBehavior.EncryptionMd5(ascdict);

            parameter.Add("signType", "MD5");
            parameter.Add("sign", sign);


            string jsontext = PayBehavior.GetParamsStr(parameter);
            //string jsontext = JsonHelper.SerializeObject(parameter);

            return jsontext;
        }


        /// <summary>
        /// 功能描述：亿点的代付参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="key">加密字段</param>
        /// <returns></returns>
        public string ProcessingYDSub(Dictionary<string, string> parameter, string key)
        {
            RulePayBehavior PayBehavior = new RulePayBehavior();
            //得到一个字符串


            parameter["transferMoney"] = (decimal.Parse(parameter["transferMoney"]) * 100).ToString("F0");

            string[] listkey = new string[] { "version", "merchantNum", "nonce_str", "merMark", "user_ip", "method", "transferId", "transferMoney", "bankCard", "bankllh" };

            string ascdict = "";
            foreach (string item in listkey)
            {

                ascdict += item + "=" + parameter[item] + "&";
            }





            //添加key
            ascdict = ascdict + "key=" + key;

            //md5加密

            string sign = PayBehavior.EncryptionMd5(ascdict);


            parameter.Add("sign", sign);


            string jsontext = PayBehavior.GetParamsStr(parameter);
            //string jsontext = JsonHelper.SerializeObject(parameter);

            return jsontext;
        }

        /// <summary>
        /// 功能描述：亿点的查询参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="key">加密字段</param>
        /// <returns></returns>
        public string ProcessingYDSelect(Dictionary<string, string> parameter, string key)
        {
            RulePayBehavior PayBehavior = new RulePayBehavior();
            //得到一个字符串




            string[] listkey = new string[] { "method", "transferId", "merchantNum", "nonce_str" };

            string ascdict = "";
            foreach (string item in listkey)
            {

                ascdict += item + "=" + parameter[item] + "&";
            }





            //添加key
            ascdict = ascdict + "key=" + key;

            //md5加密

            string sign = PayBehavior.EncryptionMd5(ascdict);


            parameter.Add("sign", sign);


            string jsontext = PayBehavior.GetParamsStr(parameter);
            //string jsontext = JsonHelper.SerializeObject(parameter);

            return jsontext;
        }


        /// <summary>
        /// 功能描述：海付的参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="key">加密字段</param>
        /// <returns></returns>
        public string ProcessingHF(Dictionary<string, string> parameter, string key)
        {
            RulePayBehavior PayBehavior = new RulePayBehavior();
            //参与签名的字段
            string[] listkey = new string[] { "userid", "subject", "amount", "notifyUrl", "pageNotifyUrl" };

            //签名的字典表
            Dictionary<string, string> singdict = new Dictionary<string, string>();
            string ascdict = "";
            foreach (string item in listkey)
            {

                singdict.Add(item, parameter[item].ToString());
            }
            //排序得到字符

            ascdict = PayBehavior.AsciiDesc(singdict);


            //添加key
            ascdict = ascdict + "key=" + key;

            //md5加密

            string sign = PayBehavior.EncryptionMd5(ascdict,"x2");

            parameter.Add("sign", sign);


            string jsontext = PayBehavior.GetParamsStr(parameter);
            //string jsontext = JsonHelper.SerializeObject(parameter);

            return jsontext;
        }




        /// <summary>
        /// 功能描述：海付的代付参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="key">加密字段</param>
        /// <returns></returns>
        public string ProcessingHFSub(Dictionary<string, string> parameter, string key)
        {
            RulePayBehavior PayBehavior = new RulePayBehavior();
            //参与签名的字段
            string[] listkey = new string[] { "userid", "amount", "bankCode", "cardName", "cardNo", "mobile", "customerType", "accountTypeCode", "province", "city", "issueBankName", "notifyUrl"};

            //签名的字典表
            Dictionary<string, string> singdict = new Dictionary<string, string>();
            string ascdict = "";
            foreach (string item in listkey)
            {

                singdict.Add(item, parameter[item].ToString());
            }
            //排序得到字符

            ascdict = PayBehavior.AsciiDesc(singdict);


            //添加key
            ascdict = ascdict + "key=" + key;

            //md5加密

            string sign = PayBehavior.EncryptionMd5(ascdict, "x2");

            parameter.Add("sign", sign);


            string jsontext = PayBehavior.GetParamsStr(parameter);
            //string jsontext = JsonHelper.SerializeObject(parameter);

            return jsontext;
        }


        /// <summary>
        /// 功能描述：海付查询参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="encstring">加密字段</param>
        /// <returns></returns>
        public string ProcessingHFselect(Dictionary<string, string> parameter, string encstring)
        {

            RulePayBehavior PayBehavior = new RulePayBehavior();
            //参与签名的字段
            string[] listkey = new string[] { "userid"};

            //签名的字典表
            Dictionary<string, string> singdict = new Dictionary<string, string>();
            string ascdict = "";
            foreach (string item in listkey)
            {

                singdict.Add(item, parameter[item].ToString());
            }
            //排序得到字符

            ascdict = PayBehavior.AsciiDesc(singdict);


            //添加key
            ascdict = ascdict + "key=" + encstring;

            //md5加密

            string sign = PayBehavior.EncryptionMd5(ascdict, "x2");

            parameter.Add("sign", sign);


            string jsontext = PayBehavior.GetParamsStr(parameter);
            //string jsontext = JsonHelper.SerializeObject(parameter);

            return jsontext;
        }

        /// <summary>
        /// 功能描述：赤的参数
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="key">加密字段</param>
        /// <returns></returns>
        public string ProcessingXF(Dictionary<string, string> parameter, string key)
        {
            RulePayBehavior PayBehavior = new RulePayBehavior();

            Dictionary<String, string> newpram = new Dictionary<string, string>();

            
          
            string ascdict = JsonHelper.SerializeObject(parameter);

            //////java 私钥转.net xml
            string xmlprivateKey = RSAExtensions.RSAPublicKeyJava2DotNet(key);

            //私钥加密
            string sign = RSAUtil.Encrypt(key, Encoding.UTF8.GetBytes(ascdict));

            //添加 同步地址 异步地址 签名

            newpram.Add("merchantNo", "9900000000000111");
            newpram.Add("keyType", "1");
            newpram.Add("agentNo", "10000034");
            newpram.Add("data", sign);


            //string jsontext = PayBehavior.GetParamsStr(newpram);
            string jsontext = JsonHelper.SerializeObject(newpram);

            return jsontext;
        }

    }
}
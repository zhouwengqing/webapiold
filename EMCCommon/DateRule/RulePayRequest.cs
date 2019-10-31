using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using DDYZ.Ensis.Library.Exception.DataRule;
using EMCCommon.Mode;
using NPOI.OpenXml4Net.OPC;
using RestSharp;

namespace EMCCommon.DateRule
{
    /// <summary>
    /// 功能描述：请求方式封装
    /// 创建  人：周文卿
    /// 创建时间：2018-11-17
    /// </summary>
    public class RulePayRequest
    {

        /// <summary>
        /// 发送请求(参数为字符)（x-www-form-urlencoded）（下单）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postDataStr"></param>
        /// <param name="channel"></param>
        /// <param name="transactionnum"></param>
        /// <param name="orderid"></param>
        /// <param name="paycode"></param>
        /// <returns></returns>

        public rerurnpram HttpPost(string url, string postDataStr, string channel, string paycode, string transactionnum, string orderid)
        {
            Encoding code = Encoding.GetEncoding("utf-8");
            rerurnpram rerurnpram = new rerurnpram();
            byte[] bytesRequestData = code.GetBytes(postDataStr.Trim());
            string str = "";
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                HttpWebRequest myReq = webRequest as HttpWebRequest;
                myReq.Method = "post";
                myReq.ContentType = "application/x-www-form-urlencoded";
                myReq.ContentLength = bytesRequestData.Length;
                Stream requestStream = myReq.GetRequestStream();
                requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
                requestStream.Close();
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader Reader = new StreamReader(myStream);

                str = Reader.ReadToEnd();
                ChannelReturnresult returnresult = new ChannelReturnresult();
                //根据渠道 处理结果
                switch (channel)
                {
                    case "RUI_005":
                        rerurnpram.message = returnresult.ResultRUI(str, paycode, transactionnum, orderid);
                        break;
                    case "Y_007":
                        rerurnpram.message = returnresult.ResultY(str, paycode, transactionnum, orderid);
                        break;
                    case "HT_006":
                        rerurnpram.message = returnresult.ResultHT(str, paycode, transactionnum, orderid);
                        break;
                    case "ZC_008":
                        rerurnpram = returnresult.ResultZC(str, paycode, transactionnum, orderid);
                        break;
                    case "WM_009":
                        rerurnpram.message = returnresult.ResultWM(str, paycode, transactionnum, orderid);
                        break;
                    case "YD_010":
                        rerurnpram.message = returnresult.ResultYD(str, paycode, transactionnum, orderid);
                        break;
                    case "HF_011":
                        rerurnpram.message = returnresult.ResultHF(str, paycode, transactionnum, orderid);
                        break;
                }

                return rerurnpram;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RulePayMethod", "PostUrl", postDataStr);
            }


        }

        /// <summary>
        /// 发送请求(参数为字符)（x-www-form-urlencoded）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postDataStr"></param>
        /// <param name="channel"></param>
        /// <param name="key"></param>
        /// <param name="orid"></param>
        /// <returns></returns>

        public string HttpPostZF(string url, string postDataStr, string channel, string key, string orid)
        {
            Encoding code = Encoding.GetEncoding("utf-8");
            rerurnpram rerurnpram = new rerurnpram();
            byte[] bytesRequestData = code.GetBytes(postDataStr.Trim());
            string str = "";
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                HttpWebRequest myReq = webRequest as HttpWebRequest;
                myReq.Method = "post";
                myReq.ContentType = "application/x-www-form-urlencoded";
                myReq.ContentLength = bytesRequestData.Length;
                Stream requestStream = myReq.GetRequestStream();
                requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
                requestStream.Close();
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader Reader = new StreamReader(myStream);
                str = Reader.ReadToEnd();
                ChannelReturnresult returnresult = new ChannelReturnresult();
                //根据渠道 处理结果
                switch (channel)
                {

                    case "HT_006":
                        rerurnpram.message = returnresult.ResultHTSub(str, key);
                        break;
                    case "Y_007":
                        rerurnpram.message = returnresult.ResultYSub(str, key);
                        break;
                    case "YD_010":
                        rerurnpram.message = returnresult.ResultYDSub(str, key);
                        break;
                    case "ZC_008":
                        rerurnpram.message = returnresult.ResultZCSub(str, key, orid);
                        break;
                    case "HF_011":
                        rerurnpram.message = returnresult.ResultHFSub(str, key);
                        break;
                }

                return rerurnpram.message;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RulePayMethod", "PostUrl", postDataStr);
            }


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postDataStr"></param>
        /// <param name="channel"></param>
        /// <param name="retacode"></param>
        /// <param name="transactionnum"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public rerurnpram PostRestSharp(string url, string postDataStr, string channel, string retacode, string transactionnum, string OrderID)
        {
            WebRequest hr = HttpWebRequest.Create(url);

            byte[] buf = System.Text.Encoding.GetEncoding("utf-8").GetBytes(postDataStr);
            hr.ContentType = "application/json";
            hr.ContentLength = buf.Length;
            hr.Method = "POST";

            System.IO.Stream RequestStream = hr.GetRequestStream();
            RequestStream.Write(buf, 0, buf.Length);
            RequestStream.Close();

            System.Net.WebResponse response = hr.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
            string ReturnVal = reader.ReadToEnd();
            reader.Close();
            response.Close();



            rerurnpram rerurnpram = new rerurnpram();
            return rerurnpram;
        }

        /// <summary>
        /// 功能描述：POST请求{}对象（下单支付）
        /// 创建  人：周文卿
        /// 创建时间：2019-02-18
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postData">json格式的请求报文,例如：{"key1":"value1","key2":"value2"}</param>
        /// <param name="code">支付方式</param>
        /// <param name="channel">请求的渠道信息</param>
        /// <param name="transactionnum">流水号</param>
        /// <param name="orderid">用户发送来的订单号</param>
        /// <returns></returns>
        public rerurnpram PostUrl(string url, string postData, string code, string channel, string transactionnum, string orderid)
        {
            try
            {
                ChannelReturnresult returnresult = new ChannelReturnresult();

                rerurnpram rerurnpram = new rerurnpram();

                string result = "";

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                req.KeepAlive = false;

                req.Method = "POST";

                req.Timeout = 5000;//设置请求超时时间，单位为毫秒

                req.ContentType = "application/json";

                byte[] data = Encoding.UTF8.GetBytes(postData);

                req.ContentLength = data.Length;

                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);

                    reqStream.Close();
                }

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Stream stream = resp.GetResponseStream();


                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }

                //根据渠道 处理结果
                switch (channel)
                {
                    case "QJ_004":
                        rerurnpram = returnresult.ResultQJ(result, code, transactionnum, orderid);
                        break;
                }
                return rerurnpram;
            }
            catch (Exception e)
            {
                rerurnpram rerurnpram = new rerurnpram();
                rerurnpram.statecode = "error";
                rerurnpram.message = e.Message;
                return rerurnpram;
                throw new InsertException(e.Message, "RulePayMethod", "PostUrl", postData);
            }
        }


        public rerurnpram trt(string url, string postData, string code, string channel, string transactionnum, string orderid)
        {
            HttpWebRequest request = null;
            Stream webStream = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            string responseString = "";

            try
            {
                byte[] bf = Encoding.UTF8.GetBytes(postData);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;
                request.Timeout = 1000 * 3;
                request.ContentType = "application/json";
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version11;
                request.ContentLength = bf.Length;
                webStream = request.GetRequestStream();
                webStream.Write(bf, 0, bf.Length);

                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                responseString = reader.ReadToEnd();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                request.Abort();
                request = null;
                if (webStream != null)
                {
                    webStream.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }



            //解析
            JavaScriptSerializer jsonConvert = new JavaScriptSerializer();
            dynamic responseObj = jsonConvert.DeserializeObject(responseString);
            if (responseObj is Dictionary<string, object>)
            {
                Dictionary<string, object> jsonobj = (Dictionary<string, object>)responseObj;
               
            }
            rerurnpram rerurnpram = new rerurnpram();
            return rerurnpram;
        }

        /// <summary>
        /// 异步通知时请求的方式
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public string PostUrl(string url, string postData)
        {
            try
            {
                ChannelReturnresult returnresult = new ChannelReturnresult();

                rerurnpram rerurnpram = new rerurnpram();

                string result = "";

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                req.Method = "POST";

                req.Timeout = 5000;//设置请求超时时间，单位为毫秒

                req.ContentType = "application/json";

                byte[] data = Encoding.UTF8.GetBytes(postData);

                req.ContentLength = data.Length;

                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);

                    reqStream.Close();
                }

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Stream stream = resp.GetResponseStream();

                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }


                return result;
            }
            catch (Exception e)
            {
                new InsertException(e.Message, "RulePayMethod", "PostUrl", "url：" + url + "参数：" + postData);
                return "error";
            }
        }


        /// <summary>
        /// 代付请求 并且处理（json的请求方式）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="channel"></param>
        ///  <param name="key"></param>
        ///  <param name="ordid"></param>
        /// <returns></returns>
        public string PostUrl(string url, string postData, string channel, string key, string ordid)
        {
            try
            {
                ChannelReturnresult returnresult = new ChannelReturnresult();

                rerurnpram rerurnpram = new rerurnpram();

                string result = "";

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                req.Method = "POST";

                req.Timeout = 5000;//设置请求超时时间，单位为毫秒

                req.ContentType = "application/json";

                byte[] data = Encoding.UTF8.GetBytes(postData);

                req.ContentLength = data.Length;

                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);

                    reqStream.Close();
                }

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Stream stream = resp.GetResponseStream();

                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
                //根据渠道 处理结果
                switch (channel)
                {
                    case "QJ_004":
                        rerurnpram.message = returnresult.ResultQJSub(result, key, ordid);
                        break;

                }

                return rerurnpram.message;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RulePayMethod", "PostUrl", postData);
            }
        }
    }
}
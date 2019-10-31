using DDYZ.Ensis.Library.Exception.DataRule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace EMCCommon.DateRule
{
    /// <summary>
    /// 查询接口的 请求方式
    /// </summary>
    public class QueryRequest
    {
        /// <summary>
        /// 发送请求(参数为字符)（x-www-form-urlencoded）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postDataStr"></param>
        /// <param name="channel"></param>
        /// <returns></returns>

        public string HttpPostZF(string url, string postDataStr, string channel,string orid)
        {
            Encoding code = Encoding.GetEncoding("utf-8");
          
            byte[] bytesRequestData = code.GetBytes(postDataStr.Trim());
            string str = "";
            string reult = "";
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

                QueryRetuenResult returnresult = new QueryRetuenResult();
         
                
                //根据渠道 处理结果
                switch (channel)
                {

                    case "HT_006":
                        reult = returnresult.Query_HTSUb(str);
                        break;
                    case "YD_010":
                        reult = returnresult.Query_YDSUb(str);
                        break;
                    case "ZC_008":
                        reult = returnresult.Query_ZCSUb(str,orid);
                        break;
                    case "HF_011":
                        reult = returnresult.Query_HFSUb(str, orid);
                        break;
                }
                return reult;
            }
            catch (Exception e)
            {
                return reult;
                throw new InsertException(e.Message, "QueryRequest", "PostUrl", postDataStr);
            }


        }


        // <summary>
        /// 发送请求(参数为字符)（json）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postDataStr"></param>
        /// <param name="channel"></param>
        /// <returns></returns>

        public string HttpPostJSON(string url, string postDataStr, string channel)
        {
            try
            {
                QueryRetuenResult returnresult = new QueryRetuenResult();

               

                string result = "";

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                req.Method = "POST";

                req.Timeout = 5000;//设置请求超时时间，单位为毫秒

                req.ContentType = "application/json";

                byte[] data = Encoding.UTF8.GetBytes(postDataStr);

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
                        result = returnresult.Query_QJSUb(result);
                        break;

                }

                return result;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RulePayMethod", "PostUrl", postDataStr);
            }


        }
    }
}
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
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
    /// 支付宝跳转
    /// </summary>
    public class alipayController : ApiController
    {
        /// <summary>
        /// 功能描述：根据订单号和流水号查询跳转地址
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public HttpResponseMessage pay(string OrderID, string tid)
        {
            try
            {
                RuleCommon common = new RuleCommon();
                DataTable dt = common.GetQueryDate("", "tblAlipay", "1=1 and fldOrderID='" + OrderID + "' and fldtransactionnum='" + tid + "'");
                string url = "http://47.112.131.178:8066/404/";
                if (dt.Rows.Count > 0)
                {
                    url = dt.Rows[0]["fldPayUrl"].ToString();
                }
                //HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.Moved);
                //resp.Headers.Location = new Uri(url);
                //return resp;

                return new HttpResponseMessage { Content = new StringContent(url, System.Text.Encoding.UTF8, "application/json") };
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "alipayController", "pay", OrderID);
            }

        }



        /// <summary>
        /// 功能描述：根据订单号和流水号查询跳转地址
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public HttpResponseMessage paycode(string OrderID, string tid)
        {
            try
            {
              
                pram pram = new pram();
                RuleCommon common = new RuleCommon();
                DataTable dt = common.GetQueryDate("", "tblAlipay", "1=1 and fldOrderID='" + OrderID + "' and fldtransactionnum='" + tid + "'");
                DataTable dt1 = common.GetQueryDate("", "tblOrdertable", "1=1 and fldOrdernum='" + OrderID + "' and fldtransactionnum='" + tid + "'");
                string url = "http://47.112.131.178:8066/404/";
                if (dt.Rows.Count > 0)
                {
                    pram.url = dt.Rows[0]["fldPayUrl"].ToString();
                    pram.amount= dt1.Rows[0]["fldOrderAmount"].ToString();
                }
                //HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.Moved);
                //resp.Headers.Location = new Uri(url);
                //return resp;
                string rest = JsonHelper.SerializeObject(pram);

                return new HttpResponseMessage { Content = new StringContent(rest, System.Text.Encoding.UTF8, "application/json") };
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "alipayController", "pay", OrderID);
            }

        }


        class pram {
            public string url { get; set; }

            public string amount { get; set; }
        }
    }
}

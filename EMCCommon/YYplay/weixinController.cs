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
    /// 微信跳转
    /// </summary>
    public class weixinController : ApiController
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
                DataTable dt = common.GetQueryDate("", "tblWeiXinpay", "1=1 and fldOrderID='" + OrderID + "' and fldtransactionnum='" + tid + "'");
                string url = "http://39.108.231.24:8066/404/";
                if (dt.Rows.Count > 0)
                {
                    url = dt.Rows[0]["fldPayUrl"].ToString();
                }
                return new HttpResponseMessage { Content = new StringContent(url, System.Text.Encoding.UTF8, "application/json") };
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "alipayController", "pay", OrderID);
            }

        }
    }
}

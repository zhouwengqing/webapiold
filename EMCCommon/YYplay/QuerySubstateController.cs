using DDYZ.Ensis.Rule.DataRule;
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
    /// 
    /// </summary>
    public class QuerySubstateController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：查出代付时间超过半个时候的代付
        /// 创建  人：周文卿
        /// 创建时间：20190318
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage Gethalfhour(parm reparm)
        {

            string result = string.Empty;
            try
            {
                int count = 0;
                string where = parwhere(reparm);



                //查询分页的数据
                DataTable dt = rule.getpaging("vwtblAgentPay", "*", "1=1" + where, reparm.page, reparm.limit, reparm.sort, out count);

                getdata getdata = new getdata();
                getdata.Table = dt;
                getdata.total = count;
                result = rule.JsonStr("ok", "成功", getdata);


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：手工代付
        /// 创建时间：20190321
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="MerchantId"></param>
        /// <param name="order_no"></param>
        /// <param name="cheanlname"></param>
        /// <returns></returns>
        public HttpResponseMessage ManualQuery(string MerchantId,string order_no,string cheanlname) {

            string result = string.Empty;
            //根据商户ID 查询Key
            using (YYPlayContext db = new YYPlayContext())
            {
                tbleMerchant merchant = (from x in db.tbleMerchant
                                where x.fldMerchID == MerchantId
                                select x).First();
                result = rule.JsonStr("ok", "", merchant);
            }


            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };

        }

        /// <summary>
        /// 
        /// </summary>
        public class parm
        {

            /// <summary>
            /// 排序字段
            /// </summary>
            public string sort { get; set; }

            /// <summary>
            /// 页面状态
            /// </summary>
            public string flag { get; set; }

            /// <summary>
            /// 页数
            /// </summary>
            public int page { get; set; }

            /// <summary>
            /// 每页显示数
            /// </summary>
            public int limit { get; set; }

            /// <summary>
            /// 渠道流水号
            /// </summary>
            public string channelnum { get; set; }

            /// <summary>
            /// 订单号
            /// </summary>
            public string Ordernum { get; set; }

            /// <summary>
            /// 最小金额
            /// </summary>
            public string minOrderAmount { get; set; }


            /// <summary>
            /// 最大金额
            /// </summary>
            public string maxOrderAmount { get; set; }

            /// <summary>
            /// 商户号
            /// </summary>
            public string merchanid { get; set; }

            /// <summary>
            /// 代付状态
            /// </summary>
            public string PayState { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string minOrdertime { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string maxOrdertime { get; set; }


            /// <summary>
            /// 渠道号
            /// </summary>
            public string channelid { get; set; }

            /// <summary>
            /// 银行卡号
            /// </summary>
            public string banknum { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class getdata
        {
            /// <summary>
            /// 总数
            /// </summary>
            public int total { get; set; }

            /// <summary>
            /// 数据
            /// </summary>
            public DataTable Table { get; set; }


        }

        /// <summary>
        /// 功能描述：拼接where条件
        /// 创建时间：2018-12-07
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        public string parwhere(parm reparm)
        {
            string where = " and GETDATE()>=dateadd(MINUTE,+30, fldCreatetime)";
            if (!string.IsNullOrEmpty(reparm.channelnum))
            {
                where += " and fldChannelnum='" + reparm.channelnum + "'";
            }
            if (!string.IsNullOrEmpty(reparm.flag))
            {
                if (reparm.flag == "0")
                {
                    where += " and fldPayState ='处理中'";
                }

            }
            if (!string.IsNullOrEmpty(reparm.merchanid))
            {
                where += " and fldMerchID='" + reparm.merchanid + "'";
            }
            if (!string.IsNullOrEmpty(reparm.Ordernum))
            {
                where += " and fldOrdernum='" + reparm.Ordernum + "'";
            }
            if (!string.IsNullOrEmpty(reparm.minOrderAmount) && !string.IsNullOrEmpty(reparm.maxOrderAmount))
            {
                where += " and fldActualAmount>=" + reparm.minOrderAmount + " and fldActualAmount<=" + reparm.maxOrderAmount;
            }
            if (!string.IsNullOrEmpty(reparm.PayState))
            {
                where += " and fldPayState='" + reparm.PayState + "'";
            }
            if (!string.IsNullOrEmpty(reparm.minOrdertime) && !string.IsNullOrEmpty(reparm.maxOrdertime))
            {
                where += " and fldCreateTime>='" + reparm.minOrdertime + "'" + " and fldCreateTime<='" + reparm.maxOrdertime + "'";
            }
            if (!string.IsNullOrEmpty(reparm.channelid))
            {
                where += " and fldChannelID='" + reparm.channelid + "'";
            }
            if (!string.IsNullOrEmpty(reparm.banknum))
            {
                where += " and fldBankCardId='" + reparm.banknum + "'";
            }
            return where;
        }
    }
}

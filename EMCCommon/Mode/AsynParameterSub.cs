using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMCCommon.Mode
{
    /// <summary>
    /// 支付结果返回参数
    /// </summary>
    public class AsynParameterSub
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// 订单时间
        /// </summary>
        public string OrderTime { get; set; }

        /// <summary>
        /// 支付状态
        /// </summary>
        public string Paystate { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

    }
}
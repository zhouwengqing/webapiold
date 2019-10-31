using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMCCommon.Mode
{
    /// <summary>
    /// 请求参数
    /// </summary>
    public class payparameter
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// 商户提供订单号ID
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayType { get; set; }

        /// <summary>
        /// 异步通知地址
        /// </summary>
        public string Notifyurl { get; set; }

        /// <summary>
        /// 订单请求时间
        /// </summary>
        public string OrderTime { get; set; }

        /// <summary>
        /// 签名的数据
        /// </summary>
        public string Sign { get; set; }
    }
}
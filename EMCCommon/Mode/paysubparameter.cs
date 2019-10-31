using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMCCommon.Mode
{
    /// <summary>
    /// 代付参数
    /// </summary>
    public class paysubparameter
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// 订单请求时间
        /// </summary>
        public string OrderTime { get; set; }

        /// <summary>
        /// 商户提供订单号ID
        /// </summary>
        public string OrderID { get; set; }

       
        /// <summary>
        /// 金额
        /// </summary>
        public string Amount { get; set; }


        /// <summary>
        /// 银行名称
        /// </summary>
        public string Bankname { get; set; }

        /// <summary>
        /// 银行支行
        /// </summary>
        public string Bankbranch { get; set; }

        /// <summary>
        /// 银行省份
        /// </summary>
        public string Bankprovince { get; set; }

        /// <summary>
        /// 开户行所在市
        /// </summary>
        public string Bankcity { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        public string Bankaccount { get; set; }

        /// <summary>
        /// 账号用户名
        /// </summary>
        public string Username  { get; set; }

        /// <summary>
        /// 签名的数据
        /// </summary>
        public string Sign { get; set; }
    }
}
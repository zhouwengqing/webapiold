namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAgentPay")]
    public partial class tblAgentPay
    {
        [Key]

        public int fldAutoID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime fldCreateTime { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>
        [StringLength(50)]
        public string fldtransactionnum { get; set; }

        /// <summary>
        /// 渠道流水号
        /// </summary>
        [StringLength(50)]
        public string fldChannelnum { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [StringLength(50)]
        public string fldOrdernum { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [StringLength(50)]
        public string fldMerchID { get; set; }

        /// <summary>
        /// 代付金额
        /// </summary>

        public decimal fldPayAmount { get; set; }

        /// <summary>
        /// 代付状态
        /// </summary>
        public string fldPayState { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal fldServiceCharge { get; set; }

        /// <summary>
        /// 实际支付金额
        /// </summary>
        public decimal fldActualAmount { get; set; }

        /// <summary>
        /// 账户名
        /// </summary>
        [StringLength(50)]
        public string fldAccountname { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [StringLength(50)]
        public string fldBankCardId { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [StringLength(50)]
        public string fldBankName { get; set; }

        /// <summary>
        /// 渠道号
        /// </summary>
        [StringLength(50)]
        public string fldChannelID { get; set; }

        /// <summary>
        /// 发起方IP
        /// </summary>
        [StringLength(50)]
        public string fldLaunchIP { get; set; }

        /// <summary>
        /// 异步通知地址
        /// </summary>
        [StringLength(50)]
        public string fldNotice { get; set; }

        /// <summary>
        /// 状态变化时间
        /// </summary>
        public DateTime fldchangstautetime { get; set; }

        /// <summary>
        /// 交易时间
        /// </summary>
        public DateTime fldtransactiontime { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal fldRtefundAmount { get; set; }

        /// <summary>
        /// 银行类型
        /// </summary>
        [StringLength(50)]
        public string fldBankType { get; set; }

        /// <summary>
        /// 商户结算金额
        /// </summary>
        public decimal fldSettlementAmount { get; set; }

        /// <summary>
        /// 开户行所在市
        /// </summary>
        public string fldBankcity { get; set; }

        /// <summary>
        /// 银行省份
        /// </summary>
        public string fldBankprovince { get; set; }

        /// <summary>
        /// 银行支行
        /// </summary>
        public string fldBankbranch { get; set; }
        
        /// <summary>
        /// 预留电话
        /// </summary>
        public string fldBankTelephoneNo { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string fldIdCard { get; set; }

       /// <summary>
       /// 银行卡类型
       /// </summary>
        public string fldCardType { get; set; }

        [Timestamp]
        public byte[] VersionNum { get; set; }
    }
}

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
        /// ����ʱ��
        /// </summary>
        public DateTime fldCreateTime { get; set; }

        /// <summary>
        /// ������ˮ��
        /// </summary>
        [StringLength(50)]
        public string fldtransactionnum { get; set; }

        /// <summary>
        /// ������ˮ��
        /// </summary>
        [StringLength(50)]
        public string fldChannelnum { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [StringLength(50)]
        public string fldOrdernum { get; set; }

        /// <summary>
        /// �̻���
        /// </summary>
        [StringLength(50)]
        public string fldMerchID { get; set; }

        /// <summary>
        /// �������
        /// </summary>

        public decimal fldPayAmount { get; set; }

        /// <summary>
        /// ����״̬
        /// </summary>
        public string fldPayState { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public decimal fldServiceCharge { get; set; }

        /// <summary>
        /// ʵ��֧�����
        /// </summary>
        public decimal fldActualAmount { get; set; }

        /// <summary>
        /// �˻���
        /// </summary>
        [StringLength(50)]
        public string fldAccountname { get; set; }

        /// <summary>
        /// ���п���
        /// </summary>
        [StringLength(50)]
        public string fldBankCardId { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [StringLength(50)]
        public string fldBankName { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [StringLength(50)]
        public string fldChannelID { get; set; }

        /// <summary>
        /// ����IP
        /// </summary>
        [StringLength(50)]
        public string fldLaunchIP { get; set; }

        /// <summary>
        /// �첽֪ͨ��ַ
        /// </summary>
        [StringLength(50)]
        public string fldNotice { get; set; }

        /// <summary>
        /// ״̬�仯ʱ��
        /// </summary>
        public DateTime fldchangstautetime { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime fldtransactiontime { get; set; }

        /// <summary>
        /// �˿���
        /// </summary>
        public decimal fldRtefundAmount { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [StringLength(50)]
        public string fldBankType { get; set; }

        /// <summary>
        /// �̻�������
        /// </summary>
        public decimal fldSettlementAmount { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        public string fldBankcity { get; set; }

        /// <summary>
        /// ����ʡ��
        /// </summary>
        public string fldBankprovince { get; set; }

        /// <summary>
        /// ����֧��
        /// </summary>
        public string fldBankbranch { get; set; }
        
        /// <summary>
        /// Ԥ���绰
        /// </summary>
        public string fldBankTelephoneNo { get; set; }

        /// <summary>
        /// ���֤
        /// </summary>
        public string fldIdCard { get; set; }

       /// <summary>
       /// ���п�����
       /// </summary>
        public string fldCardType { get; set; }

        [Timestamp]
        public byte[] VersionNum { get; set; }
    }
}

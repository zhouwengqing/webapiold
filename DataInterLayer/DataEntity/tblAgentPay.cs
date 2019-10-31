namespace DDYZ.Ensis.Presistence.DataEntity
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

        public DateTime fldCreateTime { get; set; }

        
        [StringLength(50)]
        public string fldtransactionnum { get; set; }

      
        [StringLength(50)]
        public string fldChannelnum { get; set; }

      
        [StringLength(50)]
        public string fldOrdernum { get; set; }

      
        [StringLength(50)]
        public string fldMerchID { get; set; }

      
        public decimal fldPayAmount { get; set; }

    
        [StringLength(50)]
        public string fldPayState { get; set; }

        
        public decimal fldServiceCharge { get; set; }

        public decimal fldActualAmount { get; set; }

       
        [StringLength(50)]
        public string fldAccountname { get; set; }

       
        [StringLength(50)]
        public string fldBankCardId { get; set; }

      
        [StringLength(50)]
        public string fldBankName { get; set; }

       
        [StringLength(50)]
        public string fldChannelID { get; set; }

       
        [StringLength(50)]
        public string fldLaunchIP { get; set; }

     
        [StringLength(50)]
        public string fldNotice { get; set; }

        public DateTime fldchangstautetime { get; set; }

      
        public DateTime fldtransactiontime { get; set; }

      
        public decimal fldRtefundAmount { get; set; }

      
        [StringLength(50)]
        public string fldBankType { get; set; }

      
        public decimal fldSettlementAmount { get; set; }

     
        [StringLength(50)]
        public string fldBankcity { get; set; }

      
        [StringLength(50)]
        public string fldBankprovince { get; set; }

        
        [StringLength(50)]
        public string fldBankbranch { get; set; }

        
        [StringLength(50)]
        public string fldBankTelephoneNo { get; set; }

       
        [StringLength(50)]
        public string fldIdCard { get; set; }

      
        [StringLength(50)]
        public string fldCardType { get; set; }

      
        [Timestamp]
        public byte[] VersionNum { get; set; }
    }
}

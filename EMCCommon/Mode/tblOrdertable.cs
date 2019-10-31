namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrdertable")]
    public partial class tblOrdertable
    {
        [Key]
        public int fldAutoID { get; set; }

        public DateTime fldCreatetime { get; set; }

       
        [StringLength(80)]
        public string fldtransactionnum { get; set; }

    
        [StringLength(80)]
        public string fldChannelnum { get; set; }

        [StringLength(80)]
        public string fldOrdernum { get; set; }

        public decimal fldOrderAmount { get; set; }
  
        public decimal fldRtefundAmount { get; set; }

    
        [StringLength(50)]
        public string fldMerchID { get; set; }

      
        [StringLength(50)]
        public string fldOrederdetailed { get; set; }

        [StringLength(50)]
        public string fldRateName { get; set; }

      
        [StringLength(50)]
        public string fldRateCode { get; set; }

       
        [StringLength(50)]
        public string fldChannelType { get; set; }

     
        [StringLength(50)]
        public string fldChannelID { get; set; }

        public DateTime? fldOrderInvalid { get; set; }

       
        [StringLength(50)]
        public string fldNotice { get; set; }

        
        [StringLength(50)]
        public string fldLaunchIP { get; set; }

       
        [StringLength(50)]
        public string fldStaute { get; set; }

        public DateTime? fldchangstautetime { get; set; }

        public DateTime? fldtransactiontime { get; set; }

      
        public decimal fldSettlement { get; set; }

      
        public decimal fldServiceCharge { get; set; }

     
        public byte[] VersionNum { get; set; }
    }
}

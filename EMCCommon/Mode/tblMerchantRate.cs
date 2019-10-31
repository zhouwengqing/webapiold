namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMerchantRate")]
    public partial class tblMerchantRate
    {
        [Key]
     
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string fldMerchID { get; set; }

        
        [StringLength(50)]
        public string fldRateCode { get; set; }

      
        [StringLength(50)]
        public string fldENName { get; set; }

  
     
        public decimal fldRate { get; set; }

        [StringLength(200)]
        public string fldRemark { get; set; }
    }
}

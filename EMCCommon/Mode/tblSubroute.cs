namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSubroute")]
    public partial class tblSubroute
    {
        [Key]
        
        public int fldAutoID { get; set; }

     
        [StringLength(50)]
        public string fldGatewaynumber { get; set; }

      
        [StringLength(50)]
        public string fldType { get; set; }

       
        [StringLength(50)]
        public string fldRateCode { get; set; }

       
        [StringLength(50)]
        public string fldPayType { get; set; }

        
        public decimal fldMinmoney { get; set; }

       
        public decimal fldMaxmoney { get; set; }

        [StringLength(50)]
        public string fldWeight { get; set; }

       
        public bool fldState { get; set; }

      
        public string fldProhibitMerchant { get; set; }

        [StringLength(50)]
        public string fldEncryptionWay { get; set; }
    }
}

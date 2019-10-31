namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbleMerchant")]
    public partial class tbleMerchant
    {
        [Key]
       
        public int fldAutoID { get; set; }

        
        [StringLength(200)]
        public string fldMerchID { get; set; }

      
        [StringLength(200)]
        public string fldMerchName { get; set; }

      
        [StringLength(50)]
        public string fldContacts { get; set; }

        [StringLength(50)]
        public string fldPhone { get; set; }

     
        public DateTime fldCreateTime { get; set; }

       
        [StringLength(50)]
        public string fldIPaddress { get; set; }

     
        [StringLength(50)]
        public string fldIdCare { get; set; }

       
        [StringLength(50)]
        public string fldAgent { get; set; }

      
        [StringLength(50)]
        public string fldPayPass { get; set; }

        
        [StringLength(50)]
        public string fldMaPass { get; set; }

        [StringLength(200)]
        public string fldRemark { get; set; }

       
        public bool fldisstand { get; set; }

       
        [StringLength(500)]
        public string fldSecretKey { get; set; }
    }
}

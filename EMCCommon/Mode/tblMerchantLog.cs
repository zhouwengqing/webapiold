namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMerchantLog")]
    public partial class tblMerchantLog
    {
        [Key]
       
        public int fldAutoID { get; set; }

     
        public DateTime fldLoginTime { get; set; }

     
        [StringLength(50)]
        public string fldLoginCity { get; set; }

      
        [StringLength(50)]
        public string fldLoginIP { get; set; }

       
        [StringLength(50)]
        public string fldMerchant { get; set; }
    }
}

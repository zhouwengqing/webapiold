namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbleRate")]
    public partial class tbleRate
    {
        [Key]

        public int fldAutoID { get; set; }

      
        [StringLength(50)]
        public string fldRateCode { get; set; }

     
        [StringLength(50)]
        public string fldRateName { get; set; }

        [StringLength(50)]
        public string fldENName { get; set; }

        [StringLength(200)]
        public string fldRemark { get; set; }
    }
}

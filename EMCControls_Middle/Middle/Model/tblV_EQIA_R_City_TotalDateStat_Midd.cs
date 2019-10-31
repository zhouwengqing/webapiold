namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblV_EQIA_R_City_TotalDateStat_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [Required]
        [StringLength(10)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [Required]
        [StringLength(10)]
        public string fldTimeType { get; set; }

        [Required]
        [StringLength(20)]
        public string fldAppDate { get; set; }

        [StringLength(4)]
        public string fldSumCount { get; set; }

        [StringLength(4)]
        public string fldCount { get; set; }

        [StringLength(4)]
        public string fldYLCount { get; set; }

        [StringLength(4)]
        public string fldYCount { get; set; }

        [StringLength(4)]
        public string fldLCount { get; set; }

        [StringLength(4)]
        public string fldQDCount { get; set; }

        [StringLength(4)]
        public string fldZDCount { get; set; }

        [StringLength(4)]
        public string fldZZDCount { get; set; }

        [StringLength(4)]
        public string fldYZCount { get; set; }

        [StringLength(10)]
        public string fldWPI { get; set; }

        [StringLength(10)]
        public string fldMCPI { get; set; }

        [StringLength(100)]
        public string fldCFI { get; set; }

        [StringLength(18)]
        public string fldLevel { get; set; }
    }
}

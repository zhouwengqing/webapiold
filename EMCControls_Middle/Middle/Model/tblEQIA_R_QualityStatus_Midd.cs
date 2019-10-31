namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_R_QualityStatus_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(12)]
        public string fldSTCode { get; set; }

        [StringLength(60)]
        public string fldSTName { get; set; }

        [StringLength(30)]
        public string fldPCode { get; set; }

        [StringLength(60)]
        public string fldPName { get; set; }

        [StringLength(10)]
        public string fldTimeType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldMonth { get; set; }

        [StringLength(10)]
        public string fldSumCount { get; set; }

        [StringLength(10)]
        public string fldCount { get; set; }

        [StringLength(10)]
        public string fldYCount { get; set; }

        [StringLength(10)]
        public string fldYScale { get; set; }

        [StringLength(10)]
        public string fldLCount { get; set; }

        [StringLength(10)]
        public string fldLScale { get; set; }

        [StringLength(10)]
        public string fldYLCount { get; set; }

        [StringLength(10)]
        public string fldYLScale { get; set; }

        [StringLength(10)]
        public string fldQDCount { get; set; }

        [StringLength(10)]
        public string fldQDScale { get; set; }

        [StringLength(10)]
        public string fldZDCount { get; set; }

        [StringLength(10)]
        public string fldZDScale { get; set; }

        [StringLength(10)]
        public string fldZZDCount { get; set; }

        [StringLength(10)]
        public string fldZZDScale { get; set; }

        [StringLength(10)]
        public string fldYZCount { get; set; }

        [StringLength(10)]
        public string fldYZScale { get; set; }
    }
}

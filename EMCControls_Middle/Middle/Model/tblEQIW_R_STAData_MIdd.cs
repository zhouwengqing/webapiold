namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_STAData_MIdd
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(15)]
        public string fldSTACode { get; set; }

        [StringLength(50)]
        public string fldSTAName { get; set; }

        [StringLength(50)]
        public string fldSTAInfoDby { get; set; }

        [StringLength(20)]
        public string fldStatus { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldMonth { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldDay { get; set; }

        [StringLength(8)]
        public string fldTime { get; set; }

        [StringLength(10)]
        public string fldPh { get; set; }

        [StringLength(10)]
        public string fldPhLevel { get; set; }

        [StringLength(10)]
        public string fldDO { get; set; }

        [StringLength(10)]
        public string fldDOLevel { get; set; }

        [StringLength(10)]
        public string fldCODMn { get; set; }

        [StringLength(10)]
        public string fldCODMnLevel { get; set; }

        [StringLength(10)]
        public string fldNH4N { get; set; }

        [StringLength(10)]
        public string fldNH4NLevel { get; set; }

        [StringLength(10)]
        public string fldTOC { get; set; }

        [StringLength(10)]
        public string fldTOCLevel { get; set; }
    }
}

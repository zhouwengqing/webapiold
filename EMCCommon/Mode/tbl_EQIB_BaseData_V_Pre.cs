namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_EQIB_BaseData_V_Pre
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldSTName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldRTCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldRTName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLons { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLone { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLats { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMon { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldDay { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldSWFDvalue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldZBFGvalue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldSWMDvalue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldTDTHvalue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldRLGRvalue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldXYSTvalue { get; set; }

        [StringLength(500)]
        public string fldRemark { get; set; }

        public short fldFlag { get; set; }

        public short fldImport { get; set; }

        public int fldCityID_Operate { get; set; }

        [StringLength(100)]
        public string fldCityID_Submit { get; set; }

        public int fldUserID { get; set; }

        public DateTime fldDate_Operate { get; set; }

        [StringLength(50)]
        public string fldBatch { get; set; }

        public int fldDeleteState { get; set; }
    }
}

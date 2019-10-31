namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_WS_Basedata_V_Pre
    {
        [Key]
        public long fldAutoID { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(12)]
        public string fldCCode { get; set; }

        [Required]
        [StringLength(20)]
        public string fldVCode { get; set; }

        [Required]
        [StringLength(30)]
        public string fldRSCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLon { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLat { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMonth { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldDay { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld997 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld998 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld316 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld311 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld302 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld317 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld461 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld313 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld330 { get; set; }

        [StringLength(500)]
        public string fldRemark { get; set; }

        public short fldFlag { get; set; }

        public short fldImport { get; set; }

        public int fldCityID_Operate { get; set; }

        [Required]
        [StringLength(100)]
        public string fldCityID_Submit { get; set; }

        public DateTime fldDate_Operate { get; set; }

        public int fldUserID { get; set; }

        public short fldSource { get; set; }

        [Required]
        [StringLength(50)]
        public string fldBatch { get; set; }

        public int fldDeleteState { get; set; }
    }
}

namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_Section
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(12)]
        public string fldSTCode { get; set; }

        [StringLength(30)]
        public string fldSTName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYear { get; set; }

        [StringLength(12)]
        public string fldRCode { get; set; }

        [StringLength(1000)]
        public string fldRName { get; set; }

        [StringLength(20)]
        public string fldRSCode { get; set; }

        [StringLength(1000)]
        public string fldRSName { get; set; }

        [StringLength(1000)]
        public string fldRSTown { get; set; }

        public short? fldRSDWAF { get; set; }

        [StringLength(1000)]
        public string fldRSWaterWork { get; set; }

        public short? fldSCategory { get; set; }

        public short? fldSType { get; set; }

        public short? fldSLevel { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLOD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLOM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLOS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLAD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLAM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLAS { get; set; }

        public bool? fldState { get; set; }

        public int? fldSort { get; set; }

        [StringLength(200)]
        public string fldRiverBasin { get; set; }

        [StringLength(50)]
        public string fldRVTown { get; set; }

        [StringLength(500)]
        public string fldRCounty { get; set; }

        [StringLength(10)]
        public string fldRSTownCode { get; set; }

        [StringLength(100)]
        public string fldControl { get; set; }

        [StringLength(100)]
        public string fldCTSname { get; set; }

        [StringLength(500)]
        public string fldCDSname { get; set; }

        [StringLength(500)]
        public string fldRiverStream { get; set; }

        public string fldPosition { get; set; }

        public string fldRemark { get; set; }
    }
}

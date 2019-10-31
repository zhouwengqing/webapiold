namespace EMCControls_Middle.Middle.Model_MIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_Section
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

        [StringLength(100)]
        public string fldRName { get; set; }

        [StringLength(20)]
        public string fldRSCode { get; set; }

        [StringLength(100)]
        public string fldRSName { get; set; }

        [StringLength(100)]
        public string fldRSTown { get; set; }

        public short? fldRSFun { get; set; }

        public short? fldRSDWAF { get; set; }

        public short? fldSType { get; set; }

        public short? fldSLevel { get; set; }

        [StringLength(100)]
        public string fldLOD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLOM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLOS { get; set; }

        [StringLength(100)]
        public string fldLAD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLAM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLAS { get; set; }

        public bool? fldState { get; set; }

        public int? fldSort { get; set; }

        [StringLength(2000)]
        public string fldWaterArea { get; set; }

        public short? fldSCategory { get; set; }

        [StringLength(2000)]
        public string fldBSTCode { get; set; }

        [StringLength(2000)]
        public string fldBYN { get; set; }

        public string fldRemark { get; set; }

        [StringLength(60)]
        public string fldOperators { get; set; }

        [StringLength(70)]
        public string fldManagedStation { get; set; }

        [StringLength(2000)]
        public string fldPicPath { get; set; }

        [StringLength(2000)]
        public string fldRSWaterWork { get; set; }

        [StringLength(2000)]
        public string fldAttribute { get; set; }

        public short? fldMBWAF { get; set; }

        [StringLength(100)]
        public string fldRVTown { get; set; }

        [StringLength(12)]
        public string fldPJcode { get; set; }

        [StringLength(30)]
        public string fldPJname { get; set; }

        [StringLength(20)]
        public string fldSDcode { get; set; }

        [StringLength(100)]
        public string fldSDname { get; set; }

        [StringLength(20)]
        public string fldRSTownCode { get; set; }

        public string fldControl { get; set; }

        [StringLength(2000)]
        public string fldSYTown { get; set; }

        [StringLength(2000)]
        public string fldXYTown { get; set; }

        public string fldRiverStream { get; set; }

        public string fldFunType { get; set; }

        public string fldPosition { get; set; }

        [StringLength(2000)]
        public string fldkhcityname { get; set; }

        [StringLength(2000)]
        public string fldkhtownname { get; set; }

        [StringLength(2000)]
        public string fldkhwaterarea { get; set; }

        [StringLength(2000)]
        public string fldrlevel { get; set; }

        [StringLength(2000)]
        public string fldrldest { get; set; }

        [StringLength(2000)]
        public string fldrfunction { get; set; }

        public short? fldkhscategory { get; set; }

        [StringLength(50)]
        public string fldSDcitycode { get; set; }

        [StringLength(50)]
        public string fldSDcityname { get; set; }

        [StringLength(50)]
        public string fldrcodeback { get; set; }

        [StringLength(500)]
        public string fldrnameback { get; set; }

        [StringLength(50)]
        public string fldunmointor { get; set; }

        public int? fldFun2020 { get; set; }

        [StringLength(100)]
        public string fldFun2020Name { get; set; }

        [StringLength(200)]
        public string fldUnionCZ { get; set; }

        [StringLength(200)]
        public string fldDBLtown { get; set; }

        [NotMapped]
        public short? fldReportTimes { get; set; }

        [StringLength(50)]
        public string fldTimeLimit { get; set; }

        [StringLength(100)]
        public string fldPJCode_CWQI { get; set; }

        [StringLength(100)]
        public string fldCWQI_rscode { get; set; }

        [StringLength(100)]
        public string fldFunTen { get; set; }

        [NotMapped]
        [StringLength(20)]
        public string fldFun2019 { get; set; }
    }
}

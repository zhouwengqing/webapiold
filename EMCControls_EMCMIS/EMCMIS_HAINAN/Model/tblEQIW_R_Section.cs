namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Model
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

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(30)]
        public string fldSTName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldYear { get; set; }

        [Required]
        [StringLength(12)]
        public string fldRCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRName { get; set; }

        [Required]
        [StringLength(20)]
        public string fldRSCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSName { get; set; }

        [StringLength(50)]
        public string fldDisc { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSTown { get; set; }

        public short fldRSFun { get; set; }

        public short fldRSDWAF { get; set; }

        public short fldSType { get; set; }

        public short fldSLevel { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLOD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLOM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLOS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLAD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLAM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLAS { get; set; }

        public bool fldState { get; set; }

        public int fldSort { get; set; }

        [Required]
        [StringLength(100)]
        public string fldWaterArea { get; set; }

        public short fldSCategory { get; set; }

        [Required]
        [StringLength(100)]
        public string fldBSTCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldBYN { get; set; }

        [Required]
        [StringLength(200)]
        public string fldRemark { get; set; }

        [Required]
        [StringLength(60)]
        public string fldOperators { get; set; }

        [Required]
        [StringLength(60)]
        public string fldManagedStation { get; set; }

        [Required]
        [StringLength(2000)]
        public string fldPicPath { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSWaterWork { get; set; }

        [Required]
        [StringLength(200)]
        public string fldAttribute { get; set; }

        [Required]
        [StringLength(100)]
        public string fldValleyName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldProvinceName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldProvinceCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSAreaName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSAreaCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSReachName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSReachCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSRiverLevel { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSRiverLevelCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldCRSL { get; set; }

        [Required]
        [StringLength(50)]
        public string fldRSAttr { get; set; }

        [Required]
        [StringLength(100)]
        public string fldMonWay { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSControlL { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSControlLCode { get; set; }

        public int fldRSCount { get; set; }

        [Required]
        [StringLength(100)]
        public string fldMainCity { get; set; }

        [Required]
        [StringLength(50)]
        public string fldRSBoundary { get; set; }

        [Required]
        [StringLength(100)]
        public string fldMarkRReg { get; set; }

        [Required]
        [StringLength(100)]
        public string fldModelArea { get; set; }

        [Required]
        [StringLength(100)]
        public string fldUPRNAME { get; set; }

        [Required]
        [StringLength(100)]
        public string fldUPRCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSLDC { get; set; }

        [Required]
        [StringLength(100)]
        public string fldFunAim { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldRSLength { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSMFlow { get; set; }

        [Required]
        [StringLength(100)]
        public string fldStatFlag { get; set; }

        [Required]
        [StringLength(100)]
        public string fldUpRptFlag { get; set; }

        [Required]
        [StringLength(60)]
        public string fldRChangeCode { get; set; }

        [Required]
        [StringLength(20)]
        public string fldRSChangeCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldRSAttr1 { get; set; }

        [Required]
        [StringLength(50)]
        public string fldRSAttr2 { get; set; }

        [Required]
        [StringLength(50)]
        public string fldRSAttr3 { get; set; }

        [Required]
        [StringLength(50)]
        public string fldSetDate { get; set; }

        [Required]
        [StringLength(50)]
        public string fldCancelDate { get; set; }

        [Required]
        [StringLength(50)]
        public string fldInspectPName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldInspectCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldSOrder { get; set; }

        [Required]
        [StringLength(100)]
        public string fldInspectTimes { get; set; }

        [Required]
        [StringLength(100)]
        public string fldSeaAreaCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldSeaAreaName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldSeaSpaceCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldSeaSapceName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldFjordCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldFjordName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldSeaFunName { get; set; }

        [StringLength(20)]
        public string fldIsControl { get; set; }

        [StringLength(20)]
        public string fldInConStarTime { get; set; }

        [StringLength(20)]
        public string fldControlCG { get; set; }

        [StringLength(20)]
        public string fldConStarTime { get; set; }

        [StringLength(20)]
        public string fldConEntTime { get; set; }

        [StringLength(20)]
        public string fldTransferTime { get; set; }

        [StringLength(20)]
        public string fldTownR { get; set; }

        [StringLength(20)]
        public string fldTownRWater { get; set; }

        [Required]
        [StringLength(100)]
        public string fldPJCode_CWQI { get; set; }

        [Required]
        [StringLength(100)]
        public string fldCWQI_rscode { get; set; }

        public int fldFun2020 { get; set; }

        [StringLength(50)]
        public string fldOldCityCode { get; set; }

        [StringLength(50)]
        public string fldOldCityName { get; set; }
    }
}

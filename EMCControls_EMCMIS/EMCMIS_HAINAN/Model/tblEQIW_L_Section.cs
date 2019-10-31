namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_L_Section
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
        public string fldLCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLName { get; set; }

        [Required]
        [StringLength(20)]
        public string fldLSCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLSName { get; set; }

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
        [StringLength(200)]
        public string fldRemark { get; set; }

        [Required]
        [StringLength(50)]
        public string fldLSort { get; set; }

        [Required]
        [StringLength(50)]
        public string fldLType { get; set; }

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
        [StringLength(50)]
        public string fldLSLNAME { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLSLCODE { get; set; }

        [Required]
        [StringLength(100)]
        public string fldCRSL { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLLRiver { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLLRiverCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLSAttr { get; set; }

        [Required]
        [StringLength(100)]
        public string fldMonWay { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLSControlLName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLSControlL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLSArea { get; set; }

        [Required]
        [StringLength(100)]
        public string fldMainCity { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSBoundary { get; set; }

        [Required]
        [StringLength(50)]
        public string fldMainFun { get; set; }

        [Required]
        [StringLength(4)]
        public string fldMarkRReg { get; set; }

        [Required]
        [StringLength(100)]
        public string fldModelArea { get; set; }

        [Required]
        [StringLength(100)]
        public string fldUPRNAME { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLDC { get; set; }

        [Required]
        [StringLength(100)]
        public string fldFunAim { get; set; }

        [Required]
        [StringLength(100)]
        public string fldStatFlag { get; set; }

        [Required]
        [StringLength(100)]
        public string fldUpRptFlag { get; set; }

        [Required]
        [StringLength(50)]
        public string fldLChangeCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLSChangeCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLSAttr1 { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLSAttr2 { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLSAttr3 { get; set; }

        [Required]
        [StringLength(100)]
        public string fldLSType { get; set; }

        [Required]
        [StringLength(100)]
        public string fldMainDrink { get; set; }

        [Required]
        [StringLength(100)]
        public string fldSetDate { get; set; }

        [Required]
        [StringLength(100)]
        public string fldCancelDate { get; set; }

        [Required]
        [StringLength(100)]
        public string fldInspectPName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldInspectPCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldOldPointName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldOldSTCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldOldSTName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldOrder { get; set; }

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

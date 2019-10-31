namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIS_W_Point
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldSeaAreaCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldSeaAreaName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldSeaRegionCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldSeaRegionName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldProvinceCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldProvinceName { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(30)]
        public string fldSTName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldYear { get; set; }

        [Required]
        [StringLength(50)]
        public string fldPCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldPName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldFun { get; set; }

        public short fldPLevel { get; set; }

        [Required]
        [StringLength(20)]
        public string fldLOD { get; set; }

        [Required]
        [StringLength(20)]
        public string fldLOM { get; set; }

        [Required]
        [StringLength(20)]
        public string fldLOS { get; set; }

        [Required]
        [StringLength(20)]
        public string fldLAD { get; set; }

        [Required]
        [StringLength(20)]
        public string fldLAM { get; set; }

        [Required]
        [StringLength(20)]
        public string fldLAS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldPArea { get; set; }

        [Required]
        [StringLength(200)]
        public string fldAttribute { get; set; }

        public int fldSort { get; set; }

        [Required]
        [StringLength(60)]
        public string fldManagedStation { get; set; }

        [Required]
        [StringLength(2000)]
        public string fldPicPath { get; set; }

        [Required]
        [StringLength(60)]
        public string fldOperators { get; set; }

        [Required]
        [StringLength(2000)]
        public string fldVideoPath { get; set; }

        [StringLength(20)]
        public string fldPType { get; set; }

        [StringLength(20)]
        public string fldPTypeNAME { get; set; }

        [StringLength(100)]
        public string fldPAttr { get; set; }

        [StringLength(100)]
        public string fldPControlL { get; set; }

        [StringLength(4)]
        public string fldMarkRReg { get; set; }

        [StringLength(50)]
        public string fldPLDC { get; set; }

        [StringLength(4)]
        public string fldFunAim { get; set; }

        [StringLength(50)]
        public string fldPAttr1 { get; set; }

        [StringLength(50)]
        public string fldPAttr2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLongitude { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLatitude { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldArea { get; set; }

        [StringLength(50)]
        public string fldDisc { get; set; }

        public int? fldDiscID { get; set; }

        public bool? fldCalcAQI { get; set; }

        [StringLength(50)]
        public string fldOldCityCode { get; set; }

        [StringLength(50)]
        public string fldOldCityName { get; set; }
    }
}

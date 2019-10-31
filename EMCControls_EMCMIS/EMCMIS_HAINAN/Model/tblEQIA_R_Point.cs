namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_R_Point
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
        public string fldPCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldPName { get; set; }

        public short fldPType { get; set; }

        public short fldPLevel { get; set; }

        [Required]
        [StringLength(50)]
        public string fldDisc { get; set; }

        [Required]
        [StringLength(20)]
        public string fldLName { get; set; }

        [Required]
        [StringLength(12)]
        public string fldLCode { get; set; }

        public short fldRLevel { get; set; }

        public short fldAcidP { get; set; }

        public short fldSO2Level { get; set; }

        public short fldAcidLevel { get; set; }

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

        [Required]
        [StringLength(200)]
        public string fldAttribute { get; set; }

        public int fldSort { get; set; }

        [Required]
        [StringLength(200)]
        public string fldRemark { get; set; }

        public short fldFrequency { get; set; }

        [Required]
        [StringLength(3000)]
        public string fldVideoPath { get; set; }

        [Required]
        [StringLength(3000)]
        public string fldPicPath { get; set; }

        [Required]
        [StringLength(100)]
        public string fldPAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string fldPAddressCode { get; set; }

        [Required]
        [StringLength(10)]
        public string fldMainCity { get; set; }

        [Required]
        [StringLength(20)]
        public string fldPArea { get; set; }

        [Required]
        [StringLength(80)]
        public string fldAQLSTDName { get; set; }

        [Required]
        [StringLength(80)]
        public string fldSTDName { get; set; }

        [Required]
        [StringLength(10)]
        public string fldSTDLevel { get; set; }

        [Required]
        [StringLength(20)]
        public string fldPAreaCatalog { get; set; }

        [Required]
        [StringLength(20)]
        public string fldPFunReg { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldPLandHign { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldRelateHign { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldAcreage { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldPeopleNum { get; set; }

        [Required]
        [StringLength(20)]
        public string fldMonWays { get; set; }

        [Required]
        [StringLength(100)]
        public string fldSetDate { get; set; }

        [Required]
        [StringLength(100)]
        public string fldEndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string fldCityCheck { get; set; }

        [Required]
        [StringLength(20)]
        public string fldOtherType { get; set; }

        [Required]
        [StringLength(20)]
        public string fldOrder { get; set; }

        [StringLength(50)]
        public string fldOldCityCode { get; set; }

        [StringLength(50)]
        public string fldOldCityName { get; set; }
    }
}

namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_P_Point
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
        public string fldPCode { get; set; }

        [StringLength(100)]
        public string fldPName { get; set; }

        public short? fldPLevel { get; set; }

        [StringLength(12)]
        public string fldDisc { get; set; }

        [StringLength(20)]
        public string fldLName { get; set; }

        [StringLength(12)]
        public string fldLCode { get; set; }

        public short? fldRLevel { get; set; }

        public short? fldAcidP { get; set; }

        public short? fldSO2Level { get; set; }

        public short? fldAcidLevel { get; set; }

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

        [StringLength(200)]
        public string fldAttribute { get; set; }

        public int? fldSort { get; set; }

        [StringLength(200)]
        public string fldRemark { get; set; }

        [StringLength(100)]
        public string fldPAddress { get; set; }

        [StringLength(10)]
        public string fldMainCity { get; set; }

        [StringLength(20)]
        public string fldPArea { get; set; }

        [StringLength(20)]
        public string fldPAreaCatalog { get; set; }

        [StringLength(20)]
        public string fldPFunReg { get; set; }

        [StringLength(50)]
        public string fldPAreaFun { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldPLandHign { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldRelateHign { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldAcreage { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldPeopleNum { get; set; }

        [StringLength(20)]
        public string fldMonWays { get; set; }

        [StringLength(100)]
        public string fldSetDate { get; set; }

        [StringLength(100)]
        public string fldEndDate { get; set; }

        [StringLength(100)]
        public string fldOldPName { get; set; }

        [StringLength(50)]
        public string fldInspectPName { get; set; }

        [StringLength(50)]
        public string fldOldCityCode { get; set; }

        [StringLength(50)]
        public string fldOldCityName { get; set; }
    }
}

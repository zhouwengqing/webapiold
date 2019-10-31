namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQISO_Point
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(20)]
        public string fldSTName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldYear { get; set; }

        [Required]
        [StringLength(12)]
        public string fldPCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldGroundType { get; set; }

        [Required]
        [StringLength(500)]
        public string fldSoiltexture { get; set; }

        [Required]
        [StringLength(20)]
        public string fldTerrain { get; set; }

        [Required]
        [StringLength(20)]
        public string fldVegetationType { get; set; }

        [Required]
        [StringLength(20)]
        public string fldCropKind { get; set; }

        public int fldProtectedLevel { get; set; }

        [Required]
        [StringLength(20)]
        public string fldFarmWay { get; set; }

        [Required]
        [StringLength(20)]
        public string fldWateringWay { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldHeight { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldDistance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldSlope { get; set; }

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

        public short fldPLevel { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLAS { get; set; }

        [Required]
        [StringLength(20)]
        public string fldSpareOne { get; set; }

        [Required]
        [StringLength(20)]
        public string fldSparTwo { get; set; }

        [Required]
        [StringLength(20)]
        public string fldSparThree { get; set; }

        [Required]
        [StringLength(20)]
        public string fldSparFour { get; set; }

        [Required]
        [StringLength(20)]
        public string fldSparFive { get; set; }

        [Required]
        [StringLength(500)]
        public string fldPName { get; set; }

        [Required]
        [StringLength(200)]
        public string fldAttribute { get; set; }

        public int fldSort { get; set; }

        public int fldFlag { get; set; }

        public int fldBReport { get; set; }

        public int fldAreaType { get; set; }

        [Required]
        [StringLength(12)]
        public string fldEntCode { get; set; }

        [Required]
        [StringLength(500)]
        public string fldEntName { get; set; }

        public short? fldMonitorTypeId { get; set; }

        [StringLength(60)]
        public string fldMonitorTypeName { get; set; }

        public int? fldSampleType { get; set; }

        [StringLength(60)]
        public string fldSampleName { get; set; }

        public int? fldAppType { get; set; }
    }
}

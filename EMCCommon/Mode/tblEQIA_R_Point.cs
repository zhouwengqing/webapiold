namespace EMCCommon.Mode
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
        [StringLength(12)]
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
        [StringLength(50)]
        public string fldRSTown { get; set; }

        [Required]
        [StringLength(50)]
        public string fldRVTown { get; set; }

        [Required]
        [StringLength(50)]
        public string fldAutoCoding { get; set; }
    }
}

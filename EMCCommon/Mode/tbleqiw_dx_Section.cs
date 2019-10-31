namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbleqiw_dx_Section
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(100)]
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

        [Required]
        [StringLength(100)]
        public string fldRSTown { get; set; }

        public short fldRSDWAF { get; set; }

        [Required]
        [StringLength(100)]
        public string fldRSWaterWork { get; set; }

        public short fldSCategory { get; set; }

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
        [StringLength(40)]
        public string fldRiverBasin { get; set; }
    }
}

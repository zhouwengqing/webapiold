namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_F_Point
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
        public string fldPName { get; set; }

        [Required]
        [StringLength(20)]
        public string fldStaLod { get; set; }

        [Required]
        [StringLength(20)]
        public string fldStaLad { get; set; }

        [Required]
        public string fldStaRef { get; set; }

        [Required]
        [StringLength(12)]
        public string fldNDISC { get; set; }

        [Required]
        [StringLength(12)]
        public string fldLCODE { get; set; }

        [Required]
        [StringLength(500)]
        public string fldLNAME { get; set; }

        [Required]
        [StringLength(200)]
        public string fldAttribute { get; set; }

        [Required]
        [StringLength(50)]
        public string fldSort { get; set; }

        [Required]
        [StringLength(50)]
        public string fldArea { get; set; }

        [StringLength(50)]
        public string fldhigh { get; set; }

        [Required]
        [StringLength(200)]
        public string fldRemark { get; set; }
    }
}

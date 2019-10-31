namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_IF_EQIA_P_StatData
    {
        [Key]
        public long fldAutoID { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldSTName { get; set; }

        public int fldPCount { get; set; }

        [Required]
        [StringLength(50)]
        public string fldDate { get; set; }

        public int fldTimes { get; set; }

        public int fld56Times { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld56TScale { get; set; }

        [Required]
        [StringLength(50)]
        public string fldRain { get; set; }

        [Required]
        [StringLength(50)]
        public string fld56Rain { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldRScale { get; set; }

        [Required]
        [StringLength(50)]
        public string fldpH { get; set; }

        [Required]
        [StringLength(50)]
        public string fld56pH { get; set; }

        [Required]
        [StringLength(50)]
        public string fld125 { get; set; }

        [Required]
        [StringLength(50)]
        public string fld116 { get; set; }

        [Required]
        [StringLength(50)]
        public string fld117 { get; set; }

        [Required]
        [StringLength(50)]
        public string fld118 { get; set; }

        [Required]
        [StringLength(50)]
        public string fld119 { get; set; }

        [Required]
        [StringLength(50)]
        public string fld120 { get; set; }

        [Required]
        [StringLength(50)]
        public string fld121 { get; set; }

        [Required]
        [StringLength(50)]
        public string fld122 { get; set; }

        [Required]
        [StringLength(50)]
        public string fld123 { get; set; }

        [Required]
        [StringLength(50)]
        public string fld124 { get; set; }

        [Required]
        [StringLength(50)]
        public string fldNSScale { get; set; }

        [Required]
        [StringLength(30)]
        public string fldUpdateTime { get; set; }
    }
}

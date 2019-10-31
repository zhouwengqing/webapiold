namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_IF_EQIN_A_StatData
    {
        [Key]
        public long fldAutoID { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldSTName { get; set; }

        [Required]
        [StringLength(20)]
        public string fldDate { get; set; }

        [Required]
        [StringLength(20)]
        public string fldDN { get; set; }

        public int fldPCount { get; set; }

        [Required]
        [StringLength(50)]
        public string fldWL { get; set; }

        [Required]
        [StringLength(50)]
        public string fldArea { get; set; }

        public int fldOutCount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldScale { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLEQA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMin { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMax { get; set; }

        [Required]
        [StringLength(50)]
        public string fldLevel { get; set; }

        [Required]
        [StringLength(50)]
        public string fldApprise { get; set; }

        [Required]
        [StringLength(30)]
        public string fldUpdateTime { get; set; }
    }
}

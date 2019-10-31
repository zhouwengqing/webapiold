namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_IF_EQIW_D_StatData
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
        [StringLength(12)]
        public string fldRCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldRName { get; set; }

        [Required]
        [StringLength(20)]
        public string fldRSCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldRSName { get; set; }

        [Required]
        [StringLength(20)]
        public string fldWWCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldWWName { get; set; }

        [Required]
        [StringLength(20)]
        public string fldType { get; set; }

        [Required]
        [StringLength(20)]
        public string fldSLevel { get; set; }

        [Required]
        [StringLength(50)]
        public string fldDate { get; set; }

        [Required]
        [StringLength(50)]
        public string fldALLSL { get; set; }

        [Required]
        [StringLength(50)]
        public string fldStdSL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldSLScale { get; set; }

        public int fldAllTimes { get; set; }

        public int fldStdTimes { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldTimeScale { get; set; }

        [Required]
        [StringLength(20)]
        public string fldStage { get; set; }

        [Required]
        [StringLength(20)]
        public string fldStand { get; set; }

        [Required]
        public string fldOverItems { get; set; }

        [Required]
        [StringLength(30)]
        public string fldUpdateTime { get; set; }
    }
}

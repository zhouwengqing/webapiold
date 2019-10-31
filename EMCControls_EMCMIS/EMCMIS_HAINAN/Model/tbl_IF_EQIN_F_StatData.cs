namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_IF_EQIN_F_StatData
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
        [StringLength(50)]
        public string fldDate { get; set; }

        [Required]
        [StringLength(50)]
        public string fldType { get; set; }

        [Required]
        [StringLength(50)]
        public string fld30Ld { get; set; }

        [Required]
        [StringLength(50)]
        public string fld30Ln { get; set; }

        [Required]
        [StringLength(50)]
        public string fld31Ld { get; set; }

        [Required]
        [StringLength(50)]
        public string fld31Ln { get; set; }

        [Required]
        [StringLength(50)]
        public string fld32Ld { get; set; }

        [Required]
        [StringLength(50)]
        public string fld32Ln { get; set; }

        [Required]
        [StringLength(50)]
        public string fld33Ld { get; set; }

        [Required]
        [StringLength(50)]
        public string fld33Ln { get; set; }

        [Required]
        [StringLength(50)]
        public string fld34Ld { get; set; }

        [Required]
        [StringLength(50)]
        public string fld34Ln { get; set; }

        [Required]
        [StringLength(50)]
        public string fld35Ld { get; set; }

        [Required]
        [StringLength(50)]
        public string fld35Ln { get; set; }

        [Required]
        [StringLength(50)]
        public string fldAllLd { get; set; }

        [Required]
        [StringLength(50)]
        public string fldAllLn { get; set; }

        [Required]
        [StringLength(30)]
        public string fldUpdateTime { get; set; }
    }
}

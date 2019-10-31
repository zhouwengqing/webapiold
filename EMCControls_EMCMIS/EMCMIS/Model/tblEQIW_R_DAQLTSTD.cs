namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_DAQLTSTD
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(20)]
        public string fldEdition { get; set; }

        [Required]
        [StringLength(10)]
        public string fldItemCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldST10 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldST20 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldST30 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldST40 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldST50 { get; set; }
    }
}

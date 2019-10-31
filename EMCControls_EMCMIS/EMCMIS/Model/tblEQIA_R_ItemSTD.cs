namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_R_ItemSTD
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(80)]
        public string fldStandardName { get; set; }

        [Required]
        [StringLength(20)]
        public string fldStandardNum { get; set; }

        [Required]
        [StringLength(10)]
        public string fldItemCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldHourSTG1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldHourSTG2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldHourSTG3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldDaySTG1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldDaySTG2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldDaySTG3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldYearSTG1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldYearSTG2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldYearSTG3 { get; set; }
    }
}
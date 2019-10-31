namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIBCD_CategoryInfo
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldPCode { get; set; }

        [Required]
        [StringLength(30)]
        public string fldPName { get; set; }

        [Required]
        [StringLength(30)]
        public string fldTypeCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldTypeName { get; set; }

        [Required]
        [StringLength(30)]
        public string fldOCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldOName { get; set; }

        [Required]
        [StringLength(30)]
        public string fldICode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldIName { get; set; }

        [Required]
        [StringLength(40)]
        public string fldSCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldSName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldGCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldGName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldCCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldCName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldCTypeCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldCTypeName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldCLatinName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldCTName { get; set; }

        public short fldSort { get; set; }

        public short? fldISLarge { get; set; }

        public short? fldISGM { get; set; }
    }
}

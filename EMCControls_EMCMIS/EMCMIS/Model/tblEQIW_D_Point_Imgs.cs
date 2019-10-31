namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_Point_Imgs
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        [Required]
        [StringLength(100)]
        public string fldFileName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldFilePath { get; set; }

        [Required]
        [StringLength(100)]
        public string fldFileSize { get; set; }

        public bool fldFileIsShow { get; set; }
    }
}

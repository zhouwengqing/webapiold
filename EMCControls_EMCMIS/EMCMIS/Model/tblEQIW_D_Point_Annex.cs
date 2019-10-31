namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_Point_Annex
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        [Required]
        public string fldAnnexName { get; set; }

        [Required]
        public string fldAnnexType { get; set; }

        [Required]
        public string fldFileType { get; set; }

        [Required]
        public string fldFileSize { get; set; }

        [Required]
        public string fldFilePath { get; set; }
    }
}

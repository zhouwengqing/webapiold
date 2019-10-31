namespace EMCControls_EMCMIS.EMCMIS.Model.Lap
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblFW_Dictionary
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(100)]
        public string fldTableName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldTableDesc { get; set; }

        [Required]
        [StringLength(100)]
        public string fldFieldName { get; set; }

        [Required]
        [StringLength(100)]
        public string fldFieldDesc { get; set; }

        public int fldShowField { get; set; }

        public int fldSort { get; set; }
    }
}

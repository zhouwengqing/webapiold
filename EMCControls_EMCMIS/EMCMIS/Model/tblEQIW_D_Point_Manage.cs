namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_Point_Manage
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldLicenseNum { get; set; }

        public int? fldReserveDelimit { get; set; }

        [Required]
        [StringLength(50)]
        public string fldReserveNum { get; set; }

        public int? fldIsMonitor { get; set; }

        public int? fldIsPatrol { get; set; }
    }
}

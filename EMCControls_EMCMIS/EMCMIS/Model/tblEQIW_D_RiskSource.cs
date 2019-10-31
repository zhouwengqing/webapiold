namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_RiskSource
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        public DateTime fldCheckDate { get; set; }

        [Required]
        [StringLength(50)]
        public string fldPollutionName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldPollutionType { get; set; }

        [StringLength(50)]
        public string fldlongitude { get; set; }

        [StringLength(50)]
        public string fldLatitude { get; set; }

        [StringLength(200)]
        public string fldRemark { get; set; }
    }
}

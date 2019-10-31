namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_TrafficPoint
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldRoadName { get; set; }

        [StringLength(50)]
        public string fldlongitude { get; set; }

        [StringLength(50)]
        public string fldLatitude { get; set; }

        public int? fldIsTransportation { get; set; }

        public int? fldIsWarning { get; set; }

        public int? fldIsGuardrail { get; set; }

        public int? fldIsEmergencyPool { get; set; }

        public int? fldIsDiversion { get; set; }
    }
}

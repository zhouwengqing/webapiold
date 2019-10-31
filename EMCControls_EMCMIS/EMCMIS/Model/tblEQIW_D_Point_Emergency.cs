namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_Point_Emergency
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        public int? fldIsSpare { get; set; }

        public int? fldIsEmergencyPlan { get; set; }

        public int? fldIsRiskSource { get; set; }
    }
}

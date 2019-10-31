namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_Point_Stage
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        public DateTime? fldDate { get; set; }

        [StringLength(50)]
        public string fldStage { get; set; }

        [StringLength(50)]
        public string fldTSI { get; set; }

        [StringLength(50)]
        public string fldStandardState { get; set; }

        public string fldOverItem { get; set; }

        public string fldOverDescribe { get; set; }
    }
}

namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_StagePropTar
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(200)]
        public string fldValleyName { get; set; }

        [StringLength(100)]
        public string fldTarCla { get; set; }

        [StringLength(30)]
        public string fldkhscategory { get; set; }

        [StringLength(100)]
        public string fldylCla { get; set; }

        [StringLength(10)]
        public string fldYear { get; set; }

        [StringLength(10)]
        public string fldTarVal { get; set; }
    }
}

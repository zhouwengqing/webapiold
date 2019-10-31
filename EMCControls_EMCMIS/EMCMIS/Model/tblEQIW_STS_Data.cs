namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_STS_Data
    {
        [Key]
        public int fldAutoID { get; set; }

        public int? fldNumber { get; set; }

        public string fldTaskName { get; set; }

        public string fldSTName { get; set; }

        public string fldRName { get; set; }

        public string fldRSName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fldDate { get; set; }

        public string fldSAMPH { get; set; }

        public string fldSAMPR { get; set; }
    }
}

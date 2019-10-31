namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_BaseData_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldRCode { get; set; }

        [StringLength(50)]
        public string fldRName { get; set; }

        [StringLength(50)]
        public string fldRSCode { get; set; }

        [StringLength(50)]
        public string fldRSName { get; set; }

        [StringLength(50)]
        public string fldRSC { get; set; }

        public DateTime? fldappdate { get; set; }

        [StringLength(50)]
        public string fldSAMPH { get; set; }

        [StringLength(50)]
        public string fldSAMPR { get; set; }
    }
}

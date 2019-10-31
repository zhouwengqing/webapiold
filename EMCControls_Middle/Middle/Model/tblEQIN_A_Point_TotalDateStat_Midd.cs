namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_A_Point_TotalDateStat_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string fldYear { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldGDCode { get; set; }

        [StringLength(50)]
        public string fldGDNAME { get; set; }

        [StringLength(50)]
        public string fldNSC1 { get; set; }

        [StringLength(50)]
        public string fldNSC2 { get; set; }

        [StringLength(50)]
        public string fldNSC3 { get; set; }

        [StringLength(50)]
        public string fldNSC4 { get; set; }

        [StringLength(50)]
        public string fldNSC5 { get; set; }

        [StringLength(50)]
        public string fldLEQA { get; set; }

        [StringLength(50)]
        public string fldL10A { get; set; }

        [StringLength(50)]
        public string fldL50A { get; set; }

        [StringLength(50)]
        public string fldL90A { get; set; }

        [StringLength(50)]
        public string fldSD { get; set; }
    }
}

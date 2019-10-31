namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_T_Point_TotalDateStat_Midd
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
        public string fldRoadName { get; set; }

        [StringLength(50)]
        public string fldRDCode { get; set; }

        [StringLength(50)]
        public string fldRDName { get; set; }

        [StringLength(50)]
        public string fldPTSArc { get; set; }

        [StringLength(50)]
        public string fldPLen { get; set; }

        [StringLength(50)]
        public string fldPWid { get; set; }

        [StringLength(50)]
        public string fldPTrafic { get; set; }

        [StringLength(50)]
        public string fldLEQA { get; set; }

        [StringLength(50)]
        public string fldL10A { get; set; }

        [StringLength(50)]
        public string fldL50A { get; set; }

        [StringLength(50)]
        public string fldL90A { get; set; }
    }
}

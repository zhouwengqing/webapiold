namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_T_City_TotalDateStat_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public string fldDN { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldYear { get; set; }

        [StringLength(50)]
        public string fldLeqa { get; set; }

        [StringLength(50)]
        public string fldL10 { get; set; }

        [StringLength(50)]
        public string fldL50 { get; set; }

        [StringLength(50)]
        public string fldL90 { get; set; }

        [StringLength(50)]
        public string fldSTCount { get; set; }

        [StringLength(50)]
        public string fldCiCount { get; set; }

        [StringLength(50)]
        public string fldArea { get; set; }

        [StringLength(50)]
        public string fld1Count { get; set; }

        [StringLength(50)]
        public string fld1Scale { get; set; }

        [StringLength(50)]
        public string fld2Count { get; set; }

        [StringLength(50)]
        public string fld2Scale { get; set; }

        [StringLength(50)]
        public string fld3Count { get; set; }

        [StringLength(50)]
        public string fld3Scale { get; set; }

        [StringLength(50)]
        public string fld4Count { get; set; }

        [StringLength(50)]
        public string fld4Scale { get; set; }

        [StringLength(50)]
        public string fld5Count { get; set; }

        [StringLength(50)]
        public string fld5Scale { get; set; }
    }
}

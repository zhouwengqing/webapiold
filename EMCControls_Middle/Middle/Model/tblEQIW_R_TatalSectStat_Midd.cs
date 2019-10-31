namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_TatalSectStat_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(50)]
        public string fldSpaceName { get; set; }

        [StringLength(50)]
        public string fldSpaceType { get; set; }

        [StringLength(10)]
        public string fldTimeType { get; set; }

        [StringLength(20)]
        public string fldAppDate { get; set; }

        [StringLength(10)]
        public string fldRSCount { get; set; }

        [StringLength(10)]
        public string fldStdCount { get; set; }

        [StringLength(10)]
        public string fldStdScale { get; set; }

        [StringLength(10)]
        public string fldFStdCount { get; set; }

        [StringLength(10)]
        public string fldFStdScale { get; set; }

        [StringLength(10)]
        public string fld1Count { get; set; }

        [StringLength(10)]
        public string fld1Scale { get; set; }

        [StringLength(10)]
        public string fld2Count { get; set; }

        [StringLength(10)]
        public string fld2Scale { get; set; }

        [StringLength(10)]
        public string fld3Count { get; set; }

        [StringLength(10)]
        public string fld3Scale { get; set; }

        [StringLength(10)]
        public string fld4Count { get; set; }

        [StringLength(10)]
        public string fld4Scale { get; set; }

        [StringLength(10)]
        public string fld5Count { get; set; }

        [StringLength(10)]
        public string fld5Scale { get; set; }

        [StringLength(10)]
        public string fld6Count { get; set; }

        [StringLength(10)]
        public string fld6Scale { get; set; }

        [StringLength(10)]
        public string fld13Count { get; set; }

        [StringLength(10)]
        public string fld13Scale { get; set; }

        [StringLength(20)]
        public string fldApprise { get; set; }

        [StringLength(16)]
        public string fldFun { get; set; }

        [StringLength(16)]
        public string fldStage { get; set; }

        [StringLength(10)]
        public string fldWPI { get; set; }

        [StringLength(10)]
        public string fldAvgWPI { get; set; }

        [StringLength(16)]
        public string fldWPIApp { get; set; }

        public string fldOverItem { get; set; }

        public string fldOutItem { get; set; }

        public string fldOverItems { get; set; }

        public string fldOutTimes { get; set; }

        public string fldFOutTimes { get; set; }

        [StringLength(10)]
        public string fldRcount { get; set; }
    }
}

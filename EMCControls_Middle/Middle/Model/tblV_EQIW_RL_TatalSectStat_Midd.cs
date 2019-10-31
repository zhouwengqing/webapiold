namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblV_EQIW_RL_TatalSectStat_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(50)]
        public string fldSpaceName { get; set; }

        [StringLength(50)]
        public string fldSpaceType { get; set; }

        [StringLength(20)]
        public string fldSCategory { get; set; }

        [StringLength(10)]
        public string fldTimeType { get; set; }

        [StringLength(20)]
        public string fldAppDate { get; set; }

        [StringLength(16)]
        public string fldFun { get; set; }

        [StringLength(10)]
        public string fldRSCount { get; set; }

        [StringLength(10)]
        public string fldStdCount { get; set; }

        [StringLength(10)]
        public string fldStdScale { get; set; }

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

        [StringLength(10)]
        public string fld1TLICount { get; set; }

        [StringLength(10)]
        public string fld1TLIScale { get; set; }

        [StringLength(10)]
        public string fld2TLICount { get; set; }

        [StringLength(10)]
        public string fld2TLIScale { get; set; }

        [StringLength(10)]
        public string fld3TLICount { get; set; }

        [StringLength(10)]
        public string fld3TLIScale { get; set; }

        [StringLength(10)]
        public string fld4TLICount { get; set; }

        [StringLength(10)]
        public string fld4TLIScale { get; set; }

        [StringLength(10)]
        public string fld5TLICount { get; set; }

        [StringLength(10)]
        public string fld5TLIScale { get; set; }

        [StringLength(16)]
        public string fldStage { get; set; }

        [StringLength(20)]
        public string fldSectionApp { get; set; }

        [StringLength(10)]
        public string fldStand { get; set; }

        [StringLength(10)]
        public string fldScale { get; set; }

        [StringLength(10)]
        public string fldWPI { get; set; }

        [StringLength(10)]
        public string fldAvgWPI { get; set; }

        [StringLength(16)]
        public string fldWPIApp { get; set; }

        public string fldOutItems { get; set; }

        public string fldFOutItems { get; set; }

        public string fldOverItem { get; set; }

        public string fldFOverItem { get; set; }

        public string fldOutItem { get; set; }

        public string fldOverTimes { get; set; }

        [StringLength(10)]
        public string fldCodMn { get; set; }

        [StringLength(10)]
        public string fldPtotal { get; set; }

        [StringLength(10)]
        public string fldTransp { get; set; }

        [StringLength(10)]
        public string fldChla { get; set; }

        [StringLength(10)]
        public string fldNtotal { get; set; }

        [StringLength(10)]
        public string fldTSI { get; set; }

        [StringLength(20)]
        public string fldTSIRange { get; set; }

        [StringLength(10)]
        public string fldTCount { get; set; }

        [StringLength(10)]
        public string fldT1Count { get; set; }

        [StringLength(10)]
        public string fldT1Scale { get; set; }

        [StringLength(10)]
        public string fldT2Count { get; set; }

        [StringLength(10)]
        public string fldT2Scale { get; set; }

        [StringLength(10)]
        public string fldT3Count { get; set; }

        [StringLength(10)]
        public string fldT3Scale { get; set; }

        [StringLength(10)]
        public string fldT4Count { get; set; }

        [StringLength(10)]
        public string fldT4Scale { get; set; }

        [StringLength(10)]
        public string fldT5Count { get; set; }

        [StringLength(10)]
        public string fldT5Scale { get; set; }
    }
}

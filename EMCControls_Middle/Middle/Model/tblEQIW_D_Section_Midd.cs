namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_Section_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        public string STatType { get; set; }

        public string fldTimeType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fldBeginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fldEndDate { get; set; }

        public string fldSectionInfo { get; set; }

        public string fldWaterArea { get; set; }

        public string fldRSWaterWork { get; set; }

        public string fldCityCode { get; set; }

        public string fldCityName { get; set; }

        public string fldSTCode { get; set; }

        public string fldSTName { get; set; }

        public string fldRCode { get; set; }

        public string fldRName { get; set; }

        public string fldRSCode { get; set; }

        public string fldRSName { get; set; }

        public string fldJD { get; set; }

        public string fldWD { get; set; }

        public string fldSCategory { get; set; }

        public string fldLevel { get; set; }

        public string fldRSC { get; set; }

        public string fldAppDate { get; set; }

        public string fldFun { get; set; }

        public string fldItemCount { get; set; }

        public string fldOverCount { get; set; }

        public string fldTDCheckCount { get; set; }

        public string fldYJCheckCount { get; set; }

        public string fldYJCheckItem { get; set; }

        public string fldWJCheckCount { get; set; }

        public string fldWJCheckItem { get; set; }

        public string fldAllCheckCount { get; set; }

        public string fldAllSL { get; set; }

        public string fldAllScale { get; set; }

        public string fldStandSL { get; set; }

        public string fldScaleSL { get; set; }

        public string fldFStandSL { get; set; }

        public string fldFScaleSL { get; set; }

        public string fldPC { get; set; }

        public string fldStandPC { get; set; }

        public string fldScalePC { get; set; }

        public string fldFStandPC { get; set; }

        public string fldFScalePC { get; set; }

        public string fldStage { get; set; }

        public string fldSectionApp { get; set; }

        public string fldStand { get; set; }

        public string fldSingleStageD { get; set; }

        public string fldSingleItemD { get; set; }

        public string fldSingleTimesD { get; set; }

        public string fldSingleStageF { get; set; }

        public string fldSingleItemF { get; set; }

        public string fldSingleTimesF { get; set; }

        public string fldWPI { get; set; }

        public string fldAvgWPI { get; set; }

        public string fldOverItem { get; set; }

        public string fldFOverItem { get; set; }

        public string fldOverTimes { get; set; }

        public string fldOverScale { get; set; }

        public string fldOverNum { get; set; }

        public string fldOverNum2 { get; set; }

        public string fldFOverTimes { get; set; }

        public string fldFOverScale { get; set; }

        public string fldFOverNum { get; set; }

        [Column("314_TLI")]
        public string C314_TLI { get; set; }

        [Column("313_TLI")]
        public string C313_TLI { get; set; }

        [Column("464_TLI")]
        public string C464_TLI { get; set; }

        [Column("501_TLI")]
        public string C501_TLI { get; set; }

        [Column("466_TLI")]
        public string C466_TLI { get; set; }

        public string fldTSI { get; set; }

        public string fldTSIRange { get; set; }

        public string fldOutItem { get; set; }

        public string fldOverCheckItem { get; set; }

        public string fldOverCheckItem_UN { get; set; }

        public string fldOverCheckTimes { get; set; }

        public string fldOverCheckTimes_UN { get; set; }

        public string fldRemark { get; set; }
    }
}

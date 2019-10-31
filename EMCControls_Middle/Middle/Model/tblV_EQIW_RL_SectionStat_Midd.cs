namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblV_EQIW_RL_SectionStat_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(50)]
        public string fldWaterArea { get; set; }

        [StringLength(50)]
        public string fldWaterSys { get; set; }

        [StringLength(10)]
        public string fldSTCode { get; set; }

        [StringLength(30)]
        public string fldSTName { get; set; }

        [StringLength(15)]
        public string fldRCode { get; set; }

        [StringLength(50)]
        public string fldRName { get; set; }

        [StringLength(20)]
        public string fldRSCode { get; set; }

        [StringLength(50)]
        public string fldRSName { get; set; }

        [StringLength(20)]
        public string fldSCategory { get; set; }

        [StringLength(10)]
        public string fldLevel { get; set; }

        [StringLength(100)]
        public string fldAtt { get; set; }

        [StringLength(100)]
        public string fldBArea { get; set; }

        [StringLength(30)]
        public string fldRSTown { get; set; }

        [StringLength(10)]
        public string fldPJCode { get; set; }

        [StringLength(30)]
        public string fldPJName { get; set; }

        [StringLength(30)]
        public string fldRVTown { get; set; }

        [StringLength(50)]
        public string fldFunType { get; set; }

        [StringLength(50)]
        public string fldRiverStream { get; set; }

        [StringLength(50)]
        public string fldSYTown { get; set; }

        [StringLength(50)]
        public string fldXYTown { get; set; }

        [StringLength(30)]
        public string fldControl { get; set; }

        [StringLength(10)]
        public string fldRsTownCode { get; set; }

        [StringLength(10)]
        public string fldSDCityCode { get; set; }

        [StringLength(30)]
        public string fldSDCityName { get; set; }

        [StringLength(30)]
        public string fldSDCode { get; set; }

        [StringLength(50)]
        public string fldSDName { get; set; }

        [StringLength(50)]
        public string fldKHWaterArea { get; set; }

        [StringLength(10)]
        public string fldUnmointor { get; set; }

        [StringLength(100)]
        public string fldBYN { get; set; }

        [StringLength(10)]
        public string fldKHCityCode { get; set; }

        [StringLength(30)]
        public string fldKHCityName { get; set; }

        [StringLength(30)]
        public string fldKHTownName { get; set; }

        [StringLength(10)]
        public string fldRLevel { get; set; }

        [StringLength(50)]
        public string fldRldest { get; set; }

        [StringLength(100)]
        public string fldRFunction { get; set; }

        [StringLength(4)]
        public string fldRSC { get; set; }

        [StringLength(10)]
        public string fldTimeType { get; set; }

        [StringLength(20)]
        public string fldAppDate { get; set; }

        public string fldFun { get; set; }

        [StringLength(10)]
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

        public string fldOutItems { get; set; }

        public string fldFOutItems { get; set; }

        public string fldOverItem { get; set; }

        public string fldFOverItem { get; set; }

        public string fldOverValue { get; set; }

        public string fldFOverValue { get; set; }

        public string fldOverTimes { get; set; }

        public string fldFOverTimes { get; set; }

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

        [StringLength(10)]
        public string fldCheckNum { get; set; }

        [StringLength(10)]
        public string fldOutNum { get; set; }

        [StringLength(10)]
        public string fldOutScale { get; set; }


        public int fldSort { get; set; }

        public string fldRemark { get; set; }

    }
}

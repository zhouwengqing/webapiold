namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_SectionStat_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(50)]
        public string fldWaterArea { get; set; }

        [StringLength(50)]
        public string fldWaterSys { get; set; }

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

        [StringLength(10)]
        public string fldTimeLimit { get; set; }

        [StringLength(4)]
        public string fldRSC { get; set; }

        [StringLength(10)]
        public string fldTimeType { get; set; }

        [StringLength(20)]
        public string fldAppDate { get; set; }

        [StringLength(10)]
        public string fldFun { get; set; }

        [StringLength(10)]
        public string fldStage { get; set; }

        [StringLength(20)]
        public string fldSectionApp { get; set; }

        [StringLength(10)]
        public string fldStand { get; set; }

        [StringLength(10)]
        public string fldScale { get; set; }

        public string fldOutItems { get; set; }

        public string fldFOutItems { get; set; }

        [StringLength(10)]
        public string fldWPI { get; set; }

        [StringLength(10)]
        public string fldAvgWPI { get; set; }

        [StringLength(20)]
        public string fldWPIApp { get; set; }

        public string fldOverItem { get; set; }

        public string fldFOverItem { get; set; }

        public string fldOverValue { get; set; }

        public string fldFOverValue { get; set; }

        public string fldOverTimes { get; set; }

        public string fldFOverTimes { get; set; }

        [StringLength(10)]
        public string fldCheckNum { get; set; }

        [StringLength(10)]
        public string fldOutNum { get; set; }

        [StringLength(10)]
        public string fldOutScale { get; set; }

        [StringLength(500)]
        public string fldYPOverTimes { get; set; }

        [StringLength(500)]
        public string fldReamrk { get; set; }

        [StringLength(40)]
        public string fldSort { get; set; }
    }
}

namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_P_ResultStat_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string TimeType { get; set; }

        [StringLength(50)]
        public string AppriseID { get; set; }

        [StringLength(50)]
        public string SpaceID { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldPCode { get; set; }

        [StringLength(50)]
        public string fldPName { get; set; }

        [StringLength(50)]
        public string fldStation { get; set; }

        [StringLength(50)]
        public string fldAppDate { get; set; }

        [StringLength(50)]
        public string fldType { get; set; }

        [StringLength(50)]
        public string fldPointCount { get; set; }

        [StringLength(50)]
        public string fldCurPoint { get; set; }

        [StringLength(50)]
        public string fldAllCount { get; set; }

        [StringLength(50)]
        public string fldAcidRain { get; set; }

        [StringLength(50)]
        public string fldOver { get; set; }

        [StringLength(50)]
        public string fldPHMin { get; set; }

        [StringLength(50)]
        public string fldPHMax { get; set; }

        [StringLength(50)]
        public string fldPH { get; set; }

        [StringLength(50)]
        public string fldRain { get; set; }

        [StringLength(50)]
        public string fldRain56 { get; set; }

        [StringLength(50)]
        public string fld56Scale { get; set; }

        [StringLength(50)]
        public string fldAvgRain { get; set; }

        [StringLength(50)]
        public string fldMaxRain { get; set; }

        [StringLength(50)]
        public string fldPH56Min { get; set; }

        [StringLength(50)]
        public string fldPH56Max { get; set; }

        [StringLength(50)]
        public string fldPH56 { get; set; }

        [StringLength(50)]
        public string fld125 { get; set; }

        [StringLength(50)]
        public string fld125_Count { get; set; }

        [StringLength(50)]
        public string fld125_Min { get; set; }

        [StringLength(50)]
        public string fld125_Max { get; set; }

        [StringLength(50)]
        public string fld116 { get; set; }

        [StringLength(50)]
        public string fld116_Count { get; set; }

        [StringLength(50)]
        public string fld116_Min { get; set; }

        [StringLength(50)]
        public string fld116_Max { get; set; }

        [StringLength(50)]
        public string fld117 { get; set; }

        [StringLength(50)]
        public string fld117_Count { get; set; }

        [StringLength(50)]
        public string fld117_Min { get; set; }

        [StringLength(50)]
        public string fld117_Max { get; set; }

        [StringLength(50)]
        public string fld118 { get; set; }

        [StringLength(50)]
        public string fld118_Count { get; set; }

        [StringLength(50)]
        public string fld118_Min { get; set; }

        [StringLength(50)]
        public string fld118_Max { get; set; }

        [StringLength(50)]
        public string fld119 { get; set; }

        [StringLength(50)]
        public string fld119_Count { get; set; }

        [StringLength(50)]
        public string fld119_Min { get; set; }

        [StringLength(50)]
        public string fld119_Max { get; set; }

        [StringLength(50)]
        public string fld120 { get; set; }

        [StringLength(50)]
        public string fld120_Count { get; set; }

        [StringLength(50)]
        public string fld120_Min { get; set; }

        [StringLength(50)]
        public string fld120_Max { get; set; }

        [StringLength(50)]
        public string fld121 { get; set; }

        [StringLength(50)]
        public string fld121_Count { get; set; }

        [StringLength(50)]
        public string fld121_Min { get; set; }

        [StringLength(50)]
        public string fld121_Max { get; set; }

        [StringLength(50)]
        public string fld122 { get; set; }

        [StringLength(50)]
        public string fld122_Count { get; set; }

        [StringLength(50)]
        public string fld122_Min { get; set; }

        [StringLength(50)]
        public string fld122_Max { get; set; }

        [StringLength(50)]
        public string fld123 { get; set; }

        [StringLength(50)]
        public string fld123_Count { get; set; }

        [StringLength(50)]
        public string fld123_Min { get; set; }

        [StringLength(50)]
        public string fld123_Max { get; set; }

        [StringLength(50)]
        public string fld124 { get; set; }

        [StringLength(50)]
        public string fld124_Count { get; set; }

        [StringLength(50)]
        public string fld124_Min { get; set; }

        [StringLength(50)]
        public string fld124_Max { get; set; }

        [StringLength(50)]
        public string fld0Count_S { get; set; }

        [StringLength(50)]
        public string fld0Scale_S { get; set; }

        [StringLength(50)]
        public string fld45Count_S { get; set; }

        [StringLength(50)]
        public string fld45Scale_S { get; set; }

        [StringLength(50)]
        public string fld50Count_S { get; set; }

        [StringLength(50)]
        public string fld50Scale_S { get; set; }

        [StringLength(50)]
        public string fld56Count_S { get; set; }

        [StringLength(50)]
        public string fld56Scale_S { get; set; }

        [StringLength(50)]
        public string fld70Count_S { get; set; }

        [StringLength(50)]
        public string fld70Scale_S { get; set; }
    }
}

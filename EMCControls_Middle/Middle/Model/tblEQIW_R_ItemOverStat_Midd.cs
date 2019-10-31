namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_ItemOverStat_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(10)]
        public string fldValueType { get; set; }

        [StringLength(50)]
        public string fldSpaceName { get; set; }

        [StringLength(50)]
        public string fldSpaceType { get; set; }

        [StringLength(20)]
        public string fldItemCode { get; set; }

        [StringLength(10)]
        public string fldTimeType { get; set; }

        [StringLength(20)]
        public string fldAppDate { get; set; }

        [StringLength(10)]
        public string fldRCount { get; set; }

        [StringLength(10)]
        public string fldOutCount { get; set; }

        [StringLength(10)]
        public string fldScale { get; set; }

        [StringLength(15)]
        public string fldItemValue { get; set; }

        [StringLength(16)]
        public string fldStage { get; set; }

        [StringLength(10)]
        public string fldOvers { get; set; }

        [StringLength(10)]
        public string fldMin { get; set; }

        [StringLength(10)]
        public string fldMax { get; set; }

        [StringLength(16)]
        public string fldMaxStage { get; set; }

        [StringLength(50)]
        public string fldMaxRS { get; set; }

        [StringLength(10)]
        public string fldMinOut { get; set; }

        [StringLength(10)]
        public string fldMaxOut { get; set; }

        [StringLength(10)]
        public string fldYPCount { get; set; }

        [StringLength(10)]
        public string fldYPOutCount { get; set; }

        [StringLength(10)]
        public string fldYPScale { get; set; }

        [StringLength(10)]
        public string fldYPMinScale { get; set; }

        [StringLength(10)]
        public string fldYPMaxScale { get; set; }

        [StringLength(10)]
        public string fldYPOutSection { get; set; }

        [StringLength(10)]
        public string fldYPOutSectionScale { get; set; }

        [StringLength(10)]
        public string fldYPMinValue { get; set; }

        [StringLength(10)]
        public string fldYPMaxValue { get; set; }

        [StringLength(10)]
        public string fldYPOverValue { get; set; }

        [StringLength(10)]
        public string fldMaxDayValue { get; set; }

        [StringLength(20)]
        public string fldMaxDate { get; set; }

        [StringLength(50)]
        public string fldMaxDaySection { get; set; }

        [StringLength(16)]
        public string fldMaxDayStage { get; set; }

        [StringLength(10)]
        public string fldMaxDayOut { get; set; }
    }
}

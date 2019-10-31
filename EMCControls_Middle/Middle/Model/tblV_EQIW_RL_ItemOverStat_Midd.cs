namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblV_EQIW_RL_ItemOverStat_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(20)]
        public string fldItemName { get; set; }

        [StringLength(20)]
        public string fldSectionType { get; set; }

        [StringLength(20)]
        public string fldAppDate { get; set; }

        [StringLength(20)]
        public string fldTimeType { get; set; }

        [StringLength(10)]
        public string fldRCount { get; set; }

        [StringLength(10)]
        public string fldOutCount { get; set; }

        [StringLength(10)]
        public string fldScale { get; set; }

        [StringLength(15)]
        public string fldItemValue { get; set; }

        [StringLength(16)]
        public string fldItemStage { get; set; }

        [StringLength(10)]
        public string fldItemOvers { get; set; }

        [StringLength(10)]
        public string fldMin { get; set; }

        [StringLength(10)]
        public string fldMax { get; set; }

        [StringLength(100)]
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
        public string fldYPMaxScale { get; set; }

        [StringLength(10)]
        public string fldYPOutSection { get; set; }

        [StringLength(10)]
        public string fldYPOutSectionScale { get; set; }

        [StringLength(10)]
        public string fldYPMaxValue { get; set; }

        [StringLength(10)]
        public string fldYPOverValue { get; set; }
    }
}

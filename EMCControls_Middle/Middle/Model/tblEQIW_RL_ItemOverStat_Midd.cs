namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_RL_ItemOverStat_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        public DateTime? fldBeginDate { get; set; }

        public DateTime? fldEndDate { get; set; }

        [StringLength(200)]
        public string fldSpace { get; set; }

        [StringLength(20)]
        public string fldItemName { get; set; }

        [StringLength(20)]
        public string fldSectionType { get; set; }

        [StringLength(20)]
        public string fldAppDate { get; set; }

        [StringLength(20)]
        public string fldTimeType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldRCount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldOutCount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldScale { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldItemValue { get; set; }

        [StringLength(16)]
        public string fldItemStage { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldItemOvers { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldMin { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldMax { get; set; }

        [StringLength(50)]
        public string fldMaxStage { get; set; }

        [StringLength(100)]
        public string fldMaxRS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldMinOut { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldMaxOut { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYPCount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYPOutCount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYPScale { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYPMaxScale { get; set; }

        public string fldYPOutSection { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYPOutSectionScale { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYPMaxValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYPOverValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldMaxDayValue { get; set; }

        public string fldMaxDate { get; set; }

        public string fldMaxDaySection { get; set; }

        [StringLength(50)]
        public string fldMaxDayStage { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldMaxDayOut { get; set; }
    }
}

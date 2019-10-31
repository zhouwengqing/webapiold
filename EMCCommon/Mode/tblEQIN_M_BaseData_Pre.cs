namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_M_BaseData_Pre
    {
        [Key]
        public long fldAutoID { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(12)]
        public string fldPCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMonth { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldDay { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldHour { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMinute { get; set; }

        public int fldTimelen { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldFeiPtrafic { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldFeiTrumpet { get; set; }

        [Required]
        [StringLength(50)]
        public string fldFeiTrumpetRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldJiPtraficGJ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldJiPtraficCZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldJiPtraficHC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldJiPtraficSH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldJiPtraficCount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldJiTrumpetGJ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldJiTrumpetCZ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldJiTrumpetHC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldJiTrumpetSH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldJiTrumpetCount { get; set; }

        [Required]
        [StringLength(50)]
        public string fldJiTRateGJ { get; set; }

        [Required]
        [StringLength(50)]
        public string fldJiTRateCZ { get; set; }

        [Required]
        [StringLength(50)]
        public string fldJiTRateHC { get; set; }

        [Required]
        [StringLength(50)]
        public string fldJiTRateSH { get; set; }

        [Required]
        [StringLength(50)]
        public string fldJiTRateCount { get; set; }

        public short fldFlag { get; set; }

        public short fldImport { get; set; }

        public int fldCityID_Operate { get; set; }

        [Required]
        [StringLength(100)]
        public string fldCityID_Submit { get; set; }

        public DateTime fldDate_Operate { get; set; }

        public int fldUserID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldBatch { get; set; }

        public int fldDeleteState { get; set; }

        public short fldSource { get; set; }
    }
}

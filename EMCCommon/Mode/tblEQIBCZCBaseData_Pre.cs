namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIBCZCBaseData_Pre
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(12)]
        public string fldRCode { get; set; }

        [Required]
        [StringLength(12)]
        public string fldRSCode { get; set; }

        [Required]
        [StringLength(10)]
        public string fldSAMPH { get; set; }

        [Required]
        [StringLength(10)]
        public string fldSAMPR { get; set; }

        [Required]
        [StringLength(10)]
        public string fldRSC { get; set; }

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

        [Required]
        [StringLength(50)]
        public string fldTypeCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldPCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldCTypeCode { get; set; }

        [Required]
        [StringLength(100)]
        public string fldNetTyoe { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldPickVolume { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldConcentrate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldDensity { get; set; }

        public short fldFlag { get; set; }

        public int fldCityID_Operate { get; set; }

        [Required]
        [StringLength(100)]
        public string fldCityID_Submit { get; set; }

        public int fldUserID { get; set; }

        public DateTime fldDate_Operate { get; set; }

        [Required]
        [StringLength(50)]
        public string fldBatch { get; set; }

        [Required]
        [StringLength(10)]
        public string fldImport { get; set; }

        public short fldSource { get; set; }
    }
}

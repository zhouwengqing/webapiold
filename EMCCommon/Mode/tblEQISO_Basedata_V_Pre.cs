namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQISO_Basedata_V_Pre
    {
        [Key]
        public long fldAutoID { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(12)]
        public string fldCCode { get; set; }

        [Required]
        [StringLength(20)]
        public string fldVCode { get; set; }

        [Required]
        [StringLength(12)]
        public string fldPCode { get; set; }

        [StringLength(50)]
        public string fldLon { get; set; }

        [StringLength(50)]
        public string fldLat { get; set; }

        [Required]
        [StringLength(50)]
        public string fldSampleType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMonth { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldDay { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld100 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld116 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld106 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld108 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld103 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld120 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld113 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld186 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld111 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld112 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld105 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld109 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld121 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld118 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld522 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld104 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld263 { get; set; }

        [StringLength(12)]
        public string fldPollutantsName1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldPollutantsValue1 { get; set; }

        [StringLength(12)]
        public string fldPollutantsName2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldPollutantsValue2 { get; set; }

        [StringLength(12)]
        public string fldPollutantsName3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldPollutantsValue3 { get; set; }

        [StringLength(500)]
        public string fldRemark { get; set; }

        public short fldFlag { get; set; }

        public int fldCityID_Operate { get; set; }

        [Required]
        [StringLength(100)]
        public string fldCityID_Submit { get; set; }

        public int fldUserID { get; set; }

        public DateTime fldDate_Operate { get; set; }

        public short fldImport { get; set; }

        [Required]
        [StringLength(50)]
        public string fldBatch { get; set; }
    }
}

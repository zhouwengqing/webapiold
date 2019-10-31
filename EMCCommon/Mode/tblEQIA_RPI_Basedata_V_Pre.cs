namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_RPI_Basedata_V_Pre
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

        [Column(TypeName = "numeric")]
        public decimal fldLon { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLat { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMonth { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldDay { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld101 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld141 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld107 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld105 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld108 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld106 { get; set; }

        [StringLength(20)]
        public string fldPollutantsName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldPollutantsValue { get; set; }

        [StringLength(500)]
        public string fldRemark { get; set; }

        public short fldSource { get; set; }

        public short fldImport { get; set; }

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

        public int fldDeleteState { get; set; }
    }
}

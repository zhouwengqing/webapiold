namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_RPI_Basedata_Pre
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
        public decimal fldSYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldSMonth { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldSDay { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldSHour { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldSMinute { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldEYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldEMonth { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldEDay { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldEHour { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldEMinute { get; set; }

        [Required]
        [StringLength(10)]
        public string fldItemCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldItemValue { get; set; }

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

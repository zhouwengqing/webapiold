namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_Basedata
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(12)]
        public string fldSTCode { get; set; }

        [StringLength(30)]
        public string fldSTName { get; set; }

        [StringLength(12)]
        public string fldRCode { get; set; }

        [StringLength(100)]
        public string fldRName { get; set; }

        [StringLength(12)]
        public string fldRSCode { get; set; }

        [StringLength(100)]
        public string fldRSName { get; set; }

        [StringLength(12)]
        public string fldSAMPH { get; set; }

        [StringLength(12)]
        public string fldSAMPR { get; set; }

        [StringLength(10)]
        public string fldRSC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldMonth { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldDay { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldHour { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldMinute { get; set; }

        [StringLength(10)]
        public string fldItemCode { get; set; }

        [StringLength(50)]
        public string fldItemName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldItemValue { get; set; }

        public short? fldSource { get; set; }

        public int? fldUserID { get; set; }

        public short? fldFlag { get; set; }

        public bool? fldBReport { get; set; }

        [NotMapped]
        public DateTime? fldDate { get; set; }
    }
}

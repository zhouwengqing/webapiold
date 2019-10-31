namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQID_D_BaseData_Pre
    {
        [Key]
        public long fldAutoID { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(50)]
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

        [Required]
        [StringLength(50)]
        public string fldRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldEIntensity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMIntensity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldPower { get; set; }

        public short fldFlag { get; set; }

        public short fldImport { get; set; }

        public int fldCityID_Operate { get; set; }

        [Required]
        [StringLength(100)]
        public string fldCityID_Submit { get; set; }

        public DateTime fldDate_Operate { get; set; }

        public int fldUserID { get; set; }

        public short fldSource { get; set; }
    }
}

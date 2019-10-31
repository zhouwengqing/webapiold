namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_A_BaseData_Pre
    {
        [Key]
        public long fldAutoID { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(12)]
        public string fldGDCODE { get; set; }

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

        [StringLength(10)]
        public string fldDN { get; set; }

        [StringLength(12)]
        public string fldNDISC { get; set; }

        [StringLength(12)]
        public string fldNSC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLEQA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldL10A { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldL50A { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldL90A { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLmax { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldLmin { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldSD { get; set; }

        public short fldFlag { get; set; }

        public short fldImport { get; set; }

        public int fldCityID_Operate { get; set; }

        [StringLength(100)]
        public string fldCityID_Submit { get; set; }

        public DateTime fldDate_Operate { get; set; }

        public int fldUserID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMph { get; set; }

        [StringLength(50)]
        public string fldApparatus_Type { get; set; }

        [StringLength(50)]
        public string fldApparatus_Id { get; set; }

        public bool fldApparatus_Grade { get; set; }

        public bool fldMatching_Data { get; set; }

        [StringLength(50)]
        public string fldBatch { get; set; }

        public int fldDeleteState { get; set; }

        public short fldSource { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldCalibrationVluesOn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldCalibrationVluesEnd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldSPressureValue { get; set; }

        [StringLength(50)]
        public string fldSPressureType { get; set; }

        [StringLength(50)]
        public string fldSPressureID { get; set; }
    }
}

namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_A_Point_HourStat_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        public DateTime? fldappdate { get; set; }

        [StringLength(50)]
        public string fldGDCode { get; set; }

        [StringLength(50)]
        public string fldGDName { get; set; }

        [StringLength(50)]
        public string fldStaLod { get; set; }

        [StringLength(50)]
        public string fldStaLad { get; set; }

        [StringLength(50)]
        public string fldStaRef { get; set; }

        [StringLength(50)]
        public string fldGRIDL { get; set; }

        [StringLength(50)]
        public string fldGPOPUL { get; set; }

        [StringLength(50)]
        public string fldNDISC { get; set; }

        [StringLength(50)]
        public string fldNSC { get; set; }

        [StringLength(50)]
        public string fldLEQA { get; set; }

        [StringLength(50)]
        public string fldL10 { get; set; }

        [StringLength(50)]
        public string fldL50 { get; set; }

        [StringLength(50)]
        public string fldL90 { get; set; }

        [StringLength(50)]
        public string fldLmax { get; set; }

        [StringLength(50)]
        public string fldLmin { get; set; }

        [StringLength(50)]
        public string fldSD { get; set; }

        [StringLength(50)]
        public string fldPName { get; set; }

        [StringLength(50)]
        public string fldApparatus_Type { get; set; }

        [StringLength(50)]
        public string fldApparatus_Id { get; set; }

        [StringLength(50)]
        public string fldCalibrationVluesOn { get; set; }

        [StringLength(50)]
        public string fldCalibrationVluesEnd { get; set; }

        [StringLength(50)]
        public string fldSPressureValue { get; set; }

        [StringLength(50)]
        public string fldSPressureType { get; set; }

        [StringLength(50)]
        public string fldSPressureID { get; set; }

        [StringLength(50)]
        public string fldLevel { get; set; }
    }
}

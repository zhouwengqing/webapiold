namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_T_Point_HourStat_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        public DateTime? fldappdate { get; set; }

        [StringLength(50)]
        public string fldRDCode { get; set; }

        [StringLength(50)]
        public string fldRDName { get; set; }

        [StringLength(50)]
        public string fldStaLod { get; set; }

        [StringLength(50)]
        public string fldStaLad { get; set; }

        [StringLength(50)]
        public string fldBErode { get; set; }

        [StringLength(50)]
        public string fldPLen { get; set; }

        [StringLength(50)]
        public string fldPWid { get; set; }

        [StringLength(50)]
        public string fldGRrode { get; set; }

        [StringLength(50)]
        public string fldCREtype { get; set; }

        [StringLength(50)]
        public string fldLanes { get; set; }

        [StringLength(50)]
        public string fldPTSArc { get; set; }

        [StringLength(50)]
        public string fldPTrack { get; set; }

        [StringLength(50)]
        public string fldZPTrafic { get; set; }

        [StringLength(50)]
        public string fldQPTrafic { get; set; }

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

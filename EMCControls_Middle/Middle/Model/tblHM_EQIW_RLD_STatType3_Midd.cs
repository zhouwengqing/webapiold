namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblHM_EQIW_RLD_STatType3_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        [StringLength(50)]
        public string fldWaterArea { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldRCode { get; set; }

        [StringLength(50)]
        public string fldRName { get; set; }

        [StringLength(50)]
        public string fldRSCode { get; set; }

        [StringLength(50)]
        public string fldRSName { get; set; }

        [StringLength(50)]
        public string fldLevel { get; set; }

        [StringLength(50)]
        public string fldAtt { get; set; }

        [StringLength(50)]
        public string fldRSC { get; set; }

        [StringLength(50)]
        public string fldAppDate { get; set; }

        [StringLength(50)]
        public string fldType { get; set; }

        [StringLength(50)]
        public string fldFun { get; set; }

        [StringLength(50)]
        public string fldStage { get; set; }

        [StringLength(50)]
        public string fldSectionApp { get; set; }

        [StringLength(50)]
        public string fldStand { get; set; }

        [StringLength(50)]
        public string fldOverItem { get; set; }

        [StringLength(50)]
        public string fldCheckTimes { get; set; }

        [StringLength(50)]
        public string fldOverTimes { get; set; }

        [StringLength(50)]
        public string fldOverValue { get; set; }

        [StringLength(50)]
        public string fldOverDate { get; set; }

        [StringLength(50)]
        public string fldReamrk { get; set; }

        [StringLength(50)]
        public string fldSort { get; set; }
    }
}

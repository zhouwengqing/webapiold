namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_P_STatType3_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string TimeType { get; set; }

        [StringLength(50)]
        public string AppriseID { get; set; }

        [StringLength(50)]
        public string SpaceID { get; set; }

        [StringLength(50)]
        public string fldYear { get; set; }

        [StringLength(50)]
        public string fldDate { get; set; }

        [StringLength(50)]
        public string fldPointCount { get; set; }

        [StringLength(50)]
        public string fld0Count_P { get; set; }

        [StringLength(50)]
        public string fld0Scale_P { get; set; }

        [StringLength(50)]
        public string fld20Count_P { get; set; }

        [StringLength(50)]
        public string fld20Scale_P { get; set; }

        [StringLength(50)]
        public string fld40Count_P { get; set; }

        [StringLength(50)]
        public string fld40Scale_P { get; set; }

        [StringLength(50)]
        public string fld60Count_P { get; set; }

        [StringLength(50)]
        public string fld60Scale_P { get; set; }

        [StringLength(50)]
        public string fld80Count_P { get; set; }

        [StringLength(50)]
        public string fld80Scale_P { get; set; }

        [StringLength(50)]
        public string fld100Count_P { get; set; }

        [StringLength(50)]
        public string fld100Scale_P { get; set; }

        [StringLength(50)]
        public string fldT25Count_P { get; set; }

        [StringLength(50)]
        public string fldT25Scale_P { get; set; }

        [StringLength(50)]
        public string fldT50Count_P { get; set; }

        [StringLength(50)]
        public string fldT50Scale_P { get; set; }

        [StringLength(50)]
        public string fldT75Count_P { get; set; }

        [StringLength(50)]
        public string fldT75Scale_P { get; set; }

        [StringLength(50)]
        public string fldT100Count_P { get; set; }

        [StringLength(50)]
        public string fldT100Scale_P { get; set; }

        [StringLength(50)]
        public string fld0Count_S { get; set; }

        [StringLength(50)]
        public string fld0Scale_S { get; set; }

        [StringLength(50)]
        public string fld45Count_S { get; set; }

        [StringLength(50)]
        public string fld45Scale_S { get; set; }

        [StringLength(50)]
        public string fld50Count_S { get; set; }

        [StringLength(50)]
        public string fld50Scale_S { get; set; }

        [StringLength(50)]
        public string fld56Count_S { get; set; }

        [StringLength(50)]
        public string fld56Scale_S { get; set; }
    }
}

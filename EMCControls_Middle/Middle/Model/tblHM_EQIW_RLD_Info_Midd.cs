namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblHM_EQIW_RLD_Info_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string TimeType { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? EBeginDate { get; set; }

        public DateTime? EEndDate { get; set; }

        [StringLength(50)]
        public string fldRSC { get; set; }

        public string fldRSCode { get; set; }

        [StringLength(50)]
        public string fldStandardName { get; set; }

        public int? fldLevel { get; set; }

        [StringLength(50)]
        public string fldStandardNameG { get; set; }

        public int? fldLevelG { get; set; }

        public string fldItemCode { get; set; }

        [StringLength(50)]
        public string DecCarry { get; set; }

        public int? IsPre { get; set; }

        public int? IsYear { get; set; }

        public int? IsTotal { get; set; }

        public int? IsDetail { get; set; }

        public int? AppriseID { get; set; }

        public int? SpaceID { get; set; }

        public int? STatType { get; set; }

        public int? Para1ID { get; set; }

        public int? Para2ID { get; set; }

        public int? Source { get; set; }
    }
}

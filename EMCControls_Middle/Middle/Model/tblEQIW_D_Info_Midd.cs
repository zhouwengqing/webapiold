namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_Info_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public string TimeType { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string fldRSC { get; set; }

        public string fldRSCode { get; set; }

        public string fldRStandardName { get; set; }

        public int? fldRLevel { get; set; }

        public string fldLStandardName { get; set; }

        public int? fldLLevel { get; set; }

        public string fldItemCode { get; set; }

        public string DecCarry { get; set; }

        public int? IsPre { get; set; }

        public int? IsYear { get; set; }

        public int? IsTotal { get; set; }

        public int? IsDetail { get; set; }

        public int? IsTLI { get; set; }

        public int? TLIType { get; set; }

        public int? AppriseID { get; set; }

        public int? SpaceID { get; set; }

        public int? STatType { get; set; }

        public string fldSource { get; set; }

        public int? CalculateID { get; set; }
    }
}

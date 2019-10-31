namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_A_City_AverageData_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string ReportType { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldYear { get; set; }

        [StringLength(50)]
        public string fldLeqa { get; set; }

        [StringLength(50)]
        public string fldL10 { get; set; }

        [StringLength(50)]
        public string fldL50 { get; set; }

        [StringLength(50)]
        public string fldL90 { get; set; }
    }
}

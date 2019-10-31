namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_F_City_TotalDateStat_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string ReportType { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldYear { get; set; }

        [StringLength(50)]
        public string fldDate { get; set; }

        [StringLength(50)]
        public string fldNDISC { get; set; }

        [StringLength(50)]
        public string fldCount_D { get; set; }

        [StringLength(50)]
        public string fldStdCount_D { get; set; }

        [StringLength(50)]
        public string fldScale_D { get; set; }

        [StringLength(50)]
        public string fldCount_N { get; set; }

        [StringLength(50)]
        public string fldStdCount_N { get; set; }

        [StringLength(50)]
        public string fldScale_N { get; set; }
    }
}

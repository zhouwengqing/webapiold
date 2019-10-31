namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_F_Point_TotalDateStat_Midd
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
        public string fldPCode { get; set; }

        [StringLength(50)]
        public string fldPName { get; set; }

        [StringLength(50)]
        public string fldYear { get; set; }

        [StringLength(50)]
        public string fldDate { get; set; }

        [StringLength(50)]
        public string fldNDISC { get; set; }

        [StringLength(50)]
        public string fldTimes { get; set; }

        [StringLength(50)]
        public string fldLEQA_D { get; set; }

        [StringLength(50)]
        public string fldLEQA_N { get; set; }

        [StringLength(50)]
        public string fldLEQA_DN { get; set; }

        [StringLength(50)]
        public string fldSTD_D { get; set; }

        [StringLength(50)]
        public string fldSTD_N { get; set; }

        [StringLength(50)]
        public string fldOut_D { get; set; }

        [StringLength(50)]
        public string fldOut_N { get; set; }

        [StringLength(50)]
        public string fldApp_D { get; set; }

        [StringLength(50)]
        public string fldAPP_N { get; set; }

        [StringLength(50)]
        public string fldPCount { get; set; }
    }
}

namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblReportArchive")]
    public partial class tblReportArchive
    {
        [Key]
        public int fldAutoID { get; set; }

        public string fldReport_Name { get; set; }

        public string fldReport_Type { get; set; }

        public string fldRName { get; set; }

        public string fldUserID { get; set; }

        public string fldTime { get; set; }

        public string fldPath { get; set; }

        public string fldFileName { get; set; }
    }
}

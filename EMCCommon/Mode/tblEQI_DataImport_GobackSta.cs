namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQI_DataImport_GobackSta
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(30)]
        public string fldObject { get; set; }

        public string fldRSInfo { get; set; }

        [StringLength(30)]
        public string fldDate { get; set; }

        public int? fldisgback { get; set; }

        public int? fldsource { get; set; }
    }
}

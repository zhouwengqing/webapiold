namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQI_DataImport_Remark
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(30)]
        public string fldObject { get; set; }

        public string fldRSInfo { get; set; }

        [StringLength(30)]
        public string fldDate { get; set; }

        [StringLength(1000)]
        public string fldRemark { get; set; }

        public int? fldsource { get; set; }


        [NotMapped]
        public DateTime? fldDate_2 { get; set; }
    }
}

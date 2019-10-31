namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblDT_Dn_DataLog
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(100)]
        public string fldTableName { get; set; }

        [Required]
        [StringLength(48)]
        public string fldSTName { get; set; }

        public DateTime fldDate_Begin { get; set; }

        public DateTime fldDate_End { get; set; }

        [Required]
        [StringLength(20)]
        public string fldLevel { get; set; }

        public int fldPointNum { get; set; }

        public int fldRecordNum { get; set; }

        public int fldDn_user { get; set; }

        public DateTime fldDn_date { get; set; }

        public short fldType { get; set; }

        public int? fldsource { get; set; }

        [StringLength(50)]
        public string fldTtype { get; set; }
    }
}

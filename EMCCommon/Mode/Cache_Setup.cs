namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cache_Setup
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string fldObject { get; set; }

        [StringLength(50)]
        public string fldTimeType { get; set; }

        public int? fldType { get; set; }

        [StringLength(50)]
        public string fldName { get; set; }

        [StringLength(50)]
        public string fldGroupName { get; set; }

        public int? fldUserID { get; set; }

        public string fldPointContent { get; set; }

        public string fldItemContent { get; set; }
    }
}

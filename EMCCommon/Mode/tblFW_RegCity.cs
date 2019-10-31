namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblFW_RegCity
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(12)]
        public string fldSTCode { get; set; }

        [StringLength(30)]
        public string fldSTName { get; set; }

        public int? fldParentID { get; set; }

        public bool? fldNeedAuditing { get; set; }

        public bool? fldISLogin { get; set; }

        public int? fldSort { get; set; }

        [StringLength(12)]
        public string fldSTCodeGA { get; set; }

        public short? fldCityArea { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLatitude { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldLongitude { get; set; }
    }
}

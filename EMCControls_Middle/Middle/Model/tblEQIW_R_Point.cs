namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_Point
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(15)]
        public string fldSTACode { get; set; }

        [StringLength(50)]
        public string fldSTAName { get; set; }

        [StringLength(50)]
        public string fldSTAInfoDby { get; set; }

        [StringLength(50)]
        public string fldSTABelong { get; set; }

        [StringLength(500)]
        public string fldProfile { get; set; }

        [StringLength(10)]
        public string fldLongitude { get; set; }

        [StringLength(10)]
        public string fldLatitude { get; set; }
    }
}

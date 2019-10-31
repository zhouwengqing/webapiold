namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblHM_EQISO_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldPCount { get; set; }

        [StringLength(50)]
        public string fldScale { get; set; }

        [StringLength(50)]
        public string fldRange { get; set; }

        [StringLength(50)]
        public string fldPiAvg { get; set; }

        [StringLength(50)]
        public string fld1Level { get; set; }

        [StringLength(50)]
        public string fld2Level { get; set; }
    }
}

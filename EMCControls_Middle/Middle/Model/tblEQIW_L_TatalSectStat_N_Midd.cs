namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_L_TatalSectStat_N_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(50)]
        public string fldSpaceName { get; set; }

        [StringLength(50)]
        public string fldSpaceType { get; set; }

        [StringLength(50)]
        public string fldLakeRegion { get; set; }

        [StringLength(10)]
        public string fldTimeType { get; set; }

        [StringLength(20)]
        public string fldAppDate { get; set; }

        [StringLength(16)]
        public string fldFun { get; set; }

        [StringLength(16)]
        public string fldStage { get; set; }

        [StringLength(20)]
        public string fldApp { get; set; }

        [StringLength(10)]
        public string fldScale { get; set; }

        public string fldOutItems { get; set; }

        public string fldFOutItems { get; set; }

        [StringLength(10)]
        public string fldTSI { get; set; }

        [StringLength(20)]
        public string fldTSIRange { get; set; }

        [StringLength(10)]
        public string fldWPI { get; set; }
    }
}

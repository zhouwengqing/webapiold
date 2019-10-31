namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_RL_TatalSectStat_Item_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        public long fldFKID { get; set; }

        [StringLength(5)]
        public string fldItemCode { get; set; }

        [StringLength(15)]
        public string fldItemValue_N { get; set; }

        [StringLength(15)]
        public string fldItemValue_Z { get; set; }

        [StringLength(10)]
        public string fldItemStage { get; set; }

        [StringLength(10)]
        public string fldItemCPI { get; set; }

        [StringLength(10)]
        public string fldItemCFI { get; set; }

        [StringLength(10)]
        public string fldItemSTG { get; set; }
    }
}

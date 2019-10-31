namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_TatalSectStat_Item_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        public long fldFKID { get; set; }

        [StringLength(8)]
        public string fldItemCode { get; set; }

        [StringLength(15)]
        public string fldItemValue { get; set; }

        [StringLength(16)]
        public string fldItemStage { get; set; }

        [StringLength(15)]
        public string fldItemSTG { get; set; }

        [StringLength(16)]
        public string fldItemCPI { get; set; }

        [StringLength(10)]
        public string fldItemCFI { get; set; }

        [StringLength(10)]
        public string fldItemOver { get; set; }
    }
}

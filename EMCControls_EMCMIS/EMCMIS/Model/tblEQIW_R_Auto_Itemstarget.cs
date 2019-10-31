namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_Auto_Itemstarget
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(30)]
        public string fldRSCode { get; set; }

        [StringLength(100)]
        public string fldRSName { get; set; }

        [StringLength(50)]
        public string fldItemName { get; set; }

        [StringLength(10)]
        public string fldItemCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldItemTarget { get; set; }
    }
}

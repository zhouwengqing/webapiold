namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwtblAccountingSystem")]
    public partial class vwtblAccountingSystem
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string fldMerchID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string fldMerchName { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal fldTotalAmount { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal fldWithdraw { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal fldFrozenAmount { get; set; }

        [StringLength(4)]
        public string fldState { get; set; }
    }
}

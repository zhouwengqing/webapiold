namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAccounting")]
    public partial class tblAccounting
    {
        [Key]
        [Column(Order = 0)]
        public int fldAutoID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string fldAccountingnum { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string fldMerchID { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal fldTotalAmount { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal fldWithdraw { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal fldFrozenAmount { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal fldUnsettledAmoun { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool fldState { get; set; }
    }
}

namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_R_City_TotalDateStat_Item_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        public int fldFKID { get; set; }
        [Required]
        [StringLength(10)]
        public string fldSTCode { get; set; }
        
        [Required]
        [StringLength(10)]
        public string fldTimeType { get; set; }

        [Required]
        [StringLength(20)]
        public string fldAppDate { get; set; }

        [Required]
        [StringLength(5)]
        public string fldItemCode { get; set; }

        [StringLength(15)]
        public string fldItemAVG { get; set; }

        [StringLength(10)]
        public string fldItemSD { get; set; }

        [StringLength(15)]
        public string fldItemMin { get; set; }

        [StringLength(15)]
        public string fldItemMax { get; set; }

        [StringLength(4)]
        public string fldItemLevels { get; set; }

        [StringLength(4)]
        public string fldItemAllDays { get; set; }

        [StringLength(4)]
        public string fldItemCurDays { get; set; }

        [StringLength(4)]
        public string fldItemStdDays { get; set; }

        [StringLength(4)]
        public string fldItem1LevelDays { get; set; }

        [StringLength(15)]
        public string fldItemStand { get; set; }

        [StringLength(15)]
        public string fldItemOvers { get; set; }

        [StringLength(15)]
        public string fldItemMinOut { get; set; }

        [StringLength(15)]
        public string fldItemMaxOut { get; set; }

        [StringLength(4)]
        public string fldItemCFI { get; set; }

        [StringLength(4)]
        public string fldItemCFIW { get; set; }

        [StringLength(15)]
        public string fldItemCPI { get; set; }

        [StringLength(15)]
        public string fldItemLoad { get; set; }

        [StringLength(10)]
        public string fldItemBFW { get; set; }

        [StringLength(10)]
        public string fldItemBFW90 { get; set; }

        [StringLength(10)]
        public string fldItemBFW98 { get; set; }
    }
}

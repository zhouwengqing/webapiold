namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblV_EQIA_R_City_DayStat_Item_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [Required]
        [StringLength(10)]
        public string fldSTCode { get; set; }

        public DateTime fldAppDate { get; set; }

        [StringLength(5)]
        public string fldItemCode { get; set; }

        [StringLength(15)]
        public string fldItemAVG { get; set; }

        [StringLength(6)]
        public string fldItemAQI { get; set; }
    }
}

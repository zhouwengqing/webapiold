namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQI_Item_Group
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(20)]
        public string fldObject { get; set; }

        [Required]
        [StringLength(100)]
        public string fldName { get; set; }

        public int fldUserID { get; set; }

        [Required]
        [StringLength(3000)]
        public string fldItemContent { get; set; }
    }
}

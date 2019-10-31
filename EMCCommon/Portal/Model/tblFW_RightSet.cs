namespace EMCCommon.Portal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblFW_RightSet
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(100)]
        public string fldName { get; set; }

        public short fldFlag { get; set; }

        //[Required]
        [StringLength(150)]
        public string fldKeyword { get; set; }

        public int fldParentID { get; set; }

        public short fldOrder { get; set; }

        public short fldLevel { get; set; }

        public short fldTarget { get; set; }

        public bool fldBusinessPoint { get; set; }

        public short fldWebSiteTag { get; set; }

        [StringLength(50)]
        public string fldImage { get; set; }
    }
}

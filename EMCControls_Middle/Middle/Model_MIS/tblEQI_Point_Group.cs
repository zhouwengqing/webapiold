namespace EMCControls_Middle.Middle.Model_MIS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQI_Point_Group
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(20)]
        public string fldObject { get; set; }

        public short fldType { get; set; }

        [Required]
        [StringLength(100)]
        public string fldName { get; set; }

        public int fldUserID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldYear { get; set; }

        [Required]
        public string fldPointContent { get; set; }
    }
}

namespace EMCCommon.Portal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblFW_Dept
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(20)]
        public string fldDeptCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldDeptName { get; set; }

        public int fldCityID { get; set; }
    }
}

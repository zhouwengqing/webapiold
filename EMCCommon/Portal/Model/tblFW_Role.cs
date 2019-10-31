namespace EMCCommon.Portal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblFW_Role
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldName { get; set; }

        //[Required]
        [StringLength(500)]
        public string fldRoleDesc { get; set; }

        public int fldCityID { get; set; }
    }
}

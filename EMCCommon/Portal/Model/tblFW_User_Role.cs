namespace EMCCommon.Portal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblFW_User_Role
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldUserID { get; set; }

        public int fldRoleID { get; set; }
    }
}

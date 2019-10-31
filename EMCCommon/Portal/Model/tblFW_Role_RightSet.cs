namespace EMCCommon.Portal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblFW_Role_RightSet
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldRoleID { get; set; }

        public int fldRightSetID { get; set; }
    }
}

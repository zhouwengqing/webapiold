namespace EMCCommon.Lap.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblFWContact")]
    public partial class tblFWContact
    {
        [Key]
        public int fldAutoID { get; set; }

        public string fldSTName { get; set; }

        public string fldName { get; set; }

        public string fldTittle { get; set; }

        public string fldWork { get; set; }

        public string fldTel { get; set; }

        public string fldQQ { get; set; }

        public string fldRemark { get; set; }
    }
}

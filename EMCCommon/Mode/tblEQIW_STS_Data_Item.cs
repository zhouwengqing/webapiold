namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_STS_Data_Item
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        public string fldItemCode { get; set; }

        public string fldItemName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Value { get; set; }
    }
}

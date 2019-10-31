namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_DayOfData_Item_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        [StringLength(50)]
        public string fldItemTypeValue { get; set; }

        [StringLength(50)]
        public string fldItemCodeType { get; set; }
    }
}

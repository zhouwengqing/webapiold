namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_YearBook_Item_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        public string fldItemCode { get; set; }

        public string fld_Value { get; set; }
    }
}

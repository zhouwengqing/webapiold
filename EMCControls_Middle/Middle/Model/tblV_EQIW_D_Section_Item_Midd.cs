namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblV_EQIW_D_Section_Item_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        public string fldItemCode { get; set; }

        public string fld_Value { get; set; }

        public string fld_Stage { get; set; }

        public string fld_CPI { get; set; }

        public string fld_CFI { get; set; }
    }
}

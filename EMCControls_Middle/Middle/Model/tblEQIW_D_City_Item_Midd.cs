namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_City_Item_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        public string fldItemCode { get; set; }

        public string fld_Value { get; set; }

        public string fld_Min { get; set; }

        public string fld_Max { get; set; }

        public string fld_AvgValueStage { get; set; }

        public string fld_MaxValueStage { get; set; }

        public string fld_Count { get; set; }

        public string fld_OutCount { get; set; }

        public string fld_OutScale { get; set; }

        public string fld_AvgOut { get; set; }

        public string fld_MaxOut { get; set; }
    }
}

namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblHM_EQIW_RLD_STatType3_Item_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        [StringLength(50)]
        public string fldItemCode { get; set; }

        [StringLength(50)]
        public string fld_Value { get; set; }

        [StringLength(50)]
        public string fld_Stage { get; set; }

        [StringLength(50)]
        public string fld_STG { get; set; }

        [StringLength(50)]
        public string fld_Over { get; set; }

        [StringLength(50)]
        public string fld_OutScale { get; set; }

        [StringLength(50)]
        public string fld_Min { get; set; }

        [StringLength(50)]
        public string fld_Max { get; set; }

        [StringLength(50)]
        public string fld_MaxOut { get; set; }

        [StringLength(50)]
        public string fld_MaxDate { get; set; }
    }
}

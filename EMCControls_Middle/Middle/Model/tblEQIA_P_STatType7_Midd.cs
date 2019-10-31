namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_P_STatType7_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string TimeType { get; set; }

        [StringLength(50)]
        public string AppriseID { get; set; }

        [StringLength(50)]
        public string fldYear { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldPCode { get; set; }

        [StringLength(50)]
        public string fldPName { get; set; }

        [StringLength(50)]
        public string fldStation { get; set; }

        [StringLength(50)]
        public string fldAppDate { get; set; }

        [StringLength(50)]
        public string fldType { get; set; }

        [StringLength(50)]
        public string fld125 { get; set; }

        [StringLength(50)]
        public string fld116 { get; set; }

        [StringLength(50)]
        public string fld117 { get; set; }

        [StringLength(50)]
        public string fld118 { get; set; }

        [StringLength(50)]
        public string fld119 { get; set; }

        [StringLength(50)]
        public string fld120 { get; set; }

        [StringLength(50)]
        public string fld121 { get; set; }

        [StringLength(50)]
        public string fld122 { get; set; }

        [StringLength(50)]
        public string fld123 { get; set; }

        [StringLength(50)]
        public string fld124 { get; set; }

        [StringLength(50)]
        public string fld140 { get; set; }
    }
}

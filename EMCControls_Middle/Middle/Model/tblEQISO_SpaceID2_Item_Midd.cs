namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQISO_SpaceID2_Item_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        [StringLength(50)]
        public string fldItemCode { get; set; }

        [StringLength(50)]
        public string fldItemValue { get; set; }

        [StringLength(50)]
        public string Count { get; set; }

        [StringLength(50)]
        public string Val { get; set; }

        [StringLength(50)]
        public string OutCount { get; set; }

        [StringLength(50)]
        public string OutScale { get; set; }

        [StringLength(50)]
        public string CheckCount { get; set; }

        [StringLength(50)]
        public string fldCheckScale { get; set; }
    }
}

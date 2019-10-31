namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblCorrespond_Btype_ItemCode
    {
        [Key]
        public int fldAutoid { get; set; }

        //[Required]
        [StringLength(20)]
        public string fldBName { get; set; }

        //[Required]
        [StringLength(20)]
        public string fldItemCode { get; set; }

        //[Required]
        [StringLength(50)]
        public string fldItemName { get; set; }

        //[Required]
        [StringLength(20)]
        public string fldRelation { get; set; }

        //[Required]
        [StringLength(20)]
        public string fldCItemCode { get; set; }

        //[Required]
        [StringLength(50)]
        public string fldCItemName { get; set; }

        public string fldIndex { get; set; }

        public string fldExpression { get; set; }
    }
}

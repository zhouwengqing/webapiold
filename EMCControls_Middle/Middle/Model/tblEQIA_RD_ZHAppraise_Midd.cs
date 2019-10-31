namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_RD_ZHAppraise_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string TimeType { get; set; }

        [StringLength(50)]
        public string fldYear { get; set; }

        [StringLength(50)]
        public string AppriseID { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldPCode { get; set; }

        [StringLength(50)]
        public string fldPName { get; set; }

        [StringLength(50)]
        public string fldDate { get; set; }

        [StringLength(50)]
        public string fldType { get; set; }

        [StringLength(50)]
        public string fldItemCode { get; set; }

        [StringLength(50)]
        public string fldItemName { get; set; }

        [StringLength(50)]
        public string fldItemValue { get; set; }

        [StringLength(50)]
        public string fldItemCompare { get; set; }

        [StringLength(50)]
        public string fldCityCompare { get; set; }

        [StringLength(50)]
        public string fldOverVal { get; set; }

        [StringLength(50)]
        public string fldMinValue { get; set; }

        [StringLength(50)]
        public string fldMinDate { get; set; }

        [StringLength(50)]
        public string fldMaxValue { get; set; }

        [StringLength(50)]
        public string fldMaxDate { get; set; }

        [StringLength(50)]
        public string fldCount { get; set; }

        [StringLength(50)]
        public string fldOverCount { get; set; }

        [StringLength(50)]
        public string fldOverScale { get; set; }

        [StringLength(50)]
        public string fldMaxOver { get; set; }
    }
}

namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_P_STatType4_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string 城市名称 { get; set; }

        [StringLength(50)]
        public string 测点名称 { get; set; }

        [StringLength(50)]
        public string PType { get; set; }

        public DateTime? fldSDate { get; set; }

        public DateTime? fldEDate { get; set; }

        [StringLength(50)]
        public string 降水类型 { get; set; }

        [StringLength(50)]
        public string fld131 { get; set; }

        [StringLength(50)]
        public string fld115 { get; set; }

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
        public string fldRain { get; set; }

        [StringLength(50)]
        public string fldCation { get; set; }

        [StringLength(50)]
        public string fldAnion { get; set; }

        [StringLength(50)]
        public string fldR1 { get; set; }

        [StringLength(50)]
        public string fldR1Desc { get; set; }

        [StringLength(50)]
        public string fldCalc { get; set; }

        [StringLength(50)]
        public string fldMeas { get; set; }

        [StringLength(50)]
        public string fldR2 { get; set; }

        [StringLength(50)]
        public string fldR2Desc { get; set; }
    }
}

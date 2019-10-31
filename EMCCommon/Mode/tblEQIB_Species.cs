namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIB_Species
    {
        [Key]
        public int fldAutoID { get; set; }

        public short? fldBType { get; set; }

        [StringLength(50)]
        public string fldTypeCode { get; set; }

        [StringLength(30)]
        public string fldPCode { get; set; }

        [StringLength(50)]
        public string fldPName { get; set; }

        [StringLength(30)]
        public string fldOCode { get; set; }

        [StringLength(50)]
        public string fldOName { get; set; }

        [StringLength(30)]
        public string fldICode { get; set; }

        [StringLength(50)]
        public string fldIName { get; set; }

        [StringLength(40)]
        public string fldSCode { get; set; }

        [StringLength(50)]
        public string fldSName { get; set; }

        [StringLength(50)]
        public string fldGCode { get; set; }

        [StringLength(50)]
        public string fldGName { get; set; }

        [StringLength(50)]
        public string fldCCode { get; set; }

        [StringLength(50)]
        public string fldCName { get; set; }

        [StringLength(50)]
        public string fldCTypeCode { get; set; }

        [StringLength(50)]
        public string fldCTypeName { get; set; }

        [StringLength(50)]
        public string fldCLatinName { get; set; }

        public short? fldSort { get; set; }
    }
}

namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblHM_EQIA_R_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        [StringLength(50)]
        public string fldCityCode { get; set; }

        [StringLength(50)]
        public string fldCityName { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldLCode { get; set; }

        [StringLength(50)]
        public string fldLName { get; set; }

        [StringLength(50)]
        public string fldPCode { get; set; }

        [StringLength(50)]
        public string fldPName { get; set; }

        [StringLength(50)]
        public string fldLevel { get; set; }

        [StringLength(50)]
        public string fldTrade { get; set; }

        [StringLength(50)]
        public string fldDate { get; set; }

        [StringLength(50)]
        public string fldType { get; set; }

        [StringLength(50)]
        public string fldCount { get; set; }

        [StringLength(50)]
        public string fldStdCount { get; set; }

        [StringLength(50)]
        public string fldOverItems { get; set; }

        [StringLength(50)]
        public string fldOvers { get; set; }

        [StringLength(50)]
        public string fldOverDate { get; set; }
    }
}

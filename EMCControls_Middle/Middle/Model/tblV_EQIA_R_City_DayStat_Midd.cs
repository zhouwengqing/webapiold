namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblV_EQIA_R_City_DayStat_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [Required]
        [StringLength(10)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        public DateTime fldAppDate { get; set; }

        [StringLength(5)]
        public string fldMaxDAPI { get; set; }

        [StringLength(100)]
        public string fldItem { get; set; }

        [StringLength(150)]
        public string fldOverItems { get; set; }
    }
}

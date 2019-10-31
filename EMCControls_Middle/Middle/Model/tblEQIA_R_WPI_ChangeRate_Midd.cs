namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_R_WPI_ChangeRate_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(12)]
        public string fldSTCode { get; set; }

        [StringLength(60)]
        public string fldSTName { get; set; }

        [StringLength(10)]
        public string fldTimeType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldMonth { get; set; }

        [StringLength(10)]
        public string fldLevel { get; set; }

        [StringLength(10)]
        public string fldWPI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldChangeRate { get; set; }
    }
}

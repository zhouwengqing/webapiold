namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_R_Item
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(10)]
        public string fldItemCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldItemName { get; set; }

        [Required]
        [StringLength(10)]
        public string fldCharCode { get; set; }

        [Required]
        [StringLength(20)]
        public string fldChineseCode { get; set; }

        [Required]
        [StringLength(25)]
        public string fldUnit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldInt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldDec { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMinValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMaxValue { get; set; }

        [Required]
        [StringLength(200)]
        public string fldAnalyseWay { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldSense { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldDaySample { get; set; }

        public bool fldCalcAPI { get; set; }
        

        public bool fldRender { get; set; }

        public bool fldShowGIS { get; set; }

        public short fldSort { get; set; }

        [StringLength(80)]
        public string fldStandardNum { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldSTLevel { get; set; }

        public DateTime fldMCSDate { get; set; }

        public DateTime fldMCEDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldMutationRate { get; set; }
    }
}

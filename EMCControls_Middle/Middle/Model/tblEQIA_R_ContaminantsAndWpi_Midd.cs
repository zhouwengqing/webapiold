namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIA_R_ContaminantsAndWpi_Midd
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(12)]
        public string fldSTCode { get; set; }

        [StringLength(60)]
        public string fldSTName { get; set; }

        [StringLength(30)]
        public string fldPCode { get; set; }

        [StringLength(60)]
        public string fldPName { get; set; }

        [StringLength(10)]
        public string fldTimeType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldMonth { get; set; }

        [StringLength(10)]
        public string fldSumCount { get; set; }

        [StringLength(10)]
        public string fldCount { get; set; }

        [StringLength(10)]
        public string fldWPI { get; set; }

        [StringLength(10)]
        public string fldSO2AVG { get; set; }

        [StringLength(10)]
        public string fldSO2CFI { get; set; }

        [StringLength(10)]
        public string fldSO2CFI_W { get; set; }

        [StringLength(10)]
        public string fldSO2CPI { get; set; }

        [StringLength(10)]
        public string fldSO2Load { get; set; }

        [StringLength(10)]
        public string fldPM25AVG { get; set; }

        [StringLength(10)]
        public string fldPM25CFI { get; set; }

        [StringLength(10)]
        public string fldPM25CFI_W { get; set; }

        [StringLength(10)]
        public string fldPM25CPI { get; set; }

        [StringLength(10)]
        public string fldPM25Load { get; set; }

        [StringLength(10)]
        public string fldPM10AVG { get; set; }

        [StringLength(10)]
        public string fldPM10CFI { get; set; }

        [StringLength(10)]
        public string fldPM10CFI_W { get; set; }

        [StringLength(10)]
        public string fldPM10CPI { get; set; }

        [StringLength(10)]
        public string fldPM10Load { get; set; }

        [StringLength(10)]
        public string fldO3AVG { get; set; }

        [StringLength(10)]
        public string fldO3CFI { get; set; }

        [StringLength(10)]
        public string fldO3CFI_W { get; set; }

        [StringLength(10)]
        public string fldO3CPI { get; set; }

        [StringLength(10)]
        public string fldO3Load { get; set; }

        [StringLength(10)]
        public string fldCOAVG { get; set; }

        [StringLength(10)]
        public string fldCOCFI { get; set; }

        [StringLength(10)]
        public string fldCOCFI_W { get; set; }

        [StringLength(10)]
        public string fldCOCPI { get; set; }

        [StringLength(10)]
        public string fldCOLoad { get; set; }

        [StringLength(10)]
        public string fldNO2AVG { get; set; }

        [StringLength(10)]
        public string fldNO2CFI { get; set; }

        [StringLength(10)]
        public string fldNO2CFI_W { get; set; }

        [StringLength(10)]
        public string fldNO2CPI { get; set; }

        [StringLength(10)]
        public string fldNO2Load { get; set; }
    }
}

namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIE_CityData_Pre
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(12)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        public int? fldYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldEQIWR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldEQIAR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldEQIWD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldEQINA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldHeatisLand { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldEcology { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldGreenbelt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldGDP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldEPIIWater { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldWaste { get; set; }

        public short fldImport { get; set; }

        public short fldFlag { get; set; }

        public int fldCityID_Operate { get; set; }

        [Required]
        [StringLength(100)]
        public string fldCityID_Submit { get; set; }

        public int fldUserID { get; set; }

        public DateTime fldDate_Operate { get; set; }

        [Required]
        [StringLength(50)]
        public string fldBatch { get; set; }

        public int fldDeleteState { get; set; }
    }
}

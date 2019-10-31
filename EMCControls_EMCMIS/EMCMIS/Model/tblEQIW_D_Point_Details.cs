namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_Point_Details
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldWSCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldWSName { get; set; }

        [StringLength(50)]
        public string fldAliasName { get; set; }

        [Required]
        [StringLength(20)]
        public string fldSCategory { get; set; }

        public short fldState { get; set; }
        
        [StringLength(20)]
        public string fldLevel { get; set; }

        [Required]
        [StringLength(20)]
        public string fldRSTown { get; set; }

        [Required]
        [StringLength(50)]
        public string fldAddress { get; set; }

        [StringLength(50)]
        public string fldLongitude { get; set; }

        [StringLength(50)]
        public string fldLatitude { get; set; }

        [StringLength(200)]
        public string fldSynopsis { get; set; }

        [StringLength(50)]
        public string fldFirstWaterSys { get; set; }

        [StringLength(50)]
        public string fldSecondWaterSys { get; set; }

        [StringLength(50)]
        public string fldThirdWaterSys { get; set; }

        [StringLength(50)]
        public string fldProvideType { get; set; }

        public int? fldStand { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldServicePeople { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldSupplyWater { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldDesignQuantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fldActualQuantity { get; set; }

        [StringLength(10)]
        public string fldBuildYear { get; set; }
    }
}

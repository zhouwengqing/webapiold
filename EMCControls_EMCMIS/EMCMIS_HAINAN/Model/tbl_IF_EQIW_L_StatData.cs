namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_IF_EQIW_L_StatData
    {
        [Key]
        public long fldAutoID { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldSTName { get; set; }

        [Required]
        [StringLength(12)]
        public string fldLCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldLName { get; set; }

        [Required]
        [StringLength(20)]
        public string fldLSCode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldLSName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldWaterArea { get; set; }

        [Required]
        [StringLength(20)]
        public string fldSLevel { get; set; }

        [Required]
        [StringLength(20)]
        public string fldFun { get; set; }

        [Required]
        [StringLength(20)]
        public string fldAim { get; set; }

        [Required]
        [StringLength(50)]
        public string fldDate { get; set; }

        [Required]
        [StringLength(20)]
        public string fldStage { get; set; }

        [Required]
        [StringLength(20)]
        public string fldStand { get; set; }

        [Required]
        public string fldOverItem3 { get; set; }

        [Required]
        public string fldOverItemAim { get; set; }

        [Required]
        [StringLength(30)]
        public string fldUpdateTime { get; set; }
    }
}

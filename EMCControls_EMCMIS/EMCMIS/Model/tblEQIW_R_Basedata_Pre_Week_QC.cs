namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_Basedata_Pre_Week_QC
    {
        [Key]
        public long fldAutoID { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Required]
        [StringLength(12)]
        public string fldRCode { get; set; }

        [Required]
        [StringLength(20)]
        public string fldRSCode { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSAMPH { get; set; }

        [Required]
        [StringLength(12)]
        public string fldSAMPR { get; set; }

        [Required]
        [StringLength(10)]
        public string fldRSC { get; set; }

        public DateTime? fldDate { get; set; }

        [Required]
        [StringLength(10)]
        public string fldItemCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldItemValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldActualValue { get; set; }

        public short fldFlag { get; set; }

        public short fldImport { get; set; }

        public int fldCityID_Operate { get; set; }

        [Required]
        [StringLength(100)]
        public string fldCityID_Submit { get; set; }

        public DateTime fldDate_Operate { get; set; }

        public int fldUserID { get; set; }

        public short fldSource { get; set; }

        [Required]
        [StringLength(50)]
        public string fldBatch { get; set; }

        public int fldDeleteState { get; set; }



        /// <summary>
        /// 相对误差
        /// </summary>
        [NotMapped]
        public string RelativeError { get; set; }


        /// <summary>
        /// 是否达标
        /// </summary>
        [NotMapped]
        public bool IsReachTheStandard { get; set; }


    }
}

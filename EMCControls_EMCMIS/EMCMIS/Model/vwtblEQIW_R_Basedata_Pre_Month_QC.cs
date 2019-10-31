namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vwtblEQIW_R_Basedata_Pre_Month_QC
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [StringLength(30)]
        public string fldSTName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string fldRCode { get; set; }

        [StringLength(100)]
        public string fldRName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string fldRSCode { get; set; }

        [StringLength(100)]
        public string fldRSName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(12)]
        public string fldSAMPH { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(12)]
        public string fldSAMPR { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string fldRSC { get; set; }

        public string fldDate { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(10)]
        public string fldItemCode { get; set; }

        [StringLength(50)]
        public string fldItemName { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal fldItemValue { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "numeric")]
        public decimal fldActualValue { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short fldFlag { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short fldImport { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fldCityID_Operate { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(100)]
        public string fldCityID_Submit { get; set; }

        [Key]
        [Column(Order = 13)]
        public DateTime fldDate_Operate { get; set; }

        [Key]
        [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fldUserID { get; set; }

        [Key]
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short fldSource { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(50)]
        public string fldBatch { get; set; }

        [Key]
        [Column(Order = 17)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        public string IsReachTheStandard { get; set; }
    }
}

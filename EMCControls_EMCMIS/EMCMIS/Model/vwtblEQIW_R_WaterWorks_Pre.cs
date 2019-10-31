namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vwtblEQIW_R_WaterWorks_Pre
    {
        [Key]
        [Column(Order = 0)]
        public int fldAutoID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string fldSTCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string fldSTName { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal fldYear { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(12)]
        public string fldWWCode { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string fldWWName { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(200)]
        public string fldAttribute { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fldSort { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short fldFlag { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fldCityID_Operate { get; set; }
    }
}

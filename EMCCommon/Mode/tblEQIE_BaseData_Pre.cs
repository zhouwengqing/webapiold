namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIE_BaseData_Pre
    {
        [Key]
        public long fldAutoID { get; set; }

        [StringLength(12)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        public int fldYear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldArea { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld21 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld22 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld23 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld24 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld31 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld32 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld33 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld41 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld42 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld43 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld44 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld45 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld46 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld47 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld11 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld12 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld51 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld52 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld53 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld61 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld62 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld63 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld64 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld65 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld66 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld67 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld71 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld72 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld73 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld81 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld82 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld83 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld91 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld92 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld93 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld94 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld95 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld96 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld97 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fld98 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldNDVI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldIndex { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fldPopulation { get; set; }

        public short fldSource { get; set; }

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

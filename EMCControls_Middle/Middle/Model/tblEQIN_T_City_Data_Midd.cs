namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_T_City_Data_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string ReportType { get; set; }

        [StringLength(50)]
        public string STatType { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldDN { get; set; }

        [StringLength(50)]
        public string fldYear { get; set; }

        [StringLength(50)]
        public string fldObjectID { get; set; }

        [StringLength(50)]
        public string fldObject { get; set; }

        [StringLength(50)]
        public string fldCount { get; set; }

        [StringLength(50)]
        public string fldCount_Scale { get; set; }

        [StringLength(50)]
        public string fldArea { get; set; }

        [StringLength(50)]
        public string fldArea_Scale { get; set; }

        [StringLength(50)]
        public string fldPTrafic { get; set; }

        [StringLength(50)]
        public string fldPTrafic_Scale { get; set; }

        [StringLength(50)]
        public string fldLeqa { get; set; }

        [StringLength(50)]
        public string fldOutCount { get; set; }

        [StringLength(50)]
        public string fldOutCount_Scale { get; set; }

        [StringLength(50)]
        public string fldOutArea { get; set; }

        [StringLength(50)]
        public string fldOutArea_Scale { get; set; }

        [StringLength(50)]
        public string fldAvgLen { get; set; }

        [StringLength(50)]
        public string fldAvgWid { get; set; }

        [StringLength(50)]
        public string fldCount_All { get; set; }

        [StringLength(50)]
        public string fldCount_Road { get; set; }

        [StringLength(50)]
        public string fldArea_All { get; set; }

        [StringLength(50)]
        public string fldPTrafic_All { get; set; }

        [StringLength(50)]
        public string fldLEQA_All { get; set; }

        [StringLength(50)]
        public string fldL10_All { get; set; }

        [StringLength(50)]
        public string fldL50_All { get; set; }

        [StringLength(50)]
        public string fldL90_All { get; set; }

        [StringLength(50)]
        public string fldLevel_All { get; set; }
    }
}

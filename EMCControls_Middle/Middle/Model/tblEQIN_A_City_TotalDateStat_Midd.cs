namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIN_A_City_TotalDateStat_Midd
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
        public string fldObject { get; set; }

        [StringLength(50)]
        public string fldObjectName { get; set; }

        [StringLength(50)]
        public string fldCount { get; set; }

        [StringLength(50)]
        public string fldCount_Scale { get; set; }

        [StringLength(50)]
        public string fldArea { get; set; }

        [StringLength(50)]
        public string fldArea_Scale { get; set; }

        [StringLength(50)]
        public string fldPeople { get; set; }

        [StringLength(50)]
        public string fldPeople_Scale { get; set; }

        [StringLength(50)]
        public string fldLeqa { get; set; }

        [StringLength(50)]
        public string fldLevel { get; set; }

        [StringLength(50)]
        public string fldLeqaSD { get; set; }

        [StringLength(50)]
        public string fldLeqa10 { get; set; }

        [StringLength(50)]
        public string fldLeqa10SD { get; set; }

        [StringLength(50)]
        public string fldLeqa50 { get; set; }

        [StringLength(50)]
        public string fldLeqa50SD { get; set; }

        [StringLength(50)]
        public string fldLeqa90 { get; set; }

        [StringLength(50)]
        public string fldLeqa90SD { get; set; }

        [StringLength(50)]
        public string fldGL_All { get; set; }

        [StringLength(50)]
        public string fldGW_All { get; set; }

        [StringLength(50)]
        public string fldCount_All { get; set; }

        [StringLength(50)]
        public string fldOutCount_All { get; set; }

        [StringLength(50)]
        public string fldOutScale { get; set; }

        [StringLength(50)]
        public string fldArea_All { get; set; }

        [StringLength(50)]
        public string fldPeople_All { get; set; }

        [StringLength(50)]
        public string fldLEQA_All { get; set; }

        [StringLength(50)]
        public string fldL10_All { get; set; }

        [StringLength(50)]
        public string fldL50_All { get; set; }

        [StringLength(50)]
        public string fldL90_All { get; set; }

        [StringLength(50)]
        public string fldSD_All { get; set; }

        [StringLength(50)]
        public string fldLevel_All { get; set; }
    }
}

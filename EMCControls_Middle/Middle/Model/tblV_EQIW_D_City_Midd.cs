namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblV_EQIW_D_City_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        public string STatType { get; set; }

        public string fldTimeType { get; set; }

        public string fldCityCode { get; set; }

        public string fldCityName { get; set; }

        public string fldSTCode { get; set; }

        public string fldSTName { get; set; }

        public string fldAppDate { get; set; }

        public string fldSCategory { get; set; }

        public string fldSetCount { get; set; }

        public string fldRSCount { get; set; }

        public string fldYJCheckItem { get; set; }

        public string fldWJCheckItem { get; set; }

        public string fldAllSL { get; set; }

        public string fldStdSL { get; set; }

        public string fldScale { get; set; }

        public string fldFStdSL { get; set; }

        public string fldFScale { get; set; }

        public string fldCount { get; set; }

        public string fldStdCount { get; set; }

        public string fldstdScale { get; set; }

        public string fldFstdCount { get; set; }

        public string fldFstdScale { get; set; }

        public string fldStdSecion { get; set; }

        public string fldSectionScale { get; set; }

        public string fldFStdSecion { get; set; }

        public string fldFSectionScale { get; set; }

        public string fldSections { get; set; }

        public string fldFSections { get; set; }

        public string fld1Count { get; set; }

        public string fld1Scale { get; set; }

        public string fld2Count { get; set; }

        public string fld2Scale { get; set; }

        public string fld3Count { get; set; }

        public string fld3Scale { get; set; }

        public string fld4Count { get; set; }

        public string fld4Scale { get; set; }

        public string fld5Count { get; set; }

        public string fld5Scale { get; set; }

        public string fld6Count { get; set; }

        public string fld6Scale { get; set; }
    }
}

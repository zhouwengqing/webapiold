namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblV_EQIW_D_YearBook_Midd
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

        public string fldRCode { get; set; }

        public string fldRName { get; set; }

        public string fldRSCode { get; set; }

        public string fldRSName { get; set; }

        public string fldSCategory { get; set; }

        public string fldRSC { get; set; }

        public string fldDate { get; set; }

        public string fldStage { get; set; }

        public string fldOutItems { get; set; }

        public string fldFOutItems { get; set; }
    }
}

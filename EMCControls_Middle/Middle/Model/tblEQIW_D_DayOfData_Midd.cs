namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_D_DayOfData_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        [StringLength(50)]
        public string SpaceID { get; set; }

        [StringLength(50)]
        public string fldCityCode { get; set; }

        [StringLength(50)]
        public string fldCityName { get; set; }

        [StringLength(50)]
        public string fldPrivCode { get; set; }

        [StringLength(50)]
        public string fldPrivName { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldMCity { get; set; }

        [StringLength(50)]
        public string fldNorth { get; set; }

        [StringLength(50)]
        public string fldRSName { get; set; }

        [StringLength(50)]
        public string fldRSCode { get; set; }

        [StringLength(50)]
        public string fldSystem { get; set; }

        [StringLength(50)]
        public string fldSCategory { get; set; }

        [StringLength(50)]
        public string fldJD { get; set; }

        [StringLength(50)]
        public string fldWD { get; set; }

        [StringLength(50)]
        public string fldSL { get; set; }

        [StringLength(50)]
        public string fldDate { get; set; }

        [StringLength(50)]
        public string fldRSC { get; set; }
    }
}

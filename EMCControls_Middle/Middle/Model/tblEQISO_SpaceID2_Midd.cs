namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQISO_SpaceID2_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        [StringLength(50)]
        public string AppriseID { get; set; }

        [StringLength(50)]
        public string STatType { get; set; }

        [StringLength(50)]
        public string fldYear { get; set; }

        [StringLength(50)]
        public string fldCityCode { get; set; }

        [StringLength(50)]
        public string fldCityName { get; set; }

        [StringLength(50)]
        public string fldSTCode { get; set; }

        [StringLength(50)]
        public string fldSTName { get; set; }

        [StringLength(50)]
        public string fldEntCode { get; set; }

        [StringLength(50)]
        public string fldEntName { get; set; }

        [StringLength(50)]
        public string fldAddress { get; set; }

        [StringLength(50)]
        public string fldPCode { get; set; }

        [StringLength(50)]
        public string fldPName { get; set; }

        [StringLength(50)]
        public string fldLevel { get; set; }

        [StringLength(50)]
        public string fldSOType { get; set; }

        [StringLength(50)]
        public string fldWPI_W { get; set; }

        [StringLength(50)]
        public string fldWPI_Y { get; set; }

        [StringLength(50)]
        public string fldWPI_Avg { get; set; }

        [StringLength(50)]
        public string fldWPI_Max { get; set; }

        [StringLength(50)]
        public string fldWPI { get; set; }

        [StringLength(50)]
        public string fldLevelApp { get; set; }

        [StringLength(50)]
        public string fldPCount { get; set; }

        [StringLength(50)]
        public string fldStdCount { get; set; }

        [StringLength(50)]
        public string fldStdScale { get; set; }

        [StringLength(50)]
        public string fldItemOvers { get; set; }

        [StringLength(50)]
        public string fldMaxPiApp { get; set; }

        [StringLength(50)]
        public string fldPnItem { get; set; }

        [StringLength(50)]
        public string fldPiItem { get; set; }
    }
}

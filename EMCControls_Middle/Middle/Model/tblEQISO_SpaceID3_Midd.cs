namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQISO_SpaceID3_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        [StringLength(50)]
        public string fldItemName { get; set; }

        [StringLength(50)]
        public string fldSOType { get; set; }

        [StringLength(50)]
        public string fld1Count { get; set; }

        [StringLength(50)]
        public string fld1Scale { get; set; }

        [StringLength(50)]
        public string fld2Count { get; set; }

        [StringLength(50)]
        public string fld2Scale { get; set; }

        [StringLength(50)]
        public string fld3Count { get; set; }

        [StringLength(50)]
        public string fld3Scale { get; set; }

        [StringLength(50)]
        public string fld4Count { get; set; }

        [StringLength(50)]
        public string fld4Scale { get; set; }

        [StringLength(50)]
        public string fld5Count { get; set; }

        [StringLength(50)]
        public string fld5Scale { get; set; }

        [StringLength(50)]
        public string fldCount { get; set; }

        [StringLength(50)]
        public string fldOutScale { get; set; }

        [StringLength(50)]
        public string fldCFI { get; set; }

        [StringLength(50)]
        public string fldMin { get; set; }

        [StringLength(50)]
        public string fldMax { get; set; }

        [StringLength(50)]
        public string fldAvg { get; set; }

        [StringLength(50)]
        public string fldMaxOut { get; set; }
    }
}

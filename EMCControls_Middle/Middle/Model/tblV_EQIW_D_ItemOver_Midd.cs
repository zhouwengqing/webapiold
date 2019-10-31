namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblV_EQIW_D_ItemOver_Midd
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        public string fldTimeType { get; set; }

        public string fldItemName { get; set; }

        public string fldDate { get; set; }

        public string fldRCount { get; set; }

        public string fldOutCount { get; set; }

        public string fldScale { get; set; }

        public string fldMin { get; set; }

        public string fldMax { get; set; }

        public string fldMaxOut { get; set; }

        public string fldYPCount { get; set; }

        public string fldYPOutCount { get; set; }

        public string fldYPScale { get; set; }

        public string fldYPMaxScale { get; set; }

        public string fldYPOutSection { get; set; }

        public string fldYPOutSectionScale { get; set; }

        public string fldYPMinValue { get; set; }

        public string fldYPMaxValue { get; set; }

        public string fldYPOverValue { get; set; }

        public string fldYPValue { get; set; }
    }
}

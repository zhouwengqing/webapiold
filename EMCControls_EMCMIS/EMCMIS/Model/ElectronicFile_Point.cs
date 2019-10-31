namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ElectronicFile_Point
    {
       
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int fldAutoID { get; set; }

        public string fldPointName { get; set; }

        public int? fldParentID { get; set; }
    }
}

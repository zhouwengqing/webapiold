namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_STS_Data_Log
    {
        [Key]
        public int fldAutoID { get; set; }

        public int fldFKID { get; set; }

        public int? fldUserID { get; set; }

        public DateTime? fldOperateDate { get; set; }

        public string fldContent { get; set; }
    }
}

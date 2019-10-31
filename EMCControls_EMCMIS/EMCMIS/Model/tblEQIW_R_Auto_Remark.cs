namespace EMCControls_EMCMIS.EMCMIS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_Auto_Remark
    {
        [Key]
        public int fldAutoID { get; set; }

        public string fldSTCode { get; set; }

        public string fldRCode { get; set; }

        public string fldRSCode { get; set; }

        public string fldRSName { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fldDate { get; set; }

        public string fldItemCode { get; set; }

        public string fldItemName { get; set; }

        public decimal? fldItemValue { get; set; }

        public string fldAction { get; set; }

        public DateTime? fldAuditingDate { get; set; }

        public string fldAuditor { get; set; }

        public string fldRemark { get; set; }
    }
}

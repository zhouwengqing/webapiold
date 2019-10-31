namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblGatewaynumber")]
    public partial class tblGatewaynumber
    {
        [Key]
   
        public int fldAutoID { get; set; }

      
        [StringLength(50)]
        public string fldNum { get; set; }

       
        [StringLength(50)]
        public string fldChannelName { get; set; }

       
        
        public DateTime fldCreateTime { get; set; }

       
        [StringLength(50)]
        public string fldDeductionType { get; set; }

    
        [StringLength(50)]
        public string fldChannelType { get; set; }
    }
}

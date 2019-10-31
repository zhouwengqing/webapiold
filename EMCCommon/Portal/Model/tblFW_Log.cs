namespace EMCCommon.Portal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblFW_Log
    {
        [Key]
        public long fldAutoID { get; set; }

        public int fldUserID { get; set; }

        public int fldCityID { get; set; }

        public int fldModalID { get; set; }

        public string fldModalName { get; set; }

        [Required]
        [StringLength(5000)]
        public string fldContent { get; set; }

        public DateTime fldDate_operate { get; set; }

        [Required]
        [StringLength(20)]
        public string fldIPAddress { get; set; }
    }
}

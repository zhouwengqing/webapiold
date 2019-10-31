namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class To_Setup
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldType { get; set; }

        [Required]
        [StringLength(50)]
        public string fldTypeName { get; set; }

        [Required]
        [StringLength(50)]
        public string fldTableID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldTableName { get; set; }

        public DateTime fldStartDate { get; set; }

        public DateTime fldEndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string DateType { get; set; }

        public int fldFlag { get; set; }

        public int fldTable_Type { get; set; }

        [Required]
        [StringLength(50)]
        public string fldDateType { get; set; }
    }
}

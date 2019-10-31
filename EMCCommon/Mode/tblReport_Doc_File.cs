namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblReport_Doc_File
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int fldAutoId { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime fldTime { get; set; }

        /// <summary>
        /// 业务类别
        /// </summary>
        [StringLength(50)]
        public string fldType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(50)]
        public string fldTableName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [StringLength(500)]
        public string fldAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool fldDisabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(50)]
        public string flag { get; set; }
    }
}

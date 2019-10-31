namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwOrdertable")]
    public partial class vwOrdertable
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fldAutoID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime fldCreatetime { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(80)]
        public string fldtransactionnum { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(80)]
        public string fldChannelnum { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(80)]
        public string fldOrdernum { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal fldOrderAmount { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal fldRtefundAmount { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(200)]
        public string fldMerchID { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(200)]
        public string fldMerchName { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string fldOrederdetailed { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string fldRateName { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(50)]
        public string fldChannelType { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(50)]
        public string fldUpstreamName { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(50)]
        public string fldChannelID { get; set; }

        public DateTime? fldOrderInvalid { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(50)]
        public string fldNotice { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(50)]
        public string fldLaunchIP { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(50)]
        public string fldStaute { get; set; }

        public DateTime? fldchangstautetime { get; set; }

        public DateTime? fldtransactiontime { get; set; }

        [Key]
        [Column(Order = 17, TypeName = "numeric")]
        public decimal fldSettlement { get; set; }

        [Key]
        [Column(Order = 18, TypeName = "numeric")]
        public decimal fldServiceCharge { get; set; }
    }
}

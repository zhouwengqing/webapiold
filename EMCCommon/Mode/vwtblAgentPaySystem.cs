namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwtblAgentPaySystem")]
    public partial class vwtblAgentPaySystem
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
        [StringLength(50)]
        public string fldtransactionnum { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string fldOrdernum { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string fldMerchID { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(200)]
        public string fldMerchName { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal fldPayAmount { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string fldPayState { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "numeric")]
        public decimal fldServiceCharge { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string fldAccountname { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string fldBankCardId { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(50)]
        public string fldBankName { get; set; }

        [Key]
        [Column(Order = 12)]
        public DateTime fldchangstautetime { get; set; }

        [Key]
        [Column(Order = 13, TypeName = "numeric")]
        public decimal fldRtefundAmount { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(50)]
        public string fldBankType { get; set; }

        [Key]
        [Column(Order = 15, TypeName = "numeric")]
        public decimal fldSettlementAmount { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(50)]
        public string fldBankcity { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(50)]
        public string fldBankprovince { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(50)]
        public string fldBankbranch { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(50)]
        public string fldBankTelephoneNo { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(50)]
        public string fldIdCard { get; set; }

        [Key]
        [Column(Order = 21)]
        [StringLength(50)]
        public string fldCardType { get; set; }
    }
}

namespace EMCCommon.Mode
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblChannelinformation")]
    public partial class tblChannelinformation
    {
        [Key]
        public int fldAutoID { get; set; }

        
        [StringLength(50)]
        public string fldUpstreamMerchantID { get; set; }

       
        [StringLength(50)]
        public string fldUpstreamName { get; set; }

      
        [StringLength(50)]
        public string fldNum { get; set; }

       
        [StringLength(50)]
        public string fldType { get; set; }

       
        [StringLength(50)]
        public string fldPayType { get; set; }

      
        [StringLength(60)]
        public string fldUpstreamSecretKey { get; set; }

        
        public string fldRequestUrl { get; set; }

        
        public bool fldState { get; set; }

       
        [StringLength(200)]
        public string fldAsynchronousUrl { get; set; }
    }
}

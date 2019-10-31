using System;
using System.ComponentModel.DataAnnotations;

namespace EMCControls_Middle.Middle.Model
{
    public class tblEQIA_R_Info_Midd
    {
        [Key]
        public int fldAutoID { get; set; }
        
        public string TimeType { get; set; }
        
        public DateTime? BeginDate { get; set; }
        
        public DateTime? EndDate { get; set; }
        
        public string fldPCode { get; set; }
        
        public string fldStandardName { get; set; }
        
        public int? fldLevel { get; set; }
        
        public string fldItemCode { get; set; }
        
        public string DecCarry { get; set; }
        
        public int? IsPre { get; set; }
        
        public int? IsYear { get; set; }
        
        public int? IsTotal { get; set; }
        
        public int? IsDetail { get; set; }
        
        public int? fldSource { get; set; }
        
        public int? AppriseID { get; set; }
        
        public int? STatType { get; set; }
        
        public int? CityID { get; set; }
        
        public int? CalculateID { get; set; }
        
        public string ItemValueType { get; set; }
    }
}
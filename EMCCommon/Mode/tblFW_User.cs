namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblFW_User
    {
        [Key]
        public int fldAutoID { get; set; }

        [Required]
        [StringLength(20)]
        public string fldUserName { get; set; }

        [Required]
        [StringLength(20)]
        public string fldUserDesc { get; set; }

        [Required]
        [StringLength(32)]
        public string fldPassword { get; set; }

        public int fldDeptID { get; set; }

        public int fldCityID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldDuty { get; set; }

        [Required]
        [StringLength(30)]
        public string fldHeaderShip { get; set; }

        public bool fldSex { get; set; }

        public short fldEducation { get; set; }

        public DateTime fldBirthday { get; set; }

        [Required]
        [StringLength(50)]
        public string fldEmail { get; set; }

        [Required]
        [StringLength(30)]
        public string fldPhone { get; set; }

        [Required]
        [StringLength(11)]
        public string fldMobile { get; set; }

        public bool fldActive { get; set; }

        [Required]
        [StringLength(400)]
        public string fldMemo { get; set; }
    }
}

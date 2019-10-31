namespace EMCCommon.Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEQIW_R_DevelopmentPace
    {
        [Key]
        public int fldAutoID { get; set; }

        public string fldSTName { get; set; }

        public string fldRName { get; set; }

        public string fldRSName { get; set; }

        public string 建设情况 { get; set; }

        public string 上报时间 { get; set; }

        public string 新建水站_落实经费_计划开始时间 { get; set; }

        public string 新建水站_落实经费_计划完成时间 { get; set; }

        public string 新建水站_落实经费_是否完成 { get; set; }

        public string 新建水站_落实经费_未完成原因 { get; set; }

        public string 新建水站_征租地_计划开始时间 { get; set; }

        public string 新建水站_征租地_计划完成时间 { get; set; }

        public string 新建水站_征租地_是否完成 { get; set; }

        public string 新建水站_征租地_未完成原因 { get; set; }

        public string 新建水站_设计图纸_计划开始时间 { get; set; }

        public string 新建水站_设计图纸_计划完成时间 { get; set; }

        public string 新建水站_设计图纸_是否完成 { get; set; }

        public string 新建水站_设计图纸_未完成原因 { get; set; }

        public string 新建水站_招投标_计划开始时间 { get; set; }

        public string 新建水站_招投标_计划完成时间 { get; set; }

        public string 新建水站_招投标_是否完成 { get; set; }

        public string 新建水站_招投标_未完成原因 { get; set; }

        public string 新建水站_四通一平_计划开始时间 { get; set; }

        public string 新建水站_四通一平_计划完成时间 { get; set; }

        public string 新建水站_四通一平_是否完成 { get; set; }

        public string 新建水站_四通一平_未完成原因 { get; set; }

        public string 新建水站_主体建设_计划开始时间 { get; set; }

        public string 新建水站_主体建设_计划完成时间 { get; set; }

        public string 新建水站_主体建设_是否完成 { get; set; }

        public string 新建水站_主体建设_未完成原因 { get; set; }

        public string 新建水站_室内装修_计划开始时间 { get; set; }

        public string 新建水站_室内装修_计划完成时间 { get; set; }

        public string 新建水站_新建水站_室内装修_是否完成 { get; set; }

        public string 新建水站_室内装修_未完成原因 { get; set; }

        public string 新建水站_采水系统建设_计划开始时间 { get; set; }

        public string 新建水站_采水系统建设_计划完成时间 { get; set; }

        public string 新建水站_采水系统建设_是否完成 { get; set; }

        public string 新建水站_采水系统建设_未完成原因 { get; set; }

        public string 新建水站_联网运行_计划开始时间 { get; set; }

        public string 新建水站_联网运行_计划完成时间 { get; set; }

        public string 新建水站_联网运行_是否完成 { get; set; }

        public string 新建水站_联网运行_未完成原因 { get; set; }

        public string 已建水站_落实经费_计划开始时间 { get; set; }

        public string 已建水站_落实经费_计划完成时间 { get; set; }

        public string 已建水站_落实经费_是否完成 { get; set; }

        public string 已建水站_落实经费_未完成原因 { get; set; }

        public string 已建水站_仪器设备补齐情况_计划开始时间 { get; set; }

        public string 已建水站_仪器设备补齐情况_计划完成时间 { get; set; }

        public string 已建水站_仪器设备补齐情况_是否完成 { get; set; }

        public string 已建水站_仪器设备补齐情况_未完成原因 { get; set; }

        public string 已建水站_系统更新情况_计划开始时间 { get; set; }

        public string 已建水站_系统更新情况_计划完成时间 { get; set; }

        public string 已建水站_系统更新情况_是否完成 { get; set; }

        public string 已建水站_系统更新情况_未完成原因 { get; set; }

        public string 已建水站_联网运行_计划开始时间 { get; set; }

        public string 已建水站_联网运行_计划完成时间 { get; set; }

        public string 已建水站_联网运行_是否完成 { get; set; }

        public string 已建水站_联网运行_未完成原因 { get; set; }
    }
}

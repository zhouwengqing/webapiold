using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqiw.eqiw_l
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEQIW_L_RawDataController : ApiController
    {


        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由通用存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-15
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetRawData(Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@EBeginDate",info.EBeginDate),
                    new SqlParameter("@EEndDate",info.EEndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldLSCode",info.fldLSCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@IsPre",info.IsPre),
                    new SqlParameter("@IsYear",info.IsYear),
                    new SqlParameter("@IsTotal",info.IsTotal),
                    new SqlParameter("@IsDetail",info.IsDetail),
                    new SqlParameter("@IsTLI",info.IsTLI),
                    new SqlParameter("@TLIType",info.TLIType),
                    new SqlParameter("@AppriseID",info.AppriseID),
                    new SqlParameter("@SpaceID",info.SpaceID),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@Para1ID",info.Para1ID),
                    new SqlParameter("@Para2ID",info.Para2ID),
                    new SqlParameter("@Source",info.Source)
                };

                dt = rule.RunProcedure("usp_tblEQIW_L_Report_Apprise", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 存储过程参数实体
        /// </summary>
        public class Info
        {

            /// <summary>
            /// 时间类型
            /// </summary>
            public string TimeType { get; set; }


            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }


            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndDate { get; set; }


            /// <summary>
            /// 第二个时段开始时间
            /// </summary>
            public string EBeginDate { get; set; }


            /// <summary>
            /// 第二个时段结束时间
            /// </summary>
            public string EEndDate { get; set; }


            /// <summary>
            /// 水期代码
            /// </summary>
            public string fldRSC { get; set; }


            /// <summary>
            /// 测点代码
            /// </summary>
            public string fldLSCode { get; set; }


            /// <summary>
            /// 湖库标准级别名称
            /// </summary>
            public string fldStandardName { get; set; }


            /// <summary>
            /// 河流级别
            /// </summary>
            public int fldLevel { get; set; }


            /// <summary>
            /// 项目id
            /// </summary>
            public string fldItemCode { get; set; }


            /// <summary>
            /// 平均值取值方法:0:四舍六入五单一、1:四舍五入、2:直接截断、5：对武汉项目特殊处理，氨氮和总磷按照有效位数修约
            /// </summary>
            public string DecCarry { get; set; }


            /// <summary>
            /// 是否统计前期数据
            /// </summary>
            public int IsPre { get; set; }


            /// <summary>
            /// 是否统计同期数据
            /// </summary>
            public int IsYear { get; set; }


            /// <summary>
            /// 是否统计平均值
            /// </summary>
            public int IsTotal { get; set; }


            /// <summary>
            /// 是否统计明细
            /// </summary>
            public int IsDetail { get; set; }


            /// <summary>
            /// 是否统计富营养化指数
            /// </summary>
            public int IsTLI { get; set; }


            /// <summary>
            /// 富营养化计算时叶绿素a和透明度单位：1-mg/L,cm；0-mg/m^3,m；2-mg/m^3,cm
            /// </summary>
            public int TLIType { get; set; }


            /// <summary>
            /// 0:针对单个垂线评价、1：针对湖库评价
            /// </summary>
            public int AppriseID { get; set; }


            /// <summary>
            /// 0:湖库-fldLCode、1：流域-fldWaterArea、2：设区市-fldSTCode、3：城市+湖库-fldSTCode+fldLCode、4：流域+城市-fldWaterArea+fldSTCode
            /// 99:全省
            /// </summary>
            public int SpaceID { get; set; }


            /// <summary>
            /// 1:年鉴表、2：项目超标情况表、3：综合评价表、4：市站导出上报表
            /// 91:湖库富营养化秩相关、90:项目均值秩相关、92：综合污染指数秩相关、93：达标率至相关、94污染分指数秩相关、95各级达标率至相关、96分区域各级达标率至相关、97：平均综合指数秩相关
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 湖库均值处理，0:默认值按行政区、1：按行政区前4位处理
            /// </summary>
            public int Para1ID { get; set; }


            /// <summary>
            /// 基础信息参数，用于不同省份；0：通用、2：湖南、3：内蒙、4：太原、5：无锡、6：湖北总氮和粪不参与水质类别，参与超标情况
            /// </summary>
            public int Para2ID { get; set; }


            /// <summary>
            /// 未知
            /// </summary>
            public int Source { get; set; }


        }




    }
}

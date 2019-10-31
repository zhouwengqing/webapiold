using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqia.Eqia_r
{
    public class GetEQIA_R_RawDataController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由通用存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-14
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
                    new SqlParameter("@fldPCode",info.fldPCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@IsPre",info.IsPre),
                    new SqlParameter("@IsYear",info.IsYear),
                    new SqlParameter("@IsTotal",info.IsTotal),
                    new SqlParameter("@IsDetail",info.IsDetail),
                    new SqlParameter("@fldSource",info.fldSource),
                    new SqlParameter("@AppriseID",info.AppriseID),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@CityID",info.CityID),
                    new SqlParameter("@CalculateID",info.CalculateID),
                    new SqlParameter("@ItemValueType",info.ItemValueType)
                };

                dt = rule.RunProcedure("usp_tblEQIA_R_Report_AppriseStat", paras.ToList(), null);

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
            /// 测点代码
            /// </summary>
            public string fldPCode { get; set; }


            /// <summary>
            /// 标准级别名称
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
            /// 平均值取值方法
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
            /// 预留参数：是否统计平均值
            /// </summary>
            public int IsTotal { get; set; }


            /// <summary>
            /// 预留参数：是否统计明细，明细跟平均必须有一个值为1
            /// </summary>
            public int IsDetail { get; set; }


            /// <summary>
            /// 数据源
            /// </summary>
            public int fldSource { get; set; }


            /// <summary>
            /// 0:针对单个点位评价、1：针对城市评价
            /// </summary>
            public int AppriseID { get; set; }


            /// <summary>
            /// 0:综合评价表；90：达标天数秩相关；91：污染物浓度秩相关;92：综合指数秩相关
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 0:默认城市（fldSTCode）；1：区县（太原市fldLCode）  20：城市（月标准）  21：区县（月标准）
            /// </summary>
            public int CityID { get; set; }


            /// <summary>
            /// 计算方法，0：按照国家标准计算，1：不进行数据有效性判定，2：点位个数按照国家判定，有效天数不按
            /// </summary>
            public int CalculateID { get; set; }


            /// <summary>
            /// day:默认例行数据， hour：未审核小时数据	,  audithourdata:已审核小时值	,cityday:城市日均值   , middlehour:中间库小时数据	,middleday:中间库日数据
            /// </summary>
            public string ItemValueType { get; set; }





        }





        /// <summary>
        /// 功能描述：由通用存储过程来获取小时值数据
        /// 创建者  ：刘勇军
        /// 创建时间：2018-05-04
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetRawHourData(GetRawHourData_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@BeginTime",info.BeginTime),
                    new SqlParameter("@EndTime",info.EndTime),
                    new SqlParameter("@fldPCode",info.fldPCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry)
                };

                dt = rule.RunProcedure("usp_tblEQIA_R_Report_HourStat", paras.ToList(), null);

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
        public class GetRawHourData_Info
        {

            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginTime { get; set; }


            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndTime { get; set; }


            /// <summary>
            /// 测点代码
            /// </summary>
            public string fldPCode { get; set; }


            /// <summary>
            /// 标准级别名称
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
            /// 平均值取值方法
            /// </summary>
            public string DecCarry { get; set; }
        }
    }
}

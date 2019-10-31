using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqin.Eqin_F
{
    public class GetEQIN_F_RawDataController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由通用存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-2
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
                    new SqlParameter("@PointType",info.PointType),
                    new SqlParameter("@fldPCode",info.fldPCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@IsPre",info.IsPre),
                    new SqlParameter("@IsYear",info.IsYear),
                    new SqlParameter("@SpaceID",info.SpaceID),
                    new SqlParameter("@ReportType",info.ReportType),
                    new SqlParameter("@STatType",info.STatType)
                };


                dt = rule.RunProcedure("usp_tblEQIN_F_Report_AppriseStat_S", paras.ToList(), null);



                if (info.StaLodAndStaLad == "1")
                {
                    dt.Columns.Add("fldStaLod", typeof(string));
                    dt.Columns.Add("fldStaLad", typeof(string));

                    DataTable dt2 = rule.getdt("select * from tblEQIN_F_Point");

                    foreach (DataRow item in dt.Rows)
                    {
                        foreach (DataRow item2 in dt2.Rows)
                        {
                            if 
                            (
                                item["fldSTCode"].ToString() == item2["fldSTCode"].ToString() &&
                                item["fldPCode"].ToString() == item2["fldPCode"].ToString() &&
                                item["fldYear"].ToString() == item2["fldYear"].ToString()
                            )
                            {
                                item["fldStaLod"] = item2["fldStaLod"];
                                item["fldStaLad"] = item2["fldStaLad"];
                            }
                        }
                    }

                }






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
            /// 点位传入方式0：fldSTCode、1：fldSTCode+'.'+fldPCode
            /// </summary>
            public int PointType { get; set; }

            /// <summary>
            /// 测点代码
            /// </summary>
            public string fldPCode { get; set; }

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
            /// 0:监测结果、1：达标统计情况、2：原始数据表；3、小时均值表；90、秩相关
            /// </summary>
            public int SpaceID { get; set; }

            /// <summary>
            /// 报表对象，用于行政区划分1：地市级行政区left(fldSTCode,4)+'00'、0：各级行政区fldSTCode
            /// </summary>
            public int ReportType { get; set; }

            /// <summary>
            /// 备用参数，默认值为0，如果有特殊评价要求时使用 
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 是否增加经度纬度
            /// 1：增加经度纬度列fldStaLod和fldStaLad
            /// </summary>
            public string StaLodAndStaLad { get; set; }


        }















    }
}

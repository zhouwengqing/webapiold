﻿using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqin.Eqin_T
{
    public class GetEQIN_T_RawDataController : ApiController
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
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@DN",info.DN),
                    new SqlParameter("@PointType",info.PointType),
                    new SqlParameter("@fldPCode",info.fldPCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@IsYear",info.IsYear),
                    new SqlParameter("@SpaceID",info.SpaceID),
                    new SqlParameter("@ReportType",info.ReportType),
                    new SqlParameter("@STatType",info.STatType)
                };

                dt = rule.RunProcedure("usp_tblEQIN_T_Report_AppriseStat_S", paras.ToList(), null);

                if (info.Code_GIS == "1")
                {
                    dt.Columns.Add("fldRDCode_GIS", typeof(string));

                    DataTable dt2 = rule.getdt("select * from tblEQIN_T_Point");

                    foreach (DataRow item in dt.Rows)
                    {
                        foreach (DataRow item2 in dt2.Rows)
                        {
                            if
                            (
                                item["fldSTCode"].ToString() == item2["fldSTCode"].ToString() &&
                                item["fldRDCode"].ToString() == item2["fldRDCode"].ToString() &&
                                item["fldYear"].ToString() == item2["fldYear"].ToString()
                            )
                            {
                                item["fldRDCode_GIS"] = item2["fldRDCode_GIS"];
                            }
                        }
                    }

                    var result1 = (from x in dt.AsEnumerable()
                                   where x["fldRDCode_GIS"].ToString() != ""
                                   select x).CopyToDataTable();

                    dt = result1;
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
            /// 昼夜
            /// “D”、“N”
            /// </summary>
            public string DN { get; set; }

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
            /// 报表类型：0、监测结果统计表；1、原始数据表；2、至相关；3、全省城市状况；4、城市测量数据统计表；5、城市噪声均值表
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
            /// 专用于GIS的点位转换
            /// “1”进行点位生成
            /// 交通噪声对应字段：fldRDCode_GIS
            /// 区域噪声对应字段：fldGDCode_GIS
            /// </summary>
            public string Code_GIS { get; set; }



        }




    }
}

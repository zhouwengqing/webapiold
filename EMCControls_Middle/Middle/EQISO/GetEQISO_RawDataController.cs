using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.EQISO
{
    public class GetEQISO_RawDataController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由通用存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-16
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
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@AppriseID",info.AppriseID),
                    new SqlParameter("@SpaceID",info.SpaceID),
                    new SqlParameter("@STatType",info.STatType)
                };

                dt = rule.RunProcedure("usp_tblEQISO_Report_Apprise", paras.ToList(), null);

                if (info.StaLodAndStaLad == "1")
                {
                    dt.Columns.Add("fldStaLod", typeof(string));
                    dt.Columns.Add("fldStaLad", typeof(string));



                    DataTable dt2 = new DataTable();

                    dt2 = rule.getdt("select * from tblEQISO_Point");


                    dt2.Columns.Add("fldStaLod", typeof(string));
                    dt2.Columns.Add("fldStaLad", typeof(string));

                    foreach (DataRow item in dt2.Rows)
                    {
                        item["fldStaLod"] = (double.Parse(item["fldLOD"].ToString()) + double.Parse(item["fldLOM"].ToString()) / 60 + double.Parse(item["fldLOS"].ToString()) / 3600).ToString();
                        item["fldStaLad"] = (double.Parse(item["fldLAD"].ToString()) + double.Parse(item["fldLAM"].ToString()) / 60 + double.Parse(item["fldLAS"].ToString()) / 3600).ToString();
                    }

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
            /// 测点代码
            /// </summary>
            public string fldRSCode { get; set; }


            /// <summary>
            /// 河流标准级别名称
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
            /// 0:针对单个断面评价、1：针对空间评价
            /// </summary>
            public int AppriseID { get; set; }


            /// <summary>
            /// 0:流域-fldWaterArea、1:水系-fldRSWaterWork、2：河流-fldRCode
            /// </summary>
            public int SpaceID { get; set; }


            /// <summary>
            /// 0:有采样地信息，例如：武汉
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 是否增加经度纬度
            /// 1：增加经度纬度列fldStaLod和fldStaLad
            /// </summary>
            public string StaLodAndStaLad { get; set; }

        }







        /// <summary>
        /// 功能描述：由通用存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-25
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetData_GIS_tblEQISO_Point(GIS_tblEQISO_Point_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                dt = rule.getdt("select * from tblEQISO_Point where fldYear = '" + info.fldYear + "' and fldAttribute = '" + info.fldAttribute + "'");


                dt.Columns.Add("fldStaLod", typeof(string));
                dt.Columns.Add("fldStaLad", typeof(string));

                foreach (DataRow item in dt.Rows)
                {
                    item["fldStaLod"] = (double.Parse(item["fldLOD"].ToString()) + double.Parse(item["fldLOM"].ToString()) / 60 + double.Parse(item["fldLOS"].ToString()) / 3600).ToString();
                    item["fldStaLad"] = (double.Parse(item["fldLAD"].ToString()) + double.Parse(item["fldLAM"].ToString()) / 60 + double.Parse(item["fldLAS"].ToString()) / 3600).ToString();
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
        public class GIS_tblEQISO_Point_Info
        {
            /// <summary>
            /// 年份
            /// </summary>
            public string fldYear { get; set; }

            /// <summary>
            /// 点位类型
            /// </summary>
            public string fldAttribute { get; set; }

        }




    }
}

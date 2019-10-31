using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqiw.Eqiw_D
{
    public class GetEQIW_D_RawDataController : ApiController
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

                if (info.STatType == 2)
                {
                    SqlParameter[] paras = new SqlParameter[]
                    {
                        new SqlParameter("@TimeType",info.TimeType),
                        new SqlParameter("@BeginDate",info.BeginDate),
                        new SqlParameter("@EndDate",info.EndDate),
                        new SqlParameter("@fldRSC",info.fldRSC),
                        new SqlParameter("@fldRSCode",info.fldRSCode),
                        new SqlParameter("@fldRStandardName",info.fldRStandardName),
                        new SqlParameter("@fldRLevel",info.fldRLevel),
                        new SqlParameter("@fldLStandardName",info.fldLStandardName),
                        new SqlParameter("@fldLLevel",info.fldLLevel),
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
                        new SqlParameter("@fldSource",info.fldSource),
                        new SqlParameter("@CalculateID",info.CalculateID),
                        new SqlParameter("@CategoryID",info.CategoryID)
                    };

                    dt = rule.RunProcedure("usp_tblEQIW_DX_Report_Apprise", paras.ToList(), null);
                }
                else
                {
                    List<SqlParameter> paras = new List<SqlParameter>
                    {
                        new SqlParameter("@TimeType",info.TimeType),
                        new SqlParameter("@BeginDate",info.BeginDate),
                        new SqlParameter("@EndDate",info.EndDate),
                        new SqlParameter("@fldRSC",info.fldRSC),
                        new SqlParameter("@fldRSCode",info.fldRSCode),
                        new SqlParameter("@fldRStandardName",info.fldRStandardName),
                        new SqlParameter("@fldRLevel",info.fldRLevel),
                        new SqlParameter("@fldLStandardName",info.fldLStandardName),
                        new SqlParameter("@fldLLevel",info.fldLLevel),
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
                        new SqlParameter("@fldSource",info.fldSource),
                        new SqlParameter("@CalculateID",info.CalculateID)
                    };


                    if (info.CategoryID != 0)
                    {
                        paras.Add(new SqlParameter("@CategoryID", info.CategoryID));
                    }



                    if (info.NewSTDMonth != 0)
                    {
                        paras.Add(new SqlParameter("@NewSTDMonth", info.NewSTDMonth));
                    }



                    if (info.IsFilterLess29 != 0)
                    {
                        paras.Add(new SqlParameter("@IsFilterLess29", info.IsFilterLess29));
                    }





                    dt = rule.RunProcedure("usp_tblEQIW_D_Report_Apprise", paras.ToList(), null);





                    if (info.StaLodAndStaLad == "1")
                    {
                        dt.Columns.Add("fldStaLod", typeof(string));
                        dt.Columns.Add("fldStaLad", typeof(string));


                        DataTable dt2 = new DataTable();


                        dt2 = rule.getdt("select * from tblEQIW_D_Section");


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
                                    item["fldRCode"].ToString() == item2["fldRCode"].ToString() &&
                                    item["fldRSCode"].ToString() == item2["fldRSCode"].ToString() &&
                                    item["fldYear"].ToString() == item2["fldYear"].ToString()
                                )
                                {
                                    item["fldStaLod"] = item2["fldStaLod"];
                                    item["fldStaLad"] = item2["fldStaLad"];
                                }
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
            /// 水期代码
            /// </summary>
            public string fldRSC { get; set; }

            /// <summary>
            /// 测点代码
            /// </summary>
            public string fldRSCode { get; set; }

            /// <summary>
            /// 河流标准级别名称
            /// </summary>
            public string fldRStandardName { get; set; }

            /// <summary>
            /// 河流级别
            /// </summary>
            public int fldRLevel { get; set; }

            /// <summary>
            /// 河流标准级别名称
            /// </summary>
            public string fldLStandardName { get; set; }

            /// <summary>
            /// 河流级别
            /// </summary>
            public int fldLLevel { get; set; }

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
            /// 0:针对单个断面评价、1：城市评价、2：城市区县评价
            /// </summary>
            public int AppriseID { get; set; }

            /// <summary>
            /// 0:日数据表（修约）
            /// 1：年鉴表
            /// 2：因子超标情况
            /// 20：城市因子超标情况
            /// 3：综合评价表
            /// 31：综合评价表（日均值不修约）
            /// 4：原始数据表（带左中右）
            /// 5：日数据表（不修约）
            /// 90：取水量秩相关
            /// 91：点次达标率秩相关
            /// 92：水量达标率秩相关
            /// 93：城市因子秩相关
            /// </summary>
            public int SpaceID { get; set; }

            /// <summary>
            /// 0：tblEQIW_D_BaseData
            /// 1：tblEQIW_DT_BaseData
            /// 2：tblEQIW_DX_BaseData
            /// </summary>
            public int STatType { get; set; }

            /// <summary>
            /// fldSource，用来标识是例行数据还是全分析数据
            /// </summary>
            public string fldSource { get; set; }

            /// <summary>
            /// 计算方法：0：总氮和粪和细菌总数不参与评价
            /// 1：总氮和粪参与评价
            /// 2：总氮、粪、化学需氧量不参与评价
            /// 3：总氮、粪、化学需氧量不参与水质类别,超标水量评价，参加超标因子评价，总大肠菌群都参与
            /// </summary>
            public int CalculateID { get; set; }


            /// <summary>
            /// 乡镇饮用水专用
            /// 默认值0
            /// 重置水源地类别进行评价  0：默认   1：湖库按照河流标准进行评价   2：所有水源地类型按照河流标准评价
            /// </summary>
            public int CategoryID { get; set; }



            /// <summary>
            /// 0 :关闭混合模式   4：开启混合模式 数值为分界的月份
            /// </summary>
            public int NewSTDMonth { get; set; }


            /// <summary>
            /// --0:关闭模式    1：开启过滤模式：按月份统计过滤监测项目个数小于29的数据
            /// </summary>
            public int IsFilterLess29 { get; set; }





            /// <summary>
            /// 是否增加经度纬度
            /// 1：增加经度纬度列fldStaLod和fldStaLad
            /// </summary>
            public string StaLodAndStaLad { get; set; }
        }
    }
}

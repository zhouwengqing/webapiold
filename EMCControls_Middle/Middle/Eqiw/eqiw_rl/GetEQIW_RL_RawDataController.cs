using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqiw.eqiw_rl
{
    public class GetEQIW_RL_RawDataController : ApiController
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
                if (info.fldRSCode == null || info.fldRSCode == "")
                {
                    info.fldRSCode = "-1";
                }
                List<SqlParameter> paras = new List<SqlParameter>();
                paras.Add(new SqlParameter("@TimeType", info.TimeType));
                paras.Add(new SqlParameter("@BeginDate", info.BeginDate));
                paras.Add(new SqlParameter("@EndDate", info.EndDate));
                paras.Add(new SqlParameter("@EBeginDate", info.EBeginDate));
                paras.Add(new SqlParameter("@EEndDate", info.EEndDate));
                paras.Add(new SqlParameter("@fldRSC", info.fldRSC));
                paras.Add(new SqlParameter("@fldRSCode", info.fldRSCode));
                paras.Add(new SqlParameter("@fldStandardName", info.fldStandardName));
                paras.Add(new SqlParameter("@fldLevel", info.fldLevel));
                paras.Add(new SqlParameter("@fldItemCode", info.fldItemCode));
                paras.Add(new SqlParameter("@DecCarry", info.DecCarry));
                paras.Add(new SqlParameter("@IsPre", info.IsPre));
                paras.Add(new SqlParameter("@IsYear", info.IsYear));
                paras.Add(new SqlParameter("@IsTotal", info.IsTotal));
                paras.Add(new SqlParameter("@IsDetail", info.IsDetail));
                paras.Add(new SqlParameter("@IsTLI", info.IsTLI));
                paras.Add(new SqlParameter("@TLIType", info.TLIType));
                paras.Add(new SqlParameter("@AppriseID", info.AppriseID));
                paras.Add(new SqlParameter("@SpaceID", info.SpaceID));
                paras.Add(new SqlParameter("@STatType", info.STatType));
                paras.Add(new SqlParameter("@Para1ID", info.Para1ID));
                paras.Add(new SqlParameter("@Para2ID", info.Para2ID));
                paras.Add(new SqlParameter("@Source", info.Source));

                if (info.fldSTCodeReset != 0)
                {
                    paras.Add(new SqlParameter("@fldSTCodeReset", info.fldSTCodeReset));
                }

                if (info.fldSourceReset != 0)
                {
                    paras.Add(new SqlParameter("@fldSourceReset", info.fldSourceReset));
                }

                if (info.fldIsMerge != 0)
                {
                    paras.Add(new SqlParameter("@fldIsMerge", info.fldIsMerge));
                }

                if (info.fldIsData90 != null)
                {
                    paras.Add(new SqlParameter("@fldIsData90", info.fldIsData90));
                }


                if (info.AppriseIndexContent != null)
                {
                    paras.Add(new SqlParameter("@AppriseIndexContent", info.AppriseIndexContent));
                }





                dt = rule.RunProcedure("usp_tblEQIW_RL_Report_Apprise", paras.ToList(), null);





                if (info.StaLodAndStaLad == "1")
                {
                    dt.Columns.Add("fldStaLod", typeof(string));
                    dt.Columns.Add("fldStaLad", typeof(string));


                    DataTable dt2 = new DataTable();


                    dt2 = rule.getdt("select * from tblEQIW_R_Section");


                    dt2.Columns.Add("fldStaLod", typeof(string));
                    dt2.Columns.Add("fldStaLad", typeof(string));


                    foreach (DataRow item in dt2.Rows)
                    {
                        item["fldStaLod"] = (double.Parse(item["fldLOD"].ToString()) + double.Parse(item["fldLOM"].ToString()) / 60 + double.Parse(item["fldLOS"].ToString()) / 3600).ToString();
                        item["fldStaLad"] = (double.Parse(item["fldLAD"].ToString()) + double.Parse(item["fldLAM"].ToString()) / 60 + double.Parse(item["fldLAS"].ToString()) / 3600).ToString();
                    }


                    if (info.STatType == 1)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            foreach (DataRow item2 in dt2.Rows)
                            {
                                if
                                (
                                    item["fldSTName"].ToString() == item2["fldSTName"].ToString() &&
                                    item["fldRName"].ToString() == item2["fldRName"].ToString() &&
                                    item["fldRSName"].ToString() == item2["fldRSName"].ToString() &&
                                    item["fldDate"].ToString().Substring(0, 4) == item2["fldYear"].ToString()
                                )
                                {
                                    item["fldStaLod"] = item2["fldStaLod"];
                                    item["fldStaLad"] = item2["fldStaLad"];
                                }
                            }
                        }

                    }
                    else
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            foreach (DataRow item2 in dt2.Rows)
                            {
                                if
                                (
                                    item["fldSTCode"].ToString() == item2["fldSTCode"].ToString() &&
                                    item["fldRCode"].ToString() == item2["fldRCode"].ToString() &&
                                    item["fldRSCode"].ToString() == item2["fldRSCode"].ToString() &&
                                    item["fldAppDate"].ToString().Substring(0, 4) == item2["fldYear"].ToString()
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
            /// 0:针对单个断面评价、1：针对空间评价
            /// </summary>
            public int AppriseID { get; set; }


            /// <summary>
            /// 0:流域-fldWaterArea、1:水系-fldRSWaterWork、2：河流-fldRCode、3：区县-fldRWTwon、4：设区市-fldSTCode
            /// </summary>
            public int SpaceID { get; set; }


            /// <summary>
            /// 0:数据导出格式、1:年鉴格式、2：因子超标评价、3:断面或者河流综合评价、4：数据市站上报省站格式1
            /// 90：综合指数秩相关、91：浓度秩相关、92：达标率秩相关、93：因子污染指数秩相关、94：各类达标率秩相关、
            /// 95：富营养化指数、96：达标率、综合指数、浓度
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 河流均值处理，0:默认值按行政区、1：按行政区前4位处理
            /// </summary>
            public int Para1ID { get; set; }



            /// <summary>
            /// 断面属性信息，0：默认属性、1：江西增加信息、2：太原
            /// </summary>
            public int Para2ID { get; set; }


            /// <summary>
            /// 数据类型，对应fldSource
            /// </summary>
            public int Source { get; set; }



            /// <summary>
            /// 0:fldSTCode    1:fldPJCode
            /// </summary>
            public int fldSTCodeReset { get; set; }


            /// <summary>
            /// 0:根据传参fldSource   1：根据Setion表中fldPJSource属性匹配
            /// </summary>
            public int fldSourceReset { get; set; }



            /// <summary>
            /// 河北特殊点位合并统计标记  0：不合并   1：合并
            /// </summary>
            public int fldIsMerge { get; set; }




            public int? fldIsData90 { get; set; }


            /// <summary>
            /// sgov,sgov_overi,sgov_overf,sgov_overt,sgov_overft,sgov_overv,sgov_overfv,cpi
            /// </summary>
            public string AppriseIndexContent { get; set; }




            /// <summary>
            /// 是否增加经度纬度
            /// 1：增加经度纬度列fldStaLod和fldStaLad
            /// </summary>
            public string StaLodAndStaLad { get; set; }

        }





















        /// <summary>
        /// 功能描述：由通用存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-16
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetRawData_usp_tblEQIW_RL_Report_Basedata(GetRawData_usp_tblEQIW_RL_Report_BasedataInfo info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                if (info.fldRSCode == null || info.fldRSCode == "")
                {
                    info.fldRSCode = "-1";
                }



                List<SqlParameter> paras = new List<SqlParameter>();
                paras.Add(new SqlParameter("@TimeType", info.TimeType));
                paras.Add(new SqlParameter("@BeginDate", info.BeginDate));
                paras.Add(new SqlParameter("@EndDate", info.EndDate));
                paras.Add(new SqlParameter("@EBeginDate", info.EBeginDate));
                paras.Add(new SqlParameter("@EEndDate", info.EEndDate));
                paras.Add(new SqlParameter("@fldRSC", info.fldRSC));
                paras.Add(new SqlParameter("@fldRSCode", info.fldRSCode));
                paras.Add(new SqlParameter("@fldStandardName", info.fldStandardName));
                paras.Add(new SqlParameter("@fldLevel", info.fldLevel));
                paras.Add(new SqlParameter("@fldItemCode", info.fldItemCode));
                paras.Add(new SqlParameter("@DecCarry", info.DecCarry));
                paras.Add(new SqlParameter("@IsPre", info.IsPre));
                paras.Add(new SqlParameter("@IsYear", info.IsYear));
                paras.Add(new SqlParameter("@IsTotal", info.IsTotal));
                paras.Add(new SqlParameter("@IsDetail", info.IsDetail));
                paras.Add(new SqlParameter("@IsTLI", info.IsTLI));
                paras.Add(new SqlParameter("@TLIType", info.TLIType));
                paras.Add(new SqlParameter("@AppriseID", info.AppriseID));
                paras.Add(new SqlParameter("@SpaceID", info.SpaceID));
                paras.Add(new SqlParameter("@STatType", info.STatType));
                paras.Add(new SqlParameter("@Para1ID", info.Para1ID));
                paras.Add(new SqlParameter("@Para2ID", info.Para2ID));
                paras.Add(new SqlParameter("@Source", info.Source));

                if (info.fldSTCodeReset != 0)
                {
                    paras.Add(new SqlParameter("@fldSTCodeReset", info.fldSTCodeReset));
                }

                if (info.fldSourceReset != 0)
                {
                    paras.Add(new SqlParameter("@fldSourceReset", info.fldSourceReset));
                }

                dt = rule.RunProcedure("usp_tblEQIW_RL_Report_Basedata", paras.ToList(), null);

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
        public class GetRawData_usp_tblEQIW_RL_Report_BasedataInfo
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
            /// 0:针对单个断面评价、1：针对空间评价
            /// </summary>
            public int AppriseID { get; set; }


            /// <summary>
            /// 0:流域-fldWaterArea、1:水系-fldRSWaterWork、2：河流-fldRCode、3：区县-fldRWTwon、4：设区市-fldSTCode
            /// </summary>
            public int SpaceID { get; set; }


            /// <summary>
            /// 0:数据导出格式、1:年鉴格式、2：因子超标评价、3:断面或者河流综合评价、4：数据市站上报省站格式1
            /// 90：综合指数秩相关、91：浓度秩相关、92：达标率秩相关、93：因子污染指数秩相关、94：各类达标率秩相关、
            /// 95：富营养化指数、96：达标率、综合指数、浓度
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 河流均值处理，0:默认值按行政区、1：按行政区前4位处理
            /// </summary>
            public int Para1ID { get; set; }



            /// <summary>
            /// 断面属性信息，0：默认属性、1：江西增加信息、2：太原
            /// </summary>
            public int Para2ID { get; set; }


            /// <summary>
            /// 数据类型，对应fldSource
            /// </summary>
            public int Source { get; set; }



            /// <summary>
            /// 0:fldSTCode    1:fldPJCode
            /// </summary>
            public int fldSTCodeReset { get; set; }


            /// <summary>
            /// 0:根据传参fldSource   1：根据Setion表中fldPJSource属性匹配
            /// </summary>
            public int fldSourceReset { get; set; }



        }















    }
}

using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS_Party.Eqiw_r
{
    public class EMCMIS_Party_EQIW_RController : ApiController
    {


        RuleCommon rule = new RuleCommon();



        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-13
        /// 功能描述：根据年份，返回其断面数据
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_Eqiw_R_Section_Data(Get_Eqiw_R_Section_Data_Info info)
        {
            string result = string.Empty;
            try
            {
                using (Model.EntityContext db = new Model.EntityContext())
                {

                    List<Model.tblEQIW_R_Section> list = new List<Model.tblEQIW_R_Section>();

                    list = (from x in db.tblEQIW_R_Section
                            where info.fldYear == x.fldYear &&
                            x.fldFunType == "采测分离"
                            select x).ToList();



                    if (list != null && list.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", list);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有数据", "");
                    }
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 参数实体
        /// </summary>
        public class Get_Eqiw_R_Section_Data_Info
        {
            /// <summary>
            /// 年份
            /// </summary>
            public decimal? fldYear { get; set; }
        }




















        /// <summary>
        /// 功能描述：由通用存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-16
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetRawData(GetRawData_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();


            using (Model.EntityContext db = new Model.EntityContext())
            {

                decimal? Year = decimal.Parse(info.BeginDate.Substring(0, 4));

                var query = (from x in db.tblEQIW_R_Section
                             where x.fldYear == Year &&
                             x.fldFunType == "采测分离"
                             select x).ToList();

                if (query.Count == 0)
                {
                    result = rule.JsonStr("ok", "未获取到数据！", "");

                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }


                foreach (var item in query)
                {
                    info.fldRSCode += "'" + item.fldSTCode + "." + item.fldRCode + "." + item.fldRSCode + "',";
                }

                info.fldRSCode = info.fldRSCode.TrimEnd(',');
            }



            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType","month"),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@EBeginDate",""),
                    new SqlParameter("@EEndDate",""),
                    new SqlParameter("@fldRSC","0"),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldStandardName","GB 3838-2002"),
                    new SqlParameter("@fldLevel",3),
                    new SqlParameter("@fldItemCode","302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"),
                    new SqlParameter("@DecCarry","0"),
                    new SqlParameter("@IsPre",0),
                    new SqlParameter("@IsYear",0),
                    new SqlParameter("@IsTotal",1),
                    new SqlParameter("@IsDetail",0),
                    new SqlParameter("@AppriseID",0),
                    new SqlParameter("@SpaceID",2),
                    new SqlParameter("@STatType",3),
                    new SqlParameter("@Para1ID",0),
                    new SqlParameter("@Para2ID",1),
                    new SqlParameter("@Source",0),
                    new SqlParameter("@CalculateID",0)
                };

                dt = rule.RunProcedure("usp_tblEQIW_R_Report_Apprise", paras.ToList(), null);

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
        public class GetRawData_Info
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
            /// 0:针对单个断面评价、1：针对空间评价
            /// </summary>
            public int AppriseID { get; set; }


            /// <summary>
            /// 0:流域-fldWaterArea、1:水系-fldRSWaterWork、2：河流-fldRCode、3：区县-fldRWTwon、4：设区市-fldSTCode、
            /// 5:流域+河流、6：城市+河流、7：流域+水系、8：干支流-fldRiverStream、9：河流+fldAttribute、99：全省
            /// </summary>
            public int SpaceID { get; set; }


            /// <summary>
            /// 0:数据导出格式、1:年鉴格式、2：因子超标评价、3:断面或者河流综合评价、4：数据市站上报省站格式1
            /// 90:综合指数秩相关、91：浓度秩相关、92：达标率秩相关、93：因子污染指数秩相关、94：各类达标率秩相关、95：各空间各级达标率数秩相关
            /// 96：平均综合指数秩相关、--97：因子断面达标率秩相关
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 河流均值处理，0:默认值按行政区、1：按行政区前4位处理
            /// </summary>
            public int Para1ID { get; set; }


            /// <summary>
            /// 断面属性信息，0：默认属性、1,91：江西增加信息、2：湖南项目信息、3：太原、4：内蒙、5：湖北超标情况   6：无锡
            /// </summary>
            public int Para2ID { get; set; }


            /// <summary>
            /// 未知
            /// </summary>
            public int Source { get; set; }


            /// <summary>
            /// 计算方法：0：默认规则,  1：所有项目不做特殊判断，都参与评价
            /// </summary>
            public int CalculateID { get; set; }


        }








































        /// <summary>
        /// 功能描述：由通用存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-16
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Import_PreData(List<Import_PreData_Info> info)
        {
            string result = null;
            int datacount = 0;
            try
            {

                List<Model.tblEQIW_R_Basedata_Pre> list = new List<Model.tblEQIW_R_Basedata_Pre>();

                foreach (var item in info)
                {
                    Model.tblEQIW_R_Basedata_Pre pre = new Model.tblEQIW_R_Basedata_Pre();
                    pre.fldSTCode = item.fldSTCode;
                    pre.fldRCode = item.fldRCode;
                    pre.fldRSCode = item.fldRSCode;
                    pre.fldSAMPH = item.fldSAMPH;
                    pre.fldSAMPR = item.fldSAMPR;
                    pre.fldRSC = item.fldRSC;
                    pre.fldYear = item.fldYear;
                    pre.fldMonth = item.fldMonth;
                    pre.fldDay = item.fldDay;
                    pre.fldHour = item.fldHour;
                    pre.fldMinute = item.fldMinute;
                    pre.fldItemCode = item.fldItemCode;
                    pre.fldItemValue = item.fldItemValue;
                    pre.fldFlag = 1;
                    pre.fldImport = 1;
                    pre.fldCityID_Operate = 2;
                    pre.fldCityID_Submit = "2";
                    pre.fldDate_Operate = DateTime.Now;
                    pre.fldUserID = 578;
                    pre.fldSource = 0;
                    pre.fldBatch = "0";
                    pre.fldDeleteState = 0;

                    list.Add(pre);
                }


                using (Model.EntityContext db = new Model.EntityContext())
                {
                    db.tblEQIW_R_Basedata_Pre.AddRange(list);

                    datacount = db.SaveChanges();
                }

                result = rule.JsonStr("ok", "", datacount);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 参数实体
        /// </summary>
        public class Import_PreData_Info
        {
            public string fldSTCode { get; set; }

            public string fldRCode { get; set; }

            public string fldRSCode { get; set; }

            public string fldSAMPH { get; set; }

            public string fldSAMPR { get; set; }

            public string fldRSC { get; set; }

            public decimal fldYear { get; set; }

            public decimal fldMonth { get; set; }

            public decimal fldDay { get; set; }

            public decimal fldHour { get; set; }

            public decimal fldMinute { get; set; }

            public string fldItemCode { get; set; }

            public decimal fldItemValue { get; set; }
        }






























    }
}

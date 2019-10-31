using DDYZ.Ensis.Rule.DataRule;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_r
{
    /// <summary>
    /// 功能描述：获得重庆自动建设的数据
    /// 创建  人：周文卿
    /// 创建时间：2018/03/15
    /// 修改  人：
    /// 修改时间：
    /// 修改原因：
    /// </summary>
    public class GetAutoDataController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：获得最新的一批数据
        /// 创建  人：周文卿
        /// 创建时间：2018/03/15
        /// 修改  人：
        /// 修改时间：
        /// 修改原因：
        /// </summary>
        /// <param name="obj">动态参数</param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage GetNewData(dynamic obj)
        {
            string result = string.Empty;
            try
            {
                string sql = "";
                if (obj.starttime == "" && obj.endtime == "")
                {
                    sql = @" SELECT  [fldSTName],[fldRName],[fldRSName],CONVERT(varchar,  CONVERT(datetime, 上报时间, 101),111) as 上报时间,CONVERT(varchar,  CONVERT(datetime, 新建水站_落实经费_计划开始时间, 101),111) as 落实经费_计划开始时间,CONVERT(varchar,  CONVERT(datetime, 新建水站_落实经费_计划完成时间, 101),111) as 落实经费_计划完成时间,[新建水站_落实经费_是否完成],[新建水站_落实经费_未完成原因],CONVERT(varchar, CONVERT(datetime, 新建水站_征租地_计划开始时间, 101), 111) as 征租地_计划开始时间
                            ,CONVERT(varchar, CONVERT(datetime, 新建水站_征租地_计划完成时间, 101), 111) as 征租地_计划完成时间,[新建水站_征租地_是否完成],[新建水站_征租地_未完成原因]
                            ,CONVERT(varchar, CONVERT(datetime, 新建水站_设计图纸_计划开始时间, 101),111) as 设计图纸_计划开始时间,CONVERT(varchar, CONVERT(datetime, 新建水站_设计图纸_计划完成时间, 101),111) as 设计图纸_计划完成时间,[新建水站_设计图纸_是否完成],[新建水站_设计图纸_未完成原因]
                            ,CONVERT(varchar, CONVERT(datetime, 新建水站_招投标_计划开始时间, 101),111) as 招投标_计划开始时间,CONVERT(varchar, CONVERT(datetime, 新建水站_招投标_计划完成时间, 101),111) as 招投标_计划完成时间,[新建水站_招投标_是否完成],[新建水站_招投标_未完成原因]
                            ,CONVERT(varchar, CONVERT(datetime, 新建水站_四通一平_计划开始时间, 101),111) as 四通一平_计划开始时间,CONVERT(varchar, CONVERT(datetime, 新建水站_四通一平_计划完成时间, 101),111) as 四通一平_计划完成时间,[新建水站_四通一平_是否完成],[新建水站_四通一平_未完成原因]
                            ,CONVERT(varchar, CONVERT(datetime, 新建水站_主体建设_计划开始时间, 101),111) as 主体建设_计划开始时间,CONVERT(varchar, CONVERT(datetime, 新建水站_主体建设_计划完成时间, 101),111) as 主体建设_计划完成时间,[新建水站_主体建设_是否完成],[新建水站_主体建设_未完成原因]
                            ,CONVERT(varchar, CONVERT(datetime, 新建水站_室内装修_计划开始时间, 101),111) as 室内装修_计划开始时间,CONVERT(varchar, CONVERT(datetime, 新建水站_室内装修_计划完成时间, 101),111) as 室内装修_计划完成时间,[新建水站_室内装修_是否完成],[新建水站_室内装修_未完成原因]
                            ,CONVERT(varchar, CONVERT(datetime, 新建水站_采水系统建设_计划开始时间, 101),111) as 采水系统建设_计划开始时间,CONVERT(varchar, CONVERT(datetime, 新建水站_采水系统建设_计划完成时间, 101),111) as  采水系统建设_计划完成时间,[新建水站_采水系统建设_是否完成],[新建水站_采水系统建设_未完成原因]
                            ,CONVERT(varchar, CONVERT(datetime, 新建水站_联网运行_计划开始时间, 101),111) as 联网运行_计划开始时间,CONVERT(varchar, CONVERT(datetime, 新建水站_联网运行_计划完成时间, 101),111) as 联网运行_计划完成时间,[新建水站_联网运行_是否完成],[新建水站_联网运行_未完成原因] from[tblEQIW_R_DevelopmentPace] where 上报时间=(select max(上报时间) from[tblEQIW_R_DevelopmentPace])";
                }
                else
                {
                    sql = @" SELECT  [fldSTName],[fldRName],[fldRSName],CONVERT(varchar,  CONVERT(datetime, 上报时间, 101),111) as 上报时间,CONVERT(varchar,  CONVERT(datetime, 新建水站_落实经费_计划开始时间, 101),111) as 落实经费_计划开始时间,CONVERT(varchar,  CONVERT(datetime, 新建水站_落实经费_计划完成时间, 101),111) as 落实经费_计划完成时间,[新建水站_落实经费_是否完成],[新建水站_落实经费_未完成原因]
                            ,CONVERT(varchar,  CONVERT(datetime, 新建水站_征租地_计划开始时间, 101),111) as 征租地_计划开始时间
                            ,CONVERT(varchar,  CONVERT(datetime, 新建水站_征租地_计划完成时间, 101),111) as 征租地_计划完成时间,[新建水站_征租地_是否完成],[新建水站_征租地_未完成原因]
                            ,CONVERT(varchar,  CONVERT(datetime, 新建水站_设计图纸_计划开始时间, 101),111) as 设计图纸_计划开始时间,CONVERT(varchar,  CONVERT(datetime, 新建水站_设计图纸_计划完成时间, 101),111) as 设计图纸_计划完成时间,[新建水站_设计图纸_是否完成],[新建水站_设计图纸_未完成原因]
                            ,CONVERT(varchar,  CONVERT(datetime, 新建水站_招投标_计划开始时间, 101),111) as 招投标_计划开始时间,CONVERT(varchar,  CONVERT(datetime, 新建水站_招投标_计划完成时间, 101),111) as 招投标_计划完成时间,[新建水站_招投标_是否完成],[新建水站_招投标_未完成原因]
                            ,CONVERT(varchar,  CONVERT(datetime, 新建水站_四通一平_计划开始时间, 101),111) as 四通一平_计划开始时间,CONVERT(varchar,  CONVERT(datetime, 新建水站_四通一平_计划完成时间, 101),111) as 四通一平_计划完成时间,[新建水站_四通一平_是否完成],[新建水站_四通一平_未完成原因]
                            ,CONVERT(varchar,  CONVERT(datetime, 新建水站_主体建设_计划开始时间, 101),111) as 主体建设_计划开始时间,CONVERT(varchar,  CONVERT(datetime, 新建水站_主体建设_计划完成时间, 101),111) as 主体建设_计划完成时间,[新建水站_主体建设_是否完成],[新建水站_主体建设_未完成原因]
                            ,CONVERT(varchar,  CONVERT(datetime, 新建水站_室内装修_计划开始时间, 101),111) as 室内装修_计划开始时间,CONVERT(varchar,  CONVERT(datetime, 新建水站_室内装修_计划完成时间, 101),111) as 室内装修_计划完成时间,[新建水站_室内装修_是否完成],[新建水站_室内装修_未完成原因]
                            ,CONVERT(varchar,  CONVERT(datetime, 新建水站_采水系统建设_计划开始时间, 101),111) as 采水系统建设_计划开始时间,CONVERT(varchar,  CONVERT(datetime, 新建水站_采水系统建设_计划完成时间, 101),111) as  采水系统建设_计划完成时间,[新建水站_采水系统建设_是否完成],[新建水站_采水系统建设_未完成原因]
                            ,CONVERT(varchar,  CONVERT(datetime, 新建水站_联网运行_计划开始时间, 101),111) as 联网运行_计划开始时间,CONVERT(varchar,  CONVERT(datetime, 新建水站_联网运行_计划完成时间, 101),111) as 联网运行_计划完成时间,[新建水站_联网运行_是否完成],[新建水站_联网运行_未完成原因] from [tblEQIW_R_DevelopmentPace] where 上报时间>CONVERT(datetime," + obj.starttime + ",101) and 上报时间<CONVERT(datetime," + obj.endtime + ",101)";
                }
                DataTable dt = new DataTable();
                dt = rule.getdt(sql);
                if (dt.Rows.Count > 0)
                {
                    result = rule.JsonStr("ok", "查询成功", dt);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据", dt);
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// 功能描述：获得完成率
        /// 创建  人：周文卿
        /// 创建时间：2018/03/15
        /// 修改  人：
        /// 修改时间：
        /// 修改原因： 
        /// <param name="obj"></param>
        /// <returns></returns>

        [HttpPost]
        public HttpResponseMessage GetDataStandard(dynamic obj)
        {
            string result = string.Empty;
            try
            {
                string sql = "select * from [tblEQIW_R_DevelopmentPace] where 上报时间=(select max(上报时间) from [tblEQIW_R_DevelopmentPace]) ";
                DataTable dt = new DataTable();
                dt = rule.getdt(sql);
                int count = 0;
                if (obj.isall == "0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        bool all = true;
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {

                            if (dt.Rows[i][j].ToString() == "否")
                            {
                                all = false;
                            }
                        }
                        if (all == false)
                        {
                            count++;
                        }
                    }
                }

                ret zz = new ret();
                zz.AllStande = ((float.Parse((dt.Rows.Count - count).ToString()) / float.Parse(dt.Rows.Count.ToString())) * 100).ToString();
                string named = obj.name + "_是否完成";
                var pt = (from x in dt.AsEnumerable()
                          where x[named].ToString() == "是"
                          select x);
                float prt = pt.Count();
                float allcount = prt / float.Parse(dt.Rows.Count.ToString());
                zz.PartStande = ((prt / dt.Rows.Count) * 100).ToString();

                result = rule.JsonStr("ok", "达标率", zz);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 完成率情况
        /// </summary>
        public class ret
        {

            /// <summary>
            /// 总体情况
            /// </summary>
            public string AllStande { get; set; }

            /// <summary>
            /// 每一个情况
            /// </summary>
            public string PartStande { get; set; }
        }


    }
}

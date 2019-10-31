using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace EMCCommon.Common
{
    /// <summary>
    /// 报表名称操作类
    /// </summary>
    public class ReportListController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  初始化报表列表
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-06
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="UserID">当前登录用户ID</param>
        /// <param name="typename">报表分类名称 正确的格式为：降水监测_报告表,大气监测_现状表</param>
        /// <returns>返回报表列表数据</returns>
        //[SupportFilter]
        public HttpResponseMessage GetReportList(int UserID, string typename)
        {
            string result = string.Empty;
            try
            {
                List<tblFW_ReportDataList> data = new List<tblFW_ReportDataList>();
                //验证字符串是否符合要求
                if (rule.VerificationReportString(typename) && rule.IsNmmber(UserID.ToString()))
                {
                    string[] relsit = HttpUtility.UrlDecode(typename, Encoding.GetEncoding("UTF-8")).Split(',');
                    string retype = string.Empty;
                    for (int i = 0; i < relsit.Length; i++)
                    {
                        retype += "'" + relsit[i].Split('_')[0].ToString() + "',";
                    }
                    DataTable dt = rule.GetAllReport(UserID, retype.Substring(0, retype.Length - 1));
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < relsit.Length; i++)
                        {
                            tblFW_ReportDataList relist = new tblFW_ReportDataList();
                            relist.title = relsit[i].Split('_')[1].ToString();
                            DataRow[] querydt = dt.Select("fldtypeName='" + relsit[i].Split('_')[0].ToString() + "'");
                            if (querydt.Length > 0)
                            {
                                DataTable rerows = dt.Select("fldtypeName='" + relsit[i].Split('_')[0].ToString() + "'").CopyToDataTable();
                                List<tblFW_Report> tbl = new List<tblFW_Report>();
                                for (int j = 0; j < rerows.Rows.Count; j++)
                                {
                                    tblFW_Report tblfw = new tblFW_Report();
                                    tblfw.fldAutoID = rerows.Rows[j]["fldAutoID"].ToString();
                                    tblfw.fldDefaultSortFld = rerows.Rows[j]["fldDefaultSortFld"].ToString();
                                    tblfw.fldFlag = rerows.Rows[j]["fldFlag"].ToString();
                                    tblfw.fldName = rerows.Rows[j]["fldName"].ToString();
                                    tblfw.fldParentID = rerows.Rows[j]["fldParentID"].ToString();
                                    tblfw.fldSort = rerows.Rows[j]["fldSort"].ToString();
                                    tblfw.fldTableName = rerows.Rows[j]["fldTableName"].ToString();
                                    tbl.Add(tblfw);
                                }
                                relist.data = tbl;
                                data.Add(relist);
                            }
                        }
                        result = rule.JsonStr("0", "", data);
                    }
                    else
                    {
                        result = rule.JsonStr("1", "没有数据", data);
                    }


                }
                else
                {
                    result = rule.JsonStr("error", "参数错误", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述    ： 根据用户ID来查询报表
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-07-09
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：  
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetReportList_V2(int UserID)
        {
            string result = string.Empty;
            try
            {
                DataTable dt = rule.GetAllReport(UserID, "");
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述    ：  初始化报表列表
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-07-10
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage QuerytReportList()
        {
            string result = string.Empty;
            try
            {
                DataTable dt = rule.GetAllReport(-1, "");
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述    ：  根据不同的动作操作Report表
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-07-10
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：  
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage OperationReport(Report item)
        {
            string result = string.Empty;
            try
            {

                SqlParameter[] paras = new SqlParameter[]
                 {
                    new SqlParameter("@fldaction",item.fldaction),
                    new SqlParameter("@fldAutoId",item.fldAutoId),
                    new SqlParameter("@fldFlag", item.fldFlag),
                    new SqlParameter("@fldName", item.fldName),
                    new SqlParameter("@fldType", item.fldType),
                    new SqlParameter("@fldTableName", item.fldTableName),
                    new SqlParameter("@fldParentID", item.fldParentID),
                    new SqlParameter("@fldSort", item.fldSort),
                    new SqlParameter("@fldDefaultSortFld", item.fldDefaultSortFld),
                    new SqlParameter("@fldUserID", item.fldUserID==null?"":item.fldUserID),
                 };
                DataTable dt = rule.RunProcedure_V2("usp_Operation_LAPtblFW_Report", paras.ToList(), null, "PortalEntity");
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述    ：  根据不同的动作操作Report_Doc表
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-07-11
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：  
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage OperationReport_Doc(Report item)
        {
            string result = string.Empty;
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                 {
                    new SqlParameter("@fldaction",item.fldaction),
                    new SqlParameter("@fldAutoId",item.fldAutoId),
                    new SqlParameter("@fldFlag", item.fldFlag),
                    new SqlParameter("@fldName", item.fldName),
                    new SqlParameter("@fldType", item.fldType),
                    new SqlParameter("@fldTableName", item.fldTableName),
                    new SqlParameter("@fldParentID", item.fldParentID),
                    new SqlParameter("@fldSort", item.fldSort),
                    new SqlParameter("@fldDefaultSortFld", item.fldDefaultSortFld),
                    new SqlParameter("@fldUserID", item.fldUserID==null?"":item.fldUserID),
                 };
                DataTable dt = rule.RunProcedure_V2("usp_Operation_LAPtblFW_Report_Doc", paras.ToList(), null, "PortalEntity");
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述    ：  根据不同的动作操作Report_Role_Doc表
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-07-11
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：  
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage OperationReport_Doc_Role(Report_Role item)
        {
            string result = string.Empty;
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                 {
                    new SqlParameter("@fldaction",item.fldaction),
                    new SqlParameter("@fldRoleID",item.fldRoleID),
                    new SqlParameter("@fldReportID", item.fldReportID),
                 };
                DataTable dt = rule.RunProcedure_V2("usp_tblFW_Role_Report_Doc", paras.ToList(), null, "PortalEntity");
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述    ：  根据不同的动作操作Report_Role表
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-07-11
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：  
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage OperationReport_Role(Report_Role item)
        {
            string result = string.Empty;
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@fldaction",item.fldaction),
                    new SqlParameter("@fldRoleID",item.fldRoleID),
                    new SqlParameter("@fldReportID", item.fldReportID),
                };
                DataTable dt = rule.RunProcedure_V2("usp_tblFW_Role_Report", paras.ToList(), null, "PortalEntity");
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述    ：  根据用户ID获取报表权限
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-07-12
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：  
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetReport_Role(string userid)
        {
            string result = string.Empty;
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                 {
                    new SqlParameter("@fldaction","query"),
                    new SqlParameter("@fldUserID",userid),
                 };
                DataTable dt = rule.RunProcedure_V2("usp_Operation_LAPtblFW_Report", paras.ToList(), null, "PortalEntity");
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述    ：  根据用户ID获取报告权限
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-07-12
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：  
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetReport_Role_Doc(string userid)
        {
            string result = string.Empty;
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@fldaction","query"),
                    new SqlParameter("@fldUserID",userid),
                };
                DataTable dt = rule.RunProcedure_V2("usp_Operation_LAPtblFW_Report_Doc", paras.ToList(), null, "PortalEntity");
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 
        /// </summary>
        public class Report
        {
            /// <summary>
            /// 动作 删除del 添加add 更新update
            /// </summary>
            public string fldaction
            {
                get;
                set;
            }

            /// <summary>
            /// 自增长键值
            /// </summary>
            public int fldAutoId
            {
                get;
                set;
            }

            /// <summary>
            /// 级别
            /// </summary>
            public int fldFlag
            {
                get;
                set;
            }

            /// <summary>
            /// 
            /// </summary>
            public string fldName
            {
                get;
                set;
            }

            /// <summary>
            /// 业务类型
            /// </summary>
            public string fldType
            {
                get;
                set;
            }

            /// <summary>
            /// 关键字
            /// </summary>
            public string fldTableName
            {
                get;
                set;
            }

            /// <summary>
            /// 父级ID
            /// </summary>
            public int fldParentID
            {
                get;
                set;
            }

            /// <summary>
            /// 排序字段
            /// </summary>
            public int fldSort
            {
                get;
                set;
            }

            /// <summary>
            /// 默认排序方式
            /// </summary>
            public string fldDefaultSortFld
            {
                get;
                set;
            }

            /// <summary>
            /// 用户ID
            /// </summary>
            public string fldUserID
            {
                get;
                set;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Report_Role
        {
            /// <summary>
            /// 动作 查询query
            /// </summary>
            public string fldaction
            {
                get;
                set;
            }

            /// <summary>
            /// 角色ID
            /// </summary>
            public int fldRoleID
            {
                get;
                set;
            }

            /// <summary>
            /// 用户拥有的权限
            /// </summary>
            public string fldReportID
            {
                get;
                set;
            }
        }
    }
}

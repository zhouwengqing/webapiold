using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Demo.MiddleDemo.Eqiso
{
    /// <summary>
    /// 功能描述：土壤GIS demo
    /// 创建  人：周文卿
    /// 创建时间：2017/12/11
    /// </summary>
    public class GetEqiso_DataController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：获得饮用水数据
        /// 创建  人：周文卿
        /// 创建时间：2017/09/26
        /// </summary>
        /// <param name="DP"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage Getisodata(DataParameter DP)
        {
            string result = "";
            string defwhere = "1=1";
            string defwhere2 = "1=1";
            string where1 = "";
            string level = "";
            string where2 = "";
            string where3 = "";
            try
            {

                if (rule.Judge(DP.stcode))
                {
                    defwhere += " and fldSTCode like '%" + DP.stcode.Substring(0, 4) + "%'";
                }
                if (rule.Judge(DP.stname))
                {
                    defwhere += " and fldSTName='" + DP.stname + "'";
                }

                if (rule.Judge(DP.pcode))
                {
                    defwhere += " and fldPCode='" + DP.pcode + "'";
                }


                #region
                if (rule.istime(DP.BeginDate) && rule.istime(DP.EndDate))
                {

                    if (DP.TimeType == "year")
                    {
                        DateTime dtime = DateTime.Parse(DP.EndDate);
                        int ti3 = dtime.Year;
                        int ti2 = (dtime.Year - 1);
                        where1 += " and fldYear='" + ti3 + "'";
                        where3 += " and fldYear='" + ti2 + "'";
                    }
                }
                else
                {
                    result = rule.JsonStr("error", "时间格式不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }
                #endregion

                //当期
                string sql = "select * from vwtblEQISO_Point where " + defwhere + where1;
                //同期
                string sql3 = "select * from vwtblEQISO_Point where " + defwhere + where3;
                DataTable dt = rule.GetMiddleData(sql);
                DataTable dt3 = rule.GetMiddleData(sql3);

                retudt tt = new retudt();
                tt.DQ = dt;
                tt.TQ = dt3;
                result = rule.JsonStr("ok", "", tt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }
    }

    /// <summary>
    /// 河流数据相关的参数
    /// </summary>
    public class DataParameter
    {

        /// <summary>
        /// 城市代码
        /// </summary>
        public string stcode { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string stname { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string TimeType { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string BeginDate { get; set; }

        /// <summary>
        /// 结束时间时间
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 点位代码
        /// </summary>
        public string pcode { get; set; }


    }

    /// <summary>
    /// 返回的数据
    /// </summary>
    public class retudt
    {
        /// <summary>
        /// 当期
        /// </summary>
        public DataTable DQ { get; set; }

        /// <summary>
        /// 前期
        /// </summary>
        public DataTable TQ { get; set; }

    }

}

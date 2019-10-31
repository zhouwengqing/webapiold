using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_DemoMiddleDemo.Eqin.Eqin_T
{
    /// <summary>
    /// 道路交通噪声
    /// </summary>
    public class GetEQIN_T_DataController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：获得城市数据
        /// 创建  人：周文卿
        /// 创建时间：2017/09/25
        /// </summary>
        /// <param name="DP"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage GetNTData(DataParameter DP)
        {
            string result = "";
            string defwhere = "1=1";
            string defwhere2 = "1=1";
            string where1 = "";
            string where2 = "";
            string where3 = "";
            try
            {
                if (rule.Judge(DP.stcode))
                {
                    defwhere += " and fldSTCode='" + DP.stcode + "'";
                }
                if (rule.Judge(DP.gdcode))
                {
                    defwhere += " and fldGDCode='" + DP.gdcode + "'";
                }
                if (rule.istime(DP.BeginDate) && rule.istime(DP.EndDate))
                {
                    DateTime dtime = DateTime.Parse(DP.BeginDate);
                    where1 += " and fldYear='" + dtime.Year + "'";
                    where3 += " and fldYear='" + (dtime.Year - 1) + "'";
                }
                else
                {
                    result = rule.JsonStr("error", "时间格式不正确！", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }

                //当期
                string sql = "select * from tblEQIN_T_Data where " + defwhere + where1;

                //同期
                string sql3 = "select * from tblEQIN_T_Data where " + defwhere + where3;

                DataTable dt = rule.GetMiddleData(sql);
                DataTable dt2 = new DataTable();
                DataTable dt3 = rule.GetMiddleData(sql3);

                retudt tt = new retudt();
                tt.DQ = dt;
                tt.LJ = dt2;
                tt.TQ = dt3;
                result = rule.JsonStr("ok", "", tt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 数据相关的参数
        /// </summary>
        public class DataParameter
        {



            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 结束时间时间
            /// </summary>
            public string EndDate { get; set; }

            /// <summary>
            /// 昼夜
            /// </summary>
            public string DN { get; set; }

            /// <summary>
            /// 城市代码
            /// </summary>
            public string stcode { get; set; }

            /// <summary>
            /// 网格
            /// </summary>
            public string gdcode { get; set; }




        }

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

            /// <summary>
            /// 累计
            /// </summary>
            public DataTable LJ { get; set; }
        }
    }
}

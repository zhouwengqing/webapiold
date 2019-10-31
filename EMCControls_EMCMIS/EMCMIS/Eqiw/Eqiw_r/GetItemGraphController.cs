using DDYZ.Ensis.Presistence.DataEntity;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using DDYZ.Ensis.Rule.DataRule;
using System.Web;
using DDYZ.Ensis.DataSource.DataAccess;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_r
{
    /// <summary>
    /// 功能描述：审核因子图形数据
    /// 创建  人：周文卿
    /// 创建时间：2018/01/10
    /// </summary>
    public class GetItemGraphController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获取因子的值
        /// 创建  人：周文卿
        /// 创建时间：2017/01/10
        /// </summary>
        /// <param name="rscode">断面代码</param>
        /// <param name="stcode">城市名称</param>
        /// <param name="rcode">河流名称</param>
        /// <param name="itemcode">因子代码</param>
        /// <param name="SAMPH">水平项代码</param>
        /// <param name="SAMPR">垂直项代码</param>
        /// <param name="time">时间</param>
        /// <param name="type">业务类型</param>
        /// <returns></returns>
        /// 

        [HttpGet]

        public HttpResponseMessage getItemGraphdate(string type, string rscode, string stcode, string rcode, string itemcode, string SAMPH, string SAMPR, string time)
        {
            string result = string.Empty;
            try
            {
                DateTime dt = DateTime.Parse(time);
                string defwhere = "";//一些默认的条件
                defwhere += " and fldSTCode='" + stcode + "' and fldRCode='" + rcode + "' and fldRSCode='" + rscode + "'" + " and fldSAMPH=" + SAMPH + " and fldSAMPR=" + SAMPR + " and fldItemCode='" + itemcode + "'";
                string dqtime = " and fldYear=" + (dt.Year) + " and fldMonth=" + dt.Month + defwhere;//当期时间
                string tqtime = "and fldYear=" + (dt.Year - 1) + " and fldMonth=" + dt.Month + defwhere;//同期时间

                string onetime = dqtime;//当前时间
                string twotime = "";//前两个月
                string threetiem = "";//前三个月

                string qqtime = "";
                if (dt.Month == 1)
                {
                    qqtime = " and fldYear=" + (dt.Year - 1) + " and fldMonth=12 " + defwhere;//前期时间
                }
                else
                {
                    qqtime = " and fldYear=" + (dt.Year) + " and fldMonth=" + (dt.Month - 1) + defwhere;//前期时间
                }




                if (dt.Month == 1)
                {
                    twotime = " and fldYear=" + (dt.Year - 1) + " and fldMonth=12 " + defwhere;
                    threetiem = " and fldYear=" + (dt.Year - 1) + " and fldMonth=11 " + defwhere;
                }
                else if (dt.Month == 2)
                {
                    twotime = " and fldYear=" + (dt.Year) + " and fldMonth=" + (dt.Month - 1) + defwhere;
                    threetiem = " and fldYear=" + (dt.Year - 1) + " and fldMonth=12" + defwhere;
                }
                else
                {
                    twotime = " and fldYear=" + (dt.Year) + " and fldMonth=" + (dt.Month - 1) + defwhere;
                    threetiem = " and fldYear=" + (dt.Year) + " and fldMonth=" + (dt.Month - 2) + defwhere;
                }
                GetItemGraphdate usp = new GetItemGraphdate();
                usp.onetime = onetime;
                usp.twotime = twotime;
                usp.threetime = threetiem;
                usp.tqwhere = tqtime;
                usp.qqwhere = qqtime;
                usp.type = type;
                DataTable dt1 = usp.ExecDataTable();



                retable rt = new retable();
                if (dt1.Rows.Count > 0)
                {
                    rt.zhexian = (from x in dt1.AsEnumerable()
                                  where x["fldFlag"].ToString() == "1"
                                  select x).OrderByDescending(x => x["isyear"]).CopyToDataTable();
                    rt.zhuzhuang = (from x in dt1.AsEnumerable()
                                    where x["fldFlag"].ToString() == "0"
                                    select x).CopyToDataTable();
                }

                result = rule.JsonStr("ok", "", rt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public class retable
        {
            /// <summary>
            /// 折线图的数据
            /// </summary>
            public DataTable zhexian { get; set; }

            /// <summary>
            /// 柱状图
            /// </summary>
            public DataTable zhuzhuang { set; get; }
        }


    }
}

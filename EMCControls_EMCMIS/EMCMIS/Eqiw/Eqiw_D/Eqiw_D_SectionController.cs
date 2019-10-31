using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Data;

namespace EMCControls_EMCMIS.Eqiw.Eqiw_D
{
    /// <summary>
    /// 功能描述    ：  获得地市饮用水测点信息
    /// 创建者      ：  吕荣誉
    /// 创建日期    ：  2017-8-14
    /// 修改者      ：   
    /// 修改日期    ：   
    /// 修改原因    ： 
    /// </summary>
    public class Eqiw_D_SectionController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  获得地市饮用水测点信息
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-7-10
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="fldYear">年份</param>
        /// <param name="Level">级别</param>
        /// <param name="include">是否包含上级</param>
        /// <returns>返回地市饮用水测点信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage GetEqiw_D_Section(string STCode, int fldYear, short Level, int include)
        {
            string result = string.Empty;
            try
            {

                RuletblEQIW_D_Section rule_point = new RuletblEQIW_D_Section();
                IList<tblEQIW_D_Section> list = rule_point.GetRCodeBySTCode(STCode, fldYear, Level, include);
                if (list != null && list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有测点数据", "");
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 功能描述    ：  获得地市饮用水测点信息，无STCode
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-7-10
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="fldYear">年份</param>
        /// <param name="Level">级别</param>
        /// <param name="include">是否包含上级</param>
        /// <returns>返回地市饮用水测点信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage GetEqiw_D_Section_NofldSTcode(string STCode, int fldYear, short Level, int include)
        {
            string result = string.Empty;
            try
            {

                RuletblEQIW_D_Section rule_point = new RuletblEQIW_D_Section();
                IList<tblEQIW_D_Section> list = rule_point.GetRCodeBySTCode_NofldSTCode(STCode, fldYear, Level, include);
                if (list != null && list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有测点数据", "");
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }







        /// <summary>
        /// 功能描述    ：  获得地市饮用水断面代码和断面名称
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-7-10
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="RCode">河流代码</param>
        /// <param name="Level">级别</param>
        /// <param name="include">是否包含上级</param>
        /// <param name="year">年份</param>
        /// <returns>返回地市饮用水测点信息</returns>
        [HttpGet]
        public HttpResponseMessage GetEqiw_D_Section_V2(string STCode, string RCode, short Level, int include, int year)
        {
            string result = string.Empty;
            try
            {

                RuletblEQIW_D_Section rule_point = new RuletblEQIW_D_Section();
                IList<tblEQIW_D_Section> list = rule_point.GetRSCode(STCode, RCode, Level, include, year);
                if (list != null && list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有测点数据", "");
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

















        /// <summary>
        /// 功能描述    ：  获得地表水河流和断面信息
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-07-06
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="stcode">城市代码</param>
        /// <param name="Level">级别</param>
        /// <returns>返回城市下所有的断面和河流</returns>
        [HttpGet]
        public HttpResponseMessage GetEqiw_D_RNameandRSName(string year, string stcode, string Level)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(year))
                {
                    result = rule.JsonStr("error", "缺少结束日期", "");
                }
                else if (string.IsNullOrEmpty(stcode))
                {
                    result = rule.JsonStr("error", "缺少城市代码", "");
                }
                else if (string.IsNullOrEmpty(Level))
                {
                    result = rule.JsonStr("error", "缺少断面级别", "");
                }
                else
                {
                    RuletblEQIW_D_Section rule_section = new RuletblEQIW_D_Section();
                    IList<tblEQIW_D_Section> list = rule_section.GetRSCodeandRCode(stcode, short.Parse(Level), year);

                    if (list != null && list.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", list);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有断面数据", "");
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
        /// 功能描述    ：  获得地市饮用水测点信息
        /// 创建者      ：  熊瑞竹
        /// 创建日期    ：  2017-9-13
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="fldYear">年份</param>
        /// <returns>返回地市饮用水测点信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage GetEqiw_d_hm_Section(string STCode, int fldYear)
        {
            string result = string.Empty;
            try
            {

                RuletblEQIW_D_Section rule_point = new RuletblEQIW_D_Section();
                IList<tblEQIW_D_Section> list = rule_point.GetHMRCodeBySTCode(STCode, fldYear);
                if (list != null && list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有测点数据", "");
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



















        [HttpPost]
        public HttpResponseMessage Get_Eqiw_D_Section()
        {
            string result = string.Empty;
            try
            {
                List<EMCMIS.Model.tblEQIW_D_Section> list = new List<EMCMIS.Model.tblEQIW_D_Section>();

                using (EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {
                    list = (from x in db.tblEQIW_D_Section
                            select x).ToList();
                }

                if (list != null && list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有测点数据", "");
                }

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
        /// <param name="where">查询条件</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">每页显示的数量</param>
        /// <param name="flag">判断是否需要加载所有数据</param>
        /// <returns></returns>
        [HttpGet]
        //
        public HttpResponseMessage GetW_DSectionSelect(string where, int PageIndex, int PageSize, string flag)
        {
            string result = string.Empty;
            try
            {

                int count = 0;
                DataTable dt = rule.getpaging("vwEQIW_D_Section_report", "*", "1=1" + where, PageIndex, PageSize, "fldSTCode", out count);
                string stcode = "[]";
                string year = "[]";
                string rername = "[]";
                string rersname = "[]";
                string reSCategory = "[]";



                string fldRSTown_list = "[]";
                string fldRSWaterWork_list = "[]";


                if (flag == "1")
                {
                    DataTable dt1 = rule.getdt("select * from vwEQIW_D_Section_report where 1=1" + where);
                    //城市代码
                    var fldSTCode = (from x in dt1.AsEnumerable()
                                     select new tblEQIW_D_Section
                                     {
                                         fldSTCode = x.Field<string>("fldSTCode"),
                                         fldSTName = x.Field<string>("fldSTName")
                                     }
                    ).DistinctBy(x => new { x.fldSTCode, x.fldSTName }).OrderBy(x => x.fldSTCode);
                    stcode = JsonHelper.SerializeObject(fldSTCode);
                    //时间
                    var fldYear = (from x in dt1.AsEnumerable()
                                   select new file
                                   {
                                       value = x.Field<decimal>("fldYear").ToString(),
                                       name = x.Field<decimal>("fldYear").ToString()
                                   }
                                 ).OrderByDescending(x => x.value).DistinctBy(x => new { x.value });
                    year = JsonHelper.SerializeObject(fldYear);

                    //断面名称
                    var fldRSName = (from x in dt1.AsEnumerable()
                                     select new file
                                     {
                                         value = x.Field<string>("fldRSCode").ToString(),
                                         name = x.Field<string>("fldRSName").ToString()
                                     }
                                 ).DistinctBy(x => new { x.value });
                    if (fldRSName.First().value != "")
                    {
                        rersname = JsonHelper.SerializeObject(fldRSName);
                    }

                    //河流名称
                    var RName = (from x in dt1.AsEnumerable()
                                 select new file
                                 {
                                     value = x.Field<string>("fldRCode").ToString(),
                                     name = x.Field<string>("fldRName").ToString()
                                 }
                                ).DistinctBy(x => new { x.value });
                    if (RName.First().value != "")
                    {
                        rername = JsonHelper.SerializeObject(RName);
                    }




                    //水源地名称
                    var fldSCategory = (from x in dt1.AsEnumerable()
                                        select new file
                                        {
                                            value = x.Field<string>("fldSCategory").ToString(),
                                            name = x.Field<string>("fldSCategory").ToString()
                                        }
                                 ).DistinctBy(x => new { x.value });
                    if (fldSCategory.First().value != "")
                    {
                        reSCategory = JsonHelper.SerializeObject(fldSCategory);
                    }













                    var fldRSTown = (from x in dt1.AsEnumerable()
                                     select new file
                                     {
                                         value = x.Field<string>("fldRSCode").ToString(),
                                         name = x.Field<string>("fldRSTown").ToString()
                                     }
                                 ).DistinctBy(x => new { x.value });
                    if (fldRSTown.First().value != "")
                    {
                        fldRSTown_list = JsonHelper.SerializeObject(fldRSTown);
                    }









                    var fldRSWaterWork = (from x in dt1.AsEnumerable()
                                          select new file
                                          {
                                              value = x.Field<string>("fldRSWaterWork").ToString(),
                                              name = x.Field<string>("fldRSWaterWork").ToString()
                                          }
                                 ).DistinctBy(x => new { x.value });
                    if (fldRSWaterWork.First().value != "")
                    {
                        fldRSWaterWork_list = JsonHelper.SerializeObject(fldRSWaterWork);
                    }









                }

                string d = JsonHelper.SerializeObject(dt);

                string text = "[{data:" + d + ",count:" + count + ",fldSTCode:" + stcode + ",fldYear:" + year + ",rersname:" + rersname + ",rername:" + rername + ",reSCategory:" + reSCategory + ",fldRSTown_list:" + fldRSTown_list + ",fldRSWaterWork_list:" + fldRSWaterWork_list + "}]";
                if (dt.Rows.Count > 0)
                {
                    result = rule.JsonStr("ok", "查询成功", text);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据", text);
                }
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
        public class file
        {
            /// <summary>
            /// 
            /// </summary>
            public string value { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
        }


    }
}

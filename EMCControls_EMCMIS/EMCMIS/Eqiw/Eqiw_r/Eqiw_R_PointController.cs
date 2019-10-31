using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Linq;

namespace EMCControls_EMCMIS.Eqiw.Eqiw_r
{
    /// <summary>
    /// 有关地表水断面操作
    /// </summary>
    public class Eqiw_R_PointController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  获得地表水河流信息
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-06-16
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="year">结束年份</param>
        /// <param name="include">是否包含上级</param>
        /// <param name="stcode">城市代码</param>
        /// <param name="Level">测点级别</param>
        /// <returns>返回河流信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage Geteqiw_r_getRTree(string year, string include, string stcode, string Level)
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
                    RuletblEQIW_R_Section rule_section = new RuletblEQIW_R_Section();
                    IList<tblEQIW_R_Section> list = rule_section.GetRCodeBySTCodeByRole(stcode, Int32.Parse(year), Int16.Parse(Level), Int32.Parse(include), 1);
                    List<tbleqiw_r_rcode> rcodelist = new List<tbleqiw_r_rcode>();
                    if (list != null && list.Count > 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            tbleqiw_r_rcode tbl = new tbleqiw_r_rcode();
                            tbl.rcode = list[i].fldRCode;
                            tbl.rname = list[i].fldRName;
                            rcodelist.Add(tbl);
                        }
                    }
                    if (list != null && list.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", list);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有河流数据", "");
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
        /// 功能描述    ：  获得地表水断面信息
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-06-16
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="Edate">结束年份</param>
        /// <param name="include">是否包含上级</param>
        /// <param name="stcode">城市代码</param>
        /// <param name="Level">测点级别</param>
        /// <param name="RCode">河流代码</param>
        /// <returns>返回断面信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage Geteqiw_r_ddlRSName(string Edate, string include, string stcode, string Level, string RCode)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(Edate))
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
                else if (string.IsNullOrEmpty(RCode))
                {
                    result = rule.JsonStr("error", "缺少河流代码", "");
                }
                else
                {
                    RuletblEQIW_R_Section rule_section = new RuletblEQIW_R_Section();
                    IList<tblEQIW_R_Section> list;
                    if (Level == "-2")
                    {
                        list = rule_section.GetRSCodeByRCode(stcode, RCode, Convert.ToInt32(Edate));
                    }
                    else
                    {
                        list = rule_section.GetRSCode(stcode, RCode, short.Parse(Level), Convert.ToInt32(include), Convert.ToInt32(Edate), 1);
                    }
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
        /// 功能描述    ：  根据城市代码和年份取的地表水基本信息
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-01-24
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="stcode">城市代码</param>
        /// <param name="type">水源类型</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetSectionSelectByStcode(string year = "-1", string stcode = "-1", string type = "1")
        {
            string result = string.Empty;
            try
            {
                RuletblEQIW_R_Section rule_section = new RuletblEQIW_R_Section();
                DataTable dt = rule_section.gettblEQIW_R_Sectionbystcode(year, stcode, type);
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        /// 功能描述    ：  获得地表水河流和断面信息
        /// 创建者      ：  周文卿
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
        //
        public HttpResponseMessage Geteqiw_r_RNameandRSName(string year, string stcode, string Level)
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
                    RuletblEQIW_R_Section rule_section = new RuletblEQIW_R_Section();
                    IList<tblEQIW_R_Section> list = rule_section.GetRSCodeandRCode(stcode, short.Parse(Level), year);
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
        /// 
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">每页显示的数量</param>
        /// <param name="flag">判断是否需要加载所有数据</param>
        /// <returns></returns>
        [HttpGet]
        //
        public HttpResponseMessage GetSection(string where, int PageIndex, int PageSize, string flag)
        {
            string result = string.Empty;
            try
            {

                int count = 0;
                DataTable dt = rule.getpaging("vwEQIW_R_Section_report", "*", "1=1" + where, PageIndex, PageSize, "fldSTCode", out count);
                string stcode = "[]";
                string year = "[]";
                string RVTown = "[]";
                string RSTown = "[]";
                string rekhcityname = "[]";
                string rekhtownname = "[]";
                string reSLevel = "[]";
                string reRLevel = "[]";
                string rebyn = "[]";
                string reattribute = "[]";
                string rerfunction = "[]";
                string rername = "[]";
                string rersname = "[]";
                string reWaterArea = "[]";
                string reRSWaterWork = "[]";
                string reControl = "[]";
                string rekhscategory = "[]";
                string reSCategory = "[]";
                if (flag == "1")
                {
                    DataTable dt1 = rule.getdt("select * from vwEQIW_R_Section_report where 1=1" + where);
                    //城市代码
                    var fldSTCode = (from x in dt1.AsEnumerable()
                                     select new tblEQIW_R_Section
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
                    //所在区县
                    var fldRVTown = (from x in dt1.AsEnumerable()
                                     select new file
                                     {
                                         value = x.Field<string>("fldRVTown").ToString(),
                                         name = x.Field<string>("fldRVTown").ToString()
                                     }
                                 ).DistinctBy(x => new { x.value });
                    if (fldRVTown.First().value != "")
                    {
                        RVTown = JsonHelper.SerializeObject(fldRVTown);
                    }
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
                    //考核城市
                    var khcityname = (from x in dt1.AsEnumerable()
                                      select new file
                                      {
                                          value = x.Field<string>("fldkhcityname").ToString(),
                                          name = x.Field<string>("fldkhcityname").ToString()
                                      }
                                 ).DistinctBy(x => new { x.value });
                    if (khcityname.First().value != "")
                    {
                        rekhcityname = JsonHelper.SerializeObject(khcityname);
                    }
                    //考核县区
                    var khtownname = ((from x in dt1.AsEnumerable()
                                       where x["fldkhtownname"].ToString() != ""
                                       select new file
                                       {
                                           value = x.Field<string>("fldkhtownname").ToString(),
                                           name = x.Field<string>("fldkhtownname").ToString()
                                       }
                                 ).DistinctBy(x => new { x.value })).ToList();
                    if (khtownname.Count > 0)
                    {
                        rekhtownname = JsonHelper.SerializeObject(khtownname);
                    }
                    //控制级别
                    var SLevel = (from x in dt1.AsEnumerable()
                                  select new file
                                  {
                                      value = x.Field<string>("fldSLevel").ToString(),
                                      name = x.Field<string>("fldSLevel").ToString()
                                  }
                                 ).DistinctBy(x => new { x.value });
                    if (SLevel.First().value != "")
                    {
                        reSLevel = JsonHelper.SerializeObject(SLevel);
                    }
                    //交界级别
                    var byn = (from x in dt1.AsEnumerable()
                               select new file
                               {
                                   value = x.Field<string>("fldbyn").ToString(),
                                   name = x.Field<string>("fldbyn").ToString()
                               }
                                 ).DistinctBy(x => new { x.value });
                    if (byn.First().value != "")
                    {
                        rebyn = JsonHelper.SerializeObject(byn);
                    }
                    //断面属性
                    var attribute = ((from x in dt1.AsEnumerable()
                                      select new file
                                      {
                                          value = x.Field<string>("fldAttribute").ToString(),
                                          name = x.Field<string>("fldAttribute").ToString()
                                      }
                                 ).DistinctBy(x => new { x.value })).ToList();
                    if (attribute.Count > 0)
                    {
                        reattribute = JsonHelper.SerializeObject(attribute);
                    }
                    //断面功能
                    var rfunction = ((from x in dt1.AsEnumerable()
                                      select new file
                                      {
                                          value = x.Field<string>("fldrfunction").ToString(),
                                          name = x.Field<string>("fldrfunction").ToString()
                                      }
                                 ).DistinctBy(x => new { x.value })).ToList();
                    if (rfunction.Count > 0)
                    {
                        rerfunction = JsonHelper.SerializeObject(rfunction);
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
                    //所在流域
                    var WaterArea = ((from x in dt1.AsEnumerable()
                                      where x["fldWaterArea"].ToString() != ""
                                      select new file
                                      {
                                          value = x.Field<string>("fldWaterArea").ToString(),
                                          name = x.Field<string>("fldWaterArea").ToString()
                                      }
                               ).DistinctBy(x => new { x.value })).ToList();
                    if (WaterArea.Count > 0)
                    {
                        reWaterArea = JsonHelper.SerializeObject(WaterArea);
                    }
                    //所在区县
                    var fldRSTown = (from x in dt1.AsEnumerable()
                                     select new file
                                     {
                                         value = x.Field<string>("fldRSTown").ToString(),
                                         name = x.Field<string>("fldRSTown").ToString()
                                     }
                                 ).DistinctBy(x => new { x.value });
                    if (fldRSTown.First().value != "")
                    {
                        RSTown = JsonHelper.SerializeObject(fldRSTown);
                    }
                    //所在河流级别
                    var RLevel = (from x in dt1.AsEnumerable()
                                  select new file
                                  {
                                      value = x.Field<string>("fldrlevel").ToString(),
                                      name = x.Field<string>("fldrlevel").ToString()
                                  }
                                 ).DistinctBy(x => new { x.value });
                    if (RLevel.First().value != "")
                    {
                        reRLevel = JsonHelper.SerializeObject(RLevel);
                    }
                    //所属水系
                    var RSWaterWork = ((from x in dt1.AsEnumerable()
                                        where x["fldRSWaterWork"].ToString() != ""
                                        select new file
                                        {
                                            value = x.Field<string>("fldRSWaterWork").ToString(),
                                            name = x.Field<string>("fldRSWaterWork").ToString()
                                        }
                               ).DistinctBy(x => new { x.value })).ToList();
                    if (RSWaterWork.Count > 0)
                    {
                        reRSWaterWork = JsonHelper.SerializeObject(RSWaterWork);
                    }
                    //出入境情况
                    var Control = (from x in dt1.AsEnumerable()
                                   select new file
                                   {
                                       value = x.Field<string>("fldControl").ToString(),
                                       name = x.Field<string>("fldControl").ToString()
                                   }
                                 ).DistinctBy(x => new { x.value });
                    if (Control.First().value != "")
                    {
                        reControl = JsonHelper.SerializeObject(Control);
                    }
                    //考核属性
                    var khscategory = (from x in dt1.AsEnumerable()
                                       select new file
                                       {
                                           value = x.Field<string>("fldkhscategory").ToString(),
                                           name = x.Field<string>("fldkhscategory").ToString()
                                       }
                                 ).DistinctBy(x => new { x.value });
                    if (khscategory.First().value != "")
                    {
                        rekhscategory = JsonHelper.SerializeObject(khscategory);
                    }
                    //断面类别
                    var SCategory = (from x in dt1.AsEnumerable()
                                     select new file
                                     {
                                         value = x.Field<string>("fldSCategory").ToString(),
                                         name = x.Field<string>("fldSCategory").ToString()
                                     }
                                 ).DistinctBy(x => new { x.value });
                    if (SCategory.First().value != "")
                    {
                        reSCategory = JsonHelper.SerializeObject(SCategory);
                    }
                }

                string d = JsonHelper.SerializeObject(dt);

                string text = "[{data:" + d + ",count:" + count + ",fldSTCode:" + stcode + ",fldYear:" + year + ",fldRVTown:" + RVTown + ",khcityname:" + rekhcityname + ",khtownname:" + rekhtownname + ",reSLevel:" + reSLevel + ",rebyn:" + rebyn + ",reattribute:" + reattribute + ",rerfunction:" + rerfunction + ",rersname:" + rersname + ",rername:" + rername + ",reWaterArea:" + reWaterArea + ",fldRSTown:" + RSTown + ",reRLevel:" + reRLevel + ",reRSWaterWork:" + reRSWaterWork + ",reControl:" + reControl + ",rekhscategory:" + rekhscategory + ",reSCategory:" + reSCategory + "}]";
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



        /// <summary>
        /// 功能描述    ：  获得地表水河流信息
        /// 创建者      ：  熊瑞竹
        /// 创建日期    ：  2017-09-13
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="year">结束年份</param>
        /// <param name="stcode">城市代码</param>
        /// <returns>返回河流信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage Geteqiw_r_hm_getRTree(string year, string stcode)
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
                else
                {
                    RuletblEQIW_R_Section rule_section = new RuletblEQIW_R_Section();
                    IList<tblEQIW_R_Section> list = rule_section.GetHMRCodeBySTCodeByRole(stcode, Int32.Parse(year));
                    List<tbleqiw_r_rcode> rcodelist = new List<tbleqiw_r_rcode>();
                    if (list != null && list.Count > 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            tbleqiw_r_rcode tbl = new tbleqiw_r_rcode();
                            tbl.rcode = list[i].fldRCode;
                            tbl.rname = list[i].fldRName;
                            rcodelist.Add(tbl);
                        }
                    }
                    if (list != null && list.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", list);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有河流数据", "");
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
        /// 河流类
        /// </summary>
        private class tbleqiw_r_rcode
        {
            /// <summary>
            /// 河流代码
            /// </summary>
            public string rcode { get; set; }

            /// <summary>
            /// 河流名称
            /// </summary>
            public string rname { get; set; }
        }











        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-7
        /// 功能描述：根据河流名称的集合，返回其断面数据
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetEqiw_R_byRName(GetEqiw_R_byRName_Info info)
        {
            string result = string.Empty;
            try
            {
                using (EMCControls_EMCMIS.EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {

                    List<EMCMIS.Model.tblEQIW_R_Section> list = new List<EMCMIS.Model.tblEQIW_R_Section>();

                    if (info.fldRName == null)
                    {
                        list = (from x in db.tblEQIW_R_Section
                                where info.fldYear == x.fldYear &&
                                info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tblEQIW_R_Section
                                where info.fldRName.Contains(x.fldRName) &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }

                    if (list != null && list.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", list);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有河流数据", "");
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
        public class GetEqiw_R_byRName_Info
        {
            /// <summary>
            /// RName集合
            /// </summary>
            public List<string> fldRName { get; set; }


            /// <summary>
            /// 城市代码
            /// 代码列表形式
            /// </summary>
            public string fldSTCode { get; set; }

            /// <summary>
            /// 年份
            /// </summary>
            public decimal? fldYear { get; set; }
        }










        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-7
        /// 功能描述：根据河流名称的集合，返回其断面数据
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_Eqiw_R_Section_byRSCodeAndYear(Get_Eqiw_R_Section_byRSCodeAndYear_Info info)
        {
            string result = string.Empty;
            try
            {
                using (EMCControls_EMCMIS.EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {

                    List<EMCMIS.Model.tblEQIW_R_Section> list = new List<EMCMIS.Model.tblEQIW_R_Section>();

                    list = (from x in db.tblEQIW_R_Section
                            where info.fldYear == x.fldYear
                            select x).ToList();

                    if (info.fldRCode != null)
                    {
                        list = (from x in list
                                where info.fldRCode.Contains(x.fldRCode)
                                select x).ToList();
                    }

                    if (info.fldRSCode != null)
                    {
                        list = (from x in list
                                where info.fldRSCode.Contains(x.fldRSCode)
                                select x).ToList();
                    }


                    if (info.StaLodAndStaLad == "1")
                    {
                        foreach (var item in list)
                        {
                            if (item.fldLOD == "" || item.fldLOD == null)
                            {
                                item.fldLOD = "0";
                            }

                            if (item.fldLOM.ToString() == "" || item.fldLOD == null)
                            {
                                item.fldLOM = 0.0M;
                            }

                            if (item.fldLOS.ToString() == "" || item.fldLOS == null)
                            {
                                item.fldLOS = 0.0M;
                            }

                            if (item.fldLAD == "" || item.fldLAD == null)
                            {
                                item.fldLAD = "0";
                            }

                            if (item.fldLAM.ToString() == "" || item.fldLAM == null)
                            {
                                item.fldLAM = 0.0M;
                            }

                            if (item.fldLAS.ToString() == "" || item.fldLAS == null)
                            {
                                item.fldLAS = 0.0M;
                            }
                        }

                        foreach (var item in list)
                        {
                            item.fldStaLod = (double.Parse(item.fldLOD) + double.Parse(item.fldLOM.ToString()) / 60 + double.Parse(item.fldLOS.ToString()) / 3600).ToString();

                            item.fldStaLad = (double.Parse(item.fldLAD) + double.Parse(item.fldLAM.ToString()) / 60 + double.Parse(item.fldLAS.ToString()) / 3600).ToString();
                        }
                    }


                    if (list != null && list.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", list);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有河流数据", "");
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
        public class Get_Eqiw_R_Section_byRSCodeAndYear_Info
        {

            /// <summary>
            /// 河流代码
            /// </summary>
            public string fldRCode { get; set; }

            /// <summary>
            /// 断面代码
            /// </summary>
            public string fldRSCode { get; set; }

            /// <summary>
            /// 年份
            /// </summary>
            public decimal? fldYear { get; set; }

            /// <summary>
            /// 是否增加经度纬度
            /// 1：增加经度纬度列fldStaLod和fldStaLad
            /// </summary>
            public string StaLodAndStaLad { get; set; }

        }














        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-7
        /// 功能描述：根据河流名称的集合，返回其断面数据
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_Eqiw_R_Section_byYearAndAttribute(Get_Eqiw_R_Section_byYearAndAttribute_Info info)
        {
            string result = string.Empty;
            try
            {
                using (EMCControls_EMCMIS.EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {

                    List<EMCMIS.Model.tblEQIW_R_Section> list = new List<EMCMIS.Model.tblEQIW_R_Section>();

                    list = (from x in db.tblEQIW_R_Section
                            where x.fldYear == info.fldYear
                            select x).ToList();


                    if (info.fldAttribute != null)
                    {
                        list = (from x in db.tblEQIW_R_Section
                                where info.fldAttribute.Contains(x.fldAttribute)
                                select x).ToList();
                    }



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
        public class Get_Eqiw_R_Section_byYearAndAttribute_Info
        {
            /// <summary>
            /// 控制级别
            /// </summary>
            public List<string> fldAttribute { get; set; }


            /// <summary>
            /// 年份
            /// </summary>
            public decimal? fldYear { get; set; }
        }















        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-7
        /// 功能描述：根据河流名称的集合，返回其断面数据
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQI_Point_Group(Get_tblEQI_Point_Group_Info info)
        {
            string result = string.Empty;
            try
            {
                using (EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {

                    List<EMCMIS.Model.tblEQI_Point_Group> list = new List<EMCMIS.Model.tblEQI_Point_Group>();

                    list = (from x in db.tblEQI_Point_Group
                            where info.fldYear == x.fldYear &&
                            info.fldObject.Contains(x.fldObject)
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
        public class Get_tblEQI_Point_Group_Info
        {
            /// <summary>
            /// 断面代码
            /// </summary>
            public string fldObject { get; set; }

            /// <summary>
            /// 年份
            /// </summary>
            public decimal? fldYear { get; set; }
        }
































        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-16
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQIW_R_StagePropTar(Get_tblEQIW_R_StagePropTar_Info info)
        {
            string result = string.Empty;
            try
            {
                using (EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {

                    List<EMCMIS.Model.tblEQIW_R_StagePropTar> list = new List<EMCMIS.Model.tblEQIW_R_StagePropTar>();

                    if (info.fldValleyName == null)
                    {
                        list = (from x in db.tblEQIW_R_StagePropTar
                                where info.fldYear.Contains(x.fldYear)
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tblEQIW_R_StagePropTar
                                where info.fldYear.Contains(x.fldYear) &&
                                info.fldValleyName.Contains(x.fldValleyName)
                                select x).ToList();
                    }

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
        public class Get_tblEQIW_R_StagePropTar_Info
        {
            public List<string> fldValleyName { get; set; }

            public List<string> fldYear { get; set; }
        }





















        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-16
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQIW_R_DAQLTSTD(Get_tblEQIW_R_DAQLTSTD_Info info)
        {
            string result = string.Empty;
            try
            {
                using (EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {

                    List<EMCMIS.Model.tblEQIW_R_DAQLTSTD> list = new List<EMCMIS.Model.tblEQIW_R_DAQLTSTD>();


                    list = (from x in db.tblEQIW_R_DAQLTSTD
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
        public class Get_tblEQIW_R_DAQLTSTD_Info
        {
        }






















        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-4-18
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_Eqiw_R_Section_byRiverStream(Get_Eqiw_R_Section_byRiverStream_Info info)
        {
            string result = string.Empty;
            try
            {
                using (EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {

                    List<EMCMIS.Model.tblEQIW_R_Section> list = new List<EMCMIS.Model.tblEQIW_R_Section>();

                    List<string> list_Point = new List<string>();


                    if (info.fldRiverStream != null && info.fldRiverStream != "")
                    {
                        list = (from x in db.tblEQIW_R_Section
                                where info.fldRiverStream.Contains(x.fldRiverStream) &&
                                x.fldYear == info.fldYear
                                select x).ToList();
                    }




                    if (info.fldkhscategory != null)
                    {
                        foreach (var item in info.fldkhscategory)
                        {
                            var query = (from x in db.tblEQIW_R_Section
                                         where item == x.fldkhscategory &&
                                         x.fldYear == info.fldYear
                                         select x).ToList();

                            list.AddRange(query);
                        }
                    }






                    if (info.RetrunType == "1")
                    {
                        list_Point = (from x in list
                                      select x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode).ToList();

                        string point = "";

                        foreach (var item in list_Point)
                        {
                            point += item + ",";
                        }

                        point = point.TrimEnd(',');

                        if (list_Point.Count > 0)
                        {
                            result = rule.JsonStr("ok", "", point);
                        }
                        else
                        {
                            result = rule.JsonStr("nodata", "没有数据", "");
                        }
                    }
                    else
                    {
                        if (list.Count > 0)
                        {
                            result = rule.JsonStr("ok", "", list);
                        }
                        else
                        {
                            result = rule.JsonStr("nodata", "没有数据", "");
                        }
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
        public class Get_Eqiw_R_Section_byRiverStream_Info
        {
            /// <summary>
            /// “入海口”
            /// </summary>
            public string fldRiverStream { get; set; }


            /// <summary>
            /// “国考、省考”，“省考”
            /// </summary>
            public List<string> fldkhscategory { get; set; }


            /// <summary>
            /// 年份
            /// </summary>
            public int fldYear { get; set; }


            /// <summary>
            /// 1：仅返回点位格式：fldSTCode.fldRCode.fldRSCode
            /// </summary>
            public string RetrunType { get; set; }

        }


        /// <summary>
        /// 创建者  ：周文卿
        /// 创建日期：2018-05-28
        /// 功能描述：根据年份获得所有地表水基本信息
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_Eqiw_R_ALLSection(Get_Eqiw_R_Section_byYearAndAttribute_Info info)
        {
            string result = string.Empty;
            try
            {
                using (EMCControls_EMCMIS.EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {

                    List<EMCMIS.Model.tblEQIW_R_Section> list = new List<EMCMIS.Model.tblEQIW_R_Section>();


                    list = (from x in db.tblEQIW_R_Section
                            where x.fldYear == info.fldYear
                            select x).ToList();
                    if (list != null && list.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", list);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有河流数据", "");
                    }
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


























    }
}

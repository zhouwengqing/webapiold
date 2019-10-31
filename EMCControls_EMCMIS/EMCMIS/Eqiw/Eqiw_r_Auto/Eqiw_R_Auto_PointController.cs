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
    public class Eqiw_R_Auto_PointController : ApiController
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
                string rekhcityname = "[]";
                string rekhtownname = "[]";
                string reSLevel = "[]";
                string rebyn = "[]";
                string reattribute = "[]";
                string rerfunction = "[]";
                string rername = "[]";
                string reWaterArea = "[]";
                if (flag == "1")
                {
                    DataTable dt1 = rule.getdt("select * from vwEQIW_R_Section_report");
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
                    var khtownname = (from x in dt1.AsEnumerable()
                                      where x["fldkhtownname"].ToString() != ""
                                      select new file
                                      {
                                          value = x.Field<string>("fldkhtownname").ToString(),
                                          name = x.Field<string>("fldkhtownname").ToString()
                                      }
                                 ).DistinctBy(x => new { x.value });
                    if (khtownname.First().value != "")
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
                    var attribute = (from x in dt1.AsEnumerable()
                                     select new file
                                     {
                                         value = x.Field<string>("fldattribute").ToString(),
                                         name = x.Field<string>("fldattribute").ToString()
                                     }
                                 ).DistinctBy(x => new { x.value });
                    if (attribute.First().value != "")
                    {
                        reattribute = JsonHelper.SerializeObject(attribute);
                    }
                    //断面功能
                    var rfunction = (from x in dt1.AsEnumerable()
                                     select new file
                                     {
                                         value = x.Field<string>("fldrfunction").ToString(),
                                         name = x.Field<string>("fldrfunction").ToString()
                                     }
                                 ).DistinctBy(x => new { x.value });
                    if (rfunction.First().value != "")
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
                    var WaterArea = (from x in dt1.AsEnumerable()
                                     where x["fldWaterArea"].ToString() != ""
                                     select new file
                                     {
                                         value = x.Field<string>("fldWaterArea").ToString(),
                                         name = x.Field<string>("fldWaterArea").ToString()
                                     }
                               ).DistinctBy(x => new { x.value });
                    if (WaterArea.First().value != "")
                    {
                        reWaterArea = JsonHelper.SerializeObject(WaterArea);
                    }
                }

                string d = JsonHelper.SerializeObject(dt);

                string text = "[{data:" + d + ",count:" + count + ",fldSTCode:" + stcode + ",fldYear:" + year + ",fldRVTown:" + RVTown + ",khcityname:" + rekhcityname + ",khtownname:" + rekhtownname + ",reSLevel:" + reSLevel + ",rebyn:" + rebyn + ",reattribute:" + reattribute + ",rerfunction:" + rerfunction + ",rername:" + rername + ",reWaterArea:" + reWaterArea + "}]";
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
        /// 创建日期：2018-3-14
        /// 功能描述：
        /// 修改  人：周文卿
        /// 修改时间：20180605
        /// 修改原因：新增根据断面查询所有这个断面的所有基本信息
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQIW_R_Section_Auto(Get_tblEQIW_R_Section_Auto_Info info)
        {
            string result = string.Empty;
            try
            {

                List<EMCMIS.Model.tblEQIW_R_Section_Auto> list = new List<EMCMIS.Model.tblEQIW_R_Section_Auto>();


                using (EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {

                    if (info.DataType == "0")
                    {
                        list = (from x in db.tblEQIW_R_Section_Auto
                                where x.fldYear == info.fldYear
                                select x).ToList();
                    }


                    if (info.DataType == "1")
                    {
                        list = (from x in db.tblEQIW_R_Section_Auto
                                where x.fldSTCode == info.fldSTCode &&
                                x.fldYear == info.fldYear
                                select x).ToList();

                        if (info.fldSLevel != -1)
                        {
                            list = (from x in list
                                    where x.fldSLevel == info.fldSLevel
                                    select x).ToList();
                        }
                    }


                    if (info.DataType == "2")
                    {
                        list = (from x in db.tblEQIW_R_Section_Auto
                                where x.fldRCode == info.fldRCode &&
                                x.fldYear == info.fldYear
                                select x).ToList();

                        if (info.fldSLevel != -1)
                        {
                            list = (from x in list
                                    where x.fldSLevel == info.fldSLevel
                                    select x).ToList();
                        }
                    }
                    if (info.DataType == "3")
                    {
                        list = (from x in db.tblEQIW_R_Section_Auto
                                where x.fldRSCode == info.fldRSCode &&
                                x.fldYear == info.fldYear
                                select x).ToList();                      
                    }
                }




                if (info.StaLodAndStaLad == "1")
                {
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
                    result = rule.JsonStr("nodata", "没有数据", "");
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
        public class Get_tblEQIW_R_Section_Auto_Info
        {
            /// <summary>
            /// 0：根据年份返回数据
            /// 1：根据城市，查询此城市下的河流与断面
            /// 2：根据河流，查询此河流下的断面
            /// </summary>
            public string DataType { get; set; }


            /// <summary>
            /// 城市代码
            /// </summary>
            public string fldSTCode { get; set; }


            public string fldRCode { get; set; }


            /// <summary>
            /// 级别，-1查全部
            /// </summary>
            public short? fldSLevel { get; set; }


            /// <summary>
            /// 年份
            /// </summary>
            public decimal? fldYear { get; set; }


            /// <summary>
            /// 是否计算经度纬度
            /// 1：计算经度纬度列fldStaLod和fldStaLad
            /// </summary>
            public string StaLodAndStaLad { get; set; }

            /// <summary>
            /// 断面代码
            /// </summary>
            public string fldRSCode { get; set; }

        }













        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-14
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQIW_R_Section_Auto_All(Get_tblEQIW_R_Section_Auto_All_Info info)
        {
            string result = string.Empty;
            try
            {
                List<EMCMIS.Model.tblEQIW_R_Section_Auto> list = new List<EMCMIS.Model.tblEQIW_R_Section_Auto>();

                using (EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {
                    list = (from x in db.tblEQIW_R_Section_Auto
                            select x).ToList();
                }

                foreach (var item in list)
                {
                    item.fldStaLod = (double.Parse(item.fldLOD) + double.Parse(item.fldLOM.ToString()) / 60 + double.Parse(item.fldLOS.ToString()) / 3600).ToString();

                    item.fldStaLad = (double.Parse(item.fldLAD) + double.Parse(item.fldLAM.ToString()) / 60 + double.Parse(item.fldLAS.ToString()) / 3600).ToString();
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
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 参数实体
        /// </summary>
        public class Get_tblEQIW_R_Section_Auto_All_Info
        {
        }





























        /// <summary>
        /// 功能描述    ：  保存地市饮用水录入数据
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2018-3-14
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="data">需要保存的实体类</param>
        /// <returns>返回保存是否成功</returns>
        [HttpPost]
        public HttpResponseMessage ItemSave(eqiw_dsavedata data)
        {
            string result = string.Empty;
            int result2 = 0;
            try
            {


                List<EMCMIS.Model.tblEQIW_R_Basedata_Pre_Auto> list = new List<EMCMIS.Model.tblEQIW_R_Basedata_Pre_Auto>();

                var query = from x in data.fldItemData
                            select x;

                DateTime time = DateTime.Parse(data.BeginDate);

                foreach (var item in query)
                {
                    var tbl = new EMCMIS.Model.tblEQIW_R_Basedata_Pre_Auto()
                    {
                        fldItemCode = item.itemcode,
                        fldItemValue = Decimal.Parse(item.itemvalue),
                        fldYear = time.Year,
                        fldMonth = time.Month,
                        fldDay = time.Day,
                        fldHour = time.Hour,
                        fldMinute = time.Minute,
                        fldUserID = int.Parse(data.fldUserID),
                        fldCityID_Operate = int.Parse(data.fldCityID_Operate),
                        fldCityID_Submit = data.fldCityID_Submit,
                        fldSTCode = data.CheckCode,
                        fldRCode = data.fldRCode,
                        fldRSCode = data.fldRSCode,
                        fldRSC = data.fldRSC,
                        fldFlag = 0,
                        fldImport = 0,
                        fldSAMPH = "0",
                        fldSAMPR = "0",
                        fldDate_Operate = DateTime.Now,
                        fldSource = 1,
                        fldBatch = "0",
                        fldDeleteState = 0
                    };
                    list.Add(tbl);
                }



                using (EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {

                    db.tblEQIW_R_Basedata_Pre_Auto.AddRange(list);

                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "保存成功！", "");
                }
                else
                {
                    result = rule.JsonStr("no", "保存失败！", "");
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "数据保存失败，" + e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 区县饮用水点位录入保存类
        /// </summary>
        public class eqiw_dsavedata
        {

            public string CheckCode { get; set; }

            /// <summary>
            /// 监测值数组
            /// </summary>
            public List<itemvalueData> fldItemData { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>

            public string EndDate { get; set; }

            /// <summary>
            /// 用户ID
            /// </summary>
            public string fldUserID { get; set; }

            /// <summary>
            /// 用户名
            /// </summary>
            public string fldUserName { get; set; }

            /// <summary>
            /// 操作城市id
            /// </summary>
            public string fldCityID_Operate { get; set; }

            /// <summary>
            /// 提交城市id
            /// </summary>
            public string fldCityID_Submit { get; set; }

            /// <summary>
            /// 城市代码
            /// </summary>
            public string fldSTCode { get; set; }

            /// <summary>
            /// 区县代码
            /// </summary>
            public string fldCountyCode { get; set; }

            /// <summary>
            /// 河流代码
            /// </summary>
            public string fldRCode { get; set; }


            /// <summary>
            ///断面代码
            /// </summary>
            public string fldRSCode { get; set; }

            /// <summary>
            /// 水期代码
            /// </summary>
            public string fldRSC { get; set; }

        }

        /// <summary>
        /// 因子值类
        /// </summary>
        public class itemvalueData
        {
            /// <summary>
            /// 因子代码
            /// </summary>
            public string itemcode { get; set; }

            /// <summary>
            /// 因子值
            /// </summary>

            public string itemvalue { get; set; }
        }



















































    }
}

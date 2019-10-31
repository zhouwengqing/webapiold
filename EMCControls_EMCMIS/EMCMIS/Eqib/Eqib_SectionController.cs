
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqib
{
    /// <summary>
    /// 功能描述    ：  获得生物测点信息
    /// 创建者      ：  吕荣誉
    /// 创建日期    ：  2017-8-22
    /// 修改者      ：   
    /// 修改日期    ：   
    /// 修改原因    ： 
    /// </summary>
    public class Eqib_SectionController : ApiController
    {


        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述    ：  获得生物测点信息
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
        /// <returns>返回生物测点信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage GetEqib_Section(string STCode, string strUserName, string strPLevel, int iInclude)
        {
            string result = string.Empty;
            try
            {

                RuletblEQIB_Section rule_point = new RuletblEQIB_Section();
                IList<tblEQIB_Section> list = rule_point.GetSTCodeOrPCode(STCode, strUserName, strPLevel, iInclude);
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
        public HttpResponseMessage GetEqib_Section_V2(string STCode)
        {
            string result = string.Empty;
            try
            {

                RuletblEQIB_Section rule_point = new RuletblEQIB_Section();
                IList<tblEQIB_Section> list = rule_point.GetDataAndSelfBySTCode(STCode);
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
        
        public HttpResponseMessage GetEqib_Section_RSCodeAndName(string STCode, string RCode)
        {
            string result = string.Empty;
            try
            {

                RuletblEQIB_Section rule_point = new RuletblEQIB_Section();
                IList<tblEQIB_Section> list = rule_point.GetRSCodeAndName(STCode, RCode);
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
        
        public HttpResponseMessage GetEqib_Section_GetRive(string stcode, string year)
        {
            string result = string.Empty;
            try
            {

                RuletblEQIB_Section rule_point = new RuletblEQIB_Section();
                IList<tblEQIB_Section> list = rule_point.getRive(stcode, year);
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
        
        public HttpResponseMessage GetEqib_Section_GetRSCodeByRCode(string stcode, string rcode, int year)
        {
            string result = string.Empty;
            try
            {

                RuletblEQIB_Section rule_point = new RuletblEQIB_Section();
                IList<tblEQIB_Section> list = rule_point.GetRSCodeByRCode(stcode, rcode, year);
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
        /// 功能描述    ：  获得地市饮用水测点信息
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-7-10
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年份</param>
        /// <param name="Level">级别</param>
        /// <returns></returns>
        [HttpGet]
        
        public HttpResponseMessage GetEqib_Section_GetByYearAndLevel(string STCode, int Year, short Level)
        {
            string result = string.Empty;
            try
            {

                RuletblEQIB_Section rule_point = new RuletblEQIB_Section();
                DataTable list = rule_point.GetByYearAndLevel(STCode, Year, Level);
                if (list != null && list.Rows.Count > 0)
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
        //
        public HttpResponseMessage GetEqib_Species(List<Info> Infos)
        {
            string result = string.Empty;
            List<ReturnInfo> ReturnInfos = new List<ReturnInfo>();
            try
            {
                using (EntityContext db = new EntityContext())
                {

                    if (Infos[0].type == "eqib_czp")
                    {
                        foreach (var item in Infos)
                        {
                            var query = from x in db.tblEQIBCZP_CategoryInfo
                                        where x.fldPCode == item.pcode && item.ctypecodes.Contains(x.fldCTypeCode)
                                        select x;
                            var query2 = (from x in query
                                          select new
                                          {
                                              PCode = x.fldPCode,
                                              PName = x.fldPName
                                          }).FirstOrDefault();
                            List<data> datas = new List<data>();
                            var query3 = from x in query
                                         select new data
                                         {
                                             ctypecode = x.fldCTypeCode,
                                             ctypename = x.fldCTypeName
                                         };
                            ReturnInfo returnInfo = new ReturnInfo
                            {
                                pcode = query2.PCode,
                                pname = query2.PName,
                                datas = query3.ToList()
                            };
                            ReturnInfos.Add(returnInfo);
                        }
                    }
                    else if (Infos[0].type == "eqib_czc")
                    {
                        foreach (var item in Infos)
                        {
                            var query = from x in db.tblEQIBCZC_CategoryInfo
                                        where x.fldPCode == item.pcode && item.ctypecodes.Contains(x.fldCTypeCode)
                                        select x;
                            var query2 = (from x in query
                                          select new
                                          {
                                              PCode = x.fldPCode,
                                              PName = x.fldPName
                                          }).FirstOrDefault();
                            List<data> datas = new List<data>();
                            var query3 = from x in query
                                         select new data
                                         {
                                             ctypecode = x.fldCTypeCode,
                                             ctypename = x.fldCTypeName
                                         };
                            ReturnInfo returnInfo = new ReturnInfo
                            {
                                pcode = query2.PCode,
                                pname = query2.PName,
                                datas = query3.ToList()
                            };
                            ReturnInfos.Add(returnInfo);
                        }
                    }
                    else if (Infos[0].type == "eqib_cd")
                    {
                        foreach (var item in Infos)
                        {
                            var query = from x in db.tblEQIBCD_CategoryInfo
                                        where x.fldPCode == item.pcode && item.ctypecodes.Contains(x.fldCTypeCode)
                                        select x;
                            var query2 = (from x in query
                                          select new
                                          {
                                              PCode = x.fldPCode,
                                              PName = x.fldPName
                                          }).FirstOrDefault();
                            List<data> datas = new List<data>();
                            var query3 = from x in query
                                         select new data
                                         {
                                             ctypecode = x.fldCTypeCode,
                                             ctypename = x.fldCTypeName
                                         };
                            ReturnInfo returnInfo = new ReturnInfo
                            {
                                pcode = query2.PCode,
                                pname = query2.PName,
                                datas = query3.ToList()
                            };
                            ReturnInfos.Add(returnInfo);
                        }
                    }
                    else if (Infos[0].type == "eqib_cwc")
                    {
                        foreach (var item in Infos)
                        {
                            var query = from x in db.tblEQIBCWC_CategoryInfo
                                        where x.fldPCode == item.pcode && item.ctypecodes.Contains(x.fldCTypeCode)
                                        select x;
                            var query2 = (from x in query
                                          select new
                                          {
                                              PCode = x.fldPCode,
                                              PName = x.fldPName
                                          }).FirstOrDefault();
                            List<data> datas = new List<data>();
                            var query3 = from x in query
                                         select new data
                                         {
                                             ctypecode = x.fldCTypeCode,
                                             ctypename = x.fldCTypeName
                                         };
                            ReturnInfo returnInfo = new ReturnInfo
                            {
                                pcode = query2.PCode,
                                pname = query2.PName,
                                datas = query3.ToList()
                            };
                            ReturnInfos.Add(returnInfo);
                        }
                    }
                    else if (Infos[0].type == "eqib_cwp")
                    {
                        foreach (var item in Infos)
                        {
                            var query = from x in db.tblEQIBCWP_CategoryInfo
                                        where x.fldPCode == item.pcode && item.ctypecodes.Contains(x.fldCTypeCode)
                                        select x;
                            var query2 = (from x in query
                                          select new
                                          {
                                              PCode = x.fldPCode,
                                              PName = x.fldPName
                                          }).FirstOrDefault();
                            List<data> datas = new List<data>();
                            var query3 = from x in query
                                         select new data
                                         {
                                             ctypecode = x.fldCTypeCode,
                                             ctypename = x.fldCTypeName
                                         };
                            ReturnInfo returnInfo = new ReturnInfo
                            {
                                pcode = query2.PCode,
                                pname = query2.PName,
                                datas = query3.ToList()
                            };
                            ReturnInfos.Add(returnInfo);
                        }
                    }



                }



                if (ReturnInfos != null && ReturnInfos.Count > 0)
                {
                    result = rule.JsonStr("ok", "", ReturnInfos);
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
        /// 接收实体参数
        /// </summary>
        public class Info
        {
            public string type { get; set; }

            public string pcode { get; set; }

            public List<string> ctypecodes { get; set; }
        }







        /// <summary>
        /// 返回实体参数
        /// </summary>
        public class ReturnInfo
        {
            public string pcode { get; set; }

            public string pname { get; set; }

            public List<data> datas { get; set; }
        }

        public class data
        {
            public string ctypecode { get; set; }

            public string ctypename { get; set; }

        }

    }
}

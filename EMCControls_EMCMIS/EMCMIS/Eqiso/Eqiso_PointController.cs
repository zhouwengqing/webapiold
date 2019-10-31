
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqiso
{
    /// <summary>
    /// 功能描述    ：  获得土壤测点信息
    /// 创建者      ：  吕荣誉
    /// 创建日期    ：  2017-8-17
    /// 修改者      ：   
    /// 修改日期    ：   
    /// 修改原因    ： 
    /// </summary>
    public class Eqiso_PointController : ApiController
    {




        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  获得土壤测点信息
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-8-17
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="fldYear">年份</param>
        /// <param name="Level">级别</param>
        /// <param name="include">是否包含上级</param>
        /// <returns>返回土壤测点信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage GetEqiso_Point(string STCode, int fldYear, short Level, int include, string datatype)
        {
            string result = string.Empty;
            try
            {

                RuletblEQISO_Point rule_point = new RuletblEQISO_Point();
                IList<tblEQISO_Point> list = rule_point.GetPCode(STCode, fldYear, Level, include, datatype);
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
        /// 功能描述    ：  根据[城市代码][企业代码][年份]获取测点名称和测点代码
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-7-10
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="entcode">企业代码</param>
        /// <param name="Year">年份</param>
        /// <returns>返回土壤测点信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage GetEqiso_Point_V2(string STCode, string entcode, int Year, string datatype)
        {
            string result = string.Empty;
            try
            {
                List<EMCCommon.Mode.tblEQISO_Point> list = new List<EMCCommon.Mode.tblEQISO_Point>();
                using (EMCCommon.Mode.EntityContext db = new EMCCommon.Mode.EntityContext())
                {

                    if (datatype == "1")
                    {
                        list = (from x in db.tblEQISO_Point
                                where x.fldSTCode == STCode &&
                                x.fldEntCode == entcode &&
                                x.fldYear == Year
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tblEQISO_Point
                                where x.fldSTCode.Contains(STCode.Substring(0, 4)) &&
                                x.fldEntCode == entcode &&
                                x.fldYear == Year
                                select x).ToList();
                    }



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
        /// 功能描述    ：  获得土壤城市和测点信息
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-07-06
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="pcode">测点代码</param>
        /// <param name="Year">年份</param>
        /// <returns>返回城市下所有的断面和河流</returns>
        [HttpGet]
        
        public HttpResponseMessage GetEqiso_PNameAndSTName(string pcode, int Year)
        {
            string result = string.Empty;
            try
            {
                RuletblEQISO_Point rule_section = new RuletblEQISO_Point();
                IList<tblEQISO_Point> list = rule_section.Getyearbystcodeandpcode(pcode, Year);

                if (list != null && list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有断面数据", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        /// 功能描述    ：  获得土壤县区测点信息
        /// 创建者      ：  熊瑞竹
        /// 创建日期    ：  2017-9-8
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="fldYear">年份</param>
        /// <returns>返回土壤县区测点信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage GetEqiso_County_Point(string STCode, int fldYear)
        {
            string result = string.Empty;
            try
            {

                RuletblEQISO_Point rule_point = new RuletblEQISO_Point();
                IList<tblEQISO_Point> list = rule_point.GetCountyPCode(STCode, fldYear);
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


    }
}

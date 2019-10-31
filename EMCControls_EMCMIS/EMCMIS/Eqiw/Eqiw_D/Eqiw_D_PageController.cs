using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Lap.Model;
using EMCControls_EMCMIS.EMCMIS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_D
{
    /// <summary>
    /// 功能描述：饮用水页面水源地基本信息
    /// 创建者  ：刘勇军
    /// 创建时间：2018-06-05
    /// </summary>
    public class Eqiw_D_PageController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：查询水源地基本信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-05
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns>水源地基本信息</returns>
        [HttpPost]
        public HttpResponseMessage GetWaterSource(WaterSourceInfo info)
        {
            string result = string.Empty;

            try
            {
                List<tblEQIW_D_Point_Details> list_Details = new List<tblEQIW_D_Point_Details>();
                List<tblEQIW_D_Point_Manage> list_Manage = new List<tblEQIW_D_Point_Manage>();
                List<tblEQIW_D_MonitorSection> list_Section = new List<tblEQIW_D_MonitorSection>();

                using (EntityContext db = new EntityContext())
                {
                    list_Details = (from x in db.tblEQIW_D_Point_Details
                                    select x).ToList();

                    list_Manage = (from x in db.tblEQIW_D_Point_Manage
                                    select x).ToList();

                    list_Section = (from x in db.tblEQIW_D_MonitorSection
                                    select x).ToList();

                    //根据水源地查询
                    if (info.fldSCategory != "" && info.fldSCategory != "全部") { 
                        list_Details = (from x in list_Details
                                    where x.fldSCategory == info.fldSCategory
                                    select x).ToList();
                    }

                    //根据使用状态查询
                    if (info.fldState != "")
                    {
                        list_Details = (from x in list_Details
                                        where x.fldState == int.Parse(info.fldState)
                                        select x).ToList();
                    }

                    //根据水源级别查询
                    if (info.fldLevel != "" && info.fldLevel != "全部")
                    {
                        list_Details = (from x in list_Details
                                        where x.fldLevel == info.fldLevel
                                        select x).ToList();
                    }

                    //根据所属区县查询
                    if (info.fldRSTown != "" && info.fldRSTown != "全部")
                    {
                        list_Details = (from x in list_Details
                                        where x.fldRSTown == info.fldRSTown
                                        select x).ToList();
                    }

                    //根据所属水系查询
                    if (info.fldWaterSys != "" && info.fldWaterSys != "全部")
                    {
                        list_Details = (from x in list_Details
                                        where x.fldFirstWaterSys == info.fldWaterSys
                                        select x).ToList();
                    }

                    //根据达标状态查询
                    if (info.fldStand != "")
                    {
                        list_Details = (from x in list_Details
                                        where x.fldStand == int.Parse(info.fldStand)
                                        select x).ToList();
                    }

                    //根据是否批复
                    if (info.fldReserveDelimit != "")
                    {
                        list_Manage = (from x in list_Manage
                                       where x.fldReserveDelimit == int.Parse(info.fldReserveDelimit)
                                       select x).ToList();
                    }

                    //根据断面名称模糊查询
                    if (info.fldSectionName != "")
                    {
                        list_Details = (from x in list_Details
                                        join y in list_Section
                                        on x.fldAutoID equals y.fldFKID
                                        where y.fldSectionName.Contains(info.fldSectionName)
                                        select x).ToList();
                    }

                    
                }

                string cityname = "";
                int cityid = 0;
                using (LAPContext db =new LAPContext())
                {
                    if (info.fldusrid !=0)
                    {
                      var dt=db.tblFW_User.Join(db.tblFW_RegCity,m=>m.fldCityID,f=>f.fldAutoID,(m,f)=>new {
                          m.fldCityID,
                          f.fldSTName,
                          m.fldAutoID
                      }).Where(e => e.fldAutoID ==info.fldusrid).ToList();
                        if (dt.Count > 0)
                        {
                            cityname = dt[0].fldSTName;
                            cityid = dt[0].fldCityID;
                        }
                    }
                }
                    var query = (from x in list_Details
                                 group x by x.fldAutoID
                                 into g
                                 select new
                                 {
                                     detaillist = g,
                                     Managelist = (from y in list_Manage where y.fldFKID == g.Key select y).FirstOrDefault()
                                 }).ToList();

                if(cityid!=0&&cityid != 2)
                {
                    query = (from x in list_Details.Where(f=>f.fldRSTown== cityname)
                             group x by x.fldAutoID
                                 into g
                             select new
                             {
                                 detaillist = g,
                                 Managelist = (from y in list_Manage where y.fldFKID == g.Key select y).FirstOrDefault()
                             }).ToList();
                }
                if (query.Count > 0) {
                    result = rule.JsonStr("ok", "", query);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 查询条件实体
        /// </summary>
        public class WaterSourceInfo
        {
            /// <summary>
            /// 水源地类型
            /// </summary>
            public string fldSCategory { get; set; }

            /// <summary>
            /// 使用状态
            /// </summary>
            public string fldState { get; set; }

            /// <summary>
            /// 水源级别
            /// </summary>
            public string fldLevel { get; set; }

            /// <summary>
            /// 所属区县
            /// </summary>
            public string fldRSTown { get; set; }

            /// <summary>
            /// 所属水系
            /// </summary>
            public string fldWaterSys { get; set; }

            /// <summary>
            /// 达标状态
            /// </summary>
            public string fldStand { get; set; }

            /// <summary>
            /// 断面名称
            /// </summary>
            public string fldSectionName { get; set;}

            /// <summary>
            /// 是否批复
            /// </summary>
            public string fldReserveDelimit { get; set; }

            /// <summary>
            /// 用户ID
            /// </summary>
            public int fldusrid { get; set; }
        }






        /// <summary>
        /// 功能描述：修改水源地基本信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-05
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns>修改列的实体</returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateWaterSource(GetUpdateWaterSourceInfo info)
        {
            string result = string.Empty;
            var ret = 0;
            try
            {
                tblEQIW_D_Point_Details detailsInfo = new tblEQIW_D_Point_Details();

                using (EntityContext db = new EntityContext())
                {
                    detailsInfo = (from x in db.tblEQIW_D_Point_Details
                                   where x.fldAutoID == info.fldAutoID
                                   select x).FirstOrDefault();

                    detailsInfo.fldWSCode = info.fldWSCode;
                    detailsInfo.fldWSName = info.fldWSName;
                    detailsInfo.fldAliasName = info.fldAliasName;
                    detailsInfo.fldSCategory = info.fldSCategory;
                    detailsInfo.fldState = short.Parse(info.fldState.ToString());
                    detailsInfo.fldLevel = info.fldLevel;
                    detailsInfo.fldRSTown = info.fldRSTown;
                    detailsInfo.fldAddress = info.fldAddress;
                    detailsInfo.fldLongitude = info.fldLongitude;
                    detailsInfo.fldLatitude = info.fldLatitude;
                    detailsInfo.fldSynopsis = info.fldSynopsis;
                    detailsInfo.fldFirstWaterSys = info.fldFirstWaterSys;
                    detailsInfo.fldSecondWaterSys = info.fldSecondWaterSys;
                    detailsInfo.fldThirdWaterSys = info.fldThirdWaterSys;
                    detailsInfo.fldProvideType = info.fldProvideType;
                    detailsInfo.fldStand = info.fldStand;
                    detailsInfo.fldServicePeople = info.fldServicePeople;
                    detailsInfo.fldSupplyWater = info.fldSupplyWater;
                    detailsInfo.fldDesignQuantity = info.fldDesignQuantity;
                    detailsInfo.fldActualQuantity = info.fldActualQuantity;
                    detailsInfo.fldBuildYear = info.fldBuildYear;

                    db.tblEQIW_D_Point_Details.AddOrUpdate(detailsInfo);
                    ret = db.SaveChanges();
                }

                if (ret <= 0)
                {
                    result = rule.JsonStr("error", "修改失败！", "");
                }
                else {
                    result = rule.JsonStr("ok", "", detailsInfo);
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：添加水源地基本信息
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-24
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns>修改列的实体</returns>
        [HttpPost]
        public HttpResponseMessage AddWaterSource(tblEQIW_D_Point_Details info)
        {
            string result = string.Empty;
            var ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_Point_Details.Add(info);
                    ret = db.SaveChanges();
                }

                if (ret <= 0)
                {
                    result = rule.JsonStr("error", "添加失败！", ret);
                }
                else
                {
                    result = rule.JsonStr("ok", "", info);
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 修改信息实体
        /// </summary>
        public class GetUpdateWaterSourceInfo
        {
            /// <summary>
            /// 水原ID
            /// </summary>
            public int fldAutoID { get; set; }


            /// <summary>
            /// 水原编码
            /// </summary>
            public string fldWSCode { get; set; }

            /// <summary>
            /// 水源名称
            /// </summary>
            public string fldWSName { get; set; }
            
            /// <summary>
            /// 别名
            /// </summary>
            public string fldAliasName { get; set; }

            /// <summary>
            /// 水源地类型
            /// </summary>
            public string fldSCategory { get; set; }

            /// <summary>
            /// 水源使用状态
            /// </summary>
            public int fldState { get; set; }

            /// <summary>
            /// 水源地级别
            /// </summary>
            public string fldLevel { get; set; }

            /// <summary>
            /// 所属区县
            /// </summary>          
            public string fldRSTown { get; set; }

            /// <summary>
            /// 水源地址
            /// </summary>
            public string fldAddress { get; set; }

            /// <summary>
            /// 经度
            /// </summary>
            public string fldLongitude { get; set; }

            /// <summary>
            /// 纬度
            /// </summary>
            public string fldLatitude { get; set; }

            /// <summary>
            /// 简介
            /// </summary>
            public string fldSynopsis { get; set; }

            /// <summary>
            /// 所属水系-干流
            /// </summary>
            public string fldFirstWaterSys { get; set; }

            /// <summary>
            /// 所属水系-二级水系
            /// </summary>
            public string fldSecondWaterSys { get; set; }

            /// <summary>
            /// 所属水系-三级水系
            /// </summary>
            public string fldThirdWaterSys { get; set; }

            /// <summary>
            /// 供水类型
            /// </summary>
            public string fldProvideType { get; set; }

            /// <summary>
            /// 本年度是否达标
            /// </summary>
            public int fldStand { get; set; }

            /// <summary>
            /// 服务人口
            /// </summary>
            public int fldServicePeople { get; set; }

            /// <summary>
            /// 日供水能力
            /// </summary>
            public int fldSupplyWater { get; set; }
            /// <summary>
            /// 设计取水量
            /// </summary>
            public int fldDesignQuantity { get; set; }

            /// <summary>
            /// 实际取水量
            /// </summary>
            public int fldActualQuantity { get; set; }

            /// <summary>
            /// 水源建成时间
            /// </summary>
            public string fldBuildYear { get; set; }
        }





        /// <summary>
        /// 功能描述：删除水源地基本信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-05
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns>删除列的实体</returns>
        [HttpPost]
        public HttpResponseMessage GetDeleteWaterSource(GetDeleteWaterSourceInfo info)
        {

            string result = string.Empty;
            var ret = 0;

            try
            {
                List<tblEQIW_D_Point_Details> detailsInfo = new List<tblEQIW_D_Point_Details>();

                using (EntityContext db = new EntityContext())
                {
                    detailsInfo = (from x in db.tblEQIW_D_Point_Details
                                   where x.fldAutoID == info.fldAutoID
                                   select x).ToList();

                    db.tblEQIW_D_Point_Details.RemoveRange(detailsInfo);
                    ret = db.SaveChanges();
                    if (ret > 0) {
                        List<tblEQIW_D_Waterworks> woInfo = new List<tblEQIW_D_Waterworks>();

                        woInfo = (from x in db.tblEQIW_D_Waterworks
                                  where x.fldFKID == detailsInfo[0].fldAutoID
                                  select x).ToList();

                        db.tblEQIW_D_Waterworks.RemoveRange(woInfo);
                        ret = db.SaveChanges();

                        if (ret > 0)
                        {
                            List<tblEQIW_D_WaterIntake> IntakeInfo = new List<tblEQIW_D_WaterIntake>();

                            IntakeInfo = (from x in db.tblEQIW_D_WaterIntake
                                      where x.fldFKID == detailsInfo[0].fldAutoID
                                      select x).ToList();

                            db.tblEQIW_D_WaterIntake.RemoveRange(IntakeInfo);
                            ret = db.SaveChanges();

                            if (ret > 0)
                            {
                                List<tblEQIW_D_MonitorSection> SectionInfo = new List<tblEQIW_D_MonitorSection>();

                                SectionInfo = (from x in db.tblEQIW_D_MonitorSection
                                              where x.fldFKID == detailsInfo[0].fldAutoID
                                              select x).ToList();

                                db.tblEQIW_D_MonitorSection.RemoveRange(SectionInfo);
                                ret = db.SaveChanges();
                            }
                        }

                    }
                    if (ret > 0)
                    {
                        result = rule.JsonStr("ok", "", detailsInfo);
                    }
                    else
                    {
                        result = rule.JsonStr("error", "删除失败！", "");
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
        /// 删除信息实体
        /// </summary>
        public class GetDeleteWaterSourceInfo
        {
            /// <summary>
            /// 水源ID
            /// </summary>
            public int fldAutoID { get; set; }
        }


        /// <summary>
        /// 功能描述：添加水源地基本信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-05
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddWaterSource(AddWaterSource_info info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                tblEQIW_D_Point_Details detailsInfo = new tblEQIW_D_Point_Details();
                using (EntityContext db = new EntityContext())
                {
                    detailsInfo.fldWSCode = info.fldWSCode;
                    detailsInfo.fldWSName = info.fldWSName;
                    detailsInfo.fldAliasName = info.fldAliasName;
                    detailsInfo.fldSCategory = info.fldSCategory;
                    detailsInfo.fldState = short.Parse(info.fldState.ToString());
                    detailsInfo.fldLevel = info.fldLevel;
                    detailsInfo.fldRSTown = info.fldRSTown;
                    detailsInfo.fldAddress = info.fldAddress;
                    detailsInfo.fldLongitude = info.fldLongitude;
                    detailsInfo.fldLatitude = info.fldLatitude;
                    detailsInfo.fldSynopsis = info.fldSynopsis;
                    detailsInfo.fldFirstWaterSys = info.fldFirstWaterSys;
                    detailsInfo.fldSecondWaterSys = info.fldSecondWaterSys;
                    detailsInfo.fldThirdWaterSys = info.fldThirdWaterSys;
                    detailsInfo.fldProvideType = info.fldProvideType;
                    detailsInfo.fldStand = info.fldStand;
                    detailsInfo.fldServicePeople = info.fldServicePeople;
                    detailsInfo.fldSupplyWater = info.fldSupplyWater;
                    detailsInfo.fldDesignQuantity = info.fldDesignQuantity;
                    detailsInfo.fldActualQuantity = info.fldActualQuantity;
                    detailsInfo.fldBuildYear = info.fldBuildYear;

                    db.tblEQIW_D_Point_Details.Add(detailsInfo);
                    ret = db.SaveChanges();
                }
                if (ret <= 0)
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }
                else
                {
                    result = rule.JsonStr("ok", "", detailsInfo);
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 监测断面实体
        /// </summary>
        public class AddWaterSource_info
        {
            /// <summary>
            /// 水原编码
            /// </summary>
            public string fldWSCode { get; set; }

            /// <summary>
            /// 水源名称
            /// </summary>
            public string fldWSName { get; set; }

            /// <summary>
            /// 别名
            /// </summary>
            public string fldAliasName { get; set; }

            /// <summary>
            /// 水源地类型
            /// </summary>
            public string fldSCategory { get; set; }

            /// <summary>
            /// 水源使用状态
            /// </summary>
            public int fldState { get; set; }

            /// <summary>
            /// 水源地级别
            /// </summary>
            public string fldLevel { get; set; }

            /// <summary>
            /// 所属区县
            /// </summary>          
            public string fldRSTown { get; set; }

            /// <summary>
            /// 水源地址
            /// </summary>
            public string fldAddress { get; set; }

            /// <summary>
            /// 经度
            /// </summary>
            public string fldLongitude { get; set; }

            /// <summary>
            /// 纬度
            /// </summary>
            public string fldLatitude { get; set; }

            /// <summary>
            /// 简介
            /// </summary>
            public string fldSynopsis { get; set; }

            /// <summary>
            /// 所属水系-干流
            /// </summary>
            public string fldFirstWaterSys { get; set; }

            /// <summary>
            /// 所属水系-二级水系
            /// </summary>
            public string fldSecondWaterSys { get; set; }

            /// <summary>
            /// 所属水系-三级水系
            /// </summary>
            public string fldThirdWaterSys { get; set; }

            /// <summary>
            /// 供水类型
            /// </summary>
            public string fldProvideType { get; set; }

            /// <summary>
            /// 本年度是否达标
            /// </summary>
            public int fldStand { get; set; }

            /// <summary>
            /// 服务人口
            /// </summary>
            public int fldServicePeople { get; set; }

            /// <summary>
            /// 日供水能力
            /// </summary>
            public int fldSupplyWater { get; set; }
            /// <summary>
            /// 设计取水量
            /// </summary>
            public int fldDesignQuantity { get; set; }

            /// <summary>
            /// 实际取水量
            /// </summary>
            public int fldActualQuantity { get; set; }

            /// <summary>
            /// 水源建成时间
            /// </summary>
            public string fldBuildYear { get; set; }
        }
    }
}

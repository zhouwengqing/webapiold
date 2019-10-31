using DDYZ.Ensis.Rule.DataRule;
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
    /// 功能描述：饮用水点位管理信息
    /// 创建者  ：刘勇军
    /// 创建时间：2018-06-07
    /// </summary>
    public class Eqiw_D_Point_ManageController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：查询点位管理信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetEqiw_D_Point_Manage(GetEqiw_D_Point_Manage_Info info)
        {
            string result = string.Empty;

            try
            {
                tblEQIW_D_Point_Manage manageInfo = new tblEQIW_D_Point_Manage();
                List<tblEQIW_D_WarningSign> warnlist = new List<tblEQIW_D_WarningSign>();
                List<tblEQIW_D_Billboard> billList = new List<tblEQIW_D_Billboard>();
                List<tblEQIW_D_BoundaryMarkers> markerlist = new List<tblEQIW_D_BoundaryMarkers>();
                List<tblEQIW_D_SeineFence> seinelist = new List<tblEQIW_D_SeineFence>();
                List<tblEQIW_D_VideoSurveillance> videolist = new List<tblEQIW_D_VideoSurveillance>();
                List<tblEQIW_D_FirstProtectionZones> firstlist = new List<tblEQIW_D_FirstProtectionZones>();
                List<tblEQIW_D_SecondProtectionZones> secondlist = new List<tblEQIW_D_SecondProtectionZones>();
                List<tblEQIW_D_ReadyProtectionZones> readylist = new List<tblEQIW_D_ReadyProtectionZones>();
                List<tblEQIW_D_RiskSource> risklist = new List<tblEQIW_D_RiskSource>();
                List<tblEQIW_D_EarlyWarningSection> sectionlist = new List<tblEQIW_D_EarlyWarningSection>();

                ReturnEqiw_D_Point_Manage_Info returnInfo = new ReturnEqiw_D_Point_Manage_Info();

                using (EntityContext db = new EntityContext())
                {
                    manageInfo = (from x in db.tblEQIW_D_Point_Manage
                                  where x.fldFKID == info.fldFKID
                                  select x).FirstOrDefault();

                    warnlist = (from x in db.tblEQIW_D_WarningSign
                                where x.fldFKID == info.fldFKID
                                select x).ToList();

                    billList = (from x in db.tblEQIW_D_Billboard
                                where x.fldFKID == info.fldFKID
                                select x).ToList();

                    markerlist = (from x in db.tblEQIW_D_BoundaryMarkers
                                  where x.fldFKID == info.fldFKID
                                  select x).ToList();

                    seinelist = (from x in db.tblEQIW_D_SeineFence
                                 where x.fldFKID == info.fldFKID
                                 select x).ToList();

                    videolist = (from x in db.tblEQIW_D_VideoSurveillance
                                 where x.fldFKID == info.fldFKID
                                 select x).ToList();

                    firstlist = (from x in db.tblEQIW_D_FirstProtectionZones
                                 where x.fldFKID == info.fldFKID
                                 select x).ToList();

                    secondlist = (from x in db.tblEQIW_D_SecondProtectionZones
                                  where x.fldFKID == info.fldFKID
                                  select x).ToList();

                    readylist = (from x in db.tblEQIW_D_ReadyProtectionZones
                                 where x.fldFKID == info.fldFKID
                                 select x).ToList();

                    risklist = (from x in db.tblEQIW_D_RiskSource
                                where x.fldFKID == info.fldFKID
                                select x).ToList();

                    sectionlist = (from x in db.tblEQIW_D_EarlyWarningSection
                                   where x.fldFKID == info.fldFKID
                                   select x).ToList();
                }

                returnInfo.maInfo = manageInfo;
                returnInfo.listWarn = warnlist;
                returnInfo.listBill = billList;
                returnInfo.listMarker = markerlist;
                returnInfo.listSeine = seinelist;
                returnInfo.listVideo = videolist;
                returnInfo.listFirst = firstlist;
                returnInfo.listSecond = secondlist;
                returnInfo.listReady = readylist;
                returnInfo.listRisk = risklist;
                returnInfo.listSection = sectionlist;

                if (manageInfo != null)
                {
                    result = rule.JsonStr("ok", "", returnInfo);
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
        /// 实体参数
        /// </summary>
        public class GetEqiw_D_Point_Manage_Info
        {
            /// <summary>
            /// 外键
            /// </summary>
            public int fldFKID { get; set; }
        }

        /// <summary>
        /// 返回实体
        /// </summary>
        public class ReturnEqiw_D_Point_Manage_Info
        {
            public tblEQIW_D_Point_Manage maInfo { get; set; }

            public List<tblEQIW_D_WarningSign> listWarn { get; set; }

            public List<tblEQIW_D_Billboard> listBill { get; set; }

            public List<tblEQIW_D_BoundaryMarkers> listMarker { get; set; }

            public List<tblEQIW_D_SeineFence> listSeine { get; set; }

            public List<tblEQIW_D_VideoSurveillance> listVideo { get; set; }

            public List<tblEQIW_D_FirstProtectionZones> listFirst { get; set; }

            public List<tblEQIW_D_SecondProtectionZones> listSecond { get; set; }

            public List<tblEQIW_D_ReadyProtectionZones> listReady { get; set; }

            public List<tblEQIW_D_RiskSource> listRisk { get; set; }

            public List<tblEQIW_D_EarlyWarningSection> listSection { get; set; }
        }






        /// <summary>
        /// 功能描述：修改点位管理信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateEqiw_D_Point_Manage(List<tblEQIW_D_Point_Manage> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {

                    db.tblEQIW_D_Point_Manage.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "修改失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }







        /// <summary>
        /// 功能描述：修改警示牌
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateWarningSign(List<tblEQIW_D_WarningSign> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db=new EntityContext())
                {
                    db.tblEQIW_D_WarningSign.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret>0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "修改失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

       







        /// <summary>
        /// 功能描述：修改宣传牌
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateBillboard(List<tblEQIW_D_Billboard> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_Billboard.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "修改失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }





        /// <summary>
        /// 功能描述：修改界碑界桩
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateBoundaryMarkers(List<tblEQIW_D_BoundaryMarkers> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_BoundaryMarkers.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "修改失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }







        /// <summary>
        /// 功能描述：修改围栏围网
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateSeineFence(List<tblEQIW_D_SeineFence> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_SeineFence.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "修改失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }
        
   


        /// <summary>
        /// 功能描述：修改视频监控
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateVideoSurveillance(List<tblEQIW_D_VideoSurveillance> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_VideoSurveillance.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "修改失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

 




        /// <summary>
        /// 功能描述：修改一级保护区
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateFirstProtectionZones(List<tblEQIW_D_FirstProtectionZones> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_FirstProtectionZones.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "修改失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }






        /// <summary>
        /// 功能描述：修改二级保护区
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateSecondProtectionZones(List<tblEQIW_D_SecondProtectionZones> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_SecondProtectionZones.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "修改失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

      


        /// <summary>
        /// 功能描述：修改准备保护区
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07 
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateReadyProtectionZones(List<tblEQIW_D_ReadyProtectionZones> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_ReadyProtectionZones.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "修改失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        






        /// <summary>
        /// 功能描述：修改风险源（上游/补给区）
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07 
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateRiskSource(List<tblEQIW_D_RiskSource> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_RiskSource.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "修改失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        




        /// <summary>
        /// 功能描述：修改预警监控断面
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07 
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateEarlyWarningSection(List<tblEQIW_D_EarlyWarningSection> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_EarlyWarningSection.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "修改失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

     







        /// <summary>
        /// 功能描述：添加点位管理信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddEqiw_D_Point_Manage(List<tblEQIW_D_Point_Manage> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_Point_Manage.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：删除点位管理信息
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelEqiw_D_Point_Manage(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_Point_Manage.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_Point_Manage.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "", dt);
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
        /// 功能描述：添加警示牌
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddWarningSign(List<tblEQIW_D_WarningSign> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_WarningSign.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：删除警示牌
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelWarningSign(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_WarningSign.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_WarningSign.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "", dt);
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
        /// 功能描述：添加宣传牌
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddBillboard(List<tblEQIW_D_Billboard> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_Billboard.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：删除宣传牌
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelBillboard(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_Billboard.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_Billboard.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "", dt);
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
        /// 功能描述：添加界碑界桩
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddBoundaryMarkers(List<tblEQIW_D_BoundaryMarkers> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                tblEQIW_D_BoundaryMarkers MarkerInfo = new tblEQIW_D_BoundaryMarkers();

                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_BoundaryMarkers.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：删除界碑界桩
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelBoundaryMarkers(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_BoundaryMarkers.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_BoundaryMarkers.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "", dt);
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
        /// 功能描述：添加围栏围网
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddSeineFence(List<tblEQIW_D_SeineFence> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_SeineFence.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：删除围栏围网
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelSeineFence(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_SeineFence.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_SeineFence.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "", dt);
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
        /// 功能描述：添加视频监控
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddVideoSurveillance(List<tblEQIW_D_VideoSurveillance> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {

                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_VideoSurveillance.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        /// 功能描述：删除视频监控
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelVideoSurveillance(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_VideoSurveillance.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_VideoSurveillance.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "", dt);
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
        /// 功能描述：添加一级保护区
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddFirstProtectionZones(List<tblEQIW_D_FirstProtectionZones> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                tblEQIW_D_FirstProtectionZones FirstInfo = new tblEQIW_D_FirstProtectionZones();

                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_FirstProtectionZones.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        /// 功能描述：删除一级保护区
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelFirstProtectionZones(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_FirstProtectionZones.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_FirstProtectionZones.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "", dt);
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
        /// 功能描述：添加二级保护区
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddSecondProtectionZones(List<tblEQIW_D_SecondProtectionZones> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_SecondProtectionZones.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：删除二级保护区
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelSecondProtectionZones(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_SecondProtectionZones.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_SecondProtectionZones.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "", dt);
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
        /// 功能描述：添加准备保护区
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07 
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddReadyProtectionZones(List<tblEQIW_D_ReadyProtectionZones> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_ReadyProtectionZones.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：删除准备保护区
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelReadyProtectionZones(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_ReadyProtectionZones.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_ReadyProtectionZones.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "", dt);
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
        /// 功能描述：添加风险源（上游/补给区）
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07 
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddRiskSource(List<tblEQIW_D_RiskSource> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_RiskSource.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：删除风险源（上游/补给区）
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelRiskSource(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_RiskSource.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_RiskSource.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "", dt);
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
        /// 功能描述：添加 预警监控断面
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07 
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddEarlyWarningSection(List<tblEQIW_D_EarlyWarningSection> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_EarlyWarningSection.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret > 0)
                {
                    result = rule.JsonStr("ok", "", info);
                }
                else
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：删除预警监控断面
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelEarlyWarningSection(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_EarlyWarningSection.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_EarlyWarningSection.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "", dt);
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

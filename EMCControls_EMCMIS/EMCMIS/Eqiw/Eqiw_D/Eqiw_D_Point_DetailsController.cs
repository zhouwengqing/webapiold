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
    /// 功能描述：饮用水点位基本信息
    /// 创建者  ：刘勇军
    /// 创建时间：2018-06-06
    /// </summary>
    public class Eqiw_D_Point_DetailsController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：查询点位基本信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-06
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetEQIW_D_Point_Details(GetEQIW_D_Point_DetailsInfo info)
        {
            string result = string.Empty;

            try
            {
                tblEQIW_D_Point_Details list_Details = new tblEQIW_D_Point_Details();
                List<tblEQIW_D_Waterworks> list_Works = new List<tblEQIW_D_Waterworks>();
                List<tblEQIW_D_WaterIntake> list_Intake = new List<tblEQIW_D_WaterIntake>();
                List<tblEQIW_D_MonitorSection> list_Section = new List<tblEQIW_D_MonitorSection>();
                RetuenEQIW_D_Point_Details return_list = new RetuenEQIW_D_Point_Details();
                using (EntityContext db=new EntityContext())
                {
                    list_Details = (from x in db.tblEQIW_D_Point_Details
                                    where x.fldAutoID == info.fldAutoID
                                    select x).FirstOrDefault();

                    if (list_Details != null)
                    {
                        list_Works = (from x in db.tblEQIW_D_Waterworks
                                      where x.fldFKID == list_Details.fldAutoID
                                      select x).ToList();

                        list_Intake = (from x in db.tblEQIW_D_WaterIntake
                                       where x.fldFKID == list_Details.fldAutoID
                                       select x).ToList();

                        list_Section = (from x in db.tblEQIW_D_MonitorSection
                                        where x.fldFKID == list_Details.fldAutoID
                                        select x).ToList();
                    }
                }

                return_list.deInfo = list_Details;
                return_list.woList = list_Works;
                return_list.inList = list_Intake;
                return_list.seList = list_Section;

                if (list_Details != null)
                {
                    result = rule.JsonStr("ok", "", return_list);
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
        /// 点位基本信息实体
        /// </summary>
        public class GetEQIW_D_Point_DetailsInfo
        {
            /// <summary>
            /// 水原ID
            /// </summary>
            public int fldAutoID { get; set; }
        }

        /// <summary>
        /// 返回参数
        /// </summary>
        public class RetuenEQIW_D_Point_Details
        {
            /// <summary>
            /// 基本信息实体
            /// </summary>
            public tblEQIW_D_Point_Details deInfo { get; set; }

            /// <summary>
            /// 取水口集合
            /// </summary>
            public List<tblEQIW_D_WaterIntake> inList { get; set; }

            /// <summary>
            /// 对应水厂集合
            /// </summary>
            public List<tblEQIW_D_Waterworks> woList { get; set; }

            /// <summary>
            /// 监测断面集合
            /// </summary>
            public List<tblEQIW_D_MonitorSection> seList { get; set; }
        }




        /// <summary>
        /// 功能描述：修改对应水厂
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-06
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateWaterworks(List<tblEQIW_D_Waterworks> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db=new EntityContext())
                {
                    db.tblEQIW_D_Waterworks.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret <= 0)
                {
                    result = rule.JsonStr("error", "修改失败！", "");
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
        /// 功能描述：修改取水口
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-06
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateWaterIntake(List<tblEQIW_D_WaterIntake> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_WaterIntake.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret <= 0)
                {
                    result = rule.JsonStr("error", "修改失败！", "");
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
        /// 功能描述：修改监测断面
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-06
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateMonitorSection(List<tblEQIW_D_MonitorSection> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_MonitorSection.AddOrUpdate(info.ToArray());
                    ret = db.SaveChanges();
                }
                if (ret <= 0)
                {
                    result = rule.JsonStr("error", "修改失败！", "");
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
        /// 功能描述：添加对应水厂
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-06
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddWaterworks(List<tblEQIW_D_Waterworks> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_Waterworks.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret <= 0)
                {
                    result = rule.JsonStr("error", "添加失败！", "");
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
        /// 功能描述：删除对应水厂
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelWaterworks(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_Waterworks.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_Waterworks.RemoveRange(dt);
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
        /// 功能描述：添加取水口
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-06
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddWaterIntake(List<tblEQIW_D_WaterIntake> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_WaterIntake.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret <= 0)
                {
                    result = rule.JsonStr("error", "添加失败！", "");
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
        /// 功能描述：删除取水口
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelWaterIntake(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                  var dt=db.tblEQIW_D_WaterIntake.Where(e=>e.fldAutoID==id);
                    db.tblEQIW_D_WaterIntake.RemoveRange(dt);
                   int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "删除成功！", db);
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
        /// 功能描述：添加监测断面
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-06
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddMonitorSection(List<tblEQIW_D_MonitorSection> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_MonitorSection.AddRange(info);
                    ret = db.SaveChanges();
                }
                if (ret <= 0)
                {
                    result = rule.JsonStr("error", "添加失败！", "");
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
        /// 功能描述：删除监测断面
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelMonitorSection(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_MonitorSection.Where(e => e.fldAutoID == id).ToList();
                    db.tblEQIW_D_MonitorSection.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没查到该数据", "");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "删除成功！", dt);
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

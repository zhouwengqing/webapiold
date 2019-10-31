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
    /// 功能描述：饮用水点位应急信息
    /// 创建者  ：刘勇军
    /// 创建时间：2018-06-07
    /// </summary>
    public class Eqiw_D_Point_EmergencyController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：查询点位应急信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetEqiw_D_Point_Emergency(Eqiw_D_Point_Emergency_Info info)
        {
            string result = string.Empty;

            try
            {
                tblEQIW_D_Point_Emergency emInfo = new tblEQIW_D_Point_Emergency();
                List<tblEQIW_D_TrafficPoint> Trafficlist = new List<tblEQIW_D_TrafficPoint>();
                ReturnEqiw_D_Point_Emergency_Info return_list = new ReturnEqiw_D_Point_Emergency_Info();

                using (EntityContext db=new EntityContext())
                {
                    emInfo = (from x in db.tblEQIW_D_Point_Emergency
                              where x.fldFKID == info.fldFKID
                              select x).FirstOrDefault();

                        Trafficlist = (from x in db.tblEQIW_D_TrafficPoint
                                       where x.fldFKID == info.fldFKID
                                       select x).ToList();
                }
                return_list.emerInfo = emInfo;
                return_list.listTra = Trafficlist;

                if (emInfo != null)
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
        /// 参数实体
        /// </summary>
        public class Eqiw_D_Point_Emergency_Info
        {
            public int fldFKID { get; set; }
        }

        /// <summary>
        /// 返回参数
        /// </summary>
        public class ReturnEqiw_D_Point_Emergency_Info
        {
            public tblEQIW_D_Point_Emergency emerInfo { get; set; }

            public List<tblEQIW_D_TrafficPoint> listTra { get; set; }
        }






        /// <summary>
        /// 功能描述：修改点位应急信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdatePoint_Emergency(List<tblEQIW_D_Point_Emergency> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {

                using (EntityContext db=new EntityContext())
                {
                    db.tblEQIW_D_Point_Emergency.AddOrUpdate(info.ToArray());
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
        /// 功能描述：修改交通穿越点
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07 
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetUpdateTrafficPoint(List<tblEQIW_D_TrafficPoint> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_TrafficPoint.AddOrUpdate(info.ToArray());
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
        /// 功能描述：添加点位应急信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddPoint_Emergency(List<tblEQIW_D_Point_Emergency> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {

                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_Point_Emergency.AddRange(info);
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
        /// 功能描述：添加交通穿越点
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddTrafficPoint(List<tblEQIW_D_TrafficPoint> info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_D_TrafficPoint.AddRange(info);
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
        /// 功能描述：删除交通穿越点
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelTrafficPoint(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_TrafficPoint.Where(e => e.fldAutoID == id);
                    db.tblEQIW_D_TrafficPoint.RemoveRange(dt);
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

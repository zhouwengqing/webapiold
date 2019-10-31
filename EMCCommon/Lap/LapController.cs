using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Lap.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCCommon.Lap
{
    public class LapController : ApiController
    {


        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：查询
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-27
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Query_tblFWContact(Query_tblFWContact_Info info)
        {
            string result = string.Empty;
            List<tblFWContact> list = new List<tblFWContact>();
            try
            {

                using (LAPContext db = new LAPContext())
                {
                    if (info.fldSTName == null || info.fldName == null)
                    {
                        list = (from x in db.tblFWContact
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.tblFWContact
                                where x.fldSTName == info.fldSTName &&
                                x.fldName == info.fldName
                                select x).ToList();
                    }
                }

                if (list.Count() > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Query_tblFWContact_Info
        {
            public string fldSTName { get; set; }

            public string fldName { get; set; }
        }

























        /// <summary>
        /// 功能描述：新建
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-27
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddOrUpdate_tblFWContact(AddOrUpdate_tblFWContact_Info info)
        {
            string result = string.Empty;
            tblFWContact wc = new tblFWContact();
            int result2 = 0;
            try
            {
                using (LAPContext db = new LAPContext())
                {
                    wc.fldAutoID = info.fldAutoID;
                    wc.fldSTName = info.fldSTName;
                    wc.fldName = info.fldName;
                    wc.fldTittle = info.fldTittle;
                    wc.fldWork = info.fldWork;
                    wc.fldTel = info.fldTel;
                    wc.fldQQ = info.fldQQ;
                    wc.fldRemark = info.fldRemark;

                    db.tblFWContact.AddOrUpdate(wc);

                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", "新建成功！ID为：" + wc.fldAutoID);
                }
                else
                {
                    result = rule.JsonStr("nodata", "未知错误！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class AddOrUpdate_tblFWContact_Info
        {
            public int fldAutoID { get; set; }

            public string fldSTName { get; set; }

            public string fldName { get; set; }

            public string fldTittle { get; set; }

            public string fldWork { get; set; }

            public string fldTel { get; set; }

            public string fldQQ { get; set; }

            public string fldRemark { get; set; }
        }










        /// <summary>
        /// 功能描述：删除
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-1-27
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Delete_tblFWContact(Delete_tblFWContact_Info info)
        {
            string result = string.Empty;
            List<tblFWContact> list = new List<tblFWContact>();
            int result2 = 0;

            try
            {
                using (LAPContext db = new LAPContext())
                {
                    list = (from x in db.tblFWContact
                            where info.IDList.Contains(x.fldAutoID)
                            select x).ToList();

                    db.tblFWContact.RemoveRange(list);
                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "", "删除了" + result2 + "条数据");
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有可删除的数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Delete_tblFWContact_Info
        {
            public List<int> IDList { get; set; }
        }






    }
}

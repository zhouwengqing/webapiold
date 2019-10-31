using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCCommon.Common
{
    public class Cache_SetupController : ApiController
    {

        RuleCommon rule = new RuleCommon();



        [HttpPost]
        public HttpResponseMessage Query_Cache_Setup_List(Query_Cache_Setup_List_Info info)
        {
            string result = string.Empty;
            try
            {
                List<Cache_Setup> list = new List<Cache_Setup>();


                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.Cache_Setup
                            select x).ToList();
                }


                if (list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据！", list);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        public class Query_Cache_Setup_List_Info
        {
        }












        [HttpPost]
        public HttpResponseMessage AddOrUpdate_Cache_Setup_List(AddOrUpdate_Cache_Setup_List_Info info)
        {
            string result = string.Empty;
            int count = 0;
            try
            {
                Cache_Setup cs = new Cache_Setup();
                cs.fldAutoID = info.fldAutoID;
                cs.fldObject = info.fldObject;
                cs.fldTimeType = info.fldTimeType;
                cs.fldType = info.fldType;
                cs.fldName = info.fldName;
                cs.fldGroupName = info.fldGroupName;
                cs.fldUserID = info.fldUserID;
                cs.fldPointContent = info.fldPointContent;
                cs.fldItemContent = info.fldItemContent;


                using (EntityContext db = new EntityContext())
                {
                    db.Cache_Setup.AddOrUpdate(cs);
                    count = db.SaveChanges();
                }


                if (count > 0)
                {
                    result = rule.JsonStr("ok", "", cs);
                }
                else
                {
                    result = rule.JsonStr("nodata", "未更新数据！", cs);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        public class AddOrUpdate_Cache_Setup_List_Info
        {
            public int fldAutoID { get; set; }

            public string fldObject { get; set; }

            public string fldTimeType { get; set; }

            public int fldType { get; set; }

            public string fldName { get; set; }

            public string fldGroupName { get; set; }

            public int fldUserID { get; set; }

            public string fldPointContent { get; set; }

            public string fldItemContent { get; set; }
        }













        [HttpPost]
        public HttpResponseMessage Delete_Cache_Setup_List(Delete_Cache_Setup_List_Info info)
        {
            string result = string.Empty;
            int count = 0;
            try
            {
                List<Cache_Setup> list = new List<Cache_Setup>();

                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.Cache_Setup
                            where info.IDList.Contains(x.fldAutoID)
                            select x).ToList();

                    db.Cache_Setup.RemoveRange(list);
                    count = db.SaveChanges();
                }

                if (count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "未更新数据！", list);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        public class Delete_Cache_Setup_List_Info
        {
            public List<int> IDList { get; set; }
        }



    }
}

using System;
using System.Net.Http;
using System.Web.Http;
using DDYZ.Ensis.Rule.DataRule;
using DDYZ.Ensis.Presistence.DataEntity;
using System.Linq;


namespace EMCCommon.Common
{
    /// <summary>
    /// 针对tblEQI_Point_Group表的操作
    /// </summary>
    public class PiontGroupController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：新增组合
        /// 创建  人：周文卿
        /// 创建时间：2017/06/07
        /// 修改时间：
        /// 修改  人：
        /// 修改原因：
        /// </summary>
        /// <param name="obj">动态参数(fldName:组合名称,fldObject:业务类别,fldUserID:用户ID（没有ID，传-1直接插入）,fldYear(时间（备用）,fldType（备用参数）)</param>
        /// <returns>json（status(状态),msg(提示信息),data（为-1时存在相同名称的组合，成功返回插入的ID））</returns>

        //[SupportFilter]
        [HttpPost]
        public HttpResponseMessage addGroup(dynamic obj)
        {
            string returntxt = "";
            try
            {
                tblEQI_Point_Group point_group = new tblEQI_Point_Group();
                point_group.fldName = obj.fldName;
                point_group.fldObject = obj.fldObject;
                point_group.fldUserID = obj.fldUserID;
                point_group.fldYear = obj.fldYear;
                point_group.fldPointContent = obj.fldPointContent;
                point_group.fldType = obj.fldType;
                RuletblEQI_Point_Group rule_group = new RuletblEQI_Point_Group();
                int returnID = rule_group.Insert(point_group);
                if (returnID == -1)
                {
                    returntxt = rule.JsonStr("no", "相同名称的分组已经存在,请输入其它名称", returnID);
                }
                if (returnID > 0)
                {
                    returntxt = rule.JsonStr("ok", "添加成功！", returnID);
                }
                if (returnID < 0 && returnID != -1)
                {
                    returntxt = rule.JsonStr("error", "添加失败！", 0);
                }
            }
            catch (Exception e)
            {
                returntxt = rule.JsonStr("error", e.Message, 0);
            }
            return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：更新组件
        /// 创建  人：周文卿
        /// 创建时间：2017/06/07
        /// 修改时间：
        /// 修改  人：
        /// 修改原因：
        /// </summary>
        /// <param name="obj">动态参数(id:要更新的组合ID,fldName:组合名称,fldObject:业务类别,fldUserID:用户ID(若无ID，直接更新为-1),fldYear(时间（备用）,fldType（备用参数）)</param>
        /// <returns>json（status(状态),msg(提示信息),data()</returns>
        /// 
        //[SupportFilter]
        [HttpPost]
        public HttpResponseMessage UpdateGroup(dynamic obj)
        {
            string returntxt = "";
            try
            {

                RuletblEQI_Point_Group rule_group = new RuletblEQI_Point_Group();
                tblEQI_Point_Group objObject_old = rule_group.ByPK(int.Parse(obj.id.ToString()));
                tblEQI_Point_Group objObject_new = new tblEQI_Point_Group();
                objObject_new.fldObject = obj.fldObject;
                objObject_new.fldUserID = objObject_old.fldUserID;
                objObject_new.fldName = objObject_old.fldName;
                objObject_new.fldYear = obj.fldYear;
                objObject_new.fldPointContent = obj.fldPointContent;
                objObject_new.fldType = obj.fldType;
                bool isdelete = rule_group.Update(objObject_old, objObject_new);
                if (isdelete)
                {
                    returntxt = rule.JsonStr("ok", "更新成功！", "");
                }
                else
                {
                    returntxt = rule.JsonStr("error", "更新失败！", "");
                }
            }
            catch (Exception e)
            {
                returntxt = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：删除组合
        /// 创建时间：2017/06/08
        /// 创建  人：周文卿
        /// 修改时间：
        /// 修改  人：
        /// </summary>
        /// <param name="id">要删除的ID</param>
        /// <returns>json（status(状态),msg(提示信息),data()</returns>
        /// 
        //[SupportFilter]
        [HttpGet]
        public HttpResponseMessage DeleteGroup(string id)
        {
            string returntxt = "";
            try
            {
                RuletblEQI_Point_Group rule_group = new RuletblEQI_Point_Group();
                bool isdelete = rule_group.Delete(Convert.ToInt32(id));
                if (isdelete)
                {
                    returntxt = rule.JsonStr("ok", "删除成功！", "");
                }
                else
                {
                    returntxt = rule.JsonStr("error", "删除失败！", "");
                }
            }
            catch (Exception e)
            {
                returntxt = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
        }






















        [HttpPost]
        public HttpResponseMessage PointGroupRename(PointGroupRename_Info info)
        {
            string result = string.Empty;
            try
            {
                using (Mode.EntityContext db = new Mode.EntityContext())
                {
                    var query = (from x in db.tblEQI_Point_Group
                                 where x.fldAutoID == info.fldAutoID
                                 select x).FirstOrDefault();

                    if (query != null)
                    {
                        query.fldName = info.fldName;
                        int count = db.SaveChanges();

                        result = rule.JsonStr("ok", "", count);

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




        public class PointGroupRename_Info
        {
            public int fldAutoID { get; set; }

            public string fldName { get; set; }
        }






















    }
}

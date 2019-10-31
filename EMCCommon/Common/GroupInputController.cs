using System;
using System.Net.Http;
using System.Web.Http;
using DDYZ.Ensis.Rule.DataRule;
using DDYZ.Ensis.Presistence.DataEntity;

using DDYZ.Ensis.Library.Exception.DataRule;

namespace EMCCommon.Common
{
    /// <summary>
    /// 功能描述：录入点位相关操作
    /// 创建  人：周文卿
    /// 创建时间：2017/07/05
    /// 修改时间：
    /// 修改  人：
    /// 修改原因：
    /// </summary>
    public class GroupInputController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：新增组合
        /// 创建  人：周文卿
        /// 创建时间：2017/07/05
        /// 修改原因：
        /// 修改时间：
        /// 修改  人：
        /// </summary>
        /// <param name="gname">组合名称</param>
        /// <param name="itemcontent">点位</param>
        /// <param name="fldobject">业务类别</param>
        /// <param name="UserID">用户ID，没有给-1</param>
        /// <returns></returns>
        public HttpResponseMessage addGroup(string gname, string itemcontent, string fldobject, string UserID)
        {
            string returntxt = "";
            if (string.IsNullOrEmpty(gname))
            {
                returntxt = rule.JsonStr("error", "缺少保存的名称", "");
            }
            else if (string.IsNullOrEmpty(itemcontent))
            {
                returntxt = rule.JsonStr("error", "缺少点位", "");
            }
            else if (string.IsNullOrEmpty(fldobject))
            {
                returntxt = rule.JsonStr("error", "缺少点位", "");
            }
            else
            {
                try
                {
                    tblEQI_Item_Group item_group = new tblEQI_Item_Group();
                    item_group.fldName = gname;
                    item_group.fldObject = itemcontent;
                    item_group.fldUserID = int.Parse(UserID);
                    item_group.fldItemContent = fldobject;
                    RuletblEQI_Item_Group rule_group = new RuletblEQI_Item_Group();
                    int returnID = rule_group.Insert(item_group);
                    if (returnID > 0)
                    {
                        returntxt = rule.JsonStr("ok", "保存组成功！", "");
                    }
                }
                catch (InsertPKException ex)
                {
                    returntxt = rule.JsonStr("error", "已存在相同名称的组合", "");
                }

            }
            return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}

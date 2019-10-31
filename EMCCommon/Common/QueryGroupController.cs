using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using DDYZ.Ensis.Rule.DataRule;
using DDYZ.Ensis.Presistence.DataEntity;

namespace EMCCommon.Common
{
    /// <summary>
    /// 针对查询模板的操作
    /// </summary>
    public class QueryGroupController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述    ：  根据业务获取模板信息
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-06-01
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="model">业务类型</param>
        /// <param name="userid">用户ID(没有查询-1)</param>
        /// <returns>json（status(状态),msg(提示信息),data（为tblEQI_Query_Group表所有的数据））</returns>
        //[SupportFilter]
        [HttpGet]
        public HttpResponseMessage GetTemplate(string model, string userid)
        {
            string returntxt = "";
            try
            {
                RuletblEQI_Query_Group rule_group = new RuletblEQI_Query_Group();
                if (rule.IsNmmber(Convert.ToString(userid)))
                {
                    IList<tblEQI_Query_Group> list = rule_group.GetByUserIDandObject(int.Parse(userid), model);
                    if (list.Count > 0)
                        returntxt = rule.JsonStr("ok", "成功", list);
                    else
                        returntxt = rule.JsonStr("1", "没有数据", list);
                }
                else
                {
                    returntxt = rule.JsonStr("error", "参数错误", "");
                }

            }
            catch (Exception e)
            {
                returntxt = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
        }
        /// <summary>
        /// 功能描述    ：  添加模板
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-06-01
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="obj">动态参数(fldName：模板名称，fldObject：业务类别，fldTimeType：时间类型（year,month,day,sea）,fldTimeRange：时间,fldUserID:用户ID（可直接插入-1),fldItemGroup(因子组合)，fldItemCode（因子代码）
        /// fldPointGroup（点位组合），fldPointCode（点位代码），fldSource（数据来源）,fldDataType(备用参数)，fldSampleType（备用参数）</param>
        /// <returns>json（status(状态),msg(提示信息),data（9999时存在名称相同的模板,成功返回当前插入的ID,失败返回0））</returns>
        //[SupportFilter]
        [HttpPost]
        public HttpResponseMessage AddTremGroup(dynamic obj)
        {
            string returntxt = "";
            try
            {
                tblEQI_Query_Group query_group = new tblEQI_Query_Group();
                query_group.fldName = obj.fldName;
                query_group.fldObject = obj.fldObject;
                query_group.fldTimeType = obj.fldTimeType;
                query_group.fldTimeRange = obj.fldTimeRange;
                query_group.fldUserID = obj.fldUserID;
                query_group.fldItemGroup = obj.fldItemGroup == "" || obj.fldItemGroup == "0" ? "" : Convert.ToString(obj.fldItemGroup);
                query_group.fldItemCode = obj.fldItemCode == "" ? "" : obj.fldItemCode;
                query_group.fldPointGroup = obj.fldPointGroup == "" || obj.fldPointGroup == "0" ? "" : obj.fldPointGroup;
                query_group.fldPointCode = obj.fldPointCode == "" ? "" : obj.fldPointCode;
                query_group.fldSource = obj.fldSource;
                query_group.fldDataType = obj.fldDataType;
                query_group.fldSampleType = obj.fldSampleType;
                RuletblEQI_Query_Group rule_group = new RuletblEQI_Query_Group();
                int returnID = rule_group.Insert(query_group);
                if (returnID == 9999)
                {
                    returntxt = rule.JsonStr("no", "相同名称的分组已经存在,请输入其它名称", returnID);
                }
                if (returnID > 0 && returnID != 9999)
                {

                    returntxt = rule.JsonStr("ok", "添加成功！", returnID);
                }
                if (returnID < 0)
                {
                    returntxt = rule.JsonStr("error", "添加失败！", 0);
                }
                return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
            }
            catch (Exception ex)
            {
                returntxt = rule.JsonStr("error", ex.Message, 0);
                return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
            }
        }

        /// <summary>
        /// 功能描述    ：  删除模板
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-06-01
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：  
        /// </summary>
        /// <param name="id">要删除的ID</param>
        /// <returns>json（status(状态),msg(提示信息),data（成功为0，失败为1））</returns>
        //[SupportFilter]
        [HttpGet]
        public HttpResponseMessage DelTremGroup(string id)
        {
            string returntxt = "";
            try
            {
                RuletblEQI_Query_Group rule_group = new RuletblEQI_Query_Group();
                if (rule_group.Delete(int.Parse(id)))
                {
                    returntxt = rule.JsonStr("ok", "删除成功！", 0);
                }
            }
            catch (Exception ex)
            {
                returntxt = rule.JsonStr("error", ex.Message, 1);
            }
            return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述    ：  更新模板
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-06-02
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="obj">id：要更新的id，动态参数(fldName：模板名称，fldObject：业务类别，fldTimeType：时间类型（year,month,day,sea）,fldTimeRange：时间,fldUserID:用户ID（可直接插入-1),fldItemGroup(因子组合)，fldItemCode（因子代码）
        /// fldPointGroup（点位组合），fldPointCode（点位代码），fldSource（数据来源）,fldDataType(备用参数)，fldSampleType（备用参数）</param>
        /// <returns>json（status(状态),msg(提示信息),data（）</returns>
        //[SupportFilter]
        [HttpPost]
        public HttpResponseMessage updateTremGroup(dynamic obj)
        {
            string returntxt = "";
            try
            {
                RuletblEQI_Query_Group rule_group = new RuletblEQI_Query_Group();
                tblEQI_Query_Group query_group_old = rule_group.ByPK(Convert.ToInt32(obj.fldAutoID));
                tblEQI_Query_Group query_group = new tblEQI_Query_Group();
                query_group.fldName = query_group_old.fldName;
                query_group.fldObject = query_group_old.fldObject;
                query_group.fldTimeType = obj.fldTimeType;
                query_group.fldTimeRange = obj.fldTimeRange;
                query_group.fldUserID = obj.fldUserID;
                query_group.fldItemGroup = obj.fldItemGroup;
                query_group.fldItemCode = obj.fldItemCode;
                query_group.fldPointGroup = obj.fldPointGroup;
                query_group.fldPointCode = obj.fldPointCode;
                query_group.fldSource = obj.fldSource;
                query_group.fldDataType = obj.fldDataType;
                query_group.fldSampleType = obj.fldSampleType;
                if (rule_group.Update(query_group_old, query_group))
                {
                    returntxt = rule.JsonStr("ok", "更新成功！", 0);
                }
                else
                {
                    returntxt = rule.JsonStr("error", "更新失败！", 0);
                }
            }
            catch (Exception e)
            {
                returntxt = rule.JsonStr("error", e.Message, 0);
            }
            return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}

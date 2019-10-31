using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Linq;

namespace EMCCommon.Common
{
    /// <summary>
    /// 项目组合操作方法
    /// </summary>
    public class ItemGroupController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  得到项目组合数据
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-15
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="obj">动态类型参数包括：UserID用户ID、fldobject业务类型</param>
        /// <returns>返回该业务里面有的因子项目组合数据</returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage QueryItemGroup(dynamic obj)
        {
            string result = string.Empty;
            try
            {
                RuletblEQI_Item_Group rule_group = new RuletblEQI_Item_Group();

                string type = gettype(Convert.ToString(obj.modeltype));
                //验证字符串是否符合要求
                if (rule.IsNmmber(rule.ConductUserinfo(Convert.ToString(obj.UserID))))
                {
                    IList<tblEQI_Item_Group> list = rule_group.GetByUserIDandObject(int.Parse(Convert.ToString(obj.UserID)), type);
                    if (list.Count > 0)
                        result = rule.JsonStr("ok", "", list);
                    else
                        result = rule.JsonStr("nodata", "没有数据", list);
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：根据英文的业务类别转因子组合换所需的的业务
        /// 创建  人：周文卿
        /// 创建时间：2017/07/20
        /// 修改原因：
        /// 修改时间：
        /// 修改  人：
        /// </summary>
        /// <param name="type">英文的业务类别</param>
        /// <returns>因子组合所需的类别</returns>
        public string gettype(string type)
        {
            switch (type)
            {
                case "eqia_r":
                    type = "大气";
                    break;
                case "eqia_rd":
                    type = "降尘";
                    break;
                case "eqia_p":
                    type = "降水";
                    break;
                case "eqia_s":
                    type = "大气";
                    break;
                case "eqiw_r":
                    type = "地表水";
                    break;
                case "eqiw_d":
                    type = "饮用水";
                    break;
                case "eqiw_g":
                    type = "地下水";
                    break;
                case "eqiw_sts":
                    type = "地表水专项";
                    break;

            }
            return type;
        }

        /// <summary>
        /// 功能描述    ：  保存新项目组合
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-15
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="obj">动态类型参数包括：UserID用户ID、fldname项目组合名称、flditemcontent项目组合代码、fldobject业务类型 </param>
        /// <returns>返回当前报存项目组合信息</returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage AddItemGroup(dynamic obj)
        {
            string result = string.Empty;
            try
            {
                //验证字符串是否符合要求

                if (!string.IsNullOrEmpty(Convert.ToString(obj.fldname)))
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(obj.flditemcontent)))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(obj.modeltype)))
                        {
                            try
                            {
                                string type = gettype(HttpUtility.UrlDecode(Convert.ToString(obj.modeltype)));
                                tblEQI_Item_Group item_group = new tblEQI_Item_Group();
                                item_group.fldName = HttpUtility.UrlDecode(Convert.ToString(obj.fldname));
                                item_group.fldObject = type;
                                item_group.fldUserID = Convert.ToInt32(rule.ConductUserinfo(obj.UserID));
                                item_group.fldItemContent = Convert.ToString(obj.flditemcontent);
                                RuletblEQI_Item_Group rule_group = new RuletblEQI_Item_Group();
                                int returnID = rule_group.Insert(item_group);
                                if (returnID > 0)
                                {
                                    item_group.fldAutoID = returnID;
                                    result = rule.JsonStr("ok", "", item_group);
                                }
                            }
                            catch (InsertPKException ex)
                            {
                                result = rule.JsonStr("error", "相同名称的分组已经存在,请输入其它名称", "");
                            }
                            catch (InsertException ex)
                            {
                                PageException pagex = new PageException(Convert.ToInt32(obj.UserID), ex.Message, "input", "AddItemProject", "");
                                result = rule.JsonStr("error", "项目分组信息写入数据库失败", "");
                            }
                            catch (Exception ex)
                            {
                                PageException pagex = new PageException(Convert.ToInt32(obj.UserID), ex.Message, "input", "AddItemProject", "");
                                result = rule.JsonStr("error", "新增项目分组失败", "");
                            }
                        }
                        else
                        {
                            result = rule.JsonStr("error", "fldobject参数错误", "");
                        }
                    }
                    else
                    {
                        result = rule.JsonStr("error", "flditemcontent参数错误", "请选择要保存在分组中的项目");

                    }
                }
                else
                {
                    result = rule.JsonStr("error", "fldname参数错误", "请输入要保存的名称");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述    ：  更新新项目组合
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-15
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="obj">动态类型参数包括：id当前选中项目组合在数据库表中行ID、flditemcontent项目组合代码、fldobject业务类型</param>
        /// <returns>返回更新成功后的数据</returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage UpdateItemGroup(dynamic obj)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(obj.id)) || Convert.ToString(obj.id) == "0")
                {
                    result = rule.JsonStr("error", "id参数错误", "缺少更新的项目信息");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(obj.flditemcontent)))
                {
                    result = rule.JsonStr("error", "flditemcontent参数错误", "缺少要保存在分组中的项目");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(obj.modeltype)))
                {
                    result = rule.JsonStr("error", "fldobject参数错误", "缺少业务类型");
                }
                else
                {
                    try
                    {
                        string type = gettype(HttpUtility.UrlDecode(Convert.ToString(obj.modeltype)));
                        RuletblEQI_Item_Group rule_group = new RuletblEQI_Item_Group();
                        tblEQI_Item_Group objObject_old = rule_group.ByPK(Convert.ToInt32(rule.ConductUserinfo(obj.id)));
                        tblEQI_Item_Group objObject_new = new tblEQI_Item_Group();
                        objObject_new.fldObject = type;
                        objObject_new.fldUserID = objObject_old.fldUserID;
                        objObject_new.fldName = objObject_old.fldName;
                        objObject_new.fldItemContent = HttpUtility.UrlDecode(Convert.ToString(obj.flditemcontent));
                        bool isdelete = rule_group.Update(objObject_old, objObject_new);
                        if (isdelete)
                        {
                            objObject_new.fldAutoID = Convert.ToInt32(obj.id);
                            result = rule.JsonStr("ok", "更新组成功", objObject_new);
                        }
                    }
                    catch (UpdatePKException ex)
                    {
                        result = rule.JsonStr("error", "flditemcontent参数错误", "请选择要保存在分组中的项目");
                    }
                    catch (DDYZ.Ensis.Library.Exception.DataRule.UpdateException ex)
                    {
                        PageException pagex = new PageException(Convert.ToInt32(obj.UserID), ex.Message, "input", "UpdateItemProject", "");
                        result = rule.JsonStr("error", "更新项目信息时出现了错误", "");
                    }
                    catch (Exception ex)
                    {
                        PageException pagex = new PageException(Convert.ToInt32(obj.UserID), ex.Message, "input", "UpdateItemProject", "");
                        result = rule.JsonStr("error", "更新项目信息时出现了错误", "");
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
        /// 功能描述    ：  删除新项目组合
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-15
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="obj">动态类型参数包括：id当前选中项目组合在数据库表中行ID</param>
        /// <returns>返回是否删除成功</returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage DeleteItemGroup(dynamic obj)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(obj.id)) || Convert.ToString(obj.id) == "0")
                {
                    result = rule.JsonStr("error", "请先选择要删除的项目信息", "");
                }
                else
                {
                    try
                    {
                        RuletblEQI_Item_Group rule_group = new RuletblEQI_Item_Group();
                        bool isdelete = rule_group.Delete(Convert.ToInt32(obj.id));
                        if (isdelete)
                        {
                            result = rule.JsonStr("ok", "删除组成功", "");
                        }
                    }
                    catch (DeleteException ex)
                    {
                        PageException pagex = new PageException(Convert.ToInt32(obj.id), ex.Message, "input", "DeleteItemProject", "");
                        result = rule.JsonStr("error", "删除项目信息时出现了错误", "");
                    }
                    catch (Exception ex)
                    {
                        PageException pagex = new PageException(Convert.ToInt32(obj.id), ex.Message, "input", "DeleteItemProject", "");
                        result = rule.JsonStr("error", "删除项目信息时出现了错误", "");
                    }
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        // <summary>
        /// 功能描述    ：  根据城市代码获得保存的数据组
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-07-05
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// <param name="stcode">城市代码</param>
        /// <param name="type">业务类别</param>
        /// <returns>json（tblEQI_Item_Group所有数据）</returns>
        /// 
        [HttpGet]
        //[SupportFilter]
        public HttpResponseMessage GetdllBystcode(string stcode, string type)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(stcode))
                {
                    result = rule.JsonStr("error", "缺少城市", "");
                }
                else
                {
                    RuletblEQI_publi rulep = new RuletblEQI_publi();
                    List<tblEQI_Item_Group> list = rulep.GetdllBystcode(stcode, type);
                    if (list != null && list.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", list);
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




















        [HttpPost]
        public HttpResponseMessage ItemGroupRename(ItemGroupRename_Info info)
        {
            string result = string.Empty;
            try
            {
                using (Mode.EntityContext db = new Mode.EntityContext())
                {
                    var query = (from x in db.tblEQI_Item_Group
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




        public class ItemGroupRename_Info
        {
            public int fldAutoID { get; set; }

            public string fldName { get; set; }
        }

































    }
}

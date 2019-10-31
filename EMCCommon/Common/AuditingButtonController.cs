
using DDYZ.Ensis.Library.Exception.BusiRule;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace EMCCommon.Common
{
    /// <summary>
    /// 审核页面按钮功能
    /// </summary>
    public class AuditingButtonController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：审核页面的删除功能
        /// 创建者：熊瑞竹
        /// 创建日期：2017-06-07
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>返回删除数据正确或者失败的字符串</returns>
        [HttpPost]
        //[SupportFilter]
        public string Delete(dynamic obj)
        {
            try
            {

                if (obj.typemodel.ToString() == "eqise")
                {
                    obj.typemodel = "eqiw_r";
                }
                RuletblDictionary dic = new RuletblDictionary();
                string list = dic.ByParentIDAndValue("数据审核视图", obj.typemodel.ToString());
                string listone = list.Split(',')[0].ToString().Substring(2);
                string listones = listone.Substring(0, listone.Length - 7);
                string table = "";
                if (obj.typemodel.ToString() == "eqib_v")
                {
                    table = "tbl_" + listones;
                }
                else if (obj.typemodel.ToString() == "eqiw_r_auto")
                {
                    table = "tblEQIW_R_Basedata_Pre_Auto";
                }
                else
                {
                    table = "tbl" + listones;
                }
                List<long> lstDelID = new List<long>();
                string[] fld = obj.fldAutoId.ToString().Split(',');
                for (int i = 0; i < fld.Length; i++)
                {
                    string[] pk = fld[i].Split('_');
                    for (int j = 0; j < pk.Length; j++)
                    {
                        lstDelID.Add(Convert.ToInt64(pk[j].ToString()));
                    }
                }
                RuletblEQIA_RPI_Basedata_Pre rule_basedata = new RuletblEQIA_RPI_Basedata_Pre();

                bool isb = rule_basedata.delById(lstDelID, table);
                if (isb)
                {
                    return "删除成功！";
                }
                else
                {
                    return "删除失败！";
                }
            }
            catch (Exception e)
            {
                throw new Exception("删除数据失败！");
            }
        }


        /// <summary>
        /// 功能描述：删除全部数据
        /// 创建者：熊瑞竹
        /// 创建日期：2017-06-09
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="obj">动态参数</param>
        /// <returns>返回删除全部数据正确或者失败的字符串</returns>
        [HttpPost]
        //[SupportFilter]
        public string DeleteAll(dynamic obj)
        {
            string isSuccess = "";
            try
            {
                string table = obj.table.ToString();
                string bImport = obj.bImport.ToString();
                string where = obj.where.ToString();

                // bImport = context.Request["bImport"];
                RuletblDictionary dic = new RuletblDictionary();
                string list = dic.ByParentIDAndValue("数据审核视图", table);
                string listone = list.Split(',')[0].ToString().Substring(2);
                string listones = listone.Substring(0, listone.Length - 7);
                if (obj.table.ToString() == "eqib_v")
                {
                    table = "tbl_" + listones;
                }
                else if (obj.table.ToString() == "eqiw_r_auto")
                {
                    table = "tblEQIW_R_Basedata_Pre_Auto";
                }
                else
                {
                    table = "tbl" + listones;
                }
                if (where == "undefined" || where == "")
                {
                    string type = obj.table.ToString();
                    if (type.Substring(type.Length - 3, 3) == "_hm")
                    {
                        where = " fldSource=1";
                    }
                    else
                    {
                        where = " fldSource=0";
                    }
                }
                else
                {
                    where = " 1=1 " + where;
                }
                RuletblEQI_Auditing_COM_DeleteAll rule = new RuletblEQI_Auditing_COM_DeleteAll();
                if (bImport == "1")
                {

                    #region 市站登录
                    int cityID = int.Parse(obj.cityId.ToString());
                    int iresult = -1;
                    short flag = 0;
                    string strWhere = " fldImport=1 ";
                    iresult = rule.DelAllData(flag, where, cityID, table);
                    if (iresult >= 0)
                    {
                        isSuccess = "删除数据成功！";
                    }

                    #endregion

                }
                else
                {
                    try
                    {
                        short import = short.Parse(bImport);
                        short flag = 1;
                        if (obj.table.ToString() == "eqiw_r_auto")
                        {
                            flag = 0;
                        }
                        int cityID = int.Parse(obj.cityId.ToString());
                        int result = -1;
                        int iresult = -1;

                        string strWhere = "   ";
                        iresult = rule.DelAllData(flag, where, cityID, table);

                        if (iresult > 0)
                        {
                            isSuccess = "数据删除成功！";
                        }
                        else if (iresult == 0)
                        {
                            isSuccess = "删除数据失败,没有找到可删除的数据！";
                        }
                        else
                        {
                            isSuccess = "删除数据失败，请重试！";
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("删除数据失败！");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("删除数据失败！");
            };
            return isSuccess;
            // context.Response.Write(resposne);
        }













        /// <summary>
        /// 功能描述：审核的提交审核功能
        /// 创建者：熊瑞竹
        /// 创建日期：2017-06-08
        /// </summary>
        /// <param name="obj">默认ID</param>
        [HttpPost]
        public string Update(dynamic obj)
        {
            try
            {
                obj.userId = rule.ConductUserinfo(obj.userId);
                RuletblDictionary dic = new RuletblDictionary();
                if (obj.typemodel.ToString() == "eqise")
                {
                    obj.typemodel = "eqiw_r";
                }
                string list = dic.ByParentIDAndValue("数据审核视图", obj.typemodel.ToString());

                string listone = list.Split(',')[0].ToString().Substring(2);
                string listones = null;
                if (listone.ToLower().Contains("auto"))
                {
                    listones = listone.Substring(0, listone.Length - 12);

                }
                else
                {
                    listones = listone.Substring(0, listone.Length - 7);
                }
                string table = "";
                if (obj.typemodel.ToString() == "eqib_v")
                {
                    table = "tbl_" + listones;
                }
                else
                {
                    table = "tbl" + listones;
                }


                List<long> lstDelID = new List<long>();
                string[] fld = obj.fldAutoId.ToString().Split(',');
                for (int i = 0; i < fld.Length; i++)
                {
                    string[] pk = fld[i].Split('_');
                    for (int j = 0; j < pk.Length; j++)
                    {
                        lstDelID.Add(Convert.ToInt64(pk[j].ToString()));
                    }
                }
                RuletblEQIA_RPI_Basedata_Pre rule_basedata = new RuletblEQIA_RPI_Basedata_Pre();
                RuleWriteOperateLog rule_wol = new RuleWriteOperateLog();
                if (obj.NewFlag == null)
                {
                    obj.NewFlag = 1;
                }
                bool isb = rule_basedata.delBytable(lstDelID, table, obj.NewFlag.ToString());
                if (isb)
                {
                    rule_wol.WriteLog(0, "提交审核选中的数据数据，进入监测数据审核状态录入这ID=" + obj.userId.ToString(), obj.userName.ToString(), int.Parse(obj.userId.ToString()), int.Parse(obj.cityId.ToString()));
                    return "提交审核数据成功！";
                }
                else
                {
                    return "提交审核数据失败，请重试！";
                }
            }
            catch (Exception e)
            {
                throw new Exception("提交审核数据失败！");
            }
        }











        /// <summary>
        /// 功能描述：审核的提交审核功能
        /// 创建者：熊瑞竹
        /// 创建日期：2017-06-08
        /// </summary>
        /// <param name="obj">默认ID</param>
        [HttpGet]
        public string Update(string fldAutoId, string typemodel, string userId, string userName, string cityId, string NewFlag = null)
        {
            try
            {
                userId = rule.ConductUserinfo(userId);
                RuletblDictionary dic = new RuletblDictionary();
                if (typemodel.ToString() == "eqise")
                {
                    typemodel = "eqiw_r";
                }
                string list = dic.ByParentIDAndValue("数据审核视图", typemodel.ToString());

                string listone = list.Split(',')[0].ToString().Substring(2);
                string listones = null;
                if (listone.ToLower().Contains("auto"))
                {
                    listones = listone.Substring(0, listone.Length - 12);

                }
                else
                {
                    listones = listone.Substring(0, listone.Length - 7);
                }
                string table = "";
                if (typemodel.ToString() == "eqib_v")
                {
                    table = "tbl_" + listones;
                }
                else
                {
                    table = "tbl" + listones;
                }


                List<long> lstDelID = new List<long>();
                string[] fld = fldAutoId.ToString().Split(',');
                for (int i = 0; i < fld.Length; i++)
                {
                    string[] pk = fld[i].Split('_');
                    for (int j = 0; j < pk.Length; j++)
                    {
                        lstDelID.Add(Convert.ToInt64(pk[j].ToString()));
                    }
                }
                RuletblEQIA_RPI_Basedata_Pre rule_basedata = new RuletblEQIA_RPI_Basedata_Pre();
                RuleWriteOperateLog rule_wol = new RuleWriteOperateLog();
                if (NewFlag == null)
                {
                    NewFlag = "1";
                }
                bool isb = rule_basedata.delBytable(lstDelID, table, NewFlag.ToString());
                if (isb)
                {
                    rule_wol.WriteLog(0, "提交审核选中的数据数据，进入监测数据审核状态录入这ID=" + userId.ToString(), userName.ToString(), int.Parse(userId.ToString()), int.Parse(cityId.ToString()));
                    return "提交审核数据成功！";
                }
                else
                {
                    return "提交审核数据失败，请重试！";
                }
            }
            catch (Exception e)
            {
                throw new Exception("提交审核数据失败！");
            }
        }

























    }
}

using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page;
using DDYZ.Ensis.Library.Exception.Page.Input;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqia.Eqia_p
{
    /// <summary>
    /// 降水点位录入
    /// </summary>
    public class Eqia_P_PointInputController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  保存降水点位录入数据
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-06-14
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="itemvalue">需要保存的实体类</param>
        /// <returns>返回保存是否成功</returns>
        [HttpPost]
        //
        public HttpResponseMessage ItemSave(eqia_pdsavedata itemvalue)
        {
            string result = string.Empty;
            try
            {
                if (itemvalue.fldUserID == null || itemvalue.fldUserName == null)
                {
                    itemvalue.fldUserID = rule.ConductUserinfo(itemvalue.fldUserID);
                    itemvalue.fldUserName = "";
                }
                if (itemvalue.BeginDate != null && itemvalue.EndDate != null)
                {
                    if (itemvalue.fldSTCode != null)
                    {
                        if (itemvalue.fldPCode != null)
                        {
                            if (itemvalue.fldType != null)
                            {
                                if (itemvalue.fldItemData.Count > 0)
                                {
                                    List<tblEQIA_PPI_BaseData_Pre> lstData = new List<tblEQIA_PPI_BaseData_Pre>();
                                    tblEQIA_PPI_BaseData_Pre objData = new tblEQIA_PPI_BaseData_Pre();
                                    tblEQI_InputDate inputdate_new = new tblEQI_InputDate();
                                    objData.fldType = short.Parse(itemvalue.fldType);
                                    objData.fldSTCode = itemvalue.fldSTCode;
                                    objData.fldPCode = itemvalue.fldPCode;

                                    objData.fldSYear = inputdate_new.fldSYear = decimal.Parse(Convert.ToDateTime(itemvalue.BeginDate).Year.ToString());
                                    objData.fldSMonth = inputdate_new.fldSMonth = decimal.Parse(Convert.ToDateTime(itemvalue.BeginDate).Month.ToString());
                                    objData.fldSDay = inputdate_new.fldSDay = decimal.Parse(Convert.ToDateTime(itemvalue.BeginDate).Day.ToString());
                                    objData.fldSHour = inputdate_new.fldSHour = decimal.Parse(Convert.ToDateTime(itemvalue.BeginDate).Hour.ToString());
                                    objData.fldSMinute = inputdate_new.fldSMinute = decimal.Parse(Convert.ToDateTime(itemvalue.BeginDate).Minute.ToString());
                                    objData.fldEYear = inputdate_new.fldEYear = decimal.Parse(Convert.ToDateTime(itemvalue.EndDate).Year.ToString());
                                    objData.fldEMonth = inputdate_new.fldEMonth = decimal.Parse(Convert.ToDateTime(itemvalue.EndDate).Month.ToString());
                                    objData.fldEDay = inputdate_new.fldEDay = decimal.Parse(Convert.ToDateTime(itemvalue.EndDate).Day.ToString());
                                    objData.fldEHour = inputdate_new.fldEHour = decimal.Parse(Convert.ToDateTime(itemvalue.EndDate).Hour.ToString());
                                    objData.fldEMinute = inputdate_new.fldEMinute = decimal.Parse(Convert.ToDateTime(itemvalue.EndDate).Minute.ToString());

                                    objData.fldUserID = inputdate_new.fldUserID = int.Parse(itemvalue.fldUserID);
                                    objData.fldFlag = 0;
                                    objData.fldCityID_Operate = inputdate_new.fldCityID = int.Parse(itemvalue.fldCityID_Operate);
                                    objData.fldCityID_Submit = itemvalue.fldCityID_Submit;
                                    objData.fldDate_Operate = DateTime.Now;
                                    inputdate_new.fldObject = "eqia_p";

                                    Regex regexvalue2 = new Regex(@"^(\d*\.?\d+)?[lL]$");
                                    for (int i = 0; i < itemvalue.fldItemData.Count; i++)
                                    {
                                        decimal dValue = -1;
                                            if (itemvalue.fldItemData[i].itemvalue.Trim() != "")
                                            {
                                            if (regexvalue2.IsMatch(itemvalue.fldItemData[i].itemvalue.ToString().Trim()))
                                            {
                                                if (itemvalue.fldItemData[i].itemvalue.ToString().Trim().ToLower() == "l")
                                                {
                                                    
                                                }
                                                else
                                                {
                                                    dValue = -Convert.ToDecimal(itemvalue.fldItemData[i].itemvalue.ToString().Trim().Replace("l", "").Replace("L", ""));
                                                }
                                                if (dValue == -1)
                                                {
                                                    dValue = Convert.ToDecimal(-0.99999999);
                                                }
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    dValue = Convert.ToDecimal(itemvalue.fldItemData[i].itemvalue.ToString().Trim());
                                                }
                                                catch (Exception e)
                                                {
                                                    result = rule.JsonStr("error", "监测值只能输入数字或字符L和l!", "");
                                                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                                                }
                                            }
                                            }
                                        tblEQIA_PPI_BaseData_Pre objTmp = objData.Clone();
                                        objTmp.fldItemCode = itemvalue.fldItemData[i].itemcode.ToString();
                                        objTmp.fldItemValue = dValue;
                                        objTmp.fldCityID_Operate = Int32.Parse(itemvalue.fldCityID_Operate);
                                        objTmp.fldCityID_Submit = itemvalue.fldCityID_Submit;
                                        lstData.Add(objTmp);
                                    }
                                    RuletblEQIA_PPI_Basedata_Pre rule_basedata = new RuletblEQIA_PPI_Basedata_Pre();
                                    bool issave = rule_basedata.InsertAll(lstData, inputdate_new);
                                    if (issave)
                                    {
                                        RuleWriteOperateLog rule_wol = new RuleWriteOperateLog();
                                        rule_wol.WriteLog(0, "录入降水数据到临时表，测点代码：" + itemvalue.fldPCode +
                                            ";时间：" + itemvalue.BeginDate + " " + itemvalue.EndDate + ";录入者ID:" + int.Parse(itemvalue.fldUserID), itemvalue.fldUserName, int.Parse(itemvalue.fldUserID), int.Parse(itemvalue.fldCityID_Submit));
                                        result = rule.JsonStr("error", "录入成功！您保存的数据，已进入“待提交审核的数据”状态", "");
                                    }
                                    else
                                    {
                                        result = rule.JsonStr("error", "数据保存失败，请重试", "");
                                    }
                                }
                                else
                                {
                                    result = rule.JsonStr("error", "请提交因子监测值", "");
                                }
                            }
                            else
                            {
                                result = rule.JsonStr("error", "缺少降水类型", "");
                            }                            
                        }
                        else
                        {
                            result = rule.JsonStr("error", "缺少点位代码", "");
                        }
                    }
                    else
                    {
                        result = rule.JsonStr("error", "缺少城市代码", "");
                    }
                }
                else
                {
                    result = rule.JsonStr("error", "缺少监测时间", "");
                }
            }
            catch (InputException ex)
            {
                result = rule.JsonStr("error", "数据保存失败，" + ex.Message, "");
            }
            catch (InsertException ex)
            {
                PageException pagex = new PageException(int.Parse(itemvalue.fldUserID), ex.Message,
                    "Eqia_pPointInputController", "ItemSave", "");
                result = rule.JsonStr("error", "数据写入数据库失败，" + ex.Message, "");
            }
            catch (Exception ex)
            {
                PageException pagex = new PageException(int.Parse(itemvalue.fldUserID), ex.Message,
                    "Eqia_pPointInputController", "ItemSave", "");
                result = rule.JsonStr("error", "数据保存时出现了错误，" + ex.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 大气点位录入保存类
        /// </summary>
        public class eqia_pdsavedata
        {
            /// <summary>
            /// 监测值数组
            /// </summary>
            public List<itemvalueData> fldItemData { get; set; }
            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>

            public string EndDate { get; set; }

            /// <summary>
            /// 用户ID
            /// </summary>
            public string fldUserID { get; set; }

            /// <summary>
            /// 用户名
            /// </summary>
            public string fldUserName { get; set; }

            /// <summary>
            /// 操作城市id
            /// </summary>
            public string fldCityID_Operate { get; set; }

            /// <summary>
            /// 提交城市id
            /// </summary>
            public string fldCityID_Submit { get; set; }

            /// <summary>
            /// 城市代码
            /// </summary>
            public string fldSTCode { get; set; }

            /// <summary>
            /// 区县代码
            /// </summary>
            public string fldCountyCode { get; set; }

            /// <summary>
            /// 点位代码
            /// </summary>
            public string fldPCode { get; set; }

            /// <summary>
            /// 降水类型
            /// </summary>
            public string fldType { get; set; }

        }

        /// <summary>
        /// 因子值类
        /// </summary>
        public class itemvalueData
        {
            /// <summary>
            /// 因子代码
            /// </summary>
            public string itemcode { get; set; }

            /// <summary>
            /// 因子值
            /// </summary>

            public string itemvalue { get; set; }
        }
    }
}

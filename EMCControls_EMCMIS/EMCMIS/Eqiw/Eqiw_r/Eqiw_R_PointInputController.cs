using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page;
using DDYZ.Ensis.Library.Exception.Page.Input;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqiw.Eqiw_r
{
    /// <summary>
    /// 地表水点位录入
    /// </summary>
    public class Eqiw_R_PointInputController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  保存地表水点位录入数据
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-06-14
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="itemvalue">需要保存的实体类</param>
        /// <returns>返回是否保存成功</returns>
        [HttpPost]
        //
        public HttpResponseMessage ItemSave(eqia_rsavedata itemvalue)
        {
            string result = string.Empty;
            if (itemvalue.fldUserID == null || itemvalue.fldUserName == null)
            {
                itemvalue.fldUserID = rule.ConductUserinfo(itemvalue.fldUserID);
                itemvalue.fldUserName = "";
            }
            try
            {
                if (itemvalue.BeginDate != null && itemvalue.EndDate != null)
                {
                    if (itemvalue.fldSTCode != null)
                    {
                        if (itemvalue.fldRCode != null)
                        {

                            if (itemvalue.fldRSCode != null)
                            {
                                if (itemvalue.fldItemData.Count > 0)
                                {
                                    List<tblEQIW_R_Basedata_Pre> lstData = new List<tblEQIW_R_Basedata_Pre>();
                                    tblEQIW_R_Basedata_Pre objData = new tblEQIW_R_Basedata_Pre();
                                    List<tblEQIW_D_Basedata_Pre> lstDataD = new List<tblEQIW_D_Basedata_Pre>();
                                    tblEQI_InputDate inputdate_new = new tblEQI_InputDate();
                                    objData.fldSTCode = itemvalue.fldSTCode;
                                    objData.fldRCode = itemvalue.fldRCode;
                                    objData.fldRSCode = itemvalue.fldRSCode;
                                    objData.fldRSC = itemvalue.fldRSC;
                                    objData.fldSAMPH = "1";
                                    objData.fldSAMPR = "1";
                                    objData.fldYear = inputdate_new.fldSYear = decimal.Parse(Convert.ToDateTime(itemvalue.BeginDate).Year.ToString());
                                    objData.fldMonth = inputdate_new.fldSMonth = decimal.Parse(Convert.ToDateTime(itemvalue.BeginDate).Month.ToString());
                                    objData.fldDay = inputdate_new.fldSDay = decimal.Parse(Convert.ToDateTime(itemvalue.BeginDate).Day.ToString());
                                    objData.fldHour = inputdate_new.fldSHour = decimal.Parse(Convert.ToDateTime(itemvalue.BeginDate).Hour.ToString());
                                    objData.fldMinute = inputdate_new.fldSMinute = decimal.Parse(Convert.ToDateTime(itemvalue.BeginDate).Minute.ToString());
                                    objData.fldSource = 0;
                                    objData.fldUserID = inputdate_new.fldUserID = int.Parse(itemvalue.fldUserID);
                                    objData.fldFlag = 0;
                                    objData.fldCityID_Operate = inputdate_new.fldCityID = int.Parse(itemvalue.fldCityID_Operate);
                                    objData.fldCityID_Submit = itemvalue.fldCityID_Submit;
                                    objData.fldDate_Operate = DateTime.Now;
                                    objData.fldBatch = itemvalue.BeginDate + Guid.NewGuid().ToString();
                                    inputdate_new.fldObject = "eqiw_r";
                                    Regex regexvalue = new Regex(@"^(\d*\.?\d+)+$");
                                    Regex regexvalue2 = new Regex(@"^(\d*\.?\d+)?[lL]$");
                                    for (int i = 0; i < itemvalue.fldItemData.Count; i++)
                                    {
                                        decimal dValue = -1;


                                        DataTable dataTable = rule.GetItem("地表水", itemvalue.fldItemData[i].itemcode);

                                        if (dataTable.Rows.Count > 0)
                                        {
                                            if (itemvalue.fldItemData[i].itemvalue.Trim() != "")
                                            {
                                                //if (!regexvalue.IsMatch(itemvalue.fldItemData[i].itemvalue) && !regexvalue2.IsMatch(itemvalue.fldItemData[i].itemvalue))
                                                //{
                                                //    result = rule.JsonStr("error", "项目[" + dataTable.Rows[0]["fldItemName"].ToString() + "]的监测值只能输入数字或字符L和l!", "");
                                                //    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                                                //}
                                                if (!regexvalue2.IsMatch(itemvalue.fldItemData[i].itemvalue))
                                                {
                                                    dValue = Convert.ToDecimal(itemvalue.fldItemData[i].itemvalue);
                                                    decimal dMinValue = Convert.ToDecimal(dataTable.Rows[0]["fldMinValue"].ToString());
                                                    if (dMinValue >= 0 && dValue < dMinValue)
                                                    {
                                                        result = rule.JsonStr("error", "" + dataTable.Rows[0]["fldItemName"] + "的监测值应 >=" + dMinValue, "");
                                                        return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                                                    }
                                                    decimal dMaxValue = Convert.ToDecimal(dataTable.Rows[0]["fldMaxValue"].ToString());
                                                    if (dMaxValue > 0 && dValue > dMaxValue)
                                                    {
                                                        result = rule.JsonStr("error", "" + dataTable.Rows[0]["fldItemName"] + "的监测值应 <=" + dMaxValue, "");
                                                        return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                                                    }
                                                }
                                                if (regexvalue2.IsMatch(itemvalue.fldItemData[i].itemvalue.Trim()))
                                                {
                                                    if (itemvalue.fldItemData[i].itemvalue.Trim().ToLower() == "l")
                                                    {
                                                        decimal temp = Convert.ToDecimal(dataTable.Rows[0]["fldSense"].ToString());

                                                        if (temp <= 0)
                                                        {
                                                            result = rule.JsonStr("error", "项目[" + dataTable.Rows[0]["fldItemName"].ToString() + "]的检出限<=0，不能输入 L 作为监测值", "");
                                                            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                                                        }
                                                        dValue = -temp;
                                                    }
                                                    else
                                                    {
                                                        dValue = -Convert.ToDecimal(itemvalue.fldItemData[i].itemvalue.Trim().Replace("l", "").Replace("L", ""));
                                                    }
                                                    if (dValue == -1)
                                                    {
                                                        dValue = Convert.ToDecimal(-0.99999999);
                                                    }
                                                }
                                                else
                                                {
                                                    dValue = Convert.ToDecimal(itemvalue.fldItemData[i].itemvalue.ToString().Trim());
                                                }
                                            }

                                            tblEQIW_R_Basedata_Pre objTmp = objData.Clone();
                                            objTmp.fldItemCode = itemvalue.fldItemData[i].itemcode;
                                            objTmp.fldItemValue = dValue;
                                            objTmp.fldCityID_Operate = Int32.Parse(itemvalue.fldCityID_Operate);
                                            objTmp.fldCityID_Submit = itemvalue.fldCityID_Submit;
                                            lstData.Add(objTmp);
                                        }
                                    }
                                    RuletblEQIW_R_Basedata_Pre rule_basedata = new RuletblEQIW_R_Basedata_Pre();
                                    bool issave = rule_basedata.InsertAll(lstData, inputdate_new);
                                    if (issave)
                                    {
                                        RuleWriteOperateLog rule_wol = new RuleWriteOperateLog();
                                        rule_wol.WriteLog(0, "录入河流数据到临时表，断面" + itemvalue.fldRSCode +
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
                                    result = rule.JsonStr("error", "缺少因子监测值", "");
                                }
                            }
                            else
                            {
                                result = rule.JsonStr("error", "缺少断面代码", "");
                            }
                        }
                        else
                        {
                            result = rule.JsonStr("error", "缺少河流代码", "");
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
                    "Eqiw_rPointInputController", "ItemSave", "");
                result = rule.JsonStr("error", "数据写入数据库失败，" + ex.Message, "");
            }
            catch (Exception ex)
            {
                PageException pagex = new PageException(int.Parse(itemvalue.fldUserID), ex.Message,
                    "Eqiw_rPointInputController", "ItemSave", "");
                result = rule.JsonStr("error", "数据保存时出现了错误，" + ex.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 大气点位录入保存类
        /// </summary>
        public class eqia_rsavedata
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
            /// 河流代码
            /// </summary>
            public string fldRCode { get; set; }


            /// <summary>
            ///断面代码
            /// </summary>
            public string fldRSCode { get; set; }

            /// <summary>
            /// 水期代码
            /// </summary>
            public string fldRSC { get; set; }

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

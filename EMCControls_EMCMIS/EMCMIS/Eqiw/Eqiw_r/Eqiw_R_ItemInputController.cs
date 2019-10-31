using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqiw.Eqiw_r
{
    /// <summary>
    /// 功能描述：地表水数据插入到临时表
    /// 创建时间：2017/07/12
    /// 创建  人：周文卿 
    /// </summary>
    public class Eqiw_R_ItemInputController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：数据插入到临时表
        /// 创建  人：周文卿
        /// 创建时间：2017/07/12
        /// </summary>
        /// <param name="inputdata">插入的实体类</param>
        /// <returns>json（是否成功）</returns>
        public HttpResponseMessage ItemSave(List<tbleqiw_r_table> inputdata)
        {
            string returntext = "";

            try
            {
                Regex regexvalue = new Regex(@"^(\d*\.?\d+)+$");
                Regex regexvalue2 = new Regex(@"^(\d*\.?\d+)?[lL]$");

                //赋值点位时间信息
                List<tblEQIW_R_Basedata_Pre> lstData = new List<tblEQIW_R_Basedata_Pre>();
                tblEQIW_R_Basedata_Pre objData = new tblEQIW_R_Basedata_Pre();
                List<tblEQIW_D_Basedata_Pre> lstDataD = new List<tblEQIW_D_Basedata_Pre>();
                for (int i = 0; i < inputdata.Count; i++)
                {
                    List<tbaeqiw_r_value> valueall = inputdata[i].valueall;
                    for (int j = 0; j < valueall.Count; j++)
                    {
                        objData.fldSTCode = valueall[j].fldSTCode;
                        objData.fldRSC = inputdata[i].fldRSC;
                        objData.fldUserID = int.Parse(inputdata[i].fldUserID);
                        objData.fldFlag = 0;
                        objData.fldCityID_Operate = int.Parse(inputdata[i].fldCityID_Operate);
                        objData.fldCityID_Submit = inputdata[i].fldCityID_Submit;
                        objData.fldDate_Operate = DateTime.Now;
                        decimal dValue = -1;
                        string samphvalue = valueall[j].monitorvalue;
                        #region 修改监测值
                        if (samphvalue != "")
                        {
                            if (regexvalue2.IsMatch(samphvalue))
                            {
                                if (samphvalue.ToLower() == "l")
                                {

                                    decimal temp = Convert.ToDecimal(valueall[j].monitorvalue);
                                    if (temp <= 0)
                                    {
                                        returntext = rule.JsonStr("error", "项目的检出限<=0，不能输入 L 作为监测值", "");
                                        return new HttpResponseMessage { Content = new StringContent(returntext, System.Text.Encoding.UTF8, "application/json") };
                                    }
                                    dValue = -temp;
                                }
                                else
                                {
                                    dValue = -Convert.ToDecimal(samphvalue.Replace("l", "").Replace("L", ""));
                                }
                                if (dValue == -1)
                                {
                                    dValue = Convert.ToDecimal(-0.99999999);
                                }
                            }
                            else
                            {
                                dValue = Convert.ToDecimal(samphvalue);
                            }
                        }
                        #endregion
                        tblEQIW_R_Basedata_Pre objTmp = objData.Clone();
                        DateTime time = DateTime.Parse(valueall[j].fldDate.ToString());
                        objTmp.fldYear = time.Year;
                        objTmp.fldMonth = time.Month;
                        objTmp.fldDay = time.Day;
                        objTmp.fldHour = 0;
                        objTmp.fldMinute = 0;
                        objTmp.fldSAMPH = "1";
                        objTmp.fldRCode = valueall[j].fldRCode;
                        objTmp.fldRSCode = valueall[j].fldRSCode;
                        objTmp.fldSAMPR = "1";
                        objTmp.fldItemCode = inputdata[i].itemcode;
                        objTmp.fldItemValue = dValue;
                        lstData.Add(objTmp);
                    }
                }
                RuletblEQIW_R_Basedata_Pre rule_basedata = new RuletblEQIW_R_Basedata_Pre();
                bool issave = rule_basedata.InsertAll(lstData);
                if (issave)
                {
                    RuleWriteOperateLog rule_wol = new RuleWriteOperateLog();
                    rule_wol.WriteLog(0, "录入河流数据到临时表", "", int.Parse(inputdata[0].fldUserID), int.Parse(inputdata[0].fldCityID_Operate));
                    returntext = rule.JsonStr("ok", "录入成功！您保存的数据，已进入“待提交审核的数据”状态", "");
                }
                else
                {
                    returntext = rule.JsonStr("error", "保存数据失败！请重试！", "");
                }
            }
            catch (InputException ex)
            {
                returntext = rule.JsonStr("error", ex.Message, "");
            }
            catch (InsertException ex)
            {
                returntext = rule.JsonStr("error", ex.Message, "");
            }
            catch (Exception ex)
            {
                returntext = rule.JsonStr("error", ex.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(returntext, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 录入的实体类  跟前端所传json一样
        /// </summary>
        public class tbleqiw_r_table
        {
            /// <summary>
            /// 因子代码
            /// </summary>
            public string itemcode { get; set; }

            /// <summary>
            /// 录入的详细信息
            /// </summary>
            public List<tbaeqiw_r_value> valueall { get; set; }

            /// <summary>
            /// 用户ID
            /// </summary>
            public string fldUserID { get; set; }

            /// <summary>
            /// 操作城市id
            /// </summary>
            public string fldCityID_Operate { get; set; }

            /// <summary>
            /// 提交城市ID
            /// </summary>
            public string fldCityID_Submit { get; set; }

            /// <summary>
            /// 水期代码
            /// </summary>
            public string fldRSC { get; set; }

        }

        /// <summary>
        /// 具体的数据
        /// </summary>
        public class tbaeqiw_r_value
        {
            /// <summary>
            /// ID 页面编号
            /// </summary>
            public string id { get; set; }

            /// <summary>
            /// 城市代码
            /// </summary>
            public string fldSTCode { get; set; }

            /// <summary>
            /// 河流代码
            /// </summary>
            public string fldRCode { get; set; }

            /// <summary>
            /// 河流名称
            /// </summary>
            public string fldRName { get; set; }

            /// <summary>
            /// 断面代码
            /// </summary>
            public string fldRSCode { get; set; }

            /// <summary>
            /// 断面名称
            /// </summary>
            public string fldRSName { get; set; }

            /// <summary>
            /// 监测时间
            /// </summary>
            public string fldDate { get; set; }

            /// <summary>
            /// 因子的监测值
            /// </summary>
            public string monitorvalue { get; set; }
        }
    }
}

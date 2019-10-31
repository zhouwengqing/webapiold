using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;


namespace EMCControls_EMCMIS.Eqia.Eqia_rd
{
    /// <summary>
    /// 功能描述：插入到降尘临时表
    /// 创建  人：周文卿
    /// 创建时间：2017/07/12
    /// </summary>
    public class Eqia_RD_ItemInputController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：数据插入到临时表
        /// 创建  人：周文卿
        /// 创建时间：2017/07/11
        /// 修改原因：
        /// 修改时间：
        /// 修改  人：
        /// </summary>
        /// <param name="inputdata">插入的实体类</param>
        /// <returns>json（是否成功）</returns>
        public HttpResponseMessage ItemSave(List<tbleqia_rd_table> inputdata)
        {
            string returntext = "";
            try
            {
                Regex regexvalue = new Regex(@"^(\d*\.?\d+)+$");
                Regex regexvalue2 = new Regex(@"^(\d*\.?\d+)?[lL]$");
                List<tblEQIA_RDPI_Basedata_Pre> lstData = new List<tblEQIA_RDPI_Basedata_Pre>();
                tblEQIA_RDPI_Basedata_Pre objData = new tblEQIA_RDPI_Basedata_Pre();
                tblEQI_InputDate inputdate_new = new tblEQI_InputDate();
                RuletblEQI_publi ruleSense = new RuletblEQI_publi();
                for (int i = 0; i < inputdata.Count; i++)
                {
                    List<tbaeqia_rd_value> valueall = inputdata[i].valueall;
                    for (int j = 0; j < valueall.Count; j++)
                    {
                        RuletblDictionary ruleDict = new RuletblDictionary();

                        objData.fldSTCode = valueall[j].fldSTCode;
                        objData.fldUserID = int.Parse(inputdata[i].fldUserID);
                        objData.fldFlag = 0;
                        objData.fldCityID_Operate = int.Parse(inputdata[i].fldCityID_Operate);
                        objData.fldCityID_Submit = inputdata[i].fldCityID_Submit;
                        objData.fldDate_Operate = DateTime.Now;
                        decimal dValue = -1;
                        string samphvalue = valueall[j].monitorvalue;
                        #region 因子值的处理
                        if (samphvalue != "")
                        {
                            if (regexvalue2.IsMatch(samphvalue))
                            {
                                if (samphvalue.ToLower() == "l")
                                {
                                    string itemname = "";
                                    itemname = ruleSense.GetSenseNameBytbl("EQIA_RD", inputdata[i].itemcode);
                                    decimal temp = Convert.ToDecimal(valueall[j].monitorvalue);
                                    if (temp <= 0)
                                    {
                                        returntext = "项目的检出限<=0，不能输入 L 作为监测值'";
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
                        tblEQIA_RDPI_Basedata_Pre objTmp = objData.Clone();
                        objTmp.fldPCode = valueall[j].fldPCode;

                        DateTime time = DateTime.Parse(valueall[j].fldDate.ToString());
                        objTmp.fldSYear = time.Year;
                        objTmp.fldSMonth = time.Month;
                        objTmp.fldSDay = time.Day;
                        objTmp.fldSHour = 0;
                        objTmp.fldSMinute = 0;
                        objTmp.fldEYear = time.Year;
                        objTmp.fldEMonth = time.Month;
                        objTmp.fldEDay = time.Day;
                        objTmp.fldEHour = 0;
                        objTmp.fldEMinute = 0;
                        objTmp.fldFlag = 0;
                        objTmp.fldImport = 0;
                        objTmp.fldItemCode = inputdata[i].itemcode;
                        objTmp.fldItemValue = dValue;
                        lstData.Add(objTmp);
                    }
                }
                RuletblEQIA_RDPI_Basedata_Pre rule_basedata = new RuletblEQIA_RDPI_Basedata_Pre();
                bool issave = rule_basedata.InsertAll(lstData);
                if (issave)
                {
                    RuleWriteOperateLog rule_wol = new RuleWriteOperateLog();
                    rule_wol.WriteLog(0, "录入降尘数据到临时表", "", int.Parse(inputdata[0].fldUserID), int.Parse(inputdata[0].fldCityID_Operate));
                    returntext = rule.JsonStr("ok", "录入成功！您保存的数据，已进入“待提交审核的数据”状态", "");
                }
                else
                {
                    returntext = rule.JsonStr("error", "录入失败 ！请重试！", "");
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
    }


    /// <summary>
    /// 录入的实体类  跟前端所传json一样
    /// </summary>
    public class tbleqia_rd_table
    {
        /// <summary>
        /// 因子代码
        /// </summary>
        public string itemcode { get; set; }

        /// <summary>
        /// 录入的详细信息
        /// </summary>
        public List<tbaeqia_rd_value> valueall { get; set; }

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
    }

    /// <summary>
    /// 具体的数据
    /// </summary>
    public class tbaeqia_rd_value
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
        /// 测点代码
        /// </summary>
        public string fldPCode { get; set; }

        /// <summary>
        /// 测点名称
        /// </summary>
        public string fldPName { get; set; }

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

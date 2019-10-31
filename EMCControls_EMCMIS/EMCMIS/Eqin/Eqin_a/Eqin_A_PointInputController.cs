
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

namespace EMCControls_EMCMIS.Eqin.Eqin_a
{
    /// <summary>
    /// 功能描述：区域噪声按点位录入保存
    /// 创建  人：周文卿
    /// 创建时间：2017/07/31
    /// </summary>
    /// 


    public class Eqin_A_PointInputController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：数据保存
        /// 创建  人：周文卿
        /// 创建时间：2017/08/01
        /// 修改原因：
        /// 修改时间：
        /// 修改  人：
        /// </summary>
        /// <param name="alldata">导入数据实体类</param>
        /// <returns></returns>
        /// 
        [HttpPost]
        //
        public HttpResponseMessage PointSave(List<tbleqin_a_data> alldata)
        {
            string returntext = "";
            try
            {

                tblEQI_InputDate inputdate_new = new tblEQI_InputDate();
                List<tblEQIN_A_BaseData_Pre> lstData = new List<tblEQIN_A_BaseData_Pre>();
                List<inputeqin_a_data> inputdata = alldata[0].inputdata;
                DateTime dts = DateTime.Parse(alldata[0].datetime);
                for (int i = 0; i < inputdata.Count; i++)
                {


                    tblEQIN_A_BaseData_Pre objData = new tblEQIN_A_BaseData_Pre();
                    objData.fldSTCode = inputdata[i].fldSTCode;
                    objData.fldGDCODE = inputdata[i].fldGDCODE;
                    objData.fldYear = dts.Year;
                    objData.fldMonth = dts.Month;
                    objData.fldDay = dts.Day;
                    objData.fldHour = dts.Hour.ToString() == "" ? -1 : Convert.ToDecimal(dts.Hour.ToString());
                    objData.fldMinute = dts.Minute.ToString() == "" ? -1 : Convert.ToDecimal(dts.Minute.ToString());
                    objData.fldTimelen = inputdata[i].fldTimelen.ToString() == "" ? -1 : Convert.ToInt32(inputdata[i].fldTimelen.ToString());
                    objData.fldDN = inputdata[i].fldDN.ToString();
                    objData.fldNDISC = inputdata[i].fldNDISC.ToString();

                    objData.fldNSC = inputdata[i].fldNSC.ToString();
                    objData.fldApparatus_Grade = inputdata[i].fldApparatus_Grade;

                    objData.fldLEQA = inputdata[i].fldLEQA.ToString() == "" ? -1 : Convert.ToDecimal(inputdata[i].fldLEQA.ToString());
                    objData.fldL10A = inputdata[i].fldL10A.ToString() == "" ? -1 : Convert.ToDecimal(inputdata[i].fldL10A.ToString());
                    objData.fldL50A = inputdata[i].fldL50A.ToString() == "" ? -1 : Convert.ToDecimal(inputdata[i].fldL50A.ToString());
                    objData.fldL90A = inputdata[i].fldL90A.ToString() == "" ? -1 : Convert.ToDecimal(inputdata[i].fldL90A.ToString());
                    objData.fldLmin = inputdata[i].fldLmin.ToString() == "" ? -1 : Convert.ToDecimal(inputdata[i].fldLmin.ToString());
                    objData.fldLmax = inputdata[i].fldLmax.ToString() == "" ? -1 : Convert.ToDecimal(inputdata[i].fldLmax.ToString());
                    objData.fldSD = inputdata[i].fldSD.ToString() == "" ? -1 : Convert.ToDecimal(inputdata[i].fldSD.ToString());
                    objData.fldMph = inputdata[i].fldMph.ToString() == "" ? -1 : decimal.Parse(inputdata[i].fldMph.ToString());

                    objData.fldApparatus_Type = inputdata[i].fldApparatus_Type.ToString();
                    objData.fldApparatus_Id = inputdata[i].fldApparatus_Id.ToString();

                    objData.fldFlag = 0;
                    objData.fldCityID_Operate = int.Parse(alldata[0].CityID);
                    objData.fldCityID_Submit = alldata[0].CityID;
                    objData.fldSource = 0;
                    objData.fldImport = 0;
                    objData.fldFlag = 0;
                    objData.fldBatch = "0";
                    objData.fldMatching_Data = false;
                    objData.fldSPressureValue = 0;
                    objData.fldCalibrationVluesEnd = 0;
                    objData.fldCalibrationVluesOn = 0;
                    objData.fldDeleteState = 0;
                    objData.fldSPressureType = "0";
                    objData.fldSPressureID = "0";
                    objData.fldDate_Operate = DateTime.Now;
                    objData.fldUserID = int.Parse(alldata[0].UserID);
                    lstData.Add(objData);
                    if (i == 0)
                    {
                        inputdate_new.fldSYear = objData.fldYear;
                        inputdate_new.fldSMonth = objData.fldMonth;
                        inputdate_new.fldSDay = objData.fldDay;
                        inputdate_new.fldCityID = objData.fldCityID_Operate;
                        inputdate_new.fldUserID = objData.fldUserID;
                        inputdate_new.fldObject = "eqin_a";
                    }
                }
                tblEQI_InputDate inputdate_old = new tblEQI_InputDate();
                RuletblEQIN_A_Basedata_Pre rule_basedata = new RuletblEQIN_A_Basedata_Pre();
                bool issave = rule_basedata.InsertAll(lstData, inputdate_new, inputdate_old);
                if (issave)
                {
                    RuleWriteOperateLog rule_wol = new RuleWriteOperateLog();
                    rule_wol.WriteLog(0, "录入区域噪声数据到临时表", "", int.Parse(alldata[0].UserID), int.Parse(alldata[0].CityID));
                    returntext = rule.JsonStr("ok", "录入成功！您保存的数据，已进入“待提交审核的数据”状态", "");
                }
                else
                {
                    returntext = rule.JsonStr("error", "保存失败！请重试！", "");
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
    /// 数据导入的类
    /// </summary>
    public class tbleqin_a_data
    {
        /// <summary>
        /// 数据
        /// </summary>
        public List<inputeqin_a_data> inputdata { get; set; }

        /// <summary>
        /// 城市ID
        /// </summary>
        public string CityID { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string datetime { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
    }

    /// <summary>
    /// 具体数据
    /// </summary>
    public class inputeqin_a_data
    {
        /// <summary>
        /// 城市代码
        /// </summary>
        public string fldSTCode { get; set; }

        /// <summary>
        /// 点位代码
        /// </summary>
        public string fldGDCODE { get; set; }

        /// <summary>
        /// 监测时长
        /// </summary>
        public string fldTimelen { get; set; }
        /// <summary>
        /// 昼夜
        /// </summary>
        public string fldDN { get; set; }

        /// <summary>
        /// 功能区代码
        /// </summary>
        public string fldNDISC { get; set; }

        /// <summary>
        /// 声源代码
        /// </summary>
        public string fldNSC { get; set; }

        /// <summary>
        /// fldLEQA
        /// </summary>
        public decimal fldLEQA { get; set; }

        /// <summary>
        /// fldL10A
        /// </summary>
        public decimal fldL10A { get; set; }

        /// <summary>
        /// fldL50A
        /// </summary>
        public decimal fldL50A { get; set; }

        /// <summary>
        /// fldL90A
        /// </summary>
        public decimal fldL90A { get; set; }

        /// <summary>
        /// fldLmax
        /// </summary>
        public decimal fldLmax { get; set; }

        /// <summary>
        /// fldLmin
        /// </summary>
        public decimal fldLmin { get; set; }

        /// <summary>
        /// fldSD
        /// </summary>
        public string fldSD { get; set; }

        /// <summary>
        /// fldMph
        /// </summary>
        public string fldMph { get; set; }

        /// <summary>
        /// fldApparatus_Type
        /// </summary>
        public string fldApparatus_Type { get; set; }

        /// <summary>
        /// fldApparatus_Id
        /// </summary>
        public string fldApparatus_Id { get; set; }

        /// <summary>
        /// fldApparatus_Grade
        /// </summary>
        public bool fldApparatus_Grade { get; set; }
    }
}

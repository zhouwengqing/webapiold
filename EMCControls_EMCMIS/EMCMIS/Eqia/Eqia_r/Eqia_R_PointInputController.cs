
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

namespace EMCControls_EMCMIS.Eqia.Eqia_r
{
    /// <summary>
    /// 有关大气按点位录入操作
    /// </summary>
    public class Eqia_R_PointInputController : ApiController
    {
        RuleCommon rule = new RuleCommon ();

        /// <summary>
        /// 功能描述    ：  保存大气点位录入数据
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
        public HttpResponseMessage ItemSave(eqia_rsavedata itemvalue)
        {

            string result = string.Empty;
            if(itemvalue.fldUserID==null|| itemvalue.fldUserName == null)
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
                        if (itemvalue.fldPCode != null)
                        {
                            if (itemvalue.fldItemData.Count > 0)
                            {
                                List<tblEQIA_RPI_Basedata_Pre> lstData = new List<tblEQIA_RPI_Basedata_Pre>();
                                tblEQIA_RPI_Basedata_Pre objData = new tblEQIA_RPI_Basedata_Pre();
                                tblEQI_InputDate inputdate_new = new tblEQI_InputDate();
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
                                objData.fldSource = 0;
                                objData.fldUserID = inputdate_new.fldUserID = int.Parse(itemvalue.fldUserID);
                                objData.fldFlag = 0;
                                objData.fldCityID_Operate = inputdate_new.fldCityID = int.Parse(itemvalue.fldCityID_Operate);
                                objData.fldCityID_Submit = itemvalue.fldCityID_Submit;
                                objData.fldDate_Operate = DateTime.Now;
                                objData.fldBatch = itemvalue.BeginDate + Guid.NewGuid().ToString();
                                inputdate_new.fldObject = "eqia_r";
                                Regex regexvalue2 = new Regex(@"^(\d*\.?\d+)?[lL]$");
                                for (int i = 0; i < itemvalue.fldItemData.Count; i++)
                                {
                                    decimal dValue = -1;
                                    RuletblEQIA_R_Item rule_item = new RuletblEQIA_R_Item();

                                    DataTable dataTable = rule_item.GetItemAndSTDDataByItemCode(itemvalue.fldItemData[i].itemcode);

                                    if (dataTable.Rows.Count > 0)
                                    {
                                        if (itemvalue.fldItemData[i].itemvalue.Trim() != "")
                                        {
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

                                        tblEQIA_RPI_Basedata_Pre objTmp = objData.Clone();
                                        objTmp.fldItemCode = itemvalue.fldItemData[i].itemcode;
                                        objTmp.fldItemValue = dValue;
                                        objTmp.fldCityID_Operate = Int32.Parse(itemvalue.fldCityID_Operate);
                                        objTmp.fldCityID_Submit = itemvalue.fldCityID_Submit;
                                        lstData.Add(objTmp);
                                    }
                                }
                                RuletblEQIA_RPI_Basedata_Pre rule_basedata = new RuletblEQIA_RPI_Basedata_Pre();
                                bool issave = rule_basedata.InsertAll(lstData, inputdate_new);
                                if (issave)
                                {
                                    RuleWriteOperateLog rule_wol = new RuleWriteOperateLog();
                                    rule_wol.WriteLog(0,"录入大气数据到临时表，测点代码：" + itemvalue.fldPCode +
                                        ";时间："+ itemvalue.BeginDate+" "+ itemvalue.EndDate+ ";录入者ID:" + int.Parse(itemvalue.fldUserID),itemvalue.fldUserName,int.Parse(itemvalue.fldUserID),int.Parse(itemvalue.fldCityID_Submit));                             
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
                    "Eqia_rPointInputController", "ItemSave", "");
                result = rule.JsonStr("error", "数据写入数据库失败，" + ex.Message, "");
            }
            catch (Exception ex)
            {
                PageException pagex = new PageException(int.Parse(itemvalue.fldUserID), ex.Message,
                    "Eqia_rPointInputController", "ItemSave", "");
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

            ///// <summary>
            ///// 开始年
            ///// </summary>
            //public string fldSYear { get; set; }

            ///// <summary>
            /////开始月 
            ///// </summary>
            //public string fldSMonth { get; set; }

            ///// <summary>
            ///// 开始日
            ///// </summary>
            //public string fldSDay { get; set; }

            ///// <summary>
            ///// 开始时
            ///// </summary>
            //public string fldSHour { get; set; }

            ///// <summary>
            ///// 开始分
            ///// </summary>
            //public string fldSMinute { get; set; }

            ///// <summary>
            ///// 结束年
            ///// </summary>
            //public string fldEYear { get; set; }

            ///// <summary>
            ///// 结束月
            ///// </summary>
            //public string fldEMonth { get; set; }

            ///// <summary>
            ///// 结束日
            ///// </summary>
            //public string fldEDay { get; set; }

            ///// <summary>
            ///// 结束时
            ///// </summary>
            //public string fldEHour { get; set; }

            ///// <summary>
            ///// 结束分
            ///// </summary>
            //public string fldEMinute { get; set; }

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

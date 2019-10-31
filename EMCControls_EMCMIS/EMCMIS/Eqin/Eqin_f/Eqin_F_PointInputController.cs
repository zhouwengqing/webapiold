using DDYZ.Ensis.Library.Exception.Page.Input;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqin.Eqin_f
{
    /// <summary>
    /// 功能描述：功能区噪声录入数据API
    /// 创建者  ：吕荣誉
    /// 创建日期：2017-7-11
    /// 修改者  ：
    /// 修改日期：
    /// 修改原因：
    /// </summary>
    public class Eqin_F_PointInputController : ApiController
    {

        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述    ：  保存功能区噪声录入数据
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-7-11
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="data">需要保存的实体类</param>
        /// <returns>返回保存是否成功</returns>
        [HttpPost]
        //
        public HttpResponseMessage ItemSave(Eqin_F_SaveData data)
        {
            string result = string.Empty;
            int result2 = 0;
            try
            {

                using (EntityContext db = new EntityContext())
                {







                    foreach (var item in data.InputDatas)
                    {

                        tblEQIN_F_BaseData_Pre objData = new tblEQIN_F_BaseData_Pre();


                        objData.fldSTCode = data.fldSTCode;
                        objData.fldPCode = data.fldPCode;
                        objData.fldYear = Convert.ToDecimal(data.Date.Year);
                        objData.fldMonth = Convert.ToDecimal(data.Date.Month);
                        objData.fldDay = Convert.ToDecimal(data.Date.Day);


                        objData.fldNDISC = data.ddlNDISC;

                        objData.fldHour = Convert.ToDecimal(item.fldHour);



                        objData.fldLEQA = Convert.ToDecimal(item.fldLEQA);
                        objData.fldL10A = Convert.ToDecimal(item.fldL10A);
                        objData.fldL50A = Convert.ToDecimal(item.fldL50A);
                        objData.fldL90A = Convert.ToDecimal(item.fldL90A);
                        objData.fldLmin = Convert.ToDecimal(item.fldLmin);
                        objData.fldLmax = Convert.ToDecimal(item.fldLmax);
                        objData.fldSD = decimal.Parse(item.fldSD);



                        objData.fldFlag = 0;
                        objData.fldCityID_Operate = int.Parse(data.fldCityID_Operate);
                        objData.fldCityID_Submit = data.fldCityID_Submit;
                        objData.fldDate_Operate = DateTime.Now;
                        objData.fldUserID = int.Parse(data.fldUserID);
                        objData.fldMph = decimal.Parse(data.Mph);
                        objData.fldApparatus_Type = data.Apparatus_Type;
                        objData.fldApparatus_Id = data.Apparatus_Id;
                        objData.fldSource = 0;
                        objData.fldBatch = "0";
                        objData.fldSPressureType = "0";
                        objData.fldSPressureID = "0";



                        if (data.Apparatus_Grade == "I")
                        {
                            objData.fldApparatus_Grade = true;
                        }
                        else if (data.Apparatus_Grade == "II")
                        {
                            objData.fldApparatus_Grade = false;
                        }

                        db.tblEQIN_F_BaseData_Pre.Add(objData);



                    }


                    result2 = db.SaveChanges();




                }














                //RuletblEQIN_F_Basedata_Pre rule_basedata = new RuletblEQIN_F_Basedata_Pre();
                //bool issave = rule_basedata.InsertAll(lstData);


                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "保存成功！", "");
                }
                else
                {
                    result = rule.JsonStr("no", "保存失败！", "");
                }










            }
            catch (InputException ex)
            {
                result = rule.JsonStr("error", "数据保存失败，" + ex.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能区噪声录入实体
        /// </summary>
        public class Eqin_F_SaveData
        {
            /// <summary>
            /// 输入数值组
            /// </summary>
            public List<InputData> InputDatas { get; set; }

            /// <summary>
            /// 日期
            /// </summary>
            public DateTime Date { get; set; }

            /// <summary>
            /// 用户ID
            /// </summary>
            public string fldUserID { get; set; }

            /// <summary>
            /// 用户名
            /// </summary>
            public string fldUserName { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldCityID_Operate { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldCityID_Submit { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldSTCode { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldCountyCode { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldPCode { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Mph { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Apparatus_Type { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Apparatus_Id { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Apparatus_Grade { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string ddlNDISC { get; set; }


            public int fldSource { get; set; }

        }


        /// <summary>
        /// 因子值类
        /// </summary>
        public class InputData
        {
            /// <summary>
            /// 
            /// </summary>
            public string fldHour { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldLEQA { get; set; }


            /// <summary>
            /// 
            /// </summary>
            public string fldL10A { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldL50A { get; set; }


            /// <summary>
            /// 
            /// </summary>
            public string fldL90A { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldLmax { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldLmin { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldSD { get; set; }



        }


    }
}

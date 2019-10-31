using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqib
{
    public class Eqib_SectionInputController : ApiController
    {



        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  保存[生物]录入数据
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-8-17
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="data">需要保存的实体类</param>
        /// <returns>返回保存是否成功</returns>
        [HttpPost]
        //
        public HttpResponseMessage ItemSave(eqiw_dsavedata data)
        {
            string result = string.Empty;
            int result2 = 0;
            try
            {
                using (EntityContext db = new EntityContext())
                {

                    var query = from x in data.fldItemData
                                select x;

                    DateTime time = DateTime.Parse(data.Date);

                    string fldSTCode = null;
                    if (data.fldCountyCode != null)
                    {
                        fldSTCode = data.fldCountyCode;
                    }
                    else
                    {
                        fldSTCode = data.fldSTCode;
                    }

                    foreach (var item in query)
                    {

                        if (data.type == "eqib_czp")
                        {
                            var tbl = new tblEQIBCZPBaseData_Pre()
                            {
                                fldPCode = item.fldPCode,
                                fldCTypeCode = item.fldCTypeCode,
                                fldWaterTyoe = item.fldWaterTyoe,
                                fldPickVolume = decimal.Parse(item.fldPickVolume),
                                fldConcentrate = decimal.Parse(item.fldConcentrate),
                                fldDensity = decimal.Parse(item.fldDensity),


                                fldYear = time.Year,
                                fldMonth = time.Month,
                                fldDay = time.Day,
                                fldHour = time.Hour,
                                fldMinute = time.Minute,
                                fldUserID = int.Parse(data.fldUserID),
                                fldCityID_Operate = int.Parse(data.fldCityID_Operate),
                                fldCityID_Submit = data.fldCityID_Submit,
                                fldSTCode = fldSTCode,
                                fldFlag = 0,
                                fldImport = "0",
                                fldDate_Operate = DateTime.Now,
                                fldBatch = "0",
                                fldSource = 0,
                                fldRCode = data.fldRCode,
                                fldRSCode = data.fldRSCode,
                                fldSAMPH = data.fldSAMPH,
                                fldSAMPR = data.fldSAMPR,
                                fldRSC = data.fldRSC,
                                fldTypeCode = "无值"
                            };
                            db.tblEQIBCZPBaseData_Pre.Add(tbl);

                        }
                        else if (data.type == "eqib_czc")
                        {
                            var tbl = new tblEQIBCZCBaseData_Pre()
                            {
                                fldPCode = item.fldPCode,
                                fldCTypeCode = item.fldCTypeCode,
                                fldNetTyoe = item.fldNetTyoe,
                                fldPickVolume = decimal.Parse(item.fldPickVolume),
                                fldConcentrate = decimal.Parse(item.fldConcentrate),
                                fldDensity = decimal.Parse(item.fldDensity),


                                fldYear = time.Year,
                                fldMonth = time.Month,
                                fldDay = time.Day,
                                fldHour = time.Hour,
                                fldMinute = time.Minute,
                                fldUserID = int.Parse(data.fldUserID),
                                fldCityID_Operate = int.Parse(data.fldCityID_Operate),
                                fldCityID_Submit = data.fldCityID_Submit,
                                fldSTCode = fldSTCode,
                                fldFlag = 0,
                                fldImport = "0",
                                fldDate_Operate = DateTime.Now,
                                fldBatch = "0",
                                fldSource = 0,
                                fldRCode = data.fldRCode,
                                fldRSCode = data.fldRSCode,
                                fldSAMPH = data.fldSAMPH,
                                fldSAMPR = data.fldSAMPR,
                                fldRSC = data.fldRSC,
                                fldTypeCode = "无值"
                            };
                            db.tblEQIBCZCBaseData_Pre.Add(tbl);

                        }
                        else if (data.type == "eqib_cd")
                        {
                            var tbl = new tblEQIBCDBaseData_Pre()
                            {
                                fldPCode = item.fldPCode,
                                fldCTypeCode = item.fldCTypeCode,
                                fldAcreage = decimal.Parse(item.fldAcreage),
                                fldAmount = decimal.Parse(item.fldAmount),
                                fldDensity = decimal.Parse(item.fldDensity),


                                fldYear = time.Year,
                                fldMonth = time.Month,
                                fldDay = time.Day,
                                fldHour = time.Hour,
                                fldMinute = time.Minute,
                                fldUserID = int.Parse(data.fldUserID),
                                fldCityID_Operate = int.Parse(data.fldCityID_Operate),
                                fldCityID_Submit = data.fldCityID_Submit,
                                fldSTCode = fldSTCode,
                                fldFlag = 0,
                                fldImport = "0",
                                fldDate_Operate = DateTime.Now,
                                fldBatch = "0",
                                fldSource = 0,
                                fldRCode = data.fldRCode,
                                fldRSCode = data.fldRSCode,
                                fldSAMPH = data.fldSAMPH,
                                fldSAMPR = data.fldSAMPR,
                                fldRSC = data.fldRSC,
                                fldTypeCode = "无值"
                            };
                            db.tblEQIBCDBaseData_Pre.Add(tbl);

                        }
                        else if (data.type == "eqib_cwc")
                        {
                            var tbl = new tblEQIBCWCBaseData_Pre()
                            {
                                fldPCode = item.fldPCode,
                                fldCTypeCode = item.fldCTypeCode,
                                fldAcreage = decimal.Parse(item.fldAcreage),
                                fldDensity = decimal.Parse(item.fldDensity),


                                fldYear = time.Year,
                                fldMonth = time.Month,
                                fldDay = time.Day,
                                fldHour = time.Hour,
                                fldMinute = time.Minute,
                                fldUserID = int.Parse(data.fldUserID),
                                fldCityID_Operate = int.Parse(data.fldCityID_Operate),
                                fldCityID_Submit = data.fldCityID_Submit,
                                fldSTCode = fldSTCode,
                                fldFlag = 0,
                                fldImport = "0",
                                fldDate_Operate = DateTime.Now,
                                fldBatch = "0",
                                fldSource = 0,
                                fldRCode = data.fldRCode,
                                fldRSCode = data.fldRSCode,
                                fldSAMPH = data.fldSAMPH,
                                fldSAMPR = data.fldSAMPR,
                                fldRSC = data.fldRSC,
                                fldTypeCode = "无值"
                            };
                            db.tblEQIBCWCBaseData_Pre.Add(tbl);

                        }
                        else if (data.type == "eqib_cwp")
                        {
                            var tbl = new tblEQIBCWPBaseData_Pre()
                            {
                                fldPCode = item.fldPCode,
                                fldCTypeCode = item.fldCTypeCode,
                                fldDilution = decimal.Parse(item.fldDilution),
                                fldDensity = decimal.Parse(item.fldDensity),


                                fldYear = time.Year,
                                fldMonth = time.Month,
                                fldDay = time.Day,
                                fldHour = time.Hour,
                                fldMinute = time.Minute,
                                fldUserID = int.Parse(data.fldUserID),
                                fldCityID_Operate = int.Parse(data.fldCityID_Operate),
                                fldCityID_Submit = data.fldCityID_Submit,
                                fldSTCode = fldSTCode,
                                fldFlag = 0,
                                fldImport = "0",
                                fldDate_Operate = DateTime.Now,
                                fldBatch = "0",
                                fldSource = 0,
                                fldRCode = data.fldRCode,
                                fldRSCode = data.fldRSCode,
                                fldSAMPH = data.fldSAMPH,
                                fldSAMPR = data.fldSAMPR,
                                fldRSC = data.fldRSC,
                                fldTypeCode = "无值"
                            };
                            db.tblEQIBCWPBaseData_Pre.Add(tbl);

                        }






                    }














                    result2 = db.SaveChanges();
                }

                if (result2 > 0)
                {
                    result = rule.JsonStr("ok", "保存成功！", "");
                }
                else
                {
                    result = rule.JsonStr("no", "保存失败！", "");
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "数据保存失败，" + e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 录入实体
        /// </summary>
        public class eqiw_dsavedata
        {

            public string type { get; set; }

            /// <summary>
            /// 监测值数组
            /// </summary>
            public List<itemvalueData> fldItemData { get; set; }

            /// <summary>
            /// 时间
            /// </summary>
            public string Date { get; set; }

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
            /// 水期代码
            /// </summary>
            public string fldRSC { get; set; }




            public string fldRCode { get; set; }

            public string fldRSCode { get; set; }

            public string fldSAMPH { get; set; }
            public string fldSAMPR { get; set; }

        }

        /// <summary>
        /// 因子值类
        /// </summary>
        public class itemvalueData
        {
            public string fldPCode { get; set; }

            public string fldCTypeCode { get; set; }

            public string fldWaterTyoe { get; set; }

            public string fldPickVolume { get; set; }

            public string fldConcentrate { get; set; }

            public string fldDensity { get; set; }

            public string fldNetTyoe { get; set; }

            public string fldAcreage { get; set; }

            public string fldAmount { get; set; }

            public string fldDilution { get; set; }
        }












    }
}

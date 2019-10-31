
using DDYZ.Ensis.Library.Exception.Page.Input;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqiso
{

    /// <summary>
    /// 功能描述    ：  保存[土壤]录入数据
    /// 创建者      ：  吕荣誉
    /// 创建日期    ：  2017-8-17
    /// 修改者      ：   
    /// 修改日期    ：   
    /// 修改原因    ： 
    /// </summary>
    public class Eqiso_PointInputController : ApiController
    {


        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  保存[土壤]录入数据
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

                    DateTime time = DateTime.Parse(data.BeginDate);

                    foreach (var item in query)
                    {
                        var tbl = new tblEQISO_Basedata_Pre()
                        {
                            fldItemCode = item.itemcode,
                            fldItemValue = decimal.Parse(item.itemvalue),
                            fldYear = time.Year,
                            fldMonth = time.Month,
                            fldDay = time.Day,
                            fldHour = time.Hour,
                            fldMinute = time.Minute,
                            fldUserID = int.Parse(data.fldUserID),
                            fldCityID_Operate = int.Parse(data.fldCityID_Operate),
                            fldCityID_Submit = data.fldCityID_Submit,
                            fldSTCode = data.fldCountyCode,
                            fldPCode = data.fldPCode,
                            fldSampleType = -1,
                            fldSamplingPerson = "-1",
                            fldSamplingWeather = "-1",
                            fldEntCode = data.fldEntCode,
                            fldFlag = 0,
                            fldImport = 0,
                            fldDate_Operate = DateTime.Now,
                            fldBatch = "0",
                            fldSource = 0
                        };
                        db.tblEQISO_Basedata_Pre.Add(tbl);
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
            /// 类型
            /// </summary>
            public string fldSampleType { get; set; }

            /// <summary>
            /// 水期代码
            /// </summary>
            public string fldRSC { get; set; }


            public string fldSamplingPerson { get; set; }



            public string fldSamplingWeather { get; set; }


            public string fldEntCode { get; set; }

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

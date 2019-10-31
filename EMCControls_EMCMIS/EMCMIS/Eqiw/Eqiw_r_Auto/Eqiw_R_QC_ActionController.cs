using DDYZ.Ensis.Rule.DataRule;
using EMCControls_EMCMIS.EMCMIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_r_Auto
{
    public class Eqiw_R_QC_ActionController : ApiController
    {

        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-14
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Input_tblEQIW_R_Basedata_Pre_Week_QC(Input_tblEQIW_R_Basedata_Pre_Week_QC_Info info)
        {
            string result = string.Empty;
            int datacount = 0;
            try
            {
                List<tblEQIW_R_Basedata_Pre_Week_QC> list = new List<tblEQIW_R_Basedata_Pre_Week_QC>();
                tblEQIW_R_Basedata_Pre_Week_QC qc = new tblEQIW_R_Basedata_Pre_Week_QC();
                qc.fldAutoID = info.fldAutoID;
                qc.fldSTCode = info.fldSTCode;
                qc.fldRCode = info.fldRCode;
                qc.fldRSCode = info.fldRSCode;
                qc.fldSAMPH = info.fldSAMPH;
                qc.fldSAMPR = info.fldSAMPR;
                qc.fldRSC = info.fldRSC;
                qc.fldDate = info.fldDate;
                qc.fldItemCode = info.fldItemCode;
                qc.fldItemValue = info.fldItemValue;
                qc.fldActualValue = info.fldActualValue;
                qc.fldFlag = info.fldFlag;
                qc.fldImport = info.fldImport;
                qc.fldCityID_Operate = info.fldCityID_Operate;
                qc.fldCityID_Submit = info.fldCityID_Submit;
                qc.fldDate_Operate = info.fldDate_Operate;
                qc.fldUserID = info.fldUserID;
                qc.fldSource = info.fldSource;
                qc.fldBatch = info.fldBatch;
                qc.fldDeleteState = info.fldDeleteState;

                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_R_Basedata_Pre_Week_QC.Add(qc);
                    datacount = db.SaveChanges();
                }


                if (datacount > 0)
                {
                    result = rule.JsonStr("ok", "", datacount);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有保存数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 参数实体
        /// </summary>
        public class Input_tblEQIW_R_Basedata_Pre_Week_QC_Info
        {
            public long fldAutoID { get; set; }

            public string fldSTCode { get; set; }

            public string fldRCode { get; set; }

            public string fldRSCode { get; set; }

            public string fldSAMPH { get; set; }

            public string fldSAMPR { get; set; }

            public string fldRSC { get; set; }

            public DateTime? fldDate { get; set; }

            public string fldItemCode { get; set; }

            public decimal fldItemValue { get; set; }

            public decimal fldActualValue { get; set; }

            public short fldFlag { get; set; }

            public short fldImport { get; set; }

            public int fldCityID_Operate { get; set; }

            public string fldCityID_Submit { get; set; }

            public DateTime fldDate_Operate { get; set; }

            public int fldUserID { get; set; }

            public short fldSource { get; set; }

            public string fldBatch { get; set; }

            public int fldDeleteState { get; set; }

        }









        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-14
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Query_tblEQIW_R_Basedata_Pre_Week_QC(Query_tblEQIW_R_Basedata_Pre_Week_QC_Info info)
        {
            string result = string.Empty;
            try
            {
                List<vwtblEQIW_R_Basedata_Pre_Week_QC> list = new List<vwtblEQIW_R_Basedata_Pre_Week_QC>();

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                using (EntityContext db = new EntityContext())
                {
                    if (info.fldSTCode != "-1")
                    {
                        list = (from x in db.vwtblEQIW_R_Basedata_Pre_Week_QC
                                where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                x.fldDate >= BeginDate && x.fldDate <= EndDate &&
                                info.fldItemCode.Contains(x.fldItemCode)
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.vwtblEQIW_R_Basedata_Pre_Week_QC
                                select x).ToList();
                    }
                }
                foreach (var item in list)
                {
                    decimal result2 = (item.fldActualValue - item.fldItemValue) / item.fldItemValue * 100;
                    item.RelativeError = result2.ToString("f2")+"%";
                    if (Math.Abs(result2) <= 10)
                    {
                        item.IsReachTheStandard = "是";
                    }
                    else
                    {
                        item.IsReachTheStandard = "否";
                    }
                }
                if (list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 参数实体
        /// </summary>
        public class Query_tblEQIW_R_Basedata_Pre_Week_QC_Info
        {
            public string fldSTCode { get; set; }

            public string fldBeginDate { get; set; }

            public string fldEndDate { get; set; }

            public List<string> fldItemCode { get; set; }

        }




















        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-14
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Input_tblEQIW_R_Basedata_Pre_Month_QC(Input_tblEQIW_R_Basedata_Pre_Month_QC_Info info)
        {
            string result = string.Empty;
            int datacount = 0;
            try
            {
                List<tblEQIW_R_Basedata_Pre_Month_QC> list = new List<tblEQIW_R_Basedata_Pre_Month_QC>();
                tblEQIW_R_Basedata_Pre_Month_QC qc = new tblEQIW_R_Basedata_Pre_Month_QC();

                qc.fldAutoID = info.fldAutoID;
                qc.fldSTCode = info.fldSTCode;
                qc.fldRCode = info.fldRCode;
                qc.fldRSCode = info.fldRSCode;
                qc.fldSAMPH = info.fldSAMPH;
                qc.fldSAMPR = info.fldSAMPR;
                qc.fldRSC = info.fldRSC;
                qc.fldDate = info.fldDate;
                qc.fldItemCode = info.fldItemCode;
                qc.fldItemValue = info.fldItemValue;
                qc.fldActualValue = info.fldActualValue;
                qc.fldFlag = info.fldFlag;
                qc.fldImport = info.fldImport;
                qc.fldCityID_Operate = info.fldCityID_Operate;
                qc.fldCityID_Submit = info.fldCityID_Submit;
                qc.fldDate_Operate = info.fldDate_Operate;
                qc.fldUserID = info.fldUserID;
                qc.fldSource = info.fldSource;
                qc.fldBatch = info.fldBatch;
                qc.fldDeleteState = info.fldDeleteState;

                using (EntityContext db = new EntityContext())
                {
                    db.tblEQIW_R_Basedata_Pre_Month_QC.Add(qc);
                    datacount = db.SaveChanges();
                }


                if (datacount > 0)
                {
                    result = rule.JsonStr("ok", "", datacount);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有保存数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 参数实体
        /// </summary>
        public class Input_tblEQIW_R_Basedata_Pre_Month_QC_Info
        {
            public long fldAutoID { get; set; }

            public string fldSTCode { get; set; }

            public string fldRCode { get; set; }

            public string fldRSCode { get; set; }

            public string fldSAMPH { get; set; }

            public string fldSAMPR { get; set; }

            public string fldRSC { get; set; }

            public DateTime? fldDate { get; set; }

            public string fldItemCode { get; set; }

            public decimal fldItemValue { get; set; }

            public decimal fldActualValue { get; set; }

            public short fldFlag { get; set; }

            public short fldImport { get; set; }

            public int fldCityID_Operate { get; set; }

            public string fldCityID_Submit { get; set; }

            public DateTime fldDate_Operate { get; set; }

            public int fldUserID { get; set; }

            public short fldSource { get; set; }

            public string fldBatch { get; set; }

            public int fldDeleteState { get; set; }

        }










































        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-14
        /// 功能描述：
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Query_tblEQIW_R_Basedata_Pre_Month_QC(Query_tblEQIW_R_Basedata_Pre_Month_QC_Info info)
        {
            string result = string.Empty;
            try
            {
                List<vwtblEQIW_R_Basedata_Pre_Month_QC> list = new List<vwtblEQIW_R_Basedata_Pre_Month_QC>();

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                using (EntityContext db = new EntityContext())
                {

                    if (info.fldSTCode != "-1")
                    {
                        list = (from x in db.vwtblEQIW_R_Basedata_Pre_Month_QC
                                where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                DateTime.Parse(x.fldDate) >= BeginDate && DateTime.Parse(x.fldDate) <= EndDate &&
                                info.fldItemCode.Contains(x.fldItemCode)
                                select x).ToList();
                    }
                    else
                    {
                        list = (from x in db.vwtblEQIW_R_Basedata_Pre_Month_QC
                                select x).ToList();
                    }
                }




                foreach (var item in list)
                {
                    decimal result2 = (item.fldActualValue - item.fldItemValue) / item.fldItemValue * 100;


                    item.RelativeError = result2.ToString("f2")+"%";


                    if (Math.Abs(result2) <= 10)
                    {
                        item.IsReachTheStandard = "是";
                    }
                    else
                    {
                        item.IsReachTheStandard = "否";
                    }
                }



                if (list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 参数实体
        /// </summary>
        public class Query_tblEQIW_R_Basedata_Pre_Month_QC_Info
        {
            public string fldSTCode { get; set; }

            public string fldBeginDate { get; set; }

            public string fldEndDate { get; set; }

            public List<string> fldItemCode { get; set; }

        }
















    }
}

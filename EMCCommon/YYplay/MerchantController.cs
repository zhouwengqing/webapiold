using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EMCCommon.Mode;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.EMCCommon.AccountController.WebApiCore;
using System.Data.Entity;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using EMCCommon.DateRule;

namespace EMCCommon.YYplay
{
    /// <summary>
    /// 商户表的相关操作
    /// </summary>
    public class MerchantController : ApiController
    {
        RuleCommon rule = new RuleCommon();



        /// <summary>
        /// 功能描述：获得所有的商户列表
        /// 创建  人：周文卿
        /// 创建时间：20181029
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SupportFilter]
        public HttpResponseMessage GetMerchantList(int page, int limit, string where, string sort)
        {
            string result = string.Empty;
            try
            {


                using (YYPlayContext db = new YYPlayContext())
                {
                    int count = 0;
                    //查询分页的数据
                    DataTable dt = rule.getpaging("tbleMerchant", "[fldAutoID],[fldMerchID],[fldMerchName],[fldContacts],[fldPhone],[fldCreateTime],[fldIPaddress],[fldIdCare],[fldAgent],[fldRemark],fldisstand", "1=1" + where, page, limit, sort, out count);
                    getdata getdatas = new getdata();
                    getdatas.total = count;
                    getdatas.Table = dt;
                    //查询所有的数据  用于前端筛选
                    List<tbleMerchant> tbleMerchants = (from x in db.tbleMerchant select x).ToList();
                    getdatas.tbleMerchants = tbleMerchants;
                    if (getdatas != null)
                    {
                        result = rule.JsonStr("ok", "", getdatas);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "无数据！", getdatas);
                    }
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：获得所有的商户列表（不分页）
        /// 创建  人：周文卿
        /// 创建时间：20181029
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage GetMerchantAllList()
        {
            string result = string.Empty;
            try
            {


                using (YYPlayContext db = new YYPlayContext())
                {



                    getdata getdatas = new getdata();

                    //查询所有的数据 
                    var tbleMerchants = db.tbleMerchant.Select(x => new { x.fldMerchName, x.fldMerchID }).ToList();

                    if (getdatas != null)
                    {
                        result = rule.JsonStr("ok", "", tbleMerchants);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "无数据！", getdatas);
                    }
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：验证商户是否存在
        /// 创建  人：周文卿
        /// 创建时间：20181029
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SupportFilter]
        public HttpResponseMessage VerificationMerchant(string MerchantID)
        {
            string result = string.Empty;
            try
            {


                using (YYPlayContext db = new YYPlayContext())
                {



                    getdata getdatas = new getdata();

                    //查询所有的数据 
                    List<tbleMerchant> tbleMerchants = (from x in db.tbleMerchant
                                                        where x.fldMerchID == MerchantID
                                                        select x).ToList();

                    if (tbleMerchants.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", "");
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "无数据！", "");
                    }
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：新增商户
        /// 创建  人：周文卿
        /// 创建时间：20181031
        /// </summary>
        /// <param name="tbleMerchantpram"></param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage AddDMerchantList(pram tbleMerchantpram)
        {
            string result = string.Empty;
            try
            {
                using (YYPlayContext db = new YYPlayContext())
                {
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

                    Random random = new Random();
                    string nowid = "100" + random.Next(100, 1000); ;

                    tbleMerchant maxid = (from x in db.tbleMerchant
                                          orderby x.fldMerchID descending
                                          select x).FirstOrDefault();
                  
                    RulePayBehavior rulePay = new RulePayBehavior();
                    string fldSecretKey = Guid.NewGuid().ToString("N").ToUpper();
                    tbleMerchant info = new tbleMerchant();
                    info.fldMerchID = nowid.ToString();//当前时间加上身份证后四位组成商户ID
                    info.fldMerchName = tbleMerchantpram.fldMerchName;
                    info.fldCreateTime = DateTime.Now;
                    info.fldIdCare = tbleMerchantpram.fldIdCare;
                    info.fldIPaddress = tbleMerchantpram.fldIPaddress;
                    info.fldMaPass = rulePay.EncryptionMd5(tbleMerchantpram.fldIdCare.Substring(tbleMerchantpram.fldIdCare.Length - 6, 6), "x2");//身份证后6位，为初始密码
                    info.fldPhone = tbleMerchantpram.fldPhone;
                    info.fldRemark = "";
                    info.fldPayPass = rulePay.EncryptionMd5(DateTime.Now.Year + tbleMerchantpram.fldIdCare.Substring(tbleMerchantpram.fldIdCare.Length - 6, 6), "x2");
                    info.fldContacts = tbleMerchantpram.fldContacts;
                    info.fldAgent = tbleMerchantpram.fldAgent;
                    info.fldSecretKey = fldSecretKey;

                    db.tbleMerchant.Add(info);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "添加失败！", ret);
                    }
                    else
                    {
                        int count = 0;
                        DataTable dt = rule.getpaging("tbleMerchant", "[fldAutoID],[fldMerchID],[fldMerchName],[fldContacts],[fldPhone],[fldCreateTime],[fldIPaddress],[fldIdCare],[fldAgent],[fldRemark],fldisstand", "1=1" + tbleMerchantpram.where, tbleMerchantpram.page, tbleMerchantpram.limit, tbleMerchantpram.sort, out count);

                        getdata getdatas = new getdata();
                        getdatas.total = count;
                        getdatas.Table = dt;
                        //查询所有的数据  用于前端筛选
                        List<tbleMerchant> tbleMerchants = (from x in db.tbleMerchant select x).ToList();
                        getdatas.tbleMerchants = tbleMerchants;
                        result = rule.JsonStr("ok", "", getdatas);
                    }
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：重置密码
        /// 创建  人：周文卿
        /// 创建时间：20181107
        /// </summary>
        /// <param name="marehid"></param>
        /// <returns></returns>
        [HttpGet]
        [SupportFilter]
        public HttpResponseMessage Resetpassword(string marehid)
        {
            string result = string.Empty;
            try
            {

                using (YYPlayContext db = new YYPlayContext())
                {
                    RulePayBehavior rulePay = new RulePayBehavior();
                    tbleMerchant info = (from c in db.tbleMerchant
                                         where c.fldMerchID == marehid
                                         select c).Single();
                    info.fldMaPass = rulePay.EncryptionMd5(info.fldIdCare.Substring(info.fldIdCare.Length - 6, 6));//身份证后6位，为初始密码
                    int ret = db.SaveChanges();
                    if (ret < 0)
                    {
                        result = rule.JsonStr("error", "重置失败！", ret);
                    }
                    else
                    {

                        result = rule.JsonStr("ok", "", ret);
                    }
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：重置支付密码
        /// 创建  人：周文卿
        /// 创建时间：20181229
        /// </summary>
        /// <param name="marehid"></param>
        /// <returns></returns>
        [HttpGet]
        [SupportFilter]
        public HttpResponseMessage Resetpaypassword(string marehid)
        {
            string result = string.Empty;
            try
            {

                using (YYPlayContext db = new YYPlayContext())
                {
                    RulePayBehavior rulePay = new RulePayBehavior();
                    tbleMerchant info = (from c in db.tbleMerchant
                                         where c.fldMerchID == marehid
                                         select c).Single();
                    info.fldPayPass = rulePay.EncryptionMd5(DateTime.Now.Year + info.fldIdCare.Substring(info.fldIdCare.Length - 6, 6), "x2"); //身份证后6位，为初始密码
                    int ret = db.SaveChanges();
                    if (ret < 0)
                    {
                        result = rule.JsonStr("error", "重置失败！", ret);
                    }
                    else
                    {

                        result = rule.JsonStr("ok", "", ret);
                    }
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：修改商户
        /// 创建  人：周文卿
        /// 创建时间：20181031
        /// </summary>
        /// <param name="prams"></param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage UpdateMerchantList(pram prams)
        {
            string result = string.Empty;
            try
            {

                using (YYPlayContext db = new YYPlayContext())
                {
                    tbleMerchant info = (from c in db.tbleMerchant
                                         where c.fldAutoID == prams.fldAutoID
                                         select c).Single();
                    info.fldMerchName = prams.fldMerchName;
                    info.fldIdCare = prams.fldIdCare;
                    info.fldIPaddress = prams.fldIPaddress;
                    info.fldPhone = prams.fldPhone;
                    info.fldRemark = "";
                    info.fldContacts = prams.fldContacts;
                    info.fldAgent = prams.fldAgent;
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "更新失败！", ret);
                    }
                    else
                    {

                        result = rule.JsonStr("ok", "", info);
                    }
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 参数
        /// </summary>
        public class pram
        {

            /// <summary>
            /// ID
            /// </summary>
            public int fldAutoID { get; set; }

            /// <summary>
            /// 商户ID
            /// </summary>
            public string fldMerchID { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public string fldCreateTime { get; set; }

            /// <summary>
            /// 身份证
            /// </summary>
            public string fldIdCare { get; set; }

            /// <summary>
            /// 公司名称
            /// </summary>
            public string fldMerchName { get; set; }

            /// <summary>
            /// IP地址
            /// </summary>
            public string fldIPaddress { get; set; }

            /// <summary>
            /// 联系人
            /// </summary>
            public string fldContacts { get; set; }

            /// <summary>
            /// 联系人电话
            /// </summary>
            public string fldPhone { get; set; }

            /// <summary>
            /// 代理
            /// </summary>
            public string fldAgent { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            public string fldRemark { get; set; }

            /// <summary>
            /// 查询条件
            /// </summary>
            public string where { get; set; }

            /// <summary>
            /// 当前页数
            /// </summary>
            public int page { get; set; }

            /// <summary>
            /// 每页数
            /// </summary>
            public int limit { get; set; }

            /// <summary>
            /// 排序
            /// </summary>
            public string sort { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class getdata
        {
            /// <summary>
            /// 总数
            /// </summary>
            public int total { get; set; }

            /// <summary>
            /// 数据
            /// </summary>
            public DataTable Table { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public List<tbleMerchant> tbleMerchants { get; set; }
        }
    }
}

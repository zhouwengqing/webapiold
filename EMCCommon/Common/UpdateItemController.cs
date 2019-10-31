using DDYZ.Ensis.Rule.DataRule;
using DDYZ.Ensis.Presistence.DataEntity;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace EMCCommon.Common
{
    /// <summary>
    /// 临时表更新因子值的控制器
    /// </summary>
    public class UpdateItemController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        RuleEQICommon_Auditing ruleAuditing = new RuleEQICommon_Auditing();

        string strLocalpath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/TypeBaseData.json");//配置的json文件地址

        /// <summary>
        /// 功能描述：更新因子
        /// 创建者  ：吕荣誉
        /// 创建日期：2017-7-13
        /// 修改者  ：熊瑞竹
        /// 修改日期：2018-1-23
        /// 修改原因：
        /// 修改者  ：周文卿
        /// 修改日期：2018-1-29
        /// 修改原因：新增因子修改记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage UpdateItem(dynamic obj)
        {
            string result = string.Empty;
            try
            {
                string getjson = rule.GetJson(strLocalpath);
                long index = 0;

                JArray jsonObj = JArray.Parse(getjson);

                var tablename = (from x in jsonObj
                                 where x["type"].ToString() == obj.type.ToString()
                                 select x).FirstOrDefault();

                RuletblItem_Recording it = new RuletblItem_Recording();

                tblItem_Recording item_Recording = new tblItem_Recording();
                string itemcode = "101^141^106^108^105^107";
                // 如果是大气业务，并且在上述因子中，那么做除以1000的操作
                if (obj.type == "eqia_r")
                {
                    if (itemcode.Contains(obj.flditemcode.ToString()))
                    {
                        obj.fldItemValue = (double.Parse(obj.fldItemValue.ToString()) / 1000).ToString();
                    }
                }

                bool result2 = false;
                if (obj.fldRSInfo != null)
                {
                     result2 = rule.UpdateitemAndRemark(obj.fldAutoid.ToString(), obj.flditemcode.ToString(), obj.fldItemValue.ToString(), tablename["tablenamepre"].ToString(), obj.fldSource.ToString(), obj.fldRSInfo.ToString(), obj.fldDate.ToString(), obj.fldRemark.ToString(), obj.fldObject.ToString());
                }
                else
                {
                    result2 = rule.Updateitem(obj.fldAutoid.ToString(), obj.flditemcode.ToString(), obj.fldItemValue.ToString(), tablename["tablenamepre"].ToString());
                }
                if (result2)
                {






                    if (obj.isitem == "y")
                    {
                        item_Recording.fldRange = obj.fldRSInfo + "|" + obj.flditemcode;
                        item_Recording.fldType = obj.type.ToString();
                        item_Recording.fldDate = obj.fldDate.ToString();
                        index = it.Insert(item_Recording);
                    }
                    if (index > 0)
                    {
                        result = rule.JsonStr("ok", "", "修改成功");
                    }
                    else
                    {
                        result = rule.JsonStr("ok", "", "记录因子值记录失败！");
                    }
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

    }
}

using System;
using System.Net.Http;
using System.Web.Http;
using DDYZ.Ensis.Rule.DataRule;
using System.Data;

using Newtonsoft.Json.Linq;

namespace EMCCommon.Common
{
    /// <summary>
    /// 过滤条件相关
    /// 创建时间：2017/06/14
    /// 创建人：周文卿
    /// 
    /// </summary>
    public class FilterController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        string strLocalpath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/Filter.json");//配置的json文件地址

        /// <summary>
        /// 功能描述：根据业务得到选择过滤条件
        /// 创建时间：2017/06/15
        /// 创建  人：周文卿
        /// 修改时间：2017/07/05
        /// 修改  人：熊瑞竹
        /// 修改原因：
        /// </summary>
        /// <param name="type">类别</param>
        /// <param name="jsonname">json文件名</param>
        /// <returns>json(status(状态),msg(提示信息),data格式（数据,[{"name":"按测点级别","value":"fldPLevel","dictionaries":"测点级别"}]）)</returns>
        /// 
        //[SupportFilter]
        [HttpGet]
        public HttpResponseMessage GetCondition(string type)
        {
            if (type.Contains(",") == true)
            {
                if (type.Split(',')[1] != "")
                {
                    string strLocalpathother = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/" + type.Split(',')[1] + ".json");//配置的json文件地址
                    strLocalpath = strLocalpathother;
                }
            }
            string returntxt = "";
            try
            {
                string getjson = rule.GetJson(strLocalpath);//json配置文件转换
                JArray jsonObj = JArray.Parse(getjson);
                for (int i = 0; i < jsonObj.Count; i++)
                {
                    string typemodel = jsonObj[i]["type"].ToString();
                    if (type.Split(',')[0] == typemodel)
                    {
                        JArray jsonObjs = JArray.Parse(jsonObj[i]["condition"].ToString());
                        JArray jsonend = JArray.Parse(jsonObjs[0]["one"].ToString());//配置每次的第一个，索引为0
                        returntxt = rule.JsonStr("ok", "", jsonend);
                    }
                }
            }
            catch (Exception e)
            {
                returntxt = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：根据业务和过滤条件 得到条件名称
        /// 创建时间：2017/06/14
        /// 创建  人：周文卿
        /// 修改时间：2017/07/06
        /// 修改  人：熊瑞竹
        /// 修改原因：
        /// </summary>
        /// <param name="type">类别</param>
        /// <param name="field">过滤的条件</param>
        /// <returns>josn(status(状态)，data(数据，"data":[{"label":"全部","value":-1}])，msg(提示信息))</returns>
        /// 
        //[SupportFilter]
        [HttpGet]
        public HttpResponseMessage GetFilter(string type, string field)
        {
            string returntxt = "";
            string strsql = "";
            if (type.Contains(",") == true)
            {
                if (type.Split(',')[1] != "")
                {
                    string strLocalpathother = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/" + type.Split(',')[1] + ".json");//配置的json文件地址
                    strLocalpath = strLocalpathother;//这个操作是为了区分各个系统 以防更改了河北的配置导致重庆的也一同更改了
                }
            }
            DataTable dt = new DataTable();
            try
            {
                string getjson = rule.GetJson(strLocalpath);//json配置文件转换
                JArray jsonObj = JArray.Parse(getjson);
                for (int i = 0; i < jsonObj.Count; i++)
                {
                    string typemodel = jsonObj[i]["type"].ToString();
                  
                    if (type.Split(',')[0] == typemodel)
                    {
                        JArray jsonObjs = JArray.Parse(jsonObj[i]["condition"].ToString());
                        JArray jsonend = JArray.Parse(jsonObjs[0]["one"].ToString());
                
                        for (int j = 0; j < jsonend.Count; j++)
                        {
                            if (jsonend[j]["value"].ToString() == field)
                            {
                                string isTranslate = jsonend[j]["istranslate"].ToString();

                                if (isTranslate == "yes")
                                {
                                     dt = rule.GetFiled(jsonObj[i]["table"].ToString(), field, jsonend[j]["dictionaries"].ToString());
                                }
                                else
                                {
                                    strsql = "select distinct " + field + " as 'label'," + field + " as 'value' from " + jsonObj[i]["table"].ToString() + "";
                                     dt = rule.getdt(strsql);
                                }
                                    returntxt = rule.JsonStr("ok", "", dt);
                            }
                        }

                    }
                }
            }
            catch(Exception e)
            {
                returntxt = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(returntxt, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}

using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace EMCCommon.DateRule
{
    /// <summary>
    /// 功能描述：判断请求是否符合规则的方法
    /// 创建时间：2018-11-20
    /// 创建  人：周文卿
    /// </summary>
    public class RulePayBehavior
    {
        string strLocalpath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/requestparameter.json");//配置的json文件地址

        /// <summary>
        /// 反射得到实体类的字段名称和值
        /// var dict = GetProperties(model);
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t">实例化</param>
        /// <returns></returns>
        public Dictionary<string, string> GetProperties<T>(T t)
        {
            var ret = new Dictionary<string, string>();
            if (t == null) { return null; }
            PropertyInfo[] properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (properties.Length <= 0) { return null; }
            foreach (PropertyInfo item in properties)
            {
                string name = item.Name;
                string value = item.GetValue(t, null).ToString();
                if ((item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String")) && name != "Sign")
                {
                    ret.Add(name, value);
                }
            }
            return ret;
        }

        /// <summary>
        /// 反射得到实体类的字段名称和值
        /// var dict = GetProperties(model);
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t">实例化</param>
        /// <returns></returns>
        public Dictionary<object, object> GetPropertiesboj<T>(T t)
        {
            var ret = new Dictionary<object, object>();
            if (t == null) { return null; }
            PropertyInfo[] properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (properties.Length <= 0) { return null; }
            foreach (PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                if ((item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String")))
                {
                    ret.Add(name, value);
                }
            }
            return ret;
        }



        /// <summary>
        /// 获取参数字串
        /// </summary>
        /// <param name="dic">字典</param>
        /// <returns></returns>
        public string GetParamsStr(IDictionary<string, string> dic)
        {
            SortedDictionary<string, string> sortedDic = new SortedDictionary<string, string>(dic);

            StringBuilder builder = new StringBuilder();

            foreach (var kv in sortedDic)
            {
                if (!string.IsNullOrWhiteSpace(kv.Value))
                {
                    builder.Append(kv.Key + "=" + kv.Value + "&");
                }
            }

            return builder.ToString().TrimEnd('&');
        }

        ///// <summary>
        ///// key值base64
        ///// </summary>
        ///// <param name="keyValues"></param>
        ///// <returns></returns>
        //public Dictionary<string, string> stringtoBase4(Dictionary<string, string> keyValues)
        //{

        //}

        /// <summary>
        /// 功能描述： Ascii排序 返回排序后的一个字符(去掉空值)
        /// 创建  人：周文卿
        /// 创建时间：2018-11-15
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public string AsciiDesc(Dictionary<string, string> dict)
        {
            try
            {
                Dictionary<string, string> asciiDic = new Dictionary<string, string>();
                string[] arrKeynew = dict.Keys.ToArray();
                Array.Sort(arrKeynew, string.CompareOrdinal);
                string sing = "";
                foreach (var key in arrKeynew)
                {
                    string value = dict[key];
                    if (dict[key] != null)
                    {
                        //空值不参与签名 去掉空格
                        if (dict[key].ToString().Trim() != "")
                        {
                            sing += key + "=" + dict[key].ToString().Trim() + "&";
                        }
                    }


                }
                return sing;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RulePayMethod", "AsciiDesc", dict.ToString());
            }
        }


        /// <summary>
        /// 功能描述： Ascii排序 返回排序后的一个字符
        /// 创建  人：周文卿
        /// 创建时间：2018-11-15
        /// </summary>
        /// <param name="dict"></param>

        /// <returns></returns>
        public string AsciiDescnotnull(Dictionary<string, string> dict)
        {
            try
            {
                Dictionary<string, string> asciiDic = new Dictionary<string, string>();
                string[] arrKeynew = dict.Keys.ToArray();
                Array.Sort(arrKeynew, string.CompareOrdinal);
                string sing = "";
                foreach (var key in arrKeynew)
                {
                    string value = dict[key];
                    if (dict[key] != null)
                    {

                        sing += key + "=" + dict[key].ToString().Trim() + "&";

                    }


                }
                return sing;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RulePayMethod", "AsciiDesc", dict.ToString());
            }
        }

        /// <summary>
        /// key值转base64
        /// </summary>
        /// <param name="keyValues"></param>
        /// <param name="listkey">要加密的字段</param>
        /// <returns></returns>
        public Dictionary<string, string> stringtobase64(Dictionary<string, string> keyValues, string[] listkey)
        {


            string[] arrKeynew = keyValues.Keys.ToArray();

            for (int i = 0; i < arrKeynew.Length; i++)
            {
                for (int j = 0; j < listkey.Length; j++)
                {
                    if (arrKeynew[i].ToString() == listkey[j])
                    {
                        byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(keyValues[arrKeynew[i]].ToString());
                        string encode = Convert.ToBase64String(bytes);
                        keyValues[arrKeynew[i]] = encode.Replace("+", "%2b");
                    }

                }


            }

            return keyValues;
        }


        /// <summary>
        /// 对象转换为字典
        /// </summary>
        /// <param name="obj">待转化的对象</param>
        /// <param name="isIgnoreNull">是否忽略NULL 这里我不需要转化NULL的值，正常使用可以不穿参数 默认全转换</param>
        /// <returns></returns>
        public Dictionary<string, string> ObjectToMap(object obj, bool isIgnoreNull = false)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();

            Type t = obj.GetType(); // 获取对象对应的类， 对应的类型

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance); // 获取当前type公共属性

            foreach (PropertyInfo p in pi)
            {
                MethodInfo m = p.GetGetMethod();

                if (m != null && m.IsPublic)
                {
                    // 进行判NULL处理 
                    if (m.Invoke(obj, new object[] { }) != null || !isIgnoreNull)
                    {
                        map.Add(p.Name, m.Invoke(obj, new object[] { }).ToString()); // 向字典添加元素
                    }
                }
            }
            return map;
        }


        /// <summary>
        /// Sha1加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Sha1Signature(string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            var data = SHA1.Create().ComputeHash(buffer);
            StringBuilder sub = new StringBuilder();
            foreach (var t in data) { sub.Append(t.ToString("X2")); }
            return sub.ToString();
        }


        /// <summary>
        /// 功能描述：md532位加密(加密为大写)
        /// 创建时间：2018-11-15
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string EncryptionMd5(string str)
        {
            try
            {
                string cl = str;
                string pwd = "";
                MD5 md5 = MD5.Create();//实例化一个md5对像
                                       // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
                byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
                // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
                for (int i = 0; i < s.Length; i++)
                {
                    // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                    pwd = pwd + s[i].ToString("X2");

                }
                return pwd;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RulePayMethod", "EncryptionMd5", str);
            }

        }

        /// <summary>
        /// 功能描述：md532位加密
        /// 创建时间：2018-12-29
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="str">加密的字段</param>
        /// <param name="xup">大小写</param>
        /// <returns></returns>
        public string EncryptionMd5(string str, string xup)
        {
            try
            {
                string cl = str;
                string pwd = "";
                MD5 md5 = MD5.Create();//实例化一个md5对像
                                       // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
                byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
                // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
                for (int i = 0; i < s.Length; i++)
                {
                    // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                    pwd = pwd + s[i].ToString(xup);

                }
                return pwd;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RulePayMethod", "EncryptionMd5", str);
            }

        }

        /// <summary>
        /// 判断金额是否正确
        /// </summary>
        /// <param name="amun"></param>
        /// <returns></returns>
        public bool tryint(string amun)
        {
            try
            {
                decimal trint = decimal.Parse(amun);
                return true;
            }
            catch
            {
                return false;

            }
        }



        /// <summary>
        /// 算法：
        /// 1.每个项权重+1命名为w，防止为0情况。
        /// 2.计算出总权重n。
        /// 3.每个项权重w加上从0到(n-1)的一个随机数（即总权重以内的随机数），得到新的权重排序值s。
        /// 4.根据得到新的权重排序值s进行排序，取前面s最大几个。
        /// </summary>
        /// <param name="list">原始列表</param>
        /// <param name="count">随机抽取条数</param>
        /// <returns></returns>
        public List<tblSubroute> GetRandomList(List<tblSubroute> list, int count)
        {
            if (list == null || list.Count <= count || count <= 0)
            {
                return list;
            }

            //计算权重总和
            int totalWeights = 0;
            for (int i = 0; i < list.Count; i++)
            {
                totalWeights += int.Parse(list[i].fldWeight) + 1;  //权重+1，防止为0情况。
            }

            //随机赋值权重
            Random ran = new Random(GetRandomSeed());  //GetRandomSeed()随机种子，防止快速频繁调用导致随机一样的问题 
            List<KeyValuePair<int, int>> wlist = new List<KeyValuePair<int, int>>();    //第一个int为list下标索引、第一个int为权重排序值
            for (int i = 0; i < list.Count; i++)
            {
                int w = int.Parse(list[i].fldWeight) + ran.Next(0, totalWeights);   // （权重+1） + 从0到（总权重-1）的随机数
                wlist.Add(new KeyValuePair<int, int>(i, w));
            }

            //排序
            wlist.Sort(
              delegate (KeyValuePair<int, int> kvp1, KeyValuePair<int, int> kvp2)
              {
                  return kvp2.Value - kvp1.Value;
              });

            //根据实际情况取排在最前面的几个
            List<tblSubroute> newList = new List<tblSubroute>();
            for (int i = 0; i < count; i++)
            {
                tblSubroute entiy = list[wlist[i].Key];
                newList.Add(entiy);
            }

            //随机法则
            return newList;
        }


        /// <summary>
        /// 算法：
        /// 1.每个项权重+1命名为w，防止为0情况。
        /// 2.计算出总权重n。
        /// 3.每个项权重w加上从0到(n-1)的一个随机数（即总权重以内的随机数），得到新的权重排序值s。
        /// 4.根据得到新的权重排序值s进行排序，取前面s最大几个。
        /// </summary>
        /// <param name="list">原始列表</param>
        /// <param name="count">随机抽取条数</param>
        /// <returns></returns>
        public List<DDYZ.Ensis.Presistence.DataEntity.newtblSubroute> GetRandomList(List<DDYZ.Ensis.Presistence.DataEntity.newtblSubroute> list, int count)
        {
            if (list == null || list.Count <= count || count <= 0)
            {
                return list;
            }

            //计算权重总和
            int totalWeights = 0;
            for (int i = 0; i < list.Count; i++)
            {
                totalWeights += int.Parse(list[i].fldWeight) + 1;  //权重+1，防止为0情况。
            }

            //随机赋值权重
            Random ran = new Random(GetRandomSeed());  //GetRandomSeed()随机种子，防止快速频繁调用导致随机一样的问题 
            List<KeyValuePair<int, int>> wlist = new List<KeyValuePair<int, int>>();    //第一个int为list下标索引、第一个int为权重排序值
            for (int i = 0; i < list.Count; i++)
            {
                int w = int.Parse(list[i].fldWeight) + ran.Next(0, totalWeights);   // （权重+1） + 从0到（总权重-1）的随机数
                wlist.Add(new KeyValuePair<int, int>(i, w));
            }

            //排序
            wlist.Sort(
              delegate (KeyValuePair<int, int> kvp1, KeyValuePair<int, int> kvp2)
              {
                  return kvp2.Value - kvp1.Value;
              });

            //根据实际情况取排在最前面的几个
            List<DDYZ.Ensis.Presistence.DataEntity.newtblSubroute> newList = new List<DDYZ.Ensis.Presistence.DataEntity.newtblSubroute>();
            for (int i = 0; i < count; i++)
            {
                DDYZ.Ensis.Presistence.DataEntity.newtblSubroute entiy = list[wlist[i].Key];
                newList.Add(entiy);
            }

            //随机法则
            return newList;
        }

        /// <summary>
        /// 随机种子值
        /// </summary>
        /// <returns></returns>
        private static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// 权重对象
        /// </summary>
        public class RandomObject
        {
            /// <summary>
            /// 权重
            /// </summary>
            public int fldWeight { set; get; }
        }

        /// <summary>
        /// 功能描述：处理参数
        /// 创建  人：周文卿
        /// 创建时间：2018-11-17
        /// </summary>
        /// <param name="tblSubroutes">路由表</param>
        /// <param name="payparameter">请求参数表</param>
        /// <param name="sing">签名的字段</param>
        /// <param name="orderid">订单号</param>
        /// 
        /// <returns></returns>
        public Dictionary<string, string> HandleParm(List<tblSubroute> tblSubroutes, Dictionary<string, string> payparameter, ref string sing, ref string orderid)
        {
            //读取参数配置Json 文件
            RuleCommon rule = new RuleCommon();
            string getjson = rule.GetJson(strLocalpath);
            JArray jsonObj = JArray.Parse(getjson);
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            JToken array = new JArray();
            //根据路由表判断 取哪个对象
            for (int i = 0; i < jsonObj.Count; i++)
            {
                //网关编号和支付方式一样
                if (tblSubroutes[0].fldGatewaynumber == jsonObj[i]["fldGatewaynumber"].ToString() && tblSubroutes[0].fldPayType == jsonObj[i]["fldPayType"].ToString())
                {
                    array = jsonObj[i];
                    sing = jsonObj[i]["sign"].ToString();

                }
            }
            JArray childrenarray = new JArray();


            //得到参数列表
            childrenarray = JArray.Parse(array["parameter"].ToString());

            //分别获取Key和value
            foreach (JToken item in childrenarray[0].Children())
            {
                var JP = item as JProperty;
                string key = JP.Name;
                string value = JP.Value.ToString();
                //如果value分别是num time 则为系统分配
                switch (value)
                {
                    //自己发往商户的订单号
                    case "num":
                        value = ram();
                        orderid = value;
                        break;
                    //自己发往商户的时间
                    case "time":
                        value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                    default:
                        if (payparameter.Keys.Contains(value))
                        {
                            value = payparameter[value];
                        }
                        break;
                }
                keyValuePairs.Add(key, value);
            }


            return keyValuePairs;
        }


        /// <summary>
        /// 功能描述：处理参数
        /// 创建  人：周文卿
        /// 创建时间：2018-11-17
        /// </summary>
        /// <param name="tblSubroutes">路由表</param>
        /// <param name="payparameter">请求参数表</param>
        /// <param name="sing">签名的字段</param>
        /// <param name="orderid">订单号</param>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public Dictionary<string, string> HandleParm(List<DDYZ.Ensis.Presistence.DataEntity.newtblSubroute> tblSubroutes, Dictionary<string, string> payparameter, ref string sing, ref string orderid, ref string url)
        {
            //读取参数配置Json 文件
            RuleCommon rule = new RuleCommon();
            string getjson = rule.GetJson(strLocalpath);
            JArray jsonObj = JArray.Parse(getjson);
            string bco = "";
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            JToken array = new JArray();
            //根据路由表判断 取哪个对象
            for (int i = 0; i < jsonObj.Count; i++)
            {
                //网关编号和支付方式一样
                if (tblSubroutes[0].fldGatewaynumber == jsonObj[i]["fldGatewaynumber"].ToString() && tblSubroutes[0].fldPayType == jsonObj[i]["fldPayType"].ToString())
                {
                    array = jsonObj[i];
                    sing = jsonObj[i]["sign"].ToString();
                    url = jsonObj[i]["payurl"].ToString();
                    if (jsonObj[i]["bankCode"] != null)
                    {
                        bco = jsonObj[i]["bankCode"].ToString();
                    }

                }
            }
            JArray childrenarray = new JArray();

            //得到参数列表
            childrenarray = JArray.Parse(array["parameter"].ToString());

            //分别获取Key和value
            foreach (JToken item in childrenarray[0].Children())
            {
                var JP = item as JProperty;
                string key = JP.Name;
                string value = JP.Value.ToString();
                //如果value分别是num time 则为系统分配
                switch (value)
                {
                    //自己发往商户的订单号
                    case "num":
                        value = ram();
                        orderid = value;
                        break;
                    //自己发往商户的时间
                    case "time":
                        value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                    case "time2":
                        value = DateTime.Now.ToString("yyyyMMddHHmmss");
                        break;
                    case "userid":
                        value = ramsix();
                        break;
                    case "bankCode":
                        RuletblDictionaries ruletblDictionaries = new RuletblDictionaries();
                        value = ruletblDictionaries.ValidateDictionariesCode(bco, payparameter["Bankname"].ToString());
                        break;
                    default:
                        if (payparameter.Keys.Contains(value))
                        {
                            value = payparameter[value];
                        }
                        break;
                }
                keyValuePairs.Add(key, value);
            }


            return keyValuePairs;
        }


        /// <summary>
        /// 功能描述：随机生成系统订单号，规则是当前时间加上一个随机的6位数加上LB
        /// 创建  人：周文卿
        /// 创建时间：2018-11-19
        /// </summary>
        /// <returns></returns>
        public string ram()
        {
            Random random = new Random();
            //随机一个6位数
            int num = random.Next(100000, 1000000);

            string sss = DateTime.Now.ToString("yyMMddHHmmssms");

            //加上自己X标识
            string ramtext = "X" + DateTime.Now.ToString("MMddHHmmssms") + System.Guid.NewGuid().ToString("N").Substring(0, 10);
            return ramtext.ToUpper().Substring(0, ramtext.Length - 1);
        }

        /// <summary>
        /// 根据所给的数据 随机生成 不能小于100000
        /// </summary>
        /// <returns></returns>
        public string ram(int maxnum)
        {
            Random random = new Random();
            //随机一个6位数
            int num = random.Next(100000, maxnum);

            string ramtext = DateTime.Now.ToString("yyMMddHHmmssms") + System.Guid.NewGuid().ToString("N").Substring(0, 11);
            return ramtext.ToUpper();
        }

        /// <summary>
        /// 随机6位数
        /// </summary>
        /// <returns></returns>
        public string ramsix()
        {
            Random random = new Random();
            //随机一个6位数
            int num = random.Next(100000, 1000000);


            return num.ToString(); ;
        }

        /// <summary>
        /// 功能描述：判断参数中 有什么参数为Null
        /// 创建时间：2018-11-20
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public rerurnpram IsParmNull(Dictionary<object, object> pairs)
        {
            rerurnpram rerurnpram = new rerurnpram();
            foreach (var key in pairs)
            {
                if (pairs[key.Key] == null)
                {
                    rerurnpram.statecode = "40007";
                    rerurnpram.message = "参数" + key.Key.ToString() + "未填写";
                    break;
                }
            }
            return rerurnpram;
        }

    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using System.Configuration;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 功能描述    ：  对表[tblDictionaries]的数据操作
    /// 创建者      ：  周文卿
    /// 创建日期    ：  2019-03-04
    /// </summary>
    public class RuletblDictionaries : BaseRule
    {
        /// <summary>
        /// 功能描述：验证银行名称是否正确
        /// </summary>
        /// <param name="ChannelName">渠道名称</param>
        /// <param name="BankName">银行名称</param>
        /// <returns></returns>
        public string ValidateDictionaries(string ChannelName, string BankName)
        {
            try {
                string outvarchar = "";
                usp_Dictionaries dictionaries = new usp_Dictionaries();
                dictionaries.OutChar = outvarchar;
                dictionaries.ChannelName = ChannelName;
                dictionaries.BankName = BankName;
                dictionaries.ExecNoQuery();
                outvarchar = dictionaries.OutChar;
                return outvarchar;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblDictionaries", "ValidateDictionaries", BankName);
            }
        }

        /// <summary>
        /// 功能描述：获得银行代码
        /// </summary>
        /// <param name="ChannelName">渠道名称</param>
        /// <param name="BankName">银行名称</param>
        /// <returns></returns>
        public string ValidateDictionariesCode(string ChannelName, string BankName)
        {
            try
            {
                string outvarchar = "";
                usp_DictionariesCode dictionaries = new usp_DictionariesCode();
                dictionaries.OutChar = outvarchar;
                dictionaries.ChannelName = ChannelName;
                dictionaries.BankName = BankName;
                dictionaries.ExecNoQuery();
                outvarchar = dictionaries.OutChar;
                return outvarchar;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblDictionaries", "ValidateDictionaries", BankName);
            }
        }

    }
}

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
    /// ��������    ��  �Ա�[tblDictionaries]�����ݲ���
    /// ������      ��  ������
    /// ��������    ��  2019-03-04
    /// </summary>
    public class RuletblDictionaries : BaseRule
    {
        /// <summary>
        /// ������������֤���������Ƿ���ȷ
        /// </summary>
        /// <param name="ChannelName">��������</param>
        /// <param name="BankName">��������</param>
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
        /// ����������������д���
        /// </summary>
        /// <param name="ChannelName">��������</param>
        /// <param name="BankName">��������</param>
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

using System;
using System.Collections.Generic;
using System.Text;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuleEqiaImport : BaseRule
    {
        //public void checkEqiaStcodeAndPcode(string checktype,string stcode, int year, string pcode, out int sresult, out int presult)
        //{
        //    try
        //    {
        //        usp_CheckEqia_StcodeAndPcode_ForImport checkeqia = new usp_CheckEqia_StcodeAndPcode_ForImport();
        //        sresult = -1;
        //        presult = -2;
        //        checkeqia.cktype = checktype;
        //        checkeqia.stcode = stcode;
        //        checkeqia.year = year;
        //        checkeqia.pcode = pcode;
        //        checkeqia.sresult=sresult;
        //        checkeqia.presult=presult;
        //        checkeqia.ExecScalar();
        //        sresult = checkeqia.sresult;
        //        presult = checkeqia.presult;
        //        if(string.IsNullOrEmpty(sresult.ToString())||string.IsNullOrEmpty(presult.ToString())) 
        //        {
        //            throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
        //        }
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new DataRuleException("�����ݿ����ӳ���", "RuleEqiaImport", "checkStcodeAndPcode", "stcode:" + stcode + "year:" + year + " pcode:" + pcode);
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetAllException("ִ��Sql���ʧ��", "RuleEqiaImport", "checkStcodeAndPcode", "stcode:" + stcode + "year:" + year + " pcode:" + pcode);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetAllException(e.Message, "RuleEqiaImport", "checkStcodeAndPcode", "stcode:" + stcode +"year:" + year +" pcode:" + pcode );
        //    }
        //}
    }
}

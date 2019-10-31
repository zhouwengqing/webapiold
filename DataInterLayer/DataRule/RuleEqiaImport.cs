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
        //            throw new Exception("取得记录失败，未找到对应的记录");
        //        }
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new DataRuleException("打开数据库连接出错", "RuleEqiaImport", "checkStcodeAndPcode", "stcode:" + stcode + "year:" + year + " pcode:" + pcode);
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetAllException("执行Sql语句失败", "RuleEqiaImport", "checkStcodeAndPcode", "stcode:" + stcode + "year:" + year + " pcode:" + pcode);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetAllException(e.Message, "RuleEqiaImport", "checkStcodeAndPcode", "stcode:" + stcode +"year:" + year +" pcode:" + pcode );
        //    }
        //}
    }
}

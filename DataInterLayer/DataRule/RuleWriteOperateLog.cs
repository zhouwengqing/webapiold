using DDYZ.Ensis.Library.Exception.BusiRule;
using DDYZ.Ensis.Presistence.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Rule.DataRule
{
  public  class RuleWriteOperateLog
    {
        /// <summary>
        /// 功能描述    ：  写入操作日志
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-04-18
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="iModalID">操作模块ID（从CheckRight方法返回，0为找不到）</param>
        /// <param name="sContent">操作内容</param>
        public void WriteLog(int iModalID, string sContent, string uName, int userId, int cityId)
        {
            if (uName == "yzadmin")
                return;
            try
            {
                if (iModalID < 1)
                    iModalID = 0;
                tblFW_Log objLog = new tblFW_Log();
                objLog.fldModalID = iModalID;
                objLog.fldUserID = userId;
                objLog.fldCityID = cityId;
                objLog.fldContent = sContent;
                objLog.fldDate_operate = DateTime.Now;
                RuletblFW_Log ruleLog = new RuletblFW_Log();
                ruleLog.Insert(objLog);
            }
            catch (Exception e)
            {
                BusiRuleException pexcep = new BusiRuleException(e.Message, "Page.PageBase", "WriteLog", "sContent：" + sContent);
            }
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
   public class RuletblReport_Doc
    {
       /// <summary>
       /// 功能描述：更新或者插入
       /// 创建  人：周文卿
       /// 创建时间：2017/10/25
       /// 修改  人：
       /// 修改时间：
       /// 修改原因：
       /// </summary>
       /// <param name="fldmodeltype">业务类别</param>
       /// <param name="fldName">报告名称</param>
       /// <param name="UserID">用户ID没有填写-1</param>
       /// <param name="fldContent">模板内容</param>
       /// <returns></returns>
       public int InsertorUpdateDoc(string fldmodeltype, string fldName, string UserID, string fldContent)
       {
           usp_InsertorUpdate uspAllData = new usp_InsertorUpdate();
           uspAllData.fldmodeltype = fldmodeltype;
           uspAllData.fldName = fldName;
           uspAllData.UserID = UserID;
           uspAllData.fldContent = fldContent;
           int iResult = uspAllData.ExecNoQuery();
           return iResult;
       }
    }
}

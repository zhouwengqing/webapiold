using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Data;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// ��������    ��  ���ݷ����߼��Ļ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��  �����
    /// �޸�����    ��  2010-08-06
    /// �޸�ԭ��    ��  ����WebSite����
    /// </summary>
    public abstract class BaseRule
    {
        public BaseRule()
        {
            //#if DEBUG
            ////���ҵ��õ�ǰ����ǲ���WebSite����������׳��쳣
            //bool bCanLoad = false;
            //StackTrace trace = new StackTrace();
            //if (trace.GetFrame(2).GetMethod().DeclaringType.BaseType.FullName == "PageBase" ||
            //    trace.GetFrame(2).GetMethod().DeclaringType.BaseType.FullName == "LoginPageBase" ||               
            //    trace.GetFrame(2).GetMethod().DeclaringType.BaseType.FullName == "LoginHandler" ||
            //    trace.GetFrame(2).GetMethod().DeclaringType.BaseType.FullName.IndexOf("System.Web.UI") >= 0||
            //    trace.GetFrame(2).GetMethod().DeclaringType.BaseType.FullName == "System.Web.Services.WebService" || trace.GetFrame(2).GetMethod().DeclaringType.BaseType.FullName == "PUBService.ServicPageBase")
               

            //    bCanLoad = true;
            //if (trace.GetFrame(2).GetMethod().DeclaringType.Namespace != null &&
            //    (trace.GetFrame(2).GetMethod().DeclaringType.Namespace.IndexOf("DDYZ.Ensis.Rule.BusinessRule") >= 0 ||
            //    trace.GetFrame(2).GetMethod().DeclaringType.Namespace.IndexOf("DDYZ.Ensis.Rule.DataRule") >= 0|| trace.GetFrame(2).GetMethod().DeclaringType.Namespace.IndexOf("DDYZ.Ensis.Services")>=0))
            //    bCanLoad = true;
            //if (bCanLoad == false)
            //{
            //    throw new Exception("�����ֻ�ܱ�WebSite���Լ���BusinessRule�������");
            //}
            //#endif
        }

    }
}

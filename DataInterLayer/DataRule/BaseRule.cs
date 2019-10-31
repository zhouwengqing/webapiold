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
    /// 功能描述    ：  数据访问逻辑的基类
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：  孟庆浩
    /// 修改日期    ：  2010-08-06
    /// 修改原因    ：  增加WebSite功能
    /// </summary>
    public abstract class BaseRule
    {
        public BaseRule()
        {
            //#if DEBUG
            ////查找调用当前类的是不是WebSite，如果不是抛出异常
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
            //    throw new Exception("该组件只能被WebSite、自己或BusinessRule组件调用");
            //}
            //#endif
        }

    }
}

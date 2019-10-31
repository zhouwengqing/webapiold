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
    /// <summary>
    /// 功能描述    ：  对表[tblFW_Log]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblFW_Log : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  添加[tblFW_Log]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-04-18
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objInsert">需要添加的实体类</param>
        /// <returns>返回新增记录的PK主键的值</returns>
        public long Insert(tblFW_Log objInsert)
        {
            try
            {
                usp_tblFW_Log_Insert uspInsert = new usp_tblFW_Log_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery(1);
                if (uspInsert.fldAutoID > 0)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("插入新记录失败");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("打开数据库连接失败", "RuletblFW_Log", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertException("相同的记录已经存在，违反表的唯一键约束", "RuletblFW_Log", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("执行Sql语句失败", "RuletblFW_Log", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblFW_Log", "Insert", objInsert.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  备份日志
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-04-18
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="dateStart">备份的开始日期（只传入日期部分即可）</param>
        /// <param name="dateEnd">备份的结束日期（只传入日期部分即可）</param>
        /// <returns>true / false</returns>
        public bool Backup(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                bool bResult = false;
                usp_tblFW_Log_Backup uspBack = new usp_tblFW_Log_Backup();
                uspBack.fldDate_Start = dateStart;
                uspBack.fldDate_End = dateEnd;
                uspBack.result = bResult;
                uspBack.ExecNoQuery(1);
                bResult = uspBack.result;
                return bResult;
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblFW_Log", "Backup",
                    "dateStart：" + dateStart.ToString("yyyy-MM-dd") + "；dateEnd：" + dateEnd.ToString("yyyy-MM-dd"));
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblFW_Log", "Backup",
                    "dateStart：" + dateStart.ToString("yyyy-MM-dd") + "；dateEnd：" + dateEnd.ToString("yyyy-MM-dd"));
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_Log", "Backup",
                    "dateStart：" + dateStart.ToString("yyyy-MM-dd") + "；dateEnd：" + dateEnd.ToString("yyyy-MM-dd"));
            }
        }















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
        public void WriteLog(int iModalID, string sContent, int UserID, int CityID, string UserHostAddress)
        {
            //if (this.userinfo.UserName == "yzadmin")
            //    return;



            //if (iModalID < 1)
            //    iModalID = 0;
            tblFW_Log objLog = new tblFW_Log();
            objLog.fldModalID = iModalID;
            objLog.fldUserID = UserID;
            objLog.fldCityID = CityID;
            objLog.fldContent = sContent;
            objLog.fldDate_operate = DateTime.Now;
            objLog.fldIPAddress = UserHostAddress;
            RuletblFW_Log ruleLog = new RuletblFW_Log();
            ruleLog.Insert(objLog);



        }



















    }
}

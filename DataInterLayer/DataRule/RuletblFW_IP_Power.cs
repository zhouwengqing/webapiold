using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{ 

    public class RuletblFW_IP_Power : BaseRule
    {

        /// <summary>
        /// 功能描述    ：  添加[tblFW_IP_Power]表的记录
        /// 创建者      ：  ZCH
        /// 创建日期    ：  2014-03-04
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objInsert">需要添加的实体类</param>
        /// <returns>返回新增记录的PK主键的值</returns>
        public bool GetIPPower(int iIP1,int IP2,int IP3,int IP4)
        {
            try
            {
                usp_tblFW_IP_Power_GetIPPower uspObj = new usp_tblFW_IP_Power_GetIPPower();
                uspObj.fldIP1 = iIP1;
                uspObj.fldIP2 = IP2;
                uspObj.fldIP3 = IP3;
                uspObj.fldIP4 = IP4; 
                int i=int.Parse(uspObj.ExecScalar().ToString());
                if (i > 0)
                    return false;
                else
                    return true;
            }
            catch (DBOpenException e)
            {
                throw new InsertException("打开数据库连接失败", "RuletblFW_IP_Power", "Insert", IP4.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertException("相同的记录已经存在，违反表的唯一键约束", "RuletblFW_IP_Power", "Insert", IP4.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("执行Sql语句失败", "RuletblFW_IP_Power", "Insert", IP4.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblFW_IP_Power", "Insert", IP4.ToString());
            }
        }

    }


}

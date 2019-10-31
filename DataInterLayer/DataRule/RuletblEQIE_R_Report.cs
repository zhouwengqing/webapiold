using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;
using System.Collections;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuletblEQIE_R_Report : BaseRule
    {
        #region 通用服务用到的业务逻辑

        /// 功能描述    ：  生态统计评价
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2016-01-13
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sPoint">测点代码列表</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="iSpaceID">0:监测结果、90：生态指数秩相关 </param>
        /// <param name="sTatType">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <returns>DataTable</returns>
        public DataTable GetEQIEDataInfo(string sBeginDate, string sEndDate, string sPoint,string cDecCarry = "0", int iSpaceID = 0, short sTatType = 0)
        {
            try
            {
                usp_tblEQIE_Report_AppriseStat uspAnalyseData = new usp_tblEQIE_Report_AppriseStat();
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.STatType = sTatType;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIE_R_Report", "GetEQIEDataInfo", "sBeginDate:" + sBeginDate +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sPoint:" + sPoint + ","
                                            );
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败" + e.Message, "RuletblEQIE_R_Report", "GetEQIEDataInfo", "sBeginDate:" + sBeginDate +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sPoint:" + sPoint + ","
                                            );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIE_R_Report", "GetEQIEDataInfo", "sBeginDate:" + sBeginDate +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sPoint:" + sPoint + ","
                                            );
            }
        }

        #endregion
    }
}

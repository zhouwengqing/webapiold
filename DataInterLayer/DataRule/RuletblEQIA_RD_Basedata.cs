using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuletblEQIA_RD_Basedata : BaseRule
    {
        #region 通用服务用到的业务逻辑

        /// 功能描述    ：  降尘综合统计
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2015-07-13
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sPoint">点位代码</param>
        /// <param name="sRIStdName">标准名称</param>
        ///  <param name="sRIStdLevel">标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="iStandID">标准值获取方式（0：所有对照点月均值+3）  </param> 
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>
        /// <param name="iSource">数据源</param>
        /// <param name="iAppriseID">0:针对单个点位评价、1：针对城市评价 </param>
        /// <param name="sTatType">0:降尘综合评价、1：浓度秩相关</param>
        /// <param name="iPara1ID">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <param name="iPara2ID">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <returns>DataTable</returns>
        public DataTable GetEQIARDDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, int iStandID = 0, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int iSource = 4, int iAppriseID = 0, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0)
        {
            try
            {
                usp_tblEQIA_RD_Report_AppriseStat uspAnalyseData = new usp_tblEQIA_RD_Report_AppriseStat();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.fldStandardName = sRIStdName;
                uspAnalyseData.fldLevel = sRIStdLevel;
                uspAnalyseData.fldStandID = iStandID;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.STatType = sTatType;
                uspAnalyseData.fldSource = iSource;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_RD_Basedata", "GetEQIARDDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint  +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败" + e.Message, "RuletblEQIA_RD_Basedata", "GetEQIARDDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint  +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_RD_Basedata", "GetEQIARDDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:");
            }
        }
        #endregion

    }
}

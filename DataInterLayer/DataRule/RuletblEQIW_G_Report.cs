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
    public class RuletblEQIW_G_Report : BaseRule
    {
        #region 通用服务用到的业务逻辑

        /// 功能描述    ：  地下水统计评价(0:原始数据表、1：年鉴表、因子超标情况、2：类别评价表、3：类别比例表、4：水质级别统计表 )
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2015-09-21
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sPoint">测点代码列表</param>
        /// <param name="sRStdName">标准级别名称</param>
        /// <param name="sRStdLevel">标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>
        /// <param name="iAppriseID">0:针对单个断面评价、1：城市评价</param>
        /// <param name="iSpaceID">0:原始数据表、1：年鉴表、因子超标情况、2：类别评价表、3：类别比例表、4：水质级别统计表</param>
        /// <param name="sTatType">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <returns>DataTable</returns>
        public DataTable GetEQIWGDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sPoint, string sRStdName, short sRStdLevel,
            string sItem, int iSpaceID,  string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int iAppriseID = 0, short sTatType = 0)
        {
            try
            {
                usp_tblEQIW_G_Report_Apprise uspAnalyseData = new usp_tblEQIW_G_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldStandardName = sRStdName;
                uspAnalyseData.fldLevel = sRStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.STatType = sTatType;
                uspAnalyseData.SpaceID = iSpaceID;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_G_Basedata", "GetEQIWGDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + 
                                            ",sRIStdName:" + sRStdName + ",sRIStdLevel:" + sRStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败" + e.Message, "RuletblEQIWG_Basedata", "GetEQIWGDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sRStdName + ",sRIStdLevel:" + sRStdLevel.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_G_Basedata", "GetEQIWGDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sRStdName + ",sRIStdLevel:" + sRStdLevel.ToString());
            }
        }
    
       
        #endregion
    }
}

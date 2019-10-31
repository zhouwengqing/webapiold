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
    public class RuletblEQICA_R_Report : BaseRule
    {
        #region 通用服务用到的业务逻辑

        /// 功能描述    ：  农村城市、测点综合评价
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2016-01-13
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sPoint">测点代码列表</param>
        /// <param name="sLStdName">湖库标准名称</param>
        /// <param name="sLStdLevel">湖库标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsYear">是否需要同期比较，0不需要，1需要</param>
        /// <param name="Source">数据源</param>
        /// <param name="iPointType">传入点位类型：0：具体点位、1：城市</param>
        /// <param name="iAppriseID">0:针对单个点位评价、1：针对城市评价、2：城市、测点都存在 </param>
        /// <param name="sTatType">评价类型0：江西评价表；1：原始日报数据；2：综合评价表；3：指数计算</param>
        /// <returns>DataTable</returns>
        public DataTable GetEQICADataInfo(string sTimeType,string sBeginDate, string sEndDate, string sPoint, string sItem, string sLStdName = "环境空气质量标准2012",
             short sLStdLevel = 2,  string cDecCarry = "0", int IsYear = 0, int Source = 0, int iPointType = 0, int iAppriseID = 0, short sTatType = 0)
        {
            try
            {
                usp_tblEQIA_R_Report_AppriseStat_V uspAnalyseData = new usp_tblEQIA_R_Report_AppriseStat_V();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.fldStandardName = sLStdName;
                uspAnalyseData.fldLevel = sLStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.fldIsYear = IsYear;
                uspAnalyseData.fldSource = Source;
                uspAnalyseData.PointType = iPointType;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.STatType = sTatType;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQICA_R_Report", "GetEQICADataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + 
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败"+e.Message, "RuletblEQICA_R_Report", "GetEQICADataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQICA_R_Report", "GetEQICADataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + 
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdName:");
            }
        }

        #endregion
    }
}

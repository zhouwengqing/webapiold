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
    public class RuletblEQICO_R_Report : BaseRule
    {
        #region 通用服务用到的业务逻辑

        /// 功能描述    ：  农村土壤综合评价
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2016-01-21
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
        /// <param name="iSpaceID"></param>
        /// <param name="iPointType">传入点位类型：0：具体点位、1：城市</param>
        /// <param name="iAppriseID">0：浓度范围表；1：项目超标情况；2：点位达标率计算；3、点位评价;4、地块评价</param>
        /// <param name="sTatType">土壤类型确认方法：0-江西</param>
        /// <returns>DataTable</returns>
        public DataTable GetEQICODataInfo(string sTimeType,string sBeginDate, string sEndDate, string sPoint, string sItem, string sStdName = "GB15618-1995",
             short sStdLevel = 2,  string cDecCarry = "0", int IsYear = 0,  int iPointType = 0, int iAppriseID = 0,int iSpaceID=0 ,short sTatType = 0)
        {
            try
            {
                usp_tblEQISO_Report_Apprise_V uspAnalyseData = new usp_tblEQISO_Report_Apprise_V();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldStandardName = sStdName;
                uspAnalyseData.fldLevel = sStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.fldIsYear = IsYear;
                uspAnalyseData.SpaceID = iSpaceID;
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQICO_R_Report", "GetEQICODataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + 
                                            ",sRIStdName:" + sStdName + ",sRIStdLevel:" + sStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败"+e.Message, "RuletblEQICO_R_Report", "GetEQICODataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sStdName + ",sRIStdLevel:" + sStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQICO_R_Report", "GetEQICODataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + 
                                            ",sRIStdName:" + sStdName + ",sRIStdLevel:" + sStdLevel.ToString() + ",sLIStdName:");
            }
        }

        #endregion
    }
}

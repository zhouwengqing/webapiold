﻿using System;
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
    public class RuletblEQICW_D_Report : BaseRule
    {
        #region 通用服务用到的业务逻辑

        /// 功能描述    ：  农村饮用水综合评价表
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
        /// <param name="sRStdName">河流标准级别名称</param>
        /// <param name="sRStdLevel">河流标准级别</param> 
        /// <param name="sLStdName">地下水标准级别名称</param>
        /// <param name="sLStdLevel">地下水标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="iAppriseID">0：数据明细表、1：水质状况评价表、3：达标情况表</param>
        /// <param name="iSpaceID"></param>
        /// <param name="sTatType">0全部，1地表水，2地下水  </param>
        /// <param name="iSource">用来标识是例行数据还是全分析数据</param>
        /// <param name="IsYear">是否需要同期比较，0不需要，1需要</param>
        /// <param name="iPointType">传入点位类型：0：具体点位、1：城市</param>
        /// <returns>DataTable</returns>
        public DataTable GetEQICWDDataInfo(string sTimeType, string sBeginDate, string sEndDate,  string sPoint, string sRStdName, short sRStdLevel,
            string sLStdName, short sLStdLevel, string sItem,  string cDecCarry = "0",  int iAppriseID = 0, int iSpaceID = 0, short sTatType = 0,
            int IsYear = 0, string sSource = "0", int iPointType = 0)
        {
            try
            {
                usp_tblEQIW_D_Report_Apprise_V uspAnalyseData = new usp_tblEQIW_D_Report_Apprise_V();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldRStandardName = sRStdName;
                uspAnalyseData.fldRLevel = sRStdLevel;
                uspAnalyseData.fldLStandardName = sLStdName;
                uspAnalyseData.fldLLevel = sLStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.STatType = sTatType;
                uspAnalyseData.fldIsYear = IsYear;
                uspAnalyseData.fldSource = sSource;
                uspAnalyseData.PointType = iPointType;
                

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQICW_D_Report", "GetEQICWDDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + 
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败"+e.Message, "RuletblEQICW_D_Report", "GetEQICWDDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + 
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQICW_D_Report", "GetEQICWDDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + 
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdName:");
            }
        }


        #endregion
    }
}

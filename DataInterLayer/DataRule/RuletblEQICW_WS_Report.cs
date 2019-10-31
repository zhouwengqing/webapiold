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
    public class RuletblEQICW_WS_Report : BaseRule
    {
        #region 农村污水处理厂通用服务用到的业务逻辑

        /// 功能描述    ：  农村污水处理厂综合评价表
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2016-10-22
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sPoint">测点代码列表</param>
        /// <param name="sLStdName">标准名称</param>
        ///  <param name="sLStdLevel">标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="iAppriseID">/0：原始数据表、1：评价表</param>
        /// <param name="iSpaceID">区分省份：0：江西、1：内蒙</param>
        /// <returns>DataTable</returns>
        public DataTable GetEQICWWSDataInfo(string sTimeType,string sBeginDate, string sEndDate, string sPoint, string sItem, string sStdName = "GB 3838-2002",
             short sStdLevel = 3,  string cDecCarry = "0", int iAppriseID = 0, int iSpaceID = 0)
        {
            try
            {
                usp_tblEQIW_WS_Report_Apprise_V uspAnalyseData = new usp_tblEQIW_WS_Report_Apprise_V();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldStandardName = sStdName;
                uspAnalyseData.fldLevel = sStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.SpaceID = iSpaceID;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQICW_WS_Report", "GetEQICWWSDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + 
                                            ",sRIStdName:" + sStdName + ",sRIStdLevel:" + sStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败"+e.Message, "RuletblEQICW_WS_Report", "GetEQICWWSDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sStdName + ",sRIStdLevel:" + sStdLevel.ToString() + ",sStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQICW_WS_Report", "GetEQICWWSDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + 
                                            ",sRIStdName:" + sStdName + ",sRIStdLevel:" + sStdLevel.ToString() + ",sStdName:");
            }
        }

        #endregion
    }
}

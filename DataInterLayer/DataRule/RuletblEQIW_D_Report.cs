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
    public class RuletblEQIW_D_Report : BaseRule
    {
        #region 通用服务用到的业务逻辑

        /// 功能描述    ：  饮用水统计评价(包括上报、年鉴)
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2015-09-21
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sRSC">水期</param>
        /// <param name="sPoint">测点代码列表</param>
        /// <param name="sRStdName">河流标准级别名称</param>
        /// <param name="sRStdLevel">河流标准级别</param> 
        /// <param name="sLStdName">地下水标准级别名称</param>
        /// <param name="sLStdLevel">地下水标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>
        /// <param name="IsTLI">是否统计富营养化指数</param>
        /// <param name="TLIType">富营养化计算时叶绿素a和透明度单位：0-mg/L,cm；1-mg/m^3,m</param>
        /// <param name="iAppriseID">0:针对单个断面评价、1：城市评价、2：城市区县评价</param>
        /// <param name="iSpaceID">0:原始数据表、1：年鉴表、因子超标情况、3：综合评价表 </param>
        /// <param name="sSource">用来标识是例行数据还是全分析数据   </param>
        /// <param name="sTatType">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <param name="iCalculateID">计算方法：0：算数平均、1：加权计算</param>
        /// <returns>DataTable</returns>
        public DataTable GetDrinkDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint, string sRStdName, short sRStdLevel,
            string sLStdName, short sLStdLevel, string sItem, int iSpaceID, String sSource, int iCalculateID, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int IsTLI = 0,int TLIType=0, int iAppriseID = 0, short sTatType = 0)
        {
            try
            {
                usp_tblEQIW_D_Report_Apprise uspAnalyseData = new usp_tblEQIW_D_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldRStandardName = sRStdName;
                uspAnalyseData.fldRLevel = sRStdLevel;
                uspAnalyseData.fldLStandardName = sLStdName;
                uspAnalyseData.fldLLevel = sLStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.IsTLI = IsTLI;
                uspAnalyseData.TLIType = TLIType;
                uspAnalyseData.STatType = sTatType;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.fldSource = sSource;
                uspAnalyseData.CalculateID = iCalculateID;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_D_Report", "GetDrinkDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败" + e.Message, "RuletblEQIW_D_Report", "GetDrinkDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_D_Report", "GetDrinkDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdName:");
            }
        }
    
       
        #endregion
    }
}

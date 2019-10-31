using System;
using System.Data;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuletblEQIW_RL_Report : BaseRule
    {


        #region 通用服务用到的业务逻辑(河流和湖库合并)

        /// 功能描述    ：  地表水综合统计评价
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2016-05-10
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sEBeginDate">第二个时段开始时间</param>
        /// <param name="sEEndDate">第二个时段结束时间</param>
        /// <param name="sRSC">水期</param>
        /// <param name="sPoint">断面代码</param>
        /// <param name="sLStdName">湖库标准名称</param>
        ///  <param name="sLStdLevel">湖库标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>
        /// <param name="IsTLI">是否统计富营养化指数</param>
        /// <param name="TLIType">富营养化计算时叶绿素a和透明度单位：0-mg/L,cm；1-mg/m^3,m</param>
        ///  mwpara.SpaceID = SpaceID;//0:流域-fldWaterArea、1:水系-fldRSWaterWork、2：河流-fldRCode、3：区县-fldRWTwon、4：设区市-fldSTCode
        ///  mwpara.AppriseID = 0;//0:针对单个断面评价、1：针对空间评价
        ///  mwpara.STatType = 1;//0:数据导出格式、1:年鉴格式、2：因子超标评价、3:断面或者河流综合评价、4：数据市站上报省站格 
        ///                              90:综合指数秩相关、91：浓度秩相关、92：达标率秩相关、93：因子污染指数秩相关、94：各类达标率秩相关
        ///  mwpara.Para1ID=Para1ID;//湖库均值处理，0:默认值按行政区、1：按行政区前4位处理
        ///  mwpara.Para2ID=Para2ID;//基础信息参数，用于不同省份；0：通用、 1：江西增加信息 2：湖南
        ///  mwpara.Source	=Source	;//数据类型，对应fldSource
        /// <returns>DataTable</returns>
        public DataTable GetRLDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sLStdName, short sLStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int IsTLI = 0, int TLIType = 0, int iSpaceID = 0, int iAppriseID = 0, short sTatType = 2, int iPara1ID = 0, int iPara2ID = 0, int iSource = 0,
            string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                usp_tblEQIW_RL_Report_Apprise uspAnalyseData = new usp_tblEQIW_RL_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldStandardName = sLStdName;
                uspAnalyseData.fldLevel = sLStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.IsTLI = IsTLI;
                uspAnalyseData.TLIType = TLIType;
                uspAnalyseData.STatType = sTatType;
                uspAnalyseData.Para1ID = iPara1ID;
                uspAnalyseData.Para2ID = iPara2ID;
                uspAnalyseData.Source = iSource;
                uspAnalyseData.EBeginDate = sEBeginDate == null ? "" : sEBeginDate;
                uspAnalyseData.EEndDate = sEEndDate == null ? "" : sEEndDate;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_RL_Basedata", "GetRLDataInfoS", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败"+e.Message, "RuletblEQIW_RL_Basedata", "GetRLDataInfoS", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_RL_Basedata", "GetRLDataInfoS", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdName:");
            }
        }


        #endregion
     
    }
}

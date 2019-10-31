﻿using System;
using System.Collections.Generic; 
using System.Text;
using System.Data;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuletblEQIBC_T_Analyse_Gis : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  取得潮间带生物的综合评价[潮间带生物断面（Gis）]
        /// 创建者      ：  du
        /// 创建日期    ：  2015-3-30
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="iYear">年</param>
        /// <param name="iPhase">期数:如果全年为0,期数分为1-4</param>
        /// <param name="STCode">城市代码</param>
        /// <param name="RSCode">点位代码</param>
        /// <param name="iStatType">统计类型：1-得到每个点位情况；2-区域水质类别评价</param>
        /// <param name="iSpaceID">区域类型：1-城市、2-省份、3-海域、4-海区</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataStatAnalyseGis(int iYear, int iPhase, string STCode,  string RSCode,
                                            int iStatType, int iSpaceID)
        {
            try
            {
                usp_tblEQIBT_Report_EcologicalIndex_Gis usp = new usp_tblEQIBT_Report_EcologicalIndex_Gis();
                usp.fldYear = iYear;
                usp.fldPhase = iPhase;
                usp.fldSTCode = STCode;
                usp.fldRSCode = RSCode;
                usp.fldStatType = iStatType;
                usp.fldSpaceID = iSpaceID;
                usp.TableID = 0;
                DataTable dt = usp.ExecDataTable();
                if (dt != null)
                {
                    return dt;
                }
                else
                    throw new Exception("取得统计记录失败");

            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIBC_T_Analyse_Gis", "GetDataStatAnalyseGis", e.Message);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIBC_T_Analyse_Gis", "GetDataStatAnalyseGis", e.Message);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIBC_T_Analyse_Gis", "GetDataStatAnalyseGis", e.Message);
            }
        }

       

    }
}

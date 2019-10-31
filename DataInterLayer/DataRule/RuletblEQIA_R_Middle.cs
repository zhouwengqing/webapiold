using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 对中间库表的相关操作
    /// </summary>
    public class RuletblEQIA_R_Middle : BaseRule
    {

        /// <summary>
        /// 功能描述    ：  获得[tblEQIA_R_Point_Country]表的记录
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-08-17
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="stcode">城市代码 全部填-1</param>
        /// <returns>DataTable</returns>
        public DataTable GetPoint_Country_Select(string stcode)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Point_Country_Select uspByAll = new usp_tblEQIA_R_Point_Country_Select();
                uspByAll.fldStcode = stcode;
                tblData = uspByAll.ExecDataTable(4);
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIA_R_Point_Country";
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Middle", "GetPoint_Country_Select", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Middle", "GetPoint_Country_Select", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Middle", "GetPoint_Country_Select", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  获得[tblEMCMIS_City]表的记录
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-08-17
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="stcode">城市代码 全部填-1</param>
        /// <returns>DataTable</returns>
        public DataTable GetCity_Select(string stcode)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEMCMIS_City_Select uspByAll = new usp_tblEMCMIS_City_Select();
                uspByAll.fldStcode = stcode;
                tblData = uspByAll.ExecDataTable(4);
                if (tblData != null)
                {
                    tblData.TableName = "tblEMCMIS_City";
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Middle", "GetCity_Select", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Middle", "GetCity_Select", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Middle", "GetCity_Select", "");
            }
        }



        /// <summary>
        /// 功能描述：取得城市AQI数据
        /// 创建者：徐雍文
        /// 创建日期：2017-08-11
        /// 修改者：
        /// 修改日期
        /// 修改原因：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <returns>dt</returns>
        public DataTable GetCityAqiHour(string stcode)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIA_RPI_AQI_CityHour_Midd_Select param = new usp_tblEQIA_RPI_AQI_CityHour_Midd_Select();
                param.stcode = stcode;
                dt = param.ExecDataTable(4);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw new Exception("取得记录失败，未找到对应的记录");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Middle", "GetCityAqiHour", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Middle", "GetCityAqiHour", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Middle", "GetCityAqiHour", "");
            }
        }


        /// <summary>
        /// 功能描述：取得城市AQI数据（时间段）
        /// 创建者：徐雍文
        /// 创建日期：2017-10-13
        /// 修改者：
        /// 修改日期
        /// 修改原因：
        /// </summary>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="stcode">城市代码</param>
        /// <returns>dt</returns>
        public DataTable GetCityAqiHour(string BeginDate, string EndDate, string stcode)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIA_RPI_AQI_CityHour_Midd_TimeQuantum_Select param = new usp_tblEQIA_RPI_AQI_CityHour_Midd_TimeQuantum_Select();
                param.stcode = stcode;
                param.BeginDate = BeginDate;
                param.EndDate = EndDate;
                dt = param.ExecDataTable(4);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw new Exception("取得记录失败，未找到对应的记录");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Middle", "GetCityAqiHour", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Middle", "GetCityAqiHour", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Middle", "GetCityAqiHour", "");
            }
        }

        /// <summary>
        /// 功能描述：取得测点AQI数据
        /// 创建者：徐雍文
        /// 创建日期：2017-08-17
        /// 修改者：
        /// 修改日期
        /// 修改原因：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <returns>dt</returns>
        public DataTable GetPointAqiHour(string stcode)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIA_RPI_AQI_PHour_Midd_Select param = new usp_tblEQIA_RPI_AQI_PHour_Midd_Select();
                param.stcode = stcode;
                dt = param.ExecDataTable(4);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw new Exception("取得记录失败，未找到对应的记录");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Middle", "GetPointAqiHour", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Middle", "GetPointAqiHour", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Middle", "GetPointAqiHour", "");
            }
        }


        /// <summary>
        /// 功能描述：取得城市AQI趋势数据
        /// 创建者：徐雍文
        /// 创建日期：2017-08-19
        /// 修改者：
        /// 修改日期
        /// 修改原因：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="iady">天数</param>
        /// <returns>dt</returns>
        public DataTable GetCityAqiDayTrend(string stcode,int iady)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIA_RPI_AQI_CityHour_Midd_SelectTrend param = new usp_tblEQIA_RPI_AQI_CityHour_Midd_SelectTrend();
                param.stcode = stcode;
                param.iday = iady;
                dt = param.ExecDataTable(4);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw new Exception("取得记录失败，未找到对应的记录");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Middle", "GetCityAqiDayTrend", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Middle", "GetCityAqiDayTrend", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Middle", "GetCityAqiDayTrend", "");
            }
        }

        /// <summary>
        /// 功能描述：取得城市下的测点AQI趋势数据
        /// 创建者：徐雍文
        /// 创建日期：2017-08-19
        /// 修改者：
        /// 修改日期
        /// 修改原因：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="iady">天数</param>
        /// <returns>dt</returns>
        public DataTable GetPointAqiDayTrend(string stcode, int iady,string pcode)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIA_RPI_AQI_PHour_Midd_SelectTrend param = new usp_tblEQIA_RPI_AQI_PHour_Midd_SelectTrend();
                param.stcode = stcode;
                param.iday = iady;
                param.pcode = pcode;
                dt = param.ExecDataTable(4);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw new Exception("取得记录失败，未找到对应的记录");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Middle", "GetPointAqiDayTrend", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Middle", "GetPointAqiDayTrend", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Middle", "GetPointAqiDayTrend", "");
            }
        }

        /// <summary>
        /// 功能描述：取得县(市、区)AQI数据
        /// 创建者：徐雍文
        /// 创建日期：2017-08-21
        /// 修改者：
        /// 修改日期
        /// 修改原因：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <returns>dt</returns>
        public DataTable GetCountyAqiHour(string stcode)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIA_RPI_AQI_CountyHour_Liv_Midd_Select param = new usp_tblEQIA_RPI_AQI_CountyHour_Liv_Midd_Select();
                param.stcode = stcode;
                dt = param.ExecDataTable(4);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw new Exception("取得记录失败，未找到对应的记录");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Middle", "GetCityAqiDay", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Middle", "GetCityAqiDay", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Middle", "GetCityAqiDay", "");
            }
        }

        /// <summary>
        /// 功能描述：取得城市日报
        /// 创建者：徐雍文
        /// 创建日期：2017-08-26
        /// 修改者：
        /// 修改日期
        /// 修改原因：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="date">时间</param>
        /// <returns>dt</returns>
        public DataTable GetcityAqiDay(string stcode,string date)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIA_RPI_AQI_CityDay_Midd_Select param = new usp_tblEQIA_RPI_AQI_CityDay_Midd_Select();
                param.stcode = stcode;
                param.date = date;
                dt = param.ExecDataTable(4);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw new Exception("取得记录失败，未找到对应的记录");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Middle", "GetcityAqiDay", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Middle", "GetcityAqiDay", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Middle", "GetcityAqiDay", "");
            }
        }

        /// <summary>
        /// 功能描述：取得城市日报
        /// 创建者：徐雍文
        /// 创建日期：2017-08-26
        /// 修改者：
        /// 修改日期
        /// 修改原因：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="date">时间</param>
        /// <returns>dt</returns>
        public DataTable GetcityAqiDay(string BeginDate, string EndDate, string stcode)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIA_RPI_AQI_CityDay_Midd_TimeQuantumSelect param = new usp_tblEQIA_RPI_AQI_CityDay_Midd_TimeQuantumSelect();
                param.stcode = stcode;
                param.EndDate = EndDate;
                param.BeginDate = BeginDate;
                dt = param.ExecDataTable(4);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw new Exception("取得记录失败，未找到对应的记录");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Middle", "GetcityAqiDay", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Middle", "GetcityAqiDay", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Middle", "GetcityAqiDay", "");
            }
        }


        /// <summary>
        /// 功能描述：取得城市日报
        /// 创建者：徐雍文
        /// 创建日期：2017-08-26
        /// 修改者：
        /// 修改日期
        /// 修改原因：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="pcode">测点代码</param>
        /// <param name="date">时间</param>
        /// <returns>dt</returns>
        public DataTable GetpointAqiDay(string stcode, string pcode,string date)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIA_RPI_AQI_PDay_Midd_Select param = new usp_tblEQIA_RPI_AQI_PDay_Midd_Select();
                param.stcode = stcode;
                param.date = date;
                param.pcode = pcode;
                dt = param.ExecDataTable(4);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw new Exception("取得记录失败，未找到对应的记录");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Middle", "GetpointAqiDay", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Middle", "GetpointAqiDay", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Middle", "GetpointAqiDay", "");
            }
        }

        /// <summary>
        /// 功能描述：取得城市日报
        /// 创建者：徐雍文
        /// 创建日期：2017-08-26
        /// 修改者：
        /// 修改日期
        /// 修改原因：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="pcode">测点代码</param>
        /// <param name="date">时间</param>
        /// <returns>dt</returns>
        public DataTable GetAIRDatainfo(string BeginDate, string EndDate, string stcode, string timetype)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIA_R_ContaminantsAndWpi_Midd_Select param = new usp_tblEQIA_R_ContaminantsAndWpi_Midd_Select();
                param.stcode = stcode;
                param.BeginDate = BeginDate;
                param.EndDate = EndDate;
                param.timetype = timetype;
                dt = param.ExecDataTable(4);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw new Exception("取得记录失败，未找到对应的记录");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Middle", "GetpointAqiDay", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Middle", "GetpointAqiDay", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Middle", "GetpointAqiDay", "");
            }
        }
    }
}

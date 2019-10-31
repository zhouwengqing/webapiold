using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Presistence.DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 功能描述：审核公共方法  
    /// 创建者：熊瑞竹
    /// 创建日期：2017-06-28
    /// 审核
    /// </summary>
    public class RuleEQICommon_Auditing : BaseRule
    {
        #region 根据业务代码获取审核数据
        /// <summary>
        /// 功能描述：根据业务代码获取审核数据
        /// 创建者：熊瑞竹
        /// 创建日期：2017-06-28
        /// 修改者：
        /// 修改日期：
        /// 修改原因：
        /// </summary>
        /// <param name="bstype">业务代码 例（大气：eiqa_r）</param>
        /// <param name="viewname">视图名称 例（大气所查询的视图名称：vwEQIA_RPI_Basedata_Pre_NewAll）</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="judge">查询数据类型0、基本信息和因子数据 1、基本信息</param>
        /// <returns>所查询业务的审核数据的DataTable</returns>
        public DataTable GetAuditingDatabyBusinessType(string bstype, string viewname, string strwhere, int judge)
        {
            try
            {
                DataTable Auddt = new DataTable();
                if (bstype == "eqia_r" || bstype == "eqia_r_hm")//获取大气数据表
                {
                    usp_EQIA_R_Auditing uspAcc = new usp_EQIA_R_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqia_rd")//获取降尘数据表
                {
                    usp_EQIA_RD_Auditing uspAcc = new usp_EQIA_RD_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqia_p")//获取降水数据表
                {
                    usp_EQIA_P_Auditing uspAcc = new usp_EQIA_P_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqia_s")//获取大气专项数据表
                {
                    usp_EQIA_S_Auditing uspAcc = new usp_EQIA_S_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqiw_r" || bstype == "eqiw_r_hm")//获取地表水数据表
                {
                    usp_EQIW_R_Auditing uspAcc = new usp_EQIW_R_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqiw_r_auto")
                {
                    usp_EQIW_R_Auto_Auditing uspAcc = new usp_EQIW_R_Auto_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqise")//获取水华数据表
                {
                    usp_EQIW_R_Auditing_ShuiHua uspAcc = new usp_EQIW_R_Auditing_ShuiHua();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqiw_g")//获取地下水数据表
                {
                    usp_EQIW_G_Auditing uspAcc = new usp_EQIW_G_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqiw_sts")//获取地表水专项数据表
                {
                    usp_EQIW_STS_Auditing uspAcc = new usp_EQIW_STS_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqin_a")//获取区域噪声数据表
                {
                    usp_EQIN_A_Auditing uspAcc = new usp_EQIN_A_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqin_f")//获取功能区噪声数据表
                {
                    usp_EQIN_F_Auditing uspAcc = new usp_EQIN_F_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqin_t")//获取道路交通噪声数据表
                {
                    usp_EQIN_T_Auditing uspAcc = new usp_EQIN_T_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqin_m")//获取噪声专项数据表
                {
                    usp_EQIN_M_Auditing uspAcc = new usp_EQIN_M_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqiw_dt")//获取县区饮用水源地数据表
                {
                    usp_EQIW_DT_Auditing uspAcc = new usp_EQIW_DT_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqiw_d" || bstype == "eqiw_d_hm")//获取地市级饮用水源数据表
                {
                    usp_EQIW_D_Auditing uspAcc = new usp_EQIW_D_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqiw_dx")//获取地市级饮用水源数据表
                {
                    usp_EQIW_DX_Auditing uspAcc = new usp_EQIW_DX_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }
                if (bstype == "eqiso" || bstype == "eqiso_hm")//获取土壤数据表
                {
                    usp_EQISO_Auditing uspAcc = new usp_EQISO_Auditing();
                    uspAcc.vwTableName = viewname;
                    uspAcc.strWhere = strwhere;
                    uspAcc.isItemBaseData = judge;
                    Auddt = uspAcc.ExecDataTable();
                }

                if (Auddt != null)
                {
                    return Auddt;
                }
                else
                {
                    throw new Exception("取得记录失败，未找到对应的记录");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuleEQICommon_Auditing", "GetAuditingData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleEQICommon_Auditing", "GetAuditingData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleEQICommon_Auditing", "GetItemData", "");
            }
        }
        #endregion


        /// <summary>
        /// 功能描述：确认全部数据
        /// 创建者  ：吕荣誉
        /// 创建日期：2017-7-4
        /// 修改者  ：
        /// 修改日期：
        /// 修改原因
        /// </summary>
        /// <param name="actiontype">操作类型</param>
        /// <param name="tablename">正式表名称</param>
        /// <param name="basedatacol">正式表字段</param>
        /// <param name="tablenamepre">临时表名称</param>
        /// <param name="baseprecol">临时表字段</param>
        /// <param name="where">条件</param>
        /// <param name="idlist">需要操作的数据ID列表</param>
        /// <returns></returns>
        public int ExecuteAuditingAll(string actiontype, string tablename, string basedatacol, string tablenamepre, string View, string ViewCol, string where, string idlist, string type, string NewFlag)
        {
            usp_AuditingActionAll uspAll = new usp_AuditingActionAll()
            {
                actiontype = actiontype,
                tablename = tablename,
                basedatacol = basedatacol,
                tablenamepre = tablenamepre,
                View = View,
                ViewCol = ViewCol,
                where = where,
                idlist = idlist,
                type = type,
                NewFlag = NewFlag
            };
            return uspAll.ExecNoQuery();
        }

        public int ExecuteAuditingLog(List<tblFW_AuditingLog> lstAudLog)
        {
            int iResultInsert = 0;
            //审批操作记录保存到审核日志
            for (int i = 0; i < lstAudLog.Count; i++)
            {
                usp_tblFW_AuditingLog_Insert uspInsert = new usp_tblFW_AuditingLog_Insert();
                uspInsert.ReceiveParameter(lstAudLog[i]);
                iResultInsert += uspInsert.ExecNoQuery();
                if (iResultInsert <= 0)
                {
                    throw new Exception("添加审核日志未通过原因失败，未找到对应的记录");
                }
            }
            return iResultInsert;
        }






    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuleGisDataSource : BaseRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="pcode">测点代码</param>
        /// <param name="itemcodestr">项目字符串</param>
        /// <param name="basetable">基本信息表或者视图</param>
        /// <returns></returns>
        public DataTable getDataSource(string stcode, string pcode, string itemcodestr, string basetable)
        {
            try
            {
                usp_base_getdata_forgis gis = new usp_base_getdata_forgis();
                gis.stcode = stcode;
                gis.pcode = pcode;
                gis.itemcodestr = itemcodestr;
                gis.basetable = basetable;

                DataTable tbldata = gis.ExecDataTable();
                if (tbldata != null)
                {
                    return tbldata;
                }
                else 
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("打开数据库连接出错", "RuleGisDataSource", "getDataSource", "stcode:" + stcode + " pcode:" + pcode + "itemcodestr:" + itemcodestr + "basetable:" + basetable);
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleGisDataSource", "getDataSource", "stcode:" + stcode + " pcode:" + pcode + "itemcodestr:" + itemcodestr + "basetable:" + basetable);
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleGisDataSource", "getDataSource", "stcode:" + stcode + " pcode:" + pcode + "itemcodestr:" + itemcodestr + "basetable:" + basetable);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="pcode">测点代码</param>
        /// <param name="itemcodestr">项目字符串</param>
        /// <param name="basetable">基本信息表或者视图</param>
        /// <returns></returns>
        public DataSet getDataSet(string stcode, string pcode, string itemcodestr, string basetable)
        {
            try
            {
                usp_base_getdata_forgis gis = new usp_base_getdata_forgis();
                gis.stcode = stcode             ;
                gis.pcode  = pcode              ;
                gis.itemcodestr = itemcodestr   ;
                gis.basetable = basetable       ;
                DataSet ds = gis.ExecDataSet();
                if (ds != null)
                {
                    return ds;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("打开数据库连接出错", "RuleGisDataSource", "getDataSource", "stcode:" + stcode + " pcode:" + pcode + "itemcodestr:" + itemcodestr + "basetable:" + basetable);
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleGisDataSource", "getDataSource", "stcode:" + stcode + " pcode:" + pcode + "itemcodestr:" + itemcodestr + "basetable:" + basetable);
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleGisDataSource", "getDataSource", "stcode:" + stcode + " pcode:" + pcode + "itemcodestr:" + itemcodestr + "basetable:" + basetable);
            }
        }
        public DataSet getDataSet(string stcode, string rcode, string rscode, string itemcodestr, string basetable)
        {
            try
            {
                usp_base_eqiw_getdata_forgis gis = new usp_base_eqiw_getdata_forgis();
                gis.stcode = stcode             ;
                gis.rcode  = rcode              ;
                gis.rscode = rscode             ;                
                gis.itemcodestr = itemcodestr   ;
                gis.basetable   = basetable     ;
                DataSet ds = gis.ExecDataSet();
                if (ds != null)
                {
                    return ds;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("打开数据库连接出错", "RuleGisDataSource", "getDataSource", "rcode:" + stcode + "rcode:" + rcode + "rscode:" + rscode + "itemcodestr:" + itemcodestr + "basetable:" + basetable);
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleGisDataSource", "getDataSource", "stcode:" + stcode + "rcode:" + rcode +"rscode:" + rscode + "itemcodestr:" + itemcodestr + "basetable:" + basetable);
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleGisDataSource", "getDataSource", "stcode:" + stcode + "rcode:" + rcode + "rscode:" + rscode + "itemcodestr:" + itemcodestr + "basetable:" + basetable);
            }
        }
    }
}

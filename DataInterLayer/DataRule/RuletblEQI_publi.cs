using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using System.Xml;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuletblEQI_publi : BaseRule
    {
  

        /// <summary>
        /// 功能描述    ：  传入条件
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-9-21
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="eqi">例如eqiw_r</param>      
        /// <param name="rrcode">河流代码.断面代码</param>       
        /// <returns>IList</returns>
        public List<string> Handletbl(string eqi, string rrcode, string year, string stcode)
        {
            try
            {
                List<string> liststring = new List<string>();
                string selectAll = "", tbl = "", strwhere = "";
                if (eqi == "eqiw_r")
                {
                    selectAll = " fldAutoID,  fldRCode,fldRName,fldRSCode,fldRSName";
                    tbl = "tblEQIW_R_Section";
                    strwhere = "(fldRCode+'.'+fldRSCode) in (" + rrcode + ") and fldYear = '" + year + "' and (fldSTCode='" + stcode + "' or (fldBSTCode ='" + stcode + "' and fldBYN='1' ))order by fldRCode";

                    liststring.Add(selectAll);
                    liststring.Add(tbl);
                    liststring.Add(strwhere);
                }
                else if (eqi == "eqiw_d")
                {
                    selectAll = "  fldAutoID, fldRCode,fldRName,fldRSCode,fldRSName";
                    tbl = "tblEQIW_D_Section";
                    strwhere = "(fldRCode+'.'+fldRSCode) in (" + rrcode + ") and fldYear = '" + year + "' and fldSTCode='" + stcode + "' order by fldRCode";

                    liststring.Add(selectAll);
                    liststring.Add(tbl);
                    liststring.Add(strwhere);
                }
                else if (eqi == "eqiw_dt")
                {
                    selectAll = "  fldAutoID, fldRCode,fldRName,fldRSCode,fldRSName";
                    tbl = "tblEQIW_DT_Section";
                    strwhere = "(fldRCode+'.'+fldRSCode) in (" + rrcode + ") and fldYear = '" + year + "' and fldSTCode='" + stcode + "' order by fldRCode";

                    liststring.Add(selectAll);
                    liststring.Add(tbl);
                    liststring.Add(strwhere);
                }
                else if (eqi == "eqiw_l")
                {
                    selectAll = "   fldAutoID,fldLCode as fldRCode,fldLName as fldRName,fldLSCode as fldRSCode,fldLSName as fldRSName ";
                    tbl = "tblEQIW_L_Section";
                    strwhere = "(fldLCode+'.'+fldLSCode) in (" + rrcode + ") and fldYear = '" + year + "' and fldSTCode='" + stcode + "' order by fldLCode";


                    liststring.Add(selectAll);
                    liststring.Add(tbl);
                    liststring.Add(strwhere);
                }
                else if (eqi == "eqiw_g")
                {
                    selectAll = "   fldAutoID,fldPCode as fldRCode,fldPName as fldRName";
                    tbl = "tblEQIW_G_Section";
                    strwhere = " fldPCode in (" + rrcode + ") and fldYear = '" + year + "' and fldSTCode='" + stcode + "' order by fldPCode";

                    liststring.Add(selectAll);
                    liststring.Add(tbl);
                    liststring.Add(strwhere);
                }
                else if (eqi == "eqia_d")
                {
                    selectAll = "   fldAutoID,fldQuCode,fldPCode as fldRCode,fldPName as fldRName";
                    tbl = "tblEQIA_D_Point";
                    strwhere = " (fldPCode+'.'+  fldQuCode ) in (" + rrcode + ") and fldYear = '" + year + "' and fldSTCode='" + stcode + "' order by fldPCode";

                    liststring.Add(selectAll);
                    liststring.Add(tbl);
                    liststring.Add(strwhere);
                }
                else if (eqi == "eqia_p")
                {
                    selectAll = "   fldAutoID,fldPCode as fldRCode,fldPName as fldRName";
                    tbl = "tblEQIA_P_Point";
                    strwhere = " fldPCode in (" + rrcode + ") and fldYear = '" + year + "' and fldSTCode='" + stcode + "' order by fldPCode";

                    liststring.Add(selectAll);
                    liststring.Add(tbl);
                    liststring.Add(strwhere);
                }
                else if (eqi == "eqia_rd")
                {
                    selectAll = "   fldAutoID,fldPCode as fldRCode,fldPName as fldRName";
                    tbl = "tblEQIA_RD_Point";
                    strwhere = " fldPCode in (" + rrcode + ") and fldYear = '" + year + "' and fldSTCode='" + stcode + "' order by fldPCode";

                    liststring.Add(selectAll);
                    liststring.Add(tbl);
                    liststring.Add(strwhere);
                }
                else if (eqi == "eqia_r")
                {
                    selectAll = "   fldAutoID,fldPCode as fldRCode,fldPName as fldRName";
                    tbl = "tblEQIA_R_Point";
                    strwhere = " fldPCode in (" + rrcode + ") and fldYear = '" + year + "' and fldSTCode='" + stcode + "' order by fldPCode";

                    liststring.Add(selectAll);
                    liststring.Add(tbl);
                    liststring.Add(strwhere);
                }
                else if (eqi == "eqia_s")
                {
                    selectAll = "   fldAutoID,fldPCode as fldRCode,fldPName as fldRName";
                    tbl = "tblEQIA_STS_Point";
                    strwhere = " fldPCode in (" + rrcode + ") and fldYear = '" + year + "' and fldSTCode='" + stcode + "' order by fldPCode";

                    liststring.Add(selectAll);
                    liststring.Add(tbl);
                    liststring.Add(strwhere);
                }
                else if (eqi == "eqis_w")
                {
                    selectAll = "   fldAutoID,fldPCode as fldRCode,fldPName as fldRName ";
                    tbl = "tblEQIS_W_Point";
                    strwhere = " (fldPCode) in (" + rrcode + ") and fldYear = '" + year + "' and fldSTCode='" + stcode + "' order by fldPCode";

                    liststring.Add(selectAll);
                    liststring.Add(tbl);
                    liststring.Add(strwhere);
                }

                return liststring;
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "usp_tblEQI_Section_getCodeByRRCode", "List<string>:" + stcode);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "usp_tblEQI_Section_getCodeByRRCode", "List<string>:" + stcode);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "usp_tblEQI_Section_getCodeByRRCode", "List<string>:" + stcode);
            }
        }

     



     

        /// <summary>
        /// 功能描述    ：  根据月份取得月份的最后一天
        /// 创建者      ：  黄成
        /// 创建日期    ：  2010-01-08
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：   
        /// </summary>
        /// <param name="_year">年份</param>
        /// <param name="_month">月份</param>
        /// <returns></returns>
        public static int GetLastDayInMonth(int _year, int _month)
        {
            switch (_month)
            {
                case 2:
                    if ((_year % 4 == 0 && _year % 100 != 0) || (_year % 400 == 0))
                        return 29;
                    else
                        return 28;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                default:
                    return 0;
            }
        }


        /// <summary>
        /// 功能描述    ：  获取随机代码（年月日小时分钟组合）
        /// 创建者      ：  黄成
        /// 创建日期    ：  2012-03-05
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：   
        /// </summary>
        /// <param name="_year">年份</param> 
        /// <returns></returns>
        public static string GetRandomCode()
        {
            string code = "";
            code = DateTime.Now.ToString("yyMMddHHmmss");
            return code;
        }


        /// <summary>
        /// 功能描述    ：  根据城市代码获取标准
        /// 创建者      ：  黄成
        /// 创建日期    ：  2012-01-08
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：   
        /// </summary>
        /// <param name="_stcode">城市代码</param>
        /// <param name="_stname">城市名称</param>
        /// <returns></returns>
        public double GetShiJiaoByCode(string _stcode)
        {
            if (_stcode == "310101" || _stcode == "310106" || _stcode == "310103" || _stcode == "310108" || _stcode == "310109" || _stcode == "310112" || _stcode == "310105"
                 || _stcode == "310104" || _stcode == "310110" || _stcode == "310107" || _stcode == "310113")
                return 4;
            else if (_stcode == "310117" || _stcode == "310114" || _stcode == "310118" || _stcode == "310120" || _stcode == "310116" || _stcode == "310230")
                return 3;
            else if (_stcode == "310115")
                return 3.5;
            else
                return 0;
        }

        /// <summary>
        /// 功能描述    ：  根据城市名称获取标准
        /// 创建者      ：  黄成
        /// 创建日期    ：  2012-01-08
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：   
        /// </summary>
        /// <param name="_stcode">城市代码</param>
        /// <param name="_stname">城市名称</param>
        /// <returns></returns>
        public double GetShiJiaoByName(string _stname)
        {
            if (_stname == "黄浦区" || _stname == "静安区" || _stname == "卢湾区" || _stname == "虹口区" || _stname == "闸北区" || _stname == "闵行区"
                    || _stname == "长宁区" || _stname == "徐汇区" || _stname == "杨浦区" || _stname == "普陀区" || _stname == "宝山区")
                return 4;
            else if (_stname == "松江区" || _stname == "嘉定区" || _stname == "青浦区" || _stname == "奉贤区" || _stname == "金山区" || _stname == "崇明县")
                return 3;
            else if (_stname == "浦东新区")
                return 3.5;
            else
                return 0;

        }

        /// <summary>
        /// 功能描述    ：  查询最低检出限
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-12-14
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>bool</returns>
        public string GetSenseBytbl(string tbl, string code)
        {
            try
            {
                tbl = "tbl" + tbl + "_Item";
                string sql = " select fldSense from  " + tbl + " where fldItemCode =  " + code;
                usp_execSqlText usp = new usp_execSqlText();
                usp.sqlText = sql;
                DataTable dt = usp.ExecDataTable();
                if (dt == null)
                    throw new Exception("没有查询到数据！");

                return dt.Rows[0]["fldSense"].ToString();

            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "usp_execSqlText", "tbl:" + tbl.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "usp_execSqlText", "tbl:" + tbl.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "usp_execSqlText", "tbl:" + tbl.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  查询最低检出限
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-12-14
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>bool</returns>
        public string GetSenseNameBytbl(string tbl, string code)
        {
            try
            {
                tbl = "tbl" + tbl + "_Item";
                string sql = " select fldSense ,flditemName from  " + tbl + " where fldItemCode =  " + code;
                usp_execSqlText usp = new usp_execSqlText();
                usp.sqlText = sql;
                DataTable dt = usp.ExecDataTable();
                if (dt == null)
                    throw new Exception("没有查询到数据！");

                return dt.Rows[0]["fldSense"].ToString() + "~" + dt.Rows[0]["flditemName"].ToString();

            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "usp_execSqlText", "tbl:" + tbl.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "usp_execSqlText", "tbl:" + tbl.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "usp_execSqlText", "tbl:" + tbl.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  查询保存的分组
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-07-05
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="type">业务类别</param>
        /// <returns>IList</returns>
        public List<tblEQI_Item_Group> GetdllBystcode(string stcode,string type)
        {
            try
            {
                List<tblEQI_Item_Group> list = new List<tblEQI_Item_Group>();
                usp_tblEQI_getdllBystcode usp_t = new usp_tblEQI_getdllBystcode();
                usp_t.stcode = stcode;
                usp_t.fldObject = type;
                DataTable dt = usp_t.ExecDataTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tblEQI_Item_Group tig = new tblEQI_Item_Group();
                        tig.fldName = dt.Rows[i]["fldName"].ToString();
                        tig.fldAutoID = Int32.Parse(dt.Rows[i]["fldAutoID"].ToString());
                        tig.fldItemContent = dt.Rows[i]["fldItemContent"].ToString();
                        list.Add(tig);
                    }
                }
                return list;

            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "usp_tblEQI_Section_getCodeByRRCode", "stcode:" + stcode);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "usp_tblEQI_Section_getCodeByRRCode", "stcode:" + stcode);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "usp_tblEQI_Section_getCodeByRRCode", "stcode:" + stcode);
            }
        }


        /// <summary>
        /// 功能描述    ：  读取xml文件
        /// 创建者      ：  张晓龙
        /// 创建日期    ：  2012-5-14
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：   
        /// </summary>
        /// <param name="filePath">xml文件绝对路径</param>
        /// <param name="TagName">要搜索的子元素节点名称</param>
        /// <param name="Attributs">子元素</param>
        /// <returns>DataTable</returns>
        public DataTable ReadXmlToDataTable(string filePath, string TagName, string[] NodeAttributs)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < NodeAttributs.Length; i++)
            {
                dt.Columns.Add(NodeAttributs[i], typeof(String));
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(TagName);
            foreach (XmlNode node in nodeList)
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < NodeAttributs.Length; i++)
                {
                    dr[NodeAttributs[i]] = node.ChildNodes[i].InnerText;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }





        #region 直接执行sql语句
        public DataTable getData(string cx, string tbl, string strwhere, string strorder)
        {
            try
            {
                string sql = " select " + cx + " from  " + tbl + " where " + strwhere + " order by  " + strorder;
                usp_execSqlText usp = new usp_execSqlText();
                usp.sqlText = sql;
                DataTable dt = usp.ExecDataTable();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable getdt(string sql)
        {
            try
            {
                usp_execSqlText usp = new usp_execSqlText();
                usp.sqlText = sql;
                DataTable dt = usp.ExecDataTable();
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
        }

        public bool deldt(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int isb = cmd.ExecuteNonQuery();
                    //usp_execSqlText usp = new usp_execSqlText();
                    //usp.sqlText = sql;
                    //int isb = usp.ExecNoQuery();
                    if (isb > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion





        /// <summary>
        /// 功能描述    ：  三级审核，判断。是否存在，如果存在修改，不存在增加(批量)
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-12-14
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>bool</returns>
        public bool ThreeVerifyIfUpdateOrInsert(List<tbleqi_ThreeVerify> listdata)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < listdata.Count; i++)
                        {
                            usp_tbleqi_ThreeVerifyIfUpdateOrInsert usp_UI = new usp_tbleqi_ThreeVerifyIfUpdateOrInsert();
                            usp_UI.ReceiveParameter(listdata[i]);
                            usp_UI.threelevel = "0";
                            if (usp_UI.ExecNoQuery(conn, tran) <= 0)
                                return false;
                        }
                        tran.Commit();
                        return true;

                    }
                    catch (DBOpenException e)
                    {
                        throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "usp_tblEQI_Section_getCodeByRRCode", "listdata:" + listdata.ToString());
                    }
                    catch (DBQueryException e)
                    {
                        throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "usp_tblEQI_Section_getCodeByRRCode", "listdata:" + listdata.ToString());
                    }
                    catch (Exception e)
                    {
                        throw new GetListException(e.Message, "RuletblEQI_publi", "usp_tblEQI_Section_getCodeByRRCode", "listdata:" + listdata.ToString());
                    }
                }
            }
        }


    }
}

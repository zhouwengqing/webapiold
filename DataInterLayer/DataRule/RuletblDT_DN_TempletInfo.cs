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
    public class RuletblDT_DN_TempletInfo
    {

        public IList<tblDT_DN_TempletInfo> GetAllList(short type, string fldmond)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblDT_DN_TempletInfo_ByAll_Select uspByAll = new usp_tblDT_DN_TempletInfo_ByAll_Select();
                uspByAll.type = type;
                uspByAll.fldModule = fldmond;
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblDT_DN_TempletInfo> listAll = new List<tblDT_DN_TempletInfo>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblDT_DN_TempletInfo objData = new tblDT_DN_TempletInfo();
                        objData.MetaDataTable = tblTmp;
                        listAll.Add(objData);
                    }
                    return listAll;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblDT_DN_TempletInfo", "GetAllList", "type:" + type.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblDT_DN_TempletInfo", "GetAllList", "type:" + type.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblDT_DN_TempletInfo", "GetAllList", "type:" + type.ToString());
            }
        }




















    }
}

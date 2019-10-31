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
    public class RuleOldOrdertable
    {

        /// <summary>
        /// 功能描述：根据商户和订单号修改状态和手续费
        /// 创建时间：2018-12-4
        /// 创建 人：周文卿
        /// </summary>
        /// <param name="fldMerchID">商户ID</param>
        /// <param name="fldChannelnum"></param>
        /// <param name="fldStaute"></param>
        /// <param name="IsSuccess"></param>
        /// <param name="fldTotalAmount"></param>
        /// <returns></returns>
        public DataTable updatestate(string fldMerchID, string fldChannelnum, string fldStaute, out bool IsSuccess, decimal fldTotalAmount)
        {
            try
            {

                usp_updatetblOrdertable usp = new usp_updatetblOrdertable();
                usp.fldMerchID = fldMerchID;
                usp.fldChannelnum = fldChannelnum;
                usp.fldStaute = fldStaute;
                usp.IsSuccess = false;
                usp.fldTotalAmount = fldTotalAmount;
                DataTable dt = usp.ExecDataTable();
                IsSuccess = usp.IsSuccess;
                return dt;
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuleOldOrdertable", "updatestate", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuleOldOrdertable", "updatestate", "");
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "RuleOldOrdertable", "updatestate", "更新usp_updatetblOrdertable");
            }

        }




        /// 功能描述    ：  添加[tblOrdertable]表的记录
        /// 创建者      ：  zhowuq
        /// 创建日期    ：  2019-03-22
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objInsert">需要添加的实体类</param>
        /// <returns>返回新增记录的PK主键的值</returns>
        public int Insert(tblOrdertable objInsert)
        {
            try
            {
                usp_tblOrdertable_Insert uspInsert = new usp_tblOrdertable_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery();
               
                if (uspInsert.fldAutoID > 0)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("插入新记录失败");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("打开数据库连接失败", "RuletblEQI_Query_Group", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertPKException("相同的记录已经存在，违反表的唯一键约束", "RuletblOrdertable", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("执行Sql语句失败", "RuletblEQI_Query_Group", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblEQI_Query_Group", "Insert", objInsert.ToString());
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuleSuccessStatecs
    {
        /// <summary>
        /// 查询实时成功率
        /// </summary>
        /// <param name="indextime"></param>
        /// <returns></returns>
        public DataTable successStatedataTable(string indextime)
        {
            try
            {
                SuccessState successState = new SuccessState();
                successState.indextime = short.Parse(indextime);
                DataTable dataTables = successState.ExecDataTable();
                return dataTables;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuleSuccessStatecs", "successStatedataTable", indextime);
            }
        }

        /// <summary>
        /// 查询总金额
        /// </summary>
        /// <param name="indextime"></param>
        /// <param name="endtime"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable AllAmount(string starttime,string endtime,string where)
        {
            try
            {
                allAmount successState = new allAmount();
                successState.starttime = starttime;
                successState.endtime = endtime;
                successState.where = where;
                DataTable dataTables = successState.ExecDataTable();
                return dataTables;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuleSuccessStatecs", "AllAmount", where);
            }
        }
    }
}

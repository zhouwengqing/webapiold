using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Lib.sql;
using System.Reflection;
using System.Text.RegularExpressions;
using DDYZ.Ensis.Presistence.DataEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json.Converters;
using System.Configuration;


namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuletblChannelinformation
    {
        /// <summary>
        /// 根据发往上游订单号 查询渠道信息
        /// </summary>
        /// <param name="fldChannelnum"></param>
        /// <returns></returns>
        public DataSet selechannebycid(string fldChannelnum)
        {
            try {
                AccepttblChanne accepttbl = new AccepttblChanne();
                accepttbl.fldChannelnum = fldChannelnum;
                DataSet dt = accepttbl.ExecDataSet();
                return dt;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "tblChannelinformation", "selechannebycid", fldChannelnum);
            }
           
        }

        /// <summary>
        /// 根据发往上游订单号 查询渠道信息(代付)
        /// </summary>
        /// <param name="fldChannelnum"></param>
        /// <returns></returns>
        public DataSet selechannebycidsub(string fldChannelnum)
        {
            try
            {
                AccepttblChanneSub accepttbl = new AccepttblChanneSub();
                accepttbl.fldChannelnum = fldChannelnum;
                DataSet dt = accepttbl.ExecDataSet();
                return dt;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "tblChannelinformation", "selechannebycid", fldChannelnum);
            }

        }

        /// <summary>
        /// 更新外扣的值
        /// </summary>
        /// <param name="fldbuckle"></param>
        /// <param name="fldAutoID"></param>
        /// <param name="isok"></param>
        /// <returns></returns>
        public int UpdateChannelinformation(string fldbuckle,string fldAutoID, out int isok)
        {
            try
            {
                isok = 0;
                UpdateChannelinformation accepttbl = new UpdateChannelinformation();
                accepttbl.fldbuckle = fldbuckle;
                accepttbl.fldAutoID = fldAutoID;
                accepttbl.IsOk = isok;
                int i = accepttbl.ExecNoQuery();
                isok = accepttbl.IsOk;
                return isok;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "tblChannelinformation", "UpdateChannelinformation", fldbuckle);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DDYZ.Ensis.DataSource.DataAccess
{
    public class usp_tblDictionary_Delete_ParentID : BaseProcedure
    {
        private SqlParameter parameterfldParentID;

        public usp_tblDictionary_Delete_ParentID()
		{
            base.InitCommand("usp_tblDictionary_Delete_ParentID");
			ConfigParameter();
		}

        public System.Int32 fldParentID
		{
			get
			{
                return (System.Int32)this.parameterfldParentID.Value;
			}
			set
			{
                this.parameterfldParentID.Value = value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
            this.parameterfldParentID = new SqlParameter();
            this.parameterfldParentID.ParameterName = "@fldParentID";
            this.parameterfldParentID.SqlDbType = SqlDbType.Int;
            this.parameterfldParentID.Size = 4;
            this.parameterfldParentID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldParentID);
		}
    }
}

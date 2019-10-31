using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DDYZ.Ensis.DataSource.DataAccess
{
    public class usp_tblEQIW_G_ItemSTD_GetSTD : BaseProcedure
    {
        private SqlParameter parameterstritemCode;

        private SqlParameter parameterEdition;

        public usp_tblEQIW_G_ItemSTD_GetSTD()
        {
            base.InitCommand("usp_tblEQIW_G_ItemSTD_GetSTD");
            ConfigParameter();
        }

        public System.String stritemCode
        {
            get
            {
                return (System.String)this.parameterstritemCode.Value;
            }
            set
            {
                this.parameterstritemCode.Value = value;
            }
        }

        public System.String Edition
        {
            get
            {
                return (System.String)this.parameterEdition.Value;
            }
            set
            {
                this.parameterEdition.Value = value;
            }
        }

        public void ConfigParameter()
        {
            //--------------------------------------------------------
            this.parameterstritemCode = new SqlParameter();
            this.parameterstritemCode.ParameterName = "@stritemCode";
            this.parameterstritemCode.SqlDbType = SqlDbType.NVarChar;
            this.parameterstritemCode.Size = -1;
            this.parameterstritemCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterstritemCode);
            //--------------------------------------------------------
            this.parameterEdition = new SqlParameter();
            this.parameterEdition.ParameterName = "@Edition";
            this.parameterEdition.SqlDbType = SqlDbType.VarChar;
            this.parameterEdition.Size = 20;
            this.parameterEdition.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterEdition);
        }
    }
}

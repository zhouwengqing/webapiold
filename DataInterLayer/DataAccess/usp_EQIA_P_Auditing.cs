//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: v2.0.50727
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace DDYZ.Ensis.DataSource.DataAccess
{
	using System;
	using System.Data;
	using System.Data.SqlClient;
	using System.Data.SqlTypes;
	using System.Xml;
	using System.Reflection;

	public class updatetblReportArchive : BaseProcedure
	{
		private SqlParameter parameterfldReport_Name;

		private SqlParameter parameterfldReport_Type;

		private SqlParameter parameterfldRName;

        private SqlParameter parameterfldUserID;

        private SqlParameter parameterfldTime;

        private SqlParameter parameterfldPath;

        private SqlParameter parameterfldFileName;


        public updatetblReportArchive()
		{
			base.InitCommand("updatetblReportArchive");
			ConfigParameter();
		}

		public System.String fldReport_Name
        {
			get
			{
				return (System.String)this.parameterfldReport_Name.Value;
			}
			set
			{
				this.parameterfldReport_Name.Value=value;
			}
		}

		public System.String fldReport_Type
        {
			get
			{
				return (System.String)this.parameterfldReport_Type.Value;
			}
			set
			{
				this.parameterfldReport_Type.Value=value;
			}
		}


        public System.String fldRName
        {
            get
            {
                return (System.String)this.parameterfldRName.Value;
            }
            set
            {
                this.parameterfldRName.Value = value;
            }
        }


        public System.String fldUserID
        {
			get
			{
				return (System.String)this.parameterfldUserID.Value;
			}
			set
			{
				this.parameterfldUserID.Value=value;
			}
		}


        public System.String fldTime
        {
            get
            {
                return (System.String)this.parameterfldTime.Value;
            }
            set
            {
                this.parameterfldTime.Value = value;
            }
        }

        public System.String fldPath
        {
            get
            {
                return (System.String)this.parameterfldPath.Value;
            }
            set
            {
                this.parameterfldPath.Value = value;
            }
        }

        public System.String fldFileName
        {
            get
            {
                return (System.String)this.parameterfldFileName.Value;
            }
            set
            {
                this.parameterfldFileName.Value = value;
            }
        }

        public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldReport_Name = new SqlParameter();
			this.parameterfldReport_Name.ParameterName= "@fldReport_Name";
			this.parameterfldReport_Name.SqlDbType=SqlDbType.VarChar;
			this.parameterfldReport_Name.Size=-1;
			this.parameterfldReport_Name.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldReport_Name);
			//--------------------------------------------------------
			this.parameterfldReport_Type = new SqlParameter();
			this.parameterfldReport_Type.ParameterName= "@fldReport_Type";
			this.parameterfldReport_Type.SqlDbType= SqlDbType.VarChar;
			this.parameterfldReport_Type.Size=-1;
			this.parameterfldReport_Type.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldReport_Type);
			//--------------------------------------------------------
			this.parameterfldRName = new SqlParameter();
			this.parameterfldRName.ParameterName= "@fldRName";
			this.parameterfldRName.SqlDbType=SqlDbType.VarChar;
			this.parameterfldRName.Size=-1;
			this.parameterfldRName.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldRName);
            //--------------------------------------------------------
            this.parameterfldUserID = new SqlParameter();
            this.parameterfldUserID.ParameterName = "@fldUserID";
            this.parameterfldUserID.SqlDbType = SqlDbType.VarChar;
            this.parameterfldUserID.Size = -1;
            this.parameterfldUserID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldUserID);
            //--------------------------------------------------------
            this.parameterfldTime = new SqlParameter();
            this.parameterfldTime.ParameterName = "@fldTime";
            this.parameterfldTime.SqlDbType = SqlDbType.VarChar;
            this.parameterfldTime.Size = -1;
            this.parameterfldTime.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldTime);
            //--------------------------------------------------------
            this.parameterfldPath = new SqlParameter();
            this.parameterfldPath.ParameterName = "@fldPath";
            this.parameterfldPath.SqlDbType = SqlDbType.VarChar;
            this.parameterfldPath.Size = -1;
            this.parameterfldPath.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldPath);
            //--------------------------------------------------------
            this.parameterfldFileName = new SqlParameter();
            this.parameterfldFileName.ParameterName = "@fldFileName";
            this.parameterfldFileName.SqlDbType = SqlDbType.VarChar;
            this.parameterfldFileName.Size = -1;
            this.parameterfldFileName.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldFileName);
        }
	}
}

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

    public class usp_tblEQI_Query_Group_Update : BaseProcedure
    {
        private SqlParameter parameterold_fldAutoID;

        private SqlParameter parameterold_fldObject;

        private SqlParameter parameterold_fldName;

        private SqlParameter parameterold_fldUserID;

        private SqlParameter parameterold_fldTimeType;

        private SqlParameter parameterold_fldTimeRange;

        private SqlParameter parameterold_fldItemGroup;

        private SqlParameter parameterold_fldItemCode;

        private SqlParameter parameterold_fldPointGroup;

        private SqlParameter parameterold_fldPointCode;

        private SqlParameter parameterold_fldSource;

        private SqlParameter parameterold_fldDataType;

        private SqlParameter parameterold_fldSampleType;

        private SqlParameter parameternew_fldObject;

        private SqlParameter parameternew_fldName;

        private SqlParameter parameternew_fldUserID;

        private SqlParameter parameternew_fldTimeType;

        private SqlParameter parameternew_fldTimeRange;

        private SqlParameter parameternew_fldItemGroup;

        private SqlParameter parameternew_fldItemCode;

        private SqlParameter parameternew_fldPointGroup;

        private SqlParameter parameternew_fldPointCode;

        private SqlParameter parameternew_fldSource;

        private SqlParameter parameternew_fldDataType;

        private SqlParameter parameternew_fldSampleType;

        public usp_tblEQI_Query_Group_Update()
        {
            base.InitCommand("usp_tblEQI_Query_Group_Update");
            ConfigParameter();
        }

        public System.Int32 old_fldAutoID
        {
            get
            {
                return (System.Int32)this.parameterold_fldAutoID.Value;
            }
            set
            {
                this.parameterold_fldAutoID.Value = value;
            }
        }

        public System.String old_fldObject
        {
            get
            {
                return (System.String)this.parameterold_fldObject.Value;
            }
            set
            {
                this.parameterold_fldObject.Value = value;
            }
        }

        public System.String old_fldName
        {
            get
            {
                return (System.String)this.parameterold_fldName.Value;
            }
            set
            {
                this.parameterold_fldName.Value = value;
            }
        }

        public System.String old_fldUserID
        {
            get
            {
                return (System.String)this.parameterold_fldUserID.Value;
            }
            set
            {
                this.parameterold_fldUserID.Value = value;
            }
        }

        public System.String old_fldTimeType
        {
            get
            {
                return (System.String)this.parameterold_fldTimeType.Value;
            }
            set
            {
                this.parameterold_fldTimeType.Value = value;
            }
        }

        public System.String old_fldTimeRange
        {
            get
            {
                return (System.String)this.parameterold_fldTimeRange.Value;
            }
            set
            {
                this.parameterold_fldTimeRange.Value = value;
            }
        }

        public System.String old_fldItemGroup
        {
            get
            {
                return (System.String)this.parameterold_fldItemGroup.Value;
            }
            set
            {
                this.parameterold_fldItemGroup.Value = value;
            }
        }

        public System.String old_fldItemCode
        {
            get
            {
                return (System.String)this.parameterold_fldItemCode.Value;
            }
            set
            {
                this.parameterold_fldItemCode.Value = value;
            }
        }

        public System.String old_fldPointGroup
        {
            get
            {
                return (System.String)this.parameterold_fldPointGroup.Value;
            }
            set
            {
                this.parameterold_fldPointGroup.Value = value;
            }
        }

        public System.String old_fldPointCode
        {
            get
            {
                return (System.String)this.parameterold_fldPointCode.Value;
            }
            set
            {
                this.parameterold_fldPointCode.Value = value;
            }
        }

        public System.String old_fldSource
        {
            get
            {
                return (System.String)this.parameterold_fldSource.Value;
            }
            set
            {
                this.parameterold_fldSource.Value = value;
            }
        }

        public System.String old_fldDataType
        {
            get
            {
                return (System.String)this.parameterold_fldDataType.Value;
            }
            set
            {
                this.parameterold_fldDataType.Value = value;
            }
        }

        public System.String old_fldSampleType
        {
            get
            {
                return (System.String)this.parameterold_fldSampleType.Value;
            }
            set
            {
                this.parameterold_fldSampleType.Value = value;
            }
        }

        public System.String new_fldObject
        {
            get
            {
                return (System.String)this.parameternew_fldObject.Value;
            }
            set
            {
                this.parameternew_fldObject.Value = value;
            }
        }

        public System.String new_fldName
        {
            get
            {
                return (System.String)this.parameternew_fldName.Value;
            }
            set
            {
                this.parameternew_fldName.Value = value;
            }
        }

        public System.String new_fldUserID
        {
            get
            {
                return (System.String)this.parameternew_fldUserID.Value;
            }
            set
            {
                this.parameternew_fldUserID.Value = value;
            }
        }

        public System.String new_fldTimeType
        {
            get
            {
                return (System.String)this.parameternew_fldTimeType.Value;
            }
            set
            {
                this.parameternew_fldTimeType.Value = value;
            }
        }

        public System.String new_fldTimeRange
        {
            get
            {
                return (System.String)this.parameternew_fldTimeRange.Value;
            }
            set
            {
                this.parameternew_fldTimeRange.Value = value;
            }
        }

        public System.String new_fldItemGroup
        {
            get
            {
                return (System.String)this.parameternew_fldItemGroup.Value;
            }
            set
            {
                this.parameternew_fldItemGroup.Value = value;
            }
        }

        public System.String new_fldItemCode
        {
            get
            {
                return (System.String)this.parameternew_fldItemCode.Value;
            }
            set
            {
                this.parameternew_fldItemCode.Value = value;
            }
        }

        public System.String new_fldPointGroup
        {
            get
            {
                return (System.String)this.parameternew_fldPointGroup.Value;
            }
            set
            {
                this.parameternew_fldPointGroup.Value = value;
            }
        }

        public System.String new_fldPointCode
        {
            get
            {
                return (System.String)this.parameternew_fldPointCode.Value;
            }
            set
            {
                this.parameternew_fldPointCode.Value = value;
            }
        }

        public System.String new_fldSource
        {
            get
            {
                return (System.String)this.parameternew_fldSource.Value;
            }
            set
            {
                this.parameternew_fldSource.Value = value;
            }
        }

        public System.String new_fldDataType
        {
            get
            {
                return (System.String)this.parameternew_fldDataType.Value;
            }
            set
            {
                this.parameternew_fldDataType.Value = value;
            }
        }

        public System.String new_fldSampleType
        {
            get
            {
                return (System.String)this.parameternew_fldSampleType.Value;
            }
            set
            {
                this.parameternew_fldSampleType.Value = value;
            }
        }

        public void ConfigParameter()
        {
            //--------------------------------------------------------
            this.parameterold_fldAutoID = new SqlParameter();
            this.parameterold_fldAutoID.ParameterName = "@old_fldAutoID";
            this.parameterold_fldAutoID.SqlDbType = SqlDbType.Int;
            this.parameterold_fldAutoID.Size = 4;
            this.parameterold_fldAutoID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldAutoID);
            //--------------------------------------------------------
            this.parameterold_fldObject = new SqlParameter();
            this.parameterold_fldObject.ParameterName = "@old_fldObject";
            this.parameterold_fldObject.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldObject.Size = 20;
            this.parameterold_fldObject.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldObject);
            //--------------------------------------------------------
            this.parameterold_fldName = new SqlParameter();
            this.parameterold_fldName.ParameterName = "@old_fldName";
            this.parameterold_fldName.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldName.Size = 100;
            this.parameterold_fldName.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldName);
            //--------------------------------------------------------
            this.parameterold_fldUserID = new SqlParameter();
            this.parameterold_fldUserID.ParameterName = "@old_fldUserID";
            this.parameterold_fldUserID.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldUserID.Size = 50;
            this.parameterold_fldUserID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldUserID);
            //--------------------------------------------------------
            this.parameterold_fldTimeType = new SqlParameter();
            this.parameterold_fldTimeType.ParameterName = "@old_fldTimeType";
            this.parameterold_fldTimeType.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldTimeType.Size = 50;
            this.parameterold_fldTimeType.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldTimeType);
            //--------------------------------------------------------
            this.parameterold_fldTimeRange = new SqlParameter();
            this.parameterold_fldTimeRange.ParameterName = "@old_fldTimeRange";
            this.parameterold_fldTimeRange.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldTimeRange.Size = 50;
            this.parameterold_fldTimeRange.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldTimeRange);
            //--------------------------------------------------------
            this.parameterold_fldItemGroup = new SqlParameter();
            this.parameterold_fldItemGroup.ParameterName = "@old_fldItemGroup";
            this.parameterold_fldItemGroup.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldItemGroup.Size = 50;
            this.parameterold_fldItemGroup.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldItemGroup);
            //--------------------------------------------------------
            this.parameterold_fldItemCode = new SqlParameter();
            this.parameterold_fldItemCode.ParameterName = "@old_fldItemCode";
            this.parameterold_fldItemCode.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldItemCode.Size = 4000;
            this.parameterold_fldItemCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldItemCode);
            //--------------------------------------------------------
            this.parameterold_fldPointGroup = new SqlParameter();
            this.parameterold_fldPointGroup.ParameterName = "@old_fldPointGroup";
            this.parameterold_fldPointGroup.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldPointGroup.Size = 50;
            this.parameterold_fldPointGroup.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldPointGroup);
            //--------------------------------------------------------
            this.parameterold_fldPointCode = new SqlParameter();
            this.parameterold_fldPointCode.ParameterName = "@old_fldPointCode";
            this.parameterold_fldPointCode.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldPointCode.Size = -1;
            this.parameterold_fldPointCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldPointCode);
            //--------------------------------------------------------
            this.parameterold_fldSource = new SqlParameter();
            this.parameterold_fldSource.ParameterName = "@old_fldSource";
            this.parameterold_fldSource.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldSource.Size = 50;
            this.parameterold_fldSource.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldSource);
            //--------------------------------------------------------
            this.parameterold_fldDataType = new SqlParameter();
            this.parameterold_fldDataType.ParameterName = "@old_fldDataType";
            this.parameterold_fldDataType.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldDataType.Size = 50;
            this.parameterold_fldDataType.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldDataType);
            //--------------------------------------------------------
            this.parameterold_fldSampleType = new SqlParameter();
            this.parameterold_fldSampleType.ParameterName = "@old_fldSampleType";
            this.parameterold_fldSampleType.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldSampleType.Size = 50;
            this.parameterold_fldSampleType.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldSampleType);
            //--------------------------------------------------------
            this.parameternew_fldObject = new SqlParameter();
            this.parameternew_fldObject.ParameterName = "@new_fldObject";
            this.parameternew_fldObject.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldObject.Size = 20;
            this.parameternew_fldObject.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldObject);
            //--------------------------------------------------------
            this.parameternew_fldName = new SqlParameter();
            this.parameternew_fldName.ParameterName = "@new_fldName";
            this.parameternew_fldName.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldName.Size = 100;
            this.parameternew_fldName.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldName);
            //--------------------------------------------------------
            this.parameternew_fldUserID = new SqlParameter();
            this.parameternew_fldUserID.ParameterName = "@new_fldUserID";
            this.parameternew_fldUserID.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldUserID.Size = 50;
            this.parameternew_fldUserID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldUserID);
            //--------------------------------------------------------
            this.parameternew_fldTimeType = new SqlParameter();
            this.parameternew_fldTimeType.ParameterName = "@new_fldTimeType";
            this.parameternew_fldTimeType.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldTimeType.Size = 50;
            this.parameternew_fldTimeType.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldTimeType);
            //--------------------------------------------------------
            this.parameternew_fldTimeRange = new SqlParameter();
            this.parameternew_fldTimeRange.ParameterName = "@new_fldTimeRange";
            this.parameternew_fldTimeRange.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldTimeRange.Size = 50;
            this.parameternew_fldTimeRange.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldTimeRange);
            //--------------------------------------------------------
            this.parameternew_fldItemGroup = new SqlParameter();
            this.parameternew_fldItemGroup.ParameterName = "@new_fldItemGroup";
            this.parameternew_fldItemGroup.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldItemGroup.Size = 50;
            this.parameternew_fldItemGroup.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldItemGroup);
            //--------------------------------------------------------
            this.parameternew_fldItemCode = new SqlParameter();
            this.parameternew_fldItemCode.ParameterName = "@new_fldItemCode";
            this.parameternew_fldItemCode.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldItemCode.Size = 4000;
            this.parameternew_fldItemCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldItemCode);
            //--------------------------------------------------------
            this.parameternew_fldPointGroup = new SqlParameter();
            this.parameternew_fldPointGroup.ParameterName = "@new_fldPointGroup";
            this.parameternew_fldPointGroup.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldPointGroup.Size = 50;
            this.parameternew_fldPointGroup.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldPointGroup);
            //--------------------------------------------------------
            this.parameternew_fldPointCode = new SqlParameter();
            this.parameternew_fldPointCode.ParameterName = "@new_fldPointCode";
            this.parameternew_fldPointCode.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldPointCode.Size = -1;
            this.parameternew_fldPointCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldPointCode);
            //--------------------------------------------------------
            this.parameternew_fldSource = new SqlParameter();
            this.parameternew_fldSource.ParameterName = "@new_fldSource";
            this.parameternew_fldSource.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldSource.Size = 50;
            this.parameternew_fldSource.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldSource);
            //--------------------------------------------------------
            this.parameternew_fldDataType = new SqlParameter();
            this.parameternew_fldDataType.ParameterName = "@new_fldDataType";
            this.parameternew_fldDataType.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldDataType.Size = 50;
            this.parameternew_fldDataType.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldDataType);
            //--------------------------------------------------------
            this.parameternew_fldSampleType = new SqlParameter();
            this.parameternew_fldSampleType.ParameterName = "@new_fldSampleType";
            this.parameternew_fldSampleType.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldSampleType.Size = 50;
            this.parameternew_fldSampleType.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldSampleType);
        }
    }
}

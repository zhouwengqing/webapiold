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

	public class usp_tblOrdertable_Insert : BaseProcedure
	{
		private SqlParameter parameterfldAutoID;

		private SqlParameter parameterfldCreatetime;

		private SqlParameter parameterfldtransactionnum;

		private SqlParameter parameterfldChannelnum;

		private SqlParameter parameterfldOrdernum;

		private SqlParameter parameterfldOrderAmount;

		private SqlParameter parameterfldRtefundAmount;

		private SqlParameter parameterfldMerchID;

		private SqlParameter parameterfldOrederdetailed;

		private SqlParameter parameterfldRateName;

		private SqlParameter parameterfldChannelType;

		private SqlParameter parameterfldChannelID;

		private SqlParameter parameterfldOrderInvalid;

		private SqlParameter parameterfldNotice;

		private SqlParameter parameterfldLaunchIP;

		private SqlParameter parameterfldStaute;

		private SqlParameter parameterfldchangstautetime;

		private SqlParameter parameterfldtransactiontime;

		private SqlParameter parameterfldSettlement;

		private SqlParameter parameterfldServiceCharge;


        private SqlParameter parameterfldRateCode;
        public usp_tblOrdertable_Insert()
		{
			base.InitCommand("usp_tblOrdertable_Insert");
			ConfigParameter();
		}

		public System.Int32 fldAutoID
		{
			get
			{
				return (System.Int32)this.parameterfldAutoID.Value;
			}
			set
			{
				this.parameterfldAutoID.Value=value;
			}
		}

		public System.DateTime fldCreatetime
		{
			get
			{
				return (System.DateTime)this.parameterfldCreatetime.Value;
			}
			set
			{
				this.parameterfldCreatetime.Value=value;
			}
		}

		public System.String fldtransactionnum
		{
			get
			{
				return (System.String)this.parameterfldtransactionnum.Value;
			}
			set
			{
				this.parameterfldtransactionnum.Value=value;
			}
		}

		public System.String fldChannelnum
		{
			get
			{
				return (System.String)this.parameterfldChannelnum.Value;
			}
			set
			{
				this.parameterfldChannelnum.Value=value;
			}
		}

		public System.String fldOrdernum
		{
			get
			{
				return (System.String)this.parameterfldOrdernum.Value;
			}
			set
			{
				this.parameterfldOrdernum.Value=value;
			}
		}

		public System.Decimal fldOrderAmount
		{
			get
			{
				return (System.Decimal)this.parameterfldOrderAmount.Value;
			}
			set
			{
				this.parameterfldOrderAmount.Value=value;
			}
		}

		public System.String fldRtefundAmount
		{
			get
			{
				return (System.String)this.parameterfldRtefundAmount.Value;
			}
			set
			{
				this.parameterfldRtefundAmount.Value=value;
			}
		}

		public System.String fldMerchID
		{
			get
			{
				return (System.String)this.parameterfldMerchID.Value;
			}
			set
			{
				this.parameterfldMerchID.Value=value;
			}
		}

        public System.String fldRateCode
        {
            get
            {
                return (System.String)this.parameterfldRateCode.Value;
            }
            set
            {
                this.parameterfldRateCode.Value = value;
            }
        }

        public System.String fldOrederdetailed
		{
			get
			{
				return (System.String)this.parameterfldOrederdetailed.Value;
			}
			set
			{
				this.parameterfldOrederdetailed.Value=value;
			}
		}

		public System.String fldRateName
		{
			get
			{
				return (System.String)this.parameterfldRateName.Value;
			}
			set
			{
				this.parameterfldRateName.Value=value;
			}
		}

		public System.String fldChannelType
		{
			get
			{
				return (System.String)this.parameterfldChannelType.Value;
			}
			set
			{
				this.parameterfldChannelType.Value=value;
			}
		}

		public System.String fldChannelID
		{
			get
			{
				return (System.String)this.parameterfldChannelID.Value;
			}
			set
			{
				this.parameterfldChannelID.Value=value;
			}
		}

		public System.String fldOrderInvalid
		{
			get
			{
				return (System.String)this.parameterfldOrderInvalid.Value;
			}
			set
			{
				this.parameterfldOrderInvalid.Value=value;
			}
		}

		public System.String fldNotice
		{
			get
			{
				return (System.String)this.parameterfldNotice.Value;
			}
			set
			{
				this.parameterfldNotice.Value=value;
			}
		}

		public System.String fldLaunchIP
		{
			get
			{
				return (System.String)this.parameterfldLaunchIP.Value;
			}
			set
			{
				this.parameterfldLaunchIP.Value=value;
			}
		}

		public System.String fldStaute
		{
			get
			{
				return (System.String)this.parameterfldStaute.Value;
			}
			set
			{
				this.parameterfldStaute.Value=value;
			}
		}

		public System.DateTime fldchangstautetime
		{
			get
			{
				return (System.DateTime)this.parameterfldchangstautetime.Value;
			}
			set
			{
				this.parameterfldchangstautetime.Value=value;
			}
		}

		public System.DateTime fldtransactiontime
		{
			get
			{
				return (System.DateTime)this.parameterfldtransactiontime.Value;
			}
			set
			{
				this.parameterfldtransactiontime.Value=value;
			}
		}

		public System.String fldSettlement
		{
			get
			{
				return (System.String)this.parameterfldSettlement.Value;
			}
			set
			{
				this.parameterfldSettlement.Value=value;
			}
		}

		public System.Decimal fldServiceCharge
		{
			get
			{
				return (System.Decimal)this.parameterfldServiceCharge.Value;
			}
			set
			{
				this.parameterfldServiceCharge.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldAutoID=new SqlParameter();
			this.parameterfldAutoID.ParameterName="@fldAutoID";
			this.parameterfldAutoID.SqlDbType=SqlDbType.Int;
			this.parameterfldAutoID.Size=4;
			this.parameterfldAutoID.Direction=ParameterDirection.InputOutput;
			base.m_cmd.Parameters.Add(this.parameterfldAutoID);
			//--------------------------------------------------------
			this.parameterfldCreatetime=new SqlParameter();
			this.parameterfldCreatetime.ParameterName="@fldCreatetime";
			this.parameterfldCreatetime.SqlDbType=SqlDbType.DateTime;
			this.parameterfldCreatetime.Size=8;
			this.parameterfldCreatetime.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldCreatetime);
			//--------------------------------------------------------
			this.parameterfldtransactionnum=new SqlParameter();
			this.parameterfldtransactionnum.ParameterName="@fldtransactionnum";
			this.parameterfldtransactionnum.SqlDbType=SqlDbType.VarChar;
			this.parameterfldtransactionnum.Size=60;
			this.parameterfldtransactionnum.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldtransactionnum);
			//--------------------------------------------------------
			this.parameterfldChannelnum=new SqlParameter();
			this.parameterfldChannelnum.ParameterName="@fldChannelnum";
			this.parameterfldChannelnum.SqlDbType=SqlDbType.VarChar;
			this.parameterfldChannelnum.Size=60;
			this.parameterfldChannelnum.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldChannelnum);
			//--------------------------------------------------------
			this.parameterfldOrdernum=new SqlParameter();
			this.parameterfldOrdernum.ParameterName="@fldOrdernum";
			this.parameterfldOrdernum.SqlDbType=SqlDbType.VarChar;
			this.parameterfldOrdernum.Size=60;
			this.parameterfldOrdernum.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldOrdernum);
			//--------------------------------------------------------
			this.parameterfldOrderAmount=new SqlParameter();
			this.parameterfldOrderAmount.ParameterName="@fldOrderAmount";
			this.parameterfldOrderAmount.SqlDbType=SqlDbType.Decimal;
			this.parameterfldOrderAmount.Size=17;
			this.parameterfldOrderAmount.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldOrderAmount);
			//--------------------------------------------------------
			this.parameterfldRtefundAmount=new SqlParameter();
			this.parameterfldRtefundAmount.ParameterName="@fldRtefundAmount";
			this.parameterfldRtefundAmount.SqlDbType=SqlDbType.VarChar;
			this.parameterfldRtefundAmount.Size=60;
			this.parameterfldRtefundAmount.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldRtefundAmount);
			//--------------------------------------------------------
			this.parameterfldMerchID=new SqlParameter();
			this.parameterfldMerchID.ParameterName="@fldMerchID";
			this.parameterfldMerchID.SqlDbType=SqlDbType.VarChar;
			this.parameterfldMerchID.Size=60;
			this.parameterfldMerchID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldMerchID);
			//--------------------------------------------------------
			this.parameterfldOrederdetailed=new SqlParameter();
			this.parameterfldOrederdetailed.ParameterName="@fldOrederdetailed";
			this.parameterfldOrederdetailed.SqlDbType=SqlDbType.VarChar;
			this.parameterfldOrederdetailed.Size=60;
			this.parameterfldOrederdetailed.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldOrederdetailed);
			//--------------------------------------------------------
			this.parameterfldRateName=new SqlParameter();
			this.parameterfldRateName.ParameterName="@fldRateName";
			this.parameterfldRateName.SqlDbType=SqlDbType.VarChar;
			this.parameterfldRateName.Size=60;
			this.parameterfldRateName.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldRateName);
			//--------------------------------------------------------
			this.parameterfldChannelType=new SqlParameter();
			this.parameterfldChannelType.ParameterName="@fldChannelType";
			this.parameterfldChannelType.SqlDbType=SqlDbType.VarChar;
			this.parameterfldChannelType.Size=60;
			this.parameterfldChannelType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldChannelType);
			//--------------------------------------------------------
			this.parameterfldChannelID=new SqlParameter();
			this.parameterfldChannelID.ParameterName="@fldChannelID";
			this.parameterfldChannelID.SqlDbType=SqlDbType.VarChar;
			this.parameterfldChannelID.Size=60;
			this.parameterfldChannelID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldChannelID);
			//--------------------------------------------------------
			this.parameterfldOrderInvalid=new SqlParameter();
			this.parameterfldOrderInvalid.ParameterName="@fldOrderInvalid";
			this.parameterfldOrderInvalid.SqlDbType=SqlDbType.VarChar;
			this.parameterfldOrderInvalid.Size=60;
			this.parameterfldOrderInvalid.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldOrderInvalid);
            //--------------------------------------------------------
            this.parameterfldRateCode = new SqlParameter();
            this.parameterfldRateCode.ParameterName = "@fldRateCode";
            this.parameterfldRateCode.SqlDbType = SqlDbType.VarChar;
            this.parameterfldRateCode.Size = 60;
            this.parameterfldRateCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldRateCode);
            //--------------------------------------------------------
            this.parameterfldNotice=new SqlParameter();
			this.parameterfldNotice.ParameterName="@fldNotice";
			this.parameterfldNotice.SqlDbType=SqlDbType.VarChar;
			this.parameterfldNotice.Size=60;
			this.parameterfldNotice.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldNotice);
			//--------------------------------------------------------
			this.parameterfldLaunchIP=new SqlParameter();
			this.parameterfldLaunchIP.ParameterName="@fldLaunchIP";
			this.parameterfldLaunchIP.SqlDbType=SqlDbType.VarChar;
			this.parameterfldLaunchIP.Size=60;
			this.parameterfldLaunchIP.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldLaunchIP);
			//--------------------------------------------------------
			this.parameterfldStaute=new SqlParameter();
			this.parameterfldStaute.ParameterName="@fldStaute";
			this.parameterfldStaute.SqlDbType=SqlDbType.VarChar;
			this.parameterfldStaute.Size=60;
			this.parameterfldStaute.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldStaute);
			//--------------------------------------------------------
			this.parameterfldchangstautetime=new SqlParameter();
			this.parameterfldchangstautetime.ParameterName="@fldchangstautetime";
			this.parameterfldchangstautetime.SqlDbType=SqlDbType.DateTime;
			this.parameterfldchangstautetime.Size=8;
			this.parameterfldchangstautetime.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldchangstautetime);
			//--------------------------------------------------------
			this.parameterfldtransactiontime=new SqlParameter();
			this.parameterfldtransactiontime.ParameterName="@fldtransactiontime";
			this.parameterfldtransactiontime.SqlDbType=SqlDbType.DateTime;
			this.parameterfldtransactiontime.Size=8;
			this.parameterfldtransactiontime.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldtransactiontime);
			//--------------------------------------------------------
			this.parameterfldSettlement=new SqlParameter();
			this.parameterfldSettlement.ParameterName="@fldSettlement";
			this.parameterfldSettlement.SqlDbType=SqlDbType.VarChar;
			this.parameterfldSettlement.Size=60;
			this.parameterfldSettlement.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldSettlement);
			//--------------------------------------------------------
			this.parameterfldServiceCharge=new SqlParameter();
			this.parameterfldServiceCharge.ParameterName="@fldServiceCharge";
			this.parameterfldServiceCharge.SqlDbType=SqlDbType.Decimal;
			this.parameterfldServiceCharge.Size=17;
			this.parameterfldServiceCharge.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldServiceCharge);
		}
	}
}

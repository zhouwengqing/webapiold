//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: v2.0.50727
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace DDYZ.Ensis.Presistence.DataEntity
{
	using System;
	using System.Data;
	using System.Data.SqlClient;
	using System.Data.SqlTypes;
	using System.Xml;
	using System.Reflection;

    [Serializable]
	public class tblFW_User : BaseDataEntity
	{
		[AttributePK]
		private System.Int32 m_fldAutoID;

		private System.String m_fldUserName;

		private System.String m_fldUserDesc;

		private System.String m_fldPassword;

		private System.Int32 m_fldDeptID;

		private System.Int32 m_fldCityID;

		private System.String m_fldDuty;

		private System.String m_fldHeaderShip;

		private System.Boolean m_fldSex;

		private System.Int16 m_fldEducation;

		private System.DateTime m_fldBirthday;

		private System.String m_fldEmail;

		private System.String m_fldPhone;

		private System.String m_fldMobile;

		private System.Boolean m_fldActive;

        private System.String m_fldMemo;

        private System.String m_fldRoleID;



        private System.String m_fldroles;

        private System.String m_fldintroduction;

        private System.String m_fldavatar;


        public tblFW_User()
		{
			base.InitMetaData();
        }

        /// <summary>
        /// ����ʵ���������
        /// </summary>
        /// <returns></returns>
        public tblFW_User Clone()
        {
            tblFW_User objNew = (tblFW_User)this.MemberwiseClone();
            return objNew;
        }

		public System.Int32 fldAutoID
		{
			get
			{
				return this.m_fldAutoID;
			}
			set
			{
				this.m_fldAutoID=value;
			}
		}

		public System.String fldUserName
		{
			get
			{
				return this.m_fldUserName;
			}
			set
			{
				this.m_fldUserName=value;
			}
		}

		public System.String fldUserDesc
		{
			get
			{
				return this.m_fldUserDesc;
			}
			set
			{
				this.m_fldUserDesc=value;
			}
		}

		public System.String fldPassword
		{
			get
			{
				return this.m_fldPassword;
			}
			set
			{
				this.m_fldPassword=value;
			}
		}

		public System.Int32 fldDeptID
		{
			get
			{
				return this.m_fldDeptID;
			}
			set
			{
				this.m_fldDeptID=value;
			}
		}

		public System.Int32 fldCityID
		{
			get
			{
				return this.m_fldCityID;
			}
			set
			{
				this.m_fldCityID=value;
			}
		}

		public System.String fldDuty
		{
			get
			{
				return this.m_fldDuty;
			}
			set
			{
				this.m_fldDuty=value;
			}
		}

		public System.String fldHeaderShip
		{
			get
			{
				return this.m_fldHeaderShip;
			}
			set
			{
				this.m_fldHeaderShip=value;
			}
		}

		public System.Boolean fldSex
		{
			get
			{
				return this.m_fldSex;
			}
			set
			{
				this.m_fldSex=value;
			}
		}

		public System.Int16 fldEducation
		{
			get
			{
				return this.m_fldEducation;
			}
			set
			{
				this.m_fldEducation=value;
			}
		}

		public System.DateTime fldBirthday
		{
			get
			{
				return this.m_fldBirthday;
			}
			set
			{
				this.m_fldBirthday=value;
			}
		}

		public System.String fldEmail
		{
			get
			{
				return this.m_fldEmail;
			}
			set
			{
				this.m_fldEmail=value;
			}
		}

		public System.String fldPhone
		{
			get
			{
				return this.m_fldPhone;
			}
			set
			{
				this.m_fldPhone=value;
			}
		}

		public System.String fldMobile
		{
			get
			{
				return this.m_fldMobile;
			}
			set
			{
				this.m_fldMobile=value;
			}
		}

		public System.Boolean fldActive
		{
			get
			{
				return this.m_fldActive;
			}
			set
			{
				this.m_fldActive=value;
			}
		}

		public System.String fldMemo
		{
			get
			{
				return this.m_fldMemo;
			}
			set
			{
				this.m_fldMemo=value;
			}
		}


        public System.String fldRoleID
        {
            get
            {
                return this.m_fldRoleID;
            }
            set
            {
                this.m_fldRoleID = value;
            }
        }

        public System.String fldintroduction
        {
            get
            {
                return this.m_fldintroduction;
            }
            set
            {
                this.m_fldintroduction = value;
            }
        }

        public System.String fldroles
        {
            get
            {
                return this.m_fldroles;
            }
            set
            {
                this.m_fldroles = value;
            }
        }

        public System.String fldavatar
        {
            get
            {
                return this.m_fldavatar;
            }
            set
            {
                this.m_fldavatar = value;
            }
        }
    }
}
﻿//------------------------------------------------------------------------------
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
    public class tblEQIW_D_Auditing : BaseDataEntity
    {
        [AttributePK]
        private System.Int64 m_fldAutoID;

        private System.Int64 m_fldBaseDataID;

        private System.String m_fldComment;

        public tblEQIW_D_Auditing()
        {
            base.InitMetaData();
        }

        /// <summary>
        /// 复制实体类的内容
        /// </summary>
        /// <returns></returns>
        public tblEQIW_D_Auditing Clone()
        {
            tblEQIW_D_Auditing objNew = (tblEQIW_D_Auditing)this.MemberwiseClone();
            return objNew;
        }

        public System.Int64 fldAutoID
        {
            get
            {
                return this.m_fldAutoID;
            }
            set
            {
                this.m_fldAutoID = value;
            }
        }

        public System.Int64 fldBaseDataID
        {
            get
            {
                return this.m_fldBaseDataID;
            }
            set
            {
                this.m_fldBaseDataID = value;
            }
        }

        public System.String fldComment
        {
            get
            {
                return this.m_fldComment;
            }
            set
            {
                this.m_fldComment = value;
            }
        }

    }
}

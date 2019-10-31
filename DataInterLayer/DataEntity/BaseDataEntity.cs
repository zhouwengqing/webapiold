using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Data;
using System.Diagnostics;
using DDYZ.Ensis.Library.Enum;
using DDYZ.Ensis.Library.Exception.Presistence;

namespace DDYZ.Ensis.Presistence.DataEntity
{
    /// <summary>
    /// ��������ʵ����Ļ���
    /// </summary>
    [Serializable]
    public abstract class BaseDataEntity
    {
        private bool m_IsEmpty = true;

        public BaseDataEntity()
        {
#if DEBUG
            ////���ҵ��õ�ǰ����ǲ���WebSite����������׳��쳣
            //bool bCanLoad = false;
            //StackTrace trace = new StackTrace();
            //if (trace.GetFrame(2).GetMethod().DeclaringType.BaseType.FullName == "PageBase" ||
            //    trace.GetFrame(2).GetMethod().DeclaringType.BaseType.FullName == "LoginPageBase" ||
            //    trace.GetFrame(2).GetMethod().DeclaringType.BaseType.FullName == "LoginHandler" ||
            //    trace.GetFrame(2).GetMethod().DeclaringType.BaseType.FullName.IndexOf("System.Web.UI") >= 0)
            //    bCanLoad = true;
            //if (trace.GetFrame(2).GetMethod().DeclaringType.Namespace != null && (
            //    trace.GetFrame(2).GetMethod().DeclaringType.Namespace.IndexOf("DDYZ.Ensis.Rule.BusinessRule") >= 0 ||
            //    trace.GetFrame(2).GetMethod().DeclaringType.Namespace.IndexOf("DDYZ.Ensis.Rule.DataRule") >= 0 || trace.GetFrame(2).GetMethod().DeclaringType.Namespace.IndexOf("DDYZ.Ensis.Services") >= 0
            //    || trace.GetFrame(2).GetMethod().DeclaringType.Namespace.IndexOf("EMCControls") >= 0))
            //    bCanLoad = true;
            //if (bCanLoad == false)
            //{
            //    throw new Exception("�����ֻ�ܱ�WebSite��BusinessRule��DataRule�������");
            //}
#endif
        }

        /// <summary>
        /// ʵ�����Ƿ�û�и�ֵ
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return m_IsEmpty;
            }
            set
            {
                m_IsEmpty = value;
            }
        }

        /// <summary>
        /// ��ʼ��ʵ����ĳ�Ա��Ĭ��ֵ
        /// </summary>
        public void InitMetaData()
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                if (property.IsDefined(typeof(AttributePK), false) == true)
                    continue;
                string typeString = property.PropertyType.ToString();
                switch (typeString)
                {
                    case "System.String":
                        property.SetValue(this, "", null);
                        break;
                    case "System.DateTime":
                        property.SetValue(this, Convert.ToDateTime("1900-01-01"), null);
                        break;
                    case "System.Int16":
                        property.SetValue(this, (short)0, null);
                        break;
                    case "System.Int32":
                        property.SetValue(this, 0, null);
                        break;
                    case "System.Int64":
                        property.SetValue(this, 0, null);
                        break;
                    case "System.Decimal":
                        property.SetValue(this, (decimal)0, null);
                        break;
                    case "System.Double":
                        property.SetValue(this, (double)0, null);
                        break;
                    case "System.Single":
                        property.SetValue(this, (float)0, null);
                        break;
                }
            }
        }

        /// <summary>
        /// �Ѹ�ʵ����ת��Ϊ���ݱ�
        /// </summary>
        public DataTable MetaDataTable
        {
            get
            {
                DataTable dtResult = this.GetSchema;

                // �������,�ѹ������Ժ͹����ֶε�ֵ�洢
                DataRow row = dtResult.NewRow();

                foreach (DataColumn column in dtResult.Columns)
                {
                    string propertyName = column.ColumnName;
                    PropertyInfo property = this.GetType().GetProperty(propertyName);
                    row[propertyName] = property.GetValue(this, null);
                }
                dtResult.Rows.Add(row);
                return dtResult;
            }
            set
            {
                // Ҫע����Ǵ������ı���е����������п��ܺ����Ե��������Ͳ�һ��
                // ���� DataTable
                DataTable dtReceive = value;

                // �����������Ϊ0�����ʾ��ʵ��û�г�ʼ����IsEmpty=true
                if (dtReceive.Rows.Count == 0)
                {
                    this.m_IsEmpty = true;
                    return;
                }

                this.m_IsEmpty = false;

                DataTable dtResult = this.MetaDataTable;
                DataRow rowResult = dtResult.Rows[0];

                // ��λ��������
                DataRow rowReceive = dtReceive.Rows[0];

                // ö��ʵ��������,�ѽ��ܵ�datatable�е����ݸ��o���������Լܹ���datatable
                foreach (DataColumn column in dtResult.Columns)
                {
                    string columnName = column.ColumnName;
                    if (IsInTableColumn(dtReceive, columnName) == true)
                    {
                        try
                        {
                            rowResult[columnName] = rowReceive[columnName];
                            PropertyInfo property = this.GetType().GetProperty(columnName);
                            property.SetValue(this, rowResult[columnName], null);
                        }
                        catch (Exception ept)
                        {
                            StackTrace trace = new StackTrace();
                            throw new EntityException(ept.Message, trace.GetFrame(1).GetMethod().
                                DeclaringType.FullName, "MetaDataTable set����", "");
                        }
                    }
                }
            } //set
        }

        /// <summary>
        /// ȡ��ʵ����ı�ṹ
        /// </summary>
        public DataTable GetSchema
        {
            get
            {
                string tableName = this.GetType().Name;
                DataTable dt = new DataTable(tableName);
                // �ܹ���ṹ
                // ö�ٹ�������-- public property	
                foreach (PropertyInfo myPro in this.GetType().GetProperties())
                {
                    string typeString = myPro.PropertyType.ToString();

                    // ���Ը����Ե����������Ƿ��ܱ��汾��֧��
                    if (IsSupportType(typeString) == true)
                    {
                        dt.Columns.Add(myPro.Name, Type.GetType(typeString));
                        dt.Columns[myPro.Name].AllowDBNull = true;
                    }
                } //foreach	
                return dt;
            }
        }

        /// <summary>
        /// �����ֶ������Ƿ�Ϊ���ܹ�֧�ֵ�����
        /// </summary>
        /// <param name="typeString">�ֶ�����(C#)</param>
        /// <returns>true / false</returns>
        private bool IsSupportType(string typeString)
        {
            bool IsSupport = false;
            switch (typeString)
            {
                case "System.Boolean":
                    IsSupport = true;
                    break;
                case "System.Byte":
                    IsSupport = true;
                    break;
                case "System.String":
                    IsSupport = true;
                    break;
                case "System.Byte[]":
                    IsSupport = true;
                    break;
                case "System.Char":
                    IsSupport = true;
                    break;
                case "System.DateTime":
                    IsSupport = true;
                    break;
                case "System.Decimal":
                    IsSupport = true;
                    break;
                case "System.Int32":
                    IsSupport = true;
                    break;
                case "System.Int64":
                    IsSupport = true;
                    break;
                case "System.Int16":
                    IsSupport = true;
                    break;
            }
            return IsSupport;

        }

        /// <summary>
        /// ����ĳ���ֶ��Ƿ��ڸñ���
        /// </summary>
        /// <param name="dt">Ҫ���ҵı�</param>
        /// <param name="colName">Ҫ���ҵ�������</param>
        /// <returns>true / false</returns>
        private bool IsInTableColumn(DataTable dt, string colName)
        {
            bool match = false;
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName.ToLower() == colName.ToLower())
                {
                    match = true;
                    break;
                }
            }
            return match;
        }

        /// <summary>
        /// ��ʵ����ת��Ϊxmlд���ļ�
        /// </summary>
        /// <param name="fileName">xml�ļ���·��������</param>
        public void WriteXmlData(string fileName)
        {
            DataSet ds = new DataSet("BaseEntitySet");
            DataTable dt = this.MetaDataTable;
            ds.Tables.Add(dt);
            ds.WriteXml(fileName, XmlWriteMode.WriteSchema);
        }

        /// <summary>
        /// ��ʵ����ת��Ϊxml�ĵ�����
        /// </summary>
        public XmlDocument XmlDom
        {
            get
            {
                DataSet ds = new DataSet("BaseEntitySet");
                DataTable dt = this.MetaDataTable;
                ds.Tables.Add(dt);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(ds.GetXml());
                return doc;
            }
        }
    }

    /// <summary>
    /// �Ƿ�ΪPK����������
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class AttributePK : Attribute
    {
        public AttributePK() { }
    }
}

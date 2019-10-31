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
    /// 所有数据实体类的基类
    /// </summary>
    [Serializable]
    public abstract class BaseDataEntity
    {
        private bool m_IsEmpty = true;

        public BaseDataEntity()
        {
#if DEBUG
            ////查找调用当前类的是不是WebSite，如果不是抛出异常
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
            //    throw new Exception("该组件只能被WebSite或BusinessRule、DataRule组件调用");
            //}
#endif
        }

        /// <summary>
        /// 实体类是否没有赋值
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
        /// 初始化实体类的成员的默认值
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
        /// 把该实体类转换为数据表
        /// </summary>
        public DataTable MetaDataTable
        {
            get
            {
                DataTable dtResult = this.GetSchema;

                // 添加新行,把公共属性和公共字段的值存储
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
                // 要注意的是传进来的表格列的数据类型有可能和属性的数据类型不一样
                // 接收 DataTable
                DataTable dtReceive = value;

                // 如果表格的行数为0，则表示该实体没有初始化，IsEmpty=true
                if (dtReceive.Rows.Count == 0)
                {
                    this.m_IsEmpty = true;
                    return;
                }

                this.m_IsEmpty = false;

                DataTable dtResult = this.MetaDataTable;
                DataRow rowResult = dtResult.Rows[0];

                // 定位首行数据
                DataRow rowReceive = dtReceive.Rows[0];

                // 枚举实体类属性,把接受的datatable中的数据赋給根据类属性架构的datatable
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
                                DeclaringType.FullName, "MetaDataTable set方法", "");
                        }
                    }
                }
            } //set
        }

        /// <summary>
        /// 取得实体类的表结构
        /// </summary>
        public DataTable GetSchema
        {
            get
            {
                string tableName = this.GetType().Name;
                DataTable dt = new DataTable(tableName);
                // 架构表结构
                // 枚举公共属性-- public property	
                foreach (PropertyInfo myPro in this.GetType().GetProperties())
                {
                    string typeString = myPro.PropertyType.ToString();

                    // 测试该属性的数据类型是否受本版本的支持
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
        /// 查找字段类型是否为本架构支持的类型
        /// </summary>
        /// <param name="typeString">字段类型(C#)</param>
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
        /// 查找某个字段是否在该表中
        /// </summary>
        /// <param name="dt">要查找的表</param>
        /// <param name="colName">要查找的列名称</param>
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
        /// 把实体类转换为xml写入文件
        /// </summary>
        /// <param name="fileName">xml文件的路径和名称</param>
        public void WriteXmlData(string fileName)
        {
            DataSet ds = new DataSet("BaseEntitySet");
            DataTable dt = this.MetaDataTable;
            ds.Tables.Add(dt);
            ds.WriteXml(fileName, XmlWriteMode.WriteSchema);
        }

        /// <summary>
        /// 把实体类转换为xml文档类型
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
    /// 是否为PK主键的属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class AttributePK : Attribute
    {
        public AttributePK() { }
    }
}

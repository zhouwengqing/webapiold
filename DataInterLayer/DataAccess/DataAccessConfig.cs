using System;
using System.Configuration;

namespace DDYZ.Ensis.DataSource.DataAccess
{
    public class DataAccessConfig
    {
        public DataAccessConfig()
        { }

        public static string DBServer
        {
            get
            {
                return ConfigurationManager.AppSettings["DbServer"];
            }
        }

        public static string DBName
        {
            get
            {
                return ConfigurationManager.AppSettings["DbName"];
            }
        }
        public static string FilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["FileDataPath"];
            }
        }
        public static string ConnString
        {
            get
            {
                string sConnString = "";
                sConnString += "server=" + ConfigurationManager.AppSettings["DbServer"] + ";";
                sConnString += "user id=" + ConfigurationManager.AppSettings["DbUid"] + ";";
                sConnString += "password=" + ConfigurationManager.AppSettings["DbPwd"] + ";";
                sConnString += "database=" + ConfigurationManager.AppSettings["DbName"] + ";";
                sConnString += "Connect Timeout=30;Connection Lifetime=109";
                return sConnString;
            }
        }

        public static string ConnString_PIS
        {
            get
            {
                string sConnString = "";
                sConnString += "server=" + ConfigurationManager.AppSettings["DbServer"] + ";";
                sConnString += "user id=" + ConfigurationManager.AppSettings["DbUid"] + ";";
                sConnString += "password=" + ConfigurationManager.AppSettings["DbPwd"] + ";";
                sConnString += "database=" + ConfigurationManager.AppSettings["DbPISName"] + ";";
                sConnString += "Connect Timeout=30;Connection Lifetime=109";
                return sConnString;
            }
        }

        public static string ConnStringConfig
        {
            get
            {
                string sConnString = "";
                sConnString += "server=" + ConfigurationManager.AppSettings["DbServer"] + ";";
                sConnString += "user id=" + ConfigurationManager.AppSettings["DbUid"] + ";";
                sConnString += "password=" + ConfigurationManager.AppSettings["DbPwd"] + ";";
                sConnString += "database=[database];";
                sConnString += "Connect Timeout=30;Connection Lifetime=109";
                return sConnString;
            }
        }

        public static string ConnStringLong
        {
            get
            {
                string sConnString = "";
                sConnString += "server=" + ConfigurationManager.AppSettings["DbServer"] + ";";
                sConnString += "user id=" + ConfigurationManager.AppSettings["DbUid"] + ";";
                sConnString += "password=" + ConfigurationManager.AppSettings["DbPwd"] + ";";
                sConnString += "database=" + ConfigurationManager.AppSettings["DbName"] + ";";
                sConnString += "Connect Timeout=[timeout];Connection Lifetime=[timeout]";
                return sConnString;
            }
        }

        /*通用报表服务的连接*/
        public static string ConnString_Report
        {
            get
            {
                string sConnString = "";
                sConnString += "server=" + ConfigurationManager.AppSettings["DbServer"] + ";";
                sConnString += "user id=" + ConfigurationManager.AppSettings["DbUid"] + ";";
                sConnString += "password=" + ConfigurationManager.AppSettings["DbPwd"] + ";";
                sConnString += "database=" + ConfigurationManager.AppSettings["DbReportName"] + ";";
                sConnString += "Connect Timeout=30;Connection Lifetime=109";
                return sConnString;
            }
        }

        /// <summary>
        /// 中间库的连接
        /// </summary>
        public static string ConnString_Middle
        {
            get
            {
                string sConnString = "";
                sConnString += "server=" + ConfigurationManager.AppSettings["DbServer"] + ";";
                sConnString += "user id=" + ConfigurationManager.AppSettings["DbUid"] + ";";
                sConnString += "password=" + ConfigurationManager.AppSettings["DbPwd"] + ";";
                sConnString += "database=" + ConfigurationManager.AppSettings["DbMiddle"] + ";";
                sConnString += "Connect Timeout=30;Connection Lifetime=109";
                return sConnString;
            }
        }

        /// <summary>
        /// 中间库临时连接
        /// </summary>
        public static string ConnString_Temporary_Middle
        {
            get
            {
                string sConnString = "";
                sConnString += "server=" + ConfigurationManager.AppSettings["DbServer_Middle"] + ";";
                sConnString += "user id=" + ConfigurationManager.AppSettings["DbUid_Middle"] + ";";
                sConnString += "password=" + ConfigurationManager.AppSettings["DbPwd_Middle"] + ";";
                sConnString += "database=" + ConfigurationManager.AppSettings["DbMiddle_Temp"] + ";";
                sConnString += "Connect Timeout=30;Connection Lifetime=109";
                return sConnString;
            }
        }


        /// <summary>
        /// 中间库临时连接
        /// </summary>
        public static string ConnString_PORTAL4
        {
            get
            {
                string sConnString = "";
                sConnString += "server=" + ConfigurationManager.AppSettings["DbServer"] + ";";
                sConnString += "user id=" + ConfigurationManager.AppSettings["DbUid"] + ";";
                sConnString += "password=" + ConfigurationManager.AppSettings["DbPwd"] + ";";
                sConnString += "database=" + ConfigurationManager.AppSettings["DbPORTAL4"] + ";";
                sConnString += "Connect Timeout=30;Connection Lifetime=109";
                return sConnString;
            }
        }



        /* LAP数据库连接字符串 */
        public static string ConnString_LAP
        {
            get
            {
                string sConnString = "";
                sConnString += "server=" + ConfigurationManager.AppSettings["DbServer"] + ";";
                sConnString += "user id=" + ConfigurationManager.AppSettings["DbUid"] + ";";
                sConnString += "password=" + ConfigurationManager.AppSettings["DbPwd"] + ";";
                sConnString += "database=" + ConfigurationManager.AppSettings["DbLAPName"] + ";";
                sConnString += "Connect Timeout=30;Connection Lifetime=109";
                return sConnString;
            }
        }

        public static string ConnStringConfig_LAP
        {
            get
            {
                string sConnString = "";
                sConnString += "server=" + ConfigurationManager.AppSettings["DbServer"] + ";";
                sConnString += "user id=" + ConfigurationManager.AppSettings["DbUid"] + ";";
                sConnString += "password=" + ConfigurationManager.AppSettings["DbPwd"] + ";";
                sConnString += "database=[database];";
                sConnString += "Connect Timeout=30;Connection Lifetime=109";
                return sConnString;
            }
        }


        public static string ConnStringLong_LAP
        {
            get
            {
                string sConnString = "";
                sConnString += "server=" + ConfigurationManager.AppSettings["DbServer"] + ";";
                sConnString += "user id=" + ConfigurationManager.AppSettings["DbUid"] + ";";
                sConnString += "password=" + ConfigurationManager.AppSettings["DbPwd"] + ";";
                sConnString += "database=" + ConfigurationManager.AppSettings["DbLAPName"] + ";";
                sConnString += "Connect Timeout=[timeout];Connection Lifetime=[timeout]";
                return sConnString;
            }
        }
    }
}

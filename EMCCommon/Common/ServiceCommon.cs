using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Lijoy.Service.EMCMIS
{
    /// <summary>
    /// 通用的服务类，提供如处理数据、转换级别、修约数值等功能
    /// author:都玉新
    /// date:20150612
    /// </summary>
    public static class ServiceCommon
    {
        /// <summary>
        /// 处理数据
        /// </summary>
        /// <param name="Dec">保留为数</param>
        /// <param name="dr">项目处理规则数据</param>
        /// <param name="val">需要处理的数据</param>
        /// <returns></returns>
        public static string GetRuleData(DataRow dr, decimal val, int Dec)
        {
            if (dr != null)
            {
                //最小
                decimal dMinD = decimal.Parse(dr["fldMinData"].ToString());
                //最小显示
                string sMinShow = dr["fldMinShow"].ToString();
                //范围最小
                decimal dMinSData = decimal.Parse(dr["fldMinSectionData"].ToString());
                //范围最大
                decimal dMaxSData = decimal.Parse(dr["fldMaxSectionData"].ToString());
                //范围修正
                decimal dSShow = decimal.Parse(dr["fldSectionShow"].ToString());
                //最大
                decimal dMaxD = decimal.Parse(dr["fldMaxData"].ToString());
                //最大显示
                string sMaxShow = dr["fldMaxShow"].ToString();
                //等于
                decimal dD = decimal.Parse(dr["fldData"].ToString());
                //等于显示
                string sDShow = dr["fldDataShow"].ToString();

                //等于
                if (val == dD && dD != -999)
                {
                    return sDShow;
                }
                //最小
                if (val < dMinD && dD != -999)
                {
                    return sMinShow;
                }
                //范围
                if (val >= dMinSData && val <= dMaxSData)
                {
                    return dSShow.ToString("G0");
                }
                //最大
                if (val > dMaxD && dD != -999)
                {
                    return sMaxShow;
                }
            }
            string strval = val.ToString().Split('.')[0] + (Dec == 0 ? "" : "." + (val.ToString().Split('.')[1].Length < Dec ? val.ToString().Split('.')[1] : val.ToString().Split('.')[1].Substring(0, Dec)));
            return strval.ToString();
        }

        /// <summary>
        /// 把水质类别的数字转换成Ⅰ、Ⅱ等
        /// </summary>
        /// <param name="strStageNum"></param>
        /// <returns></returns>
        public static string TransWaterStage(string strStageNum)
        {
            string strStage = "";
            switch (strStageNum)
            {
                case "1":
                    strStage = "Ⅰ";
                    break;
                case "2":
                    strStage = "Ⅱ";
                    break;
                case "3":
                    strStage = "Ⅲ";
                    break;
                case "4":
                    strStage = "Ⅳ";
                    break;
                case "5":
                    strStage = "Ⅴ";
                    break;
                case "6":
                    strStage = "劣Ⅴ";
                    break;
                default:
                    break;
            }

            return strStage;
        }

        /// <summary>
        /// 转换级别
        /// </summary>
        /// <param name="itype">类型(0:大气  1:水质)</param>
        /// <param name="ilevel">级别</param>
        /// <returns></returns>
        public static string GetAirOrWaterLevel(int itype, int ilevel)
        {
            string strLevel = "-";
            switch (ilevel)
            {
                case 1:
                    strLevel = (itype == 0 ? "一级" : "Ⅰ");
                    break;
                case 2:
                    strLevel = (itype == 0 ? "二级" : "Ⅱ");
                    break;
                case 3:
                    strLevel = (itype == 0 ? "三级" : "Ⅲ");
                    break;
                case 4:
                    strLevel = (itype == 0 ? "四级" : "Ⅳ");
                    break;
                case 5:
                    strLevel = (itype == 0 ? "五级" : "Ⅴ");
                    break;
                case 6:
                    strLevel = (itype == 0 ? "六级" : "劣Ⅴ");
                    break;
            }
            return strLevel;
        }
        /// <summary>
        /// 取得修约规则后的数值
        /// </summary>
        /// <param name="dt">修约数据</param>
        /// <param name="Item">项目代码</param>
        /// <param name="val">数据</param>
        /// <param name="Dec">保留位数</param>
        /// <returns></returns>
      

        public static string GetPValue(DataTable dt, string Item, decimal val, int Dec)
        {
            DataRow[] drRule = dt.Select("fldItemCode='" + Item + "'");
            if (drRule.Length > 0)
                return ServiceCommon.GetRuleData(drRule[0], val, Dec);
            else
                return val.ToString().Split('.')[0] + (Dec == 0 ? "" : "." + (val.ToString().Split('.')[1].Length < Dec ? val.ToString().Split('.')[1] : val.ToString().Split('.')[1].Substring(0, Dec)));
        }

        /// <summary>
        /// 获取返回的数据库值
        /// </summary>
        /// <param name="item">DataRow</param>
        /// <param name="strFielName">字段名称</param>
        /// <returns></returns>
        public static string GetDataValue(DataRow item, string strFielName)
        {
            string strTemp = "--";
            try
            {
                strTemp = item[strFielName] != null ? item[strFielName].ToString() : "";
            }
            catch(Exception ex)
            {
                strTemp = "--";
            }
           
            return strTemp;
        }
        /// <summary>
        ///判断输入字符串是否为数字
        /// </summary>
        /// <param name="nValue">字符串</param>
        /// <returns></returns>
        public static bool IsNumeric(string nValue)
        {
            int i, iAsc, idecimal = 0;
            if (nValue == null) return false;
            if (nValue.Trim() == "") return false;
            for (i = 0; i <= nValue.Length - 1; i++)
            {
                iAsc = (int)System.Convert.ToChar(nValue.Substring(i, 1));
                //'-'45 '.'46 '''0-9' 48-57
                if (iAsc == 45)
                {
                    if (nValue.Length == 1)//不能只有一个负号
                    {
                        return false;
                    }
                    if (i != 0)   //'-'不能在字符串中间
                    {
                        return false;
                    }
                }
                else if (iAsc == 46)
                {
                    idecimal++;
                    if (idecimal > 1)  //如果有两个以上的小数点
                        return false;
                }
                else if (iAsc < 48 || iAsc > 57)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///判断是否是字段浓度值
        /// </summary>
        /// <param name="strColumnName">字符串</param>
        /// <returns></returns>
        public static bool IsItemValue(string strColumnName)
        {
            string strCName = strColumnName;
            string strItemCode = strCName.Substring(strCName.Length - 3, 3);
            if (ServiceCommon.IsNumeric(strItemCode))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
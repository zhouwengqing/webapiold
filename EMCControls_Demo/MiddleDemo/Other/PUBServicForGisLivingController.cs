using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_DemoMiddle.Other
{
    /// <summary>
    /// 获取经纬度相关
    /// </summary>
    public class PUBServicForGisLivingController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  根据城市代码获取各业务测点城市经纬度
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-08-11
        /// 修改者      ：  
        /// 修改日期    ：  
        /// 修改原因    ：  
        /// </summary>
        /// <param name="stcode">城市代码 全部填-1</param>
        /// <returns></returns>
        public HttpResponseMessage GetLatitudeAndLongitude(string stcode = "-1")
        {
            string result = string.Empty;
            try
            {
                result = rule.JsonStr("ok", "", true);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        ///// <summary>
        ///// 功能描述    ：  根据城市代码获取各业务测点城市经纬度
        ///// 创建者      ：  徐雍文
        ///// 创建日期    ：  2017-08-11
        ///// 修改者      ：  
        ///// 修改日期    ：  
        ///// 修改原因    ：  
        ///// </summary>
        ///// <param name="modType">业务类型</param>
        ///// <param name="stcode">城市代码 全部填-1</param>
        ///// <returns></returns>
        //public HttpResponseMessage GetLatitudeAndLongitude(string modType,string stcode= "-1")
        //{
        //    string result = string.Empty;
        //    try
        //    {
        //        List<PointInfo> PointInfo = new List<PointInfo>();
        //        PointInfo pinfo;
        //        DataTable dt;
        //        RuletblEQIA_R_Point ruleEqia = new RuletblEQIA_R_Point();
        //        RuletblEQIW_R_Section ruleEqiW = new RuletblEQIW_R_Section();
        //        RuletblEQIW_L_Section ruleEqiWL = new RuletblEQIW_L_Section();

        //        switch (modType)
        //        {
        //            case "大气":
        //                #region 大气 
        //                List<tblEQIA_R_Point> ilst = ruleEqia.GetPointInfoForGis("");
        //                foreach (tblEQIA_R_Point tp in ilst)
        //                {
        //                    if (tp.fldLOD + (tp.fldLOM / 60) + (tp.fldLOS / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "空气自动站";
        //                        pinfo.AutoId = tp.fldAutoID.ToString();
        //                        pinfo.CityCode = tp.fldSTCode;
        //                        pinfo.CityName = tp.fldSTName;
        //                        pinfo.PCode = tp.fldPCode;
        //                        pinfo.PName = tp.fldPName;
        //                        pinfo.Attribute = tp.fldAttribute;
        //                        pinfo.Longitude = tp.fldLOD + (tp.fldLOM / 60) + (tp.fldLOS / 3600);
        //                        pinfo.Latitude = tp.fldLAD + (tp.fldLAM / 60) + (tp.fldLAS / 3600);
        //                        pinfo.PicPath = tp.fldPicPath;
        //                        pinfo.Level = tp.fldPLevel.ToString();

        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "降水":
        //                #region 降水 
        //                RuletblEQIA_P_Point ruleEqiaP = new RuletblEQIA_P_Point();
        //                List<tblEQIA_P_Point> ilstP = ruleEqiaP.GetPointInfoForGis();
        //                foreach (tblEQIA_P_Point tp in ilstP)
        //                {
        //                    if (tp.fldLOD + (tp.fldLOM / 60) + (tp.fldLOS / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "降水监测站";
        //                        pinfo.AutoId = tp.fldAutoID.ToString();
        //                        pinfo.CityCode = tp.fldSTCode;
        //                        pinfo.CityName = tp.fldSTName;
        //                        pinfo.PCode = tp.fldPCode;
        //                        pinfo.PName = tp.fldPName;
        //                        pinfo.Attribute = tp.fldAttribute;
        //                        pinfo.Longitude = tp.fldLOD + (tp.fldLOM / 60) + (tp.fldLOS / 3600);
        //                        pinfo.Latitude = tp.fldLAD + (tp.fldLAM / 60) + (tp.fldLAS / 3600);
        //                        pinfo.Level = tp.fldPLevel.ToString();
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            //case "降尘":
        //            //    #region 降尘 
        //            //    RuletblEQIA_RD_Point ruleEqiaRD = new RuletblEQIA_RD_Point();
        //            //    List<tblEQIA_RD_Point> ilstRD = ruleEqiaRD.GetPointInfoForGis();
        //            //    foreach (tblEQIA_RD_Point tp in ilstRD)
        //            //    {
        //            //        if (tp.fldLOD + (tp.fldLOM / 60) + (tp.fldLOS / 3600) > 0)
        //            //        {
        //            //            pinfo = new PointInfo();
        //            //            pinfo.PointType = "降尘监测站";
        //            //            pinfo.AutoId = tp.fldAutoID.ToString();
        //            //            pinfo.CityCode = tp.fldSTCode;
        //            //            pinfo.CityName = tp.fldSTName;
        //            //            pinfo.PCode = tp.fldPCode;
        //            //            pinfo.PName = tp.fldPName;
        //            //            pinfo.Attribute = tp.fldAttribute;
        //            //            pinfo.Longitude = tp.fldLOD + (tp.fldLOM / 60) + (tp.fldLOS / 3600);
        //            //            pinfo.Latitude = tp.fldLAD + (tp.fldLAM / 60) + (tp.fldLAS / 3600);
        //            //            pinfo.Remark = tp.fldRemark;
        //            //            pinfo.Level = tp.fldPLevel.ToString();
        //            //            PointInfo.Add(pinfo);
        //            //        }
        //            //    }
        //            //    #endregion
        //            //    break;
        //            case "大气-手动":
        //                #region 大气手动
        //                List<tblEQIA_R_Point> ilstS = ruleEqia.GetPointInfoForGis("手动");
        //                foreach (tblEQIA_R_Point tp in ilstS)
        //                {
        //                    if (tp.fldLOD + (tp.fldLOM / 60) + (tp.fldLOS / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "空气自动站";
        //                        pinfo.AutoId = tp.fldAutoID.ToString();
        //                        pinfo.CityCode = tp.fldSTCode;
        //                        pinfo.CityName = tp.fldSTName;
        //                        pinfo.PCode = tp.fldPCode;
        //                        pinfo.PName = tp.fldPName;
        //                        pinfo.Attribute = tp.fldAttribute;
        //                        pinfo.Longitude = tp.fldLOD + (tp.fldLOM / 60) + (tp.fldLOS / 3600);
        //                        pinfo.Latitude = tp.fldLAD + (tp.fldLAM / 60) + (tp.fldLAS / 3600);
        //                        pinfo.PicPath = tp.fldPicPath;
        //                        pinfo.Level = tp.fldPLevel.ToString();

        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "大气-自动":
        //                #region 大气自动
        //                List<tblEQIA_R_Point> ilstZ = ruleEqia.GetPointInfoForGis("自动");
        //                foreach (tblEQIA_R_Point tp in ilstZ)
        //                {
        //                    if (tp.fldLOD + (tp.fldLOM / 60) + (tp.fldLOS / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "空气自动站";
        //                        pinfo.AutoId = tp.fldAutoID.ToString();
        //                        pinfo.CityCode = tp.fldSTCode;
        //                        pinfo.CityName = tp.fldSTName;
        //                        pinfo.PCode = tp.fldPCode;
        //                        pinfo.PName = tp.fldPName;
        //                        pinfo.Attribute = tp.fldAttribute;
        //                        pinfo.Longitude = tp.fldLOD + (tp.fldLOM / 60) + (tp.fldLOS / 3600);
        //                        pinfo.Latitude = tp.fldLAD + (tp.fldLAM / 60) + (tp.fldLAS / 3600);
        //                        pinfo.PicPath = tp.fldPicPath;
        //                        pinfo.Level = tp.fldPLevel.ToString();

        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "河流":
        //                #region 水质 
        //                dt = ruleEqiW.GetPointInfoForGis("");
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (int.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "水质自动站";
        //                        pinfo.AutoId = dr["fldAutoID"].ToString();
        //                        pinfo.CityCode = dr["fldSTCode"].ToString();
        //                        pinfo.CityName = dr["fldSTName"].ToString();
        //                        pinfo.RiverCode = dr["fldRCode"].ToString();
        //                        pinfo.RiverName = dr["fldRName"].ToString();
        //                        pinfo.PCode = dr["fldRSCode"].ToString();
        //                        pinfo.PName = dr["fldRSName"].ToString();
        //                        pinfo.Longitude = int.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600);
        //                        pinfo.Latitude = int.Parse(dr["fldLAD"].ToString()) + (decimal.Parse(dr["fldLAM"].ToString()) / 60) + (decimal.Parse(dr["fldLAS"].ToString()) / 3600);
        //                        pinfo.PicPath = dr["fldPicPath"].ToString();
        //                        pinfo.RiverBasinName = dr["fldRiverBasinName"].ToString();
        //                        pinfo.Operators = dr["fldOperators"].ToString();
        //                        pinfo.ManagedStation = dr["fldManagedStation"].ToString();
        //                        pinfo.Level = dr["fldSLevel"].ToString();
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "河流-自动":
        //                #region 水质
        //                dt = ruleEqiW.GetPointInfoForGis("自动");
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (int.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "水质自动站";
        //                        pinfo.AutoId = dr["fldAutoID"].ToString();
        //                        pinfo.CityCode = dr["fldSTCode"].ToString();
        //                        pinfo.CityName = dr["fldSTName"].ToString();
        //                        pinfo.RiverCode = dr["fldRCode"].ToString();
        //                        pinfo.RiverName = dr["fldRName"].ToString();
        //                        pinfo.PCode = dr["fldRSCode"].ToString();
        //                        pinfo.PName = dr["fldRSName"].ToString();
        //                        pinfo.Longitude = int.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600);
        //                        pinfo.Latitude = int.Parse(dr["fldLAD"].ToString()) + (decimal.Parse(dr["fldLAM"].ToString()) / 60) + (decimal.Parse(dr["fldLAS"].ToString()) / 3600);
        //                        pinfo.PicPath = dr["fldPicPath"].ToString();
        //                        pinfo.RiverBasinName = dr["fldRiverBasinName"].ToString();
        //                        pinfo.Operators = dr["fldOperators"].ToString();
        //                        pinfo.ManagedStation = dr["fldManagedStation"].ToString();
        //                        pinfo.Level = dr["fldSLevel"].ToString();
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "河流-手动":
        //                #region 水质
        //                dt = ruleEqiW.GetPointInfoForGis("手动");
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (int.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "水质手动站";
        //                        pinfo.AutoId = dr["fldAutoID"].ToString();
        //                        pinfo.CityCode = dr["fldSTCode"].ToString();
        //                        pinfo.CityName = dr["fldSTName"].ToString();
        //                        pinfo.RiverCode = dr["fldRCode"].ToString();
        //                        pinfo.RiverName = dr["fldRName"].ToString();
        //                        pinfo.PCode = dr["fldRSCode"].ToString();
        //                        pinfo.PName = dr["fldRSName"].ToString();
        //                        pinfo.Longitude = int.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600);
        //                        pinfo.Latitude = int.Parse(dr["fldLAD"].ToString()) + (decimal.Parse(dr["fldLAM"].ToString()) / 60) + (decimal.Parse(dr["fldLAS"].ToString()) / 3600);
        //                        pinfo.PicPath = dr["fldPicPath"].ToString();
        //                        pinfo.RiverBasinName = dr["fldRiverBasinName"].ToString();
        //                        pinfo.Operators = dr["fldOperators"].ToString();
        //                        pinfo.ManagedStation = dr["fldManagedStation"].ToString();
        //                        pinfo.Level = dr["fldSLevel"].ToString();
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "饮用水":
        //                #region 饮用水
        //                RuletblEQIW_D_Section ruleEqiWD = new RuletblEQIW_D_Section();
        //                dt = ruleEqiWD.GetPointInfoForGis();
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (int.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "饮用水监测站";
        //                        pinfo.AutoId = dr["fldAutoID"].ToString();
        //                        pinfo.CityCode = dr["fldSTCode"].ToString();
        //                        pinfo.CityName = dr["fldSTName"].ToString();
        //                        pinfo.RiverCode = dr["fldRCode"].ToString();
        //                        pinfo.RiverName = dr["fldRName"].ToString();
        //                        pinfo.PCode = dr["fldRSCode"].ToString();
        //                        pinfo.PName = dr["fldRSName"].ToString();
        //                        pinfo.Longitude = int.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600);
        //                        pinfo.Latitude = int.Parse(dr["fldLAD"].ToString()) + (decimal.Parse(dr["fldLAM"].ToString()) / 60) + (decimal.Parse(dr["fldLAS"].ToString()) / 3600);
        //                        //pinfo.PicPath = dr["fldPicPath"].ToString();
        //                        //pinfo.RiverBasinName = dr["fldRiverBasinName"].ToString();
        //                        //pinfo.Operators = dr["fldOperators"].ToString();
        //                        //pinfo.ManagedStation = dr["fldManagedStation"].ToString();
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "湖库":
        //                #region 湖库 
        //                dt = ruleEqiWL.GetPointInfoForGis("手动");
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (int.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "水质自动站";
        //                        pinfo.AutoId = dr["fldAutoID"].ToString();
        //                        pinfo.CityCode = dr["fldSTCode"].ToString();
        //                        pinfo.CityName = dr["fldSTName"].ToString();
        //                        pinfo.RiverCode = dr["fldLCode"].ToString();
        //                        pinfo.RiverName = dr["fldLName"].ToString();
        //                        pinfo.PCode = dr["fldLSCode"].ToString();
        //                        pinfo.PName = dr["fldLSName"].ToString();
        //                        pinfo.Longitude = int.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600);
        //                        pinfo.Latitude = int.Parse(dr["fldLAD"].ToString()) + (decimal.Parse(dr["fldLAM"].ToString()) / 60) + (decimal.Parse(dr["fldLAS"].ToString()) / 3600);
        //                        //pinfo.PicPath = dr["fldPicPath"].ToString();
        //                        pinfo.RiverBasinName = dr["fldRiverBasinName"].ToString();
        //                        //  pinfo.Operators = dr["fldOperators"].ToString();
        //                        //  pinfo.ManagedStation = dr["fldManagedStation"].ToString();
        //                        pinfo.Level = dr["fldSLevel"].ToString();
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "废水":
        //            case "废气":
        //                #region 污染源
        //                RuletblEQIP_S_CompanyInfo ruleEqiP_S = new RuletblEQIP_S_CompanyInfo();
        //                dt = ruleEqiP_S.GetCompanyInfoForGis(modType);
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (Decimal.Parse(dr["Longitude"].ToString()) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "污染源企业";
        //                        pinfo.AutoId = dr["fldAutoID"].ToString();
        //                        pinfo.CityCode = dr["fldSTCode"].ToString();
        //                        pinfo.CityName = dr["fldSTName"].ToString();
        //                        pinfo.PCode = dr["fldCompanyCode"].ToString();
        //                        pinfo.PName = dr["fldCompanyName"].ToString();
        //                        pinfo.Longitude = Decimal.Parse(dr["Longitude"].ToString());
        //                        pinfo.Latitude = Decimal.Parse(dr["Latitude"].ToString());
        //                        //pinfo.PicPath = dr["fldPicPath"].ToString();
        //                        //pinfo.VideoPath = dr["fldVideoPath"].ToString();
        //                        //pinfo.Operators = dr["fldOperators"].ToString();
        //                        //pinfo.ManagedStation = dr["fldManagedStation"].ToString();
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "污水厂":
        //                #region 污水厂
        //                RuletblEQIP_W_WaterCompanyInfo ruleEqiP_W = new RuletblEQIP_W_WaterCompanyInfo();
        //                dt = ruleEqiP_W.GetCompanyInfoForGis();
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (Decimal.Parse(dr["Longitude"].ToString()) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "污染源企业";
        //                        pinfo.AutoId = dr["fldAutoID"].ToString();
        //                        pinfo.CityCode = dr["fldSTCode"].ToString();
        //                        pinfo.CityName = dr["fldSTName"].ToString();
        //                        pinfo.PCode = dr["fldCompanyCode"].ToString();
        //                        pinfo.PName = dr["fldCompanyName"].ToString();
        //                        pinfo.Longitude = Decimal.Parse(dr["Longitude"].ToString());
        //                        pinfo.Latitude = Decimal.Parse(dr["Latitude"].ToString());
        //                        //pinfo.PicPath = dr["fldPicPath"].ToString();
        //                        //pinfo.VideoPath = dr["fldVideoPath"].ToString();
        //                        //pinfo.Operators = dr["fldOperators"].ToString();
        //                        //pinfo.ManagedStation = dr["fldManagedStation"].ToString();
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "噪声":
        //                #region 噪声
        //                RuletblEQIN_T_Point ruleEqin = new RuletblEQIN_T_Point();
        //                List<tblEQIN_T_Point> lstEqin = ruleEqin.GetRDInfoForGis();
        //                foreach (tblEQIN_T_Point tp in lstEqin)
        //                {
        //                    if (tp.fldStaLod > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "噪声自动站";
        //                        pinfo.AutoId = tp.fldAutoID.ToString();
        //                        pinfo.CityCode = tp.fldSTCode;
        //                        pinfo.CityName = tp.fldSTName;
        //                        pinfo.PCode = tp.fldRDCode;
        //                        pinfo.PName = tp.fldRDName;
        //                        pinfo.Attribute = tp.fldAttribute;
        //                        pinfo.Longitude = tp.fldStaLod;
        //                        pinfo.Latitude = tp.fldStaLad;
        //                        pinfo.PicPath = tp.fldPicPath;
        //                        pinfo.VideoPath = tp.fldVideoPath;
        //                        pinfo.ManagedStation = tp.fldVideoPath;
        //                        pinfo.Operators = tp.fldOperators;
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            //case "功能区噪声":
        //            //    #region 功能区噪声
        //            //    RuletblEQIN_F_Point ruleEqinF = new RuletblEQIN_F_Point();
        //            //    dt = ruleEqinF.GetPointInfoForGis("自动");
        //            //    foreach (DataRow dr in dt.Rows)
        //            //    {
        //            //        if (dr["fldLOD"].ToString() == "") continue;
        //            //        if (decimal.Parse(dr["fldLOD"].ToString()) > 0)
        //            //        {
        //            //            pinfo = new PointInfo();
        //            //            pinfo.PointType = "功能区噪声";
        //            //            pinfo.CityCode = dr["fldSTCode"].ToString();
        //            //            pinfo.CityName = dr["fldSTName"].ToString();
        //            //            pinfo.PCode = dr["fldPCode"].ToString();
        //            //            pinfo.PName = dr["fldPName"].ToString();
        //            //            pinfo.Attribute = dr["fldAttribute"].ToString();
        //            //            pinfo.Longitude = decimal.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600);
        //            //            pinfo.Latitude = decimal.Parse(dr["fldLAD"].ToString()) + (decimal.Parse(dr["fldLAM"].ToString()) / 60) + (decimal.Parse(dr["fldLAS"].ToString()) / 3600);
        //            //            pinfo.Fun = dr["fldNDISC"].ToString();
        //            //            PointInfo.Add(pinfo);
        //            //        }
        //            //    }
        //            //    #endregion
        //            //    break;
        //            //case "功能区噪声_手动":
        //            //    #region 功能区噪声
        //            //    ruleEqinF = new RuletblEQIN_F_Point();
        //            //    dt = ruleEqinF.GetPointInfoForGis("手动");
        //            //    foreach (DataRow dr in dt.Rows)
        //            //    {
        //            //        if (dr["fldStaLod"].ToString() == "") continue;
        //            //        if (decimal.Parse(dr["fldStaLod"].ToString()) > 0)
        //            //        {
        //            //            pinfo = new PointInfo();
        //            //            pinfo.PointType = "功能区噪声";
        //            //            pinfo.CityCode = dr["fldSTCode"].ToString();
        //            //            pinfo.CityName = dr["fldSTName"].ToString();
        //            //            pinfo.PCode = dr["fldPCode"].ToString();
        //            //            pinfo.PName = dr["fldPName"].ToString();
        //            //            pinfo.Attribute = dr["fldAttribute"].ToString();
        //            //            pinfo.Longitude = decimal.Parse(dr["fldStaLod"].ToString());
        //            //            pinfo.Latitude = decimal.Parse(dr["fldStaLad"].ToString());
        //            //            pinfo.Fun = dr["fldNDISC"].ToString();
        //            //            PointInfo.Add(pinfo);
        //            //        }
        //            //    }
        //            //    #endregion
        //            //    break;
        //            case "海水水质":
        //                #region 海水水质
        //                RuletblEQIS_W_Point ruleEqiS_W = new RuletblEQIS_W_Point();
        //                dt = ruleEqiS_W.GetPointInfoForGis();
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (decimal.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "海水自动站";
        //                        pinfo.AutoId = dr["fldAutoID"].ToString();
        //                        pinfo.SeaWaterCode = dr["fldSeaAreaCode"].ToString();
        //                        pinfo.SeaWaterName = dr["fldSeaAreaName"].ToString();
        //                        pinfo.CityCode = dr["fldSTCode"].ToString();
        //                        pinfo.CityName = dr["fldSTName"].ToString();
        //                        pinfo.PCode = dr["fldPCode"].ToString();
        //                        pinfo.PName = dr["fldPName"].ToString();
        //                        pinfo.Longitude = decimal.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600);
        //                        pinfo.Latitude = decimal.Parse(dr["fldLAD"].ToString()) + (decimal.Parse(dr["fldLAM"].ToString()) / 60) + (decimal.Parse(dr["fldLAS"].ToString()) / 3600);
        //                        pinfo.PicPath = dr["fldPicPath"].ToString();
        //                        pinfo.Operators = dr["fldOperators"].ToString();
        //                        pinfo.ManagedStation = dr["fldManagedStation"].ToString();
        //                        pinfo.VideoPath = dr["fldVideoPath"].ToString();
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "海洋沉积物":
        //                #region 海洋沉积物
        //                RuletblEQIS_D_Point ruleEqiS_D = new RuletblEQIS_D_Point();
        //                dt = ruleEqiS_D.GetPointInfoForGis();
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (decimal.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "沉积物自动站";
        //                        pinfo.AutoId = dr["fldAutoID"].ToString();
        //                        pinfo.SeaWaterCode = dr["fldSeaAreaCode"].ToString();
        //                        pinfo.SeaWaterName = dr["fldSeaAreaName"].ToString();
        //                        pinfo.CityCode = dr["fldSTCode"].ToString();
        //                        pinfo.CityName = dr["fldSTName"].ToString();
        //                        pinfo.PCode = dr["fldPCode"].ToString();
        //                        pinfo.PName = dr["fldPName"].ToString();
        //                        pinfo.Longitude = decimal.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600);
        //                        pinfo.Latitude = decimal.Parse(dr["fldLAD"].ToString()) + (decimal.Parse(dr["fldLAM"].ToString()) / 60) + (decimal.Parse(dr["fldLAS"].ToString()) / 3600);
        //                        pinfo.PicPath = dr["fldPicPath"].ToString();
        //                        pinfo.Operators = dr["fldOperators"].ToString();
        //                        pinfo.ManagedStation = dr["fldManagedStation"].ToString();
        //                        pinfo.VideoPath = dr["fldVideoPath"].ToString();
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "海洋生物残毒":
        //                #region 海洋生物残毒
        //                RuletblEQIS_P_Point ruleEqiS_P = new RuletblEQIS_P_Point();
        //                dt = ruleEqiS_P.GetPointInfoForGis();
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (decimal.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "生物残毒自动站";
        //                        pinfo.AutoId = dr["fldAutoID"].ToString();
        //                        pinfo.SeaWaterCode = dr["fldSeaAreaCode"].ToString();
        //                        pinfo.SeaWaterName = dr["fldSeaAreaName"].ToString();
        //                        pinfo.CityCode = dr["fldSTCode"].ToString();
        //                        pinfo.CityName = dr["fldSTName"].ToString();
        //                        pinfo.PCode = dr["fldPCode"].ToString();
        //                        pinfo.PName = dr["fldPName"].ToString();
        //                        pinfo.Longitude = decimal.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600);
        //                        pinfo.Latitude = decimal.Parse(dr["fldLAD"].ToString()) + (decimal.Parse(dr["fldLAM"].ToString()) / 60) + (decimal.Parse(dr["fldLAS"].ToString()) / 3600);
        //                        pinfo.PicPath = dr["fldPicPath"].ToString();
        //                        pinfo.Operators = dr["fldOperators"].ToString();
        //                        pinfo.ManagedStation = dr["fldManagedStation"].ToString();
        //                        pinfo.VideoPath = dr["fldVideoPath"].ToString();
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;

        //            case "潮间带沉积物":
        //                #region 潮间带海洋沉积物
        //                RuletblEQIS_DZ_Point ruleEqiS_DZ = new RuletblEQIS_DZ_Point();
        //                dt = ruleEqiS_DZ.GetPointInfoForGis();
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (decimal.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "潮间带沉积物";
        //                        pinfo.AutoId = dr["fldAutoID"].ToString();
        //                        pinfo.SeaWaterCode = dr["fldSeaAreaCode"].ToString();
        //                        pinfo.SeaWaterName = dr["fldSeaAreaName"].ToString();
        //                        pinfo.CityCode = dr["fldSTCode"].ToString();
        //                        pinfo.CityName = dr["fldSTName"].ToString();
        //                        pinfo.PCode = dr["fldPCode"].ToString();
        //                        pinfo.PName = dr["fldPName"].ToString();
        //                        pinfo.Longitude = decimal.Parse(dr["fldLOD"].ToString()) + (decimal.Parse(dr["fldLOM"].ToString()) / 60) + (decimal.Parse(dr["fldLOS"].ToString()) / 3600);
        //                        pinfo.Latitude = decimal.Parse(dr["fldLAD"].ToString()) + (decimal.Parse(dr["fldLAM"].ToString()) / 60) + (decimal.Parse(dr["fldLAS"].ToString()) / 3600);
        //                        pinfo.PicPath = dr["fldPicPath"].ToString();
        //                        pinfo.Operators = dr["fldOperators"].ToString();
        //                        pinfo.ManagedStation = dr["fldManagedStation"].ToString();
        //                        pinfo.VideoPath = dr["fldVideoPath"].ToString();
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            case "电磁辐射":
        //                #region 电磁辐射
        //                RuletblEQID_D_Point ruleEqiD = new RuletblEQID_D_Point();
        //                List<tblEQID_D_Point> lstD = ruleEqiD.GetPointInfoForGis();
        //                foreach (tblEQID_D_Point tp in lstD)
        //                {
        //                    if ((int.Parse(tp.fldLOD) + decimal.Parse(tp.fldLOM) / 60 + decimal.Parse(tp.fldLOS) / 3600) > 0)
        //                    {
        //                        pinfo = new PointInfo();
        //                        pinfo.PointType = "电磁辐射";
        //                        pinfo.AutoId = tp.fldAutoID.ToString();
        //                        pinfo.CityCode = tp.fldSTCode;
        //                        pinfo.CityName = tp.fldSTName;
        //                        pinfo.PCode = tp.fldPCode;
        //                        pinfo.PName = tp.fldPName;
        //                        pinfo.Attribute = tp.fldAttribute;
        //                        pinfo.Longitude = int.Parse(tp.fldLOD) + decimal.Parse(tp.fldLOM) / 60 + decimal.Parse(tp.fldLOS) / 3600;
        //                        pinfo.Latitude = int.Parse(tp.fldLAD) + decimal.Parse(tp.fldLAM) / 60 + decimal.Parse(tp.fldLAS) / 3600;
        //                        pinfo.PicPath = tp.fldPicPath;
        //                        pinfo.VideoPath = tp.fldVideoPath;
        //                        pinfo.ManagedStation = tp.fldManagedStation;
        //                        pinfo.Operators = tp.fldOperators;
        //                        PointInfo.Add(pinfo);
        //                    }
        //                }
        //                #endregion
        //                break;
        //            default:
        //                break;
        //        }
        //        result = rule.JsonStr("ok", "", PointInfo,true);
        //    }
        //    catch (Exception e)
        //    {
        //        result = rule.JsonStr("error", e.Message, "");
        //    }
        //    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        //}
    }
}

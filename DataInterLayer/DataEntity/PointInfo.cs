using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Presistence.DataEntity
{
    public class PointInfo
    {
        public string AutoId;
        /// <summary>
        /// 站点类型(大气/水质)
        /// </summary>
        public string PointType;
        /// <summary>
        /// 流域
        /// </summary>
        public string RiverBasinName;
        /// <summary>
        /// 城市代码
        /// </summary> 
        public string CityCode;
        /// <summary>
        /// 城市名称
        /// </summary> 
        public string CityName;
        /// <summary>
        /// 河流代码
        /// </summary>
        public string RiverCode;
        /// <summary>
        /// 河流名称
        /// </summary>
        public string RiverName;
        /// <summary>
        /// 测点/断面代码
        /// </summary> 
        public string PCode;
        /// <summary>
        /// 测点/断面名称
        /// </summary> 
        public string PName;
        /// <summary>
        /// 断面级别
        /// </summary>
        public string Level;
        /// <summary>
        /// 功能区类别
        /// </summary>
        public string Fun;
        /// <summary>
        /// 属性
        /// </summary> 
        public string Attribute;
        /// <summary>
        /// 经度
        /// </summary> 
        public decimal Longitude;
        /// <summary>
        /// 纬度
        /// </summary> 
        public decimal Latitude;
        /// <summary>
        /// 运营商
        /// </summary>
        public string Operators;
        /// <summary>
        /// 托管站
        /// </summary>
        public string ManagedStation;
        /// <summary>
        /// 图片地址
        /// </summary> 
        public string PicPath;
        /// <summary>
        /// 视频地址
        /// </summary>
        public string VideoPath;
        /// <summary>
        /// 海水代码
        /// </summary>
        public string SeaWaterCode;
        /// <summary>
        /// 海水名称
        /// </summary>
        public string SeaWaterName;

        /// <summary>
        /// 国家考核断面
        /// </summary>
        public string GuoKao;

        /// <summary>
        /// 区县考核断面
        /// </summary>
        public string QuKao;

        /// <summary>
        /// GIS用断面级别
        /// </summary>
        public string GISLevel;

        /// <summary>
        /// 水务河流级别
        /// </summary>
        public string RiverLevel;

        /// <summary>
        /// 信息公开
        /// </summary>
        public string InfoPublish;

        /// <summary>
        /// 进出水断面
        /// </summary>
        public string OutOrIn;

        /// <summary>
        /// 是否湖库断面
        /// </summary>
        public string IFLSection;

        /// <summary>
        /// 是否水源地断面
        /// </summary>
        public string IFDSection;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark;
    }
}

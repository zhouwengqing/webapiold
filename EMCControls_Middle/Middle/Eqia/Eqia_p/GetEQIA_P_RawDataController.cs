using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqia.Eqia_p
{
    public class GetEQIA_P_RawDataController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由通用存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-14
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetRawData(Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldPCode",info.fldPCode),
                    new SqlParameter("@pHStand",info.pHStand),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@IsPre",info.IsPre),
                    new SqlParameter("@IsYear",info.IsYear),
                    new SqlParameter("@IsTotal",info.IsTotal),
                    new SqlParameter("@IsDetail",info.IsDetail),
                    new SqlParameter("@AppriseID",info.AppriseID),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@SpaceID",info.SpaceID),
                    new SqlParameter("@CalculateID",info.CalculateID)
                };

                dt = rule.RunProcedure("usp_tblEQIA_P_Report_AppriseStat", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 存储过程参数实体
        /// </summary>
        public class Info
        {
            /// <summary>
            /// 时间类型
            /// </summary>
            public string TimeType { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndDate { get; set; }
             
            /// <summary>
            /// 测点代码
            /// </summary>
            public string fldPCode { get; set; }

            /// <summary>
            /// 标准值
            /// </summary>
            public double pHStand { get; set; }

            /// <summary>
            /// 项目id
            /// </summary>
            public string fldItemCode { get; set; }

            /// <summary>
            /// 平均值取值方法
            /// </summary>
            public string DecCarry { get; set; }

            /// <summary>
            /// 是否统计前期数据
            /// </summary>
            public int IsPre { get; set; }

            /// <summary>
            /// 是否统计同期数据
            /// </summary>
            public int IsYear { get; set; }

            /// <summary>
            /// 是否统计合计值
            /// </summary>
            public int IsTotal { get; set; }

            /// <summary>
            /// 是否统计明细，明细跟平均必须有一个值为1
            /// </summary>
            public int IsDetail { get; set; }

            /// <summary>
            /// 0:针对单个点位评价、1：针对城市评价
            /// </summary>
            public int AppriseID { get; set; }


            /// <summary>
            /// 统计方法，根据参数返回不同结果
            /// 0：原始数据表(不带L)
            /// 10：原始数据表（带L）
            /// 1：降水点位、城市监测结果统计
            /// 2：点位、城市各时段酸雨频率、酸度比例
            /// 3：各时段点位、城市酸雨频率、酸度比例
            /// 4、阴阳离子平衡
            /// 5、样品数统计表
            /// 6、离子当量比例
            /// 7、离子当量浓度
            /// 90：降水pH值秩相关
            /// 91：酸雨频率秩相关
            /// 92：离子浓度秩相关
            /// 93：硫硝当量比
            /// 94：阴阳离子当量比
            /// </summary>
            public int STatType { get; set; }

            /// <summary>
            /// 0：按照郊区城区统计；1：按照两控区非两控区统计
            /// </summary>
            public int SpaceID { get; set; }

            /// <summary>
            /// 全省酸雨率计算方法：0城市均值、1酸雨次数除以降水次数
            /// </summary>
            public int CalculateID { get; set; }

        }






    }
}

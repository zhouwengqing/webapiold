using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Presistence.DataEntity
{
    public class tblOrdertable
    {
        #region 实体属性

        /// <summary>
        /// fldAutoID
        /// </summary>
        public int fldAutoID { get; set; }

        /// <summary>
        /// fldCreatetime
        /// </summary>
        public DateTime? fldCreatetime { get; set; }

        /// <summary>
        /// fldtransactionnum
        /// </summary>
        public string fldtransactionnum { get; set; }

        /// <summary>
        /// fldChannelnum
        /// </summary>
        public string fldChannelnum { get; set; }

        /// <summary>
        /// fldOrdernum
        /// </summary>
        public string fldOrdernum { get; set; }

        /// <summary>
        /// fldOrderAmount
        /// </summary>
        public decimal fldOrderAmount { get; set; }

        /// <summary>
        /// fldRtefundAmount
        /// </summary>
        public decimal fldRtefundAmount { get; set; }

        /// <summary>
        /// fldMerchID
        /// </summary>
        public string fldMerchID { get; set; }

        /// <summary>
        /// fldOrederdetailed
        /// </summary>
        public string fldOrederdetailed { get; set; }

        /// <summary>
        /// fldRateName
        /// </summary>
        public string fldRateName { get; set; }

        /// <summary>
        /// fldRateCode
        /// </summary>
        public string fldRateCode { get; set; }

        /// <summary>
        /// fldChannelType
        /// </summary>
        public string fldChannelType { get; set; }

        /// <summary>
        /// fldChannelID
        /// </summary>
        public string fldChannelID { get; set; }

        /// <summary>
        /// fldOrderInvalid
        /// </summary>
        public DateTime? fldOrderInvalid { get; set; }

        /// <summary>
        /// fldNotice
        /// </summary>
        public string fldNotice { get; set; }

        /// <summary>
        /// fldLaunchIP
        /// </summary>
        public string fldLaunchIP { get; set; }

        /// <summary>
        /// fldStaute
        /// </summary>
        public string fldStaute { get; set; }

        /// <summary>
        /// fldchangstautetime
        /// </summary>
        public DateTime fldchangstautetime { get; set; }

        /// <summary>
        /// fldtransactiontime
        /// </summary>
        public DateTime fldtransactiontime { get; set; }

        /// <summary>
        /// fldSettlement
        /// </summary>
        public decimal fldSettlement { get; set; }

        /// <summary>
        /// fldServiceCharge
        /// </summary>
        public decimal fldServiceCharge { get; set; }

       

        #endregion
    }
}

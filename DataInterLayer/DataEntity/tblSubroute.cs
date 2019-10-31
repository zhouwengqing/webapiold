namespace DDYZ.Ensis.Presistence.DataEntity
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.Xml;
    using System.Reflection;


    public partial class newtblSubroute : BaseDataEntity
    {


        public int fldAutoID { get; set; }



        public string fldGatewaynumber { get; set; }


        public string fldType { get; set; }



        public string fldRateCode { get; set; }



        public string fldPayType { get; set; }


        public int fldMinmoney { get; set; }


        public int fldMaxmoney { get; set; }


        public string fldWeight { get; set; }


        public bool fldState { get; set; }


        public string fldProhibitMerchant { get; set; }

        public string fldEncryptionWay { get; set; }
    }
}

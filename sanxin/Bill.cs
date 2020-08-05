using System;

namespace sanxin
{
    public class Bill
    {
        public string BILLNO { get; set; }

        public DateTime FDATE { get; set; }

        public int FENTRYID { get; set; }

        public int FSUPPLYID { get; set; }

        public int FDCSPID { get; set; }

        public int FITEMID { get; set; }

        public decimal FQTY { get; set; }

        public string FBATCHNO { get; set; }

        public string FNOTE { get; set; }
    }
}

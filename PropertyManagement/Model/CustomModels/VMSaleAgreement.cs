using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Model.CustomModels
{
    public class VMSaleAgreement
    {
        public DateTime bookdate { get; set; }
        public string project { get; set; }
        public string address { get; set; }
        public string customername { get; set; }
        public string customercnic { get; set; }
        public string customeraddress { get; set; }
        public string plotvalue { get; set; }
        public string membershipno { get; set; }
        public string plotfactor { get; set; }
        public string size { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Model.tblModel
{
    public class kinModel
    {
        public long CustomerKinId { get; set; }
        public long fkCustomerId { get; set; }
        public string KinName { get; set; }
        public string KinCNIC { get; set; }
        public string KinMobile { get; set; }
        public string KinRelation { get; set; }
        public bool ActiveYN { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}

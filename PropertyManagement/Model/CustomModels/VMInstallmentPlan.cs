using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Model.CustomModels
{
    public class VMInstallmentPlan
    {
        public int Month { get; set; }
        public string paymentDescription { get; set; }
        public long Installment { get; set; }
        public long Remaining { get; set; }
        public DateTime DueDate { get; set; }
    }
}

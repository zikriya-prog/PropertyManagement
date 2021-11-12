using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Model.CustomModels
{
    public class VMPlotSaleForm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public string Mob { get; set; }
        public string Nic { get; set; }
        public string PropertyDetails { get; set; }
        public string Size { get; set; }
        public string TotalPrice { get; set; }
        public string Discount { get; set; }
        public string DiscountedPrice { get; set; }
        public string DownPayment { get; set; }
        public string BalanceDue { get; set; }
        public string InstallmentDueDate { get; set; }
    }
}

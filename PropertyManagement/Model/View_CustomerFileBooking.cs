//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PropertyManagement.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class View_CustomerFileBooking
    {
        public long FileBookID { get; set; }
        public int fkFileID { get; set; }
        public string MemberShipNo { get; set; }
        public long CustomerID { get; set; }
        public string fkProjectID { get; set; }
        public string SubProjID { get; set; }
        public string CustomerRegNo { get; set; }
        public string FatherName { get; set; }
        public string CustomerName { get; set; }
        public string CNIC { get; set; }
        public string Mobile { get; set; }
        public string PresentAddress { get; set; }
        public string PermAddress { get; set; }
        public string OfficeNumber { get; set; }
        public string DealerYN { get; set; }
        public string ActiveYN { get; set; }
    }
}

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
    
    public partial class tbl_CustomerFileBook
    {
        public long FileBookID { get; set; }
        public long fkCustomerID { get; set; }
        public int fkFileID { get; set; }
        public string MemberShipNo { get; set; }
        public string AreaType { get; set; }
        public Nullable<double> Area { get; set; }
        public Nullable<long> Price { get; set; }
        public Nullable<long> DownPayment { get; set; }
        public Nullable<long> ConfirmationAmount { get; set; }
        public Nullable<System.DateTime> ConfirmationFeeDate { get; set; }
        public string PayMethod { get; set; }
        public Nullable<long> RegistrationAmount { get; set; }
        public Nullable<long> DiscountAmount { get; set; }
        public string BookingStatus { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual tbl_CustomerRegM tbl_CustomerRegM { get; set; }
        public virtual tbl_Files tbl_Files { get; set; }
        public virtual tbl_UserLogin tbl_UserLogin { get; set; }
        public virtual tbl_UserLogin tbl_UserLogin1 { get; set; }
    }
}

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
    
    public partial class tbl_CustomerKin
    {
        public long CustomerKinId { get; set; }
        public long fkCustomerId { get; set; }
        public string KinName { get; set; }
        public string KinCNIC { get; set; }
        public string KinMobile { get; set; }
        public string KinRelation { get; set; }
        public string ActiveYN { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual tbl_CustomerRegM tbl_CustomerRegM { get; set; }
        public virtual tbl_UserLogin tbl_UserLogin { get; set; }
        public virtual tbl_UserLogin tbl_UserLogin1 { get; set; }
    }
}

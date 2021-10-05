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
    
    public partial class tbl_Projects
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Projects()
        {
            this.tbl_CustomerRegM = new HashSet<tbl_CustomerRegM>();
            this.tbl_Files = new HashSet<tbl_Files>();
            this.tbl_Projects1 = new HashSet<tbl_Projects>();
        }
    
        public string ProjectID { get; set; }
        public string ParentID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectAddress { get; set; }
        public string AreaType { get; set; }
        public Nullable<double> TotalArea { get; set; }
        public byte[] MapIMG { get; set; }
        public string ProjectType { get; set; }
        public string Main_Sub { get; set; }
        public string ActiveYN { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CustomerRegM> tbl_CustomerRegM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Files> tbl_Files { get; set; }
        public virtual tbl_UserLogin tbl_UserLogin { get; set; }
        public virtual tbl_UserLogin tbl_UserLogin1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Projects> tbl_Projects1 { get; set; }
        public virtual tbl_Projects tbl_Projects2 { get; set; }
    }
}
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
    
    public partial class tbl_UserRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_UserRole()
        {
            this.tbl_UserLogin = new HashSet<tbl_UserLogin>();
            this.tbl_userMenu = new HashSet<tbl_userMenu>();
        }
    
        public int RoleID { get; set; }
        public string NAME { get; set; }
        public string RMKS { get; set; }
        public string AST { get; set; }
        public string PST { get; set; }
        public string VST { get; set; }
        public string INST { get; set; }
        public string UPST { get; set; }
        public string DLST { get; set; }
        public string CHST { get; set; }
        public string ADST { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_UserLogin> tbl_UserLogin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_userMenu> tbl_userMenu { get; set; }
    }
}

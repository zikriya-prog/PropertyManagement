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
    
    public partial class tbl_Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Menu()
        {
            this.tbl_userMenu = new HashSet<tbl_userMenu>();
        }
    
        public string MenuId { get; set; }
        public string ParentCode { get; set; }
        public string NAME { get; set; }
        public string SOUR { get; set; }
        public string TYP { get; set; }
        public string RMKS { get; set; }
        public string AST { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_userMenu> tbl_userMenu { get; set; }
    }
}

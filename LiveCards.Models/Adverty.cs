//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiveCards.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Adverty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adverty()
        {
            this.DelearsAdvertys = new HashSet<DelearsAdverty>();
        }
    
        public int Id { get; set; }
        public string MessageHe { get; set; }
        public string MessageAr { get; set; }
        public Nullable<System.DateTime> AddedOn { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string Link { get; set; }
    
        public virtual Category Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DelearsAdverty> DelearsAdvertys { get; set; }
    }
}

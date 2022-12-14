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
    
    public partial class UploadedFile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UploadedFile()
        {
            this.Subscriptions = new HashSet<Subscription>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public Nullable<int> DelearId { get; set; }
        public Nullable<System.DateTime> InsertedDate { get; set; }
        public Nullable<int> NoRecord { get; set; }
        public Nullable<int> Type { get; set; }
    
        public virtual Agent Distributor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}

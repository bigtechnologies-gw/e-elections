//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace voteManager
{
    using System;
    using System.Collections.Generic;
    
    public partial class sector
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sector()
        {
            this.CEs = new HashSet<CE>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public int regionId { get; set; }
    
        public virtual Region region { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CE> CEs { get; set; }
    }
}

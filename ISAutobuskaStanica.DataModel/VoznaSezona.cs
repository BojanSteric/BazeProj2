//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISAutobuskaStanica.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class VoznaSezona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VoznaSezona()
        {
            this.RedVoznjes = new HashSet<RedVoznje>();
        }
    
        public int IdSezone { get; set; }
        public string NazivSezone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RedVoznje> RedVoznjes { get; set; }
    }
}

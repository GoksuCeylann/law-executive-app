//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HukukTakipYeniProje.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class SEHIRLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEHIRLER()
        {
            this.AVUKATLAR = new HashSet<AVUKATLAR>();
            this.ILCELER = new HashSet<ILCELER>();
            this.MUSTERILER = new HashSet<MUSTERILER>();
        }
    
        public System.Guid SEHIRID { get; set; }
        public string SEHIRAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AVUKATLAR> AVUKATLAR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILCELER> ILCELER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MUSTERILER> MUSTERILER { get; set; }
    }
}

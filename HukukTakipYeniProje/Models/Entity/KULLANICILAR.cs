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
    
    public partial class KULLANICILAR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KULLANICILAR()
        {
            this.AVUKATLAR = new HashSet<AVUKATLAR>();
        }
    
        public System.Guid KULLANICIID { get; set; }
        public string KULLANICIAD { get; set; }
        public string SIFRE { get; set; }
        public Nullable<System.Guid> KULLANICIROL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AVUKATLAR> AVUKATLAR { get; set; }
        public virtual KULLANICIROL KULLANICIROL1 { get; set; }
    }
}

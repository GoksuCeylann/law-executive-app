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
    
    public partial class MUDURLUKLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MUDURLUKLER()
        {
            this.ICRALAR = new HashSet<ICRALAR>();
        }
    
        public System.Guid MUDURLUKID { get; set; }
        public string MUDURLUKAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ICRALAR> ICRALAR { get; set; }
    }
}

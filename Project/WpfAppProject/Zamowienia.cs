//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zamowienia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zamowienia()
        {
            this.Zamowienia_Klient = new HashSet<Zamowienia_Klient>();
            this.Zamowienia_SklepStacjonarny = new HashSet<Zamowienia_SklepStacjonarny>();
        }
    
        public int id_zamowienia { get; set; }
        public int id_produktu { get; set; }
        public int sztuk { get; set; }
        public bool czy_odebrano { get; set; }
    
        public virtual Produkt Produkt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zamowienia_Klient> Zamowienia_Klient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zamowienia_SklepStacjonarny> Zamowienia_SklepStacjonarny { get; set; }
    }
}

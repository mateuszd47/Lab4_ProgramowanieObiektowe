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
    
    public partial class Klienci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klienci()
        {
            this.Zamowienia_Klient = new HashSet<Zamowienia_Klient>();
        }
    
        public int id_klient { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string telefon { get; set; }
        public string adres_email { get; set; }
        public string adres { get; set; }
        public string kodpocztowy { get; set; }
        public string miejscowośc { get; set; }
        public bool klient_staly { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zamowienia_Klient> Zamowienia_Klient { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyAirportMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Passanger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Passanger()
        {
            this.OrderFlight = new HashSet<OrderFlight>();
        }
    
        public System.Guid Passanger_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public int PassportID { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderFlight> OrderFlight { get; set; }
    }
}

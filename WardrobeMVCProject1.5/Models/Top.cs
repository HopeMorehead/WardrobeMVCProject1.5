//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WardrobeMVCProject1._5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Top
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Top()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int TopID { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int ItemNumber { get; set; }
        public bool Purchase { get; set; }
        public int ColorID { get; set; }
        public int SeasonID { get; set; }
        public int OccassionID { get; set; }
    
        public virtual Color Color { get; set; }
        public virtual Occasion Occasion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        public virtual Season Season { get; set; }
    }
}

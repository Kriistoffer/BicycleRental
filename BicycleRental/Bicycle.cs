//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BicycleRental
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bicycle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bicycle()
        {
            this.Electric_bicycle = new HashSet<Electric_bicycle>();
            this.Orders = new HashSet<Order>();
            this.Regular_bicycle = new HashSet<Regular_bicycle>();
            this.Unicycles = new HashSet<Unicycle>();
        }
    
        public string frame_number { get; set; }
        public string bicycle_type { get; set; }
        public string bicycle_category { get; set; }
        public string recommended_user { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public string frame_size { get; set; }
        public string wheel_size { get; set; }
        public Nullable<byte> gears { get; set; }
        public string brake_back { get; set; }
        public string brake_front { get; set; }
        public Nullable<int> price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Electric_bicycle> Electric_bicycle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Regular_bicycle> Regular_bicycle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unicycle> Unicycles { get; set; }
    }
}

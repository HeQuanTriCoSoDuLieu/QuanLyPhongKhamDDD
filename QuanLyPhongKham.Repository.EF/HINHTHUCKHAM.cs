//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyPhongKham.Repository.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class HINHTHUCKHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HINHTHUCKHAM()
        {
            this.PHIEUKHAMs = new HashSet<PHIEUKHAM>();
        }
    
        public int MAHINHTHUCKHAM { get; set; }
        public string TENHINHTHUCKHAM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUKHAM> PHIEUKHAMs { get; set; }
    }
}
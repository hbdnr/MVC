//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_projesi.Models.varlik
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_urun()
        {
            this.tbl_satislar = new HashSet<tbl_satislar>();
        }
    
        public int URUNID { get; set; }
        public string URUNAD { get; set; }
        public string MARKA { get; set; }
        public Nullable<short> KATEGORİ { get; set; }
        public Nullable<decimal> FİYAT { get; set; }
        public Nullable<int> STOK { get; set; }
    
        public virtual tbl_kategori tbl_kategori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_satislar> tbl_satislar { get; set; }
    }
}

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
    
    public partial class CHITIETDONTHUOC
    {
        public int MADONTHUOC { get; set; }
        public int MATHUOC { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public string HUONGDAN { get; set; }
    
        public virtual DONTHUOC DONTHUOC { get; set; }
        public virtual THUOC THUOC { get; set; }
    }
}
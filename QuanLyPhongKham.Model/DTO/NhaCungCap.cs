using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    class NhaCungCap
    {
        public int MaNhaCC { get; set; }
        public string TenNhaCC { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }
        public string Email { get; set; }
        public int MaQuocGia { get; set; }
    }
}

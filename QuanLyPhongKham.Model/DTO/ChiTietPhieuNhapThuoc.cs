using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    class ChiTietPhieuNhapThuoc
    {
        public int MaPhieuNhap { get; set; }
        public int MaThuoc { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgaySX { get; set; }
        public DateTime NgayHetHan { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBanLe { get; set; }
        public int MaHSX { get; set; }
        public int MaNhaCC { get; set; }
    }
}

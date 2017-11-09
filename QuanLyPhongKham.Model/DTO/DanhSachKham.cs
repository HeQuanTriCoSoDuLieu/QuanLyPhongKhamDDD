using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    class DanhSachKham
    {
        public int MaDSK { get; set; }
        public int MaPhieuKham { get; set; }
        public DateTime NgayKham { get; set; }
        public bool HoanThanh { get; set; }
    }
}

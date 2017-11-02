using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    class ChiTietPhieuNhapThuoc
    {
        public int MAPHIEUNHAP { get; set; }
        public int MATHUOC { get; set; }
        public int SOLUONG { get; set; }
        public DateTime NGAYSX { get; set; }
        public DateTime NGAYHETHAN { get; set; }
        public decimal GIANHAP { get; set; }
        public decimal GIABANLE { get; set; }
        public int MAHSX { get; set; }
        public int MANHACC { get; set; }
    }
}

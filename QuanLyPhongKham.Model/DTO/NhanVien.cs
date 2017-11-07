using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    public class NhanVien
    {
        public int MaNV {get;set;}

        public string HoTeN { get; set; }

        public bool GioiTinh { get; set; }

        public string SoDT { get; set; }

        public string Email { get; set; }

        public int MaKhoa { get; set; }

        public int MaChucDanh { get; set; }

        public int MaChucVu { get; set; }
    }
}

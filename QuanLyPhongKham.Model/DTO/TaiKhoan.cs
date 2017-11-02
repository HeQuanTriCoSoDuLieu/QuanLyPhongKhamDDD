using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    public class TaiKhoan
    {
        public int MATK { get; set; }

        public string TENDANGNHAP { get; set; }

        public string MATKHAU { get; set; }

        public string TENHIENTHI { get; set; }

        public int? MAPHANQUYEN { get; set; }

        public bool? TRANGTHAI { get; set; }

    }
}

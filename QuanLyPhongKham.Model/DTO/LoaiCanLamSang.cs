using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    public class LoaiCanLamSang
    {
        public int MaLoaiCLS { get; set; }
        public string TenLoai { get; set; }

        public LoaiCanLamSang()
        {
        }
        public LoaiCanLamSang(int MaLoaiCLS, string TenLoai)
        {
            this.MaLoaiCLS = MaLoaiCLS;
            this.TenLoai = TenLoai;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    public class PhieuKham
    {
        public int MaPhieuKham { get; set; }
        public int MaBN { get; set; }
        public int MaNV { get; set; }
        public string ChuanDoan { get; set; }
        public int MaHinhThucKham { get; set; }
        public DateTime NgayKham { get; set; }
        public string KetLuan { get; set; }
        public int HoanThanh { get; set; }
        public int DaThanhToan { get; set; }

        public PhieuKham()
        {
        }
        public PhieuKham(int MaPhieuKham, int MaBN, int MaNV, string ChuanDoan, int MaHinhThucKham, string NgayKham, string KetLuan, int HoanThanh, int DaThanhToan)
        {
            this.MaPhieuKham = MaPhieuKham;
            this.MaBN = MaBN;
            this.MaNV = MaNV;
            this.ChuanDoan = ChuanDoan;
            this.MaHinhThucKham = MaHinhThucKham;
            this.NgayKham = NgayKham;
            this.KetLuan = KetLuan;
            this.HoanThanh = HoanThanh;
            this.DaThanhToan = DaThanhToan;
        }
    }
}
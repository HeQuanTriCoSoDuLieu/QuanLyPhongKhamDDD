using System;
using System.Collections.Generic;
using System.Data;
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
        public string NhipTim { get; set; }
        public string NhietDo { get; set; }
        public string HuyetAp { get; set; }
        public int CanNang { get; set; }
        public int ChieuCao { get; set; }
        public int MaICD { get; set; }
        public string KetLuan { get; set; }
        public int HoanThanh { get; set; }
        public int DaThanhToan { get; set; }

        public PhieuKham() { }


        public PhieuKham(int MaPhieuKham, int MaBN, int MaNV, string ChuanDoan, int MaHinhThucKham, DateTime NgayKham, string NhipTim, string NhietDo, string HuyetAp, int CanNang, int ChieuCao, int MaICD, string KetLuan, int HoanThanh, int DaThanhToan)
        {
            this.MaPhieuKham = MaPhieuKham;
            this.MaBN = MaBN;
            this.MaNV = MaNV;
            this.ChuanDoan = ChuanDoan;
            this.MaHinhThucKham = MaHinhThucKham;
            this.NgayKham = NgayKham;
            this.NhipTim = NhipTim;
            this.NhietDo = NhietDo;
            this.HuyetAp = HuyetAp;
            this.CanNang = CanNang;
            this.ChieuCao = ChieuCao;
            this.MaICD = MaICD;
            this.KetLuan = KetLuan;
            this.HoanThanh = HoanThanh;
            this.DaThanhToan = DaThanhToan;
        }

        public PhieuKham(DataRow row)
        {
            this.MaPhieuKham = (int)row["MAPHIEUKHAM"];
            this.MaBN = (int)row["MABN"];
            this.MaNV = (int)row["MANV"];
            this.ChuanDoan = row["CHUANDOAN"].ToString();
            this.MaHinhThucKham = (int)row["MAHINHTHUCKHAM"];
            this.NgayKham = (DateTime)row["NGAYKHAM"];
            this.NhipTim = row["NHIPTIM"].ToString();
            this.NhietDo = row["NHIETDO"].ToString();
            this.HuyetAp = row["HUYETAP"].ToString();
            this.CanNang = (int)row["CANNANG"];
            this.ChieuCao = (int)row["CHIEUCAO"];
            this.MaICD = (int)row["MAICD"];
            this.KetLuan = row["KETLUAN"].ToString();
            this.HoanThanh = (int)row["HOANTHANH"];
            this.DaThanhToan = (int)row["DATHANHTOAN"];

        }




    }
}
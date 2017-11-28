using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    public class NhanVien
    {
        public NhanVien() { }

        public NhanVien(int manv,string hoten,bool gioitinh,string sodt,string email, int makhoa, int machucdanh, int machucvu)
        {
            MaNV = manv;
            HoTen = hoten;
            GioiTinh = gioitinh;
            SoDT = sodt;
            Email = email;
            MaKhoa = makhoa;
            MaChucDanh = machucdanh;
            MaChucVu = machucvu;
        }
        public NhanVien(DataRow row)
        {
            MaNV = (int)row["MANV"];
            HoTen = row["HOTEN"].ToString();
            GioiTinh = (bool)row["GIOITINH"];
            SoDT = row["SODT"].ToString();
            Email = row["EMAIL"].ToString();
            MaKhoa = (int)row["MAKHOA"];
            MaChucDanh = (int)row["MACHUCDANH"];
            MaChucVu = (int)row["MACHUCVU"];
        }
        public int MaNV {get;set;}

        public string HoTen { get; set; }

        public bool GioiTinh { get; set; }

        public string SoDT { get; set; }

        public string Email { get; set; }

        public int MaKhoa { get; set; }

        public int MaChucDanh { get; set; }

        public int MaChucVu { get; set; }
    }
}

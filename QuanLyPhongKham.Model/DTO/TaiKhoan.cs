using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLyPhongKham.Model.DTO
{
    public class TaiKhoan
    {

        
        public TaiKhoan() { }

        public TaiKhoan(int maTK, string tenDangNhap, string matKhau, string tenHienThi, int? maPhanQuyen, bool? trangThai)
        {
            MaTK = maTK;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            TenHienThi = tenHienThi;
            MaPhanQuyen = maPhanQuyen;
            TrangThai = trangThai;
        }

        [Key]
        public int MaTK { get; set; }

        [Required]
        public string TenDangNhap { get; set; }

        [Required]
        public string MatKhau { get; set; }

        public string TenHienThi { get; set; }

        public int? MaPhanQuyen { get; set; }

        public bool? TrangThai { get; set; }

    }
}

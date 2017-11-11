using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    public class BenhNhan
    {
        public int MaBN { get; set; }
        public string HoTen { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DanToc { get; set; }
        public string SoCMND { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }
        public BenhNhan()
        {

        }
        public BenhNhan(int MaBN, string HoTen, int GioiTinh, DateTime NgaySinh, string DanToc, string SoCMND, string DiaChi, string SoDT)
        {
            this.MaBN = MaBN;
            this.HoTen = HoTen;
            this.GioiTinh = GioiTinh;
            this.NgaySinh = NgaySinh;
            this.DanToc = DanToc;
            this.SoCMND = SoCMND;
            this.DiaChi = DiaChi;
            this.SoDT = SoDT;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    public class BenhNhan
    {
        public int MABN { get; set; }
        public string HOTEN { get; set; }
        public string GIOITINH { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string DANTOC { get; set; }
        public string SOCMND { get; set; }
        public string DIACHI { get; set; }
        public string SODT { get; set; }
        public int MaBN { get; set; }
        public string HoTen { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DanToc { get; set; }
        public string SoCMND { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }
        public string TienSu { get; set; }
        public BenhNhan()
        {

        public BenhNhan(int mABN, string hOTEN, string gIOITINH, DateTime nGAYSINH, string dANTOC, string sOCMND, string dIACHI, string sODT)
        {
            MABN = mABN;
            HOTEN = hOTEN;
            GIOITINH = gIOITINH;
            NGAYSINH = nGAYSINH;
            DANTOC = dANTOC;
            SOCMND = sOCMND;
            DIACHI = dIACHI;
            SODT = sODT;
        }

        public BenhNhan() { }

        public BenhNhan(DataRow row)
        {
            MABN = (int)row["MABN"];
            HOTEN = row["HOTEN"].ToString();
            GIOITINH = (bool)row["GIOITINH"] == true ? "Nam": "Nữ";
            NGAYSINH = DateTime.Parse(row["NGAYSINH"].ToString());
            DANTOC = row["DANTOC"].ToString();
            SOCMND = row["SOCMND"].ToString();
            DIACHI = row["DIACHI"].ToString();
            SODT = row["SODT"].ToString();
        public BenhNhan(int MaBN, string HoTen, int GioiTinh, DateTime NgaySinh, string DanToc, string SoCMND, string DiaChi, string SoDT,string TienSu)
        {
            this.MaBN = MaBN;
            this.HoTen = HoTen;
            this.GioiTinh = GioiTinh;
            this.NgaySinh = NgaySinh;
            this.DanToc = DanToc;
            this.SoCMND = SoCMND;
            this.DiaChi = DiaChi;
            this.SoDT = SoDT;
            this.TienSu = TienSu;
        }
        public BenhNhan(DataRow row)
        {
            this.MaBN =(int) row["MABN"];
            this.HoTen = row["HOTEN"].ToString();
            this.GioiTinh =(int) row["GIOITINH"];
            this.NgaySinh = (DateTime) row["NGAYSINH"];
            this.SoCMND = row["SOCMND"].ToString();
            this.DiaChi = row["DIACHI"].ToString();
            this.SoDT = row["SODT"].ToString();
            this.TienSu = row["TIENSU"].ToString();
        }

    }
}

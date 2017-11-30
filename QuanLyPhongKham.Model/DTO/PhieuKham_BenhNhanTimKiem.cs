using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    public class PhieuKham_BenhNhanTimKiem 
    {

        public int MaPhieuKham { get; set; }
        public string HOTEN { get; set; }
        public DateTime NgayKham { get; set; }
        public bool HoanThanh { get; set; }
        public PhieuKham_BenhNhanTimKiem() { }

        public PhieuKham_BenhNhanTimKiem(int maphieukham,string ten,DateTime ngaykham, bool hoanthanh)
        {
            MaPhieuKham = maphieukham;           
            HOTEN = ten;
            NgayKham = ngaykham;
            HoanThanh = hoanthanh;
        }

        public PhieuKham_BenhNhanTimKiem(DataRow row)
        {
            MaPhieuKham = (int)row["MAPHIEUKHAM"];           
            HOTEN = row["HOTEN"].ToString();
            NgayKham =(DateTime) row["NGAYKHAM"];
            HoanThanh = (bool)row["HOANTHANH"];//  ? "True" : "False";
        }
    }
}

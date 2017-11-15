using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    public class VatTuYTe
    {
        public VatTuYTe() { }
        public VatTuYTe(int mAVATTUYTE, string tENVTYT, int mADVT, int sOLUONGTON)
        {
            MaVTYT = mAVATTUYTE;
            TenVTYT = tENVTYT;
            MaDVT = mADVT;
            SoLuongTon = sOLUONGTON;
        }
        public VatTuYTe(DataRow row)
        {
            MaVTYT = (int)row["MaVTYT"];
            TenVTYT = row["TenVTY"].ToString();
            MaDVT = (int)row["MaDVT"];
            SoLuongTon = (int)row["SoLuongTon"]; 
        }

        public int MaVTYT { get; set; }
        public string TenVTYT { get; set; }
        public int MaDVT { get; set; }
        public int SoLuongTon { get; set; }
    }
}

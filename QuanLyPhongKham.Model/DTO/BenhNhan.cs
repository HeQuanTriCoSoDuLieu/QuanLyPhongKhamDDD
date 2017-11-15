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
        }

    }
}

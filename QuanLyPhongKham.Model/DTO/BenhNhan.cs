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
        public string TIENSU{ get; set; }

        
        public BenhNhan() { }

        public BenhNhan(DataRow row)
        {
            this.MABN = (int) row["MABN"];
            this.HOTEN = row["HOTEN"].ToString();
            GIOITINH = (bool) row["GIOITINH"]  ? "Nam" : "Nữ";
            this.NGAYSINH = (DateTime) row["NGAYSINH"];
            this.SOCMND = row["SOCMND"].ToString();
            this.DIACHI = row["DIACHI"].ToString();
            this.SODT = row["SODT"].ToString();
            TIENSU = row["TIENSU"].ToString();
        }

    }
}

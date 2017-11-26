using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    public class ChiTietDonThuoc_Thuoc
    {


        public ChiTietDonThuoc_Thuoc(DataRow row)
        {
            this.MADONTHUOC = (int)row["MADONTHUOC"];
            this.TENTHUOC = row["TENTHUOC"].ToString();
            this.SOLUONG = (int)row["SOLUONG"];
            this.HUONGDAN = row["HUONGDAN"].ToString();
        }

        public int STT { get; set; }
        public int MADONTHUOC { get; set; }
        public string  TENTHUOC { get; set; }
        public int SOLUONG { get; set; }
        public string HUONGDAN { get; set; }
    }
}

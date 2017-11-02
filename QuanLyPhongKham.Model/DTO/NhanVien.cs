using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.DTO
{
    public class NhanVien
    {
        public int MaNV {get;set;}
        public string HOTEN { get; set; }
        public bool GIOITINH { get; set; }
        public string SODT { get; set; }
        public string EMAIL { get; set; }
        public int MAKHOA { get; set; }
        public int MACHUCDANH { get; set; }
        public int MACHUCVU { get; set; }
    }
}

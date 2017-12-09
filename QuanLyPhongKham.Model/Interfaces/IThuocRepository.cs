using QuanLyPhongKham.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.Interfaces
{
    public interface IThuocRepository
    {
        List<Thuoc_Loaithuoc> Danhsachthuoc();
        List<Thuoc_Loaithuoc> Danhsachthuoc(String Thongtin, String Dulieu);

    }
}

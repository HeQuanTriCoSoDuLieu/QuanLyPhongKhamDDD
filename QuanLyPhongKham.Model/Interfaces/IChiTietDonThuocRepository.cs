using QuanLyPhongKham.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.Interfaces
{
    public interface IChiTietDonThuocRepository
    {
        int TaoChiTietDonThuoc(Chitietdonthuoc ctdt, int maphieu);
        List<Chitietdonthuoc_Thuoc> DanhSachChiTietDonThuoc(int maphieu);
    }
}

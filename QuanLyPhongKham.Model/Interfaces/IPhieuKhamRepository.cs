using QuanLyPhongKham.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.Interfaces
{
    public interface IPhieuKhamRepository
    {
        List<PhieuKham_BenhNhanTimKiem> KetQuaTimPhieuKham(string ten);
        List<PhieuKham_BenhNhanChoKham> DanhSachChoKham();
        List<PhieuKham_BenhNhanTimKiem> DanhSachPhieuKham();
        PhieuKham_BenhNhanLamSang ThongTinPhieuKham(int maphieu);
        int LuuPhieuKham(PhieuKham_BenhNhanLamSang pkbn);
        List<PhieuKham_LichSuKham> LichSuKham(int mabn);
    }
}

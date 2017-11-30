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
        List<PhieuKhamGUI> DanhSachPhieuKhamGUI(DateTime dateTime);
        bool InsertPhieuKham(PhieuKham phieuKham);
        void HuyKham(int maPhieuKham,int nhanvien);
        void CapNhatPhieuKham(PhieuKham phieuKham);
    }
}

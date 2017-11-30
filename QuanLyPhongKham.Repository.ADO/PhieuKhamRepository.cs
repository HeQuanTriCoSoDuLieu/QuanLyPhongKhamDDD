using QuanLyPhongKham.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongKham.Model.DTO;
using System.Data;

namespace QuanLyPhongKham.Repository.ADO
{
    public class PhieuKhamRepository : IPhieuKhamRepository
    {
        /// <summary>
        /// hàm load danh sách phiếu khám cho fTiepNhanBenhNhan
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public List<PhieuKhamGUI> DanhSachPhieuKhamGUI(DateTime dateTime)
        {
            List<PhieuKhamGUI> list = new List<PhieuKhamGUI>();

            DataTable table = DataProvider.Instane.ExecuteReader("EXEC  dbo.SP_DanhSachKham_fKhamBenNhan @NgayKham ", new object[] { dateTime });

            foreach (DataRow row in table.Rows)
            {
                PhieuKhamGUI phieuKhamGUI = new PhieuKhamGUI(row);
                list.Add(phieuKhamGUI);
            }

            return list;
        }

        public bool InsertPhieuKham(PhieuKham phieuKham)
        {
            int row = DataProvider.Instane.ExecuteNonQuery("EXEC dbo.InsertPhieuKham @MABN , @MANV , @NVTIEPNHAN , @CHUANDOAN , @MAHINHTHUCKHAM ", new object[] { phieuKham.MaBN, phieuKham.MaNV, phieuKham.NVTiepNhan, phieuKham.ChuanDoan, phieuKham.MaHinhThucKham });

            return row > 0;
        }

        public void HuyKham(int maPhieuKham, int nhanvien)
        {
            DataProvider.Instane.ExecuteNonQuery("EXEC dbo.HuyKham @MAPHIEUKHAM , @nhanvien", new object[] { maPhieuKham , nhanvien});

        }

        public void CapNhatPhieuKham(PhieuKham phieuKham)
        {

            DataProvider.Instane.ExecuteNonQuery("EXEC dbo.SP_UpdatePhieuKham @MAPHIEUKHAM , @MANV , @NVTIEPNHAN , @CHUANDOAN , @MAHINHTHUCKHAM", new object[] { phieuKham.MaPhieuKham, phieuKham.MaNV, phieuKham.NVTiepNhan, phieuKham.ChuanDoan, phieuKham.MaHinhThucKham });
        }
    }
}

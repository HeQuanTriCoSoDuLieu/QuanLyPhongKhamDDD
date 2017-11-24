using QuanLyPhongKham.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongKham.Model.DTO;

namespace QuanLyPhongKham.Repository.ADO
{
    public class ChiTietDonThuocRepository : IChiTietDonThuocRepository
    {
        public int TaoChiTietDonThuoc(Chitietdonthuoc ctdt)
        {
            int row = DataProvider.Instane.ExecuteNonQuery("EXECUTE dbo.SP_", new object[] { });
            return row;
        }

        public int TaoChiTietDonThuoc(List<Chitietdonthuoc> ctdt)
        {
            int row = DataProvider.Instane.ExecuteNonQuery("EXECUTE dbo.SP_", new object[] { });
            return row;
        }
    }
}

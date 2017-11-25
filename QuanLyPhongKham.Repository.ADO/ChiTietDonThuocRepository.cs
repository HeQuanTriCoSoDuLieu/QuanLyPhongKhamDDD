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
    public class ChiTietDonThuocRepository : IChiTietDonThuocRepository
    {
        public List<Chitietdonthuoc_Thuoc> DanhSachChiTietDonThuoc(int maphieu)
        {
            List<Chitietdonthuoc_Thuoc> list = new List<Chitietdonthuoc_Thuoc>();

            DataTable table = DataProvider.Instane.ExecuteReader("EXECUTE dbo.SP_DanhSachChiTietDonThuoc @MAPHIEU",new object[] { maphieu });



            foreach (DataRow row in table.Rows)
            {
                list.Add(new Chitietdonthuoc_Thuoc(row));
            }
            return list;
        }

        public int TaoChiTietDonThuoc(Chitietdonthuoc ctdt,int maphieu)
        {
            int row = DataProvider.Instane.ExecuteNonQuery("EXECUTE dbo.SP_Insert_ChiTietDonThuoc @MADONTHUOC @MATHUOC @SOLUONG @HUONGDAN", new object[] { ctdt.MADONTHUOC, ctdt.MATHUOC, ctdt.SOLUONG,ctdt.HUONGDAN });
            return row;
        }
    }
}

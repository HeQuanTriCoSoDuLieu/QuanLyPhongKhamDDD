using QuanLyPhongKham.Model.DTO;
using QuanLyPhongKham.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Repository.ADO
{
    public class ThuocRepository : IThuocRepository
    {

        public List<Thuoc_Loaithuoc> Danhsachthuoc()
        {
            List<Thuoc_Loaithuoc> list = new List<Thuoc_Loaithuoc>();

            DataTable table = DataProvider.Instane.ExecuteReader("EXECUTE dbo.SP_Thuoc_selectall");

            foreach (DataRow row in table.Rows)
            {
                list.Add(new Thuoc_Loaithuoc(row));
            }
            return list;
        }
    

        public List<Thuoc_Loaithuoc> Danhsachthuoc(string Thongtin, string Dulieu)
        {
            List<Thuoc_Loaithuoc> list = new List<Thuoc_Loaithuoc>();
            DataTable table = DataProvider.Instane.ExecuteReader("EXECUTE dbo.SP_Thuoc_search @Thongtin , @DuLieu", new object[] { Thongtin,Dulieu });
            foreach(DataRow row in table.Rows)
            {
                list.Add(new Thuoc_Loaithuoc(row));
            }
            return list;
        }
}
}

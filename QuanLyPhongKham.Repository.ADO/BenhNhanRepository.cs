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
    public class BenhNhanRepository : IBenhNhanRepository
    {
        public List<BenhNhan> DanhSachBenhNhan()
        {
            List<BenhNhan> list = new List<BenhNhan>();

            DataTable table = DataProvider.Instane.ExecuteReader("EXECUTE dbo.SP_DanhSachBenhNhan");

            

            foreach (DataRow row in table.Rows)
            {
                list.Add(new BenhNhan(row));
            }
            return list;
        }

        public List<BenhNhan> TimKiemBenhNhan(string col, string info)
        {
            List<BenhNhan> list = new List<BenhNhan>();
            DataTable table = DataProvider.Instane.ExecuteReader("EXEC dbo.SP_TimKiemBenhNhan @ThongTin , @TruongDuLieu ", new object[] { col, info });
            
            foreach (DataRow row in table.Rows)
            {
                list.Add(new BenhNhan(row));
            }
            return list;
        }
    }
}

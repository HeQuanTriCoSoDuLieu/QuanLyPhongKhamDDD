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
    public class NhanVienRepository : INhanVienRepository
    {
        public List<NhanVien> DanhSachNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            DataTable table =  DataProvider.Instane.ExecuteReader(" EXEC dbo.SP_DanhSachNhanVien");
            foreach (DataRow row in table.Rows)
            {
                NhanVien nhanVien = new NhanVien(row);
                list.Add(nhanVien);
            }
            return list;
        }
    }
}

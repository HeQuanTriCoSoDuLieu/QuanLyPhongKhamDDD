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
    public class CanLamSanRepository : ICanLamSanRepository
    {
        public List<CanLamSan> DanhSachLoaiCLS(int macls)
        {
            List<CanLamSan> list = new List<CanLamSan>();
            DataTable table = DataProvider.Instane.ExecuteReader("EXEC [dbo].[SP_Getbyid_CLS] @macls ", new object[] { macls });
            foreach (DataRow row in table.Rows)
            {
                CanLamSan cls = new CanLamSan(row);
                list.Add(cls);
            }
            return list;
        }
    }
}

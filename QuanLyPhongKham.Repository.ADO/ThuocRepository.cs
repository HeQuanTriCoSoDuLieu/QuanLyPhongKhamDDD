using QuanLyPhongKham.Model.DTO;
using QuanLyPhongKham.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace QuanLyPhongKham.Repository.ADO
{
    public class ThuocRepository : IThuocRepository
    {
        public List<TimKiemThuoc> TimKiemThuoc(string timkiemthuoc, int timtheo, int loaithuoc)
        {
            List <TimKiemThuoc> list = new List<TimKiemThuoc>();
            DataTable table =  DataProvider.Instane.ExecuteReader("EXEC dbo.SP_timkiemthuoc @timkiemthuoc , @timtheo , @loaithuoc ", new object[] { timkiemthuoc , timtheo , loaithuoc });

            foreach (DataRow row in table.Rows)
            {
                list.Add(new TimKiemThuoc(row));
            }
            return list;
        }
    }
}

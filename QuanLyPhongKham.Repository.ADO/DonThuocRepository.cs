using QuanLyPhongKham.Model.DTO;
using QuanLyPhongKham.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Repository.ADO
{
    public class DonThuocRepository : IDonThuocRepository
    {
        public int ThemDonThuoc(Donthuoc donthuoc)
        {
            int row = DataProvider.Instane.ExecuteNonQuery("EXECUTE dbo.SP_", new object[] { } );
            return row;
        }
    }
}

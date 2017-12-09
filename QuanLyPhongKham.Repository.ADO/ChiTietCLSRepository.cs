using QuanLyPhongKham.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Repository.ADO
{
    public class ChiTietCLSRepository: IChiTietCLSRepository
    {

        public int InsertChiTietCLS(string getmaphieu, string getmacls)
        {
            int result = DataProvider.Instane.ExecuteNonQuery("EXEC [dbo].[SP_INSERT_DICHVUCLS] @maphieu , @macls ", new object[] { getmaphieu, getmacls });

            return result;
        }
    }
}

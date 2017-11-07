using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Services
{
    public class ServiceFactory
    {
        public static LibraryService GetLibraryService(string persistanceStrategry)
        {
            LibraryService libraryService = null;
            if (persistanceStrategry=="ADO")
            {
                libraryService = new LibraryService(new QuanLyPhongKham.Repository.ADO.TaiKhoanRepository());
            }else
            {
                libraryService = new LibraryService(new QuanLyPhongKham.Repository.EF.TaiKhoanRepository());
            }
            return libraryService;
        }
    }
}

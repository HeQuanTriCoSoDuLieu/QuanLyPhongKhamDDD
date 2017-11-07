using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongKham.Model;
using QuanLyPhongKham.Model.Interfaces;
namespace QuanLyPhongKham.Repository.EF
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        public bool Login(string userName, string passWord)
        {
            return true;
        }
    }
}

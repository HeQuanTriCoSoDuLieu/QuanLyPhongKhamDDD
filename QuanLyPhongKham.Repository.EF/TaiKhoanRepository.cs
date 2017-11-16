using QuanLyPhongKham.Model.Interfaces;
using QuanLyPhongKham.Repository.EF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Repository.EF
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        public int Login(string userName, string passWord)
        {
            int result = QuanLyPhongKhamDbContext.Instance.TAIKHOANs.Count(); //p=>p.TenDangNhap==userName && p.MatKhau == passWord
            return result;
        }
    }
}


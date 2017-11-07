using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Model.Interfaces
{
    public interface ITaiKhoanRepository
    {
        bool Login(string userName, string passWord);
    }
}

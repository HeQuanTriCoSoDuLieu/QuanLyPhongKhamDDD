using QuanLyPhongKham.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Services
{
    public class LibraryService
    {

        private ITaiKhoanRepository taiKhoanRepository;

        internal LibraryService(ITaiKhoanRepository taiKhoanRepository)
        {
            this.taiKhoanRepository = taiKhoanRepository;
        }

        public bool Login(string userName, string passWord)
        {
            return taiKhoanRepository.Login(userName,passWord);
        }

    }
}

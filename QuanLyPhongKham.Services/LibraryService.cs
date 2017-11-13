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


        #region Repositories

        private ITaiKhoanRepository taiKhoanRepository;


        #endregion



        #region constructor

        internal LibraryService(ITaiKhoanRepository taiKhoanRepository)
        {
            this.taiKhoanRepository = taiKhoanRepository;
        }

        #endregion



        #region Services cho tài khoản
        public bool Login(string userName, string passWord)
        {
            return taiKhoanRepository.Login(userName, passWord);
        }

        #endregion




    }
}

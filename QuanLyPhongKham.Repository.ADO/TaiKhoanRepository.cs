﻿using QuanLyPhongKham.Model;
using QuanLyPhongKham.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.Repository.ADO
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        public int Login(string userName, string passWord)
        {

            int result = DataProvider.Instane.ExecuteScalar("EXEC dbo.SP_Login @TenDangNhap , @MatKhau ", new object[] { userName, passWord });

            return result ;
        }
    }
}

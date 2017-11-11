using QuanLyPhongKham.Infrastructure;
using QuanLyPhongKham.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKham.Winform
{
    public partial class fLogin : MetroFramework.Forms.MetroForm
    {

        private LibraryService libraryService;
        public fLogin()
        {
            InitializeComponent();
            libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text.Trim();
            string passWord = txbPassWord.Text.Trim();
            if (libraryService.Login(userName,passWord))
            {
                Hide();
                fTiepNhanBenhNhan f = new fTiepNhanBenhNhan();
                f.ShowDialog();
            }else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo");
            }
        }
    }
}

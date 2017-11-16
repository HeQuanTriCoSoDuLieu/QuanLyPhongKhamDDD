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
    public partial class fTiepNhanBenhNhan : Form
    {
        private LibraryService libraryService;
        public fTiepNhanBenhNhan()
        {
            InitializeComponent();
            libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);
            
        }


        private void fTiepNhanBenhNhan_Load(object sender, EventArgs e)
        {

            //load danh sách bệnh nhân cho datagridview
            LoadDanhSachBenhNhan();

            //set thuộc tính đầu tiên cho combobox tim kiem 
            cbxTimKiem.SelectedIndex = 1;

        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string cot = "";
            switch (cbxTimKiem.SelectedIndex)
            {
                case 0:
                    cot = "MABN";
                    break;
                case 1:
                    cot = "HOTEN";
                    break;
                case 2:
                    cot = "SODT";
                    break;
                case 3:
                    cot = "SOCMND";
                    break;
            }
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (libraryService.TimKiemBenhNhan(cot, txtTimKiem.Text).Count==0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvDanhSachBenhNhan.DataSource = libraryService.TimKiemBenhNhan(cot, txtTimKiem.Text);
                   
                }
               
            }
            
        }






        #region Method


        /// <summary>
        /// load danh sách bệnh nhân cho datagridview bệnh nhân
        /// </summary>
        private void LoadDanhSachBenhNhan()
        {
            dgvDanhSachBenhNhan.DataSource = libraryService.DanhSachBenhNhan();
            dgvDanhSachBenhNhan.Columns[0].HeaderText = "Mã bệnh nhân";
            dgvDanhSachBenhNhan.Columns[1].HeaderText = "Họ tên";
            dgvDanhSachBenhNhan.Columns[2].HeaderText = "Giới tính";
            dgvDanhSachBenhNhan.Columns[3].HeaderText = "Ngày sinh";
            dgvDanhSachBenhNhan.Columns[4].HeaderText = "Dân tộc";
            dgvDanhSachBenhNhan.Columns[5].HeaderText = "Số CMND";
            dgvDanhSachBenhNhan.Columns[6].HeaderText = "Địa chỉ";
            dgvDanhSachBenhNhan.Columns[7].HeaderText = "Số điện thoại";
        }
        #endregion



        private void dgvDanhSachBenhNhan_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDanhSachBenhNhan.SelectedRows)
            {
                txtMaBenhNhan.Text =  row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                txtCMND.Text = row.Cells[5].Value.ToString();
                if (row.Cells[2].Value.ToString().Equals("Nam"))
                {
                    rdoNam.Checked = true;
                }else
                {
                    rdoNu.Checked = true;
                }

                dtpNgaySinh.Value = DateTime.Parse(row.Cells[3].Value.ToString());

                txtDiaChi.Text = row.Cells[6].Value.ToString();
                txtSDT.Text = row.Cells[7].Value.ToString();

            }
        }
    }
}

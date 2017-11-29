using QuanLyPhongKham.Infrastructure;
using QuanLyPhongKham.Model.DTO;
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
    public partial class fLichSuKhamBacSi : Form
    {
        private int MaBn;
        private LibraryService libraryService;
        public fLichSuKhamBacSi(int mabn)
        {
            InitializeComponent();
            this.MaBn = mabn;
            libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string cot = "";
            switch (cbxtimkiem.SelectedIndex)
            {
                case 0:
                    cot = "MABN";
                    break;
                case 1:
                    cot = "HOTEN";
                    break;
                case 2:
                    cot = "MAPHIEUKHAM";
                    break;
                case 3:
                    cot = "NGAYKHAM";
                    break;
            }
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (libraryService.LichSuKhamNhanVien(cot, txttimkiem.Text,MaBn).Count==0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   
                    List<LichSuKham_NhanVien> listlskham = new List<LichSuKham_NhanVien>();                
                    listlskham = libraryService.LichSuKhamNhanVien(cot, txttimkiem.Text, MaBn);
                    for (int i = 1; i < listlskham.Count; i++)
                    {
                        listlskham[i].STT = i;
                    }
                    dgvdsphieukham.DataSource = listlskham;
                    dgvdsphieukham.Columns[0].HeaderText = "STT"; dgvdsphieukham.Columns[0].Width = 40;
                    dgvdsphieukham.Columns[1].HeaderText = "Mã bệnh nhân"; dgvdsphieukham.Columns[1].Width = 110;
                    dgvdsphieukham.Columns[2].HeaderText = "Mã phiếu"; dgvdsphieukham.Columns[2].Width = 80;
                    dgvdsphieukham.Columns[3].HeaderText = "Họ tên bệnh nhân"; dgvdsphieukham.Columns[3].Width = 120;
                    dgvdsphieukham.Columns[4].HeaderText = "Ngày khám"; dgvdsphieukham.Columns[4].Width = 90;
                    dgvdsphieukham.Columns[5].HeaderText = "Đã thanh toán"; dgvdsphieukham.Columns[5].Width = 85;
                    dgvdsphieukham.RowHeadersVisible = false;

                }

            }
        }
        public void Load_fLichSuKhamBacSi()
        {
            dgvdsphieukham.DataSource = libraryService.LichSuKhamNhanVien(MaBn);
            List<LichSuKham_NhanVien> listlskham = new List<LichSuKham_NhanVien>();

            listlskham = libraryService.LichSuKhamNhanVien(MaBn);
            for (int i = 1; i < listlskham.Count; i++)
            {
                listlskham[i].STT = i;
            }
            dgvdsphieukham.DataSource = listlskham;
            dgvdsphieukham.Columns[0].HeaderText = "STT"; dgvdsphieukham.Columns[0].Width = 40;
            dgvdsphieukham.Columns[1].HeaderText = "Mã bệnh nhân"; dgvdsphieukham.Columns[1].Width = 110;
            dgvdsphieukham.Columns[2].HeaderText = "Mã phiếu"; dgvdsphieukham.Columns[2].Width = 80;
            dgvdsphieukham.Columns[3].HeaderText = "Họ tên bệnh nhân"; dgvdsphieukham.Columns[3].Width = 120;
            dgvdsphieukham.Columns[4].HeaderText = "Ngày khám"; dgvdsphieukham.Columns[4].Width = 90;
            dgvdsphieukham.Columns[5].HeaderText = "Đã thanh toán"; dgvdsphieukham.Columns[5].Width = 85;
            dgvdsphieukham.RowHeadersVisible = false;
        }
    }
}

﻿using QuanLyPhongKham.Infrastructure;
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
    public partial class fKhamBenhNhan : Form
    {
        private LibraryService libraryService;

        public fKhamBenhNhan()
        {
            InitializeComponent();

            libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);


            panellamsang.Parent = panelchinh;
            panelsieuam.Parent = panelchinh;
            panelxquang.Parent = panelchinh;
            panelxetnghiem.Parent = panelchinh;
            panelnoisoi.Parent = panelchinh;
            paneldonthuoc.Parent = panelchinh;
            panellichsukham.Parent = panelchinh;
        }


        private void treeviewdichvukham(object sender, TreeViewEventArgs e)
        {
            switch (treeviewdvkham.SelectedNode.Name)
            {
                case "nodexquang": showxquanh(); break;
                case "nodesieuam": showsieuam(); break;
                case "nodelamsang": showlamsang(); break;
                case "nodexetnghiem": showxetnghiem(); break;
                case "nodenoisoi": shownoisoi(); break;
                case "nodedonthuoc": showdonthuoc(); break;
                case "nodelskham": showlskham(); break;

            }
        }

        private void showlskham()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = false;
            panelsieuam.Visible = false;
            panellamsang.Visible = false;
            panellichsukham.Visible = true;
        }

        private void showdonthuoc()
        {
            paneldonthuoc.Visible = true;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = false;
            panelsieuam.Visible = false;
            panellamsang.Visible = false;
            panellichsukham.Visible = false;
        }

        private void shownoisoi()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = true;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = false;
            panelsieuam.Visible = false;
            panellamsang.Visible = false;


            int a = 5;
            cbnoisoi.DataSource = libraryService.DanhSachLoaiCLS(a);
            cbnoisoi.ValueMember = "MACLS";
            cbnoisoi.DisplayMember = "TENCLS";

            panellichsukham.Visible = false;
        }

        private void showxetnghiem()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = true;
            panelxquang.Visible = false;
            panelsieuam.Visible = false;
            panellamsang.Visible = false;
            panellichsukham.Visible = false;
        }

        private void showxquanh()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = true;
            panelsieuam.Visible = false;
            panellichsukham.Visible = false;
            panellamsang.Visible = false;

            int a = 3;
            cbxquang.DataSource = libraryService.DanhSachLoaiCLS(a);
            cbxquang.ValueMember = "MACLS";
            cbxquang.DisplayMember = "TENCLS";

        }
        private void showsieuam()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = false;
            panelsieuam.Visible = true;
            panellamsang.Visible = false;

            int a = 4;
            cbsieuam.DataSource = libraryService.DanhSachLoaiCLS(a);
            cbsieuam.ValueMember = "MACLS";
            cbsieuam.DisplayMember = "TENCLS";

            panellichsukham.Visible = false;

        }
        private void showlamsang()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = false;
            panelsieuam.Visible = false;
            panellamsang.Visible = true;
            panellichsukham.Visible = false;
        }

        private void btntimphieukham_Click(object sender, EventArgs e)
        {

            if (txttimphieukham.Text != "")
            {
                dgvdsphieukham.DataSource = libraryService.KetQuaTimPhieuKham(txttimphieukham.Text);
                dgvdsphieukham.Columns[0].HeaderText = "Mã phiếu"; dgvdsphieukham.Columns[0].Width = 40;
                dgvdsphieukham.Columns[1].HeaderText = "Tên bệnh nhân"; dgvdsphieukham.Columns[1].Width = 105;
                dgvdsphieukham.Columns[2].HeaderText = "Ngày khám"; dgvdsphieukham.Columns[2].Width = 70;
                dgvdsphieukham.Columns[3].HeaderText = "Đã Khám"; dgvdsphieukham.Columns[3].Width = 40;
                dgvdsphieukham.RowHeadersVisible = false;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên bệnh nhân cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void fKhamBenhNhan_Load(object sender, EventArgs e)
        {

            List<PhieuKham_BenhNhanChoKham> list = new List<PhieuKham_BenhNhanChoKham>();
            list = libraryService.DanhSachChoKham();
            for (int i = 1; i < list.Count; i++)
            {
                list[i].STT = i;
            }
            dgvdschokham.DataSource = list;
            dgvdschokham.Columns[0].HeaderText = "STT"; dgvdschokham.Columns[0].Width = 30;
            dgvdschokham.Columns[1].HeaderText = "Mã phiếu"; dgvdschokham.Columns[1].Width = 40;
            dgvdschokham.Columns[2].HeaderText = "Tên bệnh nhân"; dgvdschokham.Columns[2].Width = 115;
            dgvdschokham.Columns[3].HeaderText = "Ngày khám"; dgvdschokham.Columns[3].Width = 75;
            dgvdschokham.RowHeadersVisible = false;
        }

        private void dgvdschokham_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvdschokham.SelectedRows)
            {
                int maphieu = (int)row.Cells[1].Value;
                txttenbenhnhan.Text = row.Cells[2].Value.ToString();
                PhieuKham_BenhNhanLamSang pk = new PhieuKham_BenhNhanLamSang();
                pk = libraryService.DanhSachPhieuKham(maphieu);
                txtmaphieukham.Text = pk.MaPhieuKham.ToString();
                txtmabenhnhan.Text = pk.MaBN.ToString();
                txtngaykham.Text = pk.NgayKham.ToString();
                txtchandoan.Text = pk.ChuanDoan;
                txtketluan.Text = pk.KetLuan;
                txtnhietdo.Text = pk.NhietDo.ToString();
                txtnhiptim.Text = pk.NhipTim.ToString();
                txthuyetap.Text = pk.HuyetAp.ToString();
                txtchieucao.Text = pk.ChieuCao.ToString();
                txtcannang.Text = pk.CanNang.ToString();
                txtmaicd.Text = pk.MaICD.ToString();
                txttiensukham.Text = pk.TienSu;



                //đổ dữ liệu vào bảng đơn thuốc

                List<ChiTietDonThuoc_Thuoc> listdonthuoc = new List<ChiTietDonThuoc_Thuoc>();
                listdonthuoc = libraryService.DanhSachChiTietDonThuoc(maphieu);
                for (int i = 1; i < listdonthuoc.Count; i++)
                {
                    listdonthuoc[i].STT = i;
                }
                dgvdonthuoc.DataSource = listdonthuoc;
                dgvdonthuoc.Columns[0].HeaderText = "STT"; dgvdonthuoc.Columns[0].Width = 40;
                dgvdonthuoc.Columns[1].HeaderText = "Mã phiếu"; dgvdonthuoc.Columns[1].Width = 85;
                dgvdonthuoc.Columns[2].HeaderText = "Tên thuốc"; dgvdonthuoc.Columns[2].Width = 200 ;
                dgvdonthuoc.Columns[3].HeaderText = "Số lượng"; dgvdonthuoc.Columns[3].Width = 95;
                dgvdonthuoc.Columns[4].HeaderText = "Hướng dẫn"; dgvdonthuoc.Columns[4].Width = 235;
                dgvdonthuoc.RowHeadersVisible = false;


                //đổ dữ liệu vào bảng lịch sử khám
                List<PhieuKham_LichSuKham> listlskham = new List<PhieuKham_LichSuKham>();
                int mabn = int.Parse(txtmabenhnhan.Text);
                listlskham = libraryService.LichSuKham(mabn);
                for (int i = 1; i < listlskham.Count; i++)
                {
                    listlskham[i].STT = i;
                }
                dgvlichsukham.DataSource = listlskham;
                dgvlichsukham.Columns[0].HeaderText = "STT"; dgvlichsukham.Columns[0].Width = 40;
                dgvlichsukham.Columns[1].HeaderText = "Mã phiếu"; dgvlichsukham.Columns[1].Width = 85;
                dgvlichsukham.Columns[2].HeaderText = "Ngày khám"; dgvlichsukham.Columns[2].Width = 115;
                dgvlichsukham.Columns[3].HeaderText = "Chuẩn đoán"; dgvlichsukham.Columns[3].Width = 255;
                dgvlichsukham.Columns[4].HeaderText = "Kết quả"; dgvlichsukham.Columns[4].Width = 265;
                dgvlichsukham.RowHeadersVisible = false;

            }
        }

        private void dgvdsphieukham_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvdsphieukham.SelectedRows)
            {
                int maphieu = (int)row.Cells[0].Value;
                txttenbenhnhan.Text = row.Cells[1].Value.ToString();
                PhieuKham_BenhNhanLamSang pk = new PhieuKham_BenhNhanLamSang();
                pk = libraryService.DanhSachPhieuKham(maphieu);
                txtmaphieukham.Text = pk.MaPhieuKham.ToString();
                txtmabenhnhan.Text = pk.MaBN.ToString();              
                txtngaykham.Text = pk.NgayKham.ToString();
                txtchandoan.Text = pk.ChuanDoan;
                txtketluan.Text = pk.KetLuan;
                txtnhietdo.Text = pk.NhietDo.ToString();
                txtnhiptim.Text = pk.NhipTim.ToString();
                txthuyetap.Text = pk.HuyetAp.ToString();
                txtchieucao.Text = pk.ChieuCao.ToString();
                txtcannang.Text = pk.CanNang.ToString();
                txtmaicd.Text = pk.MaICD.ToString();
                txttiensukham.Text = pk.TienSu;


                //đổ dữ liệu vào bảng đơn thuốc

                List<ChiTietDonThuoc_Thuoc> listdonthuoc = new List<ChiTietDonThuoc_Thuoc>();
                listdonthuoc = libraryService.DanhSachChiTietDonThuoc(maphieu);
                for (int i = 1; i < listdonthuoc.Count; i++)
                {
                    listdonthuoc[i].STT = i;
                }
                dgvdonthuoc.DataSource = listdonthuoc;
                dgvdonthuoc.Columns[0].HeaderText = "STT"; dgvdonthuoc.Columns[0].Width = 40;
                dgvdonthuoc.Columns[1].HeaderText = "Mã phiếu"; dgvdonthuoc.Columns[1].Width = 85;
                dgvdonthuoc.Columns[2].HeaderText = "Tên thuốc"; dgvdonthuoc.Columns[2].Width = 200;
                dgvdonthuoc.Columns[2].HeaderText = "Số lượng"; dgvdonthuoc.Columns[3].Width = 95;
                dgvdonthuoc.Columns[2].HeaderText = "Hướng dẫn"; dgvdonthuoc.Columns[4].Width = 230;
                dgvdonthuoc.RowHeadersVisible = false;


                //đổ dữ liệu vào bảng lịch sử khám

                List<PhieuKham_LichSuKham> listlskham = new List<PhieuKham_LichSuKham>();
                int mabn = int.Parse(txtmabenhnhan.Text);
                listlskham = libraryService.LichSuKham(mabn);
                for (int i = 1; i < listlskham.Count; i++)
                {
                    listlskham[i].STT = i;
                }
                dgvlichsukham.DataSource = listdonthuoc;
                dgvlichsukham.Columns[0].HeaderText = "STT"; dgvlichsukham.Columns[0].Width = 40;
                dgvlichsukham.Columns[1].HeaderText = "Mã phiếu"; dgvlichsukham.Columns[1].Width = 85;
                dgvlichsukham.Columns[2].HeaderText = "Ngày khám"; dgvlichsukham.Columns[2].Width = 115;
                dgvlichsukham.Columns[2].HeaderText = "Chuẩn đoán"; dgvlichsukham.Columns[3].Width = 250;
                dgvlichsukham.Columns[2].HeaderText = "Kết quả"; dgvlichsukham.Columns[4].Width = 265;
                dgvlichsukham.RowHeadersVisible = false;
            }

        }

        private void btnluuphieukham_Click(object sender, EventArgs e)
        {
            DonThuoc dt = new DonThuoc();
            dt.MAPHIEUKHAM = int.Parse(txtmaphieukham.Text);   
            PhieuKham_BenhNhanLamSang pkbn = new PhieuKham_BenhNhanLamSang(int.Parse(txtmaphieukham.Text), int.Parse(txtmabenhnhan.Text),0,txtchandoan.Text,0,txtnhiptim.Text,txtnhietdo.Text,txthuyetap.Text,txtcannang.Text,txtchieucao.Text,txtmaicd.Text, DateTime.Parse(txtngaykham.Text),null,null,txtketluan.Text,txttiensukham.Text);

            if (libraryService.LuuPhieuKham(pkbn) !=0)
            {
                MessageBox.Show("Lưu phiếu khám thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lưu phiếu khám không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if(TaoDonThuoc(dt)!=0)
            {
                foreach (ChiTietDonThuoc i in DanhSachDonThuoc())
                {
                    libraryService.TaoChiTietDonThuoc(i,dt.MAPHIEUKHAM);
                }
            }
            else
            {
                MessageBox.Show("Tạo đơn thuốc không thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private List<ChiTietDonThuoc> DanhSachDonThuoc()
        {
            List<ChiTietDonThuoc> listdt = new List<ChiTietDonThuoc>();
            for(int i=0;i<dgvdonthuoc.RowCount;i++)
            {
                ChiTietDonThuoc thuoc = new ChiTietDonThuoc();               
                thuoc.MATHUOC = int.Parse(dgvdonthuoc.Rows[i].Cells[1].Value.ToString());
                thuoc.SOLUONG = int.Parse(dgvdonthuoc.Rows[i].Cells[2].Value.ToString());
                thuoc.HUONGDAN = dgvdonthuoc.Rows[i].Cells[3].Value.ToString();
                listdt.Add(thuoc);
            }
            return listdt;
        }

        private int TaoDonThuoc(DonThuoc donthuoc)
        {
            return libraryService.ThemDonThuoc(donthuoc);
        }

        private void btnxacnhanxquang_Click(object sender, EventArgs e)
        {
            string getmacls = cbxquang.SelectedValue.ToString();
            string getphieunhap = txtmaphieukham.Text;

            int result = libraryService.InsertChiTietCLS(getphieunhap, getmacls);
            if (result > 0)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại, đã có sẳn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnxacnhansieuam_Click(object sender, EventArgs e)
        {
            string getmacls = cbsieuam.SelectedValue.ToString();
            string getphieunhap = txtmaphieukham.Text;

            int result = libraryService.InsertChiTietCLS(getphieunhap, getmacls);
            if (result > 0)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại, đã có sẳn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxacnhannoisoi_Click(object sender, EventArgs e)
        {
            string getmacls = cbnoisoi.SelectedValue.ToString();
            string getphieunhap = txtmaphieukham.Text;

            int result = libraryService.InsertChiTietCLS(getphieunhap, getmacls);
            if (result > 0)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại, đã có sẳn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlichsulamviec_Click(object sender, EventArgs e)
        {            
            fLichSuKhamBacSi f = new fLichSuKhamBacSi(int.Parse(txtmabenhnhan.Text));
            f.Load_fLichSuKhamBacSi();
            f.ShowDialog();
           
        }
    }
}

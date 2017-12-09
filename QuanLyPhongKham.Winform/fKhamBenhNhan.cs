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
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace QuanLyPhongKham.Winform
{
    public partial class fKhamBenhNhan : Form
    {
        #region bien toan cuc
        private LibraryService libraryService;
        int manv;
        string link = @"F:\STUDY\ĐỒ ÁN NĂM  3\QUANLYPHONGKHAM\File";   // địa chỉ file kết quả
        public string tenthuoc;
        public int mathuocft;
        #endregion

        #region Constructor 
        public fKhamBenhNhan(int manv)
        {
            this.manv = manv;
            InitializeComponent();

            libraryService = ServiceFactory.GetLibraryService(LibraryParameter.persistancestrategy);

            //add parent 
            panellamsang.Parent = panelchinh;
            panelsieuam.Parent = panelchinh;
            panelxquang.Parent = panelchinh;
            panelxetnghiem.Parent = panelchinh;
            panelnoisoi.Parent = panelchinh;
            paneldonthuoc.Parent = panelchinh;
            panellichsukham.Parent = panelchinh;
        }
        #endregion

        #region Events

        private void treeviewdichvukham(object sender, TreeViewEventArgs e)
        {
            switch (treeviewdvkham.SelectedNode.Name)
            {
                case "nodexquang":
                    showxquang();
                    dulieuxquang();
                    break;
                case "nodesieuam":
                    showsieuam();
                    dulieusieuam();
                    break;
                case "nodelamsang":
                    showlamsang();
                    break;
                case "nodexetnghiem":
                    showxetnghiem();
                    dulieuxetnghiem();
                    break;
                case "nodenoisoi":
                    shownoisoi();
                    dulieunoisoi();
                    break;
                case "nodedonthuoc":
                    showdonthuoc();
                    break;
                case "nodelskham":
                    showlskham();
                    break;

            }
        }
        private void btntimphieukham_Click(object sender, EventArgs e)
        {
            if (libraryService.KetQuaTimPhieuKham(txttimphieukham.Text.Trim(), manv).Count == 0)
            {
                MessageBox.Show("Không tìm thấy bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                List<PhieuKham_BenhNhanTimKiem> list = new List<PhieuKham_BenhNhanTimKiem>();
                list = libraryService.KetQuaTimPhieuKham(txttimphieukham.Text.Trim(), manv);
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].NgayKham = DateTime.Parse(list[i].NgayKham.ToString("dd/MM/yyyy"));
                }
                dgvdsphieukham.DataSource = list;
                dgvdsphieukham.Columns[0].HeaderText = "Mã phiếu"; dgvdsphieukham.Columns[0].Width = 40;
                dgvdsphieukham.Columns[1].HeaderText = "Tên bệnh nhân"; dgvdsphieukham.Columns[1].Width = 105;
                dgvdsphieukham.Columns[2].HeaderText = "Ngày khám"; dgvdsphieukham.Columns[2].Width = 70;
                dgvdsphieukham.Columns[3].HeaderText = "Đã Khám"; dgvdsphieukham.Columns[3].Width = 40;
                dgvdsphieukham.RowHeadersVisible = false;
                dgvdsphieukham.Rows[0].Selected = false;
            }
        }
        private void fKhamBenhNhan_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        private void dgvdschokham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvdschokham.SelectedRows)
            {
                int maphieu = (int)row.Cells[1].Value;
                txttenbenhnhan.Text = row.Cells[2].Value.ToString();
                PhieuKham_BenhNhanLamSang pk = libraryService.ThongTinPhieuKham(maphieu); ;
                txtmaphieukham.Text = pk.MaPhieuKham.ToString();
                txtmabenhnhan.Text = pk.MaBN.ToString();
                txtngaykham.Text = pk.NgayKham.ToString("dd/MM/yyyy");
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
                dgvdonthuoc.Rows.Clear();
                for (int i = 0; i < listdonthuoc.Count; i++)
                {
                    listdonthuoc[i].STT = i + 1;
                }
                foreach (var item in listdonthuoc)
                {
                    dgvdonthuoc.Rows.Add(item.STT, item.MATHUOC, item.TENTHUOC, item.SOLUONG, item.HUONGDAN);
                }


                //đổ dữ liệu vào bảng lịch sử khám
                List<PhieuKham_LichSuKham> listlskham = new List<PhieuKham_LichSuKham>();
                int mabn = int.Parse(txtmabenhnhan.Text);
                listlskham = libraryService.LichSuKham(mabn);
                for (int i = 0; i < listlskham.Count; i++)
                {
                    listlskham[i].STT = i + 1;
                    listlskham[i].NgayKham = DateTime.Parse(listlskham[i].NgayKham.ToString("dd/MM/yyyy"));

                }
                dgvlichsukham.DataSource = listlskham;
                dgvlichsukham.Columns[0].HeaderText = "STT"; dgvlichsukham.Columns[0].Width = 40;
                dgvlichsukham.Columns[1].HeaderText = "Mã phiếu"; dgvlichsukham.Columns[1].Width = 85;
                dgvlichsukham.Columns[2].HeaderText = "Ngày khám"; dgvlichsukham.Columns[2].Width = 115;
                dgvlichsukham.Columns[3].HeaderText = "Chuẩn đoán"; dgvlichsukham.Columns[3].Width = 255;
                dgvlichsukham.Columns[4].HeaderText = "Kết quả"; dgvlichsukham.Columns[4].Width = 265;
                dgvlichsukham.RowHeadersVisible = false;
                if (listlskham.Count > 0)
                {
                    dgvlichsukham.Rows[0].Selected = false;
                }
            }
        }
        private void dgvdsphieukham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvdsphieukham.SelectedRows)
            {
                //đổ dữ liệu lên thông tin phiếu khám + panel lâm sàng
                int maphieu = (int)row.Cells[0].Value;
                txttenbenhnhan.Text = row.Cells[1].Value.ToString();
                PhieuKham_BenhNhanLamSang pk = libraryService.ThongTinPhieuKham(maphieu);
                txtmaphieukham.Text = pk.MaPhieuKham.ToString();
                txtmabenhnhan.Text = pk.MaBN.ToString();
                txtngaykham.Text = pk.NgayKham.ToString("dd/MM/yyyy");
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
                dgvdonthuoc.Rows.Clear();
                for (int i = 0; i < listdonthuoc.Count; i++)
                {
                    listdonthuoc[i].STT = i + 1;
                }
                foreach (var item in listdonthuoc)
                {
                    dgvdonthuoc.Rows.Add(item.STT, item.MATHUOC, item.TENTHUOC, item.SOLUONG, item.HUONGDAN);
                }


                //đổ dữ liệu vào bảng lịch sử khám

                List<PhieuKham_LichSuKham> listlskham = new List<PhieuKham_LichSuKham>();
                int mabn = int.Parse(txtmabenhnhan.Text);
                listlskham = libraryService.LichSuKham(mabn);
                for (int i = 0; i < listlskham.Count; i++)
                {
                    listlskham[i].STT = i + 1;
                    listlskham[i].NgayKham = DateTime.Parse(listlskham[i].NgayKham.ToString("dd/MM/yyyy"));

                }
                dgvlichsukham.DataSource = listlskham;
                dgvlichsukham.Columns[0].HeaderText = "STT"; dgvlichsukham.Columns[0].Width = 40;
                dgvlichsukham.Columns[1].HeaderText = "Mã phiếu"; dgvlichsukham.Columns[1].Width = 85;
                dgvlichsukham.Columns[2].HeaderText = "Ngày khám"; dgvlichsukham.Columns[2].Width = 115;
                dgvlichsukham.Columns[3].HeaderText = "Chuẩn đoán"; dgvlichsukham.Columns[3].Width = 250;
                dgvlichsukham.Columns[4].HeaderText = "Kết quả"; dgvlichsukham.Columns[4].Width = 265;
                dgvlichsukham.RowHeadersVisible = false;
                if (listlskham.Count > 0)
                {
                    dgvlichsukham.Rows[0].Selected = false;
                }
            }
    }
        private void btnluuphieukham_Click(object sender, EventArgs e)
        {
            //Khởi tạo một Đơn thuốc với mã phiếu khám là txtmaphieukham.Text
            DonThuoc dt = new DonThuoc();
            dt.MAPHIEUKHAM = int.Parse(txtmaphieukham.Text);
            //Thao tác lưu phiếu 
            try
            {
                int cannang = int.Parse(txtcannang.Text);
                int chieucao = int.Parse(txtchieucao.Text);
                PhieuKham_BenhNhanLamSang pkbn = new PhieuKham_BenhNhanLamSang(int.Parse(txtmaphieukham.Text), int.Parse(txtmabenhnhan.Text), 0, txtchandoan.Text, 0, txtnhiptim.Text, txtnhietdo.Text, txthuyetap.Text, txtcannang.Text, txtchieucao.Text, txtmaicd.Text, DateTime.Parse(txtngaykham.Text), null, null, txtketluan.Text, txttiensukham.Text);
                if (libraryService.LuuPhieuKham(pkbn) != 0)
                {
                    MessageBox.Show("Lưu phiếu khám thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lưu phiếu khám không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Lưu đơn thuốc

                TaoDonThuoc(dt);
                try
                {   
                foreach (ChiTietDonThuoc i in DanhSachDonThuoc())
                {
                    if (libraryService.TaoChiTietDonThuoc(i, dt.MAPHIEUKHAM) == 0)
                    {
                            MessageBox.Show("Lưu đơn thuốc không thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            List<ChiTietDonThuoc_Thuoc> listdonthuoc = new List<ChiTietDonThuoc_Thuoc>();
                            listdonthuoc = libraryService.DanhSachChiTietDonThuoc(dt.MAPHIEUKHAM);
                            dgvdonthuoc.Rows.Clear();
                            for (int j = 0; j < listdonthuoc.Count; j++)
                            {
                                listdonthuoc[j].STT = j + 1;
                            }
                            foreach (var item in listdonthuoc)
                            {
                                dgvdonthuoc.Rows.Add(item.STT, item.MATHUOC, item.TENTHUOC, item.SOLUONG, item.HUONGDAN);
                            }
                            break;
                    }
                }
                }
                catch
                {
                    MessageBox.Show("Lưu đơn thuốc không thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List<ChiTietDonThuoc_Thuoc> listdonthuoc = new List<ChiTietDonThuoc_Thuoc>();
                    listdonthuoc = libraryService.DanhSachChiTietDonThuoc(dt.MAPHIEUKHAM);
                    dgvdonthuoc.Rows.Clear();
                    for (int i = 0; i < listdonthuoc.Count; i++)
                    {
                        listdonthuoc[i].STT = i + 1;
                    }
                    foreach (var item in listdonthuoc)
                    {
                        dgvdonthuoc.Rows.Add(item.STT, item.MATHUOC, item.TENTHUOC, item.SOLUONG, item.HUONGDAN);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lưu phiếu khám không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }       
    }
        private void dgvlichsukham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvlichsukham.SelectedRows)
            {
                //đổ dữ liệu lên thông tin phiếu khám + panel lâm sàng
                int maphieu = (int)row.Cells[1].Value;
                PhieuKham_BenhNhanLamSang pk = libraryService.ThongTinPhieuKham(maphieu);
                txtmaphieukham.Text = pk.MaPhieuKham.ToString();
                txtmabenhnhan.Text = pk.MaBN.ToString();
                txtngaykham.Text = pk.NgayKham.ToString("dd/MM/yyyy");
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
                dgvdonthuoc.Rows.Clear();
                for (int i = 0; i < listdonthuoc.Count; i++)
                {
                    listdonthuoc[i].STT = i + 1;
                }
                foreach (var item in listdonthuoc)
                {
                    dgvdonthuoc.Rows.Add(item.STT, item.MATHUOC, item.TENTHUOC, item.SOLUONG, item.HUONGDAN);
                }

            }
    }
        private void btnHoanthanh_Click(object sender, EventArgs e)
        {
            if (libraryService.HoanThanhPhieuKham(int.Parse(txtmaphieukham.Text)) != 0)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadForm();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsmi_lichsulamviec_Click(object sender, EventArgs e)
        {
            fLichSuKhamBacSi f = new fLichSuKhamBacSi(manv);
            f.Load_fLichSuKhamBacSi();
            f.ShowDialog();
            if (f.maphieu != 0 && f.tenbn != null)
            {
                //đổ dữ liệu lên thông tin phiếu khám + panel lâm sàng
                txttenbenhnhan.Text = f.tenbn;
                PhieuKham_BenhNhanLamSang pk = new PhieuKham_BenhNhanLamSang();
                pk = libraryService.ThongTinPhieuKham(f.maphieu);
                txtmaphieukham.Text = pk.MaPhieuKham.ToString();
                txtmabenhnhan.Text = pk.MaBN.ToString();
                txtngaykham.Text = pk.NgayKham.ToString("dd/MM/yyyy");
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
                listdonthuoc = libraryService.DanhSachChiTietDonThuoc(f.maphieu);
                dgvdonthuoc.Rows.Clear();
                for (int i = 0; i < listdonthuoc.Count; i++)
                {
                    listdonthuoc[i].STT = i + 1;
                }
                foreach (var item in listdonthuoc)
                {
                    dgvdonthuoc.Rows.Add(item.STT, item.MATHUOC, item.TENTHUOC, item.SOLUONG, item.HUONGDAN);
                }



                //đổ dữ liệu vào bảng lịch sử khám
                List<PhieuKham_LichSuKham> listlskham = new List<PhieuKham_LichSuKham>();
                int mabn = int.Parse(txtmabenhnhan.Text);
                listlskham = libraryService.LichSuKham(mabn);
                for (int i = 0; i < listlskham.Count; i++)
                {
                    listlskham[i].STT = i + 1;
                    listlskham[i].NgayKham = DateTime.Parse(listlskham[i].NgayKham.ToString("dd/MM/yyyy"));
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
        private void btnxacnhanxetnghiem_Click(object sender, EventArgs e)
        {
            string getmacls = cbxetnghiem.SelectedValue.ToString();
            string getphieunhap = txtmaphieukham.Text;
            string linkxetnghiem = "File\\Xet-nghiem\\XN";
            int result = libraryService.InsertChiTietCLS(getphieunhap, getmacls, linkxetnghiem);

            string mabn = txtmabenhnhan.Text;
            ChiTietCLS cls = new ChiTietCLS();
            cls = libraryService.LayketQua(getphieunhap, getmacls);
            string ketqua = cls.KetQua.ToString();
            string linkdanxetnghiem = @ketqua + "" + mabn + "" + getphieunhap;

            if (result > 0)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // đưa dữ liệu từ file vào sieu am
                // đọc từ file word

                try
                {
                    string file = link + "" + @linkdanxetnghiem + "" + @"\ketqua.xlsx";
                    dgvketquaxetnghiem.DataSource = libraryService.GetCLS(file);
                    dgvdsphieukham.RowHeadersVisible = false;
                }
                catch
                {
                    MessageBox.Show("Cập nhật thất bại, đã có sẳn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        private void btntimthuoc_Click(object sender, EventArgs e)
        {
            fTimKiemThuoc f = new fTimKiemThuoc();
            f.ShowDialog();
            Show();
            txtchonthuoc.Text = Convert.ToString(f.mathuoctkt);
            tenthuoc = f.tenthuoctkt;
            mathuocft = f.mathuoctkt;
        }
        private void btnchonthuoc_Click(object sender, EventArgs e)
        {
            fTimKiemThuoc f = new fTimKiemThuoc();
            try
            {
                int soluong = int.Parse(txtsoluongthuoc.Text);
                if (soluong > 0)
                {                   
                    int maphieu = int.Parse(txtmaphieukham.Text);
                    int stt = dgvdonthuoc.Rows.Count;
                    List<ChiTietDonThuoc_Thuoc> listdonthuoc = new List<ChiTietDonThuoc_Thuoc>();
                    listdonthuoc = libraryService.DanhSachChiTietDonThuoc(maphieu);

                    if (stt < dgvdonthuoc.Rows.Count)
                    {
                        stt = dgvdonthuoc.Rows.Count;
                        dgvdonthuoc.Rows.Add(stt, mathuocft, tenthuoc, txtsoluongthuoc.Text, txtghichudonthuoc.Text);
                        stt = stt + 1;
                    }
                    else
                    {
                        dgvdonthuoc.Rows.Add(stt + 1, mathuocft, tenthuoc, txtsoluongthuoc.Text, txtghichudonthuoc.Text);
                        stt = stt + 1;
                    }
                }
                else
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Số lượng không hợp lệ!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnxacnhanxquang_Click_1(object sender, EventArgs e)
        {
            string getmacls = cbxquang.SelectedValue.ToString();
            string getphieunhap = txtmaphieukham.Text;
            string linkxquang = "File\\X-quang\\XQ";
            int result = libraryService.InsertChiTietCLS(getphieunhap, getmacls, linkxquang);
            string mabn = txtmabenhnhan.Text;
            ChiTietCLS cls = new ChiTietCLS();
            cls = libraryService.LayketQua(getphieunhap, getmacls);

            string ketqua = cls.KetQua.ToString();

            string linkdanxquang = @ketqua + "" + mabn + "" + getphieunhap;

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {

                        // chèn ảnh vào picturebox
                        string filepath1 = link + "" + @linkdanxquang + "" + @"\pcb1.jpg";
                        OpenFileDialog ofdImage1s = new OpenFileDialog();
                        pcbxquang1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pcbxquang1.Image = Image.FromFile(filepath1.ToString());


                        string filepath2 = link + "" + @linkdanxquang + "" + @"\pcb2.jpg";
                        OpenFileDialog ofdImages2 = new OpenFileDialog();
                        pcbxquang1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pcbxquang2.Image = Image.FromFile(filepath2.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Cập nhật thất bại, đã có sẳn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

        }
        private void btnxacnhannoisoi_Click_1(object sender, EventArgs e)
        {
            string getmacls = cbnoisoi.SelectedValue.ToString();
            string getphieunhap = txtmaphieukham.Text;
            string linknoisoi = "File\\Noi-soi\\NS";
            int result = libraryService.InsertChiTietCLS(getphieunhap, getmacls, linknoisoi);
            string mabn = txtmabenhnhan.Text;
            ChiTietCLS cls = new ChiTietCLS();
            cls = libraryService.LayketQua(getphieunhap, getmacls);
            string ketqua = cls.KetQua.ToString();

            string linkdannoisoi = @ketqua + "" + mabn + "" + getphieunhap;

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        // đưa dữ liệu từ file vào sieu am
                        // đọc từ file word
                        string file = link + "" + linkdannoisoi;
                        var word = new Microsoft.Office.Interop.Word.Application();
                        Microsoft.Office.Interop.Word.Document document = word.Documents.Open(file + "" + @"\ketqua.docx");
                        document.ActiveWindow.Selection.WholeStory();
                        document.ActiveWindow.Selection.Copy();
                        document.Close();
                        IDataObject data = Clipboard.GetDataObject();
                        txtmotonoisoi.Text = data.GetData(DataFormats.UnicodeText).ToString();

                        // chèn ảnh vào picturebox
                        string filepath1 = file + "" + @"\pcb1.jpg";

                        OpenFileDialog ofdImage1s = new OpenFileDialog();
                        pcbnoisoi1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pcbnoisoi1.Image = Image.FromFile(filepath1.ToString());


                        string filepath2 = file + "" + @"\pcb2.jpg";

                        OpenFileDialog ofdImages2 = new OpenFileDialog();
                        pcbnoisoi2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pcbnoisoi2.Image = Image.FromFile(filepath2.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Cập nhật thất bại, đã có sẳn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

        }
        private void btnxacnhansieuam_Click_1(object sender, EventArgs e)
        {
            string getmacls = cbsieuam.SelectedValue.ToString();
            string getphieunhap = txtmaphieukham.Text;
            string linksieuam = "File\\Sieu-am\\SA";
            int result = libraryService.InsertChiTietCLS(getphieunhap, getmacls, linksieuam);

            string mabn = txtmabenhnhan.Text;
            ChiTietCLS cls = new ChiTietCLS();
            cls = libraryService.LayketQua(getphieunhap, getmacls);
            string ketqua = cls.KetQua.ToString();

            string linkdansieuam = @ketqua + "" + mabn + "" + getphieunhap;

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // đưa dữ liệu từ file vào sieu am
                    // đọc từ file word
                    try
                    {

                        var word = new Microsoft.Office.Interop.Word.Application();
                        Microsoft.Office.Interop.Word.Document document = word.Documents.Open(link + "" + @linkdansieuam + "" + @"\ketqua.docx");
                        document.ActiveWindow.Selection.WholeStory();
                        document.ActiveWindow.Selection.Copy();
                        document.Close();
                        IDataObject data = Clipboard.GetDataObject();
                        txtmotasieuam.Text = data.GetData(DataFormats.UnicodeText).ToString();

                        // chèn ảnh vào picturebox
                        string filepath1 = link + "" + @linkdansieuam + "" + @"\pcb1.jpg";

                        OpenFileDialog ofdImage1s = new OpenFileDialog();
                        pcbsieuam1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pcbsieuam1.Image = Image.FromFile(filepath1.ToString());


                        string filepath2 = link + "" + @linkdansieuam + "" + @"\pcb2.jpg";

                        OpenFileDialog ofdImages2 = new OpenFileDialog();
                        pcbsieuam1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pcbsieuam2.Image = Image.FromFile(filepath2.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Cập nhật thất bại, đã có sẳn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
        }

        #endregion

        #region Method
        /// <summary>
        /// Hàm hiện thị panel lịch sử khám
        /// </summary>
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

        /// <summary>
        /// Hàm hiện thị panel đơn thuốc
        /// </summary>
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

        /// <summary>
        /// Hàm hiện thị panel nôi sôi
        /// </summary>
        private void shownoisoi()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = true;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = false;
            panelsieuam.Visible = false;
            panellamsang.Visible = false;
            panellichsukham.Visible = false;

        }

        /// <summary>
        ///  đỗ dữ liệu vào panel nội sôi
        /// </summary>
        private void dulieunoisoi()
        {
            int a = 5;
            cbnoisoi.DataSource = libraryService.DanhSachLoaiCLS(a);
            cbnoisoi.ValueMember = "MACLS";
            cbnoisoi.DisplayMember = "TENCLS";



        }

        /// <summary>
        /// Hàm hiện thị panel xét nghiệm
        /// </summary>
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

        /// <summary>
        /// đỗ dữ liệu vào panel xét nghiệm
        /// </summary>
        private void dulieuxetnghiem()
        {

            // đưa dữ liệu vào combobox
            int a = 2;
            cbxetnghiem.DataSource = libraryService.DanhSachLoaiCLS(a);
            cbxetnghiem.ValueMember = "MACLS";
            cbxetnghiem.DisplayMember = "TENCLS";

        }

        /// <summary>
        /// Hàm hiện thị panel chụp x-quang
        /// </summary>
        private void showxquang()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = true;
            panelsieuam.Visible = false;
            panellichsukham.Visible = false;
            panellamsang.Visible = false;

        }
        /// <summary>
        /// đỗ dữ liệu vào panel x-quanh
        /// </summary>
        private void dulieuxquang()
        {
            int a = 3;
            cbxquang.DataSource = libraryService.DanhSachLoaiCLS(a);
            cbxquang.ValueMember = "MACLS";
            cbxquang.DisplayMember = "TENCLS";


        }

        /// <summary>
        /// Hàm hiện thị panel siêu âm
        /// </summary>
        private void showsieuam()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = false;
            panelsieuam.Visible = true;
            panellamsang.Visible = false;
            panellichsukham.Visible = false;

        }

        /// <summary>
        /// đỗ dữ liệu vào panel sieu am
        /// </summary>
        /// 
        private void dulieusieuam()
        {
            // đưa dữ liệu vào combobox panel sieu âm
            int a = 4;
            cbsieuam.DataSource = libraryService.DanhSachLoaiCLS(a);
            cbsieuam.ValueMember = "MACLS";
            cbsieuam.DisplayMember = "TENCLS";

        }

        /// <summary>
        /// Hàm hiện thị panel khám lâm sàng
        /// </summary>
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

        /// <summary>
        /// Hàm load form khám bệnh
        /// </summary>
        public void LoadForm()
        {
            panelchinh.Visible = true;
            //Load danh sách chờ khám
            List<PhieuKham_BenhNhanChoKham> list = new List<PhieuKham_BenhNhanChoKham>();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            list = libraryService.DanhSachChoKham(manv, date);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].STT = i + 1;
                list[i].NgayKham = DateTime.Parse(list[i].NgayKham.ToString("dd/MM/yyyy"));
            }
            dgvdschokham.DataSource = list;
            dgvdschokham.Columns[0].HeaderText = "STT"; dgvdschokham.Columns[0].Width = 30;
            dgvdschokham.Columns[1].HeaderText = "Mã phiếu"; dgvdschokham.Columns[1].Width = 40;
            dgvdschokham.Columns[2].HeaderText = "Tên bệnh nhân"; dgvdschokham.Columns[2].Width = 110;
            dgvdschokham.Columns[3].HeaderText = "Ngày khám"; dgvdschokham.Columns[3].Width = 75;
            dgvdschokham.RowHeadersVisible = false;
            //Load danh sách phiếu khám
            List<PhieuKham_BenhNhanTimKiem> listtimkiem = new List<PhieuKham_BenhNhanTimKiem>();

            listtimkiem = libraryService.DanhSachPhieuKham(manv);
            for (int i = 0; i < listtimkiem.Count; i++)
            {
                listtimkiem[i].NgayKham = DateTime.Parse(listtimkiem[i].NgayKham.ToString("dd/MM/yyyy"));
            }
            dgvdsphieukham.DataSource = listtimkiem;
            dgvdsphieukham.Columns[0].HeaderText = "Mã phiếu"; dgvdsphieukham.Columns[0].Width = 40;
            dgvdsphieukham.Columns[1].HeaderText = "Tên bệnh nhân"; dgvdsphieukham.Columns[1].Width = 105;
            dgvdsphieukham.Columns[2].HeaderText = "Ngày khám"; dgvdsphieukham.Columns[2].Width = 70;
            dgvdsphieukham.Columns[3].HeaderText = "Đã Khám"; dgvdsphieukham.Columns[3].Width = 40;
            dgvdsphieukham.RowHeadersVisible = false;

        }

        /// <summary>
        /// Hàm add thuốc trong bảng đơn thuốc vào danh sách chitietdonthuoc
        /// </summary>
        /// <returns></returns>       
        private List<ChiTietDonThuoc> DanhSachDonThuoc()
        {
            
            List<ChiTietDonThuoc> listdt = new List<ChiTietDonThuoc>();
            for (int i = 0; i < dgvdonthuoc.RowCount; i++)
            {
                ChiTietDonThuoc thuoc = new ChiTietDonThuoc();
                thuoc.MATHUOC = int.Parse(dgvdonthuoc.Rows[i].Cells[1].Value.ToString());
                thuoc.SOLUONG = int.Parse(dgvdonthuoc.Rows[i].Cells[3].Value.ToString());
                thuoc.HUONGDAN = dgvdonthuoc.Rows[i].Cells[4].Value.ToString();
                listdt.Add(thuoc);
            }
            return listdt;
        }

        /// <summary>
        /// Hàm thêm đơn thuốc vào database
        /// </summary>
        /// <param name="donthuoc"></param>
        /// <returns></returns>
        private int TaoDonThuoc(DonThuoc donthuoc)
        {
            return libraryService.ThemDonThuoc(donthuoc);
        }

        #endregion

    }
}

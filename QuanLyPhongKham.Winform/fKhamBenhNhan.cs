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
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Reflection;


namespace QuanLyPhongKham.Winform
{
    public partial class fKhamBenhNhan : Form
    {
        private LibraryService libraryService;
        int manv;

        string link = @"F:\STUDY\ĐỒ ÁN NĂM  3\QUANLYPHONGKHAM\File";   // địa chỉ file kết quả

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

        private void treeviewdichvukham(object sender, TreeViewEventArgs e)
        {
            switch (treeviewdvkham.SelectedNode.Name)
            {
                case "nodexquang": showxquang(); break;
                case "nodesieuam": showsieuam(); break;
                case "nodelamsang": showlamsang(); break;
                case "nodexetnghiem": showxetnghiem(); break;
                case "nodenoisoi": shownoisoi(); break;
                case "nodedonthuoc": showdonthuoc(); break;
                case "nodelskham": showlskham(); break;

            }
        }

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

            int a = 5;
            cbnoisoi.DataSource = libraryService.DanhSachLoaiCLS(a);
            cbnoisoi.ValueMember = "MACLS";
            cbnoisoi.DisplayMember = "TENCLS";



            // đưa dữ liệu từ file vào sieu am
            // đọc từ file word
            string mabn = txtmabenhnhan.Text;
            string maphieu = txtmaphieukham.Text;
            //string mabn = "001";
            //string maphieu = "001";
            string ma = mabn + "" + maphieu;
            if (ma != null)
            {
                var word = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document document = word.Documents.Open(link + @"\Noi-soi\NS" + ma + @"\ketqua.docx");
                document.ActiveWindow.Selection.WholeStory();
                document.ActiveWindow.Selection.Copy();
                document.Close();
                IDataObject data = Clipboard.GetDataObject();
                txtmotonoisoi.Text = data.GetData(DataFormats.UnicodeText).ToString();

                // chèn ảnh vào picturebox
                string filepath1 = link + @"\Noi-soi\NS" + ma + @"\pcb1.jpg";

                OpenFileDialog ofdImage1s = new OpenFileDialog();
                pcbnoisoi1.SizeMode = PictureBoxSizeMode.StretchImage;
                pcbnoisoi1.Image = Image.FromFile(filepath1.ToString());


                string filepath2 = link + @"\Noi-soi\NS" + ma + @"\pcb2.jpg";

                OpenFileDialog ofdImages2 = new OpenFileDialog();
                pcbnoisoi2.SizeMode = PictureBoxSizeMode.StretchImage;
                pcbnoisoi2.Image = Image.FromFile(filepath2.ToString());
            }
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

            // đưa dữ liệu vào combobox
            int a = 2;
            cbxetnghiem.DataSource = libraryService.DanhSachLoaiCLS(a);
            cbxetnghiem.ValueMember = "MACLS";
            cbxetnghiem.DisplayMember = "TENCLS";

            /// thêm vào
            string mabn = txtmabenhnhan.Text;
            string maphieu = txtmaphieukham.Text;
            string ma = mabn + "" + maphieu;
            if (ma != null)
            {
                string file = link + @"\Xet-nghiem\XN" + ma + @"\ketqua.xlsx";
                dgvketquaxetnghiem.DataSource = libraryService.GetCLS(file);
                dgvdsphieukham.RowHeadersVisible = false;
            }
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

            int a = 3;
            cbxquang.DataSource = libraryService.DanhSachLoaiCLS(a);
            cbxquang.ValueMember = "MACLS";
            cbxquang.DisplayMember = "TENCLS";

            // đưa dữ liệu từ file vào
            // đọc từ file word
            string mabn = txtmabenhnhan.Text;
            string maphieu = txtmaphieukham.Text;
            string ma = mabn + "" + maphieu;
            if (mabn != null && maphieu != null)
            {
                // chèn ảnh vào picturebox
                string filepath1 = link + @"\X-quang\XQ" + ma + @"\pcb1.jpg";
                OpenFileDialog ofdImage1s = new OpenFileDialog();
                pcbxquang1.SizeMode = PictureBoxSizeMode.StretchImage;
                pcbxquang1.Image = Image.FromFile(filepath1.ToString());


                string filepath2 = link + @"\X-quang\XQ" + ma + @"\pcb2.jpg";
                OpenFileDialog ofdImages2 = new OpenFileDialog();
                pcbxquang1.SizeMode = PictureBoxSizeMode.StretchImage;
                pcbxquang2.Image = Image.FromFile(filepath2.ToString());
            }
            Console.WriteLine(ma);

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

            // đưa dữ liệu vào combobox panel sieu âm
            int a = 4;
            cbsieuam.DataSource = libraryService.DanhSachLoaiCLS(a);
            cbsieuam.ValueMember = "MACLS";
            cbsieuam.DisplayMember = "TENCLS";


            // đưa dữ liệu từ file vào sieu am
            // đọc từ file word
            string mabn = txtmabenhnhan.Text;
            string maphieu = txtmaphieukham.Text;
            string ma = mabn + "" + maphieu;
            if (ma != null)
            {
                var word = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document document = word.Documents.Open(link + @"\Sieu-am\SA" + ma + @"\ketqua.docx");
                document.ActiveWindow.Selection.WholeStory();
                document.ActiveWindow.Selection.Copy();
                document.Close();
                IDataObject data = Clipboard.GetDataObject();
                txtmotasieuam.Text = data.GetData(DataFormats.UnicodeText).ToString();

                // chèn ảnh vào picturebox
                string filepath1 = link + @"\Sieu-am\SA" + ma + @"\pcb1.jpg";

                OpenFileDialog ofdImage1s = new OpenFileDialog();
                pcbsieuam1.SizeMode = PictureBoxSizeMode.StretchImage;
                pcbsieuam1.Image = Image.FromFile(filepath1.ToString());


                string filepath2 = link + @"\Sieu-am\SA" + ma + @"\pcb2.jpg";

                OpenFileDialog ofdImages2 = new OpenFileDialog();
                pcbsieuam1.SizeMode = PictureBoxSizeMode.StretchImage;
                pcbsieuam2.Image = Image.FromFile(filepath2.ToString());
            }

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

        private void btntimphieukham_Click(object sender, EventArgs e)
        {
            if (libraryService.KetQuaTimPhieuKham(txttimphieukham.Text.Trim(),manv).Count == 0)
            {
                MessageBox.Show("Không tìm thấy bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                dgvdsphieukham.DataSource = libraryService.KetQuaTimPhieuKham(txttimphieukham.Text.Trim(), manv);
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

        /// <summary>
        /// Hàm load form khám bệnh
        /// </summary>
        public void LoadForm()
        {
            panelchinh.Visible = true;
            //Load danh sách chờ khám
            List<PhieuKham_BenhNhanChoKham> list = new List<PhieuKham_BenhNhanChoKham>();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            list = libraryService.DanhSachChoKham(manv,date);
            for (int i = 1; i < list.Count; i++)
            {
                list[i].STT = i;
            }
            dgvdschokham.DataSource = list;
            dgvdschokham.Columns[0].HeaderText = "STT"; dgvdschokham.Columns[0].Width = 30;
            dgvdschokham.Columns[1].HeaderText = "Mã phiếu"; dgvdschokham.Columns[1].Width = 40;
            dgvdschokham.Columns[2].HeaderText = "Tên bệnh nhân"; dgvdschokham.Columns[2].Width = 110;
            dgvdschokham.Columns[3].HeaderText = "Ngày khám"; dgvdschokham.Columns[3].Width = 75;
            dgvdschokham.RowHeadersVisible = false;


            //Load danh sách phiếu khám
            dgvdsphieukham.DataSource = libraryService.DanhSachPhieuKham(manv);
            dgvdsphieukham.Columns[0].HeaderText = "Mã phiếu"; dgvdsphieukham.Columns[0].Width = 40;
            dgvdsphieukham.Columns[1].HeaderText = "Tên bệnh nhân"; dgvdsphieukham.Columns[1].Width = 105;
            dgvdsphieukham.Columns[2].HeaderText = "Ngày khám"; dgvdsphieukham.Columns[2].Width = 70;
            dgvdsphieukham.Columns[3].HeaderText = "Đã Khám"; dgvdsphieukham.Columns[3].Width = 40;
            dgvdsphieukham.RowHeadersVisible = false;
        }

        private void dgvdschokham_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvdschokham.SelectedRows)
            {
                int maphieu = (int)row.Cells[1].Value;
                txttenbenhnhan.Text = row.Cells[2].Value.ToString();
                PhieuKham_BenhNhanLamSang pk = libraryService.ThongTinPhieuKham(maphieu); ;
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
                dgvdonthuoc.Columns[1].HeaderText = "Mã đơn thuốc"; dgvdonthuoc.Columns[1].Width = 85;
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
                if (listlskham.Count > 0)
                {
                    dgvlichsukham.Rows[0].Selected = false;
                }


            }
        }

        private void dgvdsphieukham_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvdsphieukham.SelectedRows)
            {
                //đổ dữ liệu lên thông tin phiếu khám + panel lâm sàng
                int maphieu = (int)row.Cells[0].Value;
                txttenbenhnhan.Text = row.Cells[1].Value.ToString();
                PhieuKham_BenhNhanLamSang pk = libraryService.ThongTinPhieuKham(maphieu);
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
                dgvdonthuoc.Columns[1].HeaderText = "Mã đơn thuốc"; dgvdonthuoc.Columns[1].Width = 85;
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
                dgvlichsukham.DataSource = listlskham;
                dgvlichsukham.Columns[0].HeaderText = "STT"; dgvlichsukham.Columns[0].Width = 40;
                dgvlichsukham.Columns[1].HeaderText = "Mã phiếu"; dgvlichsukham.Columns[1].Width = 85;
                dgvlichsukham.Columns[2].HeaderText = "Ngày khám"; dgvlichsukham.Columns[2].Width = 115;
                dgvlichsukham.Columns[2].HeaderText = "Chuẩn đoán"; dgvlichsukham.Columns[3].Width = 250;
                dgvlichsukham.Columns[2].HeaderText = "Kết quả"; dgvlichsukham.Columns[4].Width = 265;
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
            PhieuKham_BenhNhanLamSang pkbn = new PhieuKham_BenhNhanLamSang(int.Parse(txtmaphieukham.Text), int.Parse(txtmabenhnhan.Text),0,txtchandoan.Text,0,txtnhiptim.Text,txtnhietdo.Text,txthuyetap.Text,txtcannang.Text,txtchieucao.Text,txtmaicd.Text, DateTime.Parse(txtngaykham.Text),null,null,txtketluan.Text,txttiensukham.Text);
            if (libraryService.LuuPhieuKham(pkbn) !=0)
            {
                MessageBox.Show("Lưu phiếu khám thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lưu phiếu khám không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Lưu đơn thuốc
            if(TaoDonThuoc(dt)!=0)
            {
                if(DanhSachDonThuoc()==null)
                {
                }
                else
                foreach (ChiTietDonThuoc i in DanhSachDonThuoc())
                {
                    libraryService.TaoChiTietDonThuoc(i,dt.MAPHIEUKHAM);
                }
            }
            else
            {
                MessageBox.Show("Lưu đơn thuốc không thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Hàm add thuốc trong bảng đơn thuốc vào danh sách chitietdonthuoc
        /// </summary>
        /// <returns></returns>
        private List<ChiTietDonThuoc> DanhSachDonThuoc()
        {
            List<ChiTietDonThuoc> listdt = new List<ChiTietDonThuoc>();
            for(int i=0;i<dgvdonthuoc.RowCount;i++)
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

        }

        private void btnxacnhanxetnghiem_Click(object sender, EventArgs e)
        {
            string getmacls = cbxetnghiem.SelectedValue.ToString();
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

        private void dgvlichsukham_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvlichsukham.SelectedRows)
            {
                //đổ dữ liệu lên thông tin phiếu khám + panel lâm sàng
                int maphieu = (int)row.Cells[1].Value;               
                PhieuKham_BenhNhanLamSang pk = libraryService.ThongTinPhieuKham(maphieu);
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
                dgvdonthuoc.Columns[1].HeaderText = "Mã đơn thuốc"; dgvdonthuoc.Columns[1].Width = 85;
                dgvdonthuoc.Columns[2].HeaderText = "Tên thuốc"; dgvdonthuoc.Columns[2].Width = 200;
                dgvdonthuoc.Columns[2].HeaderText = "Số lượng"; dgvdonthuoc.Columns[3].Width = 95;
                dgvdonthuoc.Columns[2].HeaderText = "Hướng dẫn"; dgvdonthuoc.Columns[4].Width = 230;
                dgvdonthuoc.RowHeadersVisible = false;        
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
                listdonthuoc = libraryService.DanhSachChiTietDonThuoc(f.maphieu);
                for (int i = 1; i < listdonthuoc.Count; i++)
                {
                    listdonthuoc[i].STT = i;
                }
                dgvdonthuoc.DataSource = listdonthuoc;
                dgvdonthuoc.Columns[0].HeaderText = "STT"; dgvdonthuoc.Columns[0].Width = 40;
                dgvdonthuoc.Columns[1].HeaderText = "Mã phiếu"; dgvdonthuoc.Columns[1].Width = 85;
                dgvdonthuoc.Columns[2].HeaderText = "Tên thuốc"; dgvdonthuoc.Columns[2].Width = 200;
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

    }
}

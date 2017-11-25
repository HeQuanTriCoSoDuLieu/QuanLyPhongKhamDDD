using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongKham.Infrastructure;
using QuanLyPhongKham.Services;
using QuanLyPhongKham.Model.DTO;

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
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void testevent(object sender, TreeNodeMouseClickEventArgs e)
        {
           
        }

        private void treeviewdichvukham(object sender, TreeViewEventArgs e)
        {
            switch (treeviewdvkham.SelectedNode.Name)
            {
                case "nodexquang" : showxquanh(); break;
                case "nodesieuam": showsieuam(); break;
                case "nodelamsang": showlamsang(); break;
                case "nodexetnghiem": showxetnghiem(); break;
                case "nodenoisoi": shownoisoi(); break;
                case "nodedonthuoc": showdonthuoc(); break;

            }
        }

        private void showdonthuoc()
        {
            paneldonthuoc.Visible = true;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = false;
            panelsieuam.Visible = false;
            panellamsang.Visible = false;
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
        }

        private void showxetnghiem()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = true;
            panelxquang.Visible = false;
            panelsieuam.Visible = false;
            panellamsang.Visible = false;
        }

        private void showxquanh()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = true;
            panelsieuam.Visible = false;
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
        }
        private void showlamsang()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = false;
            panelsieuam.Visible = false;
            panellamsang.Visible = true;
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
    }
}

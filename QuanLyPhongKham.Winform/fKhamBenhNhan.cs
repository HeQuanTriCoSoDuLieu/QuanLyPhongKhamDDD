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
        public fKhamBenhNhan()
        {
            InitializeComponent();
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
        }
        private void showsieuam()
        {
            paneldonthuoc.Visible = false;
            panelnoisoi.Visible = false;
            panelxetnghiem.Visible = false;
            panelxquang.Visible = false;
            panelsieuam.Visible = true;
            panellamsang.Visible = false;
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
    }
}

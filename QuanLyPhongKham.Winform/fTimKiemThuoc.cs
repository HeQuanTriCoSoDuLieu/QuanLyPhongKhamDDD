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
    public partial class fTimKiemThuoc : Form
    {
        public fTimKiemThuoc()
        {
            InitializeComponent();
        }
        public int masadsad()
        {
            return int.Parse(txttimkiem.Text);
        }
    }
}

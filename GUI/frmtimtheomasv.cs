using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuongVanHung_2121110123.GUI
{
    public partial class frmtimtheomasv : Form
    {
        public frmtimtheomasv()
        {
            InitializeComponent();
        }
        int dem = 0;
        private void frmtimtheomasv_Load(object sender, EventArgs e)
        {

        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {
            BAL.SVBAL.timSV_Ma(txtMaSV.Text);
            dgvKetQua.DataSource = BAL.SVBAL.timSV_Ma(txtMaSV.Text);

            dem = dgvKetQua.RowCount - 1;
            label3.Text = "Tổng Số: " + dem.ToString();
        }
    }
}

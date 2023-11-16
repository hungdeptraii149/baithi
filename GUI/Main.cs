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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
     



        //private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmSV f = new frmSV();
        //    f.Show();
        //}


        //private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmkhoa f = new frmkhoa();
        //    f.Show();
        //}

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult rs;

            rs = MessageBox.Show("Bạn chắc chắn muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }

        }

        //private void tìmKiếmTheoMãSVToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmtimtheomasv f = new frmtimtheomasv();
        //    f.Show();
        //}

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private void quảnLýLớpToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmlop f = new frmlop();
        //    f.Show();
        //}

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýMônToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmMon f = new frmMon();
            f.Show();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSV f = new frmSV();
            f.Show();
        }

        private void quảnLýLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlop f = new frmlop();
            f.Show();
        }

        private void tìmKiếmTheoMãSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtimtheomasv f = new frmtimtheomasv();
            f.Show();
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult rs;

            rs = MessageBox.Show("Bạn chắc chắn muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmkhoa f = new frmkhoa();
            f.Show();
        }

        private void tìmKiếmTheoTênSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtimtheotensv f = new frmtimtheotensv();
            f.Show();
        }

       
    }
}

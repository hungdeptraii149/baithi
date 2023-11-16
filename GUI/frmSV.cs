using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuongVanHung_2121110123.GUI
{
    public partial class frmSV : Form
    {
        public frmSV()
        {
            InitializeComponent();
        }
        int dem = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSV.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Quản lý sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int gt = 1;
                    if (radNam.Checked == true)
                    {
                        gt = 1;
                    }
                    else
                    {
                        gt = 0;
                    }
                    BAL.SVBAL.Nhap_SV(txtMaSV.Text, BAL.xulichuoi.VietHoa(txtHoSV.Text), BAL.xulichuoi.VietHoa(txtTenSV.Text), gt, dtpNgaySinh.Text, cmbMaLop.SelectedValue.ToString(), cbbKhoa.SelectedValue.ToString());
                    dgvSinhVien1.DataSource = Data.DS_SINHVIEN();
                    MessageBox.Show("Thêm thành công", "Quản lý sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dem = dgvSinhVien1.RowCount;
                    label3.Text = "Tổng Số SV : " + dem.ToString();
                }

            }
            catch
            {
                MessageBox.Show("Thêm thất bại", "Quản lý sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmSV_Load(object sender, EventArgs e)
        {
            dgvSinhVien1.DataSource = Data.DS_SINHVIEN();
            dem = dgvSinhVien1.RowCount;
            label3.Text = "Tổng Số SV : " + dem.ToString();

            cmbMaLop.DataSource = Data.DS_LOP();
            cmbMaLop.DisplayMember = "MaLop";
            cmbMaLop.ValueMember = "MaLop";

            cbbKhoa.DataSource = Data.DS_KHOA();
            cbbKhoa.DisplayMember = "MaKhoa";
            cbbKhoa.ValueMember = "MaKhoa";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSV.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên để sửa thông tin.", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int gt = radNam.Checked ? 1 : 0;

                    if (cmbMaLop.SelectedItem != null && cbbKhoa.SelectedItem != null)
                    {
                        BAL.SVBAL.Sua_SV(
                             txtMaSV.Text,
                             BAL.xulichuoi.VietHoa(txtHoSV.Text),
                             BAL.xulichuoi.VietHoa(txtTenSV.Text),
                             gt,
                             dtpNgaySinh.Text,
                             cmbMaLop.SelectedValue.ToString(),
                             cbbKhoa.SelectedValue.ToString()
                         );
                    }
                    else
                    {
                        // Display a message or handle the situation where one of the ComboBoxes does not have a selected value.
                    }

                    dgvSinhVien1.DataSource = Data.DS_SINHVIEN();
                    MessageBox.Show("Cập nhật thông tin thành công.", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại", "Quản lý sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSV.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        BAL.SVBAL.Xoa_SV(txtMaSV.Text);
                        dgvSinhVien1.DataSource = Data.DS_SINHVIEN();
                        MessageBox.Show("Xóa sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi.", "Quản lý sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        int row;
        private void dgvSinhVien1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSinhVien1.Rows.Count)
            {
                row = e.RowIndex;

                if (dgvSinhVien1.Rows[row].Cells[4].Value != null)
                {
                    if (dgvSinhVien1.Rows[row].Cells[4].Value.ToString() == "Nam")
                    {
                        radNam.Checked = true;
                    }
                    else
                    {
                        radNu.Checked = true;
                    }
                }

                txtMaSV.Text = dgvSinhVien1.Rows[row].Cells[1].Value.ToString();
                txtHoSV.Text = dgvSinhVien1.Rows[row].Cells[2].Value.ToString();
                txtTenSV.Text = dgvSinhVien1.Rows[row].Cells[3].Value.ToString();

                if (dgvSinhVien1.Rows[row].Cells[5].Value != null)
                {
                    dtpNgaySinh.Text = dgvSinhVien1.Rows[row].Cells[5].Value.ToString();
                }

                if (dgvSinhVien1.Rows[row].Cells[6].Value != null)
                {
                    cmbMaLop.Text = dgvSinhVien1.Rows[row].Cells[6].Value.ToString();
                }

                if (dgvSinhVien1.Rows[row].Cells[7].Value != null)
                {
                    cbbKhoa.Text = dgvSinhVien1.Rows[row].Cells[7].Value.ToString();
                }
            }
        }

        private void dgvSinhVien1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

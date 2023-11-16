using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LuongVanHung_2121110123.BAL;
using LuongVanHung_2121110123;

namespace LuongVanHung_2121110123.GUI
{
    public partial class frmMon : Form
    {
        private bool allowMaMHSua = true;
        int row;
        int dem = 0;
        public frmMon()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtMaMH.Text) || string.IsNullOrWhiteSpace(txtTenMH.Text) || cbbGiaoVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin môn học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MonBAL.Them(txtMaMH.Text, BAL.xulichuoi.VietHoa(txtTenMH.Text), cbbGiaoVien.SelectedValue.ToString());
                dgvMonHoc.DataSource = Data.DS_MONHOC();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dem = dgvMonHoc.RowCount - 1;//đếm số lượng
                label5.Text = "Tổng số môn: " + dem.ToString();

            }
            catch
            {
                MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaMH.Text == "")
                {
                    MessageBox.Show("Chọn hàng cần sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!allowMaMHSua)
                    {
                        MessageBox.Show("Không được phép sửa mã môn học", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tiếp tục với việc sửa dữ liệu
                    MonBAL.Sua(txtMaMH.Text, BAL.xulichuoi.VietHoa(txtTenMH.Text), cbbGiaoVien.SelectedValue.ToString());
                    dgvMonHoc.DataSource = Data.DS_MONHOC();

                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult rs;
            if (txtMaMH.Text == "")
            {
                MessageBox.Show("Vui lòng chọn hàng cần xóa", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                rs = MessageBox.Show("Bạn chắc chắn muốn xóa", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == System.Windows.Forms.DialogResult.Yes)
                {
                    //hàm xóa dữ liệu
                    MonBAL.Xoa(txtMaMH.Text);
                    dgvMonHoc.DataSource = Data.DS_MONHOC();//hiện lên gridview
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void frmMon_Load(object sender, EventArgs e)
        {
            dgvMonHoc.DataSource = Data.DS_MONHOC();//chọn ngồn dữ liệu
            dem = dgvMonHoc.RowCount - 1;//đếm số lượng

            cbbGiaoVien.DataSource = Data.DS_GIANGVIEN();
            cbbGiaoVien.DisplayMember = "TenGV";//hiển thị cột tương ứng
            cbbGiaoVien.ValueMember = "MaGV";
            dem = dgvMonHoc.RowCount - 1;//đếm số lượng
            label5.Text = "Tổng số môn: " + dem.ToString();
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMonHoc.Rows.Count)
            {
                row = e.RowIndex;
                txtMaMH.Text = dgvMonHoc.Rows[row].Cells[0].Value.ToString();
                txtTenMH.Text = dgvMonHoc.Rows[row].Cells[1].Value.ToString();
            }
        }

        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMonHoc.Rows.Count)
            {
                row = e.RowIndex;
                txtMaMH.Text = dgvMonHoc.Rows[row].Cells[0].Value.ToString();
                txtTenMH.Text = dgvMonHoc.Rows[row].Cells[1].Value.ToString();
            }
        }
    }
}

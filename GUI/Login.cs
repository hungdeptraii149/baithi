using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LuongVanHung_2121110123.DAL;
using LuongVanHung_2121110123.Model;

namespace LuongVanHung_2121110123.GUI
{
    public partial class Login : Form
    {
        private int invalidLoginAttempts = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = tbName.Text;
            string password = tbPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin đăng nhập!");
                return; // Dừng thực hiện nếu thông tin không đủ
            }

            LoginBEL user = new LoginBEL
            {
                TaiKhoan = username,
                Matkhau = password
            };

            LoginDAL loginDAL = new LoginDAL(); // Create an instance of LoginDAL

            bool isValid = loginDAL.ValidateUser(user); // Call ValidateUser on the instance

            if (isValid)
            {
                MessageBox.Show("Đăng nhập thành công!");

                Main form1 = new Main();
                form1.Show();

                // Close the current login form
                this.Hide(); // Thực hiện hành động sau khi đăng nhập thành công, ví dụ: Mở form chính, v.v.
            }
            else
            {
                invalidLoginAttempts++; // Tăng số lần nhập sai

                if (invalidLoginAttempts >= 3)
                {
                    MessageBox.Show("Bạn đã nhập sai mật khẩu 3 lần. Ứng dụng sẽ thoát!");
                    Application.Exit(); // Thoát khỏi ứng dụng
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult S = MessageBox.Show("Bạn có chắc muốn thoát  không", "Thông báo", MessageBoxButtons.OKCancel);
            if (S == DialogResult.OK)
                Application.Exit();
        }
    }
}

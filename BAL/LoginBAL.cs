using LuongVanHung_2121110123.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuongVanHung_2121110123.BAL
{
    public class LoginBAL
    {
        private LoginDAL LoginDAL;
        public string ConnectionString { get; set; }

        public LoginBAL()
        {
            LoginDAL = new LoginDAL();
        }


    }
}

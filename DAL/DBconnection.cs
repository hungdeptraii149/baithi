using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace LuongVanHung_2121110123.DAL
{
    public class DBconnection
    {
        public static string strcon = @"Data Source=HUNG2003;Initial Catalog=QLSV;Integrated Security=True";
        SqlConnection con = new SqlConnection(strcon);
    }
}

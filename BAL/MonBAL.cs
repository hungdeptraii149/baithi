﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LuongVanHung_2121110123.DAL;

namespace LuongVanHung_2121110123.BAL
{
    public static class MonBAL
    {
        public static void Them(string mamh, string tenmh, string giaovien)
        {
            string strchuyentu = "";
            string[] laytu = tenmh.Split(' ');
            string kitudau = "";
            for (int i = 0; i < laytu.Length; i++)
            {
                kitudau = laytu[i].Substring(0, 1);
                strchuyentu += kitudau.ToUpper() + laytu[i].Remove(0, 1) + " ";
            }


            SqlConnection con = new SqlConnection(DBconnection.strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into MONHOC values('" + mamh + "',N'" + strchuyentu + "','" + giaovien + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void Sua(string mamh, string tenmh, string giaovien)
        {
            SqlConnection con = new SqlConnection(DBconnection.strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("update MONHOC set TenMH=N'" + tenmh + "',MaGV='" + giaovien + "' where MaMH = '" + mamh + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void Xoa(string mamh)
        {
            SqlConnection con = new SqlConnection(DBconnection.strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from MONHOC where MaMH = '" + mamh + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

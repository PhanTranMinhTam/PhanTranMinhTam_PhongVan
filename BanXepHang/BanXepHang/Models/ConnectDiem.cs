using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace BanXepHang.Models
{
    public class ConnectDiem
    {
        public List<Diem> getDataDiem()
        {
            List<Diem> lst = new List<Diem>();
            string conStr = @"Data Source=DESKTOP-SNLG86J\SQLEXPRESS;Initial Catalog=QLCake;Integrated Security=True";
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = conStr;
                string sql = "Select * From DIEM";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var diem = new Diem();
                    diem.MANGUOIDUNG = row["Manguoichoi"].ToString();
                    diem.DIEM = row["diem"].ToString();
                    diem.THANG = row["thang"].ToString();
                    lst.Add(diem);
                }
            }
            return lst;
        }
    }
}
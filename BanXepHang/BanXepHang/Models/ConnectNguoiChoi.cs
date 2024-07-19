using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
namespace BanXepHang.Models
{
    public class ConnectNguoiChoi
    {
        List<Nguoichoi> lst = new List<Nguoichoi>();
        List<Diem> lstdiem = new List<Diem>();
        string conStr = @"Data Source=DESKTOP-SNLG86J\SQLEXPRESS;Initial Catalog=QL_XepHang;Integrated Security=True";
        public List<Nguoichoi> getData()
        {

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = conStr;
                string sql = "SELECT * FROM NGUOICHOI";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var nguoichoi = new Nguoichoi();
                    nguoichoi.manguoichoi = row["Manguoichoi"].ToString();
                    nguoichoi.tennguoichoi = row["Name"].ToString();
                    lst.Add(nguoichoi);
                }
            }
            return lst;

        }
    }
}
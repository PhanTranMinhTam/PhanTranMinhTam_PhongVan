using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanXepHang.Models;
using PagedList;


namespace BanXepHang.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhSachNguoiChoi(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ManguoichoiSortParm = String.IsNullOrEmpty(sortOrder) ? "manguoichoi_desc" : "";

            int pageSize = 10; // Số lượng sản phẩm trên mỗi trang
            int pageNumber = (page ?? 1);
            List<Nguoichoi> listNguoiChoi = new List<Nguoichoi>();

            using (SqlConnection conn = new SqlConnection())
            {
                // Your connection string
                string conStr = @"Data Source=DESKTOP-SNLG86J\SQLEXPRESS; Initial Catalog=QL_XepHang; Integrated Security=true;";
                conn.ConnectionString = conStr;
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM NGUOICHOI";

                // Handle sorting options
                switch (sortOrder)
                {
                    case "manguoichoi_asc":
                        sql += " ORDER BY manguoichoi ASC";
                        ViewBag.ManguoichoiSortParm = "manguoichoi_desc"; // Invert the sort order for the next click
                        break;
                    case "manguoichoi_desc":
                        sql += " ORDER BY manguoichoi DESC";
                        ViewBag.ManguoichoiSortParm = "manguoichoi_asc"; // Invert the sort order for the next click
                        break;
                    default:
                        sql += " ORDER BY manguoichoi ASC"; // Default sorting
                        ViewBag.ManguoichoiSortParm = "manguoichoi_desc";
                        break;
                }

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    Nguoichoi emp = new Nguoichoi();
                    emp.manguoichoi = dr["manguoichoi"].ToString();
                    emp.tennguoichoi = dr["name"].ToString();
                    listNguoiChoi.Add(emp);
                }
            }

            IPagedList<Nguoichoi> pagedList = listNguoiChoi.ToPagedList(pageNumber, pageSize);
            return View(pagedList);
        }

    }
}
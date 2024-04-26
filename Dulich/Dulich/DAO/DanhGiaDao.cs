using Dulich.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dulich.DAO
{
    public class DanhGiaDao
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        Dbconnection db = new Dbconnection();

        public void Them(DanhGia danhgia)
        {
            string sqlStr = string.Format("INSERT INTO Booking(KhachSanID ,KhachHangID,NoiDung,Diem) VALUES ('{0}', '{1}', '{2}', '{3}')",
                                            danhgia.KhachSanId, danhgia.KhachHangId,danhgia.NoiDung,danhgia.Diem);
            db.ExecuteSqlCommand(sqlStr);
        }
        public DataTable HienThiDanhSach()
        {
            DataTable dt = new DataTable();
            try
            {

                conn.Open();

                // Sử dụng tham số để truyền tên bảng vào câu SQL
                string sqlStr = $"SELECT * FROM ";

                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                adapter.Fill(dt);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            return dt;
        }

    }
}

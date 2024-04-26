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
    public class BookingDao
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        Dbconnection db = new Dbconnection();
        
        public void Them(Booking booking)
        {
            string sqlStr = string.Format("INSERT INTO Booking(TenPhong ,TenKhachSan,NgayDat,NgayTra,TenNguoiDung) VALUES ('{0}', '{1}', '{2}', '{3}','{4}')",
                                            booking.PhongID,booking.KhachHangID,booking.NgayDat,booking.NgayTra,booking.KhachSanID);
            db.ExecuteSqlCommand(sqlStr);
        }

        public void Xoa(int id)
        {
            string sqlStr = string.Format("DELETE FROM Booking WHERE BookingID = '{0}'", id);
            db.ExecuteSqlCommand(sqlStr);
        }

        public DataTable HienThiDanhSach(int khachhangid)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();

                // Sử dụng tham số để truyền tên bảng vào câu SQL
                string sqlStr = @"SELECT b.[NgayDat], b.[NgayTra], p.[AnhPhong], ks.[TenKhachSan], ks.[DiaChi], p.[TenPhong], p.[Gia]
                            FROM [DuLich].[dbo].[Booking] b
                            INNER JOIN [DuLich].[dbo].[KhachSan] ks ON b.[KhachSanID] = ks.[KhachSanID]
                            INNER JOIN [DuLich].[dbo].[Phong] p ON b.[PhongID] = p.[PhongID]
                            WHERE b.[KhachHangID] = @KhachHangID";

                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@KhachHangID", khachhangide);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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

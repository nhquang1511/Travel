using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows;
using Dulich.Models;

namespace Dulich.DAO
{
    internal class PhongDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        Dbconnection db = new Dbconnection();
        public DataTable HienThiDanhSach(int idkhachsan)
        {
            DataTable dt = new DataTable();
            try
            {

                conn.Open();

                // Sử dụng tham số để truyền tên bảng vào câu SQL
                string sqlStr = $"SELECT * FROM Phong where KhachSanID = {idkhachsan}";

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
        public void Them(Phong phong)
        {
            string sqlStr = string.Format("INSERT INTO Phong(PhongID, TenPhong, KhachSanID, TenLoaiPhong, TrangThai) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                                            phong.PhongID, phong.TenPhong, phong.KhachSanID, phong.TenLoaiPhong, phong.KhachSanID, phong.TrangThai);
            db.ExecuteSqlCommand(sqlStr);
        }

        public void Xoa(int id)
        {
            string sqlStr = string.Format("DELETE FROM Phong WHERE PhongID = '{0}'", id);
            db.ExecuteSqlCommand(sqlStr);
        }

        public void SuaThongTin(Phong phong)
        {
            string sqlStr = string.Format("UPDATE Phong SET PhongID = '{0}', TenPhong= '{1}', TenLoaiPhong = '{2}', TrangThai = '{3}' WHERE PhongID = '{4}'",
                                          phong.PhongID, phong.TenPhong, phong.TenLoaiPhong, phong.TrangThai, phong.PhongID);
            db.ExecuteSqlCommand(sqlStr);
        }
        public void Datphong(int id)
        {
            string sqlStr = string.Format("UPDATE Phong SET TrangThai = 1 WHERE PhongID = '{0}'", id);
            db.ExecuteSqlCommand(sqlStr);
        }

    }
}
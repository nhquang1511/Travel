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

    public class KhachSanDao
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        Dbconnection db = new Dbconnection();
        public DataTable HienThiDanhSach(int idchukhachsan)
        {
            return db.HienThiDanhSach("KhachSan");
        }
        public void Them(KhachSan khachsan)
        {
            string sqlStr = string.Format("INSERT INTO KhachSan(KhachSanID ,TenKhachSan,DiaChi,LoaiKhachSan,Anh,MoTa) VALUES ('{0}', '{1}', '{2}', '{3}','{4}','{5}')",
                                            khachsan.KhachSanID,khachsan.TenKhachSan,khachsan.DiaChi,khachsan.LoaiKhachSan, khachsan.Anh,khachsan.MoTa);
            db.ExecuteSqlCommand(sqlStr);
        }

        public void Xoa(int id)
        {
            string sqlStr = string.Format("DELETE FROM KhachSan WHERE KhachSanID = '{0}'", id);
            db.ExecuteSqlCommand(sqlStr);
        }

        public void SuaThongTin(KhachSan khachsan)
        {
            string sqlStr = string.Format("UPDATE KhachSan SET KhachSanID = '{0}', TenKhachSan = '{1}', DiaChi = '{2}', LoaiKhachSan = '{3}',Anh = '{4}',MoTA='{5}' WHERE KhachSanID = '{6}'",
                                          khachsan.KhachSanID, khachsan.TenKhachSan, khachsan.DiaChi, khachsan.LoaiKhachSan,khachsan.Anh,khachsan.MoTa,khachsan.KhachSanID);
            db.ExecuteSqlCommand(sqlStr);
        }
        public DataTable TimKiem(string loaiphong,string loaikhachsan,string diachi)
        {
            DataTable dt = new DataTable();
            try
            {

                conn.Open();

                // Sử dụng tham số để truyền tên bảng vào câu SQL
                string sqlStr = $"SELECT KS.KhachSanID,KS.TenKhachSan, KS.DiaChi, KS.LoaiKhachSan FROM Phong P JOIN KhachSan KS ON P.KhachSanID = KS.KhachSanID WHERE P.TenLoaiPhong = N'{loaiphong}' AND KS.LoaiKhachSan = '{loaikhachsan}' AND KS.DiaChi = N'{diachi}'";

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

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
        public DataTable HienThiDanhSach(int idphong)
        {
            return db.HienThiDanhSach("Phong");
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
    }
}
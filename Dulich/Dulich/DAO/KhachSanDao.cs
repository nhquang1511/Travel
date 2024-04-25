﻿using System;
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
        public DataTable TimKiem(string loaiphong, string loaikhachsan, string diachi)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();

                // Xây dựng câu truy vấn với điều kiện OR để áp dụng bất kỳ thông tin nào được cung cấp
                string sqlStr = "SELECT KS.Anh, KS.KhachSanID, KS.TenKhachSan, KS.DiaChi, KS.LoaiKhachSan, KS.Gia " +
                                "FROM Phong P JOIN KhachSan KS ON P.KhachSanID = KS.KhachSanID WHERE 1=1";

                bool hasCriteria = false;

                if (!string.IsNullOrEmpty(loaiphong))
                {
                    sqlStr += $" AND P.TenLoaiPhong = N'{loaiphong}'";
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(loaikhachsan))
                {
                    sqlStr += $" AND KS.LoaiKhachSan = '{loaikhachsan}'";
                    hasCriteria = true;
                }

                if (!string.IsNullOrEmpty(diachi))
                {
                    sqlStr += $" AND (KS.DiaChi LIKE '%' + '{diachi}' + '%')";
                    hasCriteria = true;
                }

                if (!hasCriteria)
                {
                    sqlStr = "SELECT * FROM KhachSan"; // Nếu không có tiêu chí nào, trả về toàn bộ
                }

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

        public DataTable ChiTietKhachSan(int idkhachsan)
        {
            DataTable dt = new DataTable();
            try
            {

                conn.Open();

                // Sử dụng tham số để truyền tên bảng vào câu SQL
                string sqlStr = $"SELECT * from KhachSan WHERE KhachSanID = {idkhachsan}";

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

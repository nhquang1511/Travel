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
            string sqlStr = string.Format("INSERT INTO KhachSan(KhachSanID ,TenKhachSan,DiaChi,LoaiKhachSan) VALUES ('{0}', '{1}', '{2}', '{3}')",
                                            khachsan.KhachSanID,khachsan.TenKhachSan,khachsan.DiaChi,khachsan.LoaiKhachSan);
            db.ExecuteSqlCommand(sqlStr);
        }

        public void Xoa(int id)
        {
            string sqlStr = string.Format("DELETE FROM KhachSan WHERE KhachSanID = '{0}'", id);
            db.ExecuteSqlCommand(sqlStr);
        }

        public void SuaThongTin(KhachSan khachsan)
        {
            string sqlStr = string.Format("UPDATE KhachSan SET KhachSanID = '{0}', TenKhachSan = '{1}', DiaChi = '{2}', LoaiKhachSan = '{3}' WHERE KhachSanID = '{4}'",
                                          khachsan.KhachSanID, khachsan.TenKhachSan, khachsan.DiaChi, khachsan.LoaiKhachSan,khachsan.KhachSanID);
            db.ExecuteSqlCommand(sqlStr);
        }
    }
   
}
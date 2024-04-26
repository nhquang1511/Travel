using Dulich.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.DAO
{
    public class BookingDao
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        Dbconnection db = new Dbconnection();
        
        public void Them(Booking booking)
        {
            string sqlStr = string.Format("INSERT INTO Booking(PhongID ,KhachHangID,NGayDat,NgayTra) VALUES ('{0}', '{1}', '{2}', '{3}')",
                                            booking.PhongID,booking.KhachHangID,booking.NgayDat,booking.NgayTra);
            db.ExecuteSqlCommand(sqlStr);
        }

        public void Xoa(int id)
        {
            string sqlStr = string.Format("DELETE FROM Booking WHERE BookingID = '{0}'", id);
            db.ExecuteSqlCommand(sqlStr);
        }


    }
}

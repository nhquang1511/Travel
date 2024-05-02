using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Traveloka
{
    public class Dbconnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public bool ExecuteSqlCommand(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteNonQuery() > 0;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi lệnh SQL thất bại: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable HienThiDanhSach(string tableName)
        {
            DataTable dt = new DataTable();
            try
            {

                conn.Open();

                // Sử dụng tham số để truyền tên bảng vào câu SQL
                string sqlStr = $"SELECT * FROM {tableName}";

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

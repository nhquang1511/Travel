using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using travel.Models;

namespace travel
{
    /// <summary>
    /// Interaction logic for quanlyphong.xaml
    /// </summary>
    public partial class quanlyphong : Window
    {
        public quanlyphong()
        {
            InitializeComponent();
            DataContext = GetDanhSachPhong();
        }
        public List<Phong> GetDanhSachPhong()
        {
            List<Phong> danhSachPhong = new List<Phong>();

            string connectionString = "Data Source=localhost;Initial Catalog=DuLich;Integrated Security=True;Encrypt=False";
            string query = "SELECT * FROM Phong";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Phong phong = new Phong(
                        Convert.ToInt32(reader["PhongID"]),
                        reader["TenPhong"].ToString(),
                        Convert.ToInt32(reader["KhachSanID"]),
                        reader["TenLoaiPhong"].ToString(),
                        reader["TrangThai"].ToString()
                        );
                        danhSachPhong.Add(phong);
                    }
                    reader.Close();
                }
            }

            return danhSachPhong;
        }
    }
}

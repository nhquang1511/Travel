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

namespace travel
{
    /// <summary>
    /// Interaction logic for addkhachsan.xaml
    /// </summary>
    public partial class addkhachsan : Window
    {
        public addkhachsan()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                // Lấy dữ liệu từ các điều khiển trên cửa sổ
                int id;
                if (!int.TryParse(txtID.Text, out id))
                {
                    MessageBox.Show("ID không hợp lệ!");
                    return;
                }

                string tenKhachSan = txtTenKhachSan.Text;
                string diaChi = txtDiaChi.Text;
                string loaiKhachSan = comboBoxLoaiKhachSan.Text;

                // Kiểm tra dữ liệu hợp lệ (có thể thêm các kiểm tra khác tùy vào yêu cầu của ứng dụng)

                // Thêm dữ liệu vào cơ sở dữ liệu
                string connectionString = "Data Source=localhost;Initial Catalog=DuLich;Integrated Security=True;Encrypt=False";
                string query = "INSERT INTO KhachSan (KhachSanID, TenKhachSan, DiaChi, LoaiKhachSan) VALUES (@KhachSanID, @TenKhachSan, @DiaChi, @LoaiKhachSan)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@KhachSanID", id);
                    command.Parameters.AddWithValue("@TenKhachSan", tenKhachSan);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@LoaiKhachSan", loaiKhachSan);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm khách sạn thành công!");
                            this.Close(); // Đóng cửa sổ sau khi thêm thành công
                        }
                        else
                        {
                            MessageBox.Show("Thêm khách sạn không thành công!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm khách sạn: " + ex.Message);
                    }
                }
           

        }
    }
}

using Microsoft.Win32;
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
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class test : Window
    {
        public test()
        {
            InitializeComponent();
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                imgPreview.Source = new BitmapImage(new Uri(imagePath));

                // Lưu đường dẫn tuyệt đối của ảnh vào cơ sở dữ liệu tại đây
                // Ví dụ:
                SaveImagePathToDatabase(imagePath);
            }
        }
        private void SaveImagePathToDatabase(string imagePath)
        {
            // Kết nối đến cơ sở dữ liệu
            string connectionString = "Data Source=localhost;Initial Catalog=DuLich;Integrated Security=True;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối
                connection.Open();

                // Tạo câu lệnh SQL INSERT
                string insertQuery = "INSERT INTO HinhAnhKhachSan (HinhAnhKhachSanID,KhachSanID, DuongDan) VALUES (@HinhAnhKhachSanID ,@KhachSanID, @DuongDan)";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Thêm tham số cho câu lệnh
                    command.Parameters.AddWithValue("@HinhAnhKhachSanID", '3');
                    command.Parameters.AddWithValue("@KhachSanID", '3');
                    command.Parameters.AddWithValue("@DuongDan", imagePath);

                    // Thực thi truy vấn INSERT
                    command.ExecuteNonQuery();
                }

                // Đóng kết nối
                connection.Close();
            }
        }

    }
}

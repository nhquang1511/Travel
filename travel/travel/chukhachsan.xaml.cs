using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;

namespace travel
{
    public partial class chukhachsan : Window
    {
        public ObservableCollection<KhachSan> KhachSans { get; set; }
        public ObservableCollection<string> LoaiKhachSanList { get; set; }

        public chukhachsan()
        {
            InitializeComponent();
            KhachSans = new ObservableCollection<KhachSan>();
            LoaiKhachSanList = new ObservableCollection<string>(); // Khởi tạo danh sách loại khách sạn
            LoadData();
            DataContext = this;
        }

        // Triển khai phương thức InitializeComponent để tránh ngoại lệ
        private void LoadData()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=DuLich;Integrated Security=True;Encrypt=False";
            string query = "SELECT KhachSanID, TenKhachSan, DiaChi, LoaiKhachSan FROM KhachSan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        KhachSans.Add(new KhachSan
                        {
                            KhachSanID = reader.GetInt32(0),
                            TenKhachSan = reader.GetString(1),
                            DiaChi = reader.GetString(2),
                            LoaiKhachSan = reader.GetString(3)
                        });

                        // Thêm loại khách sạn vào danh sách nếu chưa tồn tại
                      
                    }

                    reader.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addkhachsan newWindow = new addkhachsan();

            // Mở cửa sổ mới
            newWindow.Show();
        }
    }
}

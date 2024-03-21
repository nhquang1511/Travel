using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace travel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Tạo danh sách các phòng còn trống (dữ liệu mẫu)
            List<Room> availableRooms = new List<Room>
        {
            new Room { RoomNumber = "101", RoomType = "Standard", Price = 50 ,image ="image/OIP.jpg"},
            new Room { RoomNumber = "102", RoomType = "Standard", Price = 50,image ="image/OIP.jpg" },
            new Room { RoomNumber = "103", RoomType = "Deluxe", Price = 100 ,image ="image/OIP.jpg"},
            new Room { RoomNumber = "104", RoomType = "Suite", Price = 150 ,image ="image/OIP.jpg"}
            // Thêm các phòng khác tại đây nếu cần
        };

            // Gán danh sách phòng còn trống vào ItemsSource của ListBox
            roomListBox.ItemsSource = availableRooms;
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            detail detailWindow = new detail();

            detailWindow.Show();
        }
    }


}
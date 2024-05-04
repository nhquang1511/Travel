using System;
using System.Collections.Generic;
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
using Traveloka.Models;
using Traveloka.ViewModel;

namespace Traveloka.views.user
{
    /// <summary>
    /// Interaction logic for TrangChu.xaml
    /// </summary>
    public partial class TrangChu : Window
    {
        public TrangChu()
        {
            InitializeComponent();
            DataContext = new KhachSanModel();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //    // Lấy button mà được click
        //    Button button = sender as Button;

        //    // Tìm đến đối tượng KhachSan được chọn từ Button's DataContext
        //    KhachSan selectedKhachSan = button.DataContext as KhachSan;

        //    // Kiểm tra xem có đối tượng được chọn không
        //    if (selectedKhachSan != null)
        //    {
        //        // Lấy idkhachsan từ đối tượng KhachSan được chọn
        //        int idkhachsan = selectedKhachSan.KhachSanId;

        //        // Tạo một thể hiện mới của form ChiTietKhachSan và chuyển idkhachsan qua constructor
        //        ChiTietKhachSan ctks = new ChiTietKhachSan(idkhachsan);

        //        // Hiển thị form ChiTietKhachSan
        //        ctks.Show();

        //        ;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Không thể lấy thông tin của khách sạn được chọn.");
        //    }

        //}

        
    }
}

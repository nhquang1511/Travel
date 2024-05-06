using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for ChiTietKhachSan.xaml
    /// </summary>
    public partial class ChiTietKhachSan : Window
    {

        private int idkhachsan;
        public ChiTietKhachSan()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DuLichEntities _context = new DuLichEntities();
            NhanXet nx = new NhanXet()
            {
                Diem = 5,
                NoiDung = "xin chao",
                UserId = 1,
                NgayNhanXet = DateTime.Now,
                KhachSanId = KhachSanHienTai.KhachSan.KhachSanId

            };
            _context.NhanXets.Add(nx);
            _context.SaveChanges();
            MessageBox.Show("them thanh cong");

        }
    }
}
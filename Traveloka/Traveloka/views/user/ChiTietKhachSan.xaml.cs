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
        public ChiTietKhachSan(int idkhachsan)
        {
            InitializeComponent();
            this.idkhachsan = idkhachsan;

            // Hiển thị idkhachsan trong một MessageBox

          
           
            // Gọi hàm loadData khi khởi tạo window

           
           
        }


    }
}
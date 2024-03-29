﻿using Dulich.DAO;
using Dulich.Models;
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

namespace Dulich.Views
{
    /// <summary>
    /// Interaction logic for TrangChuView.xaml
    /// </summary>
    public partial class TrangChuView : Window
    {
        public ObservableCollection<KhachSan> KhachSanList { get; set; }
        private KhachSanDao khachSanDao;
        public TrangChuView()
        {
            InitializeComponent();
            KhachSanList = new ObservableCollection<KhachSan>();
            khachSanDao = new KhachSanDao();
            // Gọi hàm loadData khi khởi tạo window
            loadData();
            DataContext = this;
        }
        public void loadData()
        {
            // Truyền id chủ khách sạn vào hàm HienThiDanhSach từ DAO
            int idChuKhachSan = 1; // Đây là id của chủ khách sạn, bạn có thể thay đổi theo cách thích của bạn
            // Gọi hàm HienThiDanhSach từ DAO để lấy DataTable
            var dataTable = khachSanDao.HienThiDanhSach(idChuKhachSan);
            // Duyệt qua từng dòng của DataTable và thêm vào ObservableCollection
            foreach (DataRow row in dataTable.Rows)
            {
                KhachSan khachSan = new KhachSan
                {
                    // Giả sử các cột trong DataTable tương ứng với các thuộc tính của đối tượng KhachSan
                    // Bạn cần chỉnh sửa phần này tùy thuộc vào cấu trúc của bảng KhachSan trong cơ sở dữ liệu
                    KhachSanID = Convert.ToInt32(row["KhachSanID"]),
                    TenKhachSan = row["TenKhachSan"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    LoaiKhachSan = row["LoaiKhachSan"].ToString(),
                    Anh = row["Anh"].ToString()
                    // Thêm các thuộc tính khác nếu cần
                };
                KhachSanList.Add(khachSan);
            }
            // Sau khi thêm dữ liệu vào ObservableCollection, gán ObservableCollection này vào ItemsSource của DataGrid

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string loaiPhong = ((ListBoxItem)listBox.SelectedItem).Content.ToString();
            string loaiKhachSan = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString();
            string diaChi = diachitxb.Text;

            // Gọi hàm TimKiem để tìm kiếm thông tin khách sạn
            DataTable dt = khachSanDao.TimKiem(loaiPhong, loaiKhachSan, diaChi);

            // Xóa dữ liệu hiện có trong ObservableCollection
            KhachSanList.Clear();

            // Duyệt qua từng dòng của DataTable và thêm vào ObservableCollection
            foreach (DataRow row in dt.Rows)
            {
                KhachSan khachSan = new KhachSan
                {
                    // Giả sử các cột trong DataTable tương ứng với các thuộc tính của đối tượng KhachSan
                    // Bạn cần chỉnh sửa phần này tùy thuộc vào cấu trúc của bảng KhachSan trong cơ sở dữ liệu
                    KhachSanID = Convert.ToInt32(row["KhachSanID"]),
                    TenKhachSan = row["TenKhachSan"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    LoaiKhachSan = row["LoaiKhachSan"].ToString()
                    // Thêm các thuộc tính khác nếu cần
                };
                KhachSanList.Add(khachSan);
            }
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            // Lấy button mà được click
            Button button = sender as Button;

            // Tìm đến đối tượng KhachSan được chọn từ Button's DataContext
            KhachSan selectedKhachSan = button.DataContext as KhachSan;

            // Kiểm tra xem có đối tượng được chọn không
            if (selectedKhachSan != null)
            {
                // Lấy idkhachsan từ đối tượng KhachSan được chọn
                int idkhachsan = selectedKhachSan.KhachSanID;

                // Tạo một thể hiện mới của form ChiTietKhachSan và chuyển idkhachsan qua constructor
                ChiTietKhachSan ctks = new ChiTietKhachSan(idkhachsan);

                // Hiển thị form ChiTietKhachSan
                ctks.Show();
            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin của khách sạn được chọn.");
            }
        }




    }
}


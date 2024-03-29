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
    /// Interaction logic for ChiTietKhachSan.xaml
    /// </summary>

    public partial class ChiTietKhachSan : Window
    {
        private int idkhachsan;
        KhachSanDao ksdao = new KhachSanDao();
        public ObservableCollection<Phong> PhongList { get; set; }
        private PhongDAO phongDao;
        public ChiTietKhachSan()
        {
            InitializeComponent();
           

        }
        public ChiTietKhachSan(int idkhachsan)
        {
            InitializeComponent();
            this.idkhachsan = idkhachsan;

            // Hiển thị idkhachsan trong một MessageBox
           
            loadData();
            PhongList = new ObservableCollection<Phong>();
            phongDao = new PhongDAO();
            // Gọi hàm loadData khi khởi tạo window
            
            loadData1();
            DataContext = this;

        }

        private void loadData()
        {
            DataTable dt = ksdao.ChiTietKhachSan(idkhachsan);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                // Hiển thị thông tin của khách sạn trong các thành phần của giao diện người dùng
                tenkhachsanlabel.Content = row["TenKhachSan"].ToString();
                diachilabel.Content = row["DiaChi"].ToString();
                string imagePath = row["Anh"].ToString();
                BitmapImage image = new BitmapImage(new Uri(imagePath));
                anhimage.Source = image;
                motalabel.Content = row["mota"].ToString();
            }

        }
        public void loadData1()
        {
            // Truyền id phòng vào hàm HienThiDanhSach từ DAO
            int idphong = 1; // Đây là id của phòng, bạn có thể thay đổi theo cách thích của bạn
            // Gọi hàm HienThiDanhSach từ DAO để lấy DataTable
            var dataTable = phongDao.HienThiDanhSach(idphong);
            // Duyệt qua từng dòng của DataTable và thêm vào ObservableCollection
            foreach (DataRow row in dataTable.Rows)
            {
                Phong phong = new Phong
                {
                    // Giả sử các cột trong DataTable tương ứng với các thuộc tính của đối tượng Phong
                    // Bạn cần chỉnh sửa phần này tùy thuộc vào cấu trúc của bảng Phong trong cơ sở dữ liệu
                    PhongID = Convert.ToInt32(row["PhongID"]),
                    TenPhong = row["TenPhong"].ToString(),
                    KhachSanID = Convert.ToInt32(row["KhachSanID"]),
                    TenLoaiPhong = row["TenLoaiPhong"].ToString(),
                    TrangThai = row["TrangThai"].ToString(),
                    Gia = Convert.ToSingle(row["Gia"])
                };
                PhongList.Add(phong);
            }
           
            // Sau khi thêm dữ liệu vào ObservableCollection, gán ObservableCollection này vào ItemsSource của DataGrid

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Chuyển đến TabItem thứ hai trong TabControl (ví dụ dựa trên index)
            myTabControl.SelectedIndex = 2;
        }
    }

}

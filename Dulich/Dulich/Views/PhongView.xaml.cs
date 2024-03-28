using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Dulich.DAO;
using Dulich.Models;

namespace Dulich.Views
{
    public partial class PhongView : Window
    {
        public ObservableCollection<Phong> PhongList { get; set; }
        private PhongDAO phongDao;
        public PhongView()
        {
            InitializeComponent();
            PhongList = new ObservableCollection<Phong>();
            phongDao = new PhongDAO();
            // Gọi hàm loadData khi khởi tạo window
            loadData();
            DataContext = this;
        }
        public void loadData()
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
                };
                PhongList.Add(phong);
            }
            // Sau khi thêm dữ liệu vào ObservableCollection, gán ObservableCollection này vào ItemsSource của DataGrid

        }
        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {
            // Tạo đối tượng Phong mới từ dữ liệu nhập vào các TextBox
            Phong newPhong = new Phong
            {
                PhongID = int.Parse(idPhongTextBox.Text),
                TenPhong = tenPhongTextBox.Text,
                KhachSanID = int.Parse(idKhachSanTextBox.Text),
                TenLoaiPhong = tenLoaiPhongTextBox.Text,
                TrangThai = trangThaiTextBox.Text
            };

            // Gọi phương thức Thêm từ đối tượng phongDao để thêm vào cơ sở dữ liệu
            phongDao.Them(newPhong);

            // Sau khi thêm vào cơ sở dữ liệu, cập nhật ObservableCollection và DataGrid
            PhongList.Add(newPhong);
        }

        private void XoaButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy đối tượng Phong hiện tại được chọn từ DataGrid
            Phong selectedPhong = myDataGrid.SelectedItem as Phong;
            if (selectedPhong != null)
            {
                // Gọi phương thức Xoa từ đối tượng phongDao để xóa khách sạn khỏi cơ sở dữ liệu
                phongDao.Xoa(selectedPhong.PhongID);

                // Sau khi xóa khỏi cơ sở dữ liệu, cập nhật ObservableCollection và DataGrid
                PhongList.Remove(selectedPhong);
            }
        }

        private void SuaButton_Click(object sender, RoutedEventArgs e)
        {

            // Lấy đối tượng Phong hiện tại được chọn từ DataGrid
            Phong selectedPhong = myDataGrid.SelectedItem as Phong;
            if (selectedPhong != null)
            {
                // Cập nhật thông tin của đối tượng KhachSan được chọn từ dữ liệu nhập từ các TextBox
                selectedPhong.PhongID = int.Parse(idPhongTextBox.Text);
                selectedPhong.TenPhong = tenPhongTextBox.Text;
                selectedPhong.KhachSanID = int.Parse(idKhachSanTextBox.Text);
                selectedPhong.TenLoaiPhong = tenLoaiPhongTextBox.Text;
                selectedPhong.TrangThai = trangThaiTextBox.Text;

                // Gọi phương thức SuaThongTin từ đối tượng phongDao để cập nhật thông tin vào cơ sở dữ liệu
                phongDao.SuaThongTin(selectedPhong);

                // Sau khi cập nhật vào cơ sở dữ liệu, cập nhật ObservableCollection và DataGrid
                // Không cần phải thực hiện bất kỳ thao tác nào, vì đối tượng Phong được thay đổi trực tiếp trong ObservableCollection
                PhongList.Clear(); // Xóa hết dữ liệu cũ
                loadData(); // Tải lại dữ liệu mới
            }
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lấy đối tượng Phong hiện tại được chọn từ DataGrid
            Phong selectedPhong = myDataGrid.SelectedItem as Phong;
            if (selectedPhong != null)
            {
                // Hiển thị thông tin của đối tượng được chọn trong các TextBox
                idPhongTextBox.Text = selectedPhong.PhongID.ToString();
                tenPhongTextBox.Text = selectedPhong.TenPhong;
                idKhachSanTextBox.Text = selectedPhong.KhachSanID.ToString();
                tenLoaiPhongTextBox.Text = selectedPhong.TenLoaiPhong;
                trangThaiTextBox.Text = selectedPhong.TrangThai;
            }
        }
    }
}
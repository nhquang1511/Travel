using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Dulich.DAO;
using Dulich.Models;

namespace Dulich.Views
{
    public partial class KhachSanView : Window
    {
        public ObservableCollection<KhachSan> KhachSanList { get; set; }
        private KhachSanDao khachSanDao;

        public KhachSanView()
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
                    LoaiKhachSan = row["LoaiKhachSan"].ToString()
                    // Thêm các thuộc tính khác nếu cần
                };
                KhachSanList.Add(khachSan);
            }
            // Sau khi thêm dữ liệu vào ObservableCollection, gán ObservableCollection này vào ItemsSource của DataGrid

        }
        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {
            // Tạo đối tượng KhachSan mới từ dữ liệu nhập vào các TextBox
            KhachSan newKhachSan = new KhachSan
            {
                KhachSanID = int.Parse(idTextBox.Text),
                TenKhachSan = tenKhachSanTextBox.Text,
                DiaChi = diaChiTextBox.Text,
                LoaiKhachSan = loaiKhachSanTextBox.Text
            };

            // Gọi phương thức Thêm từ đối tượng khachSanDao để thêm vào cơ sở dữ liệu
            khachSanDao.Them(newKhachSan);

            // Sau khi thêm vào cơ sở dữ liệu, cập nhật ObservableCollection và DataGrid
            KhachSanList.Add(newKhachSan);
        }

        private void XoaButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy đối tượng KhachSan hiện tại được chọn từ DataGrid
            KhachSan selectedKhachSan = myDataGrid.SelectedItem as KhachSan;
            if (selectedKhachSan != null)
            {
                // Gọi phương thức Xoa từ đối tượng khachSanDao để xóa khách sạn khỏi cơ sở dữ liệu
                khachSanDao.Xoa(selectedKhachSan.KhachSanID);

                // Sau khi xóa khỏi cơ sở dữ liệu, cập nhật ObservableCollection và DataGrid
                KhachSanList.Remove(selectedKhachSan);
            }
        }

        private void SuaButton_Click(object sender, RoutedEventArgs e)
        {

            // Lấy đối tượng KhachSan hiện tại được chọn từ DataGrid
            KhachSan selectedKhachSan = myDataGrid.SelectedItem as KhachSan;
            if (selectedKhachSan != null)
            {
                // Cập nhật thông tin của đối tượng KhachSan được chọn từ dữ liệu nhập từ các TextBox
                selectedKhachSan.KhachSanID = int.Parse(idTextBox.Text);
                selectedKhachSan.TenKhachSan = tenKhachSanTextBox.Text;
                selectedKhachSan.DiaChi = diaChiTextBox.Text;
                selectedKhachSan.LoaiKhachSan = loaiKhachSanTextBox.Text;

                // Gọi phương thức SuaThongTin từ đối tượng khachSanDao để cập nhật thông tin vào cơ sở dữ liệu
                khachSanDao.SuaThongTin(selectedKhachSan);

                // Sau khi cập nhật vào cơ sở dữ liệu, cập nhật ObservableCollection và DataGrid
                // Không cần phải thực hiện bất kỳ thao tác nào, vì đối tượng KhachSan được thay đổi trực tiếp trong ObservableCollection
                KhachSanList.Clear(); // Xóa hết dữ liệu cũ
                loadData(); // Tải lại dữ liệu mới
            }
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lấy đối tượng KhachSan hiện tại được chọn từ DataGrid
            KhachSan selectedKhachSan = myDataGrid.SelectedItem as KhachSan;
            if (selectedKhachSan != null)
            {
                // Hiển thị thông tin của đối tượng được chọn trong các TextBox
                idTextBox.Text = selectedKhachSan.KhachSanID.ToString();
                tenKhachSanTextBox.Text = selectedKhachSan.TenKhachSan;
                diaChiTextBox.Text = selectedKhachSan.DiaChi;
                loaiKhachSanTextBox.Text = selectedKhachSan.LoaiKhachSan;
            }
        }
    }
}
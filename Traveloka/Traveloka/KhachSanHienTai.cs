using GalaSoft.MvvmLight;
using System;
using Traveloka.Models;
using Traveloka;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using Traveloka.ViewModel;

public class KhachSanHienTai : ViewModelBase
{
    private DuLichEntities _context = new DuLichEntities();
    public static KhachSan _selectedRoom;
    public KhachSan SelectedRoom
    {
        get { return _selectedRoom; }
        set
        {
            if (_selectedRoom != value)
            {
                _selectedRoom = value;
                RaisePropertyChanged(nameof(SelectedRoom));
                // Sau khi SelectedRoom thay đổi, bạn có thể cập nhật các dữ liệu cần thiết trong tab "Đánh giá" tại đây
            }
        }
    }

    private string _reviewContent;
    public string ReviewContent
    {
        get { return _reviewContent; }
        set
        {
            if (_reviewContent != value)
            {
                _reviewContent = value;
                RaisePropertyChanged(nameof(ReviewContent));
            }
        }
    }

    private Phong _SelectedPhong;
    public Phong SelectedPhong
    {
        get { return _SelectedPhong; }
        set
        {
            if (_SelectedPhong != value)
            {
                _SelectedPhong = value;
                RaisePropertyChanged(nameof(SelectedPhong));
            }
        }
    }

    private DatPhong _SelectedDatPhong;
    public DatPhong SelectedDatPhong
    {
        get { return _SelectedDatPhong; }
        set
        {
            if (_SelectedDatPhong != value)
            {
                _SelectedDatPhong = value;
                RaisePropertyChanged(nameof(SelectedDatPhong));
            }
        }
    }

    private ObservableCollection<DatPhong> _DatPhongs;
    public ObservableCollection<DatPhong> DatPhongs
    {
        get { return _DatPhongs; }
        set
        {
            if (_DatPhongs != value)
            {
                _DatPhongs = value;
                RaisePropertyChanged(nameof(_DatPhongs));
            }
        }
    }

    public RelayCommand AddReviewCommand { get; private set; }
    public RelayCommand AddBookingCommand { get; private set; }
    public RelayCommand DeleteBookingCommand { get; private set; }
    public KhachSanHienTai()
    {
        AddReviewCommand = new RelayCommand(AddReview);
        AddBookingCommand = new RelayCommand(AddBooking);
        DeleteBookingCommand = new RelayCommand(DeleteBooking);
        LoadDatPhong();
        LoadReviews();
    }

    private void DeleteBooking()
    {
        if (SelectedDatPhong != null)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _context.Phongs.Find(SelectedDatPhong.PhongId).TrangThai = 1;
                _context.DatPhongs.Remove(SelectedDatPhong);
                _context.SaveChanges();
               
                // Sau khi xóa phòng, cập nhật lại danh sách phòng
                LoadDatPhong();
                RaisePropertyChanged(nameof(DatPhongs));
            }
        }
    }

   

    private void AddBooking()
    {
        DatPhong datphong = new DatPhong()
        {
            UserId = CurrentUser.LoggedInUser.UserId,
            PhongId = SelectedPhong.PhongId,
            NgayNhanPhong = KhachSanModel.FirstDate,
            NgayTraPhong = KhachSanModel.SecondDate
        };
        
        _context.Phongs.Find(SelectedPhong.PhongId).TrangThai = 0;
        _context.DatPhongs.Add(datphong);
        _context.SaveChanges();
        LoadDatPhong();
        RaisePropertyChanged(nameof(DatPhongs));
        MessageBox.Show("dat phong thanh cong");
    }

    private void AddReview()
    {
        // Thực hiện xử lý khi người dùng thêm đánh giá
        if (SelectedRoom != null && !string.IsNullOrEmpty(ReviewContent))
        {
            // Tạo một đối tượng đánh giá mới
            NhanXet newReview = new NhanXet()
            {
                Diem = 5, // Giả sử mặc định là 5 sao
                NoiDung = ReviewContent,
                UserId = CurrentUser.LoggedInUser.UserId,
                NgayNhanXet = DateTime.Now,
                KhachSanId = SelectedRoom.KhachSanId
            };

            _context.NhanXets.Add(newReview);
            _context.SaveChanges();

            // Load lại dữ liệu sau khi thêm đánh giá thành công
            LoadReviews();

            // Xóa nội dung đánh giá sau khi đã thêm thành công
            ReviewContent = string.Empty;
        }
        else
        {
            // Xử lý khi không có phòng được chọn hoặc nội dung đánh giá trống
            // Có thể hiển thị thông báo hoặc thực hiện các xử lý khác tùy ý
        }
    }

    private void LoadReviews()
    {
        // Xóa các đánh giá cũ trong ObservableCollection để cập nhật dữ liệu mới
        SelectedRoom = _context.KhachSans.Find(KhachSanHienTai._selectedRoom.KhachSanId);
    }
    private void LoadDatPhong()
    {
        // Xóa các đánh giá cũ trong ObservableCollection để cập nhật dữ liệu mới

        
        // Lấy danh sách đặt phòng dựa trên UserId hiện tại
        var userId = CurrentUser.LoggedInUser.UserId;
        var datphongs = _context.DatPhongs.Where(x => x.UserId == userId);
        DatPhongs = new ObservableCollection<DatPhong>(datphongs);
    }


}

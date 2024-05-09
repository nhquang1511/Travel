using GalaSoft.MvvmLight;
using System;
using Traveloka.Models;
using Traveloka;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using Traveloka.ViewModel;
using Microsoft.Win32;

public class KhachSanHienTai : ViewModelBase
{
    private DuLichEntities _context = new DuLichEntities();
    
    public static KhachSan _selectedRoom;

    public RelayCommand AddRoomCommand { get; private set; }
    public RelayCommand EditRoomCommand { get; private set; }
    public RelayCommand DeleteRoomCommand { get; private set; }
    public RelayCommand OpenFileCommand { get; private set; }

    public RelayCommand<AnhPhong> DeleteAnhPhongCommand { get; private set; }
    public RelayCommand<AnhPhong> EditAnhPhongCommand { get; private set; }

    private bool _isDon;
    public bool IsDon
    {
        get { return _isDon; }
        set
        {
            if (_isDon != value)
            {
                _isDon = value;
                RaisePropertyChanged(nameof(IsDon));
            }
        }
    }

    private bool _isDoi;
    public bool IsDoi
    {
        get { return _isDoi; }
        set
        {
            if (_isDoi != value)
            {
                _isDoi = value;
                RaisePropertyChanged(nameof(IsDoi));
            }
        }
    }

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
    private AnhPhong _newAnhPhong;
    public AnhPhong NewAnhPhong
    {
        get { return _newAnhPhong; }
        set
        {
            if (_newAnhPhong != value)
            {
                _newAnhPhong = value;
                RaisePropertyChanged(nameof(NewAnhPhong));
            }
        }
    }

    private Phong _newRoom;
    public Phong NewRoom
    {
        get { return _newRoom; }
        set
        {
            if (_newRoom != value)
            {
                _newRoom = value;
                RaisePropertyChanged(nameof(NewRoom));
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

                // Cập nhật NewRoom khi một mục được chọn
                if (_selectedRoom != null)
                {
                    NewRoom = new Phong
                    {
                        PhongId = _SelectedPhong.PhongId,
                        TenPhong = _SelectedPhong.TenPhong,
                        TenLoaiPhong = _SelectedPhong.TenLoaiPhong,
                        TrangThai = _SelectedPhong.TrangThai,
                        Gia = _SelectedPhong.Gia,
                        AnhPhongs = _SelectedPhong.AnhPhongs,
                        KhachSanId = _SelectedPhong.KhachSanId
                        
                    };
                }
            }
        }
    }
    private string _selectedImagePath;
    public string SelectedImagePath
    {
        get { return _selectedImagePath; }
        set
        {
            if (_selectedImagePath != value)
            {
                _selectedImagePath = value;
                RaisePropertyChanged(nameof(SelectedImagePath));
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

    private ObservableCollection<NhanXet> _NhanXets;
    public ObservableCollection<NhanXet> NhanXets
    {
        get { return _NhanXets; }
        set
        {
            if (_NhanXets != value)
            {
                _NhanXets = value;
                RaisePropertyChanged(nameof(NhanXets));
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
                RaisePropertyChanged(nameof(DatPhongs));
            }
        }
    }

    private ObservableCollection<Phong> _Phongs;
    public ObservableCollection<Phong> Phongs
    {
        get { return _Phongs; }
        set
        {
            if (_Phongs != value)
            {
                _Phongs = value;
                RaisePropertyChanged(nameof(Phongs));
            }
        }
    }

    public RelayCommand AddReviewCommand { get; private set; }
    public RelayCommand AddBookingCommand { get; private set; }
    public RelayCommand DeleteBookingCommand { get; private set; }
    public KhachSanHienTai()
    {
        LoadReviews();
        LoadDatPhong();
        AddReviewCommand = new RelayCommand(AddReview);
        AddBookingCommand = new RelayCommand(AddBooking);
        DeleteBookingCommand = new RelayCommand(DeleteBooking);
        
        NewRoom = new Phong();
        NewAnhPhong = new AnhPhong();
        AddRoomCommand = new RelayCommand(AddRoom);
        EditRoomCommand = new RelayCommand(EditRoom);
        DeleteRoomCommand = new RelayCommand(DeleteRoom);
        OpenFileCommand = new RelayCommand(OpenFile);
        DeleteAnhPhongCommand = new RelayCommand<AnhPhong>(DeleteAnhPhong);
        EditAnhPhongCommand = new RelayCommand<AnhPhong>(EditAnhPhong);
    }

    private void DeleteAnhPhong(AnhPhong anhPhong)
    {
        if (anhPhong != null)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ảnh này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _context.AnhPhongs.Remove(anhPhong);
                _context.SaveChanges();

                // Sau khi xóa ảnh, cập nhật lại danh sách phòng
                LoadReviews();
            }
        }
    }

    private void EditAnhPhong(AnhPhong anhPhong)
    {
        if (anhPhong != null)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                // Lưu đường dẫn của ảnh mới vào cơ sở dữ liệu
                anhPhong.AnhPhong1 = openFileDialog.FileName;
                _context.SaveChanges();

                // Cập nhật lại danh sách phòng
                LoadReviews();
            }
        }
    }

    private void OpenFile()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

        if (openFileDialog.ShowDialog() == true)
        {
            SelectedImagePath = openFileDialog.FileName;
            AnhPhong anhPhong = new AnhPhong { AnhPhong1 = openFileDialog.FileName, PhongId = SelectedPhong.PhongId };
            _context.AnhPhongs.Add(anhPhong);
            _context.SaveChanges();
            LoadReviews();
        }
    }


    

    private void AddRoom()
    {
        NewRoom.TenLoaiPhong = IsDon ? "Phòng Đơn" : "Phòng Đôi";
        NewRoom.AnhPhongs = null;
        _context.Phongs.Add(NewRoom);

        _context.SaveChanges();

        LoadReviews();
        NewRoom = new Phong(); // Reset NewRoom for next entry
    }

    private void EditRoom()
    {
        try
        {
            if (SelectedPhong != null)
            {
                // Cập nhật thông tin của phòng được chọn
                SelectedPhong.TenPhong = NewRoom.TenPhong;
                SelectedPhong.TenLoaiPhong = NewRoom.TenLoaiPhong;
                SelectedPhong.TrangThai = NewRoom.TrangThai;
                SelectedPhong.Gia = NewRoom.Gia;
                SelectedPhong.AnhPhongs = NewRoom.AnhPhongs;
                // Lưu thay đổi vào cơ sở dữ liệu
                _context.SaveChanges();
                // Cập nhật lại danh sách phòng
                LoadReviews();
                // Reset NewRoom cho lần nhập tiếp theo
                NewRoom = new Phong();
                MessageBox.Show("Chỉnh sửa phòng thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phòng để chỉnh sửa.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi chỉnh sửa phòng: " + ex.Message);
        }
    }

    private void DeleteRoom()
    {
        if (SelectedPhong != null)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _context.Phongs.Remove(_context.Phongs.Find(SelectedPhong.PhongId));
                _context.SaveChanges();

                // Sau khi xóa phòng, cập nhật lại danh sách phòng
                LoadReviews();
            }
        }
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
                LoadDatPhong();
                // Sau khi xóa phòng, cập nhật lại danh sách phòng
                LoadReviews();
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
            NgayNhanPhong = KhachSanModel._FirstDate,
            NgayTraPhong = KhachSanModel._SecondDate
        };
        
        _context.Phongs.Find(SelectedPhong.PhongId).TrangThai = 0;
        _context.DatPhongs.Add(datphong);
        _context.SaveChanges();
        LoadDatPhong();
        LoadReviews();
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
            LoadDatPhong();
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
        Phongs = new ObservableCollection<Phong>(_context.Phongs.Where(p=>p.TrangThai==1 && p.KhachSanId == SelectedRoom.KhachSanId).ToList());
        // Xóa các đánh giá cũ trong ObservableCollection để cập nhật dữ liệu mới
        NhanXets = new ObservableCollection<NhanXet>(_context.NhanXets.Where(p=>p.UserId==CurrentUser.LoggedInUser.UserId).ToList());
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

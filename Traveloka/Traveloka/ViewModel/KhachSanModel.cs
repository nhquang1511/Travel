using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Traveloka.Models;
using Traveloka.views.admin;
using Traveloka.views.user;

namespace Traveloka.ViewModel
{
    public class KhachSanModel : ViewModelBase
    {
        private DuLichEntities _context;
        public static DateTime FirstDate { get; set; }
        public static DateTime SecondDate { get; set; }
        public RelayCommand LoadKhachSan { get; private set; }
        public RelayCommand AddKhachSanCommand { get; private set; }
        public RelayCommand EditKhachSanCommand { get; private set; }
        public RelayCommand DeleteKhachSanCommand { get; private set; }
        public RelayCommand OpenFileCommand { get; private set; }

        public RelayCommand<AnhKhachSan> DeleteAnhKhachSanCommand { get; private set; }
        public RelayCommand<AnhKhachSan> EditAnhKhachSanCommand { get; private set; }

        public RelayCommand ChiTietKhachSanCommand { get; private set; }

        private AnhKhachSan _selectedAnhKhachSan;
        public AnhKhachSan SelectedAnhKhachSan
        {
            get { return _selectedAnhKhachSan; }
            set
            {
                if (_selectedAnhKhachSan != value)
                {
                    _selectedAnhKhachSan = value;
                    RaisePropertyChanged(nameof(SelectedAnhKhachSan));
                }
            }
        }



        private AnhKhachSan _newAnhKhachSan;
        public AnhKhachSan NewAnhKhachSan
        {
            get { return _newAnhKhachSan; }
            set
            {
                if (_newAnhKhachSan != value)
                {
                    _newAnhKhachSan = value;
                    RaisePropertyChanged(nameof(NewAnhKhachSan));
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

        private bool _isHotel;
        public bool IsHotel
        {
            get { return _isHotel; }
            set
            {
                if (_isHotel != value)
                {
                    _isHotel = value;
                    RaisePropertyChanged(nameof(IsHotel));
                }
            }
        }

        private bool _isResort;
        public bool IsResort
        {
            get { return _isResort; }
            set
            {
                if (_isResort != value)
                {
                    _isResort = value;
                    RaisePropertyChanged(nameof(IsResort));
                }
            }
        }


        private ObservableCollection<KhachSan> _Hotels;
        public ObservableCollection<KhachSan> Hotels
        {
            get { return _Hotels; }
            set
            {
                if (_Hotels != value)
                {
                    _Hotels = value;
                    RaisePropertyChanged(nameof(Hotels));
                }
            }
        }
        private KhachSan _selectedRoom;
        public KhachSan SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                if (_selectedRoom != value)
                {
                    _selectedRoom = value;
                    RaisePropertyChanged(nameof(SelectedRoom));

                    // Cập nhật NewRoom khi một mục được chọn
                    if (_selectedRoom != null)
                    {
                        NewRoom = new KhachSan
                        {
                            TenKhachSan = _selectedRoom.TenKhachSan,
                            DiaChi = _selectedRoom.DiaChi,
                            LoaiKhachSan = _selectedRoom.LoaiKhachSan,
                            Gia = _selectedRoom.Gia,
                            AnhKhachSans = _selectedRoom.AnhKhachSans
                        };
                    }
                }
            }
        }


        private KhachSan _newRoom;
        public KhachSan NewRoom
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



        public KhachSanModel()
        {
            _context = new DuLichEntities();
            LoadHotels();
            NewRoom = new KhachSan();
            NewAnhKhachSan = new AnhKhachSan();
            AddKhachSanCommand = new RelayCommand(AddRoom);
            EditKhachSanCommand = new RelayCommand(EditRoom);
            DeleteKhachSanCommand = new RelayCommand(DeleteRoom);
            OpenFileCommand = new RelayCommand(OpenFile);
            DeleteAnhKhachSanCommand = new RelayCommand<AnhKhachSan>(DeleteAnhKhachSan);
            EditAnhKhachSanCommand = new RelayCommand<AnhKhachSan>(EditAnhKhachSan);
            LoadKhachSan = new RelayCommand(LoadKhachSan1);
            ChiTietKhachSanCommand = new RelayCommand(ChiTietKhachSan);

        }
        private void ChiTietKhachSan()
        {
            if (SelectedRoom != null)
            {
                QuanLyPhong ctks = new QuanLyPhong();
                // Gắn SelectedRoom làm DataContext cho ChiTietKhachSan

                KhachSanHienTai._selectedRoom = SelectedRoom;
                ctks.DataContext = new KhachSanHienTai();

                // Hiển thị cửa sổ ChiTietKhachSan
                ctks.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phòng để xem chi tiết.");
            }
        }
        
        private void LoadKhachSan1()
        {
            if (SelectedRoom != null)
            {
                ChiTietKhachSan ctks = new ChiTietKhachSan();
                // Gắn SelectedRoom làm DataContext cho ChiTietKhachSan

                KhachSanHienTai._selectedRoom = SelectedRoom;
                ctks.DataContext = new KhachSanHienTai();

                // Hiển thị cửa sổ ChiTietKhachSan
                ctks.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phòng để xem chi tiết.");
            }
        }
        private void DeleteAnhKhachSan(AnhKhachSan anhKhachSan)
        {
            if (anhKhachSan != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa ảnh này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _context.AnhKhachSans.Remove(anhKhachSan);
                    _context.SaveChanges();

                    // Sau khi xóa ảnh, cập nhật lại danh sách phòng
                    LoadHotels();
                }
            }
        }

        private void EditAnhKhachSan(AnhKhachSan anhKhachSan)
        {
            if (anhKhachSan != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

                if (openFileDialog.ShowDialog() == true)
                {
                    // Lưu đường dẫn của ảnh mới vào cơ sở dữ liệu
                    anhKhachSan.AnhKhachSan1 = openFileDialog.FileName;
                    _context.SaveChanges();

                    // Cập nhật lại danh sách phòng
                    LoadHotels();
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
                AnhKhachSan anhKhachSan = new AnhKhachSan { AnhKhachSan1 = openFileDialog.FileName, KhachSanId = SelectedRoom.KhachSanId };
                _context.AnhKhachSans.Add(anhKhachSan);
                _context.SaveChanges();

                LoadHotels();
            }
        }


        public void LoadHotels()
        {
            Hotels = new ObservableCollection<KhachSan>(_context.KhachSans.ToList());
        }

        private void AddRoom()
        {
            NewRoom.LoaiKhachSan = IsHotel ? "Hotel" : "Resort";
            NewRoom.AnhKhachSans = null;
            _context.KhachSans.Add(NewRoom);
            _context.SaveChanges();
            LoadHotels();
            NewRoom = new KhachSan(); // Reset NewRoom for next entry
        }

        private void EditRoom()
        {
            try
            {
                if (SelectedRoom != null)
                {
                    // Cập nhật thông tin của phòng được chọn
                    SelectedRoom.TenKhachSan = NewRoom.TenKhachSan;
                    SelectedRoom.DiaChi = NewRoom.DiaChi;
                    SelectedRoom.LoaiKhachSan = IsHotel ? "Hotel" : "Resort";
                    SelectedRoom.Gia = NewRoom.Gia;
                    SelectedRoom.AnhKhachSans = NewRoom.AnhKhachSans;
                    // Lưu thay đổi vào cơ sở dữ liệu
                    _context.SaveChanges();
                    // Cập nhật lại danh sách phòng
                    LoadHotels();
                    // Reset NewRoom cho lần nhập tiếp theo
                    NewRoom = new KhachSan();
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
            if (SelectedRoom != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _context.KhachSans.Remove(SelectedRoom);
                    _context.SaveChanges();

                    // Sau khi xóa phòng, cập nhật lại danh sách phòng
                    LoadHotels();
                }
            }
        }


    }

}

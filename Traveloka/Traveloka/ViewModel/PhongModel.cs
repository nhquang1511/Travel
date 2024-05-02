using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Traveloka.Models;

namespace Traveloka.ViewModel
{
    public class PhongViewModel : ViewModelBase
    {
        private DuLichEntities _context;

        public RelayCommand AddRoomCommand { get; private set; }
        public RelayCommand EditRoomCommand { get; private set; }
        public RelayCommand DeleteRoomCommand { get; private set; }
        public RelayCommand OpenFileCommand { get; private set; }

        public RelayCommand<AnhPhong> DeleteAnhPhongCommand { get; private set; }
        public RelayCommand<AnhPhong> EditAnhPhongCommand { get; private set; }

        private AnhPhong _selectedAnhPhong;
        public AnhPhong SelectedAnhPhong
        {
            get { return _selectedAnhPhong; }
            set
            {
                if (_selectedAnhPhong != value)
                {
                    _selectedAnhPhong = value;
                    RaisePropertyChanged(nameof(SelectedAnhPhong));
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


        private ObservableCollection<Phong> _rooms;
        public ObservableCollection<Phong> Rooms
        {
            get { return _rooms; }
            set
            {
                if (_rooms != value)
                {
                    _rooms = value;
                    RaisePropertyChanged(nameof(Rooms));
                }
            }
        }
        private Phong _selectedRoom;
        public Phong SelectedRoom
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
                        NewRoom = new Phong
                        {
                            TenPhong = _selectedRoom.TenPhong,
                            TenLoaiPhong = _selectedRoom.TenLoaiPhong,
                            TrangThai = _selectedRoom.TrangThai,
                            Gia = _selectedRoom.Gia,
                            //AnhPhongs = _selectedRoom.AnhPhongs
                        };
                    }
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
        


        public PhongViewModel()
        {
            _context = new DuLichEntities();
            LoadRooms();
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
                    LoadRooms();
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
                    LoadRooms();
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
                AnhPhong anhPhong = new AnhPhong { AnhPhong1 = openFileDialog.FileName, PhongId = SelectedRoom.PhongId };
                _context.AnhPhongs.Add(anhPhong);
                _context.SaveChanges();
                LoadRooms();
            }
        }


        private void LoadRooms()
        {
            Rooms = new ObservableCollection<Phong>(_context.Phongs.ToList());
        }

        private void AddRoom()
        {
            _context.Phongs.Add(NewRoom);
            _context.SaveChanges();
            
            LoadRooms();
            NewRoom = new Phong(); // Reset NewRoom for next entry
        }

        private void EditRoom()
        {
            try
            {
                if (SelectedRoom != null)
                {
                    // Cập nhật thông tin của phòng được chọn
                    SelectedRoom.TenPhong = NewRoom.TenPhong;
                    SelectedRoom.TenLoaiPhong = NewRoom.TenLoaiPhong;
                    SelectedRoom.TrangThai = NewRoom.TrangThai;
                    SelectedRoom.Gia = NewRoom.Gia;
                    SelectedRoom.AnhPhongs = NewRoom.AnhPhongs;
                    // Lưu thay đổi vào cơ sở dữ liệu
                    _context.SaveChanges();
                    // Cập nhật lại danh sách phòng
                    LoadRooms();
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
            if (SelectedRoom != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _context.Phongs.Remove(SelectedRoom);
                    _context.SaveChanges();

                    // Sau khi xóa phòng, cập nhật lại danh sách phòng
                    LoadRooms();
                }
            }
        }
        

    }
}

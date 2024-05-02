using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveloka.Models;

namespace Traveloka.ViewModel
{
    public class TestModel: ViewModelBase
    {
        private DuLichEntities _context;
        // khai bao danh sach phòng
        private ObservableCollection<Phong> _phongs;
        public ObservableCollection<Phong> Phongs
        {
            get { return _phongs; }
            set
            {
                _phongs = value;
                RaisePropertyChanged(nameof(Phongs));
            }
        }
        private void LoadPhongs()
        {
            // Giả lập việc tải danh sách phòng từ cơ sở dữ liệu
            _context = new DuLichEntities();
            var phongsFromDatabase = _context.Phongs.ToList();

            Phongs = new ObservableCollection<Phong>(phongsFromDatabase);
        }

        public TestModel()
        {
            // Load danh sách phòng từ cơ sở dữ liệu hoặc từ dữ liệu giả lập
            LoadPhongs();
        }
    }
}

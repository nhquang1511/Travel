using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Models
{
    public class DanhGia
    {
        public DanhGia()
        {
        }

        public int DanhGiaId { get; set; }
        public int KhachSanId { get; set; }

        public int KhachHangId { get; set; }
        public string NoiDung { get; set; }

        public int Diem {  get; set; }
        
    }
}

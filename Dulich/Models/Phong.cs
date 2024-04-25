using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Models
{
    public class Phong
    {
        public int PhongID { get; set; }
        public string TenPhong { get; set; }
        public int KhachSanID { get; set; }
        public string TenLoaiPhong { get; set; }
        public string TrangThai { get; set; }
        public float Gia {  get; set; }
    }

}
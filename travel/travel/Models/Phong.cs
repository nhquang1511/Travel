using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travel.Models
{
    public class Phong
    {
        public int PhongID { get; set; }
        public string TenPhong { get; set; }
        public int KhachSanID { get; set; }
        public string TenLoaiPhong { get; set; }
        public string TrangThai { get; set; }

        public Phong(int PhongID, string TenPhong, int KhachSanID, string TenLoaiPhong, string TrangThai)
        {
            this.PhongID = PhongID;
            this.TenPhong = TenPhong;
            this.KhachSanID = KhachSanID;
            this.TenLoaiPhong = TenLoaiPhong;
            this.TrangThai = TrangThai;
        }
    }
}

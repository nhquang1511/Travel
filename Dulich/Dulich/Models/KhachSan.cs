using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Models
{
    public class KhachSan
    {
        public int KhachSanID { get; set; }
        public string TenKhachSan {  get; set; }
        public string DiaChi { get; set; }

        public string LoaiKhachSan { get; set; }

        public string Anh {  get; set; }
        public string MoTa { get; set; }
        public string Gia {  get; set; }
    }
}

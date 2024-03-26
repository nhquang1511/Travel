using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travel.Models
{
    public class ChuKhachSan
    {
        public int ID { get; set; }
        public string Ten { get; set; }

        public ChuKhachSan(int iD, string ten)
        {
            ID = iD;
            Ten = ten;
        }

        public ChuKhachSan()
        {
        }
    }
}

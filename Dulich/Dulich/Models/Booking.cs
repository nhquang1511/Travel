using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dulich.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DatePicker NgayDat { get; set; }
        public DatePicker NgayTra { get; set; }
        public int KhachHangID { get; set; }
        public int PhongID { get; set; }
    }
}

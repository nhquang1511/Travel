using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public string Password { get; set; }
        public User() { }
    }
}

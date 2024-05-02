using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveloka.Models;

namespace Traveloka
{
    public static class CurrentUser
    {
        public static User LoggedInUser { get; set; }
    }
}

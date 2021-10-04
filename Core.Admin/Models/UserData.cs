using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Admin.Models
{
    public class UserData
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public string Email  { get; set; }
        public string Image { get; set; }
    }
}

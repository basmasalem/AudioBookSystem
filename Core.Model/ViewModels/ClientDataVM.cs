using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class ClientDataVM
    {
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? CityId { get; set; }
        public string City { get; set; }
        public DateTime RegisterationDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string Image { get; set; }
    }
}

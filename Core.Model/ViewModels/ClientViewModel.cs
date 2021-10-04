using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
  public  class ClientViewModel
    {
        public int ClientId { get; set; }
        public string Key { get; set; }
        public string FullName { get; set; }
        public string FullNameEn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BioAr { get; set; }
        public string BioEn { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Phone { get; set; }
        public int? CityId { get; set; }
        public string CityAr { get; set; }
        public string CityEn { get; set; }
        public string Image { get; set; }

        public int AudioCount { get; set; }

        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }

        public bool IsFollowing { get; set; }
        public bool CanFollowing { get; set; }



        public List<TagDataVM> Tags { get; set; }
    }
}

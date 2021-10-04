using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
    public class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();

        }
        public int UserTypeId { get; set; }
        [Required ,MaxLength(100)]
        public string Name { get; set; }
        public bool IsShow { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

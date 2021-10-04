using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
    public class City:BaseData
    {
        public City()
        {
       
        }

        [Required, MaxLength(100)]
        public string NameAr { get; set; }

        [Required, MaxLength(100)]
        public string NameEn { get; set; }

        public int CityId { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

    }
}

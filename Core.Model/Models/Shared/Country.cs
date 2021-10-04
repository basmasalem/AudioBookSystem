using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
    public class Country:BaseData
    {
        public Country()
        {
       
        }

        [Required, MaxLength(100)]
        public string NameAr { get; set; }

        [Required, MaxLength(100)]
        public string NameEn { get; set; }

        public int CountryId { get; set; }


    }
}

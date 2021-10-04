using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
    public class AboutUs
    {
        public int AboutUsId { get; set; }

        public string AboutUsAr { get; set; }
        public string AboutUsEn { get; set; }


        [MaxLength(100)]
        public string Image { get; set; }
    }
}

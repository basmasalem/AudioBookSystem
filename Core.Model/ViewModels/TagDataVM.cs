using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class TagDataVM
    {
        public int TagId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

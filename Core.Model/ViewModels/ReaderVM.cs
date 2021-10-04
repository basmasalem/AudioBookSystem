using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class ReaderVM
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public int ClientId { get; set; }
        public string FullNameAr { get; set; }
        public string FullNameEn { get; set; }
        public string BioAr { get; set; }
        public string BioEn { get; set; }
        public string Image { get; set; }
    }
}

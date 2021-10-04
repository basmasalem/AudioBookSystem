using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
  public  class ArticleViewModel
    {

        public int ArticleId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public DateTime ArticleDate { get; set; }

        public string DescAr { get; set; }
        public string DescEn { get; set; }

        public string ArticleOwnerAr { get; set; }
        public string ArticleOwnerEn { get; set; }

        public string Image { get; set; }
        public string Key { get; set; }

    }
}

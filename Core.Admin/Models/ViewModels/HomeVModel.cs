using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Admin.Models.ViewModels
{
    public class HomeVModel
    {
        public int PodcastCount { get; set; }
        public int AudioCount { get; set; }
        public int TagCount { get; set; }
        public int AudioTypeCount { get; set; }
        public int ClientCount { get; set; }
        public int CategoryCount { get; set; }
        public int ArticleCount { get; set; }

    }
}

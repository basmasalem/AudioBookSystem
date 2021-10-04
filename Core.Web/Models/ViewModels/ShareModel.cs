using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Models.ViewModels
{
    public class ShareModel
    {
        public string Url { get; set; }
        public int ClintId { get; set; }
        public int SharedType { get; set; }// 1 for article // 2 for audio
        public int SharedId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
   public class AudioReview : BaseData
    {
        public int AudioReviewId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public int Rate { get; set; }

        public virtual Client Client { get; set; }
    }
}

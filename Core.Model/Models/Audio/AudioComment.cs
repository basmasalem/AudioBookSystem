using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
   public class AudioComment:BaseData
    {
        public int AudioCommentId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [ForeignKey("Audio")]
        public int AudioId { get; set; }
        public string Text { get; set; }

        public virtual Client Client { get; set; }
        public virtual Audio Audio { get; set; }
    }
}

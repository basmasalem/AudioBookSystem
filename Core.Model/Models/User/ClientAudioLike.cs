using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    public class ClientAudioLike
    {
        public int ClientAudioLikeId { get; set; }
        [ForeignKey("Audio")]
        public int AudioId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public bool Like { get; set; }


        public virtual Client Client { get; set; }
        public virtual Audio Audio { get; set; }

    }
}

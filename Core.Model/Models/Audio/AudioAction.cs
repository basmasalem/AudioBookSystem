using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    public class AudioAction
    {
        public int AudioActionId { get; set; }

        [ForeignKey("Audio")]
        public int AudioId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public bool? Like { get; set; }

        public int Rate { get; set; }
        [MaxLength(300)]
        public string RateText { get; set; }

        public int Share { get; set; }
        public bool? Listen { get; set; }
        public bool? ApproveRate { get; set; }
        public virtual Client Client { get; set; }
        public virtual Audio Audio { get; set; }
    }
}

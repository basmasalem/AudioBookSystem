using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    public class ClientTag:BaseData
    {
        public int ClientTagId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }


        public virtual Client Client { get; set; }
        public virtual Tag Tag { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
    public class PrintBook:BaseData
    {
        public int PrintBookId { get; set; }
        [MaxLength(100)]
        public string ClientName { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Attachment { get; set; }
    }
}

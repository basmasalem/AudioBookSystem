using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
    public class Attachment:BaseData
    {
        public int AttachmentId { get; set; }
        public int TypeId { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
   
    }
}

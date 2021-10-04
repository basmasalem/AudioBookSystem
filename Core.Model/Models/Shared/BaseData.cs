using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
  public  class BaseData
    {
        public bool IsActive{ get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}

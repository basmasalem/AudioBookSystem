using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
   public class ClientFollower
    {
        public int ClientFollowerId { get; set; }

        [ForeignKey("Client")]
        public int SubscribeId { get; set; }   
        public int FollowerId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<DateTime> FollowingDate { get; set; }


        public virtual Client Client { get; set; }

    }
}

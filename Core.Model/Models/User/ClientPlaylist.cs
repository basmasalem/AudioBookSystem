using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
   public class ClientPlaylist:BaseData
    {
        public ClientPlaylist()
        {
            PlaylistAudios = new HashSet<PlaylistAudio>();
        }
        public int ClientPlaylistId { get; set; }
        [MaxLength(100,ErrorMessage ="لا يزيد الاسم عن 100 حرف")]
        public string NameAr { get; set; }
        [MaxLength(100, ErrorMessage = "لا يزيد الاسم عن 100 حرف")]
        public string NameEn { get; set; }

        [MaxLength(300, ErrorMessage = "لا يزيد الوصف عن 300 حرف")]
        public string DescAr { get; set; }
        [MaxLength(300, ErrorMessage = "لا يزيد الوصف عن 300 حرف")]
        public string DescEn { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<PlaylistAudio> PlaylistAudios { get; set; }


    }
}

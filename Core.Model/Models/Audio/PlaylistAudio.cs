using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
   public class PlaylistAudio
    {
        public PlaylistAudio()
        {

        }
        public int PlaylistAudioId { get; set; }

        [ForeignKey("Audio")]
        public int AudioId { get; set; }
      
        [ForeignKey("ClientPlaylist")]
        public int ClientPlaylistId { get; set; }

        public virtual ClientPlaylist ClientPlaylist { get; set; }
        public virtual Audio Audio { get; set; }


    }
}

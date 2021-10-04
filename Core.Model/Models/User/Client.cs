using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
   public class Client :BaseData
    {
        public Client()
        {
            PodcastParticipants = new HashSet<PodcastParticipant>();
            ClientTags = new HashSet<ClientTag>();
            ClientPlaylists = new HashSet<ClientPlaylist>();
            AudioActions = new HashSet<AudioAction>();
            ClientFollowers = new HashSet<ClientFollower>();

        }
        public int ClientId { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(100)]
        public string FullNameEn { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(200)]
        public string BioAr { get; set; }
        [MaxLength(200)]
        public string BioEn { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        //public string Country { get; set; }
        [ForeignKey("City")]
        public int? CityId { get; set; }
        public DateTime RegisterationDate { get; set; }
        //public DateTime BirthDate { get; set; }
        [MaxLength(100)]

        public string Image { get; set; }

        public bool IsEmailVerified { get; set; }

        public virtual ICollection<PodcastParticipant> PodcastParticipants { get; set; }
        public virtual ICollection<ClientPlaylist> ClientPlaylists { get; set; }
        public virtual ICollection<ClientTag> ClientTags { get; set; }
        public virtual ICollection<AudioAction> AudioActions { get; set; }
        public virtual ICollection<ClientFollower> ClientFollowers { get; set; }
        public virtual City City { get; set; }


    }
}

using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public class AudioKetabDbContext: DbContext
    {
        public AudioKetabDbContext(DbContextOptions<AudioKetabDbContext> options) : base(options)
        {

        }


        //user
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        //Client
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientPlaylist> ClientPlaylists { get; set; }
        public virtual DbSet<ClientTag> ClientTags { get; set; }       
        public virtual DbSet<ClientFollower> ClientFollowers { get; set; }


        //shared
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<AboutUs> AboutUs { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }

        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<PrintBook>  PrintBooks { get; set; }


        //Podcast
        public virtual DbSet<Podcast> Podcast { get; set; }
        public virtual DbSet<PodcastAudio> PodcastAudio { get; set; }
        public virtual DbSet<PodcastParticipant> PodcastParticipant { get; set; }


        //Audio

        public virtual DbSet<Audio> Audios { get; set; }
        public virtual DbSet<AudioComment> AudioComments { get; set; }
        public virtual DbSet<AudioAction> AudioActions { get; set; }
        public virtual DbSet<AudioType> AudioTypes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<PlaylistAudio> PlaylistAudios { get; set; }




    }
}

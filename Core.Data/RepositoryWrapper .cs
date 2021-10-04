using Core.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private AudioKetabDbContext _audioKetabDbContext;

        private IAudioRepository _audio;
        private IAudioTypeRepository _audioType;
        private IPodcastRepository _podcast;
        private IAboutUsRepository _aboutUs;
        private IUserRepository _user;
        private IAttachmentRepository _attachment;
        private ICategoryRepository _category;
        private IContactUsRepository _contactUs;
        private IClientRepository _client;
        private IPodcastAudioRepository _podcastAudio;
        private IPodcastParticipantRepository _podcastParticipant;
        private IArticleRepository _article;
        private ITagRepository _tag;
        private ISettingRepository _setting;
        private IAudioActionRepository _audioAction;
        private IAudioCommentRepository _audioComment;
        private IClientPlaylistRepository _clientPlaylistRepository;
        private IPlaylistAudioRepository _playlistAudioRepository;
        private IClientFollowerRepository _clientFollower;
        private ICityRepository _city;
        private IPrintBookRepository _printBook;

        public ICityRepository cityRepository
        {
            get
            {
                if (_city == null)
                {
                    _city = new CityRepository(_audioKetabDbContext);
                }
                return _city;
            }
        }
        public IAudioRepository audioRepository
        {
            get
            {
                if (_audio == null)
                {
                    _audio = new AudioRepository(_audioKetabDbContext);
                }
                return _audio;
            }
        }
        public IAudioTypeRepository audioTypeRepository
        {
            get
            {
                if (_audioType == null)
                {
                    _audioType = new AudioTypeRepository(_audioKetabDbContext);
                }
                return _audioType;
            }
        }


        public IPodcastRepository podcastRepository
        {
            get
            {
                if (_podcast == null)
                {
                    _podcast = new PodcastRepository(_audioKetabDbContext);
                }
                return _podcast;
            }
        }

        public IAboutUsRepository aboutUsRepository
        {
            get
            {
                if (_aboutUs == null)
                {
                    _aboutUs = new AboutUsRepository(_audioKetabDbContext);
                }
                return _aboutUs;
            }
        }

        public IUserRepository userRepository
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_audioKetabDbContext);
                }
                return _user;
            }
        }
        public IAttachmentRepository attachmentRepository
        {
            get
            {
                if (_attachment == null)
                {
                    _attachment = new AttachmentRepository(_audioKetabDbContext);
                }
                return _attachment;
            }
        }
        public ICategoryRepository categoryRepository
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_audioKetabDbContext);
                }
                return _category;
            }
        }
        public IContactUsRepository contactUsRepository
        {
            get
            {
                if (_contactUs == null)
                {
                    _contactUs = new ContactUsRepository(_audioKetabDbContext);
                }
                return _contactUs;
            }
        }
        public IClientRepository clientRepository
        {
            get
            {
                if (_client == null)
                {
                    _client = new ClientRepository(_audioKetabDbContext);
                }
                return _client;
            }
        }

        public IPodcastAudioRepository podcastAudioRepository
        {
            get
            {
                if (_podcastAudio == null)
                {
                    _podcastAudio = new PodcastAudioRepository(_audioKetabDbContext);
                }
                return _podcastAudio;
            }
        }


        public IPodcastParticipantRepository podcastParticipantRepository
        {
            get
            {
                if (_podcastParticipant == null)
                {
                    _podcastParticipant = new PodcastParticipantRepository(_audioKetabDbContext);
                }
                return _podcastParticipant;
            }
        }
        public IArticleRepository articleRepository
        {
            get
            {
                if (_article == null)
                {
                    _article = new ArticleRepository(_audioKetabDbContext);
                }
                return _article;
            }
        }

        public ITagRepository tagRepository
        {
            get
            {
                if (_tag == null)
                {
                    _tag = new TagRepository(_audioKetabDbContext);
                }
                return _tag;
            }
        }

        public ISettingRepository settingRepository
        {
            get
            {
                if (_setting == null)
                {
                    _setting = new SettingRepository(_audioKetabDbContext);
                }
                return _setting;
            }
        }

        public IAudioActionRepository audioActionRepository
        {
            get
            {
                if (_audioAction == null)
                {
                    _audioAction = new AudioActionRepository(_audioKetabDbContext);
                }
                return _audioAction;
            }
        }

        public IAudioCommentRepository audioCommentRepository
        {
            get
            {
                if (_audioComment == null)
                {
                    _audioComment = new AudioCommentRepository(_audioKetabDbContext);
                }
                return _audioComment;
            }
        }

        public IClientPlaylistRepository clientPlaylistRepository
        {
            get
            {
                if (_clientPlaylistRepository == null)
                {
                    _clientPlaylistRepository = new ClientPlaylistRepository(_audioKetabDbContext);
                }
                return _clientPlaylistRepository;
            }
        }

        public IPlaylistAudioRepository playlistAudioRepository
        {
            get
            {
                if (_playlistAudioRepository == null)
                {
                    _playlistAudioRepository = new PlaylistAudioRepository(_audioKetabDbContext);
                }
                return _playlistAudioRepository;
            }
        }

        public IClientFollowerRepository clientFollowerRepository
        {
            get
            {
                if (_clientFollower == null)
                {
                    _clientFollower = new ClientFollowerRepository(_audioKetabDbContext);
                }
                return _clientFollower;
            }
        }

        public IPrintBookRepository PrintBookRepository
        {
            get
            {
                if (_printBook == null)
                {
                    _printBook = new PrintBookRepository(_audioKetabDbContext);
                }
                return _printBook;
            }
        }

        public RepositoryWrapper(AudioKetabDbContext audioKetabDbContext)
        {
            _audioKetabDbContext = audioKetabDbContext;
        }
        public void Save()
        {
            _audioKetabDbContext.SaveChanges();
        }
    }



    public interface IRepositoryWrapper
    {
        IAudioRepository audioRepository { get; }
        IAudioTypeRepository audioTypeRepository { get; }
        IPodcastRepository podcastRepository { get; }
        IAboutUsRepository aboutUsRepository { get; }
        IUserRepository userRepository { get; }
        IAttachmentRepository attachmentRepository { get; }
        ICategoryRepository categoryRepository { get; }
        IContactUsRepository contactUsRepository { get; }
        IClientRepository clientRepository { get; }
        IPodcastAudioRepository podcastAudioRepository { get; }
        IPodcastParticipantRepository podcastParticipantRepository { get; }
        IArticleRepository articleRepository { get; }
        ITagRepository tagRepository { get; }
        ISettingRepository settingRepository { get; }
        IAudioActionRepository audioActionRepository { get; }
        IAudioCommentRepository audioCommentRepository { get; }
        IClientPlaylistRepository clientPlaylistRepository { get; }
        IPlaylistAudioRepository playlistAudioRepository { get; }
        IClientFollowerRepository clientFollowerRepository { get; }
        ICityRepository cityRepository { get; }
        IPrintBookRepository PrintBookRepository { get; }

        void Save();


    }
}

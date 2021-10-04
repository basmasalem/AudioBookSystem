using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
  public class ServiceWrapper : IServiceWrapper
    {

        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtectionProvider _provider;
        private readonly IOptions<MailSettings> _mailSettings;
        public ServiceWrapper(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider, IOptions<MailSettings> mailSettings)
        {
            this._repoWrapper = repoWrapper;
            _provider = provider;
            _mailSettings = mailSettings;
        }


        private IAudioService _audio;
        private IAudioCommentService _audioComment;
        private IAudioTypeService _audioType;
        private IPodcastService _podcast;
        private IPodcastAudioService _podcastAudio;
        private IUserService _user;
        private ICategoryService _category;
        private IClientService _client;
        private IArticleService _article;
        private ITagService _tag;
        private ISettingService _setting;
        private IAudioActionService _audioAction;
        private IClientPlaylistService _clientPlaylist;
        private IPlaylistAudioService _PlaylistAudio;
        private IClientFollowerService _clientFollower;
        private ICityService _city;
        private IMailService _mail ;
        private IPrintBookService _printBook;


        public ICityService CityService
        {
            get
            {
                if (_city == null)
                {
                    _city = new CityService(_repoWrapper,_provider);
                }
                return _city;
            }
        }

        public ISettingService SettingService
        {
            get
            {
                if (_setting == null)
                {
                    _setting = new SettingService(_repoWrapper);
                }
                return _setting;
            }
        }
        public IAudioService audioService
        {
            get
            {
                if (_audio == null)
                {
                    _audio = new AudioService(_repoWrapper, _provider);
                }
                return _audio;
            }
        }

        public IAudioCommentService audioCommentService
        {
            get
            {
                if (_audioComment == null)
                {
                    _audioComment = new AudioCommentService(_repoWrapper, _provider);
                }
                return _audioComment;
            }
        }

        public IAudioTypeService audioTypeService
        {
            get
            {
                if (_audioType == null)
                {
                    _audioType = new AudioTypeService(_repoWrapper);
                }
                return _audioType;
            }
        }
        public IPodcastService podcastService
        {
            get
            {
                if (_podcast == null)
                {
                    _podcast = new PodcastService(_repoWrapper,_provider);
                }
                return _podcast;
            }
        }

        public IPodcastAudioService podcastAudioService
        {
            get
            {
                if (_podcastAudio == null)
                {
                    _podcastAudio = new PodcastAudioService(_repoWrapper, _provider);
                }
                return _podcastAudio;
            }
        }

        public ICategoryService categoryService
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryService(_repoWrapper, _provider);
                }
                return _category;
            }
        }

        public IUserService userService
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserService(_repoWrapper);
                }
                return _user;
            }
        }

        public IClientService clientService
        {
            get
            {
                if (_client == null)
                {
                    _client = new ClientService(_repoWrapper, _provider, new AudioService(_repoWrapper, _provider));
                }
                return _client;
            }
        }

        public IArticleService articleService
        {
            get
            {
                if (_article == null)
                {
                    _article = new ArticleService(_repoWrapper, _provider);
                }
                return _article;
            }
        }

        public ITagService tagService
        {
            get
            {
                if (_tag == null)
                {
                    _tag = new TagService(_repoWrapper);
                }
                return _tag;
            }
        }

        public IAudioActionService AudioActionService
        {
            get
            {
                if (_audioAction == null)
                {
                    _audioAction = new AudioActionService(_repoWrapper, _provider);
                }
                return _audioAction;
            }
        }

        public IClientPlaylistService ClientPlaylistService
        {
            get
            {
                if (_clientPlaylist == null)
                {
                    _clientPlaylist = new ClientPlaylistService(_repoWrapper, _provider);
                }
                return _clientPlaylist;
            }
        }

        public IPlaylistAudioService PlaylistAudioService
        {
            get
            {
                if (_PlaylistAudio == null)
                {
                    _PlaylistAudio = new PlaylistAudioService(_repoWrapper, _provider);
                }
                return _PlaylistAudio;
            }
        }
    
        
        public IClientFollowerService ClientFollowerService
        {
            get
            {
                if (_clientFollower == null)
                {
                    _clientFollower = new ClientFollowerService(_repoWrapper, _provider);
                }
                return _clientFollower;
            }
        }
        public IPrintBookService PrintBookService
        {
            get
            {
                if (_printBook == null)
                {
                    _printBook = new PrintBookService(_repoWrapper, _provider);
                }
                return _printBook;
            }
        }
        public IMailService MailService
        {
            get
            {
                if (_mail == null)
                {
                    _mail = new MailService(_mailSettings);
                }
                return _mail;
            }
        }
    }



    public interface IServiceWrapper
    {
        IAudioService audioService{ get; }
        IAudioCommentService audioCommentService { get; }
        IAudioTypeService audioTypeService { get; }
        IPodcastService podcastService { get; }
        IPodcastAudioService podcastAudioService { get; }
        IUserService userService { get; }
        ICategoryService categoryService { get; }
        IClientService clientService { get; }
        IArticleService articleService { get; }
        ITagService tagService { get; }
        ISettingService SettingService { get; }
        IAudioActionService AudioActionService { get; }
        IClientPlaylistService ClientPlaylistService { get; }
        IPlaylistAudioService PlaylistAudioService { get; }
        IMailService MailService { get; }


        IClientFollowerService ClientFollowerService { get; }
        ICityService CityService { get; }
        IPrintBookService PrintBookService { get; }

    }
}

using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
   public class PodcastAudioService : IPodcastAudioService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;
        public PodcastAudioService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
        }


        public List<AudioViewModel> GetAudiosDataByPodcastId(int podcastId)
        {
            List<AudioViewModel> list = _repoWrapper.podcastAudioRepository.List().Where(x => x.PodcastId == podcastId).ToList().Select(x => new AudioViewModel
            {
                AudioId = x.AudioId,
                AudioSrc = x.Audio.AudioSrc,
                BookImage = x.Audio.BookImage,
                BookNameAr = x.Audio.BookNameAr,
                BookNameEn = x.Audio.BookNameEn,
                AuthorNameAr = x.Audio.AuthorNameAr,
                AuthorNameEn = x.Audio.AuthorNameEn,
                PublisherNameAr = x.Audio.PublishType == PublishType.Admin ? "أديو كتاب" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.FullName,
                PublisherNameEn = x.Audio.PublishType == PublishType.Admin ? "Audio Ketab" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.FullNameEn,
                PublisherImage = x.Audio.PublishType == PublishType.Admin ? "logo.png" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.Image,
                CategoryNameAr = x.Audio?.Category?.NameAr,
                CategoryNameEn = x.Audio?.Category?.NameEn,
                AudioTypeNameAr = x.Audio?.AudioType?.NameAr,
                AudioTypeNameEn = x.Audio?.AudioType?.NameEn,
                Key = _protector.Protect(x.AudioId.ToString()),
                CategoryId = x.Audio.CategoryId,
                TypeId = x.Audio.AudioTypeId,
                ClientLikeIds = x.Audio.AudioActions.Where(x => x.Like == true).Select(x => x.ClientId).ToList(),
                PlaylistClientIds = x.Audio.PlaylistAudios.Select(x => x.ClientPlaylist.ClientId).ToList()
            }).ToList();
            return list;
        }
    }


    public interface IPodcastAudioService
    {
        List<AudioViewModel> GetAudiosDataByPodcastId(int podcastId);


    }
}

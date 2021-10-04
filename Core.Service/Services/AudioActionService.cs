using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public class AudioActionService : IAudioActionService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;
        public AudioActionService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
        }
        public List<AudioAction> AudioActions()
        {
            return _repoWrapper.audioActionRepository.List().Where(x => x.Like == true).OrderByDescending(x => x.AudioActionId).ToList();
        }

        public void CreateAudioAction(AudioAction model)
        {
            _repoWrapper.audioActionRepository.Add(model);
        }

        public void DeleteAudioAction(int id)
        {
            var model = GetAudioAction(id);
            _repoWrapper.audioActionRepository.Delete(model);
        }

        public AudioAction GetAudioAction(int id)
        {
            return _repoWrapper.audioActionRepository.Find(id);

        }

        public AudioAction GetAudioAction(int audioId, int clientId)
        {
            return _repoWrapper.audioActionRepository.List().FirstOrDefault(x => x.AudioId == audioId && x.ClientId == clientId);
        }

        public AudioRateViewModel GetAudioRate(int audioId, int clientId)
        {
            var model = _repoWrapper.audioActionRepository.List().Where(x => x.AudioId == audioId && x.ApproveRate == true && x.Rate > 0).Select(x => new ClientAudioRateViewModel
            {
                Image = x.Client.Image,
                Rate = x.Rate,
                NameAr = x.Client.FullName,
                NameEn = x.Client.FullNameEn,
                RateText=x.RateText
            }).ToList();
            var clientRate = _repoWrapper.audioActionRepository.List().FirstOrDefault(x => x.AudioId == audioId && x.ClientId == clientId && x.Rate>0);
            return new AudioRateViewModel
            {
                ClientRate=clientRate!=null?clientRate.ApproveRate==true?clientRate.Rate:-1:0,
                ClientRates=model,
                RateCount=model.Count,
                TotalRate=model.Count>0?model.Sum(x=>x.Rate)/model.Count:0
            };
        }

        public List<AudioViewModel> GetFavoriteAudio(int clientId)
        {
            return _repoWrapper.audioActionRepository.List().Where(x => x.ClientId == clientId && x.Like == true).ToList().Select(x => new AudioViewModel
            {
                AudioId = x.AudioId,
                Key = _protector.Protect(x.AudioId.ToString()),
                AudioSrc = x.Audio.AudioSrc,
                BookImage = x.Audio.BookImage,
                BookNameAr = x.Audio.BookNameAr,
                BookNameEn = x.Audio.BookNameEn,
                AuthorNameAr = x.Audio.AuthorNameAr,
                AuthorNameEn = x.Audio.AuthorNameEn,
                PublisherNameAr = x.Audio.PublishType == PublishType.Admin ? "أديو كتاب" : _repoWrapper.clientRepository.Find(x.Audio.CreatedBy)?.FullName,
                PublisherNameEn = x.Audio.PublishType == PublishType.Admin ? "Audio Ketab" : _repoWrapper.clientRepository.Find(x.Audio.CreatedBy)?.FullNameEn,
                AuthorImage = x.Audio.PublishType == PublishType.Admin ? "logo.png" : _repoWrapper.clientRepository.Find(x.Audio.CreatedBy)?.Image,
                CategoryNameAr = x.Audio.Category.NameAr,
                CategoryNameEn = x.Audio.Category.NameEn,
                AudioTypeNameAr = x.Audio.AudioType.NameAr,
                AudioTypeNameEn = x.Audio.AudioType.NameEn,
                CategoryId = x.Audio.CategoryId,
                TypeId = x.Audio.AudioTypeId,
                ClientLikeIds = x.Audio.AudioActions.Where(x => x.Like == true).Select(x => x.ClientId).ToList(),
                PlaylistClientIds = x.Audio.PlaylistAudios.Select(x => x.ClientPlaylist.ClientId).ToList(),
            }).ToList();
        }
        public List<AudioViewModel> GetCityAudio(int cityId)
        {
            City city = _repoWrapper.cityRepository.Find(cityId);
            return _repoWrapper.audioRepository.List().Where(x => x.PublishType==PublishType.Client && city.Clients.Select(c=>c.ClientId).Contains(x.CreatedBy)).ToList().Select(x => new AudioViewModel
            {
                AudioId = x.AudioId,
                Key = _protector.Protect(x.AudioId.ToString()),
                AudioSrc = x.AudioSrc,
                BookImage = x.BookImage,
                BookNameAr = x.BookNameAr,
                BookNameEn = x.BookNameEn,
                AuthorNameAr = x.AuthorNameAr,
                AuthorNameEn = x.AuthorNameEn,
                PublisherNameAr = x.PublishType == PublishType.Admin ? "أديو كتاب" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.FullName,
                PublisherNameEn = x.PublishType == PublishType.Admin ? "Audio Ketab" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.FullNameEn,
                AuthorImage = x.PublishType == PublishType.Admin ? "logo.png" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.Image,
                CategoryNameAr = x.Category.NameAr,
                CategoryNameEn = x.Category.NameEn,
                AudioTypeNameAr = x.AudioType.NameAr,
                AudioTypeNameEn = x.AudioType.NameEn,
                CategoryId = x.CategoryId,
                TypeId = x.AudioTypeId,
                ClientLikeIds = x.AudioActions.Where(x => x.Like == true).Select(x => x.ClientId).ToList(),
                PlaylistClientIds = x.PlaylistAudios.Select(x => x.ClientPlaylist.ClientId).ToList(),
            }).ToList();
        }
        public int GetListenersCount(int audioId)
        {
            return _repoWrapper.audioActionRepository.List().Where(x => x.Listen == true && x.AudioId == audioId).Count();
        }

        public decimal GetRateCount(int audioId)
        {
            int count = _repoWrapper.audioActionRepository.List().Where(x => x.Rate != 0 && x.AudioId == audioId && x.ApproveRate == true).Count();
            return count > 0 ? _repoWrapper.audioActionRepository.List().Where(x => x.Rate != 0 && x.AudioId == audioId && x.ApproveRate == true).Sum(x => x.Rate) / count : 0;
        }

        public void SaveAudioAction()
        {
            _repoWrapper.Save();
        }

        public void UpdateAudioAction(AudioAction model)
        {
            _repoWrapper.audioActionRepository.Update(model);
        }
    }
    public interface IAudioActionService
    {
        List<AudioAction> AudioActions();

        List<AudioViewModel> GetFavoriteAudio(int clientId);
        AudioAction GetAudioAction(int id);
        AudioAction GetAudioAction(int audioId, int clientId);
        AudioRateViewModel GetAudioRate(int audioId, int clientId);
        int GetListenersCount(int audioId);
        decimal GetRateCount(int audioId);
        List<AudioViewModel> GetCityAudio(int cityId);
        void CreateAudioAction(AudioAction model);
        void UpdateAudioAction(AudioAction model);
        void DeleteAudioAction(int id);
        void SaveAudioAction();
    }
}

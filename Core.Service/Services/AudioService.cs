using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public class AudioService : IAudioService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;
        public AudioService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
        }

        #region IAudioService Members
        public List<Audio> GetAudios(int count = 0)
        {
            List<Audio> list = _repoWrapper.audioRepository.List().ToList();
            return count == 0 ? list : list.Take(count).ToList();
        }


        public AudioViewModel GetAudio(int id)
        {
            var x= _repoWrapper.audioRepository.Find(id);
            return new AudioViewModel
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
                PublisherImage = x.PublishType == PublishType.Admin ? "logo.png" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.Image,
                CategoryNameAr = x.Category.NameAr,
                CategoryNameEn = x.Category.NameEn,
                AudioTypeNameAr = x.AudioType.NameAr,
                AudioTypeNameEn = x.AudioType.NameEn,
                CategoryId = x.CategoryId,
                TypeId = x.AudioTypeId,
                CreationDate = x.CreationDate.ToString(@"d\.hh\:mm\:ss"),
                DescriptionAr = x.DescriptionAr,
                DescriptionEn = x.DescriptionEn,
                ListenerCount=x.AudioActions.Where(a=>a.Listen==true).Count(),
                RatingCount = x.AudioActions.Where(a => a.Rate != 0 && a.ApproveRate == true).Count()>0? (decimal)x.AudioActions.Where(a => a.Rate != 0 && a.ApproveRate == true).Sum(a=>a.Rate)/x.AudioActions.Where(a => a.Rate !=0 && a.ApproveRate == true).Count():0,
                CityNameAr = x.PublishType == PublishType.Admin ?_repoWrapper.userRepository.Find(x.CreatedBy)?.City.NameAr : _repoWrapper.clientRepository.Find(x.CreatedBy)?.City.NameAr,
                CityNameEn= x.PublishType == PublishType.Admin ? _repoWrapper.userRepository.Find(x.CreatedBy)?.City.NameEn : _repoWrapper.clientRepository.Find(x.CreatedBy)?.City.NameEn,
                BioAr = x.PublishType == PublishType.Admin ? _repoWrapper.userRepository.Find(x.CreatedBy)?.BioAr : _repoWrapper.clientRepository.Find(x.CreatedBy)?.BioAr,
                BioEn = x.PublishType == PublishType.Admin ? _repoWrapper.userRepository.Find(x.CreatedBy)?.BioEn : _repoWrapper.clientRepository.Find(x.CreatedBy)?.BioEn,
                AudioCount= GetAudioCountByCreatedBy(x.CreatedBy)
            };
        }
        private int GetAudioCountByCreatedBy(int userId)
        {
            return _repoWrapper.audioRepository.List().Where(x => x.CreatedBy == userId && x.IsDeleted != true).Count();
        }
        public void CreateAudio(Audio Audio)
        {
            _repoWrapper.audioRepository.Add(Audio);
        }

        public void UpdateAudio(Audio Audio)
        {
            _repoWrapper.audioRepository.Update(Audio);
        }
        public void DeleteAudio(int id)
        {
            Audio audio = _repoWrapper.audioRepository.Find(id);
            audio.IsDeleted = true;
            UpdateAudio(audio);
            SaveAudio();
        }

        public void SaveAudio()
        {
            _repoWrapper.Save();
        }

        public List<AudioViewModel> GetAudiosData(int count = 0)
        {
            List<AudioViewModel> list = GetAudioViewModels(_repoWrapper.audioRepository.List().Where(x => x.IsActive == true).ToList());
            return count == 0 ? list : list.Take(count).ToList();
        }

        public List<AudioViewModel> GetAudioViewModels(List<Audio> audios)
        { 
            return audios.Select(x => new AudioViewModel
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
                PublisherImage = x.PublishType == PublishType.Admin ? "logo.png" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.Image,
                CategoryNameAr = x.Category.NameAr,
                CategoryNameEn = x.Category.NameEn,
                AudioTypeNameAr = x.AudioType.NameAr,
                AudioTypeNameEn = x.AudioType.NameEn,
                CategoryId = x.CategoryId,
                TypeId = x.AudioTypeId,
                ClientLikeIds = x.AudioActions.Where(x => x.Like == true).Select(x => x.ClientId).ToList(),
                PlaylistClientIds = x.PlaylistAudios.Select(x => x.ClientPlaylist.ClientId).ToList(),                
                CreationDate=x.CreationDate.ToString("MM/dd/yyyy hh:mm tt"),
                DescriptionAr=x.DescriptionAr,
                DescriptionEn=x.DescriptionEn,
                PublishType=x.PublishType,
                UploadType=x.UploadType,
                CreatedBy=x.CreatedBy,
               //AudioComments= audioCommentService.GetAudioComments(_protector.Protect(x.AudioId.ToString())), CurrentUser == null ? 0 : CurrentUser.UserId)
            }).ToList();
        }


            #endregion


        }

    public interface IAudioService
    {
        List<Audio> GetAudios(int count = 0);

        List<AudioViewModel> GetAudiosData(int count = 0);
        List<AudioViewModel> GetAudioViewModels(List<Audio> audios);
        AudioViewModel GetAudio(int id);
        void CreateAudio(Audio Audio);
        void UpdateAudio(Audio Audio);
        void DeleteAudio(int id);
        void SaveAudio();
    }
}

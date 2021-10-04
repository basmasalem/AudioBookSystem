using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Service
{

    public class PodcastService : IPodcastService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;
        public PodcastService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
        }

        #region IPodcastService Members
        
        public PodcastViewModel GetPodcast(int id)
        {
            var x= _repoWrapper.podcastRepository.Find(id);
            return new PodcastViewModel
            {
                PodcastId = x.PodcastId,
                Attachment = x.Attachment,
                Image = x.Image,
                StartDate = x.StartDate,
                CreatedBy = x.CreatedBy,
                PublishType = x.PublishType,
                Url = x.Url,
                NameAr = x.NameAr,
                NameEn = x.NameEn,
                DescAr = x.DescAr,
                DescEn = x.DescEn,
                ShortDescAr= Regex.Replace(x.DescAr, "<.*?>", string.Empty),
                ShortDescEn= Regex.Replace(x.DescEn, "<.*?>", string.Empty),
                IsActive = x.IsActive,
                Type = x.Type,
                AudioCount=x.PodcastAudios.Where(z=>z.IsDeleted!=true ).Count(),
                ParticipantCount=x.PodcastParticipants.Where(z => z.IsDeleted != true ).Count(),
                ParticipantIds = x.PodcastParticipants.Where(z => z.IsDeleted != true).Select(z=> z.ClientId).ToList(),
                Key = _protector.Protect(x.PodcastId.ToString())
            };
        }

        public void CreatePodcast(Podcast Podcast)
        {
            _repoWrapper.podcastRepository.Add(Podcast);
        }

        public void UpdatePodcast(Podcast Podcast)
        {
            _repoWrapper.podcastRepository.Update(Podcast);
        }
        public void DeletePodcast(int id)
        {
            Podcast Podcast = _repoWrapper.podcastRepository.Find(id);
            Podcast.IsDeleted = true;
            UpdatePodcast(Podcast);
        }

        public void SavePodcast()
        {
            _repoWrapper.Save();
        }

        public List<PodcastViewModel> GetPodcasts(int count = 0)
        {
            List<PodcastViewModel> list = _repoWrapper.podcastRepository.List().Where(x=>x.IsActive==true).Select(x => new PodcastViewModel
            {
                PodcastId = x.PodcastId,
                Attachment = x.Attachment,
                Image = x.Image,
                StartDate = x.StartDate,
                Url = x.Url,
                NameAr =  x.NameAr,
                NameEn=x.NameEn,
                DescAr = Regex.Replace(x.DescAr, "<.*?>", string.Empty),
                DescEn =  Regex.Replace(x.DescEn, "<.*?>", string.Empty),
                AudioCount = x.PodcastAudios.Where(a =>  a.IsDeleted != true).Count(),
                ParticipantCount = x.PodcastParticipants.Where(a => a.IsDeleted != true).Count(),
                Key=_protector.Protect(x.PodcastId.ToString()),
                Type=x.Type
                

            }).ToList();
            return count == 0 ? list : list.Take(count).ToList();
        }

        public List<SelectListItem> GetSelectGeneralPodcasts(int UserId, int langId)
        {
            return _repoWrapper.podcastRepository.List().Where(x=> (x.Type==PodcastType.Public &&x.PodcastParticipants.ToList().Where(x=>x.ClientId==UserId).Count()!=0 ) || 
            (x.Type==PodcastType.Special&&x.CreatedBy==UserId)).Select(x => new SelectListItem
            {
                Text = langId == 1 ? x.NameAr : x.NameEn,
                Value = x.PodcastId.ToString()
            }).ToList();
        }

        public Podcast CheckNameAr(string Name)
        {
            return _repoWrapper.podcastRepository.CheckNameAr(Name);
        }

        public Podcast CheckNameEn(string Name)
        {
            return _repoWrapper.podcastRepository.CheckNameEn(Name);
        }

        public void CreatePodcastParticipant(PodcastParticipant model)
        {
            _repoWrapper.podcastParticipantRepository.Add(model);
        }

        public void UpdatePodcastParticipant(PodcastParticipant model)
        {
            _repoWrapper.podcastParticipantRepository.Update(model);
        }

        public PodcastParticipant GetPodcastParticipantByClient(int PodcastId, int ClientId)
        {
            return _repoWrapper.podcastParticipantRepository.List().FirstOrDefault(x => x.ClientId == ClientId && x.PodcastId == PodcastId);
        }
        #endregion


    }

    public interface IPodcastService
    {
        List<PodcastViewModel> GetPodcasts(int count = 0);
        PodcastViewModel GetPodcast(int id);
        void CreatePodcast(Podcast Podcast);
        void UpdatePodcast(Podcast Podcast);
        void CreatePodcastParticipant(PodcastParticipant model);
        void UpdatePodcastParticipant(PodcastParticipant model);
        PodcastParticipant GetPodcastParticipantByClient(int PodcastId, int ClientId);
        void DeletePodcast(int id);
        Podcast CheckNameAr(string Name);
        Podcast CheckNameEn(string Name);

        void SavePodcast();
        List<SelectListItem> GetSelectGeneralPodcasts(int UserId,int langId);
    }
}

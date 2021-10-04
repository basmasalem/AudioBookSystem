using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{

    public class AudioTypeService : IAudioTypeService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public AudioTypeService(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }

        #region IAudioTypeService Members
        public List<AudioType> GetAudioTypes(int count=0)
        {
            List<AudioType> list = _repoWrapper.audioTypeRepository.List().ToList();
            return count == 0 ? list : list.Take(count).ToList();
        }
        public AudioType GetAudioType(int id)
        {
            return _repoWrapper.audioTypeRepository.Find(id);
        }

        public void CreateAudioType(AudioType AudioType)
        {
            _repoWrapper.audioTypeRepository.Add(AudioType);
        }

        public void UpdateAudioType(AudioType AudioType)
        {
            _repoWrapper.audioTypeRepository.Update(AudioType);
        }

        public void DeleteAudioType(int id)
        {
            AudioType audioType = GetAudioType(id);
            audioType.IsDeleted = true;
            UpdateAudioType(audioType);
            SaveAudioType();
        }

        public void SaveAudioType()
        {
            _repoWrapper.Save();
        }

        public List<SelectListItem> GetSelectTypes(int langId)
        {
            return _repoWrapper.audioTypeRepository.List().Select(x => new SelectListItem
            {
                Text = langId == 1 ? x.NameAr : x.NameEn,
                Value = x.AudioTypeId.ToString()
            }).ToList();
        }
        #endregion


    }

    public interface IAudioTypeService
    {
        List<AudioType> GetAudioTypes(int count=0);
        List<SelectListItem> GetSelectTypes(int langId);
        AudioType GetAudioType(int id);
        void CreateAudioType(AudioType AudioType);
        void UpdateAudioType(AudioType AudioType);
        void SaveAudioType();
    }
}

using Core.Data;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public class SettingService : ISettingService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public SettingService(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }

        public string GetDesc(int langId)
        {
            var model = _repoWrapper.settingRepository.List().FirstOrDefault();
            return model != null ? langId==1? model.DescAr: model.DescEn : string.Empty;
        }

        public string GetEmail()
        {
            var model = _repoWrapper.settingRepository.List().FirstOrDefault();
            return model != null ? model.Email : string.Empty;
        }

        public Setting GetSetting()
        {
            return _repoWrapper.settingRepository.List().FirstOrDefault();
        }

        public AboutUs GetAboutUs()
        {
            return _repoWrapper.aboutUsRepository.GetAboutUs();
        }

        public void AddContactUs(ContactUs model)
        {
             _repoWrapper.contactUsRepository.Add(model);
        }

        public void Save()
        {
            _repoWrapper.Save();
        }

    }
    public interface ISettingService
    {
        Setting GetSetting();
        string GetEmail();
        string GetDesc(int langId);

        AboutUs GetAboutUs();
        void AddContactUs(ContactUs model);
        void Save();
    }
}

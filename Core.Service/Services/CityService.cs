using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public class CityService : ICityService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;

     
        public CityService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
        }

        #region ICityService Members
        
        public City GetCity(int id)
        {
            return _repoWrapper.cityRepository.Find(id);
        }

        public void CreateCity(City City)
        {
            _repoWrapper.cityRepository.Add(City);
        }

        public void UpdateCity(City City)
        {
            _repoWrapper.cityRepository.Update(City);
        }
        public void DeleteCity(int id)
        {
            City City = GetCity(id);
            City.IsDeleted = true;
            UpdateCity(City);
            SaveCity();
        }

        public void SaveCity()
        {
            _repoWrapper.Save();
        }

        public List<SelectListItem> GetSelectCities(int langId)
        {
            return _repoWrapper.cityRepository.List().Select(x => new SelectListItem
            {
                Text=langId==1?x.NameAr:x.NameEn,
                Value=x.CityId.ToString()
            }).ToList();
        }

    
        public int GetCityId(string Name)
        {
            var model = _repoWrapper.cityRepository.List().Where(x => x.NameAr.Contains(Name) || x.NameEn.Contains(Name)).FirstOrDefault();
            return model!=null? model.CityId: 0;
        }
        #endregion


    }

    public interface ICityService
    {
       
        List<SelectListItem> GetSelectCities(int langId);
        City GetCity(int id);
        int GetCityId(string Name);

        void CreateCity(City City);
        void UpdateCity(City City);
        void DeleteCity(int id);
        void SaveCity();
    }
}

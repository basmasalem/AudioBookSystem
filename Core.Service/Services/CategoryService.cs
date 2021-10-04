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
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;

     
        public CategoryService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
        }

        #region ICategoryService Members
        public List<CategoryViewModel> GetCategories( int count = 0)
        {
            List<CategoryViewModel> list = _repoWrapper.categoryRepository.List().Select(x => new CategoryViewModel
            {
                CategoryId = x.CategoryId,
                NameAr = x.NameAr,
                NameEn = x.NameEn,
                Image = x.Image,
                Key=_protector.Protect(x.CategoryId.ToString())
            }).ToList();
            return count == 0 ? list : list.Take(count).ToList();
        }
        public Category GetCategory(int id)
        {
            return _repoWrapper.categoryRepository.Find(id);
        }

        public void CreateCategory(Category Category)
        {
            _repoWrapper.categoryRepository.Add(Category);
        }

        public void UpdateCategory(Category Category)
        {
            _repoWrapper.categoryRepository.Update(Category);
        }
        public void DeleteCategory(int id)
        {
            Category Category = GetCategory(id);
            Category.IsDeleted = true;
            UpdateCategory(Category);
            SaveCategory();
        }

        public void SaveCategory()
        {
            _repoWrapper.Save();
        }

        public List<SelectListItem> GetSelectCategories(int langId)
        {
            return _repoWrapper.categoryRepository.List().Select(x => new SelectListItem
            {
                Text=langId==1?x.NameAr:x.NameEn,
                Value=x.CategoryId.ToString()
            }).ToList();
        }

        public List<AudioViewModel> GetAudiosData( int CategoryId, int count = 0)
        {
            List<AudioViewModel> list = _repoWrapper.audioRepository.List().Where(x => x.IsActive == true && x.CategoryId== CategoryId).ToList().Select(x => new AudioViewModel
            {
                AudioId = x.AudioId,
                AudioSrc = x.AudioSrc,
                BookImage = x.BookImage,
                BookNameAr = x.BookNameAr,
                BookNameEn = x.BookNameEn,
                AuthorNameAr = x.AuthorNameAr,
                AuthorNameEn = x.AuthorNameEn,
                PublisherNameAr = x.PublishType == PublishType.Admin ? "أديو كتاب" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.FullName,
                PublisherNameEn = x.PublishType == PublishType.Admin ? "Audio Ketab" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.FullNameEn,
                PublisherImage = x.PublishType == PublishType.Admin ? "logo.png" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.Image,
                CategoryNameAr=x.Category.NameAr,
                CategoryNameEn = x.Category.NameEn,
                AudioTypeNameAr = x.AudioType.NameAr,
                AudioTypeNameEn =x.AudioType.NameEn,
                Key = _protector.Protect(x.AudioId.ToString()),
                CategoryId = x.CategoryId,
                TypeId = x.AudioTypeId,
                ClientLikeIds = x.AudioActions.Where(x => x.Like == true).Select(x => x.ClientId).ToList(),
                PlaylistClientIds = x.PlaylistAudios.Select(x => x.ClientPlaylist.ClientId).ToList()

            }).ToList();
            return count == 0 ? list : list.Take(count).ToList();
        }

        public int GetCategoryId(string Name)
        {
            var model = _repoWrapper.categoryRepository.List().Where(x => x.NameAr.Contains(Name) || x.NameEn.Contains(Name)).FirstOrDefault();
            return model!=null? model.CategoryId: 0;
        }
        #endregion


    }

    public interface ICategoryService
    {
        List<CategoryViewModel> GetCategories(int count = 0);
        List<SelectListItem> GetSelectCategories(int langId);
        List<AudioViewModel> GetAudiosData(int CategoryId, int count = 0);
        Category GetCategory(int id);
        int GetCategoryId(string Name);

        void CreateCategory(Category Category);
        void UpdateCategory(Category Category);
        void DeleteCategory(int id);
        void SaveCategory();
    }
}

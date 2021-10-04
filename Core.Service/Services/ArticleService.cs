using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{

    public class ArticleService : IArticleService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;
        public ArticleService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
        }

        #region IArticleService Members
        public List<ArticleViewModel> GetArticles( int count =0)
        {
            List<ArticleViewModel> list = _repoWrapper.articleRepository.List().Select(x=>new ArticleViewModel { 
            ArticleId=x.ArticleId,
            ArticleOwnerAr=x.ArticleOwnerAr,
            ArticleOwnerEn = x.ArticleOwnerEn,
            ArticleDate = x.CreationDate,
            DescAr=x.DescAr ,
            DescEn = x.DescEn,
            Image = x.Image,
            NameAr= x.NameAr ,
            NameEn=x.NameEn,
            Key = _protector.Protect(x.ArticleId.ToString())
            }).ToList();
            return count == 0 ? list : list.Take(count).ToList();
        }
        public ArticleViewModel GetArticle(int id)
        {
            var article = _repoWrapper.articleRepository.Find(id);
            return new ArticleViewModel {
                ArticleId = article.ArticleId,
                ArticleOwnerAr = article.ArticleOwnerAr,
                ArticleOwnerEn = article.ArticleOwnerEn,
                ArticleDate = article.CreationDate,
                DescAr = article.DescAr,
                DescEn = article.DescEn,
                Image = article.Image,
                NameAr = article.NameAr,
                NameEn = article.NameEn,
                Key = _protector.Protect(article.ArticleId.ToString())
            };
        }

        public void CreateArticle(Article Article)
        {
            _repoWrapper.articleRepository.Add(Article);
        }

        public void UpdateArticle(Article Article)
        {
            _repoWrapper.articleRepository.Update(Article);
        }
        public void DeleteArticle(int id)
        {
            Article Article = _repoWrapper.articleRepository.Find(id);
            Article.IsDeleted = true;
            UpdateArticle(Article);
            SaveArticle();
        }

        public void SaveArticle()
        {
            _repoWrapper.Save();
        }
        #endregion


    }

    public interface IArticleService
    {
        List<ArticleViewModel> GetArticles(int count=0);
        ArticleViewModel GetArticle(int id);
        void CreateArticle(Article Article);
        void UpdateArticle(Article Article);
        void DeleteArticle(int id);
        void SaveArticle();
    }
}

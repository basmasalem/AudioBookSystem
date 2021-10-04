using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class ArticleRepository : IRepository<Article>, IArticleRepository
    {
        private readonly AudioKetabDbContext _db;
        public ArticleRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(Article entity)
        {
            _db.Articles.Add(entity);
        }

        public Article CheckNameAr(string name)
        {
            return _db.Articles.FirstOrDefault(x => x.NameAr.Equals(name.Trim()) && x.IsDeleted != true);
        }

        public Article CheckNameEn(string name)
        {
            return _db.Articles.FirstOrDefault(x => x.NameEn.Equals(name.Trim()) && x.IsDeleted != true);

        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(Article entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public Article Find(int id)
        {
            return _db.Articles.Find(id);
        }

        public int GetArticleCount()
        {
            return List().Count();
        }

        public IQueryable<Article> List()
        {
            return _db.Articles.Where(x => x.IsDeleted != true).OrderByDescending(x=>x.CreationDate);
        }

        public void Update(Article entity)
        {
            _db.Update(entity);
        }
    }
    public interface IArticleRepository : IRepository<Article>
    {

        public Article CheckNameAr(string name);
        public Article CheckNameEn(string name);
        public int GetArticleCount();
    }
}

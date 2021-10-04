using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
   public class CategoryRepository : IRepository<Category>, ICategoryRepository
    {
        private readonly AudioKetabDbContext _db;
        public CategoryRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(Category entity)
        {
            _db.Categories.Add(entity);
        }

        public void Delete(Category entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public Category Find(int id)
        {
            return _db.Categories.Find(id);
        }

        public IQueryable<Category> List()
        {
            return _db.Categories.Where(x => x.IsDeleted != true).OrderByDescending(x => x.CreationDate);
        }

        public void Update(Category entity)
        {
            _db.Categories.Update(entity);
        }
        public void Commit()
        {
            _db.SaveChanges();
        }

        public Category CheckNameAr(string name)
        {
            return _db.Categories.FirstOrDefault(x => x.NameAr == name && x.IsDeleted != true);
        }

        public Category CheckNameEn(string name)
        {
            return _db.Categories.FirstOrDefault(x => x.NameEn == name && x.IsDeleted != true);
        }

        public int GetCategoryCount()
        {
            return List().Count();
        }

        public IList<CategoryViewModel> GetLatestCategory()
        {
            return _db.Categories.Where(x => x.IsDeleted != true && x.IsActive == true).OrderByDescending(x => x.CreationDate).Take(5).Select(x=> new CategoryViewModel
            { 
            CategoryId=x.CategoryId,
            NameAr=x.NameAr,
            NameEn=x.NameEn
            
            }).ToList();
        }
    }

    public interface ICategoryRepository : IRepository<Category>
    {
        public Category CheckNameAr(string name);
        public Category CheckNameEn(string name);
        public int GetCategoryCount();
        public IList<CategoryViewModel> GetLatestCategory();

    }
}

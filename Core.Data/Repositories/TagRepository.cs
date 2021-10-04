using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class TagRepository : IRepository<Tag>, ITagRepository
    {
        private readonly AudioKetabDbContext _db;
        public TagRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(Tag entity)
        {
            _db.Tags.Add(entity);
        }

        public Tag CheckNameAr(string name)
        {
            return _db.Tags.FirstOrDefault(x => x.NameAr.Equals(name.Trim()) && x.IsDeleted != true);
        }

        public Tag CheckNameEn(string name)
        {
            return _db.Tags.FirstOrDefault(x => x.NameEn.Equals(name.Trim()) && x.IsDeleted != true);

        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(Tag entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public Tag Find(int id)
        {
            return _db.Tags.Find(id);
        }

        public IList<TagDataVM> GetLatestTags()
        {
            return _db.Tags.Where(x => x.IsDeleted != true && x.IsActive == true).OrderByDescending(x => x.CreationDate).Take(5).Select(x=> new TagDataVM { 
            Image=x.Image,
            NameAr=x.NameAr,
            NameEn=x.NameEn,
            TagId=x.TagId
            
            }).ToList();
        }

        public int GetTagCount()
        {
            return List().Count();
        }

        public IQueryable<Tag> List()
        {
            return _db.Tags.Where(x => x.IsDeleted != true).OrderByDescending(x => x.CreationDate);
        }

        public IList<TagDataVM> ListTags()
        {
            return _db.Tags.Where(x => x.IsDeleted != true).OrderByDescending(x => x.CreationDate).Select(x => new TagDataVM
            {
                Image = x.Image,
                NameAr = x.NameAr,
                NameEn = x.NameEn,
                TagId = x.TagId,
                IsActive=x.IsActive,
                CreationDate=x.CreationDate

            }).ToList();
        }

        public void Update(Tag entity)
        {
            _db.Update(entity);
        }
    }
    public interface ITagRepository : IRepository<Tag>
    {

        public Tag CheckNameAr(string name);
        public Tag CheckNameEn(string name);
        public int GetTagCount();

        public IList<TagDataVM> GetLatestTags();
        public IList<TagDataVM> ListTags();

    }
}

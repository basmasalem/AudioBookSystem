using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class AboutUsRepository : IRepository<AboutUs>, IAboutUsRepository
    {
        private readonly AudioKetabDbContext _db;
        public AboutUsRepository(AudioKetabDbContext db)
        {
            _db = db;
        }

        public void Add(AboutUs entity)
        {
            _db.AboutUs.Add(entity);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(AboutUs entity)
        {
            _db.AboutUs.Remove(entity);
        }

        public AboutUs Find(int id)
        {
            return _db.AboutUs.Find(id);
        }

        public AboutUs GetAboutUs()
        {
            var aboutUs = _db.AboutUs.FirstOrDefault();
            return aboutUs ?? new AboutUs() { Image="0"};
        }

        public IQueryable<AboutUs> List()
        {
            return _db.AboutUs;
        }

        public void Update(AboutUs entity)
        {
            _db.AboutUs.Update(entity);
        }
    }
    public interface IAboutUsRepository : IRepository<AboutUs>
    {
        public AboutUs GetAboutUs();
    }
}

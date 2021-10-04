using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
   public class ContactUsRepository : IRepository<ContactUs>, IContactUsRepository
    {
        private readonly AudioKetabDbContext _db;
        public ContactUsRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(ContactUs entity)
        {
            _db.ContactUs.Add(entity);
        }

        public void Delete(ContactUs entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public ContactUs Find(int id)
        {
            return _db.ContactUs.Find(id);
        }

        public IQueryable<ContactUs> List()
        {
            return _db.ContactUs.OrderByDescending(x=>x.ContactUsId).Where(x => x.IsDeleted != true);
        }

        public void Update(ContactUs entity)
        {
            _db.ContactUs.Update(entity);
        }
        public void Commit()
        {
            _db.SaveChanges();
        }



    }

    public interface IContactUsRepository : IRepository<ContactUs>
    {


    }
}

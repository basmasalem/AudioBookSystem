using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
   public class CityRepository : IRepository<City>, ICityRepository
    {
        private readonly AudioKetabDbContext _db;
        public CityRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(City entity)
        {
            _db.Cities.Add(entity);
        }

        public void Delete(City entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public City Find(int id)
        {
            return _db.Cities.Find(id);
        }

        public IQueryable<City> List()
        {
            return _db.Cities.Where(x => x.IsDeleted != true).OrderByDescending(x => x.CreationDate);
        }

        public void Update(City entity)
        {
            _db.Cities.Update(entity);
        }
        public void Commit()
        {
            _db.SaveChanges();
        }

        public City CheckNameAr(string name)
        {
            return _db.Cities.FirstOrDefault(x => x.NameAr == name && x.IsDeleted != true);
        }

        public City CheckNameEn(string name)
        {
            return _db.Cities.FirstOrDefault(x => x.NameEn == name && x.IsDeleted != true);
        }

        public int GetCityCount()
        {
            return List().Count();
        }

        
    }

    public interface ICityRepository : IRepository<City>
    {
        public City CheckNameAr(string name);
        public City CheckNameEn(string name);
        public int GetCityCount();
       

    }
}

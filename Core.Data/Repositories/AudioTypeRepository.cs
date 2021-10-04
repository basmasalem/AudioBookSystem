using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
   public class AudioTypeRepository : IRepository<AudioType>, IAudioTypeRepository
    {
        private readonly AudioKetabDbContext _db;
        public AudioTypeRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(AudioType entity)
        {
            _db.AudioTypes.Add(entity);
        }

        public void Delete(AudioType entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public AudioType Find(int id)
        {
            return _db.AudioTypes.Find(id);
        }

        public IQueryable<AudioType> List()
        {
            return _db.AudioTypes.Where(x => x.IsDeleted != true).OrderByDescending(x => x.CreationDate);
        }

        public void Update(AudioType entity)
        {
            _db.AudioTypes.Update(entity);
        }
        public void Commit()
        {
            _db.SaveChanges();
        }

        public AudioType CheckNameAr(string name)
        {
            return _db.AudioTypes.FirstOrDefault(x => x.NameAr == name && x.IsDeleted != true);
        }

        public AudioType CheckNameEn(string name)
        {
            return _db.AudioTypes.FirstOrDefault(x => x.NameEn == name && x.IsDeleted != true);
        }

        public int GetAudioTypeCount()
        {
            return List().Count();
        }
    }

    public interface IAudioTypeRepository : IRepository<AudioType>
    {
        public AudioType CheckNameAr(string name);
        public AudioType CheckNameEn(string name);

        public int GetAudioTypeCount();

    }
}

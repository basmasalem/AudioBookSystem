using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class AudioActionRepository : IRepository<AudioAction>, IAudioActionRepository
    {
        private readonly AudioKetabDbContext _db;
        public AudioActionRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(AudioAction entity)
        {
            _db.AudioActions.Add(entity);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(AudioAction entity)
        {
            _db.AudioActions.Remove(entity);
        }

        public AudioAction Find(int id)
        {
            return _db.AudioActions.Find(id);
        }

        public IQueryable<AudioAction> List()
        {
            return _db.AudioActions;
        }

        public void Update(AudioAction entity)
        {
            _db.AudioActions.Update(entity);
        }
    }
    public interface IAudioActionRepository : IRepository<AudioAction>
    {
    }
}

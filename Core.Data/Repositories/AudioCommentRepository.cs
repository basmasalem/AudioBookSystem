using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class AudioCommentRepository : IRepository<AudioComment>, IAudioCommentRepository
    {
        private readonly AudioKetabDbContext _db;
        public AudioCommentRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(AudioComment entity)
        {
            _db.AudioComments.Add(entity);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(AudioComment entity)
        {
            _db.AudioComments.Remove(entity);
        }

        public AudioComment Find(int id)
        {
            return _db.AudioComments.Find(id);
        }

        public IQueryable<AudioComment> List()
        {
            return _db.AudioComments;
        }

        public void Update(AudioComment entity)
        {
            _db.AudioComments.Update(entity);
        }
    }
    public interface IAudioCommentRepository : IRepository<AudioComment>
    {
    }
}

using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class PlaylistAudioRepository : IRepository<PlaylistAudio>, IPlaylistAudioRepository
    {
        private readonly AudioKetabDbContext _db;
        public PlaylistAudioRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(PlaylistAudio entity)
        {
            _db.PlaylistAudios.Add(entity);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(PlaylistAudio entity)
        {
            _db.PlaylistAudios.Remove(entity);
        }

        public PlaylistAudio Find(int id)
        {
            return _db.PlaylistAudios.Find(id);
        }

        public IQueryable<PlaylistAudio> List()
        {
            return _db.PlaylistAudios;
        }

        public void Update(PlaylistAudio entity)
        {
            _db.PlaylistAudios.Update(entity);
        }
    }
    public interface IPlaylistAudioRepository : IRepository<PlaylistAudio>
    {

    }
}

using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class ClientPlaylistRepository : IClientPlaylistRepository, IRepository<ClientPlaylist>
    {
        private readonly AudioKetabDbContext _db;
        public ClientPlaylistRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(ClientPlaylist entity)
        {
            _db.ClientPlaylists.Add(entity);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(ClientPlaylist entity)
        {
            if(entity.PlaylistAudios.Count>0)
            {
                _db.PlaylistAudios.RemoveRange(entity.PlaylistAudios);
            }
            _db.ClientPlaylists.Remove(entity);
        }

        public ClientPlaylist Find(int id)
        {
            return _db.ClientPlaylists.Find(id);
        }

        public IQueryable<ClientPlaylist> List()
        {
            return _db.ClientPlaylists.Where(x => x.IsDeleted != true);
        }

        public void Update(ClientPlaylist entity)
        {
            _db.ClientPlaylists.Update(entity);
        }
    }
    public interface IClientPlaylistRepository : IRepository<ClientPlaylist>
    {

    }
}

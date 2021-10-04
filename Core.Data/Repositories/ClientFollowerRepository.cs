using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class ClientFollowerRepository : IRepository<ClientFollower>, IClientFollowerRepository
    {
        private readonly AudioKetabDbContext _db;
        public ClientFollowerRepository(AudioKetabDbContext db)
        {
            _db = db;
        }

        public void Add(ClientFollower entity)
        {
            _db.ClientFollowers.Add(entity);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(ClientFollower entity)
        {
            _db.ClientFollowers.Remove(entity);
        }

        public ClientFollower Find(int id)
        {
            return _db.ClientFollowers.Find(id);
        }

 

        public IQueryable<ClientFollower> List()
        {
            return _db.ClientFollowers.Where(x=>x.IsDeleted!=true);
        }

        public void Update(ClientFollower entity)
        {
            _db.ClientFollowers.Update(entity);
        }
    }
    public interface IClientFollowerRepository : IRepository<ClientFollower>
    {
        
    }
}

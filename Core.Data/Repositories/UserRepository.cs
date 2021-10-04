using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class UserRepository : IRepository<User>, IUserRepository
    {
        private readonly AudioKetabDbContext _db;
        public UserRepository(AudioKetabDbContext db)
        {
            _db = db;
        }

        public void Add(User entity)
        {
            _db.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public User Find(int id)
        {
            return _db.Users.SingleOrDefault(x => x.UserId == id);
        }

        public IQueryable<User> List()
        {
            return _db.Users.Where(x => x.IsDeleted != true).OrderByDescending(x => x.CreationDate) ;
        }

        public void Update(User entity)
        {
            _db.Users.Update(entity);
        }
        public void Commit()
        {
            _db.SaveChanges();
        }
        public User ValidateUser(string email ,string password)
        {
            return _db.Users.FirstOrDefault(x => x.Email==email && x.Password==password);
        }
        public User ValidateUserEmail(string email)
        {
            return _db.Users.FirstOrDefault(x => x.Email == email);
        }
    }


    public interface IUserRepository : IRepository<User>
    {
        public User ValidateUser(string email, string password);
        public User ValidateUserEmail(string email);

    }
}

using Core.Data;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public UserService(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }

        #region IUserService Members
        public List<User> GetUsers(int count=0)
        {
            List<User> list = _repoWrapper.userRepository.List().ToList();
            return count == 0 ? list : list.Take(count).ToList();
        }
        public User GetUser(int id)
        {
            return _repoWrapper.userRepository.Find(id);
        }

        public void CreateUser(User User)
        {
            _repoWrapper.userRepository.Add(User);
        }

        public void UpdateUser(User User)
        {
            _repoWrapper.userRepository.Update(User);
        }
        public void DeleteUser(int id)
        {
            User User = GetUser(id);
            User.IsDeleted = true;
            UpdateUser(User);
            SaveUser();
        }

        public void SaveUser()
        {
            _repoWrapper.Save();
        }
        #endregion

    }

    public interface IUserService
    {
        List<User> GetUsers(int count=0);
        User GetUser(int id);
        void CreateUser(User User);
        void UpdateUser(User User);
        void DeleteUser(int id);
        void SaveUser();
    }
}

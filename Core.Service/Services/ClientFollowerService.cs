using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
  public  class ClientFollowerService : IClientFollowerService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;


        public ClientFollowerService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");

        }

        #region IClientService Members

        public List<ReaderVM> GetSubscribers(int clientId)
        {
            return _repoWrapper.clientFollowerRepository.List().Where(x=>x.FollowerId==clientId).Select(x => new ReaderVM
            {
                Id=x.ClientFollowerId,
                Key= _protector.Protect(x.SubscribeId.ToString()),
                ClientId = x.SubscribeId,
                BioAr = x.Client.BioAr,
                BioEn = x.Client.BioEn,
                FullNameAr = x.Client.FullName,
                FullNameEn = x.Client.FullNameEn,
                Image = x.Client.Image
            }).ToList();
        }

        public List<ReaderVM> GetFollowers(int clientId)
        {
            return _repoWrapper.clientFollowerRepository.List().Where(x => x.SubscribeId == clientId).Select(x => new ReaderVM
            {
                Id = x.ClientFollowerId,
                Key = _protector.Protect(x.SubscribeId.ToString()),
                ClientId = x.SubscribeId,
                BioAr = x.Client.BioAr,
                BioEn = x.Client.BioEn,
                FullNameAr = x.Client.FullName,
                FullNameEn = x.Client.FullNameEn,
                Image = x.Client.Image
            }).ToList();
        }

        public void DeleteClientSubscriber(int ClientId,int id)
        {
            var ClientFollower = _repoWrapper.clientFollowerRepository.List().Where(x => x.FollowerId == ClientId && x.SubscribeId == id && x.IsDeleted != true).FirstOrDefault();
            if (ClientFollower != null)
            {
                _repoWrapper.clientFollowerRepository.Delete(ClientFollower);
                _repoWrapper.clientFollowerRepository.Commit();
            }

        }

        public void Follow(int FollowerId, int SubscriberId)
        {
            _repoWrapper.clientFollowerRepository.Add(new ClientFollower { FollowerId = FollowerId, FollowingDate = DateTime.Now, SubscribeId = SubscriberId });
            _repoWrapper.clientFollowerRepository.Commit();
        }

    
        #endregion
    }

    public interface IClientFollowerService
    {
        List<ReaderVM> GetSubscribers(int clientId);
        List<ReaderVM> GetFollowers(int clientId);
        void DeleteClientSubscriber(int ClientId, int id);

        void Follow(int FollowerId,int SubscriberId);
        //void UnFollow(int ClientSubscriberId);


    }
}

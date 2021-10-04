using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class ClientRepository : IRepository<Client>, IClientRepository
    {
        private readonly AudioKetabDbContext _db;
        public ClientRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(Client entity)
        {
            _db.Clients.Add(entity);
        }

        public void Delete(Client entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public Client Find(int id)
        {
            return _db.Clients.Find(id);
        }

        public IQueryable<Client> List()
        {
            return _db.Clients.Where(x => x.IsDeleted != true).OrderByDescending(x => x.CreationDate);
        }

        public void Update(Client entity)
        {
            _db.Clients.Update(entity);
        }
        public void Commit()
        {
            _db.SaveChanges();
        }

        public Client CheckEmail(string email)
        {
            return _db.Clients.FirstOrDefault(x => x.Email == email && x.IsDeleted != true);
        }
        public Client CheckNameAr(string name)
        {
            return _db.Clients.FirstOrDefault(x => x.FirstName == name && x.IsDeleted != true);
        }

        public Client CheckNameEn(string name)
        {
            return _db.Clients.FirstOrDefault(x => x.FirstName == name && x.IsDeleted != true);
        }

        public int GetClientCount()
        {
            return List().Count();
        }

        public IList<ClientPlayListViewModel> GetClientPlayList(int ClientId)
        {
            return _db.ClientPlaylists.Where(x => x.ClientId == ClientId && x.IsDeleted != true).Select(x => new ClientPlayListViewModel
            {
                NameAr = x.NameAr,
                Audios = x.PlaylistAudios.Select(p => new ClientPlayListAudioViewModel
                {
                    NameAr = p.Audio.BookNameAr,
                    Image = p.Audio.BookImage,
                    AudioSrc = p.Audio.AudioSrc
                }).ToList()

            }).ToList();
        }

        public IList<ClientTagVM> GetClientTags(int ClientId)
        {
            return _db.ClientTags.Where(x => x.IsDeleted != true && x.ClientId == ClientId).Select(x => new ClientTagVM
            {
                Name = x.Tag.NameAr,
                Image = x.Tag.Image
            }).ToList();
        }

        public ClientDataVM GetClientData(int Id)
        {
            var client = Find(Id);
            return client != null ? new ClientDataVM
            {
                ClientId = client.ClientId,
                CityId = client.CityId,
                City=client.City?.NameAr,
                Email = client.Email,
                FirstName = client.FirstName,
                FullName = client.FullName,
                Image = client.Image,
                LastName = client.LastName,
                Password = client.Password,
                Phone = client.Phone,
                RegisterationDate = client.RegisterationDate
            } : null;
        }

        public IList<ClientTag> GetReaders()
        {
            return _db.ClientTags.Where(x => x.IsDeleted != true && x.IsActive == true && x.TagId == 1).OrderByDescending(x => x.CreationDate).ToList();
        }
    }

    public interface IClientRepository : IRepository<Client>
    {
        public Client CheckNameAr(string name);
        public Client CheckNameEn(string name);
        public Client CheckEmail(string email);
        public int GetClientCount();
        public IList<ClientPlayListViewModel> GetClientPlayList(int ClientId);
        public IList<ClientTagVM> GetClientTags(int ClientId);
        public IList<ClientTag> GetReaders( );

        public ClientDataVM GetClientData(int Id);

    }
}

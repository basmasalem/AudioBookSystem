using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public class ClientService : IClientService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;
        private readonly IAudioService _audioService;

        public ClientService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider, IAudioService audioService)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
            _audioService = audioService;
        }

        #region IClientService Members
        public List<Client> GetClients(int count = 0)
        {
            List<Client> list = _repoWrapper.clientRepository.List().ToList();
            return count == 0 ? list : list.Take(count).ToList();
        }
        public Client GetClient(int id)
        {
            return _repoWrapper.clientRepository.Find(id);
        }
        public ClientViewModel GetClientData(int ClientId, int CurrentUserId)
        {
            Client client = GetClient(ClientId);
            return new ClientViewModel
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                FullName = client.FullName,
                FullNameEn = client.FullNameEn,
                BioAr = client.BioAr,
                BioEn = client.BioEn,
                ClientId = client.ClientId,
                CityId = client.CityId,
                CityAr = client.City?.NameAr,
                CityEn = client.City?.NameEn,
                Email = client.Email,
                Image = client.Image,
                Phone = client.Phone,
                Password=client.Password,

                AudioCount = GetClientAudios(ClientId).Count,
                IsFollowing=client.ClientFollowers.ToList().Select(a=>a.FollowerId).Contains(CurrentUserId),
                CanFollowing=(client.ClientId != CurrentUserId && CurrentUserId!=0 && !client.ClientFollowers.Where(x=>x.IsDeleted!=true).ToList().Select(a => a.FollowerId).Contains(CurrentUserId)),
               
                Tags = client.ClientTags.Where(x => x.IsDeleted != true && x.IsActive == true).Select(x => new TagDataVM
                {
                    Image = x.Tag.Image,
                    NameAr = x.Tag.NameAr,
                    NameEn = x.Tag.NameEn,
                    TagId = x.TagId
                }).ToList(),
                Key = _protector.Protect(ClientId.ToString())
            };
        }

        public List<Audio> GetClientAudios(int clientId)
        {
            List<Audio> list =
                _repoWrapper.audioRepository.List().Where(x => x.IsActive == true && x.PublishType == PublishType.Client && x.CreatedBy == clientId).ToList();

            return list;
        }

        public List<AudioViewModel> GetClientAudioShare(int clientId)
        {
            List<AudioViewModel> list =
                _repoWrapper.audioRepository.List().Where(x => x.IsActive == true && x.PublishType == PublishType.Client && x.CreatedBy == clientId).Select(x => new AudioViewModel
                {
                    AudioId = x.AudioId,
                    BookImage = x.BookImage,
                    CategoryNameAr = x.Category.NameAr,
                    CategoryNameEn = x.Category.NameEn,
                }).ToList();

            return list;
        }
        public List<AudioViewModel> GetClientAudioWithComment(int clientId, int langId, int UserId, int count = 0)
        {
            List<AudioViewModel> list = GetClientAudios(clientId).Select(x => new AudioViewModel
            {
                AudioId = x.AudioId,
                Key = _protector.Protect(x.AudioId.ToString()),
                AudioSrc = x.AudioSrc,
                BookImage = x.BookImage,
                BookNameAr = x.BookNameAr,
                BookNameEn = x.BookNameEn,
                AuthorNameAr = x.AuthorNameAr,
                AuthorNameEn = x.AuthorNameEn,
                PublisherNameAr = x.PublishType == PublishType.Admin ? "أديو كتاب" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.FullName,
                PublisherNameEn = x.PublishType == PublishType.Admin ? "Audio Ketab" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.FullNameEn,
                PublisherImage = x.PublishType == PublishType.Admin ? "logo.png" : _repoWrapper.clientRepository.Find(x.CreatedBy)?.Image,
                CategoryNameAr = x.Category.NameAr,
                CategoryNameEn = x.Category.NameEn,
                AudioTypeNameAr = x.AudioType.NameAr,
                AudioTypeNameEn = x.AudioType.NameEn,
                CategoryId = x.CategoryId,
                TypeId = x.AudioTypeId,
                ClientLikeIds = x.AudioActions.Where(x => x.Like == true).Select(x => x.ClientId).ToList(),
                PlaylistClientIds = x.PlaylistAudios.Select(x => x.ClientPlaylist.ClientId).ToList(),
                CreationDate = x.CreationDate.ToString("MM/dd/yyyy hh:mm tt"),
                DescriptionAr = x.DescriptionAr,
                DescriptionEn = x.DescriptionEn,
                PublishType = x.PublishType,
                UploadType = x.UploadType,
                CreatedBy = x.CreatedBy,
                AudioComments = x.AudioComments.Select(a => new AudioCommentViewModel
                {
                    AudioCommentId = a.AudioCommentId,
                    Key = _protector.Protect(a.AudioCommentId.ToString()),
                    ClientName = a.Client.FullName,
                    Comment = a.Text,
                    ClientImage = a.Client.Image,
                    Duration = returnPeriod(x.CreationDate, langId),
                    CanUpdate = (a.ClientId == UserId ? true : false)
                }).ToList()
            }).ToList();

            return count == 0 ? list : list.Take(count).ToList();
        }


        public string returnPeriod(DateTime dateFrom, int langId)
        {
            var dateTo = DateTime.Now;
            TimeSpan Span = dateTo.Subtract(dateFrom);
            int weeks = 0;
            if (Span.Days <= 7)
            {

                if (Span.Days < 7)
                {
                    if (Span.Days >= 1)
                    {
                        weeks = Span.Days;
                        return langId == 1 ? "منذ" + " " + weeks + " " + "يوم" : weeks + " " + "d" + " " + "ago";
                    }
                    else if (Span.Minutes >= 60)
                    {
                        weeks = Span.Hours;
                        return langId == 1 ? "منذ" + " " + weeks + " " + "ساعه" : weeks + " " + "h" + " " + "ago";
                    }
                    else if (Span.Seconds >= 60)
                    {
                        weeks = Span.Minutes;
                        return langId == 1 ? "منذ" + " " + weeks + " " + "دقيقه" : weeks + " " + "m" + " " + "ago";
                    }
                    else
                    {
                        weeks = Span.Seconds;
                        return langId == 1 ? "منذ" + " " + weeks + " " + "ثانيه" : weeks + " " + "s" + " " + "ago";
                    }

                }
                else
                {
                    weeks = 1;
                    return langId == 1 ? "منذ" + " " + weeks + " " + "اسبوع" : weeks + " " + "w" + " " + "ago";
                }


            }
            else
            {
                int Days = Span.Days - 7 + (int)dateFrom.DayOfWeek;
                int WeekCount = 1;
                int DayCount = 0;

                for (WeekCount = 1; DayCount < Days; WeekCount++)
                {
                    DayCount += 7;
                }

                weeks = WeekCount;
                return langId == 1 ? "منذ" + " " + weeks + " " + "اسبوع" : weeks + " " + "w" + " " + "ago";
            }

        }
        public void CreateClient(Client Client)
        {
            _repoWrapper.clientRepository.Add(Client);
            SaveClient();

        }

        public void UpdateClient(Client Client)
        {
            _repoWrapper.clientRepository.Update(Client);
        }
        public void DeleteClient(int id)
        {
            Client Client = GetClient(id);
            Client.IsDeleted = true;
            UpdateClient(Client);
            SaveClient();
        }

        public void SaveClient()
        {
            _repoWrapper.Save();
        }


        public List<ReaderVM> GetReaders(int count = 0)
        {
            List<ReaderVM> list = _repoWrapper.clientRepository.GetReaders().Select(x => new ReaderVM
            {
                ClientId = x.ClientId,
                Key = _protector.Protect(x.ClientId.ToString()),
                BioAr = x.Client.BioAr,
                BioEn = x.Client.BioEn,
                FullNameAr = x.Client.FullName,
                FullNameEn = x.Client.FullNameEn,
                Image = x.Client.Image
            }).ToList();
            return count == 0 ? list : list.Take(count).ToList();
        }

        public ClientViewModel ValidateClient(string email, string password)
        {
            Client client = _repoWrapper.clientRepository.List().FirstOrDefault(x => x.Email == email && x.Password == password  && x.IsDeleted != true);

            return client == null ? null : new ClientViewModel
            {
                ClientId = client.ClientId,
                CityAr = client.City?.NameAr,
                CityEn = client.City?.NameEn,
                FirstName = client.FirstName,
                Email = client.Email,
                FullName = client.FullName,
                LastName = client.LastName,
                Phone = client.Phone,
                Image = client.Image,
                BioAr = client.BioAr,
                BioEn = client.BioEn,
                FullNameEn = client.FullNameEn,
                Key = _protector.Protect(client.ClientId.ToString()),
                IsEmailVerified=client.IsEmailVerified,
                IsActive=client.IsActive
            };
        }
        public string ValidateRegisterdClient(string email, string password)
        {
            Client client = GetClientByEmail(email);

            return client == null ? "1" : (client.Password == password && client.IsActive==false)?"2":"3";
        }

        public Client GetClientByEmail(string email)
        {
            return _repoWrapper.clientRepository.List().FirstOrDefault(x => x.Email == email && x.IsDeleted != true);
        }

        
        #endregion


    }

    public interface IClientService
    {
        List<Client> GetClients(int count = 0);
        List<ReaderVM> GetReaders(int count = 0);
        List<Audio> GetClientAudios(int clientId);
        List<AudioViewModel> GetClientAudioShare(int clientId);
        ClientViewModel GetClientData(int ClientId,int CurrentUserId);
        List<AudioViewModel> GetClientAudioWithComment(int clientId, int UserId, int langId, int count = 0);
        Client GetClient(int id);
        Client GetClientByEmail(string email);
        ClientViewModel ValidateClient(string email, string password);
        public string ValidateRegisterdClient(string email, string password);
        void CreateClient(Client Client);
        void UpdateClient(Client Client);
        void DeleteClient(int id);
        void SaveClient();
        string returnPeriod(DateTime dateFrom, int langId);
    }
}

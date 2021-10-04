using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public class ClientPlaylistService : IClientPlaylistService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;
        public ClientPlaylistService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
        }
        public void CreateClientPlaylist(ClientPlaylist ClientPlaylist)
        {
            _repoWrapper.clientPlaylistRepository.Add(ClientPlaylist);
        }

        public void DeleteClientPlaylist(int id)
        {
            var model = _repoWrapper.clientPlaylistRepository.Find(id);
            _repoWrapper.clientPlaylistRepository.Delete(model);
            _repoWrapper.clientPlaylistRepository.Commit();
        }

        public List<AudioViewModel> GetAudios(int playlistId)
        {
            return _repoWrapper.playlistAudioRepository.List().Where(x => x.ClientPlaylistId == playlistId).ToList().Select(x => new AudioViewModel
            {
                AudioId = x.AudioId,
                Key = _protector.Protect(x.AudioId.ToString()),
                AudioSrc = x.Audio.AudioSrc,
                BookImage = x.Audio.BookImage,
                BookNameAr = x.Audio.BookNameAr,
                BookNameEn = x.Audio.BookNameEn,
                AuthorNameAr = x.Audio.AuthorNameAr,
                AuthorNameEn = x.Audio.AuthorNameEn,
                PublisherNameAr = x.Audio.PublishType == PublishType.Admin ? "أديو كتاب" : _repoWrapper.clientRepository.Find(x.Audio.CreatedBy)?.FullName,
                PublisherNameEn = x.Audio.PublishType == PublishType.Admin ? "Audio Ketab" : _repoWrapper.clientRepository.Find(x.Audio.CreatedBy)?.FullNameEn,
                PublisherImage = x.Audio.PublishType == PublishType.Admin ? "logo.png" : _repoWrapper.clientRepository.Find(x.Audio.CreatedBy)?.Image,
                CategoryNameAr = x.Audio.Category.NameAr,
                CategoryNameEn = x.Audio.Category.NameEn,
                AudioTypeNameAr = x.Audio.AudioType.NameAr,
                AudioTypeNameEn = x.Audio.AudioType.NameEn,
                CategoryId = x.Audio.CategoryId,
                TypeId = x.Audio.AudioTypeId,
                ClientLikeIds = x.Audio.AudioActions.Where(x => x.Like == true).Select(x => x.ClientId).ToList(),
                PlaylistClientIds = x.Audio.PlaylistAudios.Select(x => x.ClientPlaylist.ClientId).ToList()
            }).ToList();
        }

        public ClientPlayListViewModel GetClientPlaylist(int id)
        {
            var model = _repoWrapper.clientPlaylistRepository.Find(id);
            return new ClientPlayListViewModel
            {
                ClientPlaylistId = model.ClientPlaylistId,
                Key = _protector.Protect(model.ClientPlaylistId.ToString()),
                NameAr = model.NameAr,
                NameEn = model.NameEn,
                DescAr = model.DescAr,
                DescEn = model.DescEn,
                AudiosCount = model.PlaylistAudios.Count
            };
        }

        public List<ClientPlayListViewModel> GetClientPlaylists(int clientId)
        {
            return _repoWrapper.clientPlaylistRepository.List().Where(x => x.ClientId == clientId && x.IsDeleted!=true).Select(x => new ClientPlayListViewModel
            {
                ClientPlaylistId = x.ClientPlaylistId,
                Key = _protector.Protect(x.ClientPlaylistId.ToString()),
                NameAr = x.NameAr,
                NameEn = x.NameEn,
                DescAr = x.DescAr,
                DescEn = x.DescEn,
                AudiosCount = x.PlaylistAudios.Count
            }).OrderByDescending(x => x.AudiosCount).ToList();
        }

        public List<ClientPlayListViewModel> GetClientPlaylistsByAudio(int clientId, int audioId)
        {
            return _repoWrapper.clientPlaylistRepository.List().Where(x => x.ClientId == clientId && x.IsDeleted!=true).Select(x => new ClientPlayListViewModel
            {
                ClientPlaylistId = x.ClientPlaylistId,
                Key = _protector.Protect(x.ClientPlaylistId.ToString()),
                NameAr = x.NameAr,
                NameEn = x.NameEn,
                DescAr = x.DescAr,
                DescEn = x.DescEn,
                HasAudio = x.PlaylistAudios.Select(p => p.AudioId).Contains(audioId),
                AudiosCount = x.PlaylistAudios.Count
            }).OrderByDescending(x => x.AudiosCount).ToList();
        }

        public string[] GetPlaylistAudiosSrc(int playlistId, string attachName)
        {
            return _repoWrapper.playlistAudioRepository.List().Where(x => x.ClientPlaylistId == playlistId).ToList().Select(x => attachName+x.Audio.AudioSrc).ToArray();
        }

        public void SaveClientPlaylist()
        {
            _repoWrapper.clientPlaylistRepository.Commit();
        }

        public void UpdateClientPlaylist(ClientPlaylist ClientPlaylist)
        {
            _repoWrapper.clientPlaylistRepository.Update(ClientPlaylist);
        }
    }
    public interface IClientPlaylistService
    {
        List<ClientPlayListViewModel> GetClientPlaylists(int clientId);
        List<ClientPlayListViewModel> GetClientPlaylistsByAudio(int clientId, int audioId);
        List<AudioViewModel> GetAudios(int playlistId);
        string[] GetPlaylistAudiosSrc(int playlistId,string attachName);
        ClientPlayListViewModel GetClientPlaylist(int id);
        void CreateClientPlaylist(ClientPlaylist ClientPlaylist);
        void UpdateClientPlaylist(ClientPlaylist ClientPlaylist);
        void DeleteClientPlaylist(int id);
        void SaveClientPlaylist();
    }
}

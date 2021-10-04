using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public class PlaylistAudioService : IPlaylistAudioService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;
        public PlaylistAudioService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
        }
        public void CreatePlaylistAudio(PlaylistAudio PlaylistAudio)
        {
            _repoWrapper.playlistAudioRepository.Add(PlaylistAudio);
        }

        public void DeletePlaylistAudio(int id)
        {
            var model = GetPlaylistAudio(id);
            _repoWrapper.playlistAudioRepository.Delete(model);
        }

        public void DeletePlaylistAudioByAudioId(int audioId, int clientId)
        {
            var audio = _repoWrapper.playlistAudioRepository.List().FirstOrDefault(x => x.AudioId == audioId && x.ClientPlaylist.ClientId == clientId);
            if(audio!=null)
            {
                _repoWrapper.playlistAudioRepository.Delete(audio);
                _repoWrapper.playlistAudioRepository.Commit();
            }
        }

        public int GetAudioId(int playlistId, string src)
        {
            return _repoWrapper.playlistAudioRepository.List().FirstOrDefault(x => x.ClientPlaylistId == playlistId && x.Audio.AudioSrc == src).AudioId;
        }

        public PlaylistAudio GetPlaylistAudio(int id)
        {
            return _repoWrapper.playlistAudioRepository.Find(id);
        }

        public List<ClientPlayListAudioViewModel> GetPlaylistAudios(int playlisId)
        {
            return _repoWrapper.playlistAudioRepository.List().Where(x => x.ClientPlaylistId == playlisId).Select(x => new ClientPlayListAudioViewModel
            {
                NameAr=x.Audio.BookNameAr,
                NameEn=x.Audio.BookNameEn,
                AudioSrc=x.Audio.AudioSrc,
                Image=x.Audio.BookImage
            }).ToList();
        }

        public void SavePlaylistAudio()
        {
            _repoWrapper.playlistAudioRepository.Commit();
        }

        public void UpdatePlaylistAudio(PlaylistAudio PlaylistAudio)
        {
            _repoWrapper.playlistAudioRepository.Update(PlaylistAudio);
        }
    }
    public interface IPlaylistAudioService
    {
        List<ClientPlayListAudioViewModel> GetPlaylistAudios(int playlistId);
        PlaylistAudio GetPlaylistAudio(int id);
        int  GetAudioId(int playlistId,string src);

        void CreatePlaylistAudio(PlaylistAudio PlaylistAudio);
        void UpdatePlaylistAudio(PlaylistAudio PlaylistAudio);
        void DeletePlaylistAudio(int id);
        void DeletePlaylistAudioByAudioId(int audioId,int clientId);

        void SavePlaylistAudio();
    }
}

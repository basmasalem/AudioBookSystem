using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
   public class AudioRepository : IRepository<Audio>, IAudioRepository
    {
        private readonly AudioKetabDbContext _db;
        public AudioRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(Audio entity)
        {
            _db.Audios.Add(entity);
        }

        public void Delete(Audio entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public Audio Find(int id)
        {
            return _db.Audios.Find(id);
        }

        public IQueryable<Audio> List()
        {
            return _db.Audios.Where(x => x.IsDeleted != true).OrderByDescending(x => x.CreationDate);
        }

        public void Update(Audio entity)
        {
            _db.Audios.Update(entity);
        }
        public void Commit()
        {
            _db.SaveChanges();
        }

        public int GetAudioCount()
        {
            return List().Count();
        }

        public AudioViewModel GetAudioDetails(int id)
        {
            var audio = Find(id);
            return audio != null ?
                new AudioViewModel
                {
                    ArticleUrl=audio.ArticleUrl,
                    AudioId=audio.AudioId,
                    AudioSrc=audio.AudioSrc,
                    AudioTypeNameAr=audio.AudioType.NameAr,
                    AudioTypeImage=audio.AudioType.Image,
                    AuthorNameAr=audio.AuthorNameAr,
                    AuthorNameEn=audio.AuthorNameEn,
                    BookImage=audio.BookImage,
                    BookNameAr=audio.BookNameAr,
                    BookNameEn=audio.BookNameEn ,
                    CategoryNameAr=audio.Category.NameAr,
                    CategoryNameEn=audio.Category.NameEn,
                    CreatedBy=audio.CreatedBy,
                    DescriptionAr=audio.DescriptionAr,
                    DescriptionEn=audio.DescriptionEn,
                    PublishType=audio.PublishType,
                    UploadType=audio.UploadType,
                    VideoUrl=audio.VideoUrl,
                    IsActive=audio.IsActive
                }
                : null;
        }

        public IList<PodcastAudioDataVM> GetAllPodcastAudioData(int AudioId)
        {
            return _db.PodcastAudio.Where(x => x.IsDeleted != true && x.AudioId == AudioId).Select(x => new PodcastAudioDataVM
            {
                BookImage = x.Audio.BookImage,
                BookNameAr = x.Audio.BookNameAr,
                BookNameEn = x.Audio.BookNameEn,
                PodcastAudioId = x.PodcastAudioId
            }).ToList();
        }
    }

    public interface IAudioRepository : IRepository<Audio>
    {
        public int GetAudioCount();

        public AudioViewModel GetAudioDetails(int id);
        public IList<PodcastAudioDataVM> GetAllPodcastAudioData(int AudioId);

    }
}


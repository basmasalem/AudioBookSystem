using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class PodcastAudioRepository : IRepository<PodcastAudio>, IPodcastAudioRepository
    {
        private readonly AudioKetabDbContext _db;
        public PodcastAudioRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(PodcastAudio entity)
        {
            _db.PodcastAudio.Add(entity);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(PodcastAudio entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public PodcastAudio Find(int id)
        {
            return _db.PodcastAudio.Find(id);
        }

        public IList<PodcastAudioDataVM> GetAllPodcastAudioData(int PodcastId)
        {
            return _db.PodcastAudio.Where(x => x.IsDeleted != true && x.PodcastId== PodcastId).Select(x => new PodcastAudioDataVM
            {
                BookImage=x.Audio.BookImage,
                BookNameAr= x.Audio.BookNameAr,
                BookNameEn = x.Audio.BookNameEn,
                PodcastAudioId=x.PodcastAudioId,
               
            }).OrderByDescending(x=>x.PodcastAudioId).ToList();
        }

        public PodcastAudioDataVM GetPodcastAudioData(int Id)
        {
            return _db.PodcastAudio.Where(x => x.IsDeleted != true && x.PodcastAudioId==Id).Select(x => new PodcastAudioDataVM
            {
                BookNameAr = x.Audio.BookNameAr,
                BookNameEn = x.Audio.BookNameEn,
                AudioSrc=x.Audio.AudioSrc
            }).FirstOrDefault();
        }

        public IQueryable<PodcastAudio> List()
        {
            return _db.PodcastAudio.Where(x => x.IsDeleted != true).OrderByDescending(x => x.PodcastAudioId);
        }

        public void Update(PodcastAudio entity)
        {
            _db.PodcastAudio.Update(entity);
        }
    }
    public interface IPodcastAudioRepository : IRepository<PodcastAudio>
    {

        public IList<PodcastAudioDataVM> GetAllPodcastAudioData(int PodcastId);
        public PodcastAudioDataVM GetPodcastAudioData(int Id);

       
    }
}

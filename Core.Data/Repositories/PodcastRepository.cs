using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class PodcastRepository : IRepository<Podcast>, IPodcastRepository
    {
        private readonly AudioKetabDbContext _db;

        public PodcastRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(Podcast entity)
        {
            _db.Podcast.Add(entity);
        }

        public void Delete(Podcast entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public Podcast Find(int id)
        {
            return _db.Podcast.Find(id);
        }

        public IQueryable<Podcast> List()
        {
            return _db.Podcast.Where(x => x.IsDeleted != true).OrderByDescending(x=>x.CreationDate);
        }

        public void Update(Podcast entity)
        {
            _db.Podcast.Update(entity);
        }
        public void Commit()
        {
            _db.SaveChanges();
        }

        public IList<PodcastViewModel> GetAllPodcastData()
        {
            return _db.Podcast.Where(x => x.IsDeleted != true).Select(x => new PodcastViewModel
            {
                PodcastId=x.PodcastId,
                Attachment=x.Attachment,
                Image=x.Image,
                StartDate=x.StartDate,
                CreatedBy=x.CreatedBy,
                PublishType=x.PublishType,
                Url=x.Url,
                NameAr=x.NameAr,
                NameEn =x.NameEn,
                IsActive=x.IsActive,
                Type=x.Type

            }).OrderByDescending(x=>x.PodcastId).ToList();
        }

        public PodcastViewModel GetPodcastData(int id)
        {
            return _db.Podcast.Where(x => x.IsDeleted != true && x.PodcastId == id).Select(x => new PodcastViewModel
            {
                PodcastId = x.PodcastId,
                Attachment = x.Attachment,
                Image = x.Image,
                StartDate = x.StartDate,
                CreatedBy = x.CreatedBy,
                PublishType = x.PublishType,
                Url = x.Url,
                NameAr = x.NameAr,
                NameEn = x.NameEn,
                DescAr = x.DescAr,
                DescEn = x.DescEn,
                IsActive = x.IsActive,
                Type=x.Type
            }).FirstOrDefault(); 
        }

        public Podcast CheckNameAr(string name)
        {
            return _db.Podcast.FirstOrDefault(x => x.NameAr == name && x.IsDeleted!=true);
        }

        public Podcast CheckNameEn(string name)
        {
            return _db.Podcast.FirstOrDefault(x => x.NameEn == name && x.IsDeleted != true);
        }

        public int GetPodcastCount()
        {
            return List().Count();
        }

        public IList<PodcastViewModel> GetLatestPodcast()
        {
            return _db.Podcast.Where(x => x.IsDeleted != true && x.IsActive==true).OrderByDescending(x=>x.CreationDate).Take(10).Select(x => new PodcastViewModel
            {
                PodcastId = x.PodcastId,
                Attachment = x.Attachment,
                Image = x.Image,
                StartDate = x.StartDate,
                CreatedBy = x.CreatedBy,
                PublishType = x.PublishType,
                Url = x.Url,
                NameAr = x.NameAr,
                NameEn = x.NameEn,
                IsActive = x.IsActive,
                Type=x.Type,
                DescAr=x.DescAr,
                DescEn=x.DescEn
            }).ToList();
        }

        public string GetOldImage(int id)
        {
            return Find(id).Image;
        }
    }
    public interface IPodcastRepository : IRepository<Podcast>
    {

        public IList<PodcastViewModel> GetAllPodcastData();
        public PodcastViewModel GetPodcastData(int id);
        public Podcast CheckNameAr(string name);
        public Podcast CheckNameEn(string name);
        public int GetPodcastCount();

        public IList<PodcastViewModel> GetLatestPodcast();
        public string GetOldImage(int id);

    }
}

using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class PodcastParticipantRepository : IRepository<PodcastParticipant>, IPodcastParticipantRepository
    {
        private readonly AudioKetabDbContext _db;
        public PodcastParticipantRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(PodcastParticipant entity)
        {
            _db.PodcastParticipant.Add(entity);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(PodcastParticipant entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public PodcastParticipant Find(int id)
        {
            return _db.PodcastParticipant.Find(id);
        }

        public IList<PodcastParticipantDataVM> GetAllPodcastParticipantData(int PodcastId)
        {
            return _db.PodcastParticipant.Where(x => x.IsDeleted != true && x.PodcastId == PodcastId).Select(x => new PodcastParticipantDataVM {
                ClientId = x.ClientId,
                ClientName = x.Client.FullName,
                CreatedDate = x.CreatedDate,
                ClientImg = x.Client.Image,
                PodcastParticipantId = x.PodcastParticipantId
            }).OrderByDescending(x=>x.PodcastParticipantId).ToList();
        }

        public IQueryable<PodcastParticipant> List()
        {
            return _db.PodcastParticipant.OrderByDescending(x=>x.PodcastParticipantId);
        }

        public void Update(PodcastParticipant entity)
        {
            _db.PodcastParticipant.Update(entity);
        }
    }
    public interface IPodcastParticipantRepository : IRepository<PodcastParticipant>
    {

        public IList<PodcastParticipantDataVM> GetAllPodcastParticipantData(int PodcastId);

    }
}

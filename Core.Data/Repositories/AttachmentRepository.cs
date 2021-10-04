using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class AttachmentRepository : IRepository<Attachment>, IAttachmentRepository
    {
        private readonly AudioKetabDbContext _db;
        public AttachmentRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(Attachment entity)
        {
            _db.Attachments.Add(entity);
            
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(Attachment entity)
        {
            _db.Attachments.Remove(entity);
        }

        public Attachment Find(int id)
        {
            return _db.Attachments.SingleOrDefault(x => x.AttachmentId == id);
        }

        public IQueryable<Attachment> List()
        {
            return _db.Attachments;
        }

        public void Update(Attachment entity)
        {
            _db.Attachments.Update(entity);
        }
    }
    public interface IAttachmentRepository : IRepository<Attachment>
    {

    }
}

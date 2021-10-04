using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class PrintBookRepository : IRepository<PrintBook>, IPrintBookRepository
    {
        private readonly AudioKetabDbContext _db;
        public PrintBookRepository(AudioKetabDbContext db)
        {
            _db = db;
        }
        public void Add(PrintBook entity)
        {
            _db.PrintBooks.Add(entity);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(PrintBook entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public PrintBook Find(int id)
        {
            return _db.PrintBooks.Find(id);
        }

        public IQueryable<PrintBook> List()
        {
            return _db.PrintBooks.Where(x => x.IsDeleted != true).OrderByDescending(x=>x.PrintBookId);
        }

        public void Update(PrintBook entity)
        {
            _db.PrintBooks.Update(entity);
        }
    }
    public interface IPrintBookRepository : IRepository<PrintBook>
    {
    }
}

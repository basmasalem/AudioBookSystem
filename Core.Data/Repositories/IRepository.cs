using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Commit();

    }
}

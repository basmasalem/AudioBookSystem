using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data.Repositories
{
    public class SettingRepository : IRepository<Setting>, ISettingRepository
    {
        private readonly AudioKetabDbContext _db;
        public SettingRepository(AudioKetabDbContext db)
        {
            _db = db;
        }

        public void Add(Setting entity)
        {
            _db.Setting.Add(entity);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Delete(Setting entity)
        {
            _db.Setting.Remove(entity);
        }

        public Setting Find(int id)
        {
            return _db.Setting.Find(id);
        }

        public Setting GetSetting()
        {
            var Setting = _db.Setting.FirstOrDefault();
            return Setting ?? new Setting() ;
        }

        public IQueryable<Setting> List()
        {
            return _db.Setting;
        }

        public void Update(Setting entity)
        {
            _db.Setting.Update(entity);
        }
    }
    public interface ISettingRepository : IRepository<Setting>
    {
        public Setting GetSetting();
    }
}

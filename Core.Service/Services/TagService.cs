using Core.Data;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public class TagService : ITagService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public TagService(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }

        #region ITagService Members
        public List<Tag> GetTags(int count=0)
        {
            List<Tag> list = _repoWrapper.tagRepository.List().ToList();
            return count == 0 ? list : list.Take(count).ToList();
        }
        public Tag GetTag(int id)
        {
            return _repoWrapper.tagRepository.Find(id);
        }

        public void CreateTag(Tag Tag)
        {
            _repoWrapper.tagRepository.Add(Tag);
        }

        public void UpdateTag(Tag Tag)
        {
            _repoWrapper.tagRepository.Update(Tag);
        }
        public void DeleteTag(int id)
        {
            Tag Tag = GetTag(id);
            Tag.IsDeleted = true;
            UpdateTag(Tag);
            SaveTag();
        }

        public void SaveTag()
        {
            _repoWrapper.Save();
        }
        #endregion


    }

    public interface ITagService
    {
        List<Tag> GetTags(int count=0);
        Tag GetTag(int id);
        void CreateTag(Tag Tag);
        void UpdateTag(Tag Tag);
        void DeleteTag(int id);
        void SaveTag();
    }
}

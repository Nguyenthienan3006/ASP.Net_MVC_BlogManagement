using BM.Model;
using BM.Data;

namespace BM.Domain
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDbContext _dbContext;

        public TagRepository()
        {
            _dbContext = new BlogDbContext();
        }
        public void AddTag(Tag Tag)
        {
            _dbContext.Tags.Add(Tag);
            _dbContext.SaveChanges();
        }
        public void DeleteTag(int TagId)
        {
            var tag = Find(TagId);
            if (tag != null)
            {
                _dbContext.Tags.Remove(tag);
                _dbContext.SaveChanges();
            }
        }

        public Tag Find(int TagId)
        {
            return _dbContext.Tags.FirstOrDefault(t => t.Id == TagId);
        }

        public List<Tag> GetAllTags()
        {
            return _dbContext.Tags.ToList();
        }
        //1
        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return _dbContext.Tags.FirstOrDefault(t => t.UrlSlug == urlSlug);
        }

        public void UpdateTag(Tag Tag)
        {
            _dbContext.Tags.Update(Tag);
            _dbContext.SaveChanges();
        }
    }
}

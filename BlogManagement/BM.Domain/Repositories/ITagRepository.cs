using BM.Model;

namespace BM.Domain
{
    public interface ITagRepository
    {
        Tag Find(int TagId);
        void AddTag(Tag Tag);
        void UpdateTag(Tag Tag);
        void DeleteTag(int TagId);
        List<Tag> GetAllTags();
        Tag GetTagByUrlSlug(string urlSlug);
    }
}

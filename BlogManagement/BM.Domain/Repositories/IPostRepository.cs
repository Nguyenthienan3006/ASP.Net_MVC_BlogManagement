using BM.Model;

namespace BM.Domain
{
    public interface IPostRepository
    {
        Post FindPost(int year, int month, string urlSlug);
        Post FindPost(int postId);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int postId);
        IList<Post> GetAllPosts();
        IList<Post> GetPublisedPosts();
        IList<Post> GetUnpublisedPosts();
        Post GetLatestPost();
        IList<Post> GetPostsByMonth(DateTime monthYear);
        int CountPostsForCategory(int categoryId);
        IList<Post> GetPostsByCategory(int categoryId);
        int CountPostsForTag(int tagId);
        IList<Post> GetPostsByTag(string tag);
    }
}

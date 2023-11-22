using BM.Model;
using BM.Data;
using Microsoft.EntityFrameworkCore;

namespace BM.Domain
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _DbContext;

        public PostRepository()
        {
            _DbContext = new BlogDbContext();
        }
        public void AddPost(Post post)
        {
            _DbContext.Posts.Add(post);
            _DbContext.SaveChanges();
        }

        public int CountPostsForCategory(int category)
        {
            return _DbContext.Posts.Count(p => p.CategoryId == category);
        }

        public int CountPostsForTag(int tagId)
        {
            return _DbContext.Posts.SelectMany(p => p.PostTagMap).Count(ptm => ptm.Tag.Id == tagId);
        }

        public void DeletePost(int postId)
        {
            var post = FindPost(postId);
            if(post != null)
            {
                _DbContext.Posts.Remove(post);
                _DbContext.SaveChanges();
            }
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1);

            return _DbContext.Posts.FirstOrDefault(p => p.PostedOn >= startDate 
            && p.PostedOn < endDate && p.UrlSlug == urlSlug);
        }

        public Post FindPost(int postId)
        {
            return _DbContext.Posts.FirstOrDefault(p => p.Id == postId);
        }

        public IList<Post> GetAllPosts()
        {
            return _DbContext.Posts.ToList();
        }

        public Post GetLatestPost()
        {
            return _DbContext.Posts.OrderByDescending(p => p.Id).FirstOrDefault();
        }

        public IList<Post> GetPostsByCategory(int categoryId)
        {
            return _DbContext.Posts.Where(p => p.Category.Id == categoryId).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            var startDate = new DateTime(monthYear.Year, monthYear.Month, 1);
            var endDate = startDate.AddMonths(1);

            return _DbContext.Posts.Where(p => p.PostedOn >= startDate && p.PostedOn < endDate).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return _DbContext.Posts.Where(p => p.PostTagMap.Any(ptm => ptm.Tag.Name == tag)).ToList();
        }

        public IList<Post> GetPublisedPosts()
        {
            return _DbContext.Posts.Where(p => p.Published != null).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return _DbContext.Posts.Where(p => p.Published == null).ToList();
        }

        public void UpdatePost(Post post)
        {
            _DbContext.Posts.Update(post);
            _DbContext.SaveChanges();
        }

    }
}

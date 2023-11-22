using BM.Model;
namespace BM.Web_Mvc.Models
{
    public class Post_CountPostsForTagVM
    {
        public List<Tag> TagList { get; set; }
        public int? PostCountByTag { get; set; }

    }
}

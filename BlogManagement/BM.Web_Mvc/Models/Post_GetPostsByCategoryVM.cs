using BM.Model;

namespace BM.Web_Mvc.Models
{
    public class Post_GetPostsByCategoryVM
    {
        public List<Category> Categories { get; set; }
        public IList<Post> Posts { get; set; }
    }
}

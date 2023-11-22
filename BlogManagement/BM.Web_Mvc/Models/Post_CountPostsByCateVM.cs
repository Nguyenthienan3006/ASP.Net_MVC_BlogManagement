using BM.Model;

namespace BM.Web_Mvc.Models
{
    public class Post_CountPostsByCateVM
    {
        public List<Category> Categories { get; set; }
        public int? PostCount { get; set; }
    }
}

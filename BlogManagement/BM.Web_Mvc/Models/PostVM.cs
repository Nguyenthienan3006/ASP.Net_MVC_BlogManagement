namespace BM.Web_Mvc.Models
{
    public class PostVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string PostContent { get; set; }
        public string UrlSlug { get; set; }
        public DateTime? Published { get; set; }
        public DateTime? PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public int CategoryId { get; set; }
    }
}

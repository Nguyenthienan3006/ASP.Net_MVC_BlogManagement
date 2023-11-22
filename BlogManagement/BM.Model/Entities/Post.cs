using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BM.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [StringLength(255)]
        public string ShortDescription { get; set; }
        [StringLength(255)]
        public string PostContent { get; set; }
        public string UrlSlug { get; set; }
        public DateTime? Published { get; set; }
        public DateTime? PostedOn { get; set;}
        public DateTime? Modified { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IList<PostTagMap> PostTagMap { get; set; }
    }
}

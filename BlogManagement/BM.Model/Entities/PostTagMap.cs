using System.ComponentModel.DataAnnotations.Schema;

namespace BM.Model
{
    public class PostTagMap
    {
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Tag Tag { get; set; }
        public Post Post { get; set; }
    }
}

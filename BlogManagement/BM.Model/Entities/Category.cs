using System.ComponentModel.DataAnnotations;

namespace BM.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string UrlSlug { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        public virtual IList<Post> Posts { get; set; }
    }
}

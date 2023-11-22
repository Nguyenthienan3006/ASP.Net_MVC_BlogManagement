using BM.Model;
using Microsoft.EntityFrameworkCore;
namespace BM.Data
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-VN7D46F; database = BlogDb; Trusted_Connection=True; " +
                "TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //config relationship between Tag and Post through PostTagMap (many to many)
            modelBuilder.Entity<PostTagMap>()
            .HasOne<Tag>(pt => pt.Tag)
            .WithMany(t => t.PostTagMap)
            .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<PostTagMap>()
            .HasOne<Post>(pt => pt.Post)
            .WithMany(p => p.PostTagMap)
            .HasForeignKey(pt => pt.PostId);

            //config PostTagMap has PK(TagId,PostId)
            modelBuilder.Entity<PostTagMap>().HasKey(pt => new { pt.TagId, pt.PostId });
        }
    }
}

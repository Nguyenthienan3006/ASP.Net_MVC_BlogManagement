using BM.Model;
using BM.Data;

namespace BM.Domain
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogDbContext _dbContext;

        public CategoryRepository()
        {
            _dbContext = new BlogDbContext();
        }

        public Category FindCategory(int id)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }
        public int AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            return _dbContext.SaveChanges();
        }

        public int DeleteCategory(int categoryId)
        {
            var student = FindCategory(categoryId);
            if(student != null)
            {
                _dbContext.Categories.Remove(student);
                return _dbContext.SaveChanges();
            }
            return 0;
        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public int UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            return _dbContext.SaveChanges();
        }
    }
}

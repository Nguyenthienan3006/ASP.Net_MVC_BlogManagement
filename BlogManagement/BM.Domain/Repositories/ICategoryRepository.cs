using BM.Model;

namespace BM.Domain
{
    public interface ICategoryRepository
    {
        Category FindCategory(int categoryId);
        int AddCategory(Category category);
        int UpdateCategory(Category category);
        int DeleteCategory(int categoryId);
        List<Category> GetAllCategories();
    }
}

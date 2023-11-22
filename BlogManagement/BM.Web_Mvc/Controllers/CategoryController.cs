using BM.Domain;
using BM.Model;
using Microsoft.AspNetCore.Mvc;

namespace BM.Web_Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var category = _repository.GetAllCategories();
            return View(category);
        }
        public IActionResult Delete(int? Id) 
        {
            if (Id.HasValue)
            {
                _repository.DeleteCategory(Id.Value);
            }   
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name, string UrlSlug, string Description)
        {
            _repository.AddCategory(new Model.Category()
            {
                Name = Name,
                UrlSlug = UrlSlug,
                Description = Description
            });
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? Id)
        {
            if (Id.HasValue)
            {
                var cate = _repository.FindCategory(Id.Value);
                return View(cate);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(int? Id, Category category)
        {
            if (category.Name != null)
            {
                _repository.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }
    }
}

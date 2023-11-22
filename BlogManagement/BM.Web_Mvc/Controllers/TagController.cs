using BM.Domain;
using BM.Model;
using Microsoft.AspNetCore.Mvc;

namespace BM.Web_Mvc.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _repository;

        public TagController(ITagRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var tag = _repository.GetAllTags();
            return View(tag);
        }
        public IActionResult Delete(int? Id) 
        {
            if (Id.HasValue)
            {
                _repository.DeleteTag(Id.Value);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name, string UrlSlug, string Description, int Count)
        {
            _repository.AddTag(new Model.Tag()
            {
                Name = Name,
                UrlSlug = UrlSlug,
                Description = Description,
                Count = Count
            });
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? Id) 
        {
            if (Id.HasValue)
            {
                var tag = _repository.Find(Id.Value);
                return View(tag);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(int? Id, Tag tag) 
        {
            if(tag.Name != null)
            {
                _repository.UpdateTag(tag);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }
        public IActionResult GetTagByUrlSlug()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetTagByUrlSlug(string UrlSlug)
        {
            if (UrlSlug != null)
            {
                var tag = _repository.GetTagByUrlSlug(UrlSlug);
                return View(tag);
            }
            return RedirectToAction("Index");
        }
    }
}

using BM.Domain;
using BM.Model;
using BM.Web_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;


namespace BM.Web_Mvc.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _repository;
        private readonly ICategoryRepository _cateRepository;
        private readonly ITagRepository _tagRepository;

        public PostController(IPostRepository repository, ICategoryRepository cateRepository, 
            ITagRepository tagRepository)
        {
            _repository = repository;
            _cateRepository = cateRepository;
            _tagRepository = tagRepository;
        }
        public IActionResult Index()
        {
            var post = _repository.GetAllPosts();
            return View(post);
        }
        public IActionResult Delete(int? Id)
        {
            if (Id.HasValue)
            {
                _repository.DeletePost(Id.Value);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            var category = _cateRepository.GetAllCategories();
            return View(category);
        }
        [HttpPost]
        public IActionResult Create(string Title, string ShortDescription, string PostContent, string UrlSlug,
            int CategoryId)
        {
            _repository.AddPost(new Model.Post()
            {
                Title = Title,
                ShortDescription = ShortDescription,
                PostContent = PostContent,
                UrlSlug = UrlSlug,
                Published = DateTime.Now,
                PostedOn = DateTime.Now,
                Modified = DateTime.Now,
                CategoryId = CategoryId
            });
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? Id)
        {
            if (Id.HasValue)
            {
                var post = _repository.FindPost(Id.Value);
                return View(post);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(int? Id, Post post)
        {
            if (post.Title != null)
            {
                _repository.UpdatePost(post);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }
        public IActionResult CountPostsForCategory()
        {
            var viewModel = new Post_CountPostsByCateVM()
            {
                Categories = _cateRepository.GetAllCategories()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CountPostsForCategory(int? CategoryId)
        {
            if (CategoryId.HasValue)
            {
                var viewModel = new Post_CountPostsByCateVM()
                {
                    Categories = _cateRepository.GetAllCategories(),
                    PostCount = _repository.CountPostsForCategory(CategoryId.Value)
                };
                return View(viewModel);
            }
            return RedirectToAction("CountPostsForCategory");
        }

        public IActionResult CountPostsForTag()
        {
            var viewModel2 = new Post_CountPostsForTagVM()
            {
                TagList = _tagRepository.GetAllTags()
            };
            return View(viewModel2);
        }
        [HttpPost]
        public IActionResult CountPostsForTag(int? Id)
        {
            if (Id.HasValue)
            {
                var viewModel = new Post_CountPostsForTagVM()
                {
                    TagList = _tagRepository.GetAllTags(),
                    PostCountByTag = _repository.CountPostsForTag(Id.Value)
                };
                return View(viewModel);
            }
            return RedirectToAction("CountPostsForTag");
        }

        public IActionResult GetLatestPost()
        {
            var latestPost = _repository.GetLatestPost();
            return View(latestPost);
        }

        public IActionResult GetPostsByCategory()
        {
            var viewModel = new Post_GetPostsByCategoryVM()
            {
                Categories = _cateRepository.GetAllCategories(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult GetPostsByCategory(int? CategoryId)
        {
            if (CategoryId.HasValue)
            {
                var viewModel = new Post_GetPostsByCategoryVM()
                {
                    Categories = _cateRepository.GetAllCategories(),
                    Posts = _repository.GetPostsByCategory(CategoryId.Value)
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }
        public IActionResult GetPostByMonth()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetPostByMonth(int year, int month, string urlSlug)
        {
            var post = _repository.FindPost(year, month, urlSlug);

            if (post != null)
            {
                return View(post);
            }
            return RedirectToAction("Index");
            
        }
    }
}

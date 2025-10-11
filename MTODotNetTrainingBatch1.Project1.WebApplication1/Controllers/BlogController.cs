using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTODotNetTrainingBatch1.Project1.Database.Models;
using MTODotNetTrainingBatch1.Project1.Domain;

namespace MTODotNetTrainingBatch1.Project1.WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult GetAllBlog()
        {
            var model = _blogService.GetAllBlog();
            return Ok(model);
        }

        [HttpGet("{pageNo}/{pageSize}")]
        public IActionResult GetBlogWithPagination(int pageNo,int pageSize)
        {
            var model = _blogService.GetBlogWithPagination(pageNo, pageSize); 
            return StatusCode(200,model);
        }

        [HttpGet("{blogId}")]        
        public IActionResult GetByEachBlog(int blogId)
        {
            var model = _blogService.GetByEachBlog(blogId);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateBlog(TblBlog blog)
        {
            _blogService.CreateBlog(blog);
            return Ok(blog);
        }
    }
}

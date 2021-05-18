using Microsoft.AspNetCore.Mvc;
using Webservice.Models;
using Webservice.Services;

namespace Webservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("{id}")]
        public Article Get(int id) => _articleService.Get(id);
    }
}

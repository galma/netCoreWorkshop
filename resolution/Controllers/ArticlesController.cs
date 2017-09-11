using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using resolution.Entities;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace resolution.Controllers
{
    [Route("/api/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly ArticlesContext _context;
        private readonly ILogger<ArticlesController> _logger; 

        public ArticlesController(ArticlesContext context, ILogger<ArticlesController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet("{id:int}")]
        public async Task<Article> Get(int id)
        {
            var article = await _context.Articles.SingleOrDefaultAsync(m => m.Id == id);
            
            return article;
        }

        public async Task<IEnumerable<Article>> Get() => await _context.Set<Article>().ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Article article)
        {
            _logger.LogDebug("Starting save");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Articles.Add(new Article { Title = article.Title });
            await _context.SaveChangesAsync(); 

            _logger.LogDebug("Finished save");

            return CreatedAtAction(nameof(Get), new { id = article.Title }, article);
        }

         private static List<Article> _Articles = new List<Article>(new[] {
          new Article() { Id = 1, Title = "Intro to ASP.NET Core" },
          new Article() { Id = 2, Title = "Docker Fundamentals" },
          new Article() { Id = 3, Title = "Deploying to Azure with Docker" },
      });
    }
}
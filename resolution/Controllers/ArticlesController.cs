using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace res.Controllers
{
    [Route("/api/[controller]")]
    public class ArticlesController : Controller
    {
        [HttpGet]
        public string Get() => "Hello, from the controller!";
    }
}
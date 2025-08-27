using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class TagController : Controller
    {
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //private string CreateToken(User user)
        //{

        //}
    }
}

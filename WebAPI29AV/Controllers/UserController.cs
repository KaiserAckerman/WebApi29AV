using Microsoft.AspNetCore.Mvc;

namespace WebAPI29AV.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace RoutingWithoutMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        [Route("~/User")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("{name?}")]
        public string UserDetails(string? name)
        {
            return "User Name is " + (name ?? "Rohit");
        }
    }
}
